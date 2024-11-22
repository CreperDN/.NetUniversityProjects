using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;

namespace WebApp
{
    public partial class page5 : System.Web.UI.Page
    {
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string address = AddressTextBox.Text;
                int port = int.Parse(PortTextBox.Text);
                string email = EmailTextBox.Text;

                string filePath = Server.MapPath("~/App_Data/services.txt");
                string newService = $"{address}:{port}, {email}\n";
                string DB = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Lab5;Integrated Security=True";
                byte[] imageData = null;
                if (IconUpload.HasFile)
                {
                    string fileType = IconUpload.PostedFile.ContentType;
                    if (fileType == "image/jpeg" || fileType == "image/png" || fileType == "image/gif" || fileType == "image/bmp")
                    {
                        using (BinaryReader br = new BinaryReader(IconUpload.PostedFile.InputStream))
                    {
                        imageData = br.ReadBytes((int)IconUpload.PostedFile.InputStream.Length);
                    }
                    }
                    
                }

                using (SqlConnection Conn = new SqlConnection(DB))
                {
                    string query = "INSERT INTO TcpServices (Address, Port, Icon, Status, Email) " +
                           "VALUES (@Address, @Port, @Icon, @Status, @Email)";
                    using (SqlCommand command = new SqlCommand(query, Conn))
                    {
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Port", port);
                        if (imageData == null)
                        {
                            command.Parameters.Add("@Icon", SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Icon", imageData);
                        }
                        command.Parameters.AddWithValue("@Status", "---");
                        command.Parameters.AddWithValue("@Email", email);

                        Conn.Open();
                        command.ExecuteNonQuery();
                    }
                    File.AppendAllText(filePath, newService);

                    System.Threading.Thread.Sleep(500);
                    Response.Redirect("~/page1.aspx");
                }
            }
        }
        bool Check()
        {
            string address = AddressTextBox.Text;
            string port = PortTextBox.Text;
            string email = EmailTextBox.Text;
            if (string.IsNullOrEmpty(address))
            {
                Label2.Text = "Адреса не може бути порожньою.";
                return false;
            }
            if (IconUpload.HasFile)
            {
                string fileType = IconUpload.PostedFile.ContentType;
                if (fileType == "image/jpeg" || fileType == "image/png" || fileType == "image/gif" || fileType == "image/bmp")
                { }
                else
                {
                    Label2.Text = "<p style='font-size: 20px; color: red;'>Файл має бути картинкою.</p>";
                    return false;
                }
            }
                    var emailPattern = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!emailPattern.IsMatch(email))
            {
                Label2.Text = "Невірний формат email.";
                return false;
            }

            if (!int.TryParse(port, out _))
            {
                Label2.Text = "Порт повинен бути числом.";
                return false;
            }

            Label2.Text = "Дані успішно збережено!";
            return true;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            Response.Redirect("~/page1.aspx");
        }

        protected void IconUpload_click(object sender, EventArgs e) {
            if (IconUpload.HasFile)
            {
                if (IconUpload.PostedFile.ContentType == "image/jpeg")
                {
                    using (BinaryReader br = new BinaryReader(IconUpload.PostedFile.InputStream))
                    {
                        byte[] imageData = br.ReadBytes((int)IconUpload.PostedFile.InputStream.Length);
                        string base64Image = Convert.ToBase64String(imageData);
                        Icon.ImageUrl = "data:image/png;base64," + base64Image;
                        Icon.Width = 100;
                        Icon.Height = 100;
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null && Request.UrlReferrer.OriginalString.Contains("page1"))
                {
                }
                else
                {
                    Response.Redirect("~/page1.aspx");
                }
            }
        }
        }
    } 
