namespace OnlineExam
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.radPanorama2 = new Telerik.WinControls.UI.RadPanorama();
            this.radTileElement5 = new Telerik.WinControls.UI.RadTileElement();
            this.radTileElement6 = new Telerik.WinControls.UI.RadTileElement();
            this.radTileElement7 = new Telerik.WinControls.UI.RadTileElement();
            this.radTileElement4 = new Telerik.WinControls.UI.RadTileElement();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radPanorama2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanorama2
            // 
            this.radPanorama2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radTileElement5,
            this.radTileElement6,
            this.radTileElement7});
            this.radPanorama2.Location = new System.Drawing.Point(144, 180);
            this.radPanorama2.Name = "radPanorama2";
            this.radPanorama2.Size = new System.Drawing.Size(303, 102);
            this.radPanorama2.TabIndex = 0;
            this.radPanorama2.Text = "radPanorama2";
            this.radPanorama2.Click += new System.EventHandler(this.radPanorama2_Click);
            // 
            // radTileElement5
            // 
            this.radTileElement5.AccessibleDescription = "Admin";
            this.radTileElement5.AccessibleName = "Admin";
            this.radTileElement5.Name = "radTileElement5";
            this.radTileElement5.Text = "Admin";
            this.radTileElement5.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radTileElement5.Click += new System.EventHandler(this.radTileElement5_Click_1);
            // 
            // radTileElement6
            // 
            this.radTileElement6.AccessibleDescription = "Teacher";
            this.radTileElement6.AccessibleName = "Teacher";
            this.radTileElement6.Column = 1;
            this.radTileElement6.Name = "radTileElement6";
            this.radTileElement6.Text = "Teacher";
            this.radTileElement6.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radTileElement6.Click += new System.EventHandler(this.radTileElement6_Click_1);
            // 
            // radTileElement7
            // 
            this.radTileElement7.AccessibleDescription = "Student";
            this.radTileElement7.AccessibleName = "Student";
            this.radTileElement7.Column = 2;
            this.radTileElement7.Name = "radTileElement7";
            this.radTileElement7.Text = "Student";
            this.radTileElement7.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radTileElement7.Click += new System.EventHandler(this.radTileElement7_Click);
            // 
            // radTileElement4
            // 
            this.radTileElement4.AccessibleDescription = "Admin";
            this.radTileElement4.AccessibleName = "Admin";
            this.radTileElement4.Name = "radTileElement4";
            this.radTileElement4.Text = "Admin";
            this.radTileElement4.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 465);
            this.Controls.Add(this.radPanorama2);
            this.Name = "Form1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam Tool Kit";
            this.ThemeName = "Aqua";
            ((System.ComponentModel.ISupportInitialize)(this.radPanorama2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.RadPanorama radPanorama1;
        private Telerik.WinControls.UI.RadTileElement radTileElement1;
        private Telerik.WinControls.UI.RadTileElement radTileElement2;
        private Telerik.WinControls.UI.RadTileElement radTileElement3;
        private Telerik.WinControls.UI.RadPanorama radPanorama2;
        private Telerik.WinControls.UI.RadTileElement radTileElement5;
        private Telerik.WinControls.UI.RadTileElement radTileElement6;
        private Telerik.WinControls.UI.RadTileElement radTileElement7;
        private Telerik.WinControls.UI.RadTileElement radTileElement4;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
    }
}

