using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace OnlineExam
{
    public partial class Student : Telerik.WinControls.UI.RadRibbonForm
    {
        public string y_slogin="";
        public Student(string str)
        {
            y_slogin = str;
            InitializeComponent();
            radSplitContainer1_csharp.Visible = false;
            radSplitContainer_asp.Visible = false;
            radSplitContainer_ado.Visible = false;
            radSplitContainer_sql.Visible = false;
            radPanel_barchart.Visible = false;
            radPanel_piechart.Visible = false;
            radPanel_radarchart.Visible = false;
        }

        public Student()
        {
            InitializeComponent();
            radSplitContainer1_csharp.Visible = false;
            radSplitContainer_asp.Visible = false;
            radSplitContainer_ado.Visible = false;
            radSplitContainer_sql.Visible = false;
            radPanel_barchart.Visible = false;
            radPanel_piechart.Visible = false;
            radPanel_radarchart.Visible = false;
        }
        
        
        private void ribbonTab1_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
            SqlConnection conn = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from student where allowed = '1' and usr='"+y_slogin+"' ";
            SqlDataReader dr;
            
           try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {//start a test

                    GiveExam g2 = new GiveExam(y_slogin);
                    g2.Show();
                    this.Hide();

                }
                else
                {
                    label1.Text = "you are not allowed for test";
                }

                conn.Close();
            }
            catch (Exception er)
            {
                label1.Text = er.Message;

            }
            
          //  GiveExam ge = new GiveExam();
           // ge.Show();
           // this.Hide();
           

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet4.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.database1DataSet4.student);
            // TODO: This line of code loads data into the 'database1DataSet3.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.database1DataSet3.Table);
            // TODO: This line of code loads data into the 'database1DataSet2.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter1.Fill(this.database1DataSet2.Table);
            // TODO: This line of code loads data into the 'database1DataSet1.Table' table. You can move, or remove it, as needed.
          

        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            radPanel_barchart.Visible = true;
            radPanel_barchart.Dock = DockStyle.Fill;
            radPanel_piechart.Visible = false;
            radPanel_radarchart.Visible = false;

        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            radPanel_piechart.Visible = true;
            radPanel_piechart.Dock = DockStyle.Fill;
            radPanel_barchart.Visible = false;
            radPanel_radarchart.Visible = false;
            
        }
        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            radPanel_radarchart.Visible = true;
            radPanel_radarchart.Dock = DockStyle.Fill;
            radPanel_barchart.Visible = false;
            radPanel_piechart.Visible = false;

        }

        private void radRibbonBarGroup1_Click(object sender, EventArgs e)
        {
            radSplitContainer1_csharp.Visible = true;
            radSplitContainer1_csharp.Dock = DockStyle.Fill;
            radSplitContainer_asp.Visible = false;
            radSplitContainer_ado.Visible = false;
            radSplitContainer_sql.Visible = false;

        }

        private void radRibbonBarGroup2_Click(object sender, EventArgs e)
        {
            radSplitContainer_asp.Visible = true;
            radSplitContainer_asp.Dock = DockStyle.Fill;
            radSplitContainer1_csharp.Visible = false;
            radSplitContainer_ado.Visible = false;
            radSplitContainer_sql.Visible = false;
        }

        private void radRibbonBarGroup3_Click(object sender, EventArgs e)
        {
            radSplitContainer_ado.Visible = true;
            radSplitContainer_ado.Dock = DockStyle.Fill;
            radSplitContainer_asp.Visible = false;
            radSplitContainer1_csharp.Visible = false;
            radSplitContainer_sql.Visible = false;
        }

        private void radRibbonBarGroup4_Click(object sender, EventArgs e)
        {
            radSplitContainer_sql.Visible = true;
            radSplitContainer_sql.Dock = DockStyle.Fill;
            radSplitContainer_asp.Visible = false;
            radSplitContainer1_csharp.Visible = false;
            radSplitContainer_ado.Visible = false;


        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
             Form1 f = new Form1();
            f.Show();
            this.Hide();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ribbonTab2_Click(object sender, EventArgs e)
        {
            radScrollablePanel_viewresult.Visible = true;
            radScrollablePanel_viewresult.Dock = DockStyle.Fill;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn12 = new SqlConnection();
            conn12.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";

            SqlCommand cmd12 = new SqlCommand();
            cmd12.Connection = conn12;
            cmd12.CommandText = "select * from student where usr ='" + y_slogin + "' ";
            conn12.Open();
            SqlDataReader dr12 = cmd12.ExecuteReader();
            while (dr12.Read())
            {
                label2.Text = dr12["m_cs"].ToString();
                label3.Text = dr12["m_asp"].ToString();
                label4.Text = dr12["m_ado"].ToString();
                label5.Text = dr12["m_sql"].ToString();
                label6.Text = dr12["m_total"].ToString();

            }
            conn12.Close();

        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
