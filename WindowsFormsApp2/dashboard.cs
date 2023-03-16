using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class dashboard
    {
        public partial class DashboardForm : Form
        {
            private string username;

            public DashboardForm(string username)
            {
                
                this.username = username;
                DisplayUserInfo();
            }

            private void DisplayUserInfo()
            {
                // Read the text file containing user information
                string filePath = "user_info.txt";
                List<string> lines = File.ReadAllLines(filePath).ToList();

                // Find the line containing the user's information
                string userInfo = "";
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == username)
                    {
                        userInfo = line;
                        break;
                    }
                }

                // Display the user's information in the appropriate labels
                string[] userInfoParts = userInfo.Split(',');
                lblUsername.Text = userInfoParts[0];
                lblFullName.Text = userInfoParts[2];
            }
        }
    }
}
