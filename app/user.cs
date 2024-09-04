using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
            comboBoxTablename.Leave += comboBoxTablename_Leave;
            comboBoxTablename.KeyUp += comboBoxTablename_KeyUp;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;
            comboBoxTablename.TextChanged += comboBoxTablename_TextChanged;
        }

        public static string tableName = "";
        private bool userExists(string username)
        {
            // Tạo câu lệnh SQL SELECT để kiểm tra xem người dùng có tồn tại không
            string query = $"SELECT COUNT(*) FROM DBA_USERS WHERE USERNAME = '{username}'";

            // Số lượng bản ghi tương ứng với tên người dùng trong cơ sở dữ liệu
            int count = 0;

            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    connection.Open();

                    // Tạo đối tượng OracleCommand để thực thi câu lệnh SQL
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // Thực hiện câu lệnh SQL và lấy kết quả số lượng bản ghi
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi kiểm tra sự tồn tại của người dùng: " + ex.Message);
            }

            // Trả về true nếu có ít nhất một bản ghi tương ứng với tên người dùng, ngược lại trả về false
            return count > 0;
        }

        private void createUser(string username, string password)
        {
            // Câu lệnh ALTER SESSION để cho phép tạo user
            string alterSessionSql = "ALTER SESSION SET \"_ORACLE_SCRIPT\" = true";

            // Câu lệnh SQL CREATE USER
            string createSql = $"CREATE USER {username} IDENTIFIED BY {password}";

            // Câu lệnh grant quyền connect cho user
            string grantconn = $"GRANT CONNECT TO {username}";
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    connection.Open();

                    // Thực hiện câu lệnh ALTER SESSION trước khi tạo người dùng
                    using (OracleCommand alterSessionCommand = new OracleCommand(alterSessionSql, connection))
                    {
                        alterSessionCommand.ExecuteNonQuery();
                    }

                    // Tạo đối tượng OracleCommand để thực thi câu lệnh SQL CREATE USER
                    using (OracleCommand command = new OracleCommand(createSql, connection))
                    {
                        // Thực thi câu lệnh SQL CREATE USER
                        command.ExecuteNonQuery();
                    }

                    using (OracleCommand grantCommand = new OracleCommand(grantconn, connection))
                    {
                        // Thực thi câu lệnh SQL CREATE USER
                        grantCommand.ExecuteNonQuery();
                    }
                }

                // Hiển thị thông báo khi tạo người dùng thành công
                MessageBox.Show("Người dùng đã được tạo thành công!");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi tạo người dùng: " + ex.Message);
            }
        }


        private void changePassword(string username, string newPassword)
        {
            // Hiển thị hộp thoại xác nhận từ người dùng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thay đổi mật khẩu của người dùng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra xem người dùng đã xác nhận thay đổi mật khẩu hay không
            if (result == DialogResult.Yes)
            {
                // Tạo câu lệnh SQL ALTER USER để thay đổi mật khẩu
                string alterSql = $"ALTER USER {username} IDENTIFIED BY {newPassword}";

                try
                {
                    // Mở kết nối đến cơ sở dữ liệu
                    using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                    {
                        connection.Open();

                        // Tạo đối tượng OracleCommand để thực thi câu lệnh SQL
                        using (OracleCommand command = new OracleCommand(alterSql, connection))
                        {
                            // Thực thi câu lệnh SQL
                            command.ExecuteNonQuery();
                        }
                    }

                    // Hiển thị thông báo khi sửa đổi mật khẩu thành công
                    MessageBox.Show("Mật khẩu đã được thay đổi thành công!");
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show("Lỗi khi thay đổi mật khẩu: " + ex.Message);
                }
            }
        }


        DataSet getAllUser()
        {
            DataSet data = new DataSet();
            String query = "select * from DBA_USERS";
            using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
            {
                connection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }
        private void LoadUserData()
        {

            // Call getAllUser to retrieve data
            DataSet userData = getAllUser();

            // Check if there is at least one table in the DataSet
            if (userData.Tables.Count > 0)
            {
                // Set the DataGridView DataSource to the first table in the DataSet
                dataGridView1.DataSource = userData.Tables[0];
            }
        }

        private void btnUserViewUser_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string username = txtUserUsernameFind.Text.Trim();

            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            if (!string.IsNullOrEmpty(username))
            {
                // Gọi phương thức để lấy dữ liệu từ cơ sở dữ liệu và hiển thị trên DataGridView
                LoadUserData(username);
            }
            else
            {
                LoadUserData();
            }
        }
        private void deleteUser(string username)
        {
            // Tạo câu lệnh SQL DELETE để xóa người dùng
            string alterSessionSql = "ALTER SESSION SET \"_ORACLE_SCRIPT\" = true";
            string deleteSql = $"DROP USER {username}";

            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    connection.Open();

                    // Thực hiện câu lệnh ALTER SESSION trước khi tạo người dùng
                    using (OracleCommand alterSessionCommand = new OracleCommand(alterSessionSql, connection))
                    {
                        alterSessionCommand.ExecuteNonQuery();
                    }

                    // Tạo đối tượng OracleCommand để thực thi câu lệnh SQL
                    using (OracleCommand command = new OracleCommand(deleteSql, connection))
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Ném ngoại lệ nếu xảy ra lỗi
                throw new Exception("Lỗi khi xoá người dùng: " + ex.Message);
            }
        }
        private void LoadUserPermissionsTable()
        {
            try
            {
                // Tạo câu lệnh SQL để lấy thông tin quyền của người dùng
                string sqlQuery = "SELECT * FROM DBA_TAB_PRIVS WHERE PRIVILEGE IN ('SELECT', 'INSERT', 'UPDATE', 'DELETE')";

                // Gọi phương thức để thực hiện truy vấn
                DataSet permissionsData = GetDataFromDatabase(sqlQuery);

                // Hiển thị dữ liệu trên DataGridView
                dataGridView2.DataSource = permissionsData.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadUserPermissionsColumn()
        {
            try
            {

                // Tạo câu lệnh SQL để lấy thông tin quyền của người dùng
                string sqlQuery = "SELECT * FROM DBA_COL_PRIVS";

                // Gọi phương thức để thực hiện truy vấn
                DataSet permissionsData = GetDataFromDatabase(sqlQuery);

                // Hiển thị dữ liệu trên DataGridView
                dataGridView2.DataSource = permissionsData.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadUserData(string username)
        {
            // Format font column headers
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            // Format font row
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            }

            // Tạo câu truy vấn dựa trên username
            string query = "SELECT * FROM DBA_USERS WHERE USERNAME LIKE '" + username + "%'";

            // Gọi phương thức để thực hiện truy vấn
            DataSet userData = GetDataFromDatabase(query);

            // Hiển thị dữ liệu trên DataGridView
            dataGridView1.DataSource = userData.Tables[0];

        }

        private DataSet GetDataFromDatabase(string query)
        {
            DataSet data = new DataSet();
            using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
            {
                connection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        private void txtUserUsernamePrivs_TextChanged(object sender, EventArgs e)
        {
            // Lấy tên người dùng từ TextBox txtUserUsernamePrivs
            string usernamePrivs = txtUserUsernamePrivs.Text.Trim();

            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            if (!string.IsNullOrEmpty(usernamePrivs))
            {
                if (checkBoxTable.Checked)
                {
                    // Gọi phương thức để tải quyền trên bảng
                    ViewUserPrivilegesTable(usernamePrivs);
                }
                else
                {
                    // Gọi phương thức để tải quyền trên cột
                    ViewUserPrivilegesColumn(usernamePrivs);
                }

            }
            else
            {
                // Kiểm tra xem checkBoxTable có được chọn không
                if (checkBoxTable.Checked)
                {
                    // Gọi phương thức để tải quyền trên bảng
                    LoadUserPermissionsTable();
                }
                else
                {
                    // Gọi phương thức để tải quyền trên cột
                    LoadUserPermissionsColumn();
                }
            }
        }
        private void txtUserUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtUserPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void user_Load(object sender, EventArgs e)
        {

            // Format font column headers dataGridView_Role_list
            this.dataGridView_Role_list.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            // Format font row dataGridView_Role_list
            foreach (DataGridViewRow row in dataGridView_Role_list.Rows)
            {
                row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            }

            // Format font column headers dataGridView1
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            // Format font row dataGridView1
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            }

            // Format font column headers dataGridView2
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            // Format font row dataGridView2
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            }

            LoadUserData();
            LoadUserPermissionsTable();
            FindTablesByPartialName(comboBoxTablename.Text.Trim());
            checkBoxTable.Checked = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUserUsernameFind_TextChanged(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string username = txtUserUsernameFind.Text.Trim();

            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            if (!string.IsNullOrEmpty(username))
            {
                // Gọi phương thức để lấy dữ liệu từ cơ sở dữ liệu và hiển thị trên DataGridView
                LoadUserData(username);
            }
            else
            {
                LoadUserData();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxDelete_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxInsert_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private string GetSelectedPrivilege()
        {
            if (radioButtonInsert.Checked)
            {
                return "insert";
            }
            else if (radioButtonDelete.Checked)
            {
                return "delete";
            }
            else if (radioButtonSelect.Checked)
            {
                return "select";
            }
            else if (radioButtonUpdate.Checked)
            {
                return "update";
            }
            else
            {
                return null;
            }
        }
        private bool CheckUserExists(string username)
        {
            try
            {
                // Kết nối đến cơ sở dữ liệu Oracle
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu lệnh SQL để kiểm tra sự tồn tại của người dùng
                    string sqlQuery = "SELECT COUNT(*) FROM DBA_USERS WHERE USERNAME = :username";

                    // Tạo một đối tượng Command
                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        // Thêm tham số vào command
                        cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;

                        // Thực thi truy vấn và lấy kết quả
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Trả về true nếu có ít nhất một người dùng có tên tương tự, ngược lại trả về false
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Error checking user existence: " + ex.Message);
                return false; // Trả về false nếu xảy ra lỗi
            }
        }

        private bool IsTableNameExists(string tableName)
        {
            // Khai báo biến để lưu trạng thái của tên bảng
            bool tableExists = false;

            try
            {
                // Tạo kết nối đến cơ sở dữ liệu Oracle
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo command để kiểm tra xem tên bảng có tồn tại không
                    using (OracleCommand cmd = new OracleCommand($"SELECT COUNT(*) FROM USER_TABLES WHERE TABLE_NAME = :tableName", connection))
                    {
                        // Thêm tham số vào command
                        cmd.Parameters.Add("tableName", OracleDbType.Varchar2).Value = tableName;

                        // Thực thi truy vấn và lấy kết quả
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Nếu tồn tại ít nhất một bảng với tên tableName, đặt tableExists thành true
                        if (count > 0)
                        {
                            tableExists = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Error checking table existence: " + ex.Message);
            }

            return tableExists;
        }
        private string GetTableColumns(string tableName)
        {
            // Chuỗi để lưu danh sách các cột
            string columnList = "";

            try
            {
                // Kết nối đến cơ sở dữ liệu Oracle
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo một đối tượng Command để thực thi truy vấn
                    using (OracleCommand cmd = new OracleCommand($"SELECT column_name FROM all_tab_columns WHERE table_name = '{tableName}'", connection))
                    {
                        // Thực thi truy vấn và lấy ra kết quả
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            // Duyệt qua tất cả các dòng kết quả
                            while (reader.Read())
                            {
                                // Lấy tên cột và thêm vào chuỗi danh sách cột
                                columnList += reader["column_name"].ToString() + ", ";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Error fetching table columns: " + ex.Message);
            }

            // Loại bỏ dấu phẩy cuối cùng nếu có
            if (!string.IsNullOrEmpty(columnList))
            {
                columnList = columnList.Remove(columnList.Length - 2);
            }
            return columnList;
        }
        private void btnUserGrant_Click(object sender, EventArgs e)
        {
            // Lấy các thông tin từ giao diện người dùng
            string userName = txtUserUsernameGrant.Text.Trim();
            string tableName = comboBoxTablename.Text.Trim();
            string privilegeType = GetSelectedPrivilege();
            string columnName = f_selectcols_user.colsName;
            // Kiểm tra xem người dùng đã nhập tên cột hay chưa
            if (string.IsNullOrEmpty(columnName) || columnName == GetTableColumns(tableName))
            {
                columnName = null; // Gán null cho columnName nếu không có giá trị được nhập
            }
            string withGrantOption = checkBoxWGO.Checked ? "yes" : "no"; // Nếu được chọn, giá trị là 'yes'; ngược lại là 'no'
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Hãy nhập tên người dùng.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức để người dùng có cơ hội chọn quyền
            }
            if (!CheckUserExists(userName))
            {
                MessageBox.Show("Người dùng không tồn tại.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức nếu người dùng không tồn tại
            }
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Hãy chọn bảng muốn gán quyền cho người dùng.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức để người dùng có cơ hội chọn quyền
            }
            if (!IsTableNameExists(tableName))
            {
                MessageBox.Show("Tên bảng không tồn tại.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức để người dùng có cơ hội chọn tên bảng khác
            }
            if (string.IsNullOrEmpty(privilegeType))
            {
                MessageBox.Show("Hãy chọn quyền muốn gán cho người dùng.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức để người dùng có cơ hội chọn quyền
            }
            try
            {
                // Kết nối đến cơ sở dữ liệu Oracle
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo một đối tượng Command để gọi procedure
                    using (OracleCommand cmd = new OracleCommand("sp_grant_privilege", connection))
                    {
                        // Xác định kiểu command là StoredProcedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add("user_role_name", OracleDbType.Varchar2).Value = userName;
                        cmd.Parameters.Add("table_name", OracleDbType.Varchar2).Value = tableName;
                        cmd.Parameters.Add("privilege_type", OracleDbType.Varchar2).Value = privilegeType;
                        cmd.Parameters.Add("column_name", OracleDbType.Varchar2).Value = columnName;
                        cmd.Parameters.Add("with_grant_option", OracleDbType.Varchar2).Value = withGrantOption;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Hiển thị thông báo
                        MessageBox.Show("Privilege granted successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Error granting privilege: " + ex.Message);
            }
            if (privilegeType == "select" && !string.IsNullOrEmpty(columnName))
            {
                checkBoxTable.Checked = true;
                ViewUserPrivilegesTable(userName);
            }  
            else
            {
                if (!string.IsNullOrEmpty(columnName))
                {
                    checkBoxColumn.Checked = true;
                    ViewUserPrivilegesColumn(userName);
                }
                else
                {
                    checkBoxTable.Checked = true;
                    ViewUserPrivilegesTable(userName);
                }
            }
        }
        private void btnUserDeleteUser_Click(object sender, EventArgs e)
        {
            // Lấy tên người dùng từ TextBox txtUserUsername
            string username = txtUserUsername.Text.Trim();

            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            if (!string.IsNullOrEmpty(username))
            {
                // Kiểm tra xem người dùng có tồn tại hay không
                if (userExists(username))
                {
                    // Hiển thị hộp thoại xác nhận từ người dùng
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xoá người dùng '{username}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            deleteUser(username);
                            LoadUserData(username);
                            MessageBox.Show($"Người dùng '{username}' đã được xoá thành công!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xoá người dùng: " + ex.Message);
                        }
                    }
                }
                else
                {
                    // Hiển thị thông báo nếu người dùng không tồn tại
                    MessageBox.Show($"Người dùng '{username}' không tồn tại trong hệ thống.");
                }
            }
            else
            {
                // Hiển thị thông báo yêu cầu nhập tên người dùng nếu trống
                MessageBox.Show("Vui lòng nhập tên người dùng để xoá.");
            }
        }
        private void btnUserCreateUser_Click(object sender, EventArgs e)
        {
            string username = txtUserUsername.Text.Trim();
            string password = txtUserPassword.Text.Trim();
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (userExists(username))
                {
                    changePassword(username, password);
                }
                else
                {
                    createUser(username, password);
                    LoadUserData(username);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên người dùng và mật khẩu.");
            }
        }

        
        private void btnUserRevoke_Click(object sender, EventArgs e)
        {
            // Lấy các thông tin từ giao diện người dùng
            string userName = txtUserUsernameGrant.Text.Trim();
            string tableName = comboBoxTablename.Text.Trim();
            string privilegeType = GetSelectedPrivilege();
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Hãy nhập tên người dùng.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức để người dùng có cơ hội chọn quyền
            }
            if (!CheckUserExists(userName))
            {
                MessageBox.Show("Người dùng không tồn tại.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức nếu người dùng không tồn tại
            }
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Hãy chọn bảng muốn thu hồi quyền của người dùng.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức để người dùng có cơ hội chọn quyền
            }
            if (string.IsNullOrEmpty(privilegeType))
            {
                MessageBox.Show("Hãy chọn quyền muốn thu hồi của người dùng.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức để người dùng có cơ hội chọn quyền
            }
            try
            {
                // Kết nối đến cơ sở dữ liệu Oracle
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo một đối tượng Command để gọi procedure
                    using (OracleCommand cmd = new OracleCommand("sp_revoke_privilege", connection))
                    {
                        // Xác định kiểu command là StoredProcedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add("user_role_name", OracleDbType.Varchar2).Value = userName;
                        cmd.Parameters.Add("table_name", OracleDbType.Varchar2).Value = tableName;
                        cmd.Parameters.Add("privilege_type", OracleDbType.Varchar2).Value = privilegeType;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Hiển thị thông báo
                        MessageBox.Show("Privilege revoked successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Error revoking privilege: " + ex.Message);
            }

            if (checkBoxTable.Checked == true)
            {
                ViewUserPrivilegesTable(userName);
            }
            else
            {
                ViewUserPrivilegesColumn(userName);
            }
        }

        private void ViewUserPrivilegesTable(string username)
        {
            try
            {
                // Thực hiện truy vấn để lấy tất cả các quyền của người dùng từ cơ sở dữ liệu
                string query = $"SELECT * FROM DBA_TAB_PRIVS WHERE GRANTEE = '{username}'";

                // Lấy dữ liệu từ cơ sở dữ liệu bằng phương thức GetDataFromDatabase
                DataSet userData = GetDataFromDatabase(query);

                // Hiển thị dữ liệu trên DataGridView
                dataGridView2.DataSource = userData.Tables[0];
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi tìm quyền của người dùng: " + ex.Message);
            }
        }
        private void ViewUserPrivilegesColumn(string username)
        {
            try
            {
                // Thực hiện truy vấn để lấy tất cả các quyền của người dùng từ cơ sở dữ liệu
                string query = $"SELECT * FROM DBA_COL_PRIVS WHERE GRANTEE = '{username}'";

                // Lấy dữ liệu từ cơ sở dữ liệu bằng phương thức GetDataFromDatabase
                DataSet userData = GetDataFromDatabase(query);

                // Hiển thị dữ liệu trên DataGridView
                dataGridView2.DataSource = userData.Tables[0];
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi tìm quyền của người dùng: " + ex.Message);
            }
        }
        private void btnUserViewUserPrivs_Click(object sender, EventArgs e)
        {
            // Lấy tên người dùng từ TextBox txtUserUsernamePrivs
            string usernamePrivs = txtUserUsernamePrivs.Text.Trim();

            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            if (!string.IsNullOrEmpty(usernamePrivs))
            {
                if (checkBoxTable.Checked)
                {
                    // Gọi phương thức để tải quyền trên bảng
                    ViewUserPrivilegesTable(usernamePrivs);
                }
                else
                {
                    // Gọi phương thức để tải quyền trên cột
                    ViewUserPrivilegesColumn(usernamePrivs);
                }

            }
            else
            {
                // Kiểm tra xem checkBoxTable có được chọn không
                if (checkBoxTable.Checked)
                {
                    // Gọi phương thức để tải quyền trên bảng
                    LoadUserPermissionsTable();
                }
                else
                {
                    // Gọi phương thức để tải quyền trên cột
                    LoadUserPermissionsColumn();
                }
            }
        }





        private void checkBoxSelect_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void checkedListBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBoxUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }


        //---------------------------------------hiển thị tất cả Role---------------------------------------

        DataSet getAllRole()
        {
            DataSet data = new DataSet();
            String query = "SELECT * FROM DBA_ROLES";
            using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
            {
                connection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        private void LoadRoleData()
        {
            // Call getAllUser to retrieve data
            DataSet RoleData = getAllRole();

            // Check if there is at least one table in the DataSet
            if (RoleData.Tables.Count > 0)
            {
                // Set the DataGridView DataSource to the first table in the DataSet
                this.dataGridView_Role_list.DataSource = RoleData.Tables[0];
            }
        }

        //---------------------------------------Tìm kiếm Role---------------------------------------


        private void role_Load(object sender, EventArgs e)
        {
            LoadRoleData();
        }


        private void Xem_ds_role_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string rolename = TxtBox_TimKiemRole.Text.Trim();
            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            if (!string.IsNullOrEmpty(rolename) && rolename != "# Nhập tên role cần tìm.")
            {
                // Gọi phương thức để lấy dữ liệu từ cơ sở dữ liệu và hiển thị trên DataGridView
                LoadRoleData(rolename);
            }
            else
            {
                // Hiển thị thông báo nếu không có tên người dùng được nhập vào
                LoadRoleData();
            }
        }

        private void setTxtBoxSearch()
        {
            TxtBox_TimKiemRole.Text = "# Nhập tên role cần tìm.";
            TxtBox_TimKiemRole.ForeColor = Color.Gray;
        }

        private void LoadRoleData(string rolename)
        {
            // Chuyển tên người dùng sang chữ in hoa
            rolename = rolename.ToUpper();
            // Tạo câu truy vấn dựa trên rolename
            string query = "SELECT * FROM DBA_ROLES WHERE ROLE LIKE '%" + rolename + "%'";

            // Gọi phương thức để thực hiện truy vấn
            DataSet roleData = GetDataFromDatabase(query);

            // Hiển thị dữ liệu trên DataGridView
            dataGridView_Role_list.DataSource = roleData.Tables[0];
        }


        private void TxtBox_TimKiemRole_click(object sender, EventArgs e)
        {
            if (TxtBox_TimKiemRole.ForeColor != Color.Black)
            {
                this.TxtBox_TimKiemRole.Text = "";
                this.TxtBox_TimKiemRole.ForeColor = Color.Black;
            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void role_duoc_chon_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void role_duoc_chon_textBox_Click(object sender, EventArgs e)
        {
            if (this.role_duoc_chon_textBox.ForeColor != Color.Black)
            {
                this.role_duoc_chon_textBox.Text = "";
                this.role_duoc_chon_textBox.ForeColor = Color.Black;
            }
        }

        private void setTextBoxRoleSelected()
        {
            this.role_duoc_chon_textBox.Text = "# Tên role được chọn.";
            this.role_duoc_chon_textBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
        }

        private void TxtBox_TimKiemRole_Leave(object sender, EventArgs e)
        {
            if (this.TxtBox_TimKiemRole.Text == "")
            {
                this.TxtBox_TimKiemRole.Text = "# Nhập tên role cần tìm.";
                this.TxtBox_TimKiemRole.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void role_duoc_chon_textBox_Leave(object sender, EventArgs e)
        {
            if (this.role_duoc_chon_textBox.Text == "")
            {
                this.role_duoc_chon_textBox.Text = "# Tên role được chọn.";
                this.role_duoc_chon_textBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }
        //-------------------------------Tương tác giữa của role được chọn và grid_view--------------------------------
        private void dataGridView_Role_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridView_Role_list.Rows[index];
            role_duoc_chon_textBox.ForeColor = Color.Black;
            role_duoc_chon_textBox.Text = selectedRow.Cells[0].Value.ToString();
        }

        //-------------------------------- Xóa Role --------------------------------

        private void deleteRole(string rolename)
        {

            //Tạo lệnh Alter sesion
            string alterSessionSql = "ALTER SESSION SET \"_ORACLE_SCRIPT\" = true";
            // Tạo câu lệnh SQL DELETE để xóa người dùng
            string deleteSql = $"DROP ROLE {rolename}";

            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    connection.Open();

                    using (OracleCommand alterSessionCommand = new OracleCommand(alterSessionSql, connection))
                    {
                        alterSessionCommand.ExecuteNonQuery();
                    }
                    // Tạo đối tượng OracleCommand để thực thi câu lệnh SQL
                    using (OracleCommand command = new OracleCommand(deleteSql, connection))
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Role " + rolename + " đã được xoá thành công!");
                }
            }
            catch (Exception ex)
            {
                // Ném ngoại lệ nếu xảy ra lỗi
                throw new Exception("Lỗi khi xoá role: " + ex.Message);
            }
        }

        private void buttom_xoa_role_Click(object sender, EventArgs e)
        {
            string rolename = role_duoc_chon_textBox.Text.Trim();

            if (rolename == "# Tên Role đang được chọn." || rolename == "")
            {
                MessageBox.Show("Vui lòng chọn role cần xóa!");
            }
            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            else
            {
                DialogResult ask = MessageBox.Show("Bạn có chắc chắn muốn xoá role " + rolename + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Gọi phương thức xóa role
                if (ask == DialogResult.Yes)
                {
                    deleteRole(rolename);
                    role_duoc_chon_textBox.Text = "";
                    role_duoc_chon_textBox_Leave(sender, e);
                    Xem_ds_role_Click(sender, e);
                }
            }
        }

        private void TxtBox_TimKiemRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Xem_ds_role_Click(sender, e);
            }
        }



        //-------------------------------- Tạo Role --------------------------------
        private void createRole(string rolename)
        {
            // Tạo câu lệnh SQL CREATE ROLE
            string alterSessionSql = "ALTER SESSION SET \"_ORACLE_SCRIPT\" = true";
            string createSql = $"CREATE ROLE {rolename}";

            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    connection.Open();


                    using (OracleCommand alterSessionCommand = new OracleCommand(alterSessionSql, connection))
                    {
                        alterSessionCommand.ExecuteNonQuery();
                    }

                    // Tạo đối tượng OracleCommand để thực thi câu lệnh SQL
                    using (OracleCommand command = new OracleCommand(createSql, connection))
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Role " + rolename + " đã được tạo thành công!");
                }
            }
            catch (Exception ex)
            {
                // Ném ngoại lệ nếu xảy ra lỗi
                throw new Exception("Lỗi khi tạo role: " + ex.Message);
            }
        }

        private void textBox_tao_role_Click(object sender, EventArgs e)
        {
            if (this.textBox_tao_role.ForeColor != Color.Black)
            {
                this.textBox_tao_role.Text = "";
                this.textBox_tao_role.ForeColor = Color.Black;
            }
        }

        private void textBox_tao_role_Leave(object sender, EventArgs e)
        {
            if (this.textBox_tao_role.Text == "")
            {
                this.textBox_tao_role.Text = "# Nhập tên role muốn tạo.";
                this.textBox_tao_role.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void button_taorole_Click(object sender, EventArgs e)
        {
            if (textBox_tao_role.Text == "# Nhập tên role muốn tạo." || textBox_tao_role.Text == "")
            {
                MessageBox.Show("Vui lòng nhập role cần tạo!");
            }
            else
            {
                try
                {
                    createRole(textBox_tao_role.Text);

                    role_duoc_chon_textBox.Text = textBox_tao_role.Text.ToUpper();
                    textBox_tao_role.Text = "";
                    textBox_tao_role_Leave(sender, e);

                    // load data all role 
                    setTxtBoxSearch();
                    LoadRoleData();

                    // call function button_xemchitien_chick
                    button_Xemchitiet_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo role: " + ex.Message);
                }
            }
        }

        // Get roleName from user form to f_xem_chi_tiet form
        public static string roleName = "";

        // show form f_xem_chi_tiet
        private void button_Xemchitiet_Click(object sender, EventArgs e)
        {
            roleName = role_duoc_chon_textBox.Text.Trim();

            if (roleName == "" || roleName == "# Tên role được chọn.")
            {
                MessageBox.Show("Vui lòng chọn role!");
            }
            else
            {
                f_xem_chi_tiet f = new f_xem_chi_tiet();
                f.Show();
            }
        }

        private void textBox_tao_role_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_taorole_Click(sender, e);
            }
        }

        private void FindTablesByPartialName(string partialTableName)
        {
            try
            {
                // Kết nối đến cơ sở dữ liệu Oracle
                using (OracleConnection connection = new OracleConnection(ConnectionStr.connectionStr))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu lệnh SQL để lấy tên các bảng phù hợp với chuỗi nhập vào hoặc tất cả các bảng nếu không có chuỗi
                    string sqlQuery = string.IsNullOrEmpty(partialTableName) ?
                                        "SELECT TABLE_NAME FROM USER_TABLES" :
                                        "SELECT TABLE_NAME FROM USER_TABLES WHERE TABLE_NAME LIKE :inputText || '%'";

                    // Tạo một đối tượng Command
                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        // Thêm tham số đầu vào cho câu lệnh SQL nếu có chuỗi nhập vào
                        if (!string.IsNullOrEmpty(partialTableName))
                        {
                            cmd.Parameters.Add(":inputText", OracleDbType.Varchar2).Value = partialTableName;
                        }

                        // Sử dụng OracleDataReader để đọc dữ liệu từ truy vấn
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            // Xóa các mục hiện có trong comboBoxTablename
                            comboBoxTablename.Items.Clear();

                            // Đọc mỗi dòng từ truy vấn và thêm tên của bảng vào comboBoxTablename
                            while (reader.Read())
                            {
                                comboBoxTablename.Items.Add(reader["TABLE_NAME"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void comboBoxTablename_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxTablename_TextChanged(object sender, EventArgs e)
        {
            tableName = comboBoxTablename.Text;
        }
        private void comboBoxTablename_Leave(object sender, EventArgs e)
        {
           
        }
        private void comboBoxTablename_KeyUp(object sender, KeyEventArgs e)
        {
            // Lọc ra các phím cần thiết (ví dụ: phím Enter, Backspace) và gọi hàm tìm kiếm
            if (e.KeyCode != Keys.Enter)
            {
                // Lưu vị trí con trỏ hiện tại
                int currentSelectionStart = comboBoxTablename.SelectionStart;

                // Gọi hàm tìm kiếm
                FindTablesByPartialName(comboBoxTablename.Text.Trim());

                // Đặt vị trí con trỏ vào cuối chuỗi
                comboBoxTablename.SelectionStart = currentSelectionStart;
            }
        }


        private void comboBoxAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUserUsernameGrant_TextChanged(object sender, EventArgs e)
        {

        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonInsert_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonSelect_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu radio button "select" được chọn
            if (radioButtonSelect.Checked)
            {
                buttonSelectCols.Visible = true; // Kích hoạt textBoxAttribute
            }
            else
            {
                buttonSelectCols.Visible = false; // Vô hiệu hóa textBoxAttribute
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn vào một ô hợp lệ chưa
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị của ô trong cột "username" của hàng được chọn
                string username = dataGridView1.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();

                // Điền giá trị username vào txtUserUsernameGrant
                txtUserUsernameGrant.Text = username;
                txtUserUsername.Text = username;
                txtUserUsernamePrivs.Text = username;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn vào một ô hợp lệ chưa
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị của ô trong các cột cần thiết  
                string username = dataGridView2.Rows[e.RowIndex].Cells["GRANTEE"].Value.ToString();
                string tablename = dataGridView2.Rows[e.RowIndex].Cells["TABLE_NAME"].Value.ToString();
                string privilege = dataGridView2.Rows[e.RowIndex].Cells["PRIVILEGE"].Value.ToString();
                // Điền giá trị vào các ô cần thiết
                txtUserUsernameGrant.Text = username;
                comboBoxTablename.Text = tablename;
                if (privilege == "SELECT")
                {
                    radioButtonSelect.Checked = true;
                }
                else if (privilege == "INSERT")
                {
                    radioButtonInsert.Checked = true;
                }
                else if (privilege == "UPDATE")
                {
                    radioButtonUpdate.Checked = true;
                }
                else if (privilege == "DELETE")
                {
                    radioButtonDelete.Checked = true;
                }
                else
                {
                    radioButtonSelect.Checked = false;
                    radioButtonInsert.Checked = false;
                    radioButtonUpdate.Checked = false;
                    radioButtonDelete.Checked = false;
                }
            }
        }

        private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu radio button "update" được chọn
            if (radioButtonUpdate.Checked)
            {
                buttonSelectCols.Visible = true; 
            }
            else
            {
                buttonSelectCols.Visible = false; 
            }
        }

        private void checkBoxWGO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAttribute_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxTable_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem checkBoxTable có được chọn không
            if (checkBoxTable.Checked)
            {
                // Nếu checkBoxTable được chọn, tắt checkBoxColumn
                checkBoxColumn.Checked = false;
            }
            else
            {
                // Nếu checkBoxTable được chọn, tắt checkBoxColumn
                checkBoxColumn.Checked = true;
            }
            // Lấy tên người dùng từ TextBox txtUserUsernamePrivs
            string usernamePrivs = txtUserUsernamePrivs.Text.Trim();

            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            if (!string.IsNullOrEmpty(usernamePrivs))
            {
                if (checkBoxTable.Checked)
                {
                    // Gọi phương thức để tải quyền trên bảng
                    ViewUserPrivilegesTable(usernamePrivs);
                }
                else
                {
                    // Gọi phương thức để tải quyền trên cột
                    ViewUserPrivilegesColumn(usernamePrivs);
                }

            }
            else
            {
                // Kiểm tra xem checkBoxTable có được chọn không
                if (checkBoxTable.Checked)
                {
                    // Gọi phương thức để tải quyền trên bảng
                    LoadUserPermissionsTable();
                }
                else
                {
                    // Gọi phương thức để tải quyền trên cột
                    LoadUserPermissionsColumn();
                }
            }
        }

        private void checkBoxColumn_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem checkBoxColumn có được chọn không
            if (checkBoxColumn.Checked)
            {
                // Nếu checkBoxColumn được chọn, tắt checkBoxTable
                checkBoxTable.Checked = false;
            }
            else
            {
                checkBoxTable.Checked = true;
            }
            // Lấy tên người dùng từ TextBox txtUserUsernamePrivs
            string usernamePrivs = txtUserUsernamePrivs.Text.Trim();

            // Kiểm tra xem người dùng đã nhập tên người dùng hay chưa
            if (!string.IsNullOrEmpty(usernamePrivs))
            {
                if (checkBoxTable.Checked)
                {
                    // Gọi phương thức để tải quyền trên bảng
                    ViewUserPrivilegesTable(usernamePrivs);
                }
                else
                {
                    // Gọi phương thức để tải quyền trên cột
                    ViewUserPrivilegesColumn(usernamePrivs);
                }

            }
            else
            {
                // Kiểm tra xem checkBoxTable có được chọn không
                if (checkBoxTable.Checked)
                {
                    // Gọi phương thức để tải quyền trên bảng
                    LoadUserPermissionsTable();
                }
                else
                {
                    // Gọi phương thức để tải quyền trên cột
                    LoadUserPermissionsColumn();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_tao_role_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void role_duoc_chon_textBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserUsernameFind.Text = "";
            txtUserUsernamePrivs.Text = "";
            txtUserUsername.Text = "";
            txtUserPassword.Text = "";
            comboBoxTablename.Text = "";
            txtUserUsernameGrant.Text = "";
            setTxtBoxSearch();
            setTextBoxRoleSelected();
            LoadRoleData();
        }

        private void buttonSelectCols_Click(object sender, EventArgs e)
        {
            f_selectcols_user f = new f_selectcols_user();
            f.Show();
        }
    }
}
