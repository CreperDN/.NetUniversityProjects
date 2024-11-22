using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class page2 : System.Web.UI.Page
    {
        public static string Code = "";
        byte[] imageData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null && Request.UrlReferrer.OriginalString.Contains("page1"))
                {

                    LoadServiceProperties();
                }
                else
                {
                    Response.Redirect("~/page1.aspx");
                }
            }
        }

        protected void LoadServiceProperties()
        {
            int serviceId = int.Parse(Request.QueryString["ID"]);
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Lab5;Integrated Security=True";
            string query = "SELECT Id, Address, Icon, Port, Email FROM TcpServices WHERE Id = @ServiceId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ServiceId", serviceId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("Icon")))
                    {
                        imageData = (byte[])reader["Icon"];
                        string base64Image = Convert.ToBase64String(imageData);
                        Icon.ImageUrl = "data:image/png;base64," + base64Image;
                        Icon.Width = 100;
                        Icon.Height = 100;
                    }
                    else
                    {
                        Label1.Text = "No Image";
                    }
                    AddresTextBox.Text = reader["Address"].ToString();
                    PortTextBox.Text = reader["Port"].ToString();
                    EmailTextBox.Text = reader["Email"].ToString();
                }
                else
                {
                    AddresTextBox.Text = "Service not found.";
                    PortTextBox.Text = "N/A";
                    EmailTextBox.Text = "N/A";
                    foreach (Control control in form1.Controls)
                    {
                        if (control is Button button && control.ID != "BackButton")
                            button.Enabled = false;
                        else if (control is TextBox textBox)
                            textBox.Enabled = false;
                        else if (control is FileUpload fileUpload)
                            fileUpload.Enabled = false;

                    }
                    Response.Write("<p style='font-size: 20px; color: red;'>Неправильна ID служби.</p>");
                }
                return;
            }
        }

        protected bool Check()
        {
            string address = AddresTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string port = PortTextBox.Text.Trim();

            if (string.IsNullOrEmpty(address))
            {
                Label2.Text = "Адреса не може бути порожньою.";
                return false;
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


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Lab5;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();

                    if (IconUpload.HasFile)
                    {
                        string fileType = IconUpload.PostedFile.ContentType;
                        if (fileType == "image/jpeg" || fileType == "image/png" || fileType == "image/gif" || fileType == "image/bmp")

                        {
                            string query = "UPDATE TcpServices SET Icon = @Icon WHERE Id = @Id";
                            using (SqlCommand Comm = new SqlCommand(query, conn))
                            {
                                using (BinaryReader br = new BinaryReader(IconUpload.PostedFile.InputStream))
                                {
                                    imageData = br.ReadBytes((int)IconUpload.PostedFile.InputStream.Length);
                                }

                                Comm.Parameters.AddWithValue("@Id", int.Parse(Request.QueryString["ID"]));
                                Comm.Parameters.Add("@Icon", SqlDbType.Image).Value = imageData;
                                Comm.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            Label2.Text = "<p style='font-size: 20px; color: red;'>Будь ласка завантажте картинку.</p>";
                        }
                    }

                    string queryUpdateDetails = "UPDATE TcpServices SET Address = @Address, Port = @Port, Email = @Email WHERE Id = @Id";
                    using (SqlCommand Comm = new SqlCommand(queryUpdateDetails, conn))
                    {
                        Comm.Parameters.Add("@Address", SqlDbType.NVarChar).Value = AddresTextBox.Text;
                        Comm.Parameters.Add("@Port", SqlDbType.Int).Value = int.Parse(PortTextBox.Text);
                        Comm.Parameters.Add("@Email", SqlDbType.NVarChar).Value = EmailTextBox.Text;
                        Comm.Parameters.AddWithValue("@Id", int.Parse(Request.QueryString["ID"]));
                        Comm.ExecuteNonQuery();
                    }

                    if (imageData != null)
                    {
                        string base64Image = Convert.ToBase64String(imageData);
                        Icon.ImageUrl = "data:image/png;base64," + base64Image;
                        Icon.Width = 100;
                        Icon.Height = 100;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                System.Threading.Thread.Sleep(1000);
            }
        }




        protected void BackButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            Response.Redirect("~/page1.aspx");
        }

        protected void CheckButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            Response.Redirect("~/page3.aspx?serviceId=" + int.Parse(Request.QueryString["ID"]));
        }

    }
}