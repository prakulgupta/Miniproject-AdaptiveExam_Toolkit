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
    public partial class Admin_registration : Telerik.WinControls.UI.RadForm
    {
        public Admin_registration()
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
            conn.Open();
            SqlDataReader dr;



            cmd.CommandText = "insert into admin(usr,pwd) values('" + textBox1.Text + "','" + textBox2.Text + "')";
            dr = cmd.ExecuteReader();
            this.Hide();

        }
    }
}
