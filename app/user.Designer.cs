namespace ATBM
{
    partial class user
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUserCreateUser = new System.Windows.Forms.Button();
            this.btnUserDeleteUser = new System.Windows.Forms.Button();
            this.btnUserGrant = new System.Windows.Forms.Button();
            this.btnUserRevoke = new System.Windows.Forms.Button();
            this.txtUserUsernameFind = new System.Windows.Forms.TextBox();
            this.txtUserUsername = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserUsernameGrant = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSelectCols = new System.Windows.Forms.Button();
            this.radioButtonUpdate = new System.Windows.Forms.RadioButton();
            this.radioButtonSelect = new System.Windows.Forms.RadioButton();
            this.radioButtonDelete = new System.Windows.Forms.RadioButton();
            this.radioButtonInsert = new System.Windows.Forms.RadioButton();
            this.comboBoxTablename = new System.Windows.Forms.ComboBox();
            this.checkBoxWGO = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxColumn = new System.Windows.Forms.CheckBox();
            this.checkBoxTable = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserUsernamePrivs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox_tao_role = new System.Windows.Forms.TextBox();
            this.label_tao_role = new System.Windows.Forms.Label();
            this.buttom_xoa_role = new System.Windows.Forms.Button();
            this.button_taorole = new System.Windows.Forms.Button();
            this.button_Xemchitiet = new System.Windows.Forms.Button();
            this.role_duoc_chon_textBox = new System.Windows.Forms.TextBox();
            this.lable_select_role = new System.Windows.Forms.Label();
            this.Xem_ds_role = new System.Windows.Forms.Button();
            this.TxtBox_TimKiemRole = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView_Role_list = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Role_list)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(238, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH NGƯỜI DÙNG";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(94, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tìm kiếm";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Username";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mật khẩu";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(173, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(449, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "TẠO/ CẬP NHẬT/ XÓA NGƯỜI DÙNG";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Username";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tablename";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnUserCreateUser
            // 
            this.btnUserCreateUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUserCreateUser.BackColor = System.Drawing.Color.Teal;
            this.btnUserCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserCreateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserCreateUser.Location = new System.Drawing.Point(552, 82);
            this.btnUserCreateUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserCreateUser.Name = "btnUserCreateUser";
            this.btnUserCreateUser.Size = new System.Drawing.Size(165, 32);
            this.btnUserCreateUser.TabIndex = 11;
            this.btnUserCreateUser.Text = "Tạo/Đổi";
            this.btnUserCreateUser.UseVisualStyleBackColor = false;
            this.btnUserCreateUser.Click += new System.EventHandler(this.btnUserCreateUser_Click);
            // 
            // btnUserDeleteUser
            // 
            this.btnUserDeleteUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUserDeleteUser.BackColor = System.Drawing.Color.Brown;
            this.btnUserDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserDeleteUser.Location = new System.Drawing.Point(552, 148);
            this.btnUserDeleteUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserDeleteUser.Name = "btnUserDeleteUser";
            this.btnUserDeleteUser.Size = new System.Drawing.Size(165, 33);
            this.btnUserDeleteUser.TabIndex = 12;
            this.btnUserDeleteUser.Text = "Xóa";
            this.btnUserDeleteUser.UseVisualStyleBackColor = false;
            this.btnUserDeleteUser.Click += new System.EventHandler(this.btnUserDeleteUser_Click);
            // 
            // btnUserGrant
            // 
            this.btnUserGrant.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUserGrant.BackColor = System.Drawing.Color.Teal;
            this.btnUserGrant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserGrant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserGrant.Location = new System.Drawing.Point(546, 47);
            this.btnUserGrant.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserGrant.Name = "btnUserGrant";
            this.btnUserGrant.Size = new System.Drawing.Size(183, 34);
            this.btnUserGrant.TabIndex = 13;
            this.btnUserGrant.Text = "Grant";
            this.btnUserGrant.UseVisualStyleBackColor = false;
            this.btnUserGrant.Click += new System.EventHandler(this.btnUserGrant_Click);
            // 
            // btnUserRevoke
            // 
            this.btnUserRevoke.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUserRevoke.BackColor = System.Drawing.Color.Brown;
            this.btnUserRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserRevoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserRevoke.Location = new System.Drawing.Point(546, 94);
            this.btnUserRevoke.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserRevoke.Name = "btnUserRevoke";
            this.btnUserRevoke.Size = new System.Drawing.Size(183, 34);
            this.btnUserRevoke.TabIndex = 14;
            this.btnUserRevoke.Text = "Revoke";
            this.btnUserRevoke.UseVisualStyleBackColor = false;
            this.btnUserRevoke.Click += new System.EventHandler(this.btnUserRevoke_Click);
            // 
            // txtUserUsernameFind
            // 
            this.txtUserUsernameFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserUsernameFind.Location = new System.Drawing.Point(204, 50);
            this.txtUserUsernameFind.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserUsernameFind.Name = "txtUserUsernameFind";
            this.txtUserUsernameFind.Size = new System.Drawing.Size(413, 30);
            this.txtUserUsernameFind.TabIndex = 15;
            this.txtUserUsernameFind.TextChanged += new System.EventHandler(this.txtUserUsernameFind_TextChanged);
            // 
            // txtUserUsername
            // 
            this.txtUserUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserUsername.Location = new System.Drawing.Point(179, 86);
            this.txtUserUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserUsername.Name = "txtUserUsername";
            this.txtUserUsername.Size = new System.Drawing.Size(326, 30);
            this.txtUserUsername.TabIndex = 17;
            this.txtUserUsername.TextChanged += new System.EventHandler(this.txtUserUsername_TextChanged);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPassword.Location = new System.Drawing.Point(179, 150);
            this.txtUserPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(326, 30);
            this.txtUserPassword.TabIndex = 18;
            this.txtUserPassword.TextChanged += new System.EventHandler(this.txtUserPassword_TextChanged);
            // 
            // txtUserUsernameGrant
            // 
            this.txtUserUsernameGrant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserUsernameGrant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserUsernameGrant.Location = new System.Drawing.Point(179, 49);
            this.txtUserUsernameGrant.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserUsernameGrant.Name = "txtUserUsernameGrant";
            this.txtUserUsernameGrant.Size = new System.Drawing.Size(319, 30);
            this.txtUserUsernameGrant.TabIndex = 19;
            this.txtUserUsernameGrant.TextChanged += new System.EventHandler(this.txtUserUsernameGrant_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUserUsernameFind);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 402);
            this.panel1.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 94);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(747, 290);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtUserUsername);
            this.panel2.Controls.Add(this.txtUserPassword);
            this.panel2.Controls.Add(this.btnUserCreateUser);
            this.panel2.Controls.Add(this.btnUserDeleteUser);
            this.panel2.Location = new System.Drawing.Point(0, 406);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 228);
            this.panel2.TabIndex = 22;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonSelectCols);
            this.panel3.Controls.Add(this.radioButtonUpdate);
            this.panel3.Controls.Add(this.radioButtonSelect);
            this.panel3.Controls.Add(this.radioButtonDelete);
            this.panel3.Controls.Add(this.radioButtonInsert);
            this.panel3.Controls.Add(this.comboBoxTablename);
            this.panel3.Controls.Add(this.checkBoxWGO);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtUserUsernameGrant);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.btnUserGrant);
            this.panel3.Controls.Add(this.btnUserRevoke);
            this.panel3.Location = new System.Drawing.Point(787, 406);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(770, 228);
            this.panel3.TabIndex = 23;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // buttonSelectCols
            // 
            this.buttonSelectCols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectCols.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSelectCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectCols.Location = new System.Drawing.Point(40, 136);
            this.buttonSelectCols.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelectCols.Name = "buttonSelectCols";
            this.buttonSelectCols.Size = new System.Drawing.Size(241, 32);
            this.buttonSelectCols.TabIndex = 49;
            this.buttonSelectCols.Text = "Chọn cột select/update";
            this.buttonSelectCols.UseVisualStyleBackColor = false;
            this.buttonSelectCols.Visible = false;
            this.buttonSelectCols.Click += new System.EventHandler(this.buttonSelectCols_Click);
            // 
            // radioButtonUpdate
            // 
            this.radioButtonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonUpdate.AutoSize = true;
            this.radioButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonUpdate.Location = new System.Drawing.Point(142, 182);
            this.radioButtonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonUpdate.Name = "radioButtonUpdate";
            this.radioButtonUpdate.Size = new System.Drawing.Size(96, 29);
            this.radioButtonUpdate.TabIndex = 48;
            this.radioButtonUpdate.TabStop = true;
            this.radioButtonUpdate.Text = "Update";
            this.radioButtonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonUpdate.UseVisualStyleBackColor = true;
            this.radioButtonUpdate.CheckedChanged += new System.EventHandler(this.radioButtonUpdate_CheckedChanged);
            // 
            // radioButtonSelect
            // 
            this.radioButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSelect.AutoSize = true;
            this.radioButtonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSelect.Location = new System.Drawing.Point(40, 182);
            this.radioButtonSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSelect.Name = "radioButtonSelect";
            this.radioButtonSelect.Size = new System.Drawing.Size(88, 29);
            this.radioButtonSelect.TabIndex = 47;
            this.radioButtonSelect.TabStop = true;
            this.radioButtonSelect.Text = "Select";
            this.radioButtonSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonSelect.UseVisualStyleBackColor = true;
            this.radioButtonSelect.CheckedChanged += new System.EventHandler(this.radioButtonSelect_CheckedChanged);
            // 
            // radioButtonDelete
            // 
            this.radioButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonDelete.AutoSize = true;
            this.radioButtonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDelete.Location = new System.Drawing.Point(380, 182);
            this.radioButtonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonDelete.Name = "radioButtonDelete";
            this.radioButtonDelete.Size = new System.Drawing.Size(89, 29);
            this.radioButtonDelete.TabIndex = 46;
            this.radioButtonDelete.TabStop = true;
            this.radioButtonDelete.Text = "Delete";
            this.radioButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonDelete.UseVisualStyleBackColor = true;
            this.radioButtonDelete.CheckedChanged += new System.EventHandler(this.radioButtonDelete_CheckedChanged);
            // 
            // radioButtonInsert
            // 
            this.radioButtonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonInsert.AutoSize = true;
            this.radioButtonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonInsert.Location = new System.Drawing.Point(268, 182);
            this.radioButtonInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonInsert.Name = "radioButtonInsert";
            this.radioButtonInsert.Size = new System.Drawing.Size(81, 29);
            this.radioButtonInsert.TabIndex = 45;
            this.radioButtonInsert.TabStop = true;
            this.radioButtonInsert.Text = "Insert";
            this.radioButtonInsert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonInsert.UseVisualStyleBackColor = true;
            this.radioButtonInsert.CheckedChanged += new System.EventHandler(this.radioButtonInsert_CheckedChanged);
            // 
            // comboBoxTablename
            // 
            this.comboBoxTablename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTablename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTablename.FormattingEnabled = true;
            this.comboBoxTablename.Location = new System.Drawing.Point(179, 89);
            this.comboBoxTablename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTablename.Name = "comboBoxTablename";
            this.comboBoxTablename.Size = new System.Drawing.Size(319, 33);
            this.comboBoxTablename.TabIndex = 40;
            this.comboBoxTablename.SelectedIndexChanged += new System.EventHandler(this.comboBoxTablename_SelectedIndexChanged);
            // 
            // checkBoxWGO
            // 
            this.checkBoxWGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxWGO.AutoSize = true;
            this.checkBoxWGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWGO.Location = new System.Drawing.Point(496, 182);
            this.checkBoxWGO.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxWGO.Name = "checkBoxWGO";
            this.checkBoxWGO.Size = new System.Drawing.Size(190, 29);
            this.checkBoxWGO.TabIndex = 37;
            this.checkBoxWGO.Text = "With Grant Option";
            this.checkBoxWGO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxWGO.UseVisualStyleBackColor = true;
            this.checkBoxWGO.CheckedChanged += new System.EventHandler(this.checkBoxWGO_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Teal;
            this.label15.Location = new System.Drawing.Point(171, 13);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(460, 29);
            this.label15.TabIndex = 31;
            this.label15.Text = "CẤP/ HỦY QUYỀN CỦA NGƯỜI DÙNG";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(4, -2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1760, 690);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1752, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.checkBoxColumn);
            this.panel4.Controls.Add(this.checkBoxTable);
            this.panel4.Controls.Add(this.dataGridView2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtUserUsernamePrivs);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(787, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(770, 402);
            this.panel4.TabIndex = 24;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // checkBoxColumn
            // 
            this.checkBoxColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxColumn.AutoSize = true;
            this.checkBoxColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxColumn.Location = new System.Drawing.Point(663, 62);
            this.checkBoxColumn.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxColumn.Name = "checkBoxColumn";
            this.checkBoxColumn.Size = new System.Drawing.Size(88, 24);
            this.checkBoxColumn.TabIndex = 50;
            this.checkBoxColumn.Text = "Column";
            this.checkBoxColumn.UseVisualStyleBackColor = true;
            this.checkBoxColumn.CheckedChanged += new System.EventHandler(this.checkBoxColumn_CheckedChanged);
            // 
            // checkBoxTable
            // 
            this.checkBoxTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTable.AutoSize = true;
            this.checkBoxTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTable.Location = new System.Drawing.Point(664, 30);
            this.checkBoxTable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTable.Name = "checkBoxTable";
            this.checkBoxTable.Size = new System.Drawing.Size(72, 24);
            this.checkBoxTable.TabIndex = 49;
            this.checkBoxTable.Text = "Table";
            this.checkBoxTable.UseVisualStyleBackColor = true;
            this.checkBoxTable.CheckedChanged += new System.EventHandler(this.checkBoxTable_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(20, 94);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(731, 290);
            this.dataGridView2.TabIndex = 17;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtUserUsernamePrivs
            // 
            this.txtUserUsernamePrivs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserUsernamePrivs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserUsernamePrivs.Location = new System.Drawing.Point(164, 50);
            this.txtUserUsernamePrivs.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserUsernamePrivs.Name = "txtUserUsernamePrivs";
            this.txtUserUsernamePrivs.Size = new System.Drawing.Size(461, 30);
            this.txtUserUsernamePrivs.TabIndex = 16;
            this.txtUserUsernamePrivs.TextChanged += new System.EventHandler(this.txtUserUsernamePrivs_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(171, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(488, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "DANH SÁCH QUYỀN CỦA NGƯỜI DÙNG";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.textBox_tao_role);
            this.tabPage3.Controls.Add(this.label_tao_role);
            this.tabPage3.Controls.Add(this.buttom_xoa_role);
            this.tabPage3.Controls.Add(this.button_taorole);
            this.tabPage3.Controls.Add(this.button_Xemchitiet);
            this.tabPage3.Controls.Add(this.role_duoc_chon_textBox);
            this.tabPage3.Controls.Add(this.lable_select_role);
            this.tabPage3.Controls.Add(this.Xem_ds_role);
            this.tabPage3.Controls.Add(this.TxtBox_TimKiemRole);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.dataGridView_Role_list);
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1752, 648);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Role";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // textBox_tao_role
            // 
            this.textBox_tao_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_tao_role.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_tao_role.Location = new System.Drawing.Point(61, 492);
            this.textBox_tao_role.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_tao_role.Name = "textBox_tao_role";
            this.textBox_tao_role.Size = new System.Drawing.Size(292, 30);
            this.textBox_tao_role.TabIndex = 12;
            this.textBox_tao_role.Text = "# Nhập tên role muốn tạo.";
            this.textBox_tao_role.Click += new System.EventHandler(this.textBox_tao_role_Click);
            this.textBox_tao_role.TextChanged += new System.EventHandler(this.textBox_tao_role_TextChanged);
            this.textBox_tao_role.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_tao_role_KeyDown);
            this.textBox_tao_role.Leave += new System.EventHandler(this.textBox_tao_role_Leave);
            // 
            // label_tao_role
            // 
            this.label_tao_role.AutoSize = true;
            this.label_tao_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_tao_role.Location = new System.Drawing.Point(61, 443);
            this.label_tao_role.Name = "label_tao_role";
            this.label_tao_role.Size = new System.Drawing.Size(176, 25);
            this.label_tao_role.TabIndex = 11;
            this.label_tao_role.Text = "Tên role muốn tạo:";
            // 
            // buttom_xoa_role
            // 
            this.buttom_xoa_role.BackColor = System.Drawing.Color.Brown;
            this.buttom_xoa_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttom_xoa_role.ForeColor = System.Drawing.Color.Black;
            this.buttom_xoa_role.Location = new System.Drawing.Point(61, 320);
            this.buttom_xoa_role.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttom_xoa_role.Name = "buttom_xoa_role";
            this.buttom_xoa_role.Size = new System.Drawing.Size(293, 41);
            this.buttom_xoa_role.TabIndex = 10;
            this.buttom_xoa_role.Text = "Xóa role";
            this.buttom_xoa_role.UseVisualStyleBackColor = false;
            this.buttom_xoa_role.Click += new System.EventHandler(this.buttom_xoa_role_Click);
            // 
            // button_taorole
            // 
            this.button_taorole.BackColor = System.Drawing.Color.Teal;
            this.button_taorole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_taorole.ForeColor = System.Drawing.Color.Black;
            this.button_taorole.Location = new System.Drawing.Point(61, 542);
            this.button_taorole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_taorole.Name = "button_taorole";
            this.button_taorole.Size = new System.Drawing.Size(293, 41);
            this.button_taorole.TabIndex = 9;
            this.button_taorole.Text = "Tạo role mới";
            this.button_taorole.UseVisualStyleBackColor = false;
            this.button_taorole.Click += new System.EventHandler(this.button_taorole_Click);
            // 
            // button_Xemchitiet
            // 
            this.button_Xemchitiet.BackColor = System.Drawing.Color.Teal;
            this.button_Xemchitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_Xemchitiet.ForeColor = System.Drawing.Color.Black;
            this.button_Xemchitiet.Location = new System.Drawing.Point(61, 270);
            this.button_Xemchitiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Xemchitiet.Name = "button_Xemchitiet";
            this.button_Xemchitiet.Size = new System.Drawing.Size(293, 41);
            this.button_Xemchitiet.TabIndex = 8;
            this.button_Xemchitiet.Text = "Xem chi tiết";
            this.button_Xemchitiet.UseVisualStyleBackColor = false;
            this.button_Xemchitiet.Click += new System.EventHandler(this.button_Xemchitiet_Click);
            // 
            // role_duoc_chon_textBox
            // 
            this.role_duoc_chon_textBox.Enabled = false;
            this.role_duoc_chon_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role_duoc_chon_textBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.role_duoc_chon_textBox.Location = new System.Drawing.Point(61, 222);
            this.role_duoc_chon_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.role_duoc_chon_textBox.Name = "role_duoc_chon_textBox";
            this.role_duoc_chon_textBox.Size = new System.Drawing.Size(292, 30);
            this.role_duoc_chon_textBox.TabIndex = 7;
            this.role_duoc_chon_textBox.Text = "# Tên role được chọn.";
            this.role_duoc_chon_textBox.Click += new System.EventHandler(this.role_duoc_chon_textBox_Click);
            this.role_duoc_chon_textBox.TextChanged += new System.EventHandler(this.role_duoc_chon_textBox_TextChanged_1);
            this.role_duoc_chon_textBox.Leave += new System.EventHandler(this.role_duoc_chon_textBox_Leave);
            // 
            // lable_select_role
            // 
            this.lable_select_role.AutoSize = true;
            this.lable_select_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lable_select_role.Location = new System.Drawing.Point(61, 172);
            this.lable_select_role.Name = "lable_select_role";
            this.lable_select_role.Size = new System.Drawing.Size(158, 25);
            this.lable_select_role.TabIndex = 6;
            this.lable_select_role.Text = "Role được chọn: ";
            // 
            // Xem_ds_role
            // 
            this.Xem_ds_role.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Xem_ds_role.BackColor = System.Drawing.Color.Teal;
            this.Xem_ds_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Xem_ds_role.ForeColor = System.Drawing.Color.Black;
            this.Xem_ds_role.Location = new System.Drawing.Point(1034, 84);
            this.Xem_ds_role.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Xem_ds_role.Name = "Xem_ds_role";
            this.Xem_ds_role.Size = new System.Drawing.Size(286, 44);
            this.Xem_ds_role.TabIndex = 5;
            this.Xem_ds_role.Text = "Tìm kiếm";
            this.Xem_ds_role.UseVisualStyleBackColor = false;
            this.Xem_ds_role.Click += new System.EventHandler(this.Xem_ds_role_Click);
            // 
            // TxtBox_TimKiemRole
            // 
            this.TxtBox_TimKiemRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtBox_TimKiemRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBox_TimKiemRole.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.TxtBox_TimKiemRole.Location = new System.Drawing.Point(515, 92);
            this.TxtBox_TimKiemRole.Margin = new System.Windows.Forms.Padding(4);
            this.TxtBox_TimKiemRole.Name = "TxtBox_TimKiemRole";
            this.TxtBox_TimKiemRole.Size = new System.Drawing.Size(444, 30);
            this.TxtBox_TimKiemRole.TabIndex = 4;
            this.TxtBox_TimKiemRole.Text = "# Nhập tên role cần tìm.";
            this.TxtBox_TimKiemRole.Click += new System.EventHandler(this.TxtBox_TimKiemRole_click);
            this.TxtBox_TimKiemRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TimKiemRole_KeyDown);
            this.TxtBox_TimKiemRole.Leave += new System.EventHandler(this.TxtBox_TimKiemRole_Leave);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Teal;
            this.label11.Location = new System.Drawing.Point(635, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(477, 29);
            this.label11.TabIndex = 2;
            this.label11.Text = "DANH SÁCH ROLE TRONG DATABASE";
            this.label11.Click += new System.EventHandler(this.label11_Click_1);
            // 
            // dataGridView_Role_list
            // 
            this.dataGridView_Role_list.AllowUserToAddRows = false;
            this.dataGridView_Role_list.AllowUserToDeleteRows = false;
            this.dataGridView_Role_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Role_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Role_list.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView_Role_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Role_list.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView_Role_list.Location = new System.Drawing.Point(409, 149);
            this.dataGridView_Role_list.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Role_list.Name = "dataGridView_Role_list";
            this.dataGridView_Role_list.ReadOnly = true;
            this.dataGridView_Role_list.RowHeadersWidth = 51;
            this.dataGridView_Role_list.RowTemplate.Height = 24;
            this.dataGridView_Role_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Role_list.Size = new System.Drawing.Size(1128, 462);
            this.dataGridView_Role_list.TabIndex = 0;
            this.dataGridView_Role_list.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Role_list_CellClick);
            // 
            // user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 690);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "user";
            this.Text = "user";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.user_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Role_list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUserCreateUser;
        private System.Windows.Forms.Button btnUserDeleteUser;
        private System.Windows.Forms.Button btnUserGrant;
        private System.Windows.Forms.Button btnUserRevoke;
        private System.Windows.Forms.TextBox txtUserUsernameFind;
        private System.Windows.Forms.TextBox txtUserUsername;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserUsernameGrant;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBoxWGO;
        private System.Windows.Forms.ComboBox comboBoxTablename;
        private System.Windows.Forms.RadioButton radioButtonDelete;
        private System.Windows.Forms.RadioButton radioButtonInsert;
        private System.Windows.Forms.RadioButton radioButtonUpdate;
        private System.Windows.Forms.RadioButton radioButtonSelect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView_Role_list;
        private System.Windows.Forms.TextBox TxtBox_TimKiemRole;
        private System.Windows.Forms.Label lable_select_role;
        private System.Windows.Forms.Button Xem_ds_role;
        private System.Windows.Forms.Button buttom_xoa_role;
        private System.Windows.Forms.Button button_taorole;
        private System.Windows.Forms.Button button_Xemchitiet;
        private System.Windows.Forms.TextBox role_duoc_chon_textBox;
        private System.Windows.Forms.Label label_tao_role;
        private System.Windows.Forms.TextBox textBox_tao_role;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBoxColumn;
        private System.Windows.Forms.CheckBox checkBoxTable;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserUsernamePrivs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectCols;
    }
}