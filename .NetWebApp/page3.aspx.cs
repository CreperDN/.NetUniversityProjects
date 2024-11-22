using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Services.Description;

namespace WebApp
{
    public partial class page3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null && Request.UrlReferrer.OriginalString.Contains("page2"))
                {
                    SendOtpToEmail();

                }
                else
                {

                    Response.Redirect("~/page1.aspx");
                }
            }
        }

        private void SendOtpToEmail()
        {
            string recipientEmail = "";
            string DB = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Lab5;Integrated Security=True";
            if (!int.TryParse(Request.QueryString["serviceId"], out int serviceId))
            {
                foreach (Control control in form1.Controls)
                {
                    if (control is Button button && button.ID == "BackButton")
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
                        recipientEmail = reader["Email"].ToString();
                    }
                }
            }

            if (!IsValidEmail(recipientEmail))
            {
                Response.Write("Invalid email address format." + recipientEmail);
                return;
            }

            string theme = "Verification Code";
            string body = GenerateCode();
            SendEmail(recipientEmail, theme, body);
            Session["Otp"] = body;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



        protected void VerifyButton_Click(object sender, EventArgs e)
        {
            if (OtpTextBox.Text == Session["Otp"]?.ToString())
            {
                Response.Redirect("page4.aspx?serviceId=" + Request.QueryString["serviceId"]);
            }
            else
            {
                Response.Write("<span style='color: red;'>Неправильний пароль. Спробуйте ще раз</span>");
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            Response.Redirect("~/page1.aspx");
        }

        public static string GenerateCode()
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder code = new StringBuilder(6);

            for (int i = 0; i < 6; i++)
            {
                code.Append(chars[random.Next(chars.Length)]);
            }

            return code.ToString();
        }
        static void SendEmail(string to, string subject, string body)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            string senderEmail = "email";
            string senderPassword = "password";


                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    MailMessage mail = new MailMessage(senderEmail, to, subject, body);
                    client.Send(mail);
                }
        }
    }
}