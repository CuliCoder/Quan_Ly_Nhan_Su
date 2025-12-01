using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.Constants;
using System;
namespace Quan_Ly_Nhan_Su.GUI.ChamCongUserControl
{
    partial class AttendanceGUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>

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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabctChamCong = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlbAttendance = new System.Windows.Forms.Panel();
            this.ptbAttendance = new System.Windows.Forms.PictureBox();
            this.lbAttendance = new System.Windows.Forms.Label();
            this.tabctKiemTraCongCa = new System.Windows.Forms.TabPage();
            this.ucChiTietChamCong1 = new Quan_Ly_Nhan_Su.GUI.ChamCongUserControl.ucKiemTraCongCa();
            this.tabctDanhSachNhanVien = new System.Windows.Forms.TabPage();
            this.ucChamCong1 = new Quan_Ly_Nhan_Su.GUI.ChamCongUserControl.ucDanhSachNhanVienAttendance();
            this.tabSearchByTimes = new System.Windows.Forms.TabPage();
            this.ucSearchByTimes1 = new Quan_Ly_Nhan_Su.GUI.ChamCongUserControl.ucSearchByTimes();
            this.tabControl1.SuspendLayout();
            this.tabctChamCong.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlbAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAttendance)).BeginInit();
            this.tabctKiemTraCongCa.SuspendLayout();
            this.tabctDanhSachNhanVien.SuspendLayout();
            this.tabSearchByTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabctChamCong);
            this.tabControl1.Controls.Add(this.tabctKiemTraCongCa);
            this.tabControl1.Controls.Add(this.tabctDanhSachNhanVien);
            this.tabControl1.Controls.Add(this.tabSearchByTimes);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1107, 733);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabctChamCong
            // 
            this.tabctChamCong.Controls.Add(this.panel1);
            this.tabctChamCong.Location = new System.Drawing.Point(4, 31);
            this.tabctChamCong.Margin = new System.Windows.Forms.Padding(2);
            this.tabctChamCong.Name = "tabctChamCong";
            this.tabctChamCong.Padding = new System.Windows.Forms.Padding(2);
            this.tabctChamCong.Size = new System.Drawing.Size(1099, 698);
            this.tabctChamCong.TabIndex = 2;
            this.tabctChamCong.Text = "Chấm công";
            this.tabctChamCong.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlbAttendance);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 694);
            this.panel1.TabIndex = 1;
            // 
            // pnlbAttendance
            // 
            this.pnlbAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlbAttendance.Controls.Add(this.ptbAttendance);
            this.pnlbAttendance.Controls.Add(this.lbAttendance);
            this.pnlbAttendance.Location = new System.Drawing.Point(464, 218);
            this.pnlbAttendance.Name = "pnlbAttendance";
            this.pnlbAttendance.Size = new System.Drawing.Size(206, 174);
            this.pnlbAttendance.TabIndex = 2;
            // 
            // ptbAttendance
            // 
            this.ptbAttendance.Image = global::Quan_Ly_Nhan_Su.Properties.Resources.check_in_bigSize;
            this.ptbAttendance.Location = new System.Drawing.Point(39, 14);
            this.ptbAttendance.Name = "ptbAttendance";
            this.ptbAttendance.Size = new System.Drawing.Size(128, 128);
            this.ptbAttendance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ptbAttendance.TabIndex = 2;
            this.ptbAttendance.TabStop = false;
            // 
            // lbAttendance
            // 
            this.lbAttendance.AutoSize = true;
            this.lbAttendance.Location = new System.Drawing.Point(50, 145);
            this.lbAttendance.Name = "lbAttendance";
            this.lbAttendance.Size = new System.Drawing.Size(108, 24);
            this.lbAttendance.TabIndex = 1;
            this.lbAttendance.Text = "Chấm công";
            // 
            // tabctKiemTraCongCa
            // 
            this.tabctKiemTraCongCa.Controls.Add(this.ucChiTietChamCong1);
            this.tabctKiemTraCongCa.Location = new System.Drawing.Point(4, 31);
            this.tabctKiemTraCongCa.Margin = new System.Windows.Forms.Padding(2);
            this.tabctKiemTraCongCa.Name = "tabctKiemTraCongCa";
            this.tabctKiemTraCongCa.Padding = new System.Windows.Forms.Padding(2);
            this.tabctKiemTraCongCa.Size = new System.Drawing.Size(1099, 698);
            this.tabctKiemTraCongCa.TabIndex = 1;
            this.tabctKiemTraCongCa.Text = "Kiểm tra công ca";
            this.tabctKiemTraCongCa.UseVisualStyleBackColor = true;
            // 
            // ucChiTietChamCong1
            // 
            this.ucChiTietChamCong1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChiTietChamCong1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChiTietChamCong1.Location = new System.Drawing.Point(2, 2);
            this.ucChiTietChamCong1.Margin = new System.Windows.Forms.Padding(4);
            this.ucChiTietChamCong1.Name = "ucChiTietChamCong1";
            this.ucChiTietChamCong1.Size = new System.Drawing.Size(1095, 694);
            this.ucChiTietChamCong1.TabIndex = 0;
            // 
            // tabctDanhSachNhanVien
            // 
            this.tabctDanhSachNhanVien.Controls.Add(this.ucChamCong1);
            this.tabctDanhSachNhanVien.Location = new System.Drawing.Point(4, 31);
            this.tabctDanhSachNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.tabctDanhSachNhanVien.Name = "tabctDanhSachNhanVien";
            this.tabctDanhSachNhanVien.Padding = new System.Windows.Forms.Padding(2);
            this.tabctDanhSachNhanVien.Size = new System.Drawing.Size(1099, 698);
            this.tabctDanhSachNhanVien.TabIndex = 0;
            this.tabctDanhSachNhanVien.Text = "Danh sách nhân viên";
            this.tabctDanhSachNhanVien.UseVisualStyleBackColor = true;
            // 
            // ucChamCong1
            // 
            this.ucChamCong1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ucChamCong1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChamCong1.Location = new System.Drawing.Point(0, 0);
            this.ucChamCong1.Margin = new System.Windows.Forms.Padding(2);
            this.ucChamCong1.Name = "ucChamCong1";
            this.ucChamCong1.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.ucChamCong1.Size = new System.Drawing.Size(1107, 733);
            this.ucChamCong1.TabIndex = 0;
            // 
            // tabSearchByTimes
            // 
            this.tabSearchByTimes.Controls.Add(this.ucSearchByTimes1);
            this.tabSearchByTimes.Location = new System.Drawing.Point(4, 31);
            this.tabSearchByTimes.Name = "tabSearchByTimes";
            this.tabSearchByTimes.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearchByTimes.Size = new System.Drawing.Size(1099, 698);
            this.tabSearchByTimes.TabIndex = 3;
            this.tabSearchByTimes.Text = "Tìm kiếm theo khoảng thời gian";
            this.tabSearchByTimes.UseVisualStyleBackColor = true;
            // 
            // ucSearchByTimes1
            // 
            this.ucSearchByTimes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSearchByTimes1.Location = new System.Drawing.Point(3, 3);
            this.ucSearchByTimes1.Margin = new System.Windows.Forms.Padding(5);
            this.ucSearchByTimes1.Name = "ucSearchByTimes1";
            this.ucSearchByTimes1.Size = new System.Drawing.Size(1093, 692);
            this.ucSearchByTimes1.TabIndex = 0;
            // 
            // AttendanceGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AttendanceGUI";
            this.Size = new System.Drawing.Size(1109, 735);
            this.tabControl1.ResumeLayout(false);
            this.tabctChamCong.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlbAttendance.ResumeLayout(false);
            this.pnlbAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAttendance)).EndInit();
            this.tabctKiemTraCongCa.ResumeLayout(false);
            this.tabctDanhSachNhanVien.ResumeLayout(false);
            this.tabSearchByTimes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabctDanhSachNhanVien;
        private System.Windows.Forms.TabPage tabctKiemTraCongCa;
        private ucDanhSachNhanVienAttendance ucChamCong1;
        private System.Windows.Forms.TabPage tabctChamCong;
        private System.Windows.Forms.Panel panel1;
        private ucKiemTraCongCa ucChiTietChamCong1;
        private System.Windows.Forms.Label lbAttendance;
        private System.Windows.Forms.Panel pnlbAttendance;
        private System.Windows.Forms.PictureBox ptbAttendance;
        private System.Windows.Forms.TabPage tabSearchByTimes;
        private ucSearchByTimes ucSearchByTimes1;
    }
}
