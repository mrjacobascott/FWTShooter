using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FWTShooter {
    public partial class manualTester : Form {
        public manualTester() {
            InitializeComponent();
        }


        // handle clicking the x of the UI
        private void manualTester_Closing(object sender, CancelEventArgs e) {
            //this prevents the closing action from redoing if the back button is used
            if (xClicked) {
                xClicked = false;
                menu men = new menu();
                men.Show();
                this.Close();
            }
        }
        private bool xClicked = true;
        private void backButton_Click(object sender, EventArgs e) {
            xClicked = false;
            menu men = new menu();
            men.Show();
            this.Close();
        }

        private void manualTester_Load(object sender, EventArgs e) {
            //hide table while changes are done. Speeds up redraw
            tbl.SuspendLayout();
            tbl.Visible = false;

            //empties table for when reset button is clicked
            while (tbl.Controls.Count > 0) {
                tbl.Controls[0].Dispose();
            }
            //builds initial table
            tbl.ColumnCount = 6;
            tbl.RowCount = 1;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 350F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            //add headings
            tbl.Controls.Add(new Label() { Text = "Setting", Anchor = AnchorStyles.Top, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tbl.Controls.Add(new Label() { Text = "Enter Data", Anchor = AnchorStyles.Top, TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            tbl.Controls.Add(new Label() { Text = "Status", Anchor = AnchorStyles.Top, TextAlign = ContentAlignment.MiddleCenter }, 2, 0);
            tbl.Controls.Add(new Label() { Text = "Tips", Anchor = AnchorStyles.Top, TextAlign = ContentAlignment.MiddleCenter }, 3, 0);
            tbl.Controls.Add(new Label() { Text = "Add", Anchor = AnchorStyles.Top, TextAlign = ContentAlignment.MiddleCenter }, 4, 0);
            tbl.Controls.Add(new Label() { Text = "Delete", Anchor = AnchorStyles.Top, TextAlign = ContentAlignment.MiddleCenter }, 5, 0);

            //enabled option
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Enabled", Dock = DockStyle.Fill, Anchor = AnchorStyles.Left, TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new ComboBox() {
                Text = "Not Configured", Anchor = AnchorStyles.Top,
                Name = "enabled", Items = { "Not Configured", "Enabled", "Disabled" }, DropDownStyle = ComboBoxStyle.DropDownList,
                SelectedIndex = 0, Width = 250
            }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", Anchor = AnchorStyles.Top, ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", Anchor = AnchorStyles.Top }, 3, tbl.RowCount - 1);

            //name
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "Name", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "ruleName" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            //Interface types
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Interface types", Dock = DockStyle.Fill, Anchor = AnchorStyles.Left,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new CheckedListBox() {
                Text = "", Anchor = AnchorStyles.Top,
                Name = "interfaceTypes", Items = { "Remote Access", "Wireless", "Lan", "[Not Supported] Mobile Broadband",
                "All"}, Width = 250
            }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", Anchor = AnchorStyles.Top, ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", Anchor = AnchorStyles.Top }, 3, tbl.RowCount - 1);

            //File Path
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "File Path", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft },
                0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "filePath" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            //Remote port range
            //TODO: make button functional
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Remote Port Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "rport1" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);
            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Edge Traversal option
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Edge Traversal", Anchor = AnchorStyles.Left, Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new ComboBox() {
                Text = "Not Configured", Anchor = AnchorStyles.Top,
                Name = "edgeTraversal", Items = { "Not Configured", "Enabled", "Disabled" }, DropDownStyle = ComboBoxStyle.DropDownList,
                SelectedIndex = 0, Width = 250
            }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", Anchor = AnchorStyles.Top, ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", Anchor = AnchorStyles.Top }, 3, tbl.RowCount - 1);

            //Local User Authorized List
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local User Authorized List", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "rport1" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);
            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Network types
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Network types", Anchor = AnchorStyles.Left, Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new CheckedListBox() {
                Text = "", Anchor = AnchorStyles.Top,
                Name = "networkTypes", Items = { "FW_PROFILE_TYPE_DOMAIN", "FW_PROFILE_TYPE_PRIVATE", "FWPROFILETYPEPUBLIC",
                    "FW_PROFILE_TYPE_ALL", "FW_PROFILE_TYPE_CURRENT"}, Width = 250
            }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", Anchor = AnchorStyles.Top, ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", Anchor = AnchorStyles.Top }, 3, tbl.RowCount - 1);

            //Direction
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Direction", Anchor = AnchorStyles.Left, Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new ComboBox() {
                Text = "Not Configured", Anchor = AnchorStyles.Top,
                Name = "direction", Items = { "Not Configured", "This rule applies to inbound traffic",
                    "This rule applies to outbound traffic" }, DropDownStyle = ComboBoxStyle.DropDownList,
                SelectedIndex = 0, Width = 250
            }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", Anchor = AnchorStyles.Top, ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", Anchor = AnchorStyles.Top }, 3, tbl.RowCount - 1);

            //Local port range
            //TODO: make button functional
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local Port Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "lport1" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);
            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Remote Address range
            //TODO: make button functional
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Remote Address Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "rrange1" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);
            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Action
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Action", Anchor = AnchorStyles.Left, Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new ComboBox() {
                Text = "Not Configured", Anchor = AnchorStyles.Top,
                Name = "Action", Items = { "Not Configured", "Block", "Allow" },
                DropDownStyle = ComboBoxStyle.DropDownList, SelectedIndex = 0, Width = 250
            }, 1,
                tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", Anchor = AnchorStyles.Top, ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", Anchor = AnchorStyles.Top }, 3, tbl.RowCount - 1);

            //Description
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "Description", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft },
                0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "desc" }, 1,
                tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            //Policy App ID
            //todo check name
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "Policy App ID", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft },
                0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "polAppId" }, 1,
                tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            //Package Family Name
            //todo check name
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Package Family Name", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "pacFamName" }, 1,
                tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            //Protocol
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "Protocol", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft },
                0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "protocol" }, 1,
                tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            //ICMP Types and Codes
            //TODO: make button functional
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "ICMP Types and Codes", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "icmp" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);
            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Local Address range
            //TODO: make button functional
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local Address Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "lrange1" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            var lrangeadd = new Button() { Text = "Add", Anchor = AnchorStyles.None };
            lrangeadd.Click += new EventHandler(lrangadd_click);
            tbl.Controls.Add(lrangeadd, 4, tbl.RowCount - 1);


            // adding handler for when any control is pressed (including labels)
            foreach (Control c in this.tbl.Controls) {
                c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
            }

            //show table now changes are done. Speeds up redraw
            tbl.ResumeLayout();
            tbl.Visible = true;
        }

        //provide reset button to redraw the form as if on initial load
        private void resetButton_Click(object sender, EventArgs e) {
            manualTester_Load(null, EventArgs.Empty);
        }

        private void evaluateRules() {

        }

        private void lrangadd_click(object sender, EventArgs e) {
            //Local Address range
            // TODO update reference label? 
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local Address Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            
            // counter for how many times the name appears in the list
            // so that we can increment the number reference for the button
            var lrangecount = new int();
            for(int i = 0; i<tbl.RowCount; i++) {
                if (tbl.GetControlFromPosition(0, i).Text == "Local Address Range") {
                    lrangecount++;
                }
            }
            // add textbox, dynamically generate the name
            var lrange = new TextBox() { Text = "", Dock = DockStyle.Fill, Name = string.Format("lrange{0}", lrangecount) };
            tbl.Controls.Add(lrange, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
                }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            // add add button, dynamically generate the name
            var lrangeadd = new Button() { Text = "Add", Anchor = AnchorStyles.None, 
                Name= string.Format("lrangeadd{0}", lrangecount)};
            lrangeadd.Click += new EventHandler(lrangadd_click);
            tbl.Controls.Add(lrangeadd, 4, tbl.RowCount - 1);

            // add delete button, dynamically generate the name
            var lrangeremove = new Button() { Text = "Delete", Anchor = AnchorStyles.None, 
                Name = string.Format("lrangedelete{0}", lrangecount) };
            tbl.Controls.Add(lrangeremove, 5, tbl.RowCount - 1);

            // adding handler for when any control is pressed (including labels)
            foreach (Control c in this.tbl.Controls) {
                c.MouseClick -= new MouseEventHandler(ClickOnTableLayoutPanel);
                c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
            }
        }

        // this is where to do something based on a table control being clicked
        public void ClickOnTableLayoutPanel(object sender, MouseEventArgs e) {

            // column 5 is the delete column. Get the row and purge it
            if (tbl.GetColumn((Control)sender) > 0 && tbl.GetColumn((Control)sender) == 5) {
                //MessageBox.Show("delete clicked: " + tbl.GetRow((Control)sender) + ", " + tbl.GetColumn((Control)sender));
                //tbl.Controls.RemoveAt(tbl.GetRow((Control)sender));
                var currentRow = tbl.GetRow((Control)sender);
                if (currentRow >= tbl.RowCount) {
                    return;
                }

                // delete all controls of row that we want to delete
                for (int i = 0; i < tbl.ColumnCount; i++) {
                    var control = tbl.GetControlFromPosition(i, currentRow);
                    tbl.Controls.Remove(control);
                }

                // move up row controls that comes after row we want to remove
                for (int i = currentRow + 1; i < tbl.RowCount; i++) {
                    for (int j = 0; j < tbl.ColumnCount; j++) {
                        var control = tbl.GetControlFromPosition(j, i);
                        if (control != null) {
                            //tbl.Controls.Add(control, j, i - 1);
                            tbl.SetRow(control, i - 1);
                        }
                    }
                }
                var removeStyle = tbl.RowCount - 1;
                if (tbl.RowStyles.Count > removeStyle)
                    tbl.RowStyles.RemoveAt(removeStyle);
                tbl.RowCount--;
            }
            

            // todo once figured out how to mitigate the delete issue
            // migrate add button to here. Check the row that it came from
            // insert new row below using the name of the setting


        }

        private void lrangeremove_Click(object? sender, EventArgs e) {
            //MessageBox.Show((sender as Button).Name);
        }



        // this code is added to speed up redraw of the form which is slow
        // It adds double buffering which makes the form significantly quicker
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
    }


}
