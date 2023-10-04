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
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

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
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Remote Port Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "rport0" }, 1, tbl.RowCount - 1);
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
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "rport0" }, 1, tbl.RowCount - 1);
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
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local Port Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "lport0" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);
            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Remote Address range
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Remote Address Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "rrange0" }, 1, tbl.RowCount - 1);
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
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local Address Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "lrange0" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() {
                Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
            }, 2, tbl.RowCount - 1);
            tbl.Controls.Add(new Label() { Text = "", }, 3, tbl.RowCount - 1);

            var lrangeadd = new Button() { Text = "Add", Anchor = AnchorStyles.None };
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

        // this is where to do something based on a table control being clicked
        public void ClickOnTableLayoutPanel(object sender, MouseEventArgs e) {
            ///////////////////////////////////////////////////////////
            ///DELETE row
            // column 5 is the delete column. Get the row and purge it
            if (tbl.GetColumn((Control)sender) > 0 && tbl.GetColumn((Control)sender) == 5) {
                //MessageBox.Show("delete clicked: " + tbl.GetRow((Control)sender) + ", " + tbl.GetColumn((Control)sender));
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
                            tbl.SetRow(control, i - 1);
                        }
                    }
                }
                // remove the style from the last row, possibly not needed
                var removeStyle = tbl.RowCount - 1;
                if (tbl.RowStyles.Count > removeStyle)
                    tbl.RowStyles.RemoveAt(removeStyle);
                tbl.RowCount--;
                //this.Refresh();
            }

            ////////////////////////////////////////////////////////////
            /// DUPLICATE row
            // goal is to copy the current row to the row below it
            // will have to do it by copying all data and moving down
            if (tbl.GetColumn((Control)sender) > 0 && tbl.GetColumn((Control)sender) == 4) {
                // get the row that sent the request
                var currentRow = tbl.GetRow((Control)sender);
                tbl.RowCount++;
                // move down row controls that comes after row we want to add
                // start at the bottom and shuffle moving up the page because this 
                // moves the control, it doesn't copy it
                for (int i = tbl.RowCount - 1; i > currentRow; i--) {
                    for (int j = 0; j < tbl.ColumnCount; j++) {
                        var controlToRemove = tbl.GetControlFromPosition(j, i + 1);
                        if (controlToRemove != null) {
                            tbl.Controls.Remove(controlToRemove);
                        }

                        var ctl = tbl.GetControlFromPosition(j, i);
                        if (ctl != null) {
                            tbl.Controls.Add(ctl, j, i + 1);
                            //this.Refresh();
                            //tbl.SetRow(control, i + 1);
                        }
                    }
                }

                //copy current row to below row
                for (int j = 0; j < 2; j++) {
                    var controlToRemove = tbl.GetControlFromPosition(j, currentRow + 1);
                    if (controlToRemove != null) {
                        tbl.Controls.Remove(controlToRemove);
                    }
                    this.Refresh();

                }
                var controlName = tbl.GetControlFromPosition(0, currentRow);
                // copy label of button clicked and add to new row
                tbl.Controls.Add(new Label() {
                    Text = controlName.Text, Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                }, 0, currentRow + 1);
                // counter for how many times the name appears in the list
                // so that we can increment the number reference for the control/button
                var settingCount = new int();
                for (int i = 0; i < tbl.RowCount; i++) {
                    if (tbl.GetControlFromPosition(0, i).Text == controlName.Text) {
                        settingCount++;
                    }
                }

                // add data entry control, dynamically generate the name
                var control = tbl.GetControlFromPosition(1, currentRow);
                var id = control.Name;
                // only text box style setting can have some added, so that's all that is logic'd here
                var newControl = new TextBox() {Text = "", Dock = DockStyle.Fill,
                    Name = string.Format(id + "{0}", settingCount)};
                tbl.Controls.Add(newControl, 1, currentRow + 1);

                tbl.Controls.Add(new Label() {
                    Text = "", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red
                }, 2, currentRow + 1);
                tbl.Controls.Add(new Label() { Text = "", }, 3, currentRow + 1);
                var lrangeadd = new Button() {
                    Text = "Add", Anchor = AnchorStyles.None,
                    Name = string.Format(id + "{0}", settingCount)
                };
                tbl.Controls.Add(lrangeadd, 4, currentRow + 1);
                var lrangeremove = new Button() {
                    Text = "Delete", Anchor = AnchorStyles.None,
                    Name = string.Format(id + "{0}", settingCount)
                };
                tbl.Controls.Add(lrangeremove, 5, currentRow + 1);

                //make sure the new button has an event handler
                foreach (Control c in this.tbl.Controls) {
                    c.MouseClick -= new MouseEventHandler(ClickOnTableLayoutPanel);
                    c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                }
            }

            //blank rows appear for unknown reasons, trying to clean them up
            for (int i = 0; i < tbl.RowCount; i++) {
                var blankrows = tbl.GetControlFromPosition(0, i);
                if (blankrows == null) {
                    tbl.RowCount--;
                }
                //this.Refresh();
            }

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
