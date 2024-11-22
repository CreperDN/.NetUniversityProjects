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
using System.Web.Services.Description;
using System.Collections;

namespace WebApp
{
    public partial class page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                LoadTcpServices();
            
        }

        protected void LoadTcpServices()
        {
            GetAllTable();
        }

        protected void b4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string id = clickedButton.CommandArgument; 
            System.Threading.Thread.Sleep(2000);
            Response.Redirect("~/page2.aspx?ID=" + HttpUtility.UrlEncode(id)); 
        }

        protected void NewServiceButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            Response.Redirect("~/page5.aspx");
        }

        protected void GetAllTable()
        {
            string DB = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Lab5;Integrated Security=True";
            string Query = "select Id, Address, Port, Icon, LastCheck, Status from TcpServices";

            using (SqlConnection Conn = new SqlConnection(DB))
            {
                Conn.Open();
                SqlCommand Comm = new SqlCommand(Query, Conn);
                SqlDataReader R = Comm.ExecuteReader();

                while (R.Read())
                {
                    TableRow tr2 = new TableRow();
                    TableCell td1 = new TableCell(); Label l1 = new Label();
                    TableCell td2 = new TableCell(); Label l2 = new Label();
                    TableCell td3 = new TableCell(); Label l3 = new Label();
                    TableCell td4 = new TableCell();
                    TableCell td5 = new TableCell(); Label l5 = new Label();
                    TableCell td6 = new TableCell(); Label l6 = new Label();
                    TableCell td7 = new TableCell(); Button b4 = new Button();

                    l1.Text = R["Id"].ToString(); td1.Controls.Add(l1); tr2.Cells.Add(td1);
                    l2.Text = R["Address"].ToString(); td2.Controls.Add(l2); tr2.Cells.Add(td2);
                    l3.Text = R["Port"].ToString(); td3.Controls.Add(l3); tr2.Cells.Add(td3);

                    if (!R.IsDBNull(R.GetOrdinal("Icon")))
                    {
                        byte[] imageData = (byte[])R["Icon"];
                        string base64Image = Convert.ToBase64String(imageData);
                        System.Web.UI.WebControls.Image l4 = new System.Web.UI.WebControls.Image
                        {
                            ImageUrl = "data:image/png;base64," + base64Image,
                            Width = 50,
                            Height = 50
                        };
                        td4.Controls.Add(l4);
                    }
                    else
                    {
                        td4.Text = "No Image";
                    }
                    td4.HorizontalAlign = HorizontalAlign.Center;
                    tr2.Cells.Add(td4);

                    l5.Text = R["LastCheck"].ToString(); td5.Controls.Add(l5); tr2.Cells.Add(td5);
                    l6.Text = R["Status"].ToString(); td6.Controls.Add(l6); 
                    if (l6.Text == "НЕ ПРАЦЮЄ")
                    {
                        td6.ForeColor = Color.FromArgb(255, 255, 50, 50);
                       
                    }
                    else if (l6.Text == "ПРАЦЮЄ")
                    {
                        td6.ForeColor = Color.FromArgb(255, 25, 200, 25);
                    }
                    tr2.Cells.Add(td6);

                    b4.Text = "Властивості";
                    b4.Font.Bold = true;
                    b4.Font.Size = 24;
                    b4.CommandArgument = l1.Text; 
                    b4.Click += new EventHandler(b4_Click); 
                    b4.OnClientClick = "this.style.visibility='hidden';";

                    td7.Controls.Add(b4);
                    tr2.Cells.Add(td7);

                    foreach (TableCell cell in tr2.Cells)
                    {
                        cell.BorderColor = Color.Blue;
                        cell.BorderWidth = 4;
                    }

                    TcpServiceTable.Rows.Add(tr2);
                    TcpServiceTable.Font.Size = 18;
                    TcpServiceTable.BorderStyle = BorderStyle.Solid;
                    TcpServiceTable.GridLines = GridLines.Both;
                }
            }
        }
    }
}
