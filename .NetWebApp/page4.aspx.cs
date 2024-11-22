using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class page4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null && Request.UrlReferrer.OriginalString.Contains("page3"))
            {
                VerifyServiceStatus();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                Response.Redirect("~/page1.aspx");
            }
        }

        private void VerifyServiceStatus()
        {
            string address = "";
            int port = 0;
            string status = null;
            string DB = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Lab5;Integrated Security=True";

            if (!int.TryParse(Request.QueryString["serviceId"], out int serviceId))
            {
                foreach (Control control in form1.Controls)
                {
                    if (control is Button button && button.ID == "HomeButton")
                    {
                        button.Style["background-color"] = "red";
                        button.Text = "НА ГОЛОВНУ";
                        button.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
                Response.Write("<p style='font-size: 20px; color: red;'>Неправильна ID служби.</p>");

                return;
            }

            string query = "SELECT Address, Port, Icon, Email, LastCheck, Status FROM TcpServices WHERE ID = @serviceId";

            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@serviceId", serviceId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        address = reader["Address"].ToString();
                        port = Convert.ToInt32(reader["Port"]);
                    }
                }
            }
            int connectionTimeout = 3000; 

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    var connectTask = client.ConnectAsync(address, port);
                    if (connectTask.Wait(connectionTimeout)) 
                    {
                        ServiceStatusLabel.Text = "<span style='color: green;'>Service is ONLINE</span>";
                        status = "ПРАЦЮЄ";
                    }
                    else
                    {
                        ServiceStatusLabel.Text = "<span style='color: red;'>Service is OFFLINE - Connection attempt timed out.</span>";
                        status = "НЕ ПРАЦЮЄ";
                    }
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.ConnectionRefused)
                    {
                        ServiceStatusLabel.Text = "<span style='color: red;'>Service is OFFLINE - Connection actively refused.</span>";
                    }
                    else
                    {
                        ServiceStatusLabel.Text = $"<span style='color: red;'>Service is OFFLINE - Error: {ex.Message}</span>";
                    }
                    status = "НЕ ПРАЦЮЄ";
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SocketException innerEx && innerEx.SocketErrorCode == SocketError.ConnectionRefused)
                    {
                        ServiceStatusLabel.Text = "<span style='color: red;'>Service is OFFLINE - Connection actively refused.</span>";
                        status = "НЕ ПРАЦЮЄ";
                    }
                    else
                    {
                        ServiceStatusLabel.Text = $"<span style='color: red;'>Service is OFFLINE - General error: {ex.Message}</span>";
                        status = "НЕ ПРАЦЮЄ";
                    }
                }
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Lab5;Integrated Security=True";
            query = "UPDATE TcpServices SET LastCheck = @LastCheck, Status = @Status WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand Comm = new SqlCommand(query, conn))
                {
                    Comm.Parameters.AddWithValue("@LastCheck", DateTime.Now);
                    Comm.Parameters.AddWithValue("@Status", status);
                    Comm.Parameters.AddWithValue("@Id", serviceId);
                    Comm.ExecuteNonQuery();
                }
            }

            System.Threading.Thread.Sleep(500);
            VerificationStatusLabel.Text = "<span style='color: green;'>Email verification successful!</span>";
        }


        protected void HomeButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            Response.Redirect("~/page1.aspx");
        }
    }
}