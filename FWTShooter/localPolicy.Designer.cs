namespace FWTShooter {
    partial class localPolicy {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(localPolicy));
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            holder = new Panel();
            ruleInfoBox = new TextBox();
            label2 = new Label();
            rulesBox = new ComboBox();
            label3 = new Label();
            backButton = new Button();
            holder.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(575, 65);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.Click += label1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(701, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // holder
            // 
            holder.Controls.Add(ruleInfoBox);
            holder.Location = new Point(12, 117);
            holder.Name = "holder";
            holder.Size = new Size(677, 718);
            holder.TabIndex = 3;
            // 
            // ruleInfoBox
            // 
            ruleInfoBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ruleInfoBox.Location = new Point(0, 0);
            ruleInfoBox.Multiline = true;
            ruleInfoBox.Name = "ruleInfoBox";
            ruleInfoBox.ReadOnly = true;
            ruleInfoBox.Size = new Size(677, 718);
            ruleInfoBox.TabIndex = 0;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(676, 2);
            label2.TabIndex = 4;
            // 
            // rulesBox
            // 
            rulesBox.AllowDrop = true;
            rulesBox.DropDownHeight = 120;
            rulesBox.FormattingEnabled = true;
            rulesBox.IntegralHeight = false;
            rulesBox.Location = new Point(63, 88);
            rulesBox.Name = "rulesBox";
            rulesBox.Size = new Size(626, 23);
            rulesBox.TabIndex = 5;
            rulesBox.Text = "Select rule:";
            rulesBox.SelectedIndexChanged += rules_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 91);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 6;
            label3.Text = "Rules";
            // 
            // backButton
            // 
            backButton.Location = new Point(593, 9);
            backButton.Name = "backButton";
            backButton.Size = new Size(95, 65);
            backButton.TabIndex = 7;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // localPolicy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 847);
            Controls.Add(backButton);
            Controls.Add(label3);
            Controls.Add(rulesBox);
            Controls.Add(label2);
            Controls.Add(holder);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "localPolicy";
            Text = "Policy Currently On Device";
            FormClosing += localPolicy_Closing;
            Load += localPolicy_Load;
            holder.ResumeLayout(false);
            holder.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MenuStrip menuStrip1;
        private Panel holder;
        private Label label2;
        private ComboBox rulesBox;
        private Label label3;
        private TextBox ruleInfoBox;
        private Button backButton;
    }
}