using System.Runtime.InteropServices;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace UDP_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelTime.Text = DateTime.Now.ToString();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetSystemTime(ref SYSTEMTIME st);

        private string SendRequestToServer(string requestXml, string serverIp)
        {
            try
            {
                string F = File.ReadAllText(requestXml, Encoding.GetEncoding(1251));
                byte[] M = Encoding.GetEncoding(1251).GetBytes(F);
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), 51000);
                byte[] bytes = new byte[1000000];

                using (Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    S.SendTimeout = 5000; 
                    S.ReceiveTimeout = 5000;
                    S.Connect(ipEndPoint);
                    S.Send(M);

                    int bytesRec = S.Receive(bytes);
                    string Answer = Encoding.GetEncoding(1251).GetString(bytes, 0, bytesRec);
                    S.Shutdown(SocketShutdown.Both);
                    return Answer;
                }
            }
            catch (SocketException ex)
            {
                LogError($"Socket Error: {ex.Message}");
                MessageBox.Show("Помилка підключення до сервера. Перевірте IP-адресу та підключення.", "Помилка");
            }
            catch (Exception ex)
            {
                LogError($"Unexpected Error: {ex.Message}");
                MessageBox.Show("Виникла неочікувана помилка при обробці запиту.", "Помилка");
            }
            return string.Empty;
        }


        private void LogError(string message)
        {
            using (StreamWriter writer = new StreamWriter(@"ErrorLog.txt", true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        private void UpdateSystemTime(DateTime newTime)
        {
            SYSTEMTIME st = new SYSTEMTIME
            {
                wYear = (ushort)newTime.Year,
                wMonth = (ushort)newTime.Month,
                wDay = (ushort)newTime.Day,
                wHour = (ushort)newTime.Hour,
                wMinute = (ushort)newTime.Minute,
                wSecond = (ushort)newTime.Second,
                wMilliseconds = (ushort)newTime.Millisecond
            };

            if (SetSystemTime(ref st))
            {
                MessageBox.Show($"Системний час успішно змінено на: {newTime.AddHours(2):yyyy-MM-dd HH:mm:ss}");
            }
            else
            {
                int errorCode = Marshal.GetLastWin32Error();
                LogError($"Не вдалося змінити системний час. Код помилки: {errorCode}");
                MessageBox.Show("Не вдалося змінити системний час.");
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonShowTable_Click_1(object sender, EventArgs e)
        {
            string requestXml = "<Request>Kyiv&amp;London</Request>";
            File.WriteAllText(@"Request-2.xml", requestXml);

            string serverIp = textBoxServerIP.Text;
            string responseXml = SendRequestToServer(@"Request-2.xml", serverIp);

            File.WriteAllText(@"Response-2.xml", responseXml);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Місто", typeof(string));
            dataTable.Columns.Add("Дата", typeof(string));
            dataTable.Columns.Add("Час", typeof(string));

            try
            {
                XmlDocument responseDoc = new XmlDocument();
                responseDoc.LoadXml(responseXml);

                XmlNode kyivNode = responseDoc.SelectSingleNode("/Times/Kyiv");
                string kyivDate = kyivNode.SelectSingleNode("Date").InnerText;
                string kyivTime = kyivNode.SelectSingleNode("Time").InnerText;
                dataTable.Rows.Add("Київ", kyivDate, kyivTime);

                XmlNode londonNode = responseDoc.SelectSingleNode("/Times/London");
                string londonDate = londonNode.SelectSingleNode("Date").InnerText;
                string londonTime = londonNode.SelectSingleNode("Time").InnerText;
                dataTable.Rows.Add("Лондон", londonDate, londonTime);
            }
            catch (Exception ex)
            {
                LogError($"XML Processing Error: {ex.Message}");
            }

            dataGridViewTimes.DataSource = dataTable;
        }

        private void buttonSyncTime_Click_1(object sender, EventArgs e)
        {
            string cityRequest = checkBoxLondonTime.Checked ? "London_Time" : "Kyiv_Time";
            string requestXml = $"<Request>{cityRequest}</Request>";
            File.WriteAllText(@"Request-1.xml", requestXml);

            string serverIp = textBoxServerIP.Text; 
            string responseXml = SendRequestToServer(@"Request-1.xml", serverIp);

            File.WriteAllText(@"Response-1.xml", responseXml);

            try
            {
                XmlDocument responseDoc = new XmlDocument();
                responseDoc.LoadXml(responseXml);

                string city = responseDoc.SelectSingleNode("/Time/City").InnerText; 
                string date = responseDoc.SelectSingleNode("/Time/Date").InnerText;
                string time = responseDoc.SelectSingleNode("/Time/Time").InnerText;

                DateTime receivedTime = DateTime.Parse($"{date} {time}");

                DateTime localTime = receivedTime.AddHours(-2);

                labelTime.Text = $"Встановлено дату і час {city}: {receivedTime}";

                UpdateSystemTime(localTime);
            }
            catch (Exception ex)
            {
                LogError($"XML Processing Error: {ex.Message}");
            }
        }

    }
}
