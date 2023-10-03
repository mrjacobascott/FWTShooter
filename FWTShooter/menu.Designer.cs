namespace FWTShooter {
    partial class menu {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            localBtn = new Button();
            localLabel = new Label();
            tipLocal = new ToolTip(components);
            localTip = new ToolTip(components);
            manualRules = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 38);
            label1.Name = "label1";
            label1.Size = new Size(282, 15);
            label1.TabIndex = 0;
            label1.Text = "Welcome to the Intune Firewall Rule Troubleshooter!";
            // 
            // localBtn
            // 
            localBtn.Location = new Point(14, 89);
            localBtn.Name = "localBtn";
            localBtn.Size = new Size(151, 56);
            localBtn.TabIndex = 1;
            localBtn.Text = "Run";
            localBtn.UseVisualStyleBackColor = true;
            localBtn.Click += localBtn_Click;
            // 
            // localLabel
            // 
            localLabel.Location = new Point(183, 110);
            localLabel.Name = "localLabel";
            localLabel.Size = new Size(201, 15);
            localLabel.TabIndex = 2;
            localLabel.Text = "Check local successful firewall policy";
            // 
            // localTip
            // 
            localTip.ShowAlways = true;
            localTip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // manualRules
            // 
            manualRules.Location = new Point(14, 160);
            manualRules.Name = "manualRules";
            manualRules.Size = new Size(151, 56);
            manualRules.TabIndex = 7;
            manualRules.Text = "Run";
            manualRules.UseVisualStyleBackColor = true;
            manualRules.Click += manualRules_Click;
            // 
            // label3
            // 
            label3.Location = new Point(183, 181);
            label3.Name = "label3";
            label3.Size = new Size(201, 19);
            label3.TabIndex = 8;
            label3.Text = "Manually enter rules and validate";
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 235);
            Controls.Add(label3);
            Controls.Add(manualRules);
            Controls.Add(localLabel);
            Controls.Add(localBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "menu";
            Text = "Intune Firewall Rule Troubleshooter";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button localBtn;
        private Label localLabel;
        private ToolTip tipLocal;
        private ToolTip localTip;
        private Button cloudBtn;
        private Label label2;
        private Button infoBtn;
        private Label infoLabel;
        private Button manualRules;
        private Label label3;
    }
}