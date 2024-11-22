using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using L2_2;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace L2_2
{
    public partial class Form1 : Form
    {
        public Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDown += new EventHandler(comboBox1_DropDown);
            InsertCategories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                DataTable T = null;
                string ID = textID.Text;
                string Name = null;
                string Description = textDescription.Text;
                string MaxPlayers = null;
                string Experience = null;
                string Category = comboBox1.Text.Substring(0, comboBox1.Text.IndexOf('.'));

                if (rbGetting.Checked)
                {
                    if (cbCategory.Checked && cbID.Checked)
                    {
                        T = GetSQLRequest("SELECT * FROM Games WHERE ID = " + ID + " AND Category_ID = " + Category);
                    }
                    else if (cbCategory.Checked)
                    {
                        T = GetSQLRequest("SELECT * FROM Games WHERE Category_ID = " + Category);
                    }
                    else if (cbID.Checked)
                    {
                        T = GetSQLRequest("SELECT * FROM Games WHERE ID = " + ID);
                    }
                    else
                    {
                        T = GetSQLRequest("SELECT * FROM Games INNER JOIN Categories ON Games.Category_ID = Categories.ID");
                    }
                }
                else if (rbDeleting.Checked)
                {
                    DisplayChangedRowCount("DELETE FROM Games WHERE ID =" + ID);
                    T = GetSQLRequest("SELECT * FROM Games");
                }
                else
                {
                    if (ValidateName(textName.Text))
                    {
                        Name = textName.Text;
                    }
                    else MessageBox.Show("Введіть правильну назву");
                    if (ValidateMaxPlayers(textMaxPlayers.Text))
                    {
                        MaxPlayers = textMaxPlayers.Text;
                    }
                    else MessageBox.Show("Введіть правильну максимальну кількість");
                    if (ValidateExperience(textExperience.Text))
                    {
                        Experience = textExperience.Text;
                    }
                    else MessageBox.Show("У поле Досвід введіть Низький, Середній або Високий ");

                    if (Name != null && MaxPlayers != null && Experience != null)
                    {
                        if (rbAdding.Checked)
                        {
                            DisplayChangedRowCount("INSERT INTO Games (Name, Descriprion, MaxPlayers, ExperienceLevel, Category_ID) VALUES (N'" + Name +
                                "', N'" + Description + "','" + MaxPlayers + "',N'" + Experience + "', " + Category + ")");
                        }
                        else if (rbUpdating.Checked)
                        {
                            DisplayChangedRowCount("UPDATE Games SET Name = N'" + Name +
                                "', Descriprion = N'" + Description + "', MaxPlayers = '" + MaxPlayers +
                                "', ExperienceLevel = N'" + Experience + "', Category_ID = " + Category +
                                " WHERE ID = " + ID + ";");
                        }

                        T = GetSQLRequest("SELECT * FROM Games");
                    }
                }
                dataGridView1.DataSource = T;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }

        public static void DisplayChangedRowCount(string Query)
        {
            string DB = "server=192.168.204.129;port=3306;database=Gambling;user=root;password='12345678';";
            using (MySqlConnection Conn = new MySqlConnection(DB))
            {
                Conn.Open();
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                int affectedRows = cmd.ExecuteNonQuery();
                MessageBox.Show("Rows affected: " + affectedRows);
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

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string DB = "server=192.168.204.129;port=3306;database=Gambling;user=root;password='12345678';";
            string Query = "SELECT * FROM Categories";
            using (MySqlConnection Conn = new MySqlConnection(DB))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(Query, Conn);
                da.Fill(ds);
                dt = ds.Tables[0];

                comboBox1.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row["ID"] + ". " + row["Category"]);
                }
            }
        }

        private void InsertCategories()
        {
            string DB = "server=192.168.204.129;port=3306;database=Gambling;user=root;password='12345678';";
            string query = "INSERT INTO Categories (ID, Category) VALUES (1, N'Карткові ігри'), (2, N'Автомати') " +
                "ON DUPLICATE KEY UPDATE Category = VALUES(Category);";
            using (MySqlConnection conn = new MySqlConnection(DB))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool ValidateName(string name)
        {
            Regex regex = new Regex(@"^[A-Za-zА-Яа-яҐґЄєІіЇї\s]+$");
            return regex.IsMatch(name);
        }
        private bool ValidateMaxPlayers(string maxPlayers)
        {
            Regex regex = new Regex(@"^[1-9][0-9]{0,2}$");
            return regex.IsMatch(maxPlayers);
        }
        private bool ValidateExperience(string experience)
        {
            Regex regex = new Regex(@"^(Низький|Середній|Високий)$");
            return regex.IsMatch(experience);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }
    }
}
