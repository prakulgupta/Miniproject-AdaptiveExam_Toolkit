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
    public partial class teacher1 : Telerik.WinControls.UI.RadRibbonForm
    {
        public teacher1()
        {
            InitializeComponent();
            radScrollablepanel_teachermain.Visible = true;
            radScrollablepanel_teachermain.Dock = DockStyle.Fill;
          
            radPanelEnroll.Dock = DockStyle.Fill;
            radPanelEnroll.Visible = false;
            radPanelMCQ.Visible = false;
            radPanelMCQ.Dock = DockStyle.Fill;
            radPanelC_Exam.Dock = DockStyle.Fill;

            panel_viewQB_main.Dock = DockStyle.Fill;
            


            radPaneladdques.Visible = false;
            radPaneladdques.Dock = DockStyle.Fill;
            radPanelsqladdques.Visible = false;
            radPanelsqladdques.Dock = DockStyle.Fill;
            radPanelenterques.Visible = false;
            radPanelenterques.Dock = DockStyle.Fill;
            radPaneladoaddques.Visible = false;
            radPaneladoaddques.Dock = DockStyle.Fill;
            radPanelaspaddques.Visible = false;
            radPanelaspaddques.Dock = DockStyle.Fill;
            panel_viewQB_main.Visible = false;
            panel_viewQB_main.Dock = DockStyle.Fill;

            // view question

            radSplitContainer_view_QB_cs.Visible = false;
            radSplitContainer_view_QB_cs.Dock = DockStyle.Fill;
            dataGridView_cs_e.Visible = false;
            dataGridView_cs_h.Visible = false;
            dataGridView_cs_m.Visible = false;
            
            dataGridView_cs_e.Dock = DockStyle.Fill;
            dataGridView_cs_h.Dock = DockStyle.Fill;
            dataGridView_cs_m.Dock = DockStyle.Fill;

            dataGridView_asp_e.Visible = false;
            dataGridView_asp_h.Visible = false;
            dataGridView_asp_m.Visible = false;

            dataGridView_asp_e.Dock = DockStyle.Fill;
            dataGridView_asp_h.Dock = DockStyle.Fill;
            dataGridView_asp_m.Dock = DockStyle.Fill;

            dataGridView_ado_e.Visible = false;
            dataGridView_ado_h.Visible = false;
            dataGridView_ado_m.Visible = false;

            dataGridView_ado_e.Dock = DockStyle.Fill;
            dataGridView_ado_h.Dock = DockStyle.Fill;
            dataGridView_ado_m.Dock = DockStyle.Fill;

            dataGridView_sql_e.Visible = false;
            dataGridView_sql_h.Visible = false;
            dataGridView_sql_m.Visible = false;

            dataGridView_sql_e.Dock = DockStyle.Fill;
            dataGridView_sql_h.Dock = DockStyle.Fill;
            dataGridView_sql_m.Dock = DockStyle.Fill;



            radSplitContainer_allowstud.Visible = false;
            radSplitContainer_allowstud.Dock = DockStyle.Fill;
            
          
        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();

        }

        private void ribbonTab1_Click(object sender, EventArgs e)
        {

            panel_viewQB_main.Visible = false;


            radSplitContainer_allowstud.Visible = false;
            radPanelC_Exam.Visible = true;
            radPanelEnroll.Visible = false;
            panel_viewQB_main.Visible = false;
            radPanelMCQ.Visible = true;
            radPanelMCQ.Dock = DockStyle.Fill;

            radPanelEnroll.Visible = false;
            radPaneladdques.Visible = true;
            radPaneladdques.Dock = DockStyle.Fill;

          
        }

        private void ribbonTab2_Click(object sender, EventArgs e)
        {
            panel_viewQB_main.Visible = false;
            radPanelEnroll.Visible = true;
            radPanelC_Exam.Visible = false;
            radSplitContainer_allowstud.Visible = false;
        }

        private void radLabel4_Click(object sender, EventArgs e)
        {

        }

        private void radLabel10_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radRibbonBarGroup1_Click(object sender, EventArgs e)
        {
            

            


        }

        private void radButton2_Click(object sender, EventArgs e)
        {
          
          
        }

        private void radLabel21_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox53_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton48_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radScrollablePanel4_PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanelmcqpage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButtonnextpage_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            
        }

        private void radLabel7_Click(object sender, EventArgs e)
        {

        }

        private void radRadioButton4_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

        }

        private void radButton2_Click_1(object sender, EventArgs e)
        {
            


        }

        private void richTextBox20_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void richTextBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void radDropDownList4_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            radPanelenterques.Visible = true;
            radPanelsqladdques.Visible = false;
            radPanelaspaddques.Visible = false;
            radPaneladoaddques.Visible = false;

        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            radPaneladoaddques.Visible = false;
            radPanelsqladdques.Visible = true;
            radPanelaspaddques.Visible = false;
            radPanelenterques.Visible = false;

        }

        private void radPanelaspaddques_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {

            radPaneladoaddques.Visible = false;
            radPanelsqladdques.Visible = false;
            radPanelaspaddques.Visible = true;
            radPanelenterques.Visible = false;
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            radPaneladoaddques.Visible = true;
            radPanelsqladdques.Visible = false;
            radPanelaspaddques.Visible = false;
            radPanelenterques.Visible = false;
        }

        private void radButton_Csharp_addques_Click(object sender, EventArgs e)
        {
            string answer = null;
            try
            {

                if (radioButton73.Checked)
                {
                    answer = richTextBox21.Text;
                }
                else if (radioButton74.Checked)
                {
                    answer = richTextBox22.Text;
                }
                else if (radioButton75.Checked)
                {
                    answer = richTextBox23.Text;
                }
                else if (radioButton76.Checked)
                {
                    answer = richTextBox24.Text;
                }
                else
                {
                    label1.Text = "Select the option";
                }
                //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
                SqlConnection conn = new SqlConnection(connection_string);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                {
                    if (radRadioButton9.IsChecked)
                    {
                        cmd.CommandText = "insert into cs_e values('" + richTextBox20.Text + "','" + richTextBox21.Text + "','" + richTextBox22.Text + "','" + richTextBox23.Text + "','" + richTextBox24 + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else if (radRadioButton8.IsChecked)
                    {
                        cmd.CommandText = "insert into cs_m values('" + richTextBox20.Text + "','" + richTextBox21.Text + "','" + richTextBox22.Text + "','" + richTextBox23.Text + "','" + richTextBox24 + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else if (radRadioButton7.IsChecked)
                    {
                        cmd.CommandText = "insert into cs_h values('" + richTextBox20.Text + "','" + richTextBox21.Text + "','" + richTextBox22.Text + "','" + richTextBox23.Text + "','" + richTextBox24 + "','" + answer+ "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else
                    {
                        label1.Text = "select the difficulty";
                    }


                }
                conn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                label1.Text =
                    "There was an error in executing the SQL. " +
                    "Error Message:" + ex.Message;

            }

            //enter question
            richTextBox20.Text = "";
            //enter options
            richTextBox21.Text = "";
            richTextBox22.Text = "";
            richTextBox23.Text = "";
            richTextBox24.Text = "";
            // select correct option
            radioButton73.Checked = false;
            radioButton74.Checked = false;
            radioButton75.Checked = false;
            radioButton76.Checked = false;
            //choose difficulty
            radRadioButton4.IsChecked = false;
            radRadioButton5.IsChecked = false;
            radRadioButton6.IsChecked = false;

            }

        private void radButton_sql_addques_Click(object sender, EventArgs e)
        {
            string answer = null;
            try
            {

                if (radioButton77.Checked)
                {
                    answer = richTextBox28.Text;
                }
                else if(radioButton78.Checked)
                {
                    answer = richTextBox27.Text;
                }
                else if (radioButton79.Checked)
                {
                    answer = richTextBox26.Text;
                }
                else if (radioButton80.Checked)
                {
                    answer = richTextBox25.Text;
                }
                else
                {
                    label2.Text = "Select the option";
                }
                //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                SqlConnection conn = new SqlConnection(connection_string);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                {
                    if(radRadioButton9.IsChecked)
                    {
                        cmd.CommandText = "insert into sql_e values('" + richTextBox29.Text + "','" + richTextBox28.Text + "','" + richTextBox27.Text + "','" + richTextBox26.Text + "','" + richTextBox25.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else if(radRadioButton8.IsChecked)
                    {
                        cmd.CommandText = "insert into sql_m values('" + richTextBox29.Text + "','" + richTextBox28.Text + "','" + richTextBox27.Text + "','" + richTextBox26.Text + "','" + richTextBox25.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else if (radRadioButton7.IsChecked)
                    {
                        cmd.CommandText = "insert into sql_h values('" + richTextBox29.Text + "','" + richTextBox28.Text + "','" + richTextBox27.Text + "','" + richTextBox26.Text + "','" + richTextBox25.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else
                    {
                        label2.Text = "select the difficulty";
                    }
                    
                    
                }
                conn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                label2.Text=
                    "There was an error in executing the SQL. " +
                    "Error Message:" + ex.Message;

            }
            //enter question
            richTextBox29.Text = "";
            //enter options
            richTextBox28.Text = "";
            richTextBox27.Text = "";
            richTextBox26.Text = "";
            richTextBox25.Text = "";
            // select correct option
            radioButton77.Checked = false;
            radioButton78.Checked = false;
            radioButton79.Checked = false;
            radioButton80.Checked = false;
            //choose difficulty
            radRadioButton7.IsChecked = false;
            radRadioButton8.IsChecked = false;
            radRadioButton9.IsChecked = false;
        }

        private void radButton_asp_addques_Click(object sender, EventArgs e)
        {
            string answer = null;
            try
            {

                if (radioButton81.Checked)
                {
                    answer = richTextBox33.Text;
                }
                else if (radioButton82.Checked)
                {
                    answer = richTextBox32.Text;
                }
                else if (radioButton83.Checked)
                {
                    answer = richTextBox31.Text;
                }
                else if (radioButton84.Checked)
                {
                    answer = richTextBox30.Text;
                }
                else
                {
                    label6.Text = "Select the option";
                }
                //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                SqlConnection conn = new SqlConnection(connection_string);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                {
                    if (radRadioButton12.IsChecked)
                    {
                        cmd.CommandText = "insert into asp_e values('" + richTextBox34.Text + "','" + richTextBox33.Text + "','" + richTextBox32.Text + "','" + richTextBox31.Text + "','" + richTextBox30.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else if (radRadioButton11.IsChecked)
                    {
                        cmd.CommandText = "insert into asp_m values('" + richTextBox34.Text + "','" + richTextBox33.Text + "','" + richTextBox32.Text + "','" + richTextBox31.Text + "','" + richTextBox30.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else if (radRadioButton10.IsChecked)
                    {
                        cmd.CommandText = "insert into asp_h values('" + richTextBox34.Text + "','" + richTextBox33.Text + "','" + richTextBox32.Text + "','" + richTextBox31.Text + "','" + richTextBox30.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else
                    {
                        label6.Text = "select the difficulty";
                    }


                }
                conn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                label6.Text =
                    "There was an error in executing the SQL. " +
                    "Error Message:" + ex.Message;

            }
            //enter question
            richTextBox34.Text = "";
            //enter options
            richTextBox31.Text = "";
            richTextBox32.Text = "";
            richTextBox33.Text = "";
            richTextBox30.Text = "";
            // select correct option
            radioButton81.Checked = false;
            radioButton82.Checked = false;
            radioButton83.Checked = false;
            radioButton84.Checked = false;
            //choose difficulty
            radRadioButton12.IsChecked = false;
            radRadioButton11.IsChecked = false;
            radRadioButton10.IsChecked = false;
        }

        private void radButton_ado_addques_Click(object sender, EventArgs e)
        {
            string answer = null;
            try
            {

                if (radioButton85.Checked)
                {
                    answer = richTextBox38.Text;
                }
                else if (radioButton86.Checked)
                {
                    answer = richTextBox37.Text;
                }
                else if (radioButton87.Checked)
                {
                    answer = richTextBox36.Text;
                }
                else if (radioButton88.Checked)
                {
                    answer = richTextBox35.Text;
                }
                else
                {
                    label8.Text = "Select the option";
                }
                //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                SqlConnection conn = new SqlConnection(connection_string);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                {
                    if (radRadioButton15.IsChecked)
                    {
                        cmd.CommandText = "insert into ado_e values('" + richTextBox39.Text + "','" + richTextBox38.Text + "','" + richTextBox37.Text + "','" + richTextBox36.Text + "','" + richTextBox35.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else if (radRadioButton14.IsChecked)
                    {
                        cmd.CommandText = "insert into ado_m values('" + richTextBox39.Text + "','" + richTextBox38.Text + "','" + richTextBox37.Text + "','" + richTextBox36.Text + "','" + richTextBox35.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else if (radRadioButton13.IsChecked)
                    {
                        cmd.CommandText = "insert into ado_h values('" + richTextBox39.Text + "','" + richTextBox38.Text + "','" + richTextBox37.Text + "','" + richTextBox36.Text + "','" + richTextBox35.Text + "','" + answer + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    else
                    {
                        label8.Text = "select the difficulty";
                    }


                }
                conn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                label8.Text =
                    "There was an error in executing the SQL. " +
                    "Error Message:" + ex.Message;

            }
            //enter question
            richTextBox39.Text = "";
            //enter options
            richTextBox38.Text = "";
            richTextBox37.Text = "";
            richTextBox36.Text = "";
            richTextBox35.Text = "";
            // select correct option
            radioButton85.Checked = false;
            radioButton86.Checked = false;
            radioButton87.Checked = false;
            radioButton88.Checked = false;
            //choose difficulty
            radRadioButton13.IsChecked = false;
            radRadioButton14.IsChecked = false;
            radRadioButton15.IsChecked = false;
        }

        

        private void ribbonTab3_Click(object sender, EventArgs e)
        {
            radSplitContainer_allowstud.Visible = false;
            panel_viewQB_main.Visible = true;
            radPanelEnroll.Visible = false;
            radPanelC_Exam.Visible = false;
            
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            /*radScrollablePanelview_cs_e_inside.Dock = DockStyle.Fill;
            radScrollablePanelview_cs_e_inside.Visible = true;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from cs_e", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView1.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();*/


        }

        private void panelview_QB_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton2_Click_2(object sender, EventArgs e)
        {

        }

        private void radButton_cs_e_Click(object sender, EventArgs e)
        {
            dataGridView_cs_e.Visible = true;
            dataGridView_cs_e.Dock = DockStyle.Fill;

            dataGridView_cs_m.Visible = false;
            dataGridView_cs_h.Visible = false;

           

          //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
          con.Open();

          //Data table is used to bind the resultant data
          DataTable dtusers = new DataTable();
          // Create a new data adapter based on the specified query.
          SqlDataAdapter da = new SqlDataAdapter("Select * from cs_e", con);
          //SQl command builder is used to get data from database based on query
          SqlCommandBuilder cmd = new SqlCommandBuilder(da);
          //Fill data table
          da.Fill(dtusers);
          //assigning data table to Datagridview
          dataGridView_cs_e.DataSource = dtusers;

          //Resize the Datagridview column to fit the gridview columns with data in datagridview
          dataGridView_cs_e.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
          con.Close();


        }

        private void radButton_cs_m_Click(object sender, EventArgs e)
        {
            dataGridView_cs_e.Visible = false;
            dataGridView_cs_h.Visible = false;
            dataGridView_cs_m.Visible = true;
            dataGridView_cs_m.Dock = DockStyle.Fill;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from cs_m", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_cs_m.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_cs_m.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();


        }

        private void radButton_cs_h_Click(object sender, EventArgs e)
        {
            dataGridView_cs_h.Visible = true;
            dataGridView_cs_h.Dock = DockStyle.Fill;
            dataGridView_cs_e.Visible = false;
            dataGridView_cs_m.Visible = false;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from cs_h", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_cs_h.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_cs_h.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();

        }

        

        private void radScrollablePanelVQB_cs_e_Click(object sender, EventArgs e)
        {

        }

        private void radRibbonBarGroup2_Click(object sender, EventArgs e)
        {
            radSplitContainer_view_QB_cs.Visible = true;
            
            radScrollablePanelVQB_sql.Visible = true;
            radScrollablePanelVQB_sql.Dock = DockStyle.Fill;
            radScrollablePanelVQB_ado.Visible = false;
            radScrollablePanelVQB_cs_e.Visible = false;
            radScrollablePanelVQB_asp.Visible = false;

            panel_sql.Visible = true;
            panel_sql.Dock = DockStyle.Fill;
            panel_ado.Visible = false;
            panel_asp.Visible = false;
            panel_cs_e.Visible = false;
            
        }

        private void radRibbonBarGroup3_Click(object sender, EventArgs e)
        {
            radSplitContainer_view_QB_cs.Visible = true;

            radScrollablePanelVQB_sql.Visible = false;
            radScrollablePanelVQB_asp.Dock = DockStyle.Fill;
            radScrollablePanelVQB_ado.Visible = false;
            radScrollablePanelVQB_cs_e.Visible = false;
            radScrollablePanelVQB_asp.Visible = true;

            panel_sql.Visible = false;
            panel_asp.Dock = DockStyle.Fill;
            panel_ado.Visible = false;
            panel_asp.Visible = true;
            panel_cs_e.Visible = false;
        }

        private void radRibbonBarGroup4_Click(object sender, EventArgs e)
        {
            radSplitContainer_view_QB_cs.Visible = true;

            radScrollablePanelVQB_sql.Visible = false;
            radScrollablePanelVQB_ado.Dock = DockStyle.Fill;
            radScrollablePanelVQB_ado.Visible = true;
            radScrollablePanelVQB_cs_e.Visible = false;
            radScrollablePanelVQB_asp.Visible = false;

            panel_sql.Visible = false;
            panel_ado.Dock = DockStyle.Fill;
            panel_ado.Visible = true;
            panel_asp.Visible = false;
            panel_cs_e.Visible = false;
        }
        private void radRibbonBarGroup1_Click_1(object sender, EventArgs e)
        {
            radSplitContainer_view_QB_cs.Visible = true;
            
            panel_cs_e.Visible = true;
            panel_sql.Visible = false;
            panel_ado.Visible = false;
            panel_asp.Visible = false;


            radScrollablePanelVQB_sql.Visible = false;
            radScrollablePanelVQB_cs_e.Dock = DockStyle.Fill;
            radScrollablePanelVQB_ado.Visible = false;
            radScrollablePanelVQB_cs_e.Visible = true;
            radScrollablePanelVQB_asp.Visible = false;

            
            
            panel_cs_e.Dock = DockStyle.Fill;

         
        }

        private void radScrollablePanelVQB_asp_Click(object sender, EventArgs e)
        {

        }

        private void radButton8_Click(object sender, EventArgs e)
        {
            dataGridView_asp_e.Visible = true;
            dataGridView_asp_e.Dock = DockStyle.Fill;

            dataGridView_asp_m.Visible = false;
            dataGridView_asp_h.Visible = false;



            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from asp_e", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_asp_e.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_asp_e.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
        }

        private void radButton9_Click(object sender, EventArgs e)
        {
            dataGridView_asp_e.Visible = false;
            dataGridView_asp_h.Visible = false;
            dataGridView_asp_m.Visible = true;
            dataGridView_asp_m.Dock = DockStyle.Fill;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from asp_m", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_asp_m.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_asp_m.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();

        }

        private void radButton10_Click(object sender, EventArgs e)
        {
            dataGridView_asp_h.Visible = true;
            dataGridView_asp_h.Dock = DockStyle.Fill;
            dataGridView_asp_e.Visible = false;
            dataGridView_asp_m.Visible = false;
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from asp_h", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_asp_h.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_asp_h.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radButton2_Click_3(object sender, EventArgs e)
        {
            dataGridView_sql_e.Visible = true;
            dataGridView_sql_e.Dock = DockStyle.Fill;

            dataGridView_sql_m.Visible = false;
            dataGridView_sql_h.Visible = false;



            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from sql_e", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_sql_e.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_sql_e.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            dataGridView_sql_e.Visible = false;
            dataGridView_sql_h.Visible = false;
            dataGridView_sql_m.Visible = true;
            dataGridView_sql_m.Dock = DockStyle.Fill;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from sql_m", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_sql_m.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_sql_m.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            dataGridView_sql_h.Visible = true;
            dataGridView_sql_h.Dock = DockStyle.Fill;
            dataGridView_sql_e.Visible = false;
            dataGridView_sql_m.Visible = false;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from sql_h", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_sql_h.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_sql_h.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();

        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            dataGridView_ado_e.Visible = true;
            dataGridView_ado_e.Dock = DockStyle.Fill;

            dataGridView_ado_m.Visible = false;
            dataGridView_ado_h.Visible = false;



            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from ado_e", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_ado_e.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_ado_e.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            dataGridView_ado_e.Visible = false;
            dataGridView_ado_h.Visible = false;
            dataGridView_ado_m.Visible = true;
            dataGridView_ado_m.Dock = DockStyle.Fill;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from ado_m", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_ado_m.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_ado_m.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            dataGridView_ado_h.Visible = true;
            dataGridView_ado_h.Dock = DockStyle.Fill;
            dataGridView_ado_e.Visible = false;
            dataGridView_ado_m.Visible = false;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select * from ado_h", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView_ado_h.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView_ado_h.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
        }

        private void radScrollablepanel_teachermain_Click(object sender, EventArgs e)
        {

        }

        

        private void radMenuItem1_Click_2(object sender, EventArgs e)
        {
            radPanelenterques.Visible = true;
            radPanelsqladdques.Visible = false;
            radPanelaspaddques.Visible = false;
            radPaneladoaddques.Visible = false;
        }

        private void radMenuItem2_Click_1(object sender, EventArgs e)
        {
            radPaneladoaddques.Visible = false;
            radPanelsqladdques.Visible = true;
            radPanelaspaddques.Visible = false;
            radPanelenterques.Visible = false;
        }

        private void radMenuItem3_Click_1(object sender, EventArgs e)
        {

            radPaneladoaddques.Visible = false;
            radPanelsqladdques.Visible = false;
            radPanelaspaddques.Visible = true;
            radPanelenterques.Visible = false;
        }

        private void radMenuItem4_Click_1(object sender, EventArgs e)
        {
            radPaneladoaddques.Visible = true;
            radPanelsqladdques.Visible = false;
            radPanelaspaddques.Visible = false;
            radPanelenterques.Visible = false;
        }

        private void ribbonTab4_Click(object sender, EventArgs e)
        {
            radSplitContainer_allowstud.Visible = true;
            radSplitContainer_allowstud.Dock = DockStyle.Fill;
            radPanelEnroll.Visible = false;
            radPanelC_Exam.Visible = false;
            panel_viewQB_main.Visible = false;
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select allowed,name,enrl,branch,email,phn from student", con);
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

        private void radButton11_Click(object sender, EventArgs e)
        {
            /*example ex = new example();
            ex.Show();
            this.Hide();*/
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            
            //Stack<String> stck_enrl = new Stack<String>();
            
            int count = 0;
            string y = "";
            string chk= null;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[0].Value != null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    count++;

                    if (radioButton1.Checked)
                    {
                        chk = "1";
                    }
                    else if (radioButton2.Checked)
                    {
                        chk = "2";
                    }
                    else if (radioButton3.Checked)
                    {
                        chk = "3";

                    }
                    else if (radioButton4.Checked)
                    {
                        chk = "4";
                    }
                    label10.Text = count.ToString();
                    
                    y = dr.Cells[3].Value.ToString();

                    cmd.CommandText = "update student set allowed='1' , subj='" + chk + "' where enrl='" + y + "' ";
                    con.Open();
                    SqlDataReader dread2 = cmd.ExecuteReader();
                    
                    con.Close();
                    label11.Text = dr.Cells[3].Value.ToString();
                    //stck_enrl.Push(dr.Cells[3].Value.ToString());
                }
            }

            

        }

        private void splitPanel3_Click(object sender, EventArgs e)
        {

        }

        private void radButton12_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //Stack<String> stck_enrl = new Stack<String>();

            int count = 0;
            string y = "";
            string chk = null;
            
            /*foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[0].Value != null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    count++;

                    label10.Text = count.ToString();
                    y = dr.Cells[3].Value.ToString();
                    cmd.CommandText = "update student set allowed='0' where enrl='" + y + "' ";
                    con.Open();
                    SqlDataReader dread2 = cmd.ExecuteReader();
                    con.Close();
                    label11.Text = dr.Cells[3].Value.ToString();
                    //stck_enrl.Push(dr.Cells[3].Value.ToString());
                }
            }
            */
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[0].Value != null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    count++;

                    if (radioButton1.Checked)
                    {
                        chk = "1";
                    }
                    else if (radioButton2.Checked)
                    {
                        chk = "2";
                    }
                    else if (radioButton3.Checked)
                    {
                        chk = "3";

                    }
                    else if (radioButton4.Checked)
                    {
                        chk = "4";
                    }
                    label10.Text = count.ToString();

                    y = dr.Cells[3].Value.ToString();

                    cmd.CommandText = "update student set allowed='0' , subj='" + chk + "' where enrl='" + y + "' ";
                    con.Open();
                    SqlDataReader dread2 = cmd.ExecuteReader();

                    con.Close();
                    label11.Text = dr.Cells[3].Value.ToString();
                    //stck_enrl.Push(dr.Cells[3].Value.ToString());
                }
            }

        }

        private void radButton13_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //Stack<String> stck_enrl = new Stack<String>();

            int count = 0;
            string y = "";
            string chk = null;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                //if (dr.Cells[0].Value != null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    count++;

                    if (radioButton1.Checked)
                    {
                        chk = "1";
                    }
                    else if (radioButton2.Checked)
                    {
                        chk = "2";
                    }
                    else if (radioButton3.Checked)
                    {
                        chk = "3";

                    }
                    else if (radioButton4.Checked)
                    {
                        chk = "4";
                    }
                    label10.Text = count.ToString();

                    y = dr.Cells[3].Value.ToString();

                    cmd.CommandText = "update student set allowed='1' , subj='" + chk + "' ";
                    con.Open();
                    SqlDataReader dread2 = cmd.ExecuteReader();

                    con.Close();
                    label11.Text = dr.Cells[3].Value.ToString();
                    //stck_enrl.Push(dr.Cells[3].Value.ToString());
                }
            }

        }

        private void radButton14_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //Stack<String> stck_enrl = new Stack<String>();

            int count = 0;
            string y = "";
            string chk = null;

            /*foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[0].Value != null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    count++;

                    label10.Text = count.ToString();
                    y = dr.Cells[3].Value.ToString();
                    cmd.CommandText = "update student set allowed='0' where enrl='" + y + "' ";
                    con.Open();
                    SqlDataReader dread2 = cmd.ExecuteReader();
                    con.Close();
                    label11.Text = dr.Cells[3].Value.ToString();
                    //stck_enrl.Push(dr.Cells[3].Value.ToString());
                }
            }
            */
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                //if (dr.Cells[0].Value != null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    count++;

                    if (radioButton1.Checked)
                    {
                        chk = "1";
                    }
                    else if (radioButton2.Checked)
                    {
                        chk = "2";
                    }
                    else if (radioButton3.Checked)
                    {
                        chk = "3";

                    }
                    else if (radioButton4.Checked)
                    {
                        chk = "4";
                    }
                    label10.Text = count.ToString();

                    y = dr.Cells[3].Value.ToString();

                    cmd.CommandText = "update student set allowed='0' , subj='" + chk + "' ";
                    con.Open();
                    SqlDataReader dread2 = cmd.ExecuteReader();

                    con.Close();
                    label11.Text = dr.Cells[3].Value.ToString();
                    //stck_enrl.Push(dr.Cells[3].Value.ToString());
                }
            }
        }

        private void textBox78_TextChanged(object sender, EventArgs e)
        {

        }

        private void radScrollablePanelVQB_cs_e_PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
