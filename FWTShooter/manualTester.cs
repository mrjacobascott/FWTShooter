using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;
using ToolTip = System.Windows.Forms.ToolTip;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));


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
            var enab = new ComboBox() {
                Text = "Not Configured", Anchor = AnchorStyles.Top, Name = "enabled",
                Items = { "Not Configured", "Enabled", "Disabled" }, DropDownStyle = ComboBoxStyle.DropDownList,
                SelectedIndex = 0, Width = 250
            };
            enab.SelectedIndexChanged += new System.EventHandler(evaluateRules);
            tbl.Controls.Add(enab, 1, tbl.RowCount - 1);

            //name
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "Name", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "ruleName" }, 1, tbl.RowCount - 1);

            //Interface types
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Interface types", Dock = DockStyle.Fill, Anchor = AnchorStyles.Left,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            var ift = new CheckedListBox() {
                Text = "", Anchor = AnchorStyles.Top,
                Name = "interfaceTypes", Items = { "Remote Access", "Wireless", "Lan", "[Not Supported] Mobile Broadband",
                "All"}, Width = 250, CheckOnClick = true
            };
            ift.SelectedIndexChanged += new System.EventHandler(evaluateRules);
            tbl.Controls.Add(ift, 1, tbl.RowCount - 1);

            //File Path
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "File Path", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft },
                0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "filePath" }, 1, tbl.RowCount - 1);


            //Remote port range
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Remote Port Range", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "rport0" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Edge Traversal option
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Edge Traversal", Anchor = AnchorStyles.Left, Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            var edgetr = new ComboBox() {
                Text = "Not Configured", Anchor = AnchorStyles.Top,
                Name = "edgeTraversal", Items = { "Not Configured", "Enabled", "Disabled" },
                DropDownStyle = ComboBoxStyle.DropDownList,
                SelectedIndex = 0, Width = 250
            };
            edgetr.SelectedIndexChanged += new System.EventHandler(evaluateRules);
            tbl.Controls.Add(edgetr, 1, tbl.RowCount - 1);

            //Local User Authorized List
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local User Authorized List", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "lusers" }, 1, tbl.RowCount - 1);

            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Network types
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Network types", Anchor = AnchorStyles.Left, Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            var nt = new CheckedListBox() {
                Text = "", Anchor = AnchorStyles.Top,
                Name = "networkTypes", Items = { "FW_PROFILE_TYPE_DOMAIN", "FW_PROFILE_TYPE_PRIVATE", "FWPROFILETYPEPUBLIC",
                    "FW_PROFILE_TYPE_ALL", "FW_PROFILE_TYPE_CURRENT"}, Width = 250, CheckOnClick = true,
            };
            nt.Click += new System.EventHandler(evaluateRules);
            tbl.Controls.Add(nt, 1, tbl.RowCount - 1);

            //Direction
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Direction", Anchor = AnchorStyles.Left, Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            var direc = new ComboBox() {
                Text = "Not Configured", Anchor = AnchorStyles.Top,
                Name = "direction", Items = { "Not Configured", "This rule applies to inbound traffic",
                    "This rule applies to outbound traffic" }, DropDownStyle = ComboBoxStyle.DropDownList,
                SelectedIndex = 0, Width = 250
            };
            direc.SelectedIndexChanged += new System.EventHandler(evaluateRules);
            tbl.Controls.Add(direc, 1, tbl.RowCount - 1);

            //Local port range
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local Port Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "lport0" }, 1, tbl.RowCount - 1);

            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Remote Address range
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Remote Address Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "rrange0" }, 1, tbl.RowCount - 1);

            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Action
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Action", Anchor = AnchorStyles.Left, Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            var acti = new ComboBox() {
                Text = "Not Configured", Anchor = AnchorStyles.Top,
                Name = "Action", Items = { "Not Configured", "Block", "Allow" },
                DropDownStyle = ComboBoxStyle.DropDownList, SelectedIndex = 0, Width = 250
            };
            acti.SelectedIndexChanged += new System.EventHandler(evaluateRules);
            tbl.Controls.Add(acti, 1, tbl.RowCount - 1);

            //Description
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "Description", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft },
                0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "desc" }, 1,
                tbl.RowCount - 1);

            //Policy App ID
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "Policy App ID", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft },
                0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "polAppId" }, 1,
                tbl.RowCount - 1);

            //Package Family Name
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Package Family Name", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "pacFamName" }, 1,
                tbl.RowCount - 1);

            //Protocol
            tbl.RowCount++;
            tbl.Controls.Add(new Label() { Text = "Protocol", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft },
                0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "protocol" }, 1,
                tbl.RowCount - 1);

            //ICMP Types and Codes
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "ICMP Types and Codes", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "icmp" }, 1, tbl.RowCount - 1);
            tbl.Controls.Add(new Button() { Text = "Add", Anchor = AnchorStyles.None }, 4, tbl.RowCount - 1);

            //Local Address range
            tbl.RowCount++;
            tbl.Controls.Add(new Label() {
                Text = "Local Address Range", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, tbl.RowCount - 1);
            tbl.Controls.Add(new TextBox() { Text = "", Dock = DockStyle.Fill, Name = "lrange0" }, 1, tbl.RowCount - 1);
            var lrangeadd = new Button() { Text = "Add", Anchor = AnchorStyles.None };
            tbl.Controls.Add(lrangeadd, 4, tbl.RowCount - 1);

            for (int i = 1; i < tbl.RowCount; i++) {
                //add status text placeholder to each row
                tbl.Controls.Add(new Label() {
                    Text = "", TextAlign = ContentAlignment.MiddleLeft, ForeColor = Color.Red, Anchor = AnchorStyles.Left
                }, 2, i);

                //add tooltip placeholder to each row
                PictureBox help = new PictureBox();
                help.Image = FWTShooter.Properties.Resources.halp;
                Size size = new Size(20,20);
                help.Size = size;
                help.SizeMode = PictureBoxSizeMode.Zoom;
                help.Anchor = AnchorStyles.Left;
                tbl.Controls.Add(help, 3, i);
            }

            // adding handler for when any control is pressed (including labels)
            foreach (Control c in this.tbl.Controls) {
                if (c is Button) {
                    c.MouseClick -= new MouseEventHandler(ClickOnTableLayoutPanel);
                    c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                } else if (c is TextBox) {
                    c.TextChanged -= new EventHandler(evaluateRules);
                    c.TextChanged += new EventHandler(evaluateRules);
                } else if (c is ComboBox) {
                    c.TextChanged -= new EventHandler(evaluateRules);
                    c.TextChanged += new EventHandler(evaluateRules);
                }
            }

            //show table now changes are done. Speeds up redraw
            tbl.ResumeLayout();
            tbl.Visible = true;
            // trigger evaluate rules to get the tooltips to populate
            evaluateRules(null,e);
        }

        //provide reset button to redraw the form as if on initial load
        private void resetButton_Click(object sender, EventArgs e) {
            manualTester_Load(null, EventArgs.Empty);
        }

        private void evaluateRules(object sender, EventArgs e) {
            // tooltip template
            ToolTip tt = new ToolTip();
            tt.AutoPopDelay = 5000;
            tt.InitialDelay = 100;
            tt.ReshowDelay = 500;
            tt.ShowAlways = true;

            ///////////////////////////////////////////////////////////////////////////
            // enabled rules
            // Name = "enabled"

            ///////////////////////////////////////////////////////////////////////////
            // name rules 
            // Name = "ruleName"
            // name not required to be unique
            // populate tool tips
            for (int i = 0; i < tbl.RowCount; i++) {
                var setting = tbl.GetControlFromPosition(1, i);
                if (setting.Name == "ruleName") {
                    tt.SetToolTip(tbl.GetControlFromPosition(3, i), 
                        "Name1: Fields cannot contain the pipe '|' character");
                    

                }
            }
            
            ////Rule logic
            // name1: check for pipe character
            for (int i = 0; i < tbl.RowCount; i++) {
                var setting = tbl.GetControlFromPosition(1, i);
                if (setting.Name == "ruleName") {
                    var warning = tbl.GetControlFromPosition(2, i);
                    if (setting.Text.Contains("|")) {
                        warning.Text = "Error: Name1";
                    } else {
                        warning.Text = "";
                    }

                }
            }

            ///////////////////////////////////////////////////////////////////////////
            // interface types
            // listbox name: interfaceTypes
            // populate tool tips
            for (int i = 0; i < tbl.RowCount; i++) {
                var setting = tbl.GetControlFromPosition(1, i);
                if (setting.Name == "interfaceTypes") {
                    tt.SetToolTip(tbl.GetControlFromPosition(3, i),
                        "Iface1: If 'all' is selected, others must not be selected");


                }
            }

            // rule iface1: If 'all' is selected, others must not be selected
            for (int i = 0; i < tbl.RowCount; i++) {
                var control = tbl.GetControlFromPosition(1, i);
                if (control.Name == "interfaceTypes") {
                    // todo found the control for this, now need to get the values for it
                    var ctl = (CheckedListBox) tbl.GetControlFromPosition(1, i);
                    var warning = tbl.GetControlFromPosition(2, i);
                    var checkedItems = ctl.CheckedItems;
                    if (checkedItems.Contains("All")){
                        if (checkedItems.Contains("Remote Access") | checkedItems.Contains("Wireless") |
                            checkedItems.Contains("Lan") | checkedItems.Contains("[Not Supported] Mobile Broadband")) {
                            warning.Text = "Error: Iface1";
                        } else {
                            warning.Text = "";
                        }
                    } else {
                        warning.Text = "";
                    }
                }   
            }


            ///////////////////////////////////////////////////////////////////////////
            // filepath
            // Name = "filePath" 
            //The file path of an app is simply its location on the client device.
            //For example, C:\Windows\System\Notepad.exe or % WINDIR %\Notepad.exe.
            //You can define one application to be used in each Firewall rule.If you
            //specify multiple conditions in a single rule, these will be treated as an
            //AND operation. i.e program = svchost.exe AND service = mpssvc, etc. All of
            //the app related conditions in a single rule work to scope the traffic even
            //further, so they must all correspond to the specific app/ service.

            // todo fpath1: verify length of filepath < 261 chars

            // todo fpath2: cannot contain spaces or path invalid characters <>:"/|?* 



            ///////////////////////////////////////////////////////////////////////////
            // remote port range
            // Name = "rport0"
            // reminder: multiple port ranges can be declared
            // todo rport1: verify ranges are acending
            // todo rport2: verity ranges are within range 0-65535
            // TODO rport3: if rport configured, need protocol 6/17 (change from edge to remote/local port ranges)
            // todo rport4: verify no letters/spaces/proper format
            /*
            for (int i = 0; i < tbl.RowCount; i++) {
                var control = tbl.GetControlFromPosition(1, i);
                if (control.Name == "edgeTraversal") {
                    if (control.Text == "Enabled") {
                        for (int j = 0; j < tbl.RowCount; j++) {
                            var pro = tbl.GetControlFromPosition(1, j);
                            if (pro.Name == "protocol") {
                                if (pro.Text != "6" & pro.Text != "17") {
                                    tbl.GetControlFromPosition(2, i).Text = "ERROR";
                                } else {
                                    tbl.GetControlFromPosition(2, i).Text = "";
                                }
                            }
                        }
                    } else if (control.Text == "Disabled") {
                        tbl.GetControlFromPosition(2, i).Text = "";
                    } else if (control.Text == "Not Configured") {
                        tbl.GetControlFromPosition(2, i).Text = "";
                    }
                }
            }
            */


            ///////////////////////////////////////////////////////////////////////////
            // edge traversal
            // combobox name: edgeTraversal
            // possibly requires IPV6 if specified, need to see if it gets created locally
            for (int i = 0; i < tbl.RowCount; i++) {
                var setting = tbl.GetControlFromPosition(1, i);
                if (setting.Name == "edgeTraversal") {
                    tt.SetToolTip(tbl.GetControlFromPosition(3, i),
                        "Edge1: If edge traversal is configured, rule must apply to inbound traffic.");


                }
            }

            // rule edge1: if edge traversal is enabled, rule direction must be inbound
            // todo change to direction, not protocol. 
            for (int i = 0; i < tbl.RowCount; i++) {
                var control = tbl.GetControlFromPosition(1, i);
                if (control.Name == "edgeTraversal") {
                    if (control.Text == "Enabled") {
                        for (int j = 0; j < tbl.RowCount; j++) {
                            var direct = tbl.GetControlFromPosition(1, j);
                            if (direct.Name == "direction") {
                                if (direct.Text == "This rule applies to outbound traffic" | direct.Text == "Not Configured") {
                                    tbl.GetControlFromPosition(2, i).Text = "Error: Edge1";
                                } else {
                                    tbl.GetControlFromPosition(2, i).Text = "";
                                }
                            }
                        }
                    } else if (control.Text == "Disabled") {
                        tbl.GetControlFromPosition(2, i).Text = "";
                    } else if (control.Text == "Not Configured") {
                        tbl.GetControlFromPosition(2, i).Text = "";
                    }
                }
            }

            ///////////////////////////////////////////////////////////////////////////
            // local users
            // Name = "lusers"
            // todo lusers1: cannot be used if targeting a service
            // todo lusers2: verify This is a string in Security Descriptor Definition Language (SDDL) format.

            ///////////////////////////////////////////////////////////////////////////
            // network types
            // Name = "networkTypes"

            ///////////////////////////////////////////////////////////////////////////
            // direction
            // Name = "direction"

            ///////////////////////////////////////////////////////////////////////////
            // local port range
            // Name = "lport0"
            // reminder: multiple port ranges can be declared
            // todo lport1: verify ranges are acending
            // todo lport2: verity ranges are within range 0-65535
            // TODO lport3: if lport configured, need protocol 6/17
            // todo rport4: verify no letters/spaces/proper format

            ///////////////////////////////////////////////////////////////////////////
            // remote address range
            // Name = "rrange0"
            // reminder multiple can be declared
            // Tokens are case insensitive. Valid tokens include:
            //  - "*" If present, this must be the only token included.
            //  - "Defaultgateway", "DHCP", "DNS", "WINS", "Intranet", "RmtIntranet", "Internet"
            //  - "Ply2Renders", "LocalSubnet"
            //  - A subnet can be specified using either the subnet mask or network prefix notation. 
            //  - A valid IPv6 address.
            //  - An IPv4 address range in the format of "start address - end address" with no spaces included.
            //  - An IPv6 address range in the format of "start address - end address" with no spaces included.

            // todo radd1: verify no spaces
            // todo radd2: check token nomenclature
            // todo radd3: verify format of ipv4/ipv6
            // todo radd4: verify start is before end address
            // todo radd4: verify start is before end address
            // todo radd5: verify if * that it's all that is present

            ///////////////////////////////////////////////////////////////////////////
            // action
            // Name = "action"

            ///////////////////////////////////////////////////////////////////////////
            // description
            // Name = "desc"
            // todo check for length/valid chars

            ///////////////////////////////////////////////////////////////////////////
            // policy app id
            // Name = "polAppId"
            // todo pappid1: can't use if service name found

            ///////////////////////////////////////////////////////////////////////////
            // package family name
            // Name = "pacFamName"

            ///////////////////////////////////////////////////////////////////////////
            // protocol
            // Name = "protocol"
            // todo: protocol1: verify single number and 0-255

            ///////////////////////////////////////////////////////////////////////////
            // icmp types and codes
            // Name = "icmp"

            ///////////////////////////////////////////////////////////////////////////
            // local address range
            // Name = "lrange0"
            // reminder multiple can be declared
            // Valid tokens include:
            //  - "*" If present, this must be the only token included.
            //  - A subnet can be specified using either the subnet mask or network prefix notation.
            //  - A valid IPv6 address.
            //  - An IPv4 address range in the format of "start address - end address" with no spaces included.
            //  - An IPv6 address range in the format of "start address - end address" with no spaces included.

            // todo ladd1: verify no spaces
            // todo ladd2: check token nomenclature
            // todo ladd3: verify format of ipv4/ipv6
            // todo ladd4: verify start is before end address
            // todo ladd5: verify if * that it's all that is present
        }

        // this is where to do something based on a table control being clicked
        public void ClickOnTableLayoutPanel(object sender, MouseEventArgs e) {
            ///////////////////////////////////////////////////////////
            ////DELETE row
            // column 5 is the delete column. Get the row and purge it
            if (tbl.GetColumn((Control)sender) > 0 && tbl.GetColumn((Control)sender) == 5) {
                //MessageBox.Show("delete clicked: " + tbl.GetRow((Control)sender) + ", " + tbl.GetColumn((Control)sender));
                tbl.SuspendLayout();
                tbl.Visible = false;

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
                tbl.ResumeLayout();
                tbl.Visible = true;
            }

            ////////////////////////////////////////////////////////////
            /// DUPLICATE row
            // goal is to copy the current row to the row below it
            // will have to do it by copying all data and moving down
            if (tbl.GetColumn((Control)sender) > 0 && tbl.GetColumn((Control)sender) == 4) {
                tbl.SuspendLayout();
                //tbl.Visible = false;
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
                        }
                    }
                }

                //copy current row to below row
                for (int j = 0; j < 2; j++) {
                    var controlToRemove = tbl.GetControlFromPosition(j, currentRow + 1);
                    if (controlToRemove != null) {
                        tbl.Controls.Remove(controlToRemove);
                    }
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
                var newControl = new TextBox() {
                    Text = "", Dock = DockStyle.Fill,
                    Name = string.Format(id + "{0}", settingCount)
                };
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
                    if (c is Button) {
                        c.MouseClick -= new MouseEventHandler(ClickOnTableLayoutPanel);
                        c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                    } else if (c is TextBox) {
                        c.TextChanged -= new EventHandler(evaluateRules);
                        c.TextChanged += new EventHandler(evaluateRules);
                    }
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

            tbl.ResumeLayout();
            tbl.Visible = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

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
