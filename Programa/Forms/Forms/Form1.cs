using System.Data.SqlClient;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=tcp:mednat.ieeta.pt/SQLSERVER,8101;Initial Catalog=p1g1;Persist Security Info=True;User ID=p1g1;Password=Porto>Benfica;");
            SqlDataAdapter cmd = new SqlDataAdapter();
            cmd.InsertCommand = new SqlCommand("INSERT INTO Person VALUES (@First Name,@Middle Name,@Last Name,@CC,@Email,@Address,@Sex)",con);
            cmd.InsertCommand.Parameters.AddWithValue("@First Name", textBox1.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@Middle Name", textBox2.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@Last Name", textBox3.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@CC", textBox4.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@Sex", textBox7.Text);
            con.Open();
            cmd.InsertCommand.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Saved!");
        }

       
    }
}