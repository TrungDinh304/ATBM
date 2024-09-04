using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATBM;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ATBM
{
    public partial class f_xem_chi_tiet : Form
    {
        public f_xem_chi_tiet()
        {
            InitializeComponent();
        }

        // roleName testing
        public string roleName = null;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Format font column headers dataGridView_privs_role
                this.dataGridView_privs_role.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                // Format font row dataGridView_privs_role
                foreach (DataGridViewRow row in dataGridView_privs_role.Rows)
                {
                    row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                }

                // Format font column headers dataGridViewNember
                this.dataGridViewNember.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                // Format font row dataGridView_privs_role
                foreach (DataGridViewRow row in dataGridViewNember.Rows)
                {
                    row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                }

                // get role name 
                roleName = user.roleName;

                buttonSelectCols.Visible = false;
                // when merge code => add par "roleName"
                // Select all members of roles whose is same roleName
                LoadGridNembers1(roleName);

                // Select all privileges of roles whose is same roleName
                LoadGridPrivs1(roleName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadTabelsToComboBox()
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
                {
                    con.Open();
                    OracleDataAdapter adp = new OracleDataAdapter("SELECT table_name FROM all_tables", con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    comboBoxTables.DataSource = dt;
                    comboBoxTables.DisplayMember = "table_name";
                    comboBoxTables.ValueMember = "table_name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGridNembers1(string roleName = "")
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
                {
                    con.Open();
                    // Select all members of roles whose names contain roleName
                    OracleDataAdapter adp1 = new OracleDataAdapter($"SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE = '{roleName}'", con);
                    DataTable dt1 = new DataTable();
                    adp1.Fill(dt1);
                    dataGridViewNember.DataSource = dt1;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadGridPrivs1(string roleName = "")
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
                {
                    con.Open();
                    OracleDataAdapter adp2 = new OracleDataAdapter($"SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE = '{roleName}'", con);
                    DataTable dt2 = new DataTable();
                    adp2.Fill(dt2);
                    dataGridView_privs_role.DataSource = dt2;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void LoadGridNembers(string roleName = "") 
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
                {
                    con.Open();
                    // Select all members of roles whose names contain roleName
                    OracleDataAdapter adp1 = new OracleDataAdapter($"SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE LIKE '%{roleName}%'", con);
                    DataTable dt1 = new DataTable();
                    adp1.Fill(dt1);
                    dataGridViewNember.DataSource = dt1;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void LoadGridPrivs(string roleName = "")
        {
            try
            {
                using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
                {
                    con.Open();
                    OracleDataAdapter adp2 = new OracleDataAdapter($"SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE '%{roleName}%'", con);
                    DataTable dt2 = new DataTable();
                    adp2.Fill(dt2);
                    dataGridView_privs_role.DataSource = dt2;
                    con.Close() ;   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // when click button "Chọn cột select"
        private void button1_Click(object sender, EventArgs e)
        {
            f_select_cols f = new f_select_cols();
            f.Show();
        }

        // when click button "Chọn user"
        private void btn_user_role_Click(object sender, EventArgs e)
        {
            f_users f = new f_users();
            f.Show();
        }

        private void comboBoxTables_Enter_1(object sender, EventArgs e)
        {
            try
            {
                // Load data into ComboBox controls
                loadTabelsToComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Create sendText from form f_xem_chi_tiet
        public static string tabName = null;

        private void comboBoxTables_SelectedValueChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;

            if (cb != null)
            {
                tabName = cb.SelectedValue?.ToString();
            }
        }

        // var string pridicate 
        private string pridicate = null;

        private void radioButtonInsert_CheckedChanged(object sender, EventArgs e)
        {
            pridicate = radioButtonInsert.Text.ToString();
            buttonSelectCols.Visible = false;
        }

        private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
        {
            pridicate = radioButtonUpdate.Text.ToString();
            buttonSelectCols.Visible = true;
        }

        private void radioButtonSelect_CheckedChanged(object sender, EventArgs e)
        {
            pridicate = radioButtonSelect.Text.ToString();
            buttonSelectCols.Visible = true;
        }

        private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {
            pridicate = radioButtonDelete.Text.ToString();
            buttonSelectCols.Visible = false;
        }
        private void btn_grant_Click(object sender, EventArgs e)
        {
            string colsName = null;
            OracleCommand cmd = null;

            if (pridicate == "Insert" || pridicate == "Select")
            {
                colsName = f_select_cols.colsName;
            }

            if (tabName == null)
            {
                MessageBox.Show("Vui lòng chọn tên bảng!");
                return;
            }

            if (pridicate == null)
            {
                MessageBox.Show("Vui lòng chọn quyền!");
                return;
            }

            using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
            {
                try
                {
                    con.Open();

                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "sp_grant_priv_to_role";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_role_name", OracleDbType.Varchar2).Value = roleName;
                    cmd.Parameters.Add("p_privs", OracleDbType.Varchar2).Value = pridicate;
                    cmd.Parameters.Add("p_obj_name", OracleDbType.Varchar2).Value = tabName;
                    cmd.Parameters.Add("p_cols_name", OracleDbType.Varchar2).Value = colsName;

                    OracleParameter errorCodeParam = new OracleParameter("p_error_code", OracleDbType.Int32);
                    errorCodeParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorCodeParam);

                    OracleParameter errorMsgParam = new OracleParameter("p_error_msg", OracleDbType.Varchar2, 1000);
                    errorMsgParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorMsgParam);

                    cmd.ExecuteNonQuery();


                    // get output due to check error or secussed
                    OracleDecimal errorCodeDecimal = (OracleDecimal)cmd.Parameters["p_error_code"].Value;
                    int errorCode = errorCodeDecimal.ToInt32();

                    OracleString errorMsgOracleString = (OracleString)cmd.Parameters["p_error_msg"].Value;
                    string errorMsg = errorMsgOracleString.IsNull ? "" : errorMsgOracleString.Value;

                    // check error or secussed
                    if (errorCode != 0)
                    {
                        MessageBox.Show($"Error {errorCode}: {errorMsg}");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Cấp quyền thành công!");
                    }

                    // reload DataGridView LoadGridPrivs
                    LoadGridPrivs(roleName);
                    colsName = null;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView_privs_role_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_privs_role.Rows.Count)
            {
                // Retrieve the value from the "GRANTEE" column of the clicked row and assign it to the text box
                comboBoxTables.Text = dataGridView_privs_role.Rows[e.RowIndex].Cells["TABLE_NAME"].Value?.ToString();
                if (dataGridView_privs_role.Rows[e.RowIndex].Cells["PRIVILEGE"].Value?.ToString() == "SELECT")
                {
                    radioButtonSelect.Checked = true;
                }
                else if (dataGridView_privs_role.Rows[e.RowIndex].Cells["PRIVILEGE"].Value?.ToString() == "UPDATE")
                {
                    radioButtonUpdate.Checked = true;
                }
                else if (dataGridView_privs_role.Rows[e.RowIndex].Cells["PRIVILEGE"].Value?.ToString() == "INSERT")
                {
                    radioButtonInsert.Checked = true;
                }
                else if (dataGridView_privs_role.Rows[e.RowIndex].Cells["PRIVILEGE"].Value?.ToString() == "DELETE")
                {
                    radioButtonDelete.Checked = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabName = comboBoxTables.Text;
            if (tabName == null)
            {
                MessageBox.Show("Vui lòng chọn tên bảng!");
                return;
            }

            if (pridicate == null)
            {
                MessageBox.Show("Vui lòng chọn quyền!");
                return;
            }

            // Create a connection to the database
            using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
            {
                try
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "sp_revoke_priv_from_role";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    cmd.Parameters.Add("p_role_name", OracleDbType.Varchar2).Value = roleName;
                    cmd.Parameters.Add("p_privs", OracleDbType.Varchar2).Value = pridicate;
                    cmd.Parameters.Add("p_obj_name", OracleDbType.Varchar2).Value = tabName;

                    // Output parameters
                    OracleParameter errorCodeParam = new OracleParameter("p_error_code", OracleDbType.Int32);
                    errorCodeParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorCodeParam);

                    OracleParameter errorMsgParam = new OracleParameter("p_error_msg", OracleDbType.Varchar2, 1000);
                    errorMsgParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorMsgParam);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    OracleDecimal errorCodeDecimal = (OracleDecimal)cmd.Parameters["p_error_code"].Value;
                    int errorCode = errorCodeDecimal.ToInt32();

                    OracleString errorMsgOracleString = (OracleString)cmd.Parameters["p_error_msg"].Value;
                    string errorMsg = errorMsgOracleString.IsNull ? "" : errorMsgOracleString.Value;

                    if (errorCode != 0)
                    {
                        MessageBox.Show($"Error {errorCode}: {errorMsg}");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thu quyền thành công!");
                    }

                    // reload DataGridView privs role
                    LoadGridPrivs(roleName);
                    con.Close();
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void dataGridViewNember_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewNember.Rows.Count)
            {
                // Retrieve the value from the "GRANTEE" column of the clicked row and assign it to the text box
                textBoxUserName.Text = dataGridViewNember.Rows[e.RowIndex].Cells["GRANTEE"].Value?.ToString();
            }
        }

        private void btnGrantUsers_Click(object sender, EventArgs e)
        {
            string userName = null;

            // get cols name
            userName = f_users.usersName;

            if (userName == null)
            {
                MessageBox.Show("Vui lòng chọn user!");
                return;
            }

            // Create a connection to the database
            using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
            {
                try
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "sp_grant_users_to_role";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    cmd.Parameters.Add("p_user_name", OracleDbType.Varchar2).Value = userName;
                    cmd.Parameters.Add("p_role_name", OracleDbType.Varchar2).Value = roleName;

                    // Output parameters
                    OracleParameter errorCodeParam = new OracleParameter("p_error_code", OracleDbType.Int32);
                    errorCodeParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorCodeParam);

                    OracleParameter errorMsgParam = new OracleParameter("p_error_msg", OracleDbType.Varchar2, 1000);
                    errorMsgParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorMsgParam);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    OracleDecimal errorCodeDecimal = (OracleDecimal)cmd.Parameters["p_error_code"].Value;
                    int errorCode = errorCodeDecimal.ToInt32();

                    OracleString errorMsgOracleString = (OracleString)cmd.Parameters["p_error_msg"].Value;
                    string errorMsg = errorMsgOracleString.IsNull ? "" : errorMsgOracleString.Value;

                    if (errorCode != 0)
                    {
                        MessageBox.Show($"Error {errorCode}: {errorMsg}");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Cấp user cho role thành công!");
                    }

                    // reload DataGridView privs role
                    LoadGridNembers(roleName);

                    userName = null;
                    con.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void buttonRevokeUser_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text.Trim();
            if (userName == null)
            {
                MessageBox.Show("Vui lòng chọn user");
                return;
            }

            // Create a connection to the database
            using (OracleConnection con = new OracleConnection(ConnectionStr.connectionStr))
            {
                try
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "sp_revoke_user_from_role";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    cmd.Parameters.Add("p_user_name", OracleDbType.Varchar2).Value = userName;
                    cmd.Parameters.Add("p_role_name", OracleDbType.Varchar2).Value = roleName;
                    

                    // Output parameters
                    OracleParameter errorCodeParam = new OracleParameter("p_error_code", OracleDbType.Int32);
                    errorCodeParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorCodeParam);

                    OracleParameter errorMsgParam = new OracleParameter("p_error_msg", OracleDbType.Varchar2, 1000);
                    errorMsgParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorMsgParam);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    OracleDecimal errorCodeDecimal = (OracleDecimal)cmd.Parameters["p_error_code"].Value;
                    int errorCode = errorCodeDecimal.ToInt32();

                    OracleString errorMsgOracleString = (OracleString)cmd.Parameters["p_error_msg"].Value;
                    string errorMsg = errorMsgOracleString.IsNull ? "" : errorMsgOracleString.Value;

                    if (errorCode != 0)
                    {
                        MessageBox.Show($"Error {errorCode}: {errorMsg}");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thu hồi user thành công!");
                    }

                    // reload DataGridView privs role
                    LoadGridNembers(roleName);

                    userName = null;
                    con.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
