using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
    

namespace OnlineExam
{
    public partial class AdminPage : Telerik.WinControls.UI.RadForm
    {
        public AdminPage()
        {   
            InitializeComponent();
            
               //  SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from teacher", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView1.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();


        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");

                string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;    
                SqlConnection conn = new SqlConnection(connection_string);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr;



                cmd.CommandText = "insert into teacher(usr,pwd) values('" + textBox1.Text + "','" + textBox2.Text + "')";
                dr = cmd.ExecuteReader();
                textBox1.Text = null;
                textBox2.Text = null;
                label4.Text = "Teacher successfully added";
                conn.Close();

            }
            catch (Exception er)
            {
                label4.Text = er.Message;
            }
            
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from teacher", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView1.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            
        }
    }
}
