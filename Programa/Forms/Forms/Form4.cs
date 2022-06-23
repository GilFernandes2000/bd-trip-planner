using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TripPlanner
{
    public partial class Form4 : Form
    {
        private int currentCity;
        private SqlConnection con;

        public Form4()
        {
            InitializeComponent();
            Load += new EventHandler(Form4_Load);
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


        private void Form4_Load(object sender, EventArgs e)
        {
            con = getSGBDConnection();
            if (!verifySGBDConnection())
            {
                return;
            }
            

            SqlCommand cmd = new SqlCommand("SELECT CName, Country, Continent FROM TripPlanner.City", con);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Select City...");
            while (reader.Read())
            {
                City C = new City();
                C.City_name = reader["CName"].ToString();
                C.Country_name = reader["Country"].ToString();
                C.Continent_name = reader["Continent"].ToString();
                comboBox2.Items.Add(C.City_name);
            }

            con.Close();
            //listBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
           



        }
      

        private void ComboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            con = getSGBDConnection();
            if (!verifySGBDConnection())
            {
                return;
            }
            
            SqlCommand cmd = new SqlCommand("SELECT PoIname, Rating, Email, Contact, Price, PoIAddress FROM TripPlanner.POInterest WHERE City = " + comboBox2.Items[comboBox2.SelectedIndex], con);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();
            while (reader.Read())
            {
                POI P = new POI();
                P.POI_name = reader["PoIName"].ToString();
                P.Rating = Int32.Parse(reader["Rating"].ToString());
                P.Email = reader["Email"].ToString();
                P.Contact = reader["Contact"].ToString();
                P.Price = reader["Price"].ToString();
                P.Address = reader["PoIAddress"].ToString();
                listBox2.Items.Add(P.POI_name);
            }

            con.Close();

            listBox2.SelectedIndex = 0;
            

            
        }


        public void ShowCity()
        {
            if (listBox1.Items.Count == 0 | currentCity < 0)
                return;
            City city = new City();
            city = (City)listBox1.Items[currentCity];


        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con = getSGBDConnection();
            if (!verifySGBDConnection())
            {
                return;
            }

            SqlDataAdapter cmd = new SqlDataAdapter();
            cmd.InsertCommand = new SqlCommand("INSERT INTO TripPlanner.POInterest (Email,Rating,PoIName,Contact,Price,PoIAddress,City,TrType) VALUES (@Email,@Rating,@PoIName,@Contact,@Price,@PoIAddress,@City,@TrType)", con);
            cmd.InsertCommand.Parameters.AddWithValue("@Email", textBox1.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@Rating", Int32.Parse(textBox2.Text));
            cmd.InsertCommand.Parameters.AddWithValue("@PoIName", textBox3.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@City", comboBox2.Items[comboBox2.SelectedIndex]);
            cmd.InsertCommand.Parameters.AddWithValue("@Price", textBox5.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@PoIAddress", textBox6.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@TrType", textBox7.Text);
            
            cmd.InsertCommand.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Sucess!");
        }
    }
    
}
