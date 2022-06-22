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
            listBox1.DoubleClick += new EventHandler(ListBox1_DoubleClick);
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
            listBox1.Items.Clear();

            while (reader.Read())
            {
                City C = new City();
                C.City_name = reader["CName"].ToString();
                C.Country_name = reader["Country"].ToString();
                C.Continent_name = reader["Continent"].ToString();
                listBox1.Items.Add(C.City_name);
            }

            con.Close();
            //listBox1.SelectedIndex = 0;

            currentCity = 0;
           
        }
        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MessageBox.Show(listBox1.SelectedItem.ToString());
            }
        }


        public void ShowCity()
        {
            if (listBox1.Items.Count == 0 | currentCity < 0)
                return;
            City city = new City();
            city = (City)listBox1.Items[currentCity];


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
