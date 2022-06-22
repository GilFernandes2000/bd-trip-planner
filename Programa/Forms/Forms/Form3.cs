using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TripPlanner
{
    public partial class Form3 : Form
    {
        private SqlConnection con;
        private int currentPerson;
        public Form3()
        {
            InitializeComponent();
            Load += new EventHandler(Form3_Load);
        }

        private SqlConnection getSGBDConnection() 
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog=p1g1;Persist Security Info=True;User ID=p1g1;Password=Porto>Benfica;");
        }

        private bool verifySGBDConnection() 
        {
            if (con == null)
                con = getSGBDConnection();

            if (con.State != ConnectionState.Open)
                con.Open();

            return con.State == ConnectionState.Open;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            con = getSGBDConnection();
            if (!verifySGBDConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("select * from TripPlanner.Person", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Person P = new Person();
                P.Sex = reader["Sex"].ToString();
                P.First_Name = reader["PfName"].ToString();
                P.Middle_Name = reader["PmName"].ToString();
                P.Last_Name = reader["PlName"].ToString();
                P.Email = reader["Email"].ToString();
                P.Address = reader["PAddress"].ToString();
                P.PersonCC = reader["CC"].ToString();
                comboBox1.Items.Add(P.First_Name + " " + P.Last_Name);
            }
            con.Close();
            comboBox1.SelectedIndex = 0;

            currentPerson = 0;


            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            SqlDataAdapter cmd = new SqlDataAdapter();
            DateTime departureDate = dateTimePicker1.Value;
            cmd.InsertCommand = new SqlCommand("insert into Trip values(@TrType, @TrName, @Price, @Duration, @Departure_Date, @TrState)", con);

            if(departureDate > DateTime.Today)
            {
                cmd.InsertCommand.Parameters.AddWithValue("@Departure_Date", departureDate);
            }
            else
            {
                MessageBox.Show("Date not valid");
            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            if (listBox1.Items.Contains(comboBox1.Text))
            {
                MessageBox.Show(comboBox1.Text + " already added to your trip");
            }
            else
            {
                listBox1.Items.Add(comboBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(comboBox1.Text))
            {
                listBox1.Items.Remove(comboBox1.Text);
            }
            else
            {
                MessageBox.Show(comboBox1.Text + " not in your trip");
            }
        }
    }
}
