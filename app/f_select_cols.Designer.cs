namespace ATBM
{
    partial class f_select_cols
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
            this.btnGetCols = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewCols = new System.Windows.Forms.DataGridView();
            this.txtColName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCols)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetCols
            // 
            this.btnGetCols.BackColor = System.Drawing.Color.Teal;
            this.btnGetCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetCols.Location = new System.Drawing.Point(94, 367);
            this.btnGetCols.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetCols.Name = "btnGetCols";
            this.btnGetCols.Size = new System.Drawing.Size(116, 30);
            this.btnGetCols.TabIndex = 1;
            this.btnGetCols.Text = "OK";
            this.btnGetCols.UseVisualStyleBackColor = false;
            this.btnGetCols.Click += new System.EventHandler(this.btnGetCols_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "CHỌN CỘT CẤP QUYỀN";
            // 
            // dataGridViewCols
            // 
            this.dataGridViewCols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCols.Location = new System.Drawing.Point(20, 85);
            this.dataGridViewCols.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCols.Name = "dataGridViewCols";
            this.dataGridViewCols.RowHeadersWidth = 62;
            this.dataGridViewCols.RowTemplate.Height = 28;
            this.dataGridViewCols.Size = new System.Drawing.Size(271, 270);
            this.dataGridViewCols.TabIndex = 3;
            // 
            // txtColName
            // 
            this.txtColName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColName.ForeColor = System.Drawing.Color.Gray;
            this.txtColName.Location = new System.Drawing.Point(20, 47);
            this.txtColName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtColName.Name = "txtColName";
            this.txtColName.Size = new System.Drawing.Size(269, 26);
            this.txtColName.TabIndex = 5;
            this.txtColName.Text = "Nhập tên cột";
            this.txtColName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtColName.Enter += new System.EventHandler(this.txtColName_Enter);
            this.txtColName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColName_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // f_select_cols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 406);
            this.Controls.Add(this.txtColName);
            this.Controls.Add(this.dataGridViewCols);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetCols);
            this.Location = new System.Drawing.Point(440, 180);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "f_select_cols";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "form_select_cols";
            this.Load += new System.EventHandler(this.f_select_cols_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGetCols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCols;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}