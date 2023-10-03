using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.ComponentModel;

namespace FWTShooter {
    public partial class menu : Form {
        public menu() {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(menu_Closing);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void localBtn_Click(object sender, EventArgs e) {

            //query registry path to get all firewall rules that are present
            var rules = new Dictionary<string, string>();
            const string REGISTRY_ROOT = @"SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\Mdm\FirewallRules";
            using (RegistryKey rootKey = Registry.LocalMachine.OpenSubKey(REGISTRY_ROOT)) {
                if (rootKey != null) {
                    string[] valueNames = rootKey.GetValueNames();
                    foreach (string currSubKey in valueNames) {
                        //currSubKey == the 'name' of the fw registry key 
                        String value = Registry.GetValue(rootKey.ToString(), currSubKey, "").ToString();
                        // create a dictionary of registry key and values both as string
                        rules.Add(currSubKey, value);
                    }
                    rootKey.Close();
                } else {
                    //key is null
                    MessageBox.Show("Couldn't find registry path that contains the path \n HKLM\\SYSTEM\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\Mdm\\FirewallRules");
                }
            }
            //startup the local policy UI
            localPolicy lclplcy = new localPolicy(rules);
            lclplcy.Show();
            this.Hide();
        }



        private void manualRules_Click(object sender, EventArgs e) {
            manualTester manTest = new manualTester();
            manTest.Show();
            this.Hide();
        }
        private void menu_Closing(object sender, CancelEventArgs e) {
            System.Windows.Forms.Application.Exit();
        }

    }
}