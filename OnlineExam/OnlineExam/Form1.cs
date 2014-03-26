using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace OnlineExam
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }

        
        private void radTileElement6_Click_1(object sender, EventArgs e)
        {
            teacherlogin tl = new teacherlogin();
            tl.Show();
            this.Hide();
            //teacher1 t = new teacher1();
            
            
            
        }

        private void radTileElement7_Click(object sender, EventArgs e)
        {
            Studentlogin sl = new Studentlogin();
            sl.Show(); 
            this.Hide();
            
        }


        private void radTileElement5_Click(object sender, EventArgs e)
        {

        }

        private void radTileElement6_Click(object sender, EventArgs e)
        {


        }

        private void radPanorama2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void radTileElement5_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
            SqlConnection conn = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader dr;
            cmd.CommandText = "select id from admin";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i = 1;
            }
            if (i == 1)
            {
                Admin_login al = new Admin_login();
                al.Show();
                this.Hide();
            }
            else
            {
                Admin_registration ar = new Admin_registration();
                ar.Show();

                

            //registration admin

            }

        }

    }
}
