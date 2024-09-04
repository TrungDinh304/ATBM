using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string port = textBox_Port.Text;
            string Admin_Path = textBox_AdminFolderPath.Text;
            string username = textBox_UserName.Text;
            string password = textBox_PassWord.Text;

            if (port == "" || Admin_Path == "" || username == "" || password == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                try
                {
                    ConnectionStr.connectionStr = @"DATA SOURCE=localhost:" + port + "/xe;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=" + Admin_Path + ";PERSIST SECURITY INFO=True;USER ID=" + username + ";PASSWORD=" + password;
                    this.Hide();
                    user newuser = new user();
                    newuser.Show();
                    newuser.FormClosed += (s, args) => this.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            
        }
    }
}
