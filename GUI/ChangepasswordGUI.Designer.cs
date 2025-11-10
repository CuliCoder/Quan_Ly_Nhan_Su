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
        private Panel panelContainer;
        private Label lblPasswordHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContainer = new System.Windows.Forms.Panel();
            this.lblPasswordHint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowConfirm = new System.Windows.Forms.Button();
            this.btnShowNew = new System.Windows.Forms.Button();
            this.btnShowOld = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Controls.Add(this.lblPasswordHint);
            this.panelContainer.Controls.Add(this.btnSave);
            this.panelContainer.Controls.Add(this.btnShowConfirm);
            this.panelContainer.Controls.Add(this.btnShowNew);
            this.panelContainer.Controls.Add(this.btnShowOld);
            this.panelContainer.Controls.Add(this.txtConfirmPassword);
            this.panelContainer.Controls.Add(this.txtNewPassword);
            this.panelContainer.Controls.Add(this.txtOldPassword);
            this.panelContainer.Controls.Add(this.txtUsername);
            this.panelContainer.Controls.Add(this.lblConfirmPassword);
            this.panelContainer.Controls.Add(this.lblNewPassword);
            this.panelContainer.Controls.Add(this.lblOldPassword);
            this.panelContainer.Controls.Add(this.lblUsername);
            this.panelContainer.Controls.Add(this.lblTitle);
            this.panelContainer.Location = new System.Drawing.Point(69, 56);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1050, 680); // <-- KÍCH THƯỚC ĐÃ SỬA
            this.panelContainer.TabIndex = 0;
            // 
            // lblPasswordHint
            // 
            this.lblPasswordHint.AutoSize = true;
            this.lblPasswordHint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblPasswordHint.ForeColor = System.Drawing.Color.Gray;
            this.lblPasswordHint.Location = new System.Drawing.Point(381, 350); // <-- VỊ TRÍ ĐÃ SỬA
            this.lblPasswordHint.Name = "lblPasswordHint";
            this.lblPasswordHint.Size = new System.Drawing.Size(317, 80);
            this.lblPasswordHint.TabIndex = 13;
            this.lblPasswordHint.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(194)))), ((int)(((byte)(167)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(425, 560); // <-- VỊ TRÍ ĐÃ SỬA (thay đổi Y)
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 50);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "💾 Lưu Thay Đổi";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnShowConfirm
            // 
            this.btnShowConfirm.BackColor = System.Drawing.Color.White;
            this.btnShowConfirm.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnShowConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowConfirm.Location = new System.Drawing.Point(795, 465); // <-- VỊ TRÍ ĐÃ SỬA
            this.btnShowConfirm.Name = "btnShowConfirm";
            this.btnShowConfirm.Size = new System.Drawing.Size(45, 32);
            this.btnShowConfirm.TabIndex = 11;
            this.btnShowConfirm.Text = "👁";
            this.btnShowConfirm.UseVisualStyleBackColor = false;
            // 
            // btnShowNew
            // 
            this.btnShowNew.BackColor = System.Drawing.Color.White;
            this.btnShowNew.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnShowNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowNew.Location = new System.Drawing.Point(795, 305); // <-- VỊ TRÍ ĐÃ SỬA
            this.btnShowNew.Name = "btnShowNew";
            this.btnShowNew.Size = new System.Drawing.Size(45, 32);
            this.btnShowNew.TabIndex = 10;
            this.btnShowNew.Text = "👁";
            this.btnShowNew.UseVisualStyleBackColor = false;
            // 
            // btnShowOld
            // 
            this.btnShowOld.BackColor = System.Drawing.Color.White;
            this.btnShowOld.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnShowOld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOld.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowOld.Location = new System.Drawing.Point(795, 225); // <-- VỊ TRÍ ĐÃ SỬA
            this.btnShowOld.Name = "btnShowOld";
            this.btnShowOld.Size = new System.Drawing.Size(45, 32);
            this.btnShowOld.TabIndex = 9;
            this.btnShowOld.Text = "👁";
            this.btnShowOld.UseVisualStyleBackColor = false;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(400, 465); // <-- VỊ TRÍ ĐÃ SỬA
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '•';
            this.txtConfirmPassword.Size = new System.Drawing.Size(400, 32);
            this.txtConfirmPassword.TabIndex = 8;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNewPassword.Location = new System.Drawing.Point(400, 305); // <-- VỊ TRÍ ĐÃ SỬA
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new System.Drawing.Size(400, 32);
            this.txtNewPassword.TabIndex = 7;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtOldPassword.Location = new System.Drawing.Point(400, 225); // <-- VỊ TRÍ ĐÃ SỬA
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '•';
            this.txtOldPassword.Size = new System.Drawing.Size(400, 32);
            this.txtOldPassword.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.LightGray;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(400, 145); // <-- VỊ TRÍ ĐÃ SỬA
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(400, 32);
            this.txtUsername.TabIndex = 5;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(205, 470); // <-- VỊ TRÍ ĐÃ SỬA
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(133, 35);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Xác nhận MK:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblNewPassword.Location = new System.Drawing.Point(205, 310); // <-- VỊ TRÍ ĐÃ SỬA
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(140, 35);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "Mật khẩu mới:";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOldPassword.Location = new System.Drawing.Point(205, 230); // <-- VỊ TRÍ ĐÃ SỬA
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(171, 35);
            this.lblOldPassword.TabIndex = 2;
            this.lblOldPassword.Text = "Mật khẩu hiện tại:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblUsername.Location = new System.Drawing.Point(205, 150); // <-- VỊ TRÍ ĐÃ SỬA
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(102, 35);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Tài khoản:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(194)))), ((int)(((byte)(167)))));
            this.lblTitle.Location = new System.Drawing.Point(165, 60); // <-- VỊ TRÍ ĐÃ SỬA
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(720, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔐 Thay Đổi Mật Khẩu";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChangepasswordGUI
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelContainer);
            this.Name = "ChangepasswordGUI";
            this.Load += new System.EventHandler(this.ChangepasswordGUI_Load_1);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}