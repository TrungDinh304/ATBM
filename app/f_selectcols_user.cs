using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ATBM
{
    public partial class f_selectcols_user : Form
    {
        // Add a headercheckbox 
        CheckBox headerCheckBox = null;
        bool isHeaderCheckBoxClicked = false;

        private void addHeaderCheckBox()
        {
            headerCheckBox = new CheckBox();
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.Location = new Point(76, 5);

            // Add the checkbox into the datagridview 
            this.dataGridViewCols.Controls.Add(headerCheckBox);
        }

        // Now header checkbox clickevent
        private void headerCheckBoxClick(CheckBox HCheckBox)
        {
            isHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow row in dataGridViewCols.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells["check1"]).Value = HCheckBox.Checked;
            }

            dataGridViewCols.RefreshEdit();

            isHeaderCheckBoxClicked = false;
        }

        // mouse click event
        private void headCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            headerCheckBoxClick((CheckBox)sender);
        }

        public f_selectcols_user()
        {
            InitializeComponent();
            txtColName.Enter += txtColName_Enter;
            txtColName.KeyDown += txtColName_KeyDown;
            this.Load += f_selectcols_user_Load;
        }

        private static string tabName = "";

        private void f_selectcols_user_Load(object sender, EventArgs e)
        {
            try
            {
                // get tabName in form f_xem_chi_tiet
                tabName = user.tableName;

                // call this nethod of header checkbox 
                addHeaderCheckBox();

                // first add header checkbox than mouseclick without checkbox what will you click
                headerCheckBox.MouseClick += new MouseEventHandler(headCheckBox_MouseClick);

                // Add checkbox 
                dataGridViewCols.AllowUserToAddRows = false;
                DataGridViewCheckBoxColumn checkboxcol = new DataGridViewCheckBoxColumn();
                checkboxcol.Width = 40;
                checkboxcol.Name = "check1";
                checkboxcol.HeaderText = "";
                dataGridViewCols.Columns.Add(checkboxcol);

                // Select all members of all roles
                LoadGridByTabColsName(tabName, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadGridByTabColsName(string tabName, string colName = "")
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
                {
                    con.Open();

                    // Select all members of roles whose names contain roleName
                    OracleDataAdapter adp1 = new OracleDataAdapter($"SELECT column_name from ALL_TAB_COLUMNS WHERE table_name = '{tabName}' AND column_name LIKE '%{colName}%'", con);
                    DataTable dt1 = new DataTable();
                    adp1.Fill(dt1);
                    dataGridViewCols.DataSource = dt1;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getColsNameSelected()
        {
            string result = "";

            foreach (DataGridViewRow row in dataGridViewCols.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["check1"].Value);
                if (isSelected)
                {
                    if (result != "")
                    {
                        result = result + ", ";
                    }
                    result = result + row.Cells["column_name"].Value;
                }
            }
            return result;
        }

        public static string colsName = "";

        private void txtColName_KeyDown(object sender, KeyEventArgs e)
        {
            string ColName = txtColName.Text.Trim().ToUpper();
            LoadGridByTabColsName(tabName, ColName);
        }

        private void txtColName_Enter(object sender, EventArgs e)
        {
            // Set placeholder text to TextBox "txtNameName"
            if (txtColName.Text == "Nhập tên cột")
            {
                txtColName.Text = "";
                txtColName.ForeColor = Color.Black;
            }
        }

        private void btnGetCols_Click_1(object sender, EventArgs e)
        {
            colsName = getColsNameSelected();
            this.Hide();
        }
    }
}
