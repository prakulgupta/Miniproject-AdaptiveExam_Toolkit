using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace OnlineExam
{
    public partial class example : Form
    {
        public example()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select qn,op1,op1 from asp_e", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView1.DataSource = dtusers;

            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();       

            /*
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
            con.Open();

            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("Select qn,op1,op1 from asp_e", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            
            radGridView1.DataSource = dtusers;
            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
           // radGridView1.AllowAutoSizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
            */
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[0].Value != null) //Cells[0] Because in cell 0th cell we have added checkbox
                {
                    count++;
                    label1.Text = count.ToString();
                    label2.Text = dr.Cells[1].Value.ToString();

                }
            }
            /*int c = 0;
            for (int i = 0; i < this.radGridView1.Rows.Count; i++)
            {
                
                if (this.radGridView1.SelectedCells[0].Value !=null)
                {
                    c++;
                    label1.Text = c.ToString();
                    label2.Text = this.radGridView1.SelectedCells[1].Value.ToString();
                }
            }
            */
        }
    }
}
