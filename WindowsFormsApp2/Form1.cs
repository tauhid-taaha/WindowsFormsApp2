using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both a username and password.");
                return;
            }

            if (AuthenticateUser(username, password))
            {
                DashboardForm dashboardForm = new DashboardForm(username);
                dashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Read the text file containing user information
            string filePath = "user_info.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            // Check if the entered credentials match any stored credentials
            foreach (string line in lines)
            {
                string[] userInfo = line.Split(',');
                if (userInfo[0] == username && userInfo[1] == password)
                {
                    return true;
                }
            }

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2form = new Form2();
            form2form.ShowDialog();
        }
    }
    }

