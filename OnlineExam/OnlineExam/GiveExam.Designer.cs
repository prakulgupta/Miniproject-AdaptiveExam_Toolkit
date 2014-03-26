using System;
namespace OnlineExam
{
    partial class GiveExam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {

                components.Dispose();
            }
            if (ptrHook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(ptrHook);
                ptrHook = IntPtr.Zero;
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.roundRectShapeForm = new Telerik.WinControls.RoundRectShape(this.components);
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radScrollablePanel_takeexam = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.radButton_submit = new Telerik.WinControls.UI.RadButton();
            this.radButton_next = new Telerik.WinControls.UI.RadButton();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.radRadioButton_optionC = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton_optionD = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton_optionB = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton_optionA = new Telerik.WinControls.UI.RadRadioButton();
            this.radButton_exitexam = new Telerik.WinControls.UI.RadButton();
            this.radButton_instruction = new Telerik.WinControls.UI.RadButton();
            this.radScrollablePanel_takeexam1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radButton_startexam = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radClock1 = new Telerik.WinControls.UI.RadClock();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel_takeexam)).BeginInit();
            this.radScrollablePanel_takeexam.PanelContainer.SuspendLayout();
            this.radScrollablePanel_takeexam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_submit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton_optionC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton_optionD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton_optionB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton_optionA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_exitexam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_instruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel_takeexam1)).BeginInit();
            this.radScrollablePanel_takeexam1.PanelContainer.SuspendLayout();
            this.radScrollablePanel_takeexam1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_startexam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radClock1)).BeginInit();
            this.SuspendLayout();
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(222)))), ((int)(((byte)(189)))));
            this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel1.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label4);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label3);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.panel1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radProgressBar1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radButton3);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radClock1);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(1252, 745);
            this.radScrollablePanel1.PanelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.radScrollablePanel1_PanelContainer_Paint);
            // 
            // 
            // 
            this.radScrollablePanel1.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.radScrollablePanel1.Size = new System.Drawing.Size(1254, 747);
            this.radScrollablePanel1.TabIndex = 1;
            this.radScrollablePanel1.Text = "radScrollablePanelgiveexam_main";
            this.radScrollablePanel1.Click += new System.EventHandler(this.radScrollablePanel1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "timer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "label3";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radScrollablePanel_takeexam);
            this.panel1.Controls.Add(this.radScrollablePanel_takeexam1);
            this.panel1.Location = new System.Drawing.Point(194, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 564);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // radScrollablePanel_takeexam
            // 
            this.radScrollablePanel_takeexam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel_takeexam.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel_takeexam.Name = "radScrollablePanel_takeexam";
            // 
            // radScrollablePanel_takeexam.PanelContainer
            // 
            this.radScrollablePanel_takeexam.PanelContainer.Controls.Add(this.radPanel2);
            this.radScrollablePanel_takeexam.PanelContainer.Controls.Add(this.radButton_exitexam);
            this.radScrollablePanel_takeexam.PanelContainer.Controls.Add(this.radButton_instruction);
            this.radScrollablePanel_takeexam.PanelContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.radScrollablePanel_takeexam.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel_takeexam.PanelContainer.Size = new System.Drawing.Size(1030, 554);
            // 
            // 
            // 
            this.radScrollablePanel_takeexam.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.radScrollablePanel_takeexam.Size = new System.Drawing.Size(1047, 564);
            this.radScrollablePanel_takeexam.TabIndex = 16;
            this.radScrollablePanel_takeexam.Text = "radScrollablePanel2";
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(248)))), ((int)(((byte)(216)))));
            this.radPanel2.Controls.Add(this.radLabel10);
            this.radPanel2.Controls.Add(this.radLabel9);
            this.radPanel2.Controls.Add(this.radLabel8);
            this.radPanel2.Controls.Add(this.radLabel7);
            this.radPanel2.Controls.Add(this.radLabel2);
            this.radPanel2.Controls.Add(this.label2);
            this.radPanel2.Controls.Add(this.radButton_submit);
            this.radPanel2.Controls.Add(this.radButton_next);
            this.radPanel2.Controls.Add(this.radLabel6);
            this.radPanel2.Controls.Add(this.radLabel5);
            this.radPanel2.Controls.Add(this.radLabel4);
            this.radPanel2.Controls.Add(this.radLabel3);
            this.radPanel2.Controls.Add(this.richTextBox1);
            this.radPanel2.Controls.Add(this.radRadioButton_optionC);
            this.radPanel2.Controls.Add(this.radRadioButton_optionD);
            this.radPanel2.Controls.Add(this.radRadioButton_optionB);
            this.radPanel2.Controls.Add(this.radRadioButton_optionA);
            this.radPanel2.Location = new System.Drawing.Point(0, 4);
            this.radPanel2.Name = "radPanel2";
            // 
            // 
            // 
            this.radPanel2.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPanel2.Size = new System.Drawing.Size(1017, 460);
            this.radPanel2.TabIndex = 3;
            // 
            // radLabel10
            // 
            this.radLabel10.Location = new System.Drawing.Point(33, 66);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(17, 18);
            this.radLabel10.TabIndex = 16;
            this.radLabel10.Text = "Q.";
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(14, 15);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(29, 18);
            this.radLabel9.TabIndex = 15;
            this.radLabel9.Text = "level";
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(56, 66);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(22, 18);
            this.radLabel8.TabIndex = 14;
            this.radLabel8.Text = "no.";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(49, 15);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(22, 18);
            this.radLabel7.TabIndex = 13;
            this.radLabel7.Text = "no.";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(14, 119);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 18);
            this.radLabel2.TabIndex = 12;
            this.radLabel2.Text = "random qn no.";
            this.radLabel2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 11;
            // 
            // radButton_submit
            // 
            this.radButton_submit.Location = new System.Drawing.Point(510, 288);
            this.radButton_submit.Name = "radButton_submit";
            this.radButton_submit.Size = new System.Drawing.Size(133, 43);
            this.radButton_submit.TabIndex = 10;
            this.radButton_submit.Text = "Submit";
            this.radButton_submit.ThemeName = "Aqua";
            this.radButton_submit.Visible = false;
            this.radButton_submit.Click += new System.EventHandler(this.radButton_submit_Click);
            // 
            // radButton_next
            // 
            this.radButton_next.Location = new System.Drawing.Point(298, 288);
            this.radButton_next.Name = "radButton_next";
            this.radButton_next.Size = new System.Drawing.Size(125, 43);
            this.radButton_next.TabIndex = 9;
            this.radButton_next.Text = "Next";
            this.radButton_next.ThemeName = "Aqua";
            this.radButton_next.Click += new System.EventHandler(this.radButton_next_Click);
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(152, 220);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(14, 18);
            this.radLabel6.TabIndex = 8;
            this.radLabel6.Text = "D";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(152, 191);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(13, 18);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "C";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(152, 164);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(13, 18);
            this.radLabel4.TabIndex = 8;
            this.radLabel4.Text = "B";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(151, 135);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(13, 18);
            this.radLabel3.TabIndex = 7;
            this.radLabel3.Text = "A";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(129, 54);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(759, 59);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // radRadioButton_optionC
            // 
            this.radRadioButton_optionC.Location = new System.Drawing.Point(180, 191);
            this.radRadioButton_optionC.Name = "radRadioButton_optionC";
            this.radRadioButton_optionC.Size = new System.Drawing.Size(105, 18);
            this.radRadioButton_optionC.TabIndex = 5;
            this.radRadioButton_optionC.Text = "radRadioButton4";
            // 
            // radRadioButton_optionD
            // 
            this.radRadioButton_optionD.Location = new System.Drawing.Point(180, 220);
            this.radRadioButton_optionD.Name = "radRadioButton_optionD";
            this.radRadioButton_optionD.Size = new System.Drawing.Size(105, 18);
            this.radRadioButton_optionD.TabIndex = 5;
            this.radRadioButton_optionD.Text = "radRadioButton3";
            // 
            // radRadioButton_optionB
            // 
            this.radRadioButton_optionB.Location = new System.Drawing.Point(180, 164);
            this.radRadioButton_optionB.Name = "radRadioButton_optionB";
            this.radRadioButton_optionB.Size = new System.Drawing.Size(105, 18);
            this.radRadioButton_optionB.TabIndex = 5;
            this.radRadioButton_optionB.Text = "radRadioButton2";
            // 
            // radRadioButton_optionA
            // 
            this.radRadioButton_optionA.Location = new System.Drawing.Point(179, 135);
            this.radRadioButton_optionA.Name = "radRadioButton_optionA";
            this.radRadioButton_optionA.Size = new System.Drawing.Size(105, 18);
            this.radRadioButton_optionA.TabIndex = 4;
            this.radRadioButton_optionA.Text = "radRadioButton1";
            // 
            // radButton_exitexam
            // 
            this.radButton_exitexam.Location = new System.Drawing.Point(329, 478);
            this.radButton_exitexam.Name = "radButton_exitexam";
            this.radButton_exitexam.Size = new System.Drawing.Size(132, 43);
            this.radButton_exitexam.TabIndex = 4;
            this.radButton_exitexam.Text = "Exit Exam";
            this.radButton_exitexam.ThemeName = "Aqua";
            this.radButton_exitexam.Click += new System.EventHandler(this.radButton_exitexam_Click);
            // 
            // radButton_instruction
            // 
            this.radButton_instruction.Location = new System.Drawing.Point(527, 478);
            this.radButton_instruction.Name = "radButton_instruction";
            this.radButton_instruction.Size = new System.Drawing.Size(133, 43);
            this.radButton_instruction.TabIndex = 5;
            this.radButton_instruction.Text = "Instructions";
            this.radButton_instruction.ThemeName = "Aqua";
            // 
            // radScrollablePanel_takeexam1
            // 
            this.radScrollablePanel_takeexam1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(248)))), ((int)(((byte)(216)))));
            this.radScrollablePanel_takeexam1.Location = new System.Drawing.Point(77, 88);
            this.radScrollablePanel_takeexam1.Name = "radScrollablePanel_takeexam1";
            // 
            // radScrollablePanel_takeexam1.PanelContainer
            // 
            this.radScrollablePanel_takeexam1.PanelContainer.Controls.Add(this.radButton_startexam);
            this.radScrollablePanel_takeexam1.PanelContainer.Controls.Add(this.label1);
            this.radScrollablePanel_takeexam1.PanelContainer.Size = new System.Drawing.Size(112, 260);
            // 
            // 
            // 
            this.radScrollablePanel_takeexam1.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.radScrollablePanel_takeexam1.Size = new System.Drawing.Size(114, 279);
            this.radScrollablePanel_takeexam1.TabIndex = 17;
            this.radScrollablePanel_takeexam1.Text = "radScrollablePanel2";
            // 
            // radButton_startexam
            // 
            this.radButton_startexam.Location = new System.Drawing.Point(396, 170);
            this.radButton_startexam.Name = "radButton_startexam";
            this.radButton_startexam.Size = new System.Drawing.Size(201, 73);
            this.radButton_startexam.TabIndex = 1;
            this.radButton_startexam.Text = "Start Exam";
            this.radButton_startexam.ThemeName = "Aqua";
            this.radButton_startexam.Click += new System.EventHandler(this.radButton_startexam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Dash = true;
            this.radProgressBar1.Location = new System.Drawing.Point(45, 251);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.SeparatorColor1 = System.Drawing.Color.Yellow;
            this.radProgressBar1.SeparatorColor2 = System.Drawing.Color.DarkOrange;
            this.radProgressBar1.SeparatorWidth = 1;
            this.radProgressBar1.Size = new System.Drawing.Size(130, 24);
            this.radProgressBar1.Step = 1;
            this.radProgressBar1.StepWidth = 20;
            this.radProgressBar1.TabIndex = 15;
            this.radProgressBar1.Value1 = 65;
            this.radProgressBar1.Value2 = 98;
            this.radProgressBar1.Visible = false;
            this.radProgressBar1.Click += new System.EventHandler(this.radProgressBar1_Click_1);
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(45, 341);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(110, 24);
            this.radButton3.TabIndex = 14;
            this.radButton3.Text = "radButton3";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Jokerman", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(330, 27);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.Alignment = System.Drawing.ContentAlignment.TopCenter;
            this.radLabel1.Size = new System.Drawing.Size(758, 107);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Summer Training Exam";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radClock1
            // 
            this.radClock1.Location = new System.Drawing.Point(21, 11);
            this.radClock1.Name = "radClock1";
            this.radClock1.Size = new System.Drawing.Size(134, 135);
            this.radClock1.TabIndex = 2;
            this.radClock1.Text = "radClock1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GiveExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 747);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "GiveExam";
            this.Shape = this.roundRectShapeForm;
            this.Text = "GiveExam";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GiveExam_Load);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.radScrollablePanel_takeexam.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel_takeexam)).EndInit();
            this.radScrollablePanel_takeexam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_submit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton_optionC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton_optionD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton_optionB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton_optionA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_exitexam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton_instruction)).EndInit();
            this.radScrollablePanel_takeexam1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel_takeexam1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel_takeexam1)).EndInit();
            this.radScrollablePanel_takeexam1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton_startexam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radClock1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.RoundRectShape roundRectShapeForm;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadClock radClock1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButton_instruction;
        private Telerik.WinControls.UI.RadButton radButton_exitexam;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton_optionC;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton_optionD;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton_optionB;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton_optionA;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel_takeexam1;
        private Telerik.WinControls.UI.RadButton radButton_startexam;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel_takeexam;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton radButton_next;
        private Telerik.WinControls.UI.RadButton radButton_submit;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.UI.RadButton radButton3;
        private System.Windows.Forms.Label label4;
    }
}
