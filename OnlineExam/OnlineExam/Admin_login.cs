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
    public partial class Admin_login : Telerik.WinControls.UI.RadForm
    {
        public Admin_login()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from admin where usr ='" + textBox1.Text + "' AND " + " pwd ='" + textBox2.Text + "'";

            SqlDataReader dr;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AdminPage ap = new AdminPage();
                    ap.Show();
                    this.Hide();

                }
                else
                {
                    label4.Text = "Wrong username or password";
                }

                conn.Close();
            }
            catch(Exception er)
            {
                label4.Text = er.Message;

            }


        



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
