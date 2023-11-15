using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlServerConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //address of SQL server and db
            string ConnectionString = "Data Source=AACHAL\\SQLEXPRESS;Initial Catalog=Connection_Forms;Integrated Security=True";

            //establish connection 
            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection
            con.Open();

            //prepare query
            string FirstName = textBox1.Text;
            string LastName = textBox2.Text;


            string Query = "INSERT INTO DataConnection (FirstName, LastName) values ('"+ FirstName + "','"+ LastName + "')";

            //execute query
            SqlCommand cmd = new SqlCommand(Query,con);
            cmd.ExecuteNonQuery();                 //only executes, doesnt returns anything

            //close connection
            con.Close();


            MessageBox.Show("Data has been saved in db");
        }

        private void btShowData_Click(object sender, EventArgs e)
        {
            //writing the db address
            string ConnectionString = "Data Source=AACHAL\\SQLEXPRESS;Initial Catalog=Connection_Forms;Integrated Security=True";
            
            //establishing connection
            SqlConnection con = new SqlConnection(ConnectionString);
            
            //opening connection
            con.Open();
            
            //prepare sql query
            string Query = "SELECT * FROM DataConnection";
            SqlCommand cmd = new SqlCommand(Query, con);
            
            //execute query
            var reader = cmd.ExecuteReader();               //for raw data  //to store ; reader

            while(reader.Read())                           //gives row from sql to here 1 by 1
            {

                dataGridView1.Rows.Add(reader["Id"], reader["FirstName"].ToString().ToUpper() + " " + reader["LastName"], "Edit");
            }



            /* Method 1 : 
            DataTable table = new DataTable();
            table.Load(reader);                            // to fill the data

            dataGridView1.DataSource = table;
            */

            //close connection
            con.Close();

        }

        private void tbUpdate_Click(object sender, EventArgs e)
        {
            //address of SQL server and db
            string ConnectionString = "Data Source=AACHAL\\SQLEXPRESS;Initial Catalog=Connection_Forms;Integrated Security=True";

            //establish connection 
            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection
            con.Open();

            //prepare query
            string id = textBox3.Text;
            string FirstName = textBox1.Text;
            string LastName = textBox2.Text;


            string Query = "UPDATE DataConnection SET FirstName = '"+FirstName+ "', LastName = '" + LastName+"' WHERE id = "+id;

            //execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();         

            //close connection
            con.Close();


            MessageBox.Show("Data has been updated");


        }

        private void tb_Fetch_Click(object sender, EventArgs e)
        {

            string ConnectionString = "Data Source=AACHAL\\SQLEXPRESS;Initial Catalog=Connection_Forms;Integrated Security=True";

            SqlConnection con = new SqlConnection(ConnectionString);



            con.Open();


            string id = textBox3.Text;

            string Query = "SELECT * FROM DataConnection WHERE Id = " + id;

            SqlCommand cmd = new SqlCommand(Query, con);
            var Reader = cmd.ExecuteReader();

            if (Reader.Read())
            {
                textBox1.Text = Reader["FirstName"].ToString();
                textBox2.Text = Reader["LastName"].ToString();
            }
            else
            
                MessageBox.Show("No record found");

                con.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}
