namespace ATBM
{
    partial class Login
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
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_caption = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_PassWord = new System.Windows.Forms.TextBox();
            this.textBox_AdminFolderPath = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.label_Adminpath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.SkyBlue;
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_login.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_login.Location = new System.Drawing.Point(362, 484);
            this.button_login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(156, 48);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox_Port.Location = new System.Drawing.Point(344, 134);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(393, 37);
            this.textBox_Port.TabIndex = 1;
            // 
            // label_caption
            // 
            this.label_caption.AutoSize = true;
            this.label_caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_caption.ForeColor = System.Drawing.Color.Teal;
            this.label_caption.Location = new System.Drawing.Point(146, 31);
            this.label_caption.Name = "label_caption";
            this.label_caption.Size = new System.Drawing.Size(610, 46);
            this.label_caption.TabIndex = 2;
            this.label_caption.Text = "Hệ Thống Quản Trị Người Dùng";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox_UserName.Location = new System.Drawing.Point(344, 298);
            this.textBox_UserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(393, 37);
            this.textBox_UserName.TabIndex = 3;
            // 
            // textBox_PassWord
            // 
            this.textBox_PassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox_PassWord.Location = new System.Drawing.Point(344, 382);
            this.textBox_PassWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_PassWord.Name = "textBox_PassWord";
            this.textBox_PassWord.Size = new System.Drawing.Size(393, 37);
            this.textBox_PassWord.TabIndex = 4;
            // 
            // textBox_AdminFolderPath
            // 
            this.textBox_AdminFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBox_AdminFolderPath.Location = new System.Drawing.Point(344, 214);
            this.textBox_AdminFolderPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_AdminFolderPath.Name = "textBox_AdminFolderPath";
            this.textBox_AdminFolderPath.Size = new System.Drawing.Size(393, 37);
            this.textBox_AdminFolderPath.TabIndex = 2;
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label_port.Location = new System.Drawing.Point(162, 138);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(74, 30);
            this.label_port.TabIndex = 5;
            this.label_port.Text = "Port: ";
            // 
            // label_Adminpath
            // 
            this.label_Adminpath.AutoSize = true;
            this.label_Adminpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label_Adminpath.Location = new System.Drawing.Point(162, 218);
            this.label_Adminpath.Name = "label_Adminpath";
            this.label_Adminpath.Size = new System.Drawing.Size(159, 30);
            this.label_Adminpath.TabIndex = 6;
            this.label_Adminpath.Text = "Admin Path: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(162, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "User Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(162, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password: ";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Adminpath);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.textBox_AdminFolderPath);
            this.Controls.Add(this.textBox_PassWord);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.label_caption);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.button_login);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_caption;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_PassWord;
        private System.Windows.Forms.TextBox textBox_AdminFolderPath;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label_Adminpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}