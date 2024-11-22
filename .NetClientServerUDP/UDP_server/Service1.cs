using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace UDP_server
{
    public partial class Service1 : ServiceBase
    {
        private Thread wmiThread;
        private Thread udpThread;
        private ManagementEventWatcher watcher;
        private UdpClient udpServer;
        private bool mustStop = false;
        private string logFilePath = @"C:\STUDY\Laba-4.log";
        private string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            wmiThread = new Thread(MonitorFileDeletions);
            wmiThread.Start();

            udpThread = new Thread(ServerLoop);
            udpThread.Start();

            LogEvent("File Deletion Watcher Service Started.");
        }
        protected override void OnStop()
        {
            mustStop = true;

            watcher.Stop();
            watcher.Dispose();
            wmiThread.Join();

            udpServer?.Close();
            udpThread.Join();

            LogEvent("Service stopped.");
        }
        private void MonitorFileDeletions()
        {
            string queryString = "SELECT * FROM __InstanceDeletionEvent WITHIN 5 WHERE " +
                                 "TargetInstance ISA 'CIM_DataFile' AND " +
                                 "TargetInstance.Drive = 'C:' AND " +
                                 "TargetInstance.Path = '\\\\WMI-Files\\\\'";

            watcher = new ManagementEventWatcher(queryString);
            watcher.EventArrived += new EventArrivedEventHandler(OnFileDeleted);
            watcher.Start();
        }
        private void OnFileDeleted(object sender, EventArrivedEventArgs e)
        {
            var filePath = e.NewEvent["TargetInstance"] as ManagementBaseObject;
            string deletedFilePath = filePath?["Name"].ToString();
            LogEvent($"File Deleted: {deletedFilePath}");
        }



        private void ServerLoop()
        {
            IPAddress ip = IPAddress.Any;
            IPEndPoint endPoint = new IPEndPoint(ip, 51000);
            udpServer = new UdpClient(endPoint);

            try
            {
                while (!mustStop)
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] buffer = udpServer.Receive(ref remoteEndPoint);
                    string requestXml = Encoding.UTF8.GetString(buffer);

                    if (requestXml.Contains("Kyiv&amp;London"))
                    {
                        File.WriteAllText(Path.Combine(workingDirectory, "Request-2.xml"), requestXml);
                        string responseXml = ProcessKyivLondonRequest();
                        File.WriteAllText(Path.Combine(workingDirectory, "Response-2.xml"), responseXml);

                        byte[] responseBytes = Encoding.UTF8.GetBytes(responseXml);
                        udpServer.Send(responseBytes, responseBytes.Length, remoteEndPoint);
                    }
                    else
                    {
                        File.WriteAllText(Path.Combine(workingDirectory, "Request-1.xml"), requestXml);
                        string responseXml = ProcessRequest(requestXml);

                        File.WriteAllText(Path.Combine(workingDirectory, "Response-1.xml"), responseXml);
                        byte[] responseBytes = Encoding.UTF8.GetBytes(responseXml);
                        udpServer.Send(responseBytes, responseBytes.Length, remoteEndPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvent($"UDP-server Error: {ex.Message}");
            }
            finally
            {
                udpServer.Close();
            }
        }

        private string ProcessKyivLondonRequest()
        {
            try
            {
                string kyivTime = GetWmiDateTime("Win32_LocalTime");
                string londonTime = GetWmiDateTime("Win32_UTCTime");

                string responseXml = $@"
        <Times>
            <Kyiv>
                <Date>{kyivTime.Split(' ')[0]}</Date>
                <Time>{kyivTime.Split(' ')[1]}</Time>
            </Kyiv>
            <London>
                <Date>{londonTime.Split(' ')[0]}</Date>
                <Time>{londonTime.Split(' ')[1]}</Time>
            </London>
        </Times>";
                return responseXml;
            }
            catch (Exception ex)
            {
                LogEvent($"Error processing Kyiv&London request: {ex.Message}");
                return "<Error>Failed to retrieve Kyiv and London time</Error>";
            }
        }

        private string GetWmiDateTime(string className)
        {
            ManagementClass mc = new ManagementClass(className);
            foreach (ManagementObject mo in mc.GetInstances())
            {
                return $"{mo["Day"]}.{mo["Month"]}.{mo["Year"]} {mo["Hour"]}:{mo["Minute"]}:{mo["Second"]}"; 
            }
            return null;
        }

        private string ProcessRequest(string requestXml)
        {
            if (string.IsNullOrWhiteSpace(requestXml))
            {
                LogEvent("Received an empty or null request.");
                return "<Error>Empty request received</Error>";
            }

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(requestXml); 
                string city = doc.DocumentElement.InnerText;

                DateTime currentTime = city == "Kyiv_Time" ? DateTime.Now : DateTime.UtcNow;
                string response = $"<Time><City>{city.Replace("_Time", "")}</City><Date>{currentTime:yyyy-MM-dd}</Date><Time>{currentTime:HH:mm:ss}</Time></Time>"; 
                return response;
            }
            catch (XmlException ex)
            {
                LogEvent($"XML Parsing Error: {ex.Message}");
                return "<Error>Invalid XML format</Error>";
            }
            catch (Exception ex)
            {
                LogEvent($"Unexpected error in ProcessRequest: {ex.Message}");
                return "<Error>Unexpected processing error</Error>";
            }
        }


        private void LogEvent(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
