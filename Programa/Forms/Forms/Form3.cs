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

            SqlCommand person = new SqlCommand("select * from TripPlanner.Person", con);
            SqlDataReader reader = person.ExecuteReader();
            comboBox1.Items.Add("Select Person...");
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
            reader.Close();

            SqlCommand tp = new SqlCommand("select * from TripPlanner.TripType", con);
            SqlDataReader readerType = tp.ExecuteReader();

            while (readerType.Read())
            {
                TripType TT = new TripType();
                TT.ID = Int32.Parse(readerType["ID"].ToString());
                TT.Type = readerType["TypeName"].ToString();
                if (!types.Items.Contains(TT.Type))
                {
                    types.Items.Add(TT.Type);
                }
            }
            readerType.Close();

            SqlCommand st = new SqlCommand("select * from TripPlanner.Stay", con);
            SqlDataReader readerStay = st.ExecuteReader();
            stays.Items.Add("Select a Stay...");
            while (readerStay.Read())
            {
                Stay S = new Stay();
                S.Email = readerStay["Email"].ToString();
                S.Rating = Int32.Parse(readerStay["Rating"].ToString());
                S.Name = readerStay["SName"].ToString();
                S.Contact = readerStay["Contact"].ToString();
                S.Address = readerStay["SAddress"].ToString();
                stays.Items.Add(S.Name);
            }

            readerStay.Close();
            con.Close();
            comboBox1.SelectedIndex = 0;
            stays.SelectedIndex = 0;
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
            con = getSGBDConnection();
            if (!verifySGBDConnection())
            {
                return;
            }

            stays.Items.Clear();

            SqlCommand st = new SqlCommand("select * from TripPlanner.Stay s, TriPlanner.TripType tt where tt.ID = s.TrType and tt.TypeName = " + types.SelectedItem.ToString(), con);
            SqlDataReader readerStay = st.ExecuteReader();
            stays.Items.Add("Select a Stay...");
            while (readerStay.Read())
            {
                Stay S = new Stay();
                S.Email = readerStay["Email"].ToString();
                S.Rating = Int32.Parse(readerStay["Rating"].ToString());
                S.Name = readerStay["SName"].ToString();
                S.Contact = readerStay["Contact"].ToString();
                S.Address = readerStay["SAddress"].ToString();
                stays.Items.Add(S.Name);
            }

            readerStay.Close();
            con.Close();

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
                cmd.InsertCommand.Parameters.AddWithValue("@Duration", Int32.Parse(duration.Text.ToString()));
                cmd.InsertCommand.Parameters.AddWithValue("@TrName", tripName.Text.ToString());
                cmd.InsertCommand.Parameters.AddWithValue("@TrType", types.SelectedItem.ToString());
                cmd.InsertCommand.Parameters.AddWithValue("@TrState", "Scheduled");
                cmd.InsertCommand.Parameters.AddWithValue("@Price", 0);
                cmd.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Trip Created with success");
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
            else if(comboBox1.Text == "Select Person...")
            {
                MessageBox.Show(comboBox1.Text);
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
            else if (comboBox1.Text == "Select Person...")
            {
                MessageBox.Show(comboBox1.Text);
            }
            else
            {
                MessageBox.Show(comboBox1.Text + " not in your trip");
            }
        }
    }
}
