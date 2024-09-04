using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ATBM
{
    public partial class f_users : Form
    {
        public f_users()
        {
            InitializeComponent();
        }

        // Add a headercheckbox 
        CheckBox headerCheckBox = null;
        bool isHeaderCheckBoxClicked = false;

        private void addHeaderCheckBox()
        {
            headerCheckBox = new CheckBox();
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.Location = new Point(76, 5);

            // Add the checkbox into the datagridview 
            this.dataGridViewUsers.Controls.Add(headerCheckBox);
        }

        // Now header checkbox clickevent
        private void headerCheckBoxClick(CheckBox HCheckBox)
        {
            isHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells["check1"]).Value = HCheckBox.Checked;
            }

            dataGridViewUsers.RefreshEdit();

            isHeaderCheckBoxClicked = false;
        }

        // mouse click event
        private void headCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            headerCheckBoxClick((CheckBox)sender);
        }

        private void f_grant_user_role_Load(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
                {
                    // call this nethod of header checkbox 
                    addHeaderCheckBox();

                    // first add header checkbox than mouseclick without checkbox what will you click
                    headerCheckBox.MouseClick += new MouseEventHandler(headCheckBox_MouseClick);

                    con.Open();

                    dataGridViewUsers.AllowUserToAddRows = false;
                    DataGridViewCheckBoxColumn checkboxcol = new DataGridViewCheckBoxColumn();
                    checkboxcol.Width = 40;
                    checkboxcol.Name = "check1";
                    checkboxcol.HeaderText = "";
                    dataGridViewUsers.Columns.Add(checkboxcol);


                    // Select all members of all roles
                    OracleDataAdapter adp1 = new OracleDataAdapter("SELECT USERNAME FROM ALL_USERS", con);
                    DataTable dt1 = new DataTable();
                    adp1.Fill(dt1);
                    dataGridViewUsers.DataSource = dt1;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGridByRoleName(string userName)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
                {
                    con.Open();

                    // Select all members of roles whose names contain roleName
                    OracleDataAdapter adp1 = new OracleDataAdapter($"SELECT USERNAME FROM ALL_USERS WHERE USERNAME LIKE '%{userName}%'", con);
                    DataTable dt1 = new DataTable();
                    adp1.Fill(dt1);
                    dataGridViewUsers.DataSource = dt1;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string getUserNameSelected()
        {
            string result = null;
            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["check1"].Value);
                if (isSelected)
                {
                    if (result != null)
                    {
                        result = result + ", ";
                    }
                    result = result + row.Cells["USERNAME"].Value;
                }
            }
            return result;
        }

        public static string usersName = null;
        private void button1_Click(object sender, EventArgs e)
        {
            usersName = getUserNameSelected();
            this.Hide();
        }

        private void txtNameUser_KeyDown(object sender, KeyEventArgs e)
        {
            string userName = txtNameUser.Text.Trim().ToUpper();
            LoadGridByRoleName(userName);
        }

        private void txtNameUser_Enter(object sender, EventArgs e)
        {
            // Set placeholder text to TextBox "txtNameName"
            if (txtNameUser.Text == "Nhập tên user")
            {
                txtNameUser.Text = null;
                txtNameUser.ForeColor = Color.Black;
            }
        }
    }
}
