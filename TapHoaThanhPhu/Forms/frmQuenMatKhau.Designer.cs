namespace TapHoaThanhPhu.Forms
{
    partial class frmQuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuenMatKhau));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.btnLayMa = new System.Windows.Forms.Button();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtgmail = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.lblQuenMatKhau);
            this.groupBox1.Controls.Add(this.btnLayMa);
            this.groupBox1.Controls.Add(this.btnDoiMatKhau);
            this.groupBox1.Controls.Add(this.txtNewPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtgmail);
            this.groupBox1.Controls.Add(this.txtMatKhau);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.txtTaiKhoan);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(558, 333);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quên mật khẩu";
            // 
            // lblQuenMatKhau
            // 
            this.lblQuenMatKhau.AutoSize = true;
            this.lblQuenMatKhau.Location = new System.Drawing.Point(463, 308);
            this.lblQuenMatKhau.Name = "lblQuenMatKhau";
            this.lblQuenMatKhau.Size = new System.Drawing.Size(88, 20);
            this.lblQuenMatKhau.TabIndex = 3;
            this.lblQuenMatKhau.TabStop = true;
            this.lblQuenMatKhau.Text = "Đăng nhập";
            // 
            // btnLayMa
            // 
            this.btnLayMa.Location = new System.Drawing.Point(373, 127);
            this.btnLayMa.Name = "btnLayMa";
            this.btnLayMa.Size = new System.Drawing.Size(97, 37);
            this.btnLayMa.TabIndex = 2;
            this.btnLayMa.Text = "Lấy mã";
            this.btnLayMa.UseVisualStyleBackColor = true;
            this.btnLayMa.Click += new System.EventHandler(this.btnLayMa_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Location = new System.Drawing.Point(373, 216);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(97, 48);
            this.btnDoiMatKhau.TabIndex = 2;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.AutoSize = true;
            this.txtNewPassword.Location = new System.Drawing.Point(71, 181);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(104, 20);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã";
            // 
            // txtgmail
            // 
            this.txtgmail.AutoSize = true;
            this.txtgmail.Location = new System.Drawing.Point(71, 89);
            this.txtgmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtgmail.Name = "txtgmail";
            this.txtgmail.Size = new System.Drawing.Size(50, 20);
            this.txtgmail.TabIndex = 1;
            this.txtgmail.Text = "Gmail";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(207, 178);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(263, 26);
            this.txtMatKhau.TabIndex = 0;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(207, 132);
            this.txtMa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(123, 26);
            this.txtMa.TabIndex = 0;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(207, 86);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(263, 26);
            this.txtTaiKhoan.TabIndex = 0;
            // 
            // frmQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuenMatKhau";
            this.Text = "Quên Mật Khẩu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lblQuenMatKhau;
        private System.Windows.Forms.Button btnLayMa;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Label txtNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtgmail;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTaiKhoan;
    }
}