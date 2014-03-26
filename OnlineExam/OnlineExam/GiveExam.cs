using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes.Design;
using System.Xml.XPath;
using System.Xml;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace OnlineExam
{
    public partial class GiveExam : Telerik.WinControls.UI.ShapedForm
    {
        private bool check;
        Student s1 = new Student();

        
        //two count variables for total qn count
        // and another for level check(+1 only if count=3 otherwise -1 except level1 n level3)
        int total_qn = 4;       //to be specified by teacher and extracted from a lable or textbox
        int countqn = 0;
        int lvl = 1;
        int lvl_counter_up = 1;         //for every level both have to be reassigned, specially lvl_counter_low
        //int lvl_counter_low = 3;int lvl_counter_low = 3;  
        int y;
        int length_easy = 0;  // length_m, length_h
        int length_m = 0;
        int length_h = 0;
        int marks = 0;  //global
        int marks_total = 0;
        int[] arr_e = new int[100];         //arr_h , arr_m
        int[] arr_m = new int[100];
        int[] arr_h = new int[100];
        Stack<int> stck_e = new Stack<int>();
        Stack<int> stck_m = new Stack<int>();
        Stack<int> stck_h = new Stack<int>();
        int pop;
        string exm_sub = "";
        int close_v=0;

        // Because we have not specified a namespace, this
        // will be a System.Windows.Forms.Timer instance
        private Timer _timer;

        // The last time the timer was started
        private DateTime _startTime = DateTime.MinValue;

        // Time between now and when the timer was started last
        private TimeSpan _currentElapsedTime = TimeSpan.Zero;

        // Time between now and the first time the timer was started after a reset
        private TimeSpan _totalElapsedTime = TimeSpan.Zero;

        // Whether or not the timer is currently running
        private bool _timerRunning = false;

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
    
   //System level functions to be used for hook and unhook keyboard input
   private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
   [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
   [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern bool UnhookWindowsHookEx(IntPtr hook);
   [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
   [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern IntPtr GetModuleHandle(string name);
   [DllImport("user32.dll", CharSet = CharSet.Auto)]
   private static extern short GetAsyncKeyState(Keys key);
    
    
   //Declaring Global objects
   private IntPtr ptrHook;
   private LowLevelKeyboardProc objKeyboardProcess;
   
        
        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (close_v == 0)
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        e.Cancel = true;
                        break;
                }
                //    base.OnFormClosing(e);
            }
            else
            {
                e.Cancel = false;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.RWin)
                e.SuppressKeyPress = true;
        }

        string y_student = "";
        public GiveExam(string str)
        {
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule; //Get Current Module
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey); //Assign callback function each time keyboard process
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0); //Setting Hook of Keyboard Process for current module
     
     

            y_student = str;        // data from student
            
            InitializeComponent();

            
            radButton3.Visible = false;
           
            label3.Text = y_student;
            
            radScrollablePanel_takeexam1.Visible = true;
            radScrollablePanel_takeexam.Visible = false;
            radScrollablePanel_takeexam.Dock = DockStyle.Fill;
            radScrollablePanel_takeexam1.Dock = DockStyle.Fill;

        }
        public GiveExam()
        {
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule; //Get Current Module
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey); //Assign callback function each time keyboard process
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0); //Setting Hook of Keyboard Process for current module
     
     

            InitializeComponent();

            

            radScrollablePanel_takeexam1.Visible = true;
            radScrollablePanel_takeexam.Visible = false;
            radScrollablePanel_takeexam.Dock = DockStyle.Fill;
            radScrollablePanel_takeexam1.Dock = DockStyle.Fill;

            
            
        }


        /// <summary>
        /// Handle the Timer's Tick event
        /// </summary>
        /// <param name="sender">System.Windows.Forms.Timer instance</param>
        /// <param name="e">EventArgs object</param>
        void _timer_Tick(object sender, EventArgs e)
        {
            // We do this to chop off any stray milliseconds resulting from 
            // the Timer's inherent inaccuracy, with the bonus that the 
            // TimeSpan.ToString() method will now show correct HH:MM:SS format
            var timeSinceStartTime = DateTime.Now - _startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours,
                                              timeSinceStartTime.Minutes,
                                              timeSinceStartTime.Seconds);

            // The current elapsed time is the time since the start button was
            // clicked, plus the total time elapsed since the last reset
            _currentElapsedTime = timeSinceStartTime + _totalElapsedTime;

            // These are just two Label controls which display the current 
            // elapsed time and total elapsed time
            label4.Text = _currentElapsedTime.ToString();
            //_currentElapsedTimeDisplay.Text = timeSinceStartTime.ToString();

            //to finish exam
            if (_currentElapsedTime.Hours == 0 && _currentElapsedTime.Minutes == 02 && _currentElapsedTime.Seconds == 20)
            {
                radButton_next.Visible = false;
                radButton_submit.Visible = true;
                label4.Text = "";

                _timer.Stop();
                _timerRunning = false;

                _totalElapsedTime = TimeSpan.Zero;
                _currentElapsedTime = TimeSpan.Zero;
                
                //come back
            }
        }

        private void GiveExam_Load(object sender, EventArgs e)
        {
            close_v = 0;
        }

        private void radTitleBar1_Click(object sender, EventArgs e)
        {

        }

        private void radScrollablePanel1_Click(object sender, EventArgs e)
        {

        }

        private void radWaitingBar1_WaitingStarted(object sender, EventArgs e)
        {

        }
        int ticks = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            radProgressBar1.Value1 = ticks;
            if (ticks == 100)
            {
                timer1.Enabled = false;
                ticks = 0;
            }
            
        }

        private void radProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }

        private void radProgressBar1_DashChanged(object sender, Telerik.WinControls.UI.ProgressBarEventArgs e)
        {
          
        }

        private void radProgressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void radButton4_Click(object sender, EventArgs e)
        {

        }

        private void radButton_startexam_Click(object sender, EventArgs e)
        {
            //randomly generate first qn

            //selecting records from easy table(this code produces only the last record)
            
            radScrollablePanel_takeexam1.Visible = false;
            radScrollablePanel_takeexam.Visible = true;

            // Set up a timer and fire the Tick event once per second (1000 ms)
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);

            // If the timer isn't already running
            if (!_timerRunning)
            {
                // Set the start time to Now
                _startTime = DateTime.Now;

                // Store the total elapsed time so far
                _totalElapsedTime = _currentElapsedTime;

                _timer.Start();
                _timerRunning = true;
            }
            else // If the timer is already running
            {
                _timer.Stop();
                _timerRunning = false;
                
            }
            

            //SqlConnection conn9 = new SqlConnection();
            //conn9.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
            SqlConnection conn9 = new SqlConnection(connection_string);
            SqlCommand cmd9 = new SqlCommand();
            cmd9.Connection = conn9;

            cmd9.CommandText = "select subj from student where usr='"+y_student+"' ";
            conn9.Open();
            exm_sub = cmd9.ExecuteScalar().ToString();
            conn9.Close();
            if (exm_sub == "1")
            {
                try
                {
                    //SqlConnection conn = new SqlConnection();
                    //conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    //string connection_string1 = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlConnection conn = new SqlConnection(connection_string);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    //SqlConnection conn2 = new SqlConnection();
                    //conn2.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    //string connection_string2 = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlConnection conn2 = new SqlConnection(connection_string);


                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn2;

                    //SqlConnection conn3 = new SqlConnection();
                    //conn3.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    //string connection_string3 = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlConnection conn3 = new SqlConnection(connection_string);

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = conn3;

                    //SqlConnection conn4 = new SqlConnection();
                    //conn4.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    //string connection_string4 = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlConnection conn4 = new SqlConnection(connection_string);


                    SqlCommand cmd4 = new SqlCommand();
                    cmd4.Connection = conn4;

                    cmd.CommandText = "select count(id) from cs_e ";
                    conn.Open();
                    length_easy = Convert.ToInt32(cmd.ExecuteScalar()); //to store the return from the executed command
                    //                label3.Text = length_easy.ToString();
                    conn.Close();

                    cmd3.CommandText = "select count(id) from cs_m ";
                    conn3.Open();
                    length_m = Convert.ToInt32(cmd3.ExecuteScalar()); //to store the return from the executed command
                    conn3.Close();

                    cmd4.CommandText = "select count(id) from cs_h ";
                    conn4.Open();
                    length_h = Convert.ToInt32(cmd4.ExecuteScalar()); //to store the return from the executed command
                    conn4.Close();

                    /*
                    //Code to generate unique random no.
                    Random rand = new Random();
                    y = rand.Next(1, length_easy + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

      //              label4.Text = y.ToString();
                
                    */

                    //Level 1

                    //Code to generate Array of unique random nos. SQL_easy
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_easy; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_easy + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_e[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_e[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_e[i] = 0;         // when no. already exists, make that index=0
                            if (arr_e[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_easy; i++)
                        {
                            stck_e.Push(arr_e[i]);
                        }
                    }                       // end of random array generator

                    pop = stck_e.Pop();
                    cmd2.CommandText = "select * from cs_e where id =" + pop + ""; //can be put in if for diff subj
                    conn2.Open();
                    radLabel7.Text = "1";
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        radLabel8.Text = (countqn + 1).ToString();
                        radLabel2.Text = "Qn No. " + dr2["id"].ToString();   //to see the id of the random qn no.
                        richTextBox1.Text = dr2["qn"].ToString();
                        radRadioButton_optionA.Text = dr2["op1"].ToString();
                        radRadioButton_optionB.Text = dr2["op2"].ToString();
                        radRadioButton_optionC.Text = dr2["op3"].ToString();
                        radRadioButton_optionD.Text = dr2["op4"].ToString();
                    }
                    conn2.Close();
                    countqn++;

                    //Code to generate Array of unique random nos. SQL_m
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_m; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_m + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_m[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_m[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_m[i] = 0;         // when no. already exists, make that index=0
                            if (arr_m[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_m; i++)
                        {
                            stck_m.Push(arr_m[i]);
                        }
                    }

                    //Code to generate Array of unique random nos. SQL_h
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_h; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_h + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_h[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_h[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_h[i] = 0;         // when no. already exists, make that index=0
                            if (arr_h[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_h; i++)
                        {
                            stck_h.Push(arr_h[i]);
                        }
                    }

                }           //end of try
                catch (System.Data.SqlClient.SqlException ex)
                {
                    radLabel2.Text =
                       "There was an error in executing the SQL. " +
                       "Error Message:" + ex.Message;

                }

            }       //end if subj=1
            else if (exm_sub == "2")
            {
                try
                {
                    //SqlConnection conn = new SqlConnection();
                    //conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    //string connection_string5 = OnlineExam.Properties.Settings.Default.Database1ConnectionString; //updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    //SqlConnection conn2 = new SqlConnection();
                    //conn2.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn2 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com


                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn2;

                    //SqlConnection conn3 = new SqlConnection();
                    //conn3.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn3 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = conn3;

                    //SqlConnection conn4 = new SqlConnection();
                    //conn4.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn4 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd4 = new SqlCommand();
                    cmd4.Connection = conn4;

                    cmd.CommandText = "select count(id) from asp_e ";
                    conn.Open();
                    length_easy = Convert.ToInt32(cmd.ExecuteScalar()); //to store the return from the executed command
                    //                label3.Text = length_easy.ToString();
                    conn.Close();

                    cmd3.CommandText = "select count(id) from asp_m ";
                    conn3.Open();
                    length_m = Convert.ToInt32(cmd3.ExecuteScalar()); //to store the return from the executed command
                    conn3.Close();

                    cmd4.CommandText = "select count(id) from asp_h ";
                    conn4.Open();
                    length_h = Convert.ToInt32(cmd4.ExecuteScalar()); //to store the return from the executed command
                    conn4.Close();

                    /*
                    //Code to generate unique random no.
                    Random rand = new Random();
                    y = rand.Next(1, length_easy + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

      //              label4.Text = y.ToString();
                
                    */

                    //Level 1

                    //Code to generate Array of unique random nos. SQL_easy
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_easy; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_easy + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_e[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_e[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_e[i] = 0;         // when no. already exists, make that index=0
                            if (arr_e[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_easy; i++)
                        {
                            stck_e.Push(arr_e[i]);
                        }
                    }                       // end of random array generator

                    pop = stck_e.Pop();
                    cmd2.CommandText = "select * from asp_e where id =" + pop + ""; //can be put in if for diff subj
                    conn2.Open();
                    radLabel7.Text = "1";
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        radLabel8.Text = (countqn + 1).ToString();
                        radLabel2.Text = "Qn No. " + dr2["id"].ToString();   //to see the id of the random qn no.
                        richTextBox1.Text = dr2["qn"].ToString();
                        radRadioButton_optionA.Text = dr2["op1"].ToString();
                        radRadioButton_optionB.Text = dr2["op2"].ToString();
                        radRadioButton_optionC.Text = dr2["op3"].ToString();
                        radRadioButton_optionD.Text = dr2["op4"].ToString();
                    }
                    conn2.Close();
                    countqn++;

                    //Code to generate Array of unique random nos. SQL_m
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_m; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_m + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_m[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_m[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_m[i] = 0;         // when no. already exists, make that index=0
                            if (arr_m[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_m; i++)
                        {
                            stck_m.Push(arr_m[i]);
                        }
                    }

                    //Code to generate Array of unique random nos. SQL_h
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_h; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_h + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_h[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_h[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_h[i] = 0;         // when no. already exists, make that index=0
                            if (arr_h[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_h; i++)
                        {
                            stck_h.Push(arr_h[i]);
                        }
                    }

                }           //end of try
                catch (System.Data.SqlClient.SqlException ex)
                {
                    radLabel2.Text =
                       "There was an error in executing the SQL. " +
                       "Error Message:" + ex.Message;

                }
            }
            else if (exm_sub == "3")
            {
                try
                {
                    //SqlConnection conn = new SqlConnection();
                    //conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    //SqlConnection conn2 = new SqlConnection();
                    //conn2.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn2 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com


                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn2;

                    //SqlConnection conn3 = new SqlConnection();
                    //conn3.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn3 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = conn3;

                    //SqlConnection conn4 = new SqlConnection();
                    //conn4.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn4 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd4 = new SqlCommand();
                    cmd4.Connection = conn4;

                    cmd.CommandText = "select count(id) from ado_e ";
                    conn.Open();
                    length_easy = Convert.ToInt32(cmd.ExecuteScalar()); //to store the return from the executed command
                    //                label3.Text = length_easy.ToString();
                    conn.Close();

                    cmd3.CommandText = "select count(id) from ado_m ";
                    conn3.Open();
                    length_m = Convert.ToInt32(cmd3.ExecuteScalar()); //to store the return from the executed command
                    conn3.Close();

                    cmd4.CommandText = "select count(id) from ado_h ";
                    conn4.Open();
                    length_h = Convert.ToInt32(cmd4.ExecuteScalar()); //to store the return from the executed command
                    conn4.Close();

                    /*
                    //Code to generate unique random no.
                    Random rand = new Random();
                    y = rand.Next(1, length_easy + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

      //              label4.Text = y.ToString();
                
                    */

                    //Level 1

                    //Code to generate Array of unique random nos. SQL_easy
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_easy; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_easy + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_e[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_e[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_e[i] = 0;         // when no. already exists, make that index=0
                            if (arr_e[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_easy; i++)
                        {
                            stck_e.Push(arr_e[i]);
                        }
                    }                       // end of random array generator

                    pop = stck_e.Pop();
                    cmd2.CommandText = "select * from ado_e where id =" + pop + ""; //can be put in if for diff subj
                    conn2.Open();
                    radLabel7.Text = "1";
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        radLabel8.Text = (countqn + 1).ToString();
                        radLabel2.Text = "Qn No. " + dr2["id"].ToString();   //to see the id of the random qn no.
                        richTextBox1.Text = dr2["qn"].ToString();
                        radRadioButton_optionA.Text = dr2["op1"].ToString();
                        radRadioButton_optionB.Text = dr2["op2"].ToString();
                        radRadioButton_optionC.Text = dr2["op3"].ToString();
                        radRadioButton_optionD.Text = dr2["op4"].ToString();
                    }
                    conn2.Close();
                    countqn++;

                    //Code to generate Array of unique random nos. SQL_m
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_m; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_m + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_m[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_m[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_m[i] = 0;         // when no. already exists, make that index=0
                            if (arr_m[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_m; i++)
                        {
                            stck_m.Push(arr_m[i]);
                        }
                    }

                    //Code to generate Array of unique random nos. SQL_h
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_h; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_h + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_h[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_h[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_h[i] = 0;         // when no. already exists, make that index=0
                            if (arr_h[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_h; i++)
                        {
                            stck_h.Push(arr_h[i]);
                        }
                    }

                }           //end of try
                catch (System.Data.SqlClient.SqlException ex)
                {
                    radLabel2.Text =
                       "There was an error in executing the SQL. " +
                       "Error Message:" + ex.Message;

                }
            }
            else if (exm_sub == "4")
            {
                try
                {
                    //SqlConnection conn = new SqlConnection();
                    //conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    //SqlConnection conn2 = new SqlConnection();
                    //conn2.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn2 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn2;

                    //SqlConnection conn3 = new SqlConnection();
                    //conn3.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn3 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = conn3;

                    //SqlConnection conn4 = new SqlConnection();
                    //conn4.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                    SqlConnection conn4 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                    SqlCommand cmd4 = new SqlCommand();
                    cmd4.Connection = conn4;

                    cmd.CommandText = "select count(id) from sql_e ";
                    conn.Open();
                    length_easy = Convert.ToInt32(cmd.ExecuteScalar()); //to store the return from the executed command
                    //                label3.Text = length_easy.ToString();
                    conn.Close();

                    cmd3.CommandText = "select count(id) from sql_m ";
                    conn3.Open();
                    length_m = Convert.ToInt32(cmd3.ExecuteScalar()); //to store the return from the executed command
                    conn3.Close();

                    cmd4.CommandText = "select count(id) from sql_h ";
                    conn4.Open();
                    length_h = Convert.ToInt32(cmd4.ExecuteScalar()); //to store the return from the executed command
                    conn4.Close();

                    /*
                    //Code to generate unique random no.
                    Random rand = new Random();
                    y = rand.Next(1, length_easy + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

      //              label4.Text = y.ToString();
                
                    */

                    //Level 1

                    //Code to generate Array of unique random nos. SQL_easy
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_easy; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_easy + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_e[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_e[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_e[i] = 0;         // when no. already exists, make that index=0
                            if (arr_e[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_easy; i++)
                        {
                            stck_e.Push(arr_e[i]);
                        }
                    }                       // end of random array generator

                    pop = stck_e.Pop();
                    cmd2.CommandText = "select * from sql_e where id =" + pop + ""; //can be put in if for diff subj
                    conn2.Open();
                    radLabel7.Text = "1";
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        radLabel8.Text = (countqn + 1).ToString();
                        radLabel2.Text = "Qn No. " + dr2["id"].ToString();   //to see the id of the random qn no.
                        richTextBox1.Text = dr2["qn"].ToString();
                        radRadioButton_optionA.Text = dr2["op1"].ToString();
                        radRadioButton_optionB.Text = dr2["op2"].ToString();
                        radRadioButton_optionC.Text = dr2["op3"].ToString();
                        radRadioButton_optionD.Text = dr2["op4"].ToString();
                    }
                    conn2.Close();
                    countqn++;

                    //Code to generate Array of unique random nos. SQL_m
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_m; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_m + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_m[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_m[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_m[i] = 0;         // when no. already exists, make that index=0
                            if (arr_m[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_m; i++)
                        {
                            stck_m.Push(arr_m[i]);
                        }
                    }

                    //Code to generate Array of unique random nos. SQL_h
                    {
                        Random rand1 = new Random();
                        int r_no;

                        int f;      //flag to check if no. generated exists in array or not

                        for (int i = 0; i < length_h; i++)
                        {
                            f = 0;
                            r_no = rand1.Next(1, length_h + 1);      //rand.Next() works for 1 to N+1 and generates no. 1 to N

                            for (int j = 0; j < i + 1; j++)
                            {
                                if (r_no == arr_h[j])
                                {
                                    f = 1;
                                }
                            }
                            if (f != 1)
                            {
                                arr_h[i] = r_no;         // i.e. if the no. generated is not in the array
                            }
                            else
                                arr_h[i] = 0;         // when no. already exists, make that index=0
                            if (arr_h[i] == 0)        //and decrement the loop variable so that the chance is not wasted n it loops again
                                i = i - 1;
                        }                           //end for loop of random no. finder
                        // Array of unique  random no. is saved
                        for (int i = 0; i < length_h; i++)
                        {
                            stck_h.Push(arr_h[i]);
                        }
                    }

                }           //end of try
                catch (System.Data.SqlClient.SqlException ex)
                {
                    radLabel2.Text =
                       "There was an error in executing the SQL. " +
                       "Error Message:" + ex.Message;

                }
            }
        }

        private void radScrollablePanel1_PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton_next_Click(object sender, EventArgs e)
        {
            // level counter+1 if correct response; if level count=3, level incremented else level-1
            // conditions for level1 n 3
            // if level=1 , extract qn in box

            //total count if 20 then submit
            //random array filled
            //if total_count<= no. of qns

            //countqn++;
            if (exm_sub == "1")
            {
                if (countqn == total_qn)
                {
                    //button1.Visible = false;
                    //button4.Visible = true;
                    radButton_next.Visible = false;
                    radButton_submit.Visible = true;
                    richTextBox1.Enabled = false;
                    radRadioButton_optionA.Enabled = false;
                    radRadioButton_optionB.Enabled = false;
                    radRadioButton_optionC.Enabled = false;
                    radRadioButton_optionD.Enabled = false;
                }
                if (countqn == 1)
                {
                    radLabel7.Text = "1";
                    try
                    {
                      //  SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                        string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                        SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        SqlDataReader dr;
                        conn.Open();
                        {
                            cmd.CommandText = "select * from cs_e where id=" + pop + ""; // can be put in if for diff subj n level+"
                            dr = cmd.ExecuteReader();
                        }

                        while (dr.Read())
                        {
                            if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else
                                lvl_counter_up--;

                        }           //end while
                        //level count inc if correct ans else dec

                        //if level=1 retrieval from level 1 and accordingly

                        conn.Close();

                        // Code for next qn retrieval

                        //SqlConnection conn5 = new SqlConnection();
                        //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                        SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.Connection = conn5;

                        pop = stck_e.Pop();                     //a chance is there for the first qn to be repeated
                        cmd5.CommandText = "select * from cs_e where id =" + pop + ""; //can be put in if for diff subj
                        conn5.Open();
                        SqlDataReader dr5 = cmd5.ExecuteReader();
                        while (dr5.Read())
                        {
                            radLabel8.Text = (countqn + 1).ToString();
                            radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                            richTextBox1.Text = dr5["qn"].ToString();
                            radRadioButton_optionA.Text = dr5["op1"].ToString();
                            radRadioButton_optionB.Text = dr5["op2"].ToString();
                            radRadioButton_optionC.Text = dr5["op3"].ToString();
                            radRadioButton_optionD.Text = dr5["op4"].ToString();
                        }
                        conn5.Close();

                        // Code for next qn retrieval
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        radLabel2.Text =
                           "There was an error in executing the SQL. " +
                           "Error Message:" + ex.Message;

                    }
                }               //end if(countqn==1)
                else
                {
                    //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                    string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                    SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    SqlDataReader dr;

                    if (lvl_counter_up < 3)
                        lvl = 1;
                    else if (lvl_counter_up >= 3 && lvl_counter_up < 6)
                        lvl = 2;
                    else if (lvl_counter_up >= 6)
                        lvl = 3;
                    if (lvl == 1)
                    {
                        radLabel7.Text = "1";
                        conn.Open();
                        //int pop = stck_e.Pop();
                        cmd.CommandText = "select * from cs_e where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else
                                lvl_counter_up--;

                        }                       //end while
                        conn.Close();

                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                    //        SqlConnection conn5 = new SqlConnection();
                      //      conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_e.Pop();
                            cmd5.CommandText = "select * from cs_e where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif

                    else if (lvl == 2)                      // one level 1 qn id in level2 ????????????????????????????????/
                    {
                        radLabel7.Text = "2";
                        if (lvl_counter_up == 3)
                        {
                            conn.Open();
                            //int pop = stck_m.Pop();
                            cmd.CommandText = "select * from cs_e where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }                   //end if
                        else
                        {
                            conn.Open();
                            //int pop = stck_m.Pop();
                            cmd.CommandText = "select * from cs_m where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }           //end else
                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                            //SqlConnection conn5 = new SqlConnection();
                            //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_m.Pop();
                            cmd5.CommandText = "select * from cs_m where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif

                    else if (lvl == 3)
                    {
                        radLabel7.Text = "3";
                        if (lvl_counter_up == 6)
                        {
                            conn.Open();
                            //int pop = stck_h.Pop();
                            cmd.CommandText = "select * from cs_m where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }
                        else
                        {
                            conn.Open();
                            //int pop = stck_h.Pop();
                            cmd.CommandText = "select * from cs_h where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }
                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                            //SqlConnection conn5 = new SqlConnection();
                            //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_h.Pop();
                            cmd5.CommandText = "select * from cs_h where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif
                }           //end else
                countqn++;
                label2.Text = marks.ToString();


                /*   radRadioButton_optionA.IsChecked = false;
                   radRadioButton_optionB.IsChecked = false;
                   radRadioButton_optionC.IsChecked = false;
                   radRadioButton_optionD.IsChecked = false;*/

            }                       //end if subj=1
            else if (exm_sub == "2")
            {
                if (countqn == total_qn)
                {
                    //button1.Visible = false;
                    //button4.Visible = true;
                    radButton_next.Visible = false;
                    radButton_submit.Visible = true;
                    richTextBox1.Enabled = false;
                    radRadioButton_optionA.Enabled = false;
                    radRadioButton_optionB.Enabled = false;
                    radRadioButton_optionC.Enabled = false;
                    radRadioButton_optionD.Enabled = false;
                }
                if (countqn == 1)
                {
                    radLabel7.Text = "1";
                    try
                    {
                        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                        string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                        SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        SqlDataReader dr;
                        conn.Open();
                        {
                            cmd.CommandText = "select * from asp_e where id=" + pop + ""; // can be put in if for diff subj n level+"
                            dr = cmd.ExecuteReader();
                        }

                        while (dr.Read())
                        {
                            if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else
                                lvl_counter_up--;

                        }           //end while
                        //level count inc if correct ans else dec

                        //if level=1 retrieval from level 1 and accordingly

                        conn.Close();

                        // Code for next qn retrieval

                        //SqlConnection conn5 = new SqlConnection();
                        //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                        
                        SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.Connection = conn5;

                        pop = stck_e.Pop();                     //a chance is there for the first qn to be repeated
                        cmd5.CommandText = "select * from asp_e where id =" + pop + ""; //can be put in if for diff subj
                        conn5.Open();
                        SqlDataReader dr5 = cmd5.ExecuteReader();
                        while (dr5.Read())
                        {
                            radLabel8.Text = (countqn + 1).ToString();
                            radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                            richTextBox1.Text = dr5["qn"].ToString();
                            radRadioButton_optionA.Text = dr5["op1"].ToString();
                            radRadioButton_optionB.Text = dr5["op2"].ToString();
                            radRadioButton_optionC.Text = dr5["op3"].ToString();
                            radRadioButton_optionD.Text = dr5["op4"].ToString();
                        }
                        conn5.Close();

                        // Code for next qn retrieval
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        radLabel2.Text =
                           "There was an error in executing the SQL. " +
                           "Error Message:" + ex.Message;

                    }
                }               //end if(countqn==1)
                else
                {
                    //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                    
                    string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                    SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    SqlDataReader dr;

                    if (lvl_counter_up < 3)
                        lvl = 1;
                    else if (lvl_counter_up >= 3 && lvl_counter_up < 6)
                        lvl = 2;
                    else if (lvl_counter_up >= 6)
                        lvl = 3;
                    if (lvl == 1)
                    {
                        radLabel7.Text = "1";
                        conn.Open();
                        //int pop = stck_e.Pop();
                        cmd.CommandText = "select * from asp_e where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else
                                lvl_counter_up--;

                        }                       //end while
                        conn.Close();

                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                            //SqlConnection conn5 = new SqlConnection();
                            //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com


                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_e.Pop();
                            cmd5.CommandText = "select * from asp_e where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif

                    else if (lvl == 2)                      // one level 1 qn id in level2 ????????????????????????????????/
                    {
                        radLabel7.Text = "2";
                        if (lvl_counter_up == 3)
                        {
                            conn.Open();
                            //int pop = stck_m.Pop();
                            cmd.CommandText = "select * from asp_e where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }                   //end if
                        else
                        {
                            conn.Open();
                            //int pop = stck_m.Pop();
                            cmd.CommandText = "select * from asp_m where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }           //end else
                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                            //SqlConnection conn5 = new SqlConnection();
                            //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_m.Pop();
                            cmd5.CommandText = "select * from asp_m where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif

                    else if (lvl == 3)
                    {
                        radLabel7.Text = "3";
                        if (lvl_counter_up == 6)
                        {
                            conn.Open();
                            //int pop = stck_h.Pop();
                            cmd.CommandText = "select * from asp_m where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }
                        else
                        {
                            conn.Open();
                            //int pop = stck_h.Pop();
                            cmd.CommandText = "select * from asp_h where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }
                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                            //SqlConnection conn5 = new SqlConnection();
                            //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_h.Pop();
                            cmd5.CommandText = "select * from asp_h where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif
                }           //end else
                countqn++;
                label2.Text = marks.ToString();


                /*   radRadioButton_optionA.IsChecked = false;
                   radRadioButton_optionB.IsChecked = false;
                   radRadioButton_optionC.IsChecked = false;
                   radRadioButton_optionD.IsChecked = false;*/
            }
            else if (exm_sub == "3")
            {
                if (countqn == total_qn)
                {
                    //button1.Visible = false;
                    //button4.Visible = true;
                    radButton_next.Visible = false;
                    radButton_submit.Visible = true;
                    richTextBox1.Enabled = false;
                    radRadioButton_optionA.Enabled = false;
                    radRadioButton_optionB.Enabled = false;
                    radRadioButton_optionC.Enabled = false;
                    radRadioButton_optionD.Enabled = false;
                }
                if (countqn == 1)
                {
                    radLabel7.Text = "1";
                    try
                    {
                        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                        string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                        SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        SqlDataReader dr;
                        conn.Open();
                        {
                            cmd.CommandText = "select * from ado_e where id=" + pop + ""; // can be put in if for diff subj n level+"
                            dr = cmd.ExecuteReader();
                        }

                        while (dr.Read())
                        {
                            if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else
                                lvl_counter_up--;

                        }           //end while
                        //level count inc if correct ans else dec

                        //if level=1 retrieval from level 1 and accordingly

                        conn.Close();

                        // Code for next qn retrieval

                        //SqlConnection conn5 = new SqlConnection();
                        //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                        SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.Connection = conn5;

                        pop = stck_e.Pop();                     //a chance is there for the first qn to be repeated
                        cmd5.CommandText = "select * from ado_e where id =" + pop + ""; //can be put in if for diff subj
                        conn5.Open();
                        SqlDataReader dr5 = cmd5.ExecuteReader();
                        while (dr5.Read())
                        {
                            radLabel8.Text = (countqn + 1).ToString();
                            radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                            richTextBox1.Text = dr5["qn"].ToString();
                            radRadioButton_optionA.Text = dr5["op1"].ToString();
                            radRadioButton_optionB.Text = dr5["op2"].ToString();
                            radRadioButton_optionC.Text = dr5["op3"].ToString();
                            radRadioButton_optionD.Text = dr5["op4"].ToString();
                        }
                        conn5.Close();

                        // Code for next qn retrieval
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        radLabel2.Text =
                           "There was an error in executing the SQL. " +
                           "Error Message:" + ex.Message;

                    }
                }               //end if(countqn==1)
                else
                {
                    //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                    string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                    SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    SqlDataReader dr;

                    if (lvl_counter_up < 3)
                        lvl = 1;
                    else if (lvl_counter_up >= 3 && lvl_counter_up < 6)
                        lvl = 2;
                    else if (lvl_counter_up >= 6)
                        lvl = 3;
                    if (lvl == 1)
                    {
                        radLabel7.Text = "1";
                        conn.Open();
                        //int pop = stck_e.Pop();
                        cmd.CommandText = "select * from ado_e where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else
                                lvl_counter_up--;

                        }                       //end while
                        conn.Close();

                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                    //        SqlConnection conn5 = new SqlConnection();
                      //      conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_e.Pop();
                            cmd5.CommandText = "select * from ado_e where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif

                    else if (lvl == 2)                      // one level 1 qn id in level2 ????????????????????????????????/
                    {
                        radLabel7.Text = "2";
                        if (lvl_counter_up == 3)
                        {
                            conn.Open();
                            //int pop = stck_m.Pop();
                            cmd.CommandText = "select * from ado_e where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }                   //end if
                        else
                        {
                            conn.Open();
                            //int pop = stck_m.Pop();
                            cmd.CommandText = "select * from ado_m where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }           //end else
                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                            //SqlConnection conn5 = new SqlConnection();
                            //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_m.Pop();
                            cmd5.CommandText = "select * from ado_m where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif

                    else if (lvl == 3)
                    {
                        radLabel7.Text = "3";
                        if (lvl_counter_up == 6)
                        {
                            conn.Open();
                            //int pop = stck_h.Pop();
                            cmd.CommandText = "select * from ado_m where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }
                        else
                        {
                            conn.Open();
                            //int pop = stck_h.Pop();
                            cmd.CommandText = "select * from ado_h where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }
                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                            //SqlConnection conn5 = new SqlConnection();
                            //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_h.Pop();
                            cmd5.CommandText = "select * from ado_h where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif
                }           //end else
                countqn++;
                label2.Text = marks.ToString();


                /*   radRadioButton_optionA.IsChecked = false;
                   radRadioButton_optionB.IsChecked = false;
                   radRadioButton_optionC.IsChecked = false;
                   radRadioButton_optionD.IsChecked = false;*/
            }
            else if (exm_sub == "4")
            {
                if (countqn == total_qn)
                {
                    //button1.Visible = false;
                    //button4.Visible = true;
                    radButton_next.Visible = false;
                    radButton_submit.Visible = true;
                    richTextBox1.Enabled = false;
                    radRadioButton_optionA.Enabled = false;
                    radRadioButton_optionB.Enabled = false;
                    radRadioButton_optionC.Enabled = false;
                    radRadioButton_optionD.Enabled = false;
                }
                if (countqn == 1)
                {
                    radLabel7.Text = "1";
                    try
                    {
                        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        SqlDataReader dr;
                        conn.Open();
                        {
                            cmd.CommandText = "select * from sql_e where id=" + pop + ""; // can be put in if for diff subj n level+"
                            dr = cmd.ExecuteReader();
                        }

                        while (dr.Read())
                        {
                            if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else
                                lvl_counter_up--;

                        }           //end while
                        //level count inc if correct ans else dec

                        //if level=1 retrieval from level 1 and accordingly

                        conn.Close();

                        // Code for next qn retrieval

                        //SqlConnection conn5 = new SqlConnection();
                        //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                        string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                        SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.Connection = conn5;

                        pop = stck_e.Pop();                     //a chance is there for the first qn to be repeated
                        cmd5.CommandText = "select * from sql_e where id =" + pop + ""; //can be put in if for diff subj
                        conn5.Open();
                        SqlDataReader dr5 = cmd5.ExecuteReader();
                        while (dr5.Read())
                        {
                            radLabel8.Text = (countqn + 1).ToString();
                            radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                            richTextBox1.Text = dr5["qn"].ToString();
                            radRadioButton_optionA.Text = dr5["op1"].ToString();
                            radRadioButton_optionB.Text = dr5["op2"].ToString();
                            radRadioButton_optionC.Text = dr5["op3"].ToString();
                            radRadioButton_optionD.Text = dr5["op4"].ToString();
                        }
                        conn5.Close();

                        // Code for next qn retrieval
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        radLabel2.Text =
                           "There was an error in executing the SQL. " +
                           "Error Message:" + ex.Message;

                    }
                }               //end if(countqn==1)
                else
                {
                    //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True");
                    string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
                    SqlConnection conn = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    SqlDataReader dr;

                    if (lvl_counter_up < 3)
                        lvl = 1;
                    else if (lvl_counter_up >= 3 && lvl_counter_up < 6)
                        lvl = 2;
                    else if (lvl_counter_up >= 6)
                        lvl = 3;
                    if (lvl == 1)
                    {
                        radLabel7.Text = "1";
                        conn.Open();
                        //int pop = stck_e.Pop();
                        cmd.CommandText = "select * from sql_e where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                            {
                                marks += 3;
                                lvl_counter_up++;
                            }
                            else
                                lvl_counter_up--;

                        }                       //end while
                        conn.Close();

                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                        //    SqlConnection conn5 = new SqlConnection();
                          //  conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_e.Pop();
                            cmd5.CommandText = "select * from sql_e where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif

                    else if (lvl == 2)                      // one level 1 qn id in level2 ????????????????????????????????/
                    {
                        radLabel7.Text = "2";
                        if (lvl_counter_up == 3)
                        {
                            conn.Open();
                            //int pop = stck_m.Pop();
                            cmd.CommandText = "select * from sql_e where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 3;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }                   //end if
                        else
                        {
                            conn.Open();
                            //int pop = stck_m.Pop();
                            cmd.CommandText = "select * from sql_m where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }           //end else
                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                            //SqlConnection conn5 = new SqlConnection();
                            //conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_m.Pop();
                            cmd5.CommandText = "select * from sql_m where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif

                    else if (lvl == 3)
                    {
                        radLabel7.Text = "3";
                        if (lvl_counter_up == 6)
                        {
                            conn.Open();
                            //int pop = stck_h.Pop();
                            cmd.CommandText = "select * from sql_m where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 5;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }
                        else
                        {
                            conn.Open();
                            //int pop = stck_h.Pop();
                            cmd.CommandText = "select * from sql_h where id=" + pop + ""; // can be put in 'if' for diff subj n level+"
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                if (radRadioButton_optionA.IsChecked == true && radRadioButton_optionA.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionB.IsChecked == true && radRadioButton_optionB.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionC.IsChecked == true && radRadioButton_optionC.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else if (radRadioButton_optionD.IsChecked == true && radRadioButton_optionD.Text == dr["ans"].ToString())
                                {
                                    marks += 7;
                                    lvl_counter_up++;
                                }
                                else
                                    lvl_counter_up--;

                            }                       //end while
                            conn.Close();
                        }
                        // Code for next qn retrieval
                        if (countqn != total_qn)
                        {
                        //    SqlConnection conn5 = new SqlConnection();
                          //  conn5.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
                            SqlConnection conn5 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.Connection = conn5;

                            pop = stck_h.Pop();
                            cmd5.CommandText = "select * from sql_h where id =" + pop + ""; //can be put in if for diff subj
                            conn5.Open();
                            SqlDataReader dr5 = cmd5.ExecuteReader();
                            while (dr5.Read())
                            {
                                radLabel8.Text = (countqn + 1).ToString();
                                radLabel2.Text = "Qn No. " + dr5["id"].ToString();
                                richTextBox1.Text = dr5["qn"].ToString();
                                radRadioButton_optionA.Text = dr5["op1"].ToString();
                                radRadioButton_optionB.Text = dr5["op2"].ToString();
                                radRadioButton_optionC.Text = dr5["op3"].ToString();
                                radRadioButton_optionD.Text = dr5["op4"].ToString();
                            }
                            conn5.Close();
                        }
                        // Code for next qn retrieval
                    }                           //endif
                }           //end else
                countqn++;
                label2.Text = marks.ToString();


                /*   radRadioButton_optionA.IsChecked = false;
                   radRadioButton_optionB.IsChecked = false;
                   radRadioButton_optionC.IsChecked = false;
                   radRadioButton_optionD.IsChecked = false;*/
            }                           //end if subj=4


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton_submit_Click(object sender, EventArgs e)
        {
            close_v = 1;


            //SqlConnection conn10 = new SqlConnection();
            //conn10.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn10 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

            SqlCommand cmd10 = new SqlCommand();
            cmd10.Connection = conn10;
            if (exm_sub == "1")
            {
                cmd10.CommandText = "update student set m_cs='" + marks.ToString() + "' where usr='" + y_student + "' ";
            }
            else if (exm_sub == "2")
            {
                cmd10.CommandText = "update student set m_asp='" + marks.ToString() + "' where usr='" + y_student + "' ";
            }
            else if (exm_sub == "3")
            {
                cmd10.CommandText = "update student set m_ado='" + marks.ToString() + "' where usr='" + y_student + "' ";
            }
            else if (exm_sub == "4")
            {
                cmd10.CommandText = "update student set m_sql='" + marks.ToString() + "' where usr='" + y_student + "' ";
            }

            conn10.Open();
            SqlDataReader dr10 = cmd10.ExecuteReader();
            conn10.Close();

            radPanel2.Visible = false;


            //SqlConnection conn11 = new SqlConnection();
            //conn11.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            SqlConnection conn11 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

            SqlCommand cmd11 = new SqlCommand();
            cmd11.Connection = conn11;

            cmd11.CommandText = "update student set allowed='0' where usr='" + y_student + "' ";
            conn11.Open();
            SqlDataReader dr11 = cmd11.ExecuteReader();
            conn11.Close();

            //to enter total marks

            //SqlConnection conn15 = new SqlConnection();
            //conn15.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            SqlConnection conn15 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

            SqlCommand cmd15 = new SqlCommand();
            cmd15.Connection = conn15;

            cmd15.CommandText = "select m_cs,m_asp,m_ado,m_sql from student where usr='" + y_student + "' ";
            conn15.Open();
            SqlDataReader dr15 = cmd15.ExecuteReader();
            while (dr15.Read())
            {
                marks_total = Convert.ToInt32(dr15["m_cs"]) + Convert.ToInt32(dr15["m_asp"]) + Convert.ToInt32(dr15["m_ado"]) + Convert.ToInt32(dr15["m_sql"]);
            }
            conn15.Close();

            //SqlConnection conn16 = new SqlConnection();
            //conn16.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            SqlConnection conn16 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

            SqlCommand cmd16 = new SqlCommand();
            cmd16.Connection = conn16;

            cmd16.CommandText = "update student set m_total='" + marks_total.ToString() + "' where usr='" + y_student + "' ";
            conn16.Open();
            SqlDataReader dr16 = cmd16.ExecuteReader();

            conn16.Close();

        }

        private void radButton_exitexam_Click(object sender, EventArgs e)
        {

            //SqlConnection conn11 = new SqlConnection();
            //conn11.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            string connection_string = OnlineExam.Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn11 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

            SqlCommand cmd11 = new SqlCommand();
            cmd11.Connection = conn11;

            cmd11.CommandText = "update student set allowed='0' where usr='" + y_student + "' ";
            conn11.Open();
            SqlDataReader dr11 = cmd11.ExecuteReader();
            conn11.Close();

            //SqlConnection conn12 = new SqlConnection();
            //conn12.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            SqlConnection conn12 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

            SqlCommand cmd12 = new SqlCommand();
            cmd12.Connection = conn12;
            if (exm_sub == "1")
            {
                cmd12.CommandText = "update student set m_cs='" + marks.ToString() + "' where usr='" + y_student + "' ";
            }
            else if (exm_sub == "2")
            {
                cmd12.CommandText = "update student set m_asp='" + marks.ToString() + "' where usr='" + y_student + "' ";
            }
            else if (exm_sub == "3")
            {
                cmd12.CommandText = "update student set m_ado='" + marks.ToString() + "' where usr='" + y_student + "' ";
            }
            else if (exm_sub == "4")
            {
                cmd12.CommandText = "update student set m_sql='" + marks.ToString() + "' where usr='" + y_student + "' ";
            }

            conn12.Open();
            SqlDataReader dr12 = cmd12.ExecuteReader();
            conn12.Close();

            
            //to enter total marks
            
            //SqlConnection conn13 = new SqlConnection();
            //conn13.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            SqlConnection conn13 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

            SqlCommand cmd13 = new SqlCommand();
            cmd13.Connection = conn13;

            cmd13.CommandText = "select m_cs,m_asp,m_ado,m_sql from student where usr='" + y_student + "' ";
            conn13.Open();
            SqlDataReader dr13 = cmd13.ExecuteReader();
            while (dr13.Read())
            {
                marks_total = Convert.ToInt32(dr13["m_cs"]) + Convert.ToInt32(dr13["m_asp"]) + Convert.ToInt32(dr13["m_ado"]) + Convert.ToInt32(dr13["m_sql"]);
            }
            conn13.Close();

            //SqlConnection conn14 = new SqlConnection();
            //conn14.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Prakul\Documents\Visual Studio 2012\OnlineExam\OnlineExam\Database1.mdf;Integrated Security=True";
            SqlConnection conn14 = new SqlConnection(connection_string);//updated 11-03-2014 by gupta.prakul@gmail.com

            SqlCommand cmd14 = new SqlCommand();
            cmd14.Connection = conn14;

            cmd14.CommandText = "update student set m_total='"+marks_total.ToString()+"' where usr='" + y_student + "' ";
            conn14.Open();
            SqlDataReader dr14 = cmd14.ExecuteReader();

            conn14.Close();

            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();

        }
    }
}
