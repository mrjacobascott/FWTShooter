using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FWTShooter {
    public partial class localPolicy : Form {
        //init variables for usage elsewhere outside constructor
        private Dictionary<string, string> ruleNames;
        private Dictionary<string, string> localRules;

        // constructor
        public localPolicy(Dictionary<string, string> rules) {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(localPolicy_Closing);
            // init rule name dictionary
            ruleNames = new Dictionary<string, string>();
            // add placeholder text for dropdown
            ruleNames.Add("Select rule:", "default");
            // init rule data dictionary
            localRules = new Dictionary<string, string>();

            //loop through passed rules
            foreach (var rule in rules.Keys) {
                //populate the data dictionary to use in this class
                localRules.Add(rule, rules[rule]);
                // get the user entered name of the fw rule
                string name = rules[rule].Split(new string[] { "Name=" }, StringSplitOptions.None).Last();
                // remove the tail setting after the rule name
                name = name.Split(new string[] { @"|" }, StringSplitOptions.None).First();
                //append the registry name after the user entered rule name
                name += " (" + rule + ")";
                //add the rule names to the list for usage in the combo box
                ruleNames.Add(name, rule);
            }
            //convert dictionary to list, configure dropdown
            var ruleNamesToShow = ruleNames.Keys.ToList();
            rulesBox.DataSource = ruleNamesToShow;
            rulesBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //specify entry to be placeholder text, must be in the dictionary/list or won't do anything
            rulesBox.Text = "Select rule:";
        }
        private void label1_Click(object sender, EventArgs e) {

        }

        private void localPolicy_Load(object sender, EventArgs e) {

        }

        private void rules_SelectedIndexChanged(object sender, EventArgs e) {
            // this is done on initial load and anytime the list changes
            // this happens before local policy is loaded in

            // figure out what the selected item is
            string curRule = this.rulesBox.GetItemText(this.rulesBox.SelectedItem);
            //checking to see if first load of page
            if (curRule == "FWTShooter.localPolicy+ruleList") {
                //do nothing because first load in so default
            } else {
                // check if currently selected rule is the placeholder text            
                if (ruleNames[curRule] != "default") {
                    // reset text box text
                    ruleInfoBox.ResetText();
                    //copy value to easy to use variable
                    string ruleInfo = localRules[ruleNames[curRule]];
                    //Action=
                    ruleInfo = ruleInfo.Replace("Action=", "Block/Allow traffic: ");
                    //Dir=
                    ruleInfo = ruleInfo.Replace("Dir=", "Direction: ");
                    //Profile= (can have multiple)
                    ruleInfo = ruleInfo.Replace("Profile=", "Profile: ");
                    //RA4= (can have mulitple)
                    ruleInfo = ruleInfo.Replace("RA4=", "Remote Address (IPV4): ");
                    //LA4= (can have mulitple)
                    ruleInfo = ruleInfo.Replace("LA4=", "Local Address (IPV4): ");
                    //Name=
                    ruleInfo = ruleInfo.Replace("Name=", "Name of Rule: ");
                    //Active=
                    ruleInfo = ruleInfo.Replace("Active=", "Is rule enabled: ");
                    //Protocol=
                    ruleInfo = ruleInfo.Replace("Protocol=", "Protocol: ");
                    //ICMP4= (can have mulitiple)
                    ruleInfo = ruleInfo.Replace("ICMP4=", "ICMP (IPV4): ");
                    //ICMP6
                    ruleInfo = ruleInfo.Replace("ICMP6=", "ICMP (IPV6): ");
                    //RA6
                    ruleInfo = ruleInfo.Replace("RA6=", "Remote Address (IPV6): ");
                    //LA6
                    ruleInfo = ruleInfo.Replace("LA6=", "Local Address (IPV6): ");
                    //Lport
                    ruleInfo = ruleInfo.Replace("LPort=", "Local Port: ");
                    //Lport range
                    ruleInfo = ruleInfo.Replace("LPort2_10=", "Local Port Range: ");
                    //Rport
                    ruleInfo = ruleInfo.Replace("RPort=", "Remote Port: ");
                    //Rport range
                    ruleInfo = ruleInfo.Replace("RPort2_10=", "Remote Port Range: ");
                    //App
                    ruleInfo = ruleInfo.Replace("App=", "File Path: ");
                    //SVC
                    ruleInfo = ruleInfo.Replace("Svc=", "Service Name: ");
                    //Desc
                    ruleInfo = ruleInfo.Replace("Desc=", "Description: ");
                    //package family name
                    ruleInfo = ruleInfo.Replace("EmbedCtxt=", "Package Family Name: ");
                    //policy app id
                    ruleInfo = ruleInfo.Replace("AppPkgId=", "Policy App ID: ");
                    //Local user list
                    ruleInfo = ruleInfo.Replace("LUAuth=", "Local User Authorized List: ");
                    //IFtype
                    ruleInfo = ruleInfo.Replace("IFType=", "Interface type: ");
                    // edge
                    ruleInfo = ruleInfo.Replace("Edge=", "Edge Traversal Enabled: ");
                    //convert pipes to new lines
                    ruleInfo = ruleInfo.Replace("|", System.Environment.NewLine);
                    //populate textbox
                    ruleInfoBox.Text = ruleInfo;

                } else {
                    // default placeholder has been selected
                    ruleInfoBox.ResetText();
                }
            }
        }

        // handle clicking the x of the UI
        private void localPolicy_Closing(object sender, CancelEventArgs e) {
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

    }
}
