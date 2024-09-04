namespace ATBM
{
    partial class f_xem_chi_tiet
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewNember = new System.Windows.Forms.DataGridView();
            this.dataGridView_privs_role = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_grant = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectCols = new System.Windows.Forms.Button();
            this.btn_user_role = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.radioButtonInsert = new System.Windows.Forms.RadioButton();
            this.radioButtonUpdate = new System.Windows.Forms.RadioButton();
            this.radioButtonDelete = new System.Windows.Forms.RadioButton();
            this.radioButtonSelect = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGrantUsers = new System.Windows.Forms.Button();
            this.buttonRevokeUser = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_privs_role)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNember
            // 
            this.dataGridViewNember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewNember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNember.Location = new System.Drawing.Point(872, 75);
            this.dataGridViewNember.Name = "dataGridViewNember";
            this.dataGridViewNember.RowHeadersWidth = 62;
            this.dataGridViewNember.RowTemplate.Height = 28;
            this.dataGridViewNember.Size = new System.Drawing.Size(784, 497);
            this.dataGridViewNember.TabIndex = 0;
            this.dataGridViewNember.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNember_CellClick_1);
            // 
            // dataGridView_privs_role
            // 
            this.dataGridView_privs_role.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_privs_role.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_privs_role.Location = new System.Drawing.Point(21, 75);
            this.dataGridView_privs_role.Name = "dataGridView_privs_role";
            this.dataGridView_privs_role.RowHeadersWidth = 62;
            this.dataGridView_privs_role.RowTemplate.Height = 28;
            this.dataGridView_privs_role.Size = new System.Drawing.Size(784, 497);
            this.dataGridView_privs_role.TabIndex = 1;
            this.dataGridView_privs_role.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_privs_role_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(1104, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "CÁC USER ĐÃ GÁN CHO ROLE";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(176, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "CÁC QUYỀN ĐÃ CẤP CHO ROLE";
            // 
            // btn_grant
            // 
            this.btn_grant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_grant.BackColor = System.Drawing.Color.Teal;
            this.btn_grant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_grant.Location = new System.Drawing.Point(376, 737);
            this.btn_grant.Name = "btn_grant";
            this.btn_grant.Size = new System.Drawing.Size(118, 42);
            this.btn_grant.TabIndex = 12;
            this.btn_grant.Text = "Grant";
            this.btn_grant.UseVisualStyleBackColor = false;
            this.btn_grant.Click += new System.EventHandler(this.btn_grant_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 634);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tên bảng";
            // 
            // buttonSelectCols
            // 
            this.buttonSelectCols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectCols.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSelectCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectCols.Location = new System.Drawing.Point(376, 685);
            this.buttonSelectCols.Name = "buttonSelectCols";
            this.buttonSelectCols.Size = new System.Drawing.Size(272, 40);
            this.buttonSelectCols.TabIndex = 15;
            this.buttonSelectCols.Text = "Chọn cột select/update";
            this.buttonSelectCols.UseVisualStyleBackColor = false;
            this.buttonSelectCols.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_user_role
            // 
            this.btn_user_role.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_user_role.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_user_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_user_role.Location = new System.Drawing.Point(1096, 617);
            this.btn_user_role.Name = "btn_user_role";
            this.btn_user_role.Size = new System.Drawing.Size(176, 42);
            this.btn_user_role.TabIndex = 17;
            this.btn_user_role.Text = "Chọn user";
            this.btn_user_role.UseVisualStyleBackColor = false;
            this.btn_user_role.Click += new System.EventHandler(this.btn_user_role_Click);
            // 
            // btn_return
            // 
            this.btn_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_return.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_return.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_return.Location = new System.Drawing.Point(1318, 731);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(134, 40);
            this.btn_return.TabIndex = 18;
            this.btn_return.Text = "Trở về";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Items.AddRange(new object[] {
            "156",
            "253",
            "335",
            "46",
            "54",
            "624"});
            this.comboBoxTables.Location = new System.Drawing.Point(376, 631);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(272, 28);
            this.comboBoxTables.TabIndex = 22;
            this.comboBoxTables.SelectedValueChanged += new System.EventHandler(this.comboBoxTables_SelectedValueChanged);
            this.comboBoxTables.Enter += new System.EventHandler(this.comboBoxTables_Enter_1);
            // 
            // radioButtonInsert
            // 
            this.radioButtonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonInsert.AutoSize = true;
            this.radioButtonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonInsert.Location = new System.Drawing.Point(117, 688);
            this.radioButtonInsert.Name = "radioButtonInsert";
            this.radioButtonInsert.Size = new System.Drawing.Size(85, 29);
            this.radioButtonInsert.TabIndex = 23;
            this.radioButtonInsert.TabStop = true;
            this.radioButtonInsert.Text = "Insert";
            this.radioButtonInsert.UseVisualStyleBackColor = true;
            this.radioButtonInsert.CheckedChanged += new System.EventHandler(this.radioButtonInsert_CheckedChanged);
            // 
            // radioButtonUpdate
            // 
            this.radioButtonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonUpdate.AutoSize = true;
            this.radioButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonUpdate.Location = new System.Drawing.Point(242, 688);
            this.radioButtonUpdate.Name = "radioButtonUpdate";
            this.radioButtonUpdate.Size = new System.Drawing.Size(100, 29);
            this.radioButtonUpdate.TabIndex = 24;
            this.radioButtonUpdate.TabStop = true;
            this.radioButtonUpdate.Text = "Update";
            this.radioButtonUpdate.UseVisualStyleBackColor = true;
            this.radioButtonUpdate.CheckedChanged += new System.EventHandler(this.radioButtonUpdate_CheckedChanged);
            // 
            // radioButtonDelete
            // 
            this.radioButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonDelete.AutoSize = true;
            this.radioButtonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDelete.Location = new System.Drawing.Point(117, 740);
            this.radioButtonDelete.Name = "radioButtonDelete";
            this.radioButtonDelete.Size = new System.Drawing.Size(93, 29);
            this.radioButtonDelete.TabIndex = 25;
            this.radioButtonDelete.TabStop = true;
            this.radioButtonDelete.Text = "Delete";
            this.radioButtonDelete.UseVisualStyleBackColor = true;
            this.radioButtonDelete.CheckedChanged += new System.EventHandler(this.radioButtonDelete_CheckedChanged);
            // 
            // radioButtonSelect
            // 
            this.radioButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonSelect.AutoSize = true;
            this.radioButtonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSelect.Location = new System.Drawing.Point(242, 740);
            this.radioButtonSelect.Name = "radioButtonSelect";
            this.radioButtonSelect.Size = new System.Drawing.Size(92, 29);
            this.radioButtonSelect.TabIndex = 26;
            this.radioButtonSelect.TabStop = true;
            this.radioButtonSelect.Text = "Select";
            this.radioButtonSelect.UseVisualStyleBackColor = true;
            this.radioButtonSelect.CheckedChanged += new System.EventHandler(this.radioButtonSelect_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(530, 737);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 40);
            this.button2.TabIndex = 28;
            this.button2.Text = "Revoke";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGrantUsers
            // 
            this.btnGrantUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrantUsers.BackColor = System.Drawing.Color.Teal;
            this.btnGrantUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrantUsers.Location = new System.Drawing.Point(1318, 617);
            this.btnGrantUsers.Name = "btnGrantUsers";
            this.btnGrantUsers.Size = new System.Drawing.Size(134, 40);
            this.btnGrantUsers.TabIndex = 29;
            this.btnGrantUsers.Text = "Grant";
            this.btnGrantUsers.UseVisualStyleBackColor = false;
            this.btnGrantUsers.Click += new System.EventHandler(this.btnGrantUsers_Click);
            // 
            // buttonRevokeUser
            // 
            this.buttonRevokeUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRevokeUser.BackColor = System.Drawing.Color.Brown;
            this.buttonRevokeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRevokeUser.Location = new System.Drawing.Point(1318, 675);
            this.buttonRevokeUser.Name = "buttonRevokeUser";
            this.buttonRevokeUser.Size = new System.Drawing.Size(134, 40);
            this.buttonRevokeUser.TabIndex = 30;
            this.buttonRevokeUser.Text = "Revoke";
            this.buttonRevokeUser.UseVisualStyleBackColor = false;
            this.buttonRevokeUser.Click += new System.EventHandler(this.buttonRevokeUser_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(1096, 683);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(175, 30);
            this.textBoxUserName.TabIndex = 31;
            // 
            // f_xem_chi_tiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 811);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonRevokeUser);
            this.Controls.Add(this.btnGrantUsers);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButtonSelect);
            this.Controls.Add(this.radioButtonDelete);
            this.Controls.Add(this.radioButtonUpdate);
            this.Controls.Add(this.radioButtonInsert);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_user_role);
            this.Controls.Add(this.buttonSelectCols);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_grant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView_privs_role);
            this.Controls.Add(this.dataGridViewNember);
            this.Name = "f_xem_chi_tiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_xem_chi_tiet";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_privs_role)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNember;
        private System.Windows.Forms.DataGridView dataGridView_privs_role;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_grant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectCols;
        private System.Windows.Forms.Button btn_user_role;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.RadioButton radioButtonInsert;
        private System.Windows.Forms.RadioButton radioButtonUpdate;
        private System.Windows.Forms.RadioButton radioButtonDelete;
        private System.Windows.Forms.RadioButton radioButtonSelect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGrantUsers;
        private System.Windows.Forms.Button buttonRevokeUser;
        private System.Windows.Forms.TextBox textBoxUserName;
    }
}

