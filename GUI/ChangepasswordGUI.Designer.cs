using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    partial class ChangepasswordGUI
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblUsername;
        private Label lblOldPassword;
        private Label lblNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtUsername;
        private TextBox txtOldPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Button btnShowOld;
        private Button btnShowNew;
        private Button btnShowConfirm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowOld = new System.Windows.Forms.Button();
            this.btnShowNew = new System.Windows.Forms.Button();
            this.btnShowConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(255, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(334, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin tài khoản cá nhân";
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(132, 192);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Tài khoản";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.Location = new System.Drawing.Point(129, 256);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(100, 23);
            this.lblOldPassword.TabIndex = 2;
            this.lblOldPassword.Text = "Mật khẩu cũ";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Location = new System.Drawing.Point(129, 304);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(100, 23);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "Mật khẩu mới";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Location = new System.Drawing.Point(129, 356);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(100, 23);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu mới";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.LightGray;
            this.txtUsername.Location = new System.Drawing.Point(248, 192);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(404, 26);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Text = "admin";
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(248, 253);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '•';
            this.txtOldPassword.Size = new System.Drawing.Size(404, 26);
            this.txtOldPassword.TabIndex = 6;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(248, 304);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new System.Drawing.Size(404, 26);
            this.txtNewPassword.TabIndex = 7;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(248, 356);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '•';
            this.txtConfirmPassword.Size = new System.Drawing.Size(404, 26);
            this.txtConfirmPassword.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(286, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(189, 55);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu Thay đổi";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnShowOld
            // 
            this.btnShowOld.Location = new System.Drawing.Point(658, 253);
            this.btnShowOld.Name = "btnShowOld";
            this.btnShowOld.Size = new System.Drawing.Size(35, 25);
            this.btnShowOld.TabIndex = 9;
            this.btnShowOld.Text = "👁";
            // 
            // btnShowNew
            // 
            this.btnShowNew.Location = new System.Drawing.Point(658, 302);
            this.btnShowNew.Name = "btnShowNew";
            this.btnShowNew.Size = new System.Drawing.Size(35, 25);
            this.btnShowNew.TabIndex = 10;
            this.btnShowNew.Text = "👁";
            // 
            // btnShowConfirm
            // 
            this.btnShowConfirm.Location = new System.Drawing.Point(658, 357);
            this.btnShowConfirm.Name = "btnShowConfirm";
            this.btnShowConfirm.Size = new System.Drawing.Size(35, 25);
            this.btnShowConfirm.TabIndex = 11;
            this.btnShowConfirm.Text = "👁";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblOldPassword);
            this.panel1.Controls.Add(this.lblNewPassword);
            this.panel1.Controls.Add(this.lblConfirmPassword);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.txtOldPassword);
            this.panel1.Controls.Add(this.txtNewPassword);
            this.panel1.Controls.Add(this.txtConfirmPassword);
            this.panel1.Controls.Add(this.btnShowOld);
            this.panel1.Controls.Add(this.btnShowNew);
            this.panel1.Controls.Add(this.btnShowConfirm);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 596);
            this.panel1.TabIndex = 13;
            // 
            // ChangepasswordGUI
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Name = "ChangepasswordGUI";
            this.Size = new System.Drawing.Size(880, 625);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel panel1;
    }
}