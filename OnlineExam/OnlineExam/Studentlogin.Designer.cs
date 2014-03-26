namespace OnlineExam
{
    partial class Studentlogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.label4 = new System.Windows.Forms.Label();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(60, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 20;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(187, 233);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(129, 57);
            this.radButton1.TabIndex = 18;
            this.radButton1.Text = "Login";
            this.radButton1.ThemeName = "Aqua";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(324, 141);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "User Name";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(203, 47);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(244, 45);
            this.radLabel1.TabIndex = 21;
            this.radLabel1.Text = "Student Login";
            this.radLabel1.ThemeName = "Aqua";
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(353, 233);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(129, 57);
            this.radButton2.TabIndex = 19;
            this.radButton2.Text = "Back";
            this.radButton2.ThemeName = "Aqua";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(324, 171);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 22;
            // 
            // Studentlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 393);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Studentlogin";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Studentlogin";
            this.ThemeName = "Aqua";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private System.Windows.Forms.TextBox textBox2;
    }
}
