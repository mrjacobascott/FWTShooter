namespace FWTShooter {
    partial class manualTester {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manualTester));
            backButton = new Button();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            tbl = new TableLayoutPanel();
            helpIcon = new PictureBox();
            resetButton = new Button();
            panel1.SuspendLayout();
            tbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)helpIcon).BeginInit();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Location = new Point(724, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(90, 44);
            backButton.TabIndex = 1;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 26);
            label1.Name = "label1";
            label1.Size = new Size(507, 15);
            label1.TabIndex = 2;
            label1.Text = "Use this wizard to manually build out firewall rules to determine if they will be successful or not";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(13, 68);
            label2.Name = "label2";
            label2.Size = new Size(801, 1);
            label2.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tbl);
            panel1.Location = new Point(16, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(799, 891);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // tbl
            // 
            tbl.AutoScroll = true;
            tbl.AutoSize = true;
            tbl.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tbl.ColumnCount = 6;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            tbl.Controls.Add(helpIcon, 3, 0);
            tbl.Dock = DockStyle.Top;
            tbl.Location = new Point(0, 0);
            tbl.Margin = new Padding(0);
            tbl.Name = "tbl";
            tbl.RowCount = 1;
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl.Size = new Size(797, 34);
            tbl.TabIndex = 0;
            // 
            // helpIcon
            // 
            helpIcon.Dock = DockStyle.Fill;
            helpIcon.ErrorImage = (Image)resources.GetObject("helpIcon.ErrorImage");
            helpIcon.Image = Properties.Resources.halp;
            helpIcon.InitialImage = (Image)resources.GetObject("helpIcon.InitialImage");
            helpIcon.Location = new Point(642, 3);
            helpIcon.Margin = new Padding(1);
            helpIcon.Name = "helpIcon";
            helpIcon.Size = new Size(37, 28);
            helpIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            helpIcon.TabIndex = 0;
            helpIcon.TabStop = false;
            helpIcon.Click += pictureBox1_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(629, 12);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(89, 43);
            resetButton.TabIndex = 7;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // manualTester
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            ClientSize = new Size(827, 985);
            Controls.Add(resetButton);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(backButton);
            MaximizeBox = false;
            Name = "manualTester";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Manually Build and Validate Rules";
            FormClosing += manualTester_Closing;
            Load += manualTester_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tbl.ResumeLayout(false);
            tbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)helpIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button backButton;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private TableLayoutPanel tbl;
        private Button resetButton;
        private PictureBox helpIcon;
    }
}