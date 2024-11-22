using L2_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace L2_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = System.Windows.Forms.Application.OpenForms["Form1"] as Form1;
            form1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable T = null;
            string ID = textID.Text;
            string Category = textName.Text;

            if (rbGetting.Checked)
            {
                T = GetSQLRequest("SELECT * FROM Categories");
            }
            else
            {
                if (rbAdding.Checked)
                {
                    DisplayChangedRowCount("INSERT INTO Categories (Category) VALUES (N'" + Category + "')");
                }
                else if (rbUpdating.Checked)
                {
                    DisplayChangedRowCount("UPDATE Categories SET Category = N'" + Category + "' WHERE ID = " + ID + ";");
                }
                else if (rbDeleting.Checked)
                {
                    DisplayChangedRowCount("DELETE FROM Categories WHERE ID =" + ID);
                }
                T = GetSQLRequest("SELECT * FROM Categories");
            }

            if (T != null)
            {
                dataGridView1.DataSource = T;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
        }

        public static DataTable GetSQLRequest(string Query)
        {
            string DB = "server=192.168.204.129;port=3306;database=Gambling;user=root;password='12345678';";
            using (MySqlConnection Conn = new MySqlConnection(DB))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(Query, Conn);
                da.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
        }

        public static void DisplayChangedRowCount(string Query)
        {
            string DB = "server=192.168.204.129;port=3306;database=Gambling;user=root;password='12345678';";
            using (MySqlConnection Conn = new MySqlConnection(DB))
            {
                string affectedRows;
                Conn.Open();
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                affectedRows = cmd.ExecuteNonQuery().ToString();
                MessageBox.Show("Rows affected: " + affectedRows);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
