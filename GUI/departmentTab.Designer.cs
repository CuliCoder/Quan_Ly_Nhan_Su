namespace Quan_Ly_Nhan_Su
{
    partial class departmentTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleTab = new System.Windows.Forms.Panel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.mainContent = new System.Windows.Forms.Panel();
            this.btnQuanLy = new System.Windows.Forms.Button();
            this.titleTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleTab
            // 
            this.titleTab.BackColor = System.Drawing.Color.White;
            this.titleTab.Controls.Add(this.btnQuanLy);
            this.titleTab.Controls.Add(this.btnThongKe);
            this.titleTab.Location = new System.Drawing.Point(3, 3);
            this.titleTab.Name = "titleTab";
            this.titleTab.Size = new System.Drawing.Size(1101, 59);
            this.titleTab.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(0, 0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(142, 59);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // mainContent
            // 
            this.mainContent.BackColor = System.Drawing.Color.White;
            this.mainContent.Location = new System.Drawing.Point(3, 68);
            this.mainContent.Name = "mainContent";
            this.mainContent.Size = new System.Drawing.Size(1101, 665);
            this.mainContent.TabIndex = 1;
            // 
            // btnQuanLy
            // 
            this.btnQuanLy.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLy.Location = new System.Drawing.Point(173, 0);
            this.btnQuanLy.Name = "btnQuanLy";
            this.btnQuanLy.Size = new System.Drawing.Size(142, 59);
            this.btnQuanLy.TabIndex = 3;
            this.btnQuanLy.Text = "Quản Lý";
            this.btnQuanLy.UseVisualStyleBackColor = true;
            this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click);
            // 
            // departmentTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.mainContent);
            this.Controls.Add(this.titleTab);
            this.Name = "departmentTab";
            this.Size = new System.Drawing.Size(1107, 733);
            this.titleTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titleTab;
        private System.Windows.Forms.Panel mainContent;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnQuanLy;
    }
}
