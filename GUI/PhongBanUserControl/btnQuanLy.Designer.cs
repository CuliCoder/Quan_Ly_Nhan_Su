using System.Windows.Forms;

namespace Quan_Ly_Nhan_Su.GUI
{
    partial class btnQuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnQuanLy));
            this.Title = new System.Windows.Forms.Panel();
            this.boxAdd = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.icAdd = new System.Windows.Forms.PictureBox();
            this.boxEdit = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxdelete = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tablePB = new System.Windows.Forms.Panel();
            this.tbPB = new System.Windows.Forms.DataGridView();
            this.tableNV = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNV = new System.Windows.Forms.DataGridView();
            this.ifNV = new System.Windows.Forms.Panel();
            this.lbHV2 = new System.Windows.Forms.Label();
            this.lbCV2 = new System.Windows.Forms.Label();
            this.lbDC2 = new System.Windows.Forms.Label();
            this.lbDT2 = new System.Windows.Forms.Label();
            this.lbNS2 = new System.Windows.Forms.Label();
            this.lbGT2 = new System.Windows.Forms.Label();
            this.lbHT2 = new System.Windows.Forms.Label();
            this.lbMNV2 = new System.Windows.Forms.Label();
            this.lbNNC = new System.Windows.Forms.Label();
            this.lbDT = new System.Windows.Forms.Label();
            this.lbDC = new System.Windows.Forms.Label();
            this.lbCV = new System.Windows.Forms.Label();
            this.lbMNV = new System.Windows.Forms.Label();
            this.lbHT = new System.Windows.Forms.Label();
            this.lbGT = new System.Windows.Forms.Label();
            this.lbNS = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Title.SuspendLayout();
            this.boxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icAdd)).BeginInit();
            this.boxEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.boxdelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            this.tablePB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPB)).BeginInit();
            this.tableNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNV)).BeginInit();
            this.ifNV.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Controls.Add(this.boxAdd);
            this.Title.Controls.Add(this.boxEdit);
            this.Title.Controls.Add(this.boxdelete);
            this.Title.Controls.Add(this.label1);
            this.Title.Location = new System.Drawing.Point(4, 4);
            this.Title.Margin = new System.Windows.Forms.Padding(4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(1460, 58);
            this.Title.TabIndex = 0;
            // 
            // boxAdd
            // 
            this.boxAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxAdd.Controls.Add(this.label4);
            this.boxAdd.Controls.Add(this.icAdd);
            this.boxAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxAdd.Location = new System.Drawing.Point(1328, 5);
            this.boxAdd.Margin = new System.Windows.Forms.Padding(4);
            this.boxAdd.Name = "boxAdd";
            this.boxAdd.Size = new System.Drawing.Size(128, 50);
            this.boxAdd.TabIndex = 4;
            this.boxAdd.Click += new System.EventHandler(this.boxAdd_Click);
            this.boxAdd.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.boxAdd.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thêm";
            this.label4.Click += new System.EventHandler(this.boxAdd_Click);
            this.label4.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // icAdd
            // 
            this.icAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icAdd.Image = ((System.Drawing.Image)(resources.GetObject("icAdd.Image")));
            this.icAdd.Location = new System.Drawing.Point(12, 7);
            this.icAdd.Margin = new System.Windows.Forms.Padding(4);
            this.icAdd.Name = "icAdd";
            this.icAdd.Size = new System.Drawing.Size(42, 37);
            this.icAdd.TabIndex = 1;
            this.icAdd.TabStop = false;
            this.icAdd.Click += new System.EventHandler(this.boxAdd_Click);
            this.icAdd.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.icAdd.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // boxEdit
            // 
            this.boxEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxEdit.Controls.Add(this.pictureBox1);
            this.boxEdit.Controls.Add(this.label3);
            this.boxEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxEdit.Location = new System.Drawing.Point(1192, 5);
            this.boxEdit.Margin = new System.Windows.Forms.Padding(4);
            this.boxEdit.Name = "boxEdit";
            this.boxEdit.Size = new System.Drawing.Size(128, 50);
            this.boxEdit.TabIndex = 3;
            this.boxEdit.Click += new System.EventHandler(this.boxEdit_Click);
            this.boxEdit.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.boxEdit.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 44);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.boxEdit_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sửa";
            this.label3.Click += new System.EventHandler(this.boxEdit_Click);
            this.label3.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // boxdelete
            // 
            this.boxdelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxdelete.Controls.Add(this.label2);
            this.boxdelete.Controls.Add(this.delete);
            this.boxdelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxdelete.Location = new System.Drawing.Point(1056, 5);
            this.boxdelete.Margin = new System.Windows.Forms.Padding(4);
            this.boxdelete.Name = "boxdelete";
            this.boxdelete.Size = new System.Drawing.Size(128, 50);
            this.boxdelete.TabIndex = 2;
            this.boxdelete.Click += new System.EventHandler(this.boxdelete_Click);
            this.boxdelete.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.boxdelete.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Xóa";
            this.label2.Click += new System.EventHandler(this.boxdelete_Click);
            this.label2.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // delete
            // 
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.Location = new System.Drawing.Point(11, 8);
            this.delete.Margin = new System.Windows.Forms.Padding(4);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(37, 37);
            this.delete.TabIndex = 1;
            this.delete.TabStop = false;
            this.delete.Click += new System.EventHandler(this.boxdelete_Click);
            this.delete.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.delete.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Phòng Ban";
            // 
            // tablePB
            // 
            this.tablePB.Controls.Add(this.tbPB);
            this.tablePB.Location = new System.Drawing.Point(4, 69);
            this.tablePB.Margin = new System.Windows.Forms.Padding(4);
            this.tablePB.Name = "tablePB";
            this.tablePB.Size = new System.Drawing.Size(1460, 366);
            this.tablePB.TabIndex = 1;
            // 
            // tbPB
            // 
            this.tbPB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbPB.Location = new System.Drawing.Point(4, 4);
            this.tbPB.Margin = new System.Windows.Forms.Padding(4);
            this.tbPB.Name = "tbPB";
            this.tbPB.RowHeadersWidth = 51;
            this.tbPB.Size = new System.Drawing.Size(1452, 361);
            this.tbPB.TabIndex = 0;
            // 
            // tableNV
            // 
            this.tableNV.Controls.Add(this.label5);
            this.tableNV.Controls.Add(this.tbNV);
            this.tableNV.Location = new System.Drawing.Point(8, 442);
            this.tableNV.Margin = new System.Windows.Forms.Padding(4);
            this.tableNV.Name = "tableNV";
            this.tableNV.Size = new System.Drawing.Size(801, 373);
            this.tableNV.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nhân Viên Phòng Kỹ Thuật";
            // 
            // tbNV
            // 
            this.tbNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbNV.Location = new System.Drawing.Point(0, 43);
            this.tbNV.Margin = new System.Windows.Forms.Padding(4);
            this.tbNV.Name = "tbNV";
            this.tbNV.RowHeadersWidth = 51;
            this.tbNV.Size = new System.Drawing.Size(799, 326);
            this.tbNV.TabIndex = 0;
            // 
            // ifNV
            // 
            this.ifNV.Controls.Add(this.lbHV2);
            this.ifNV.Controls.Add(this.lbCV2);
            this.ifNV.Controls.Add(this.lbDC2);
            this.ifNV.Controls.Add(this.lbDT2);
            this.ifNV.Controls.Add(this.lbNS2);
            this.ifNV.Controls.Add(this.lbGT2);
            this.ifNV.Controls.Add(this.lbHT2);
            this.ifNV.Controls.Add(this.lbMNV2);
            this.ifNV.Controls.Add(this.lbNNC);
            this.ifNV.Controls.Add(this.lbDT);
            this.ifNV.Controls.Add(this.lbDC);
            this.ifNV.Controls.Add(this.lbCV);
            this.ifNV.Controls.Add(this.lbMNV);
            this.ifNV.Controls.Add(this.lbHT);
            this.ifNV.Controls.Add(this.lbGT);
            this.ifNV.Controls.Add(this.lbNS);
            this.ifNV.Controls.Add(this.label6);
            this.ifNV.Location = new System.Drawing.Point(817, 442);
            this.ifNV.Margin = new System.Windows.Forms.Padding(4);
            this.ifNV.Name = "ifNV";
            this.ifNV.Size = new System.Drawing.Size(643, 369);
            this.ifNV.TabIndex = 3;
            // 
            // lbHV2
            // 
            this.lbHV2.AutoSize = true;
            this.lbHV2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHV2.Location = new System.Drawing.Point(126, 305);
            this.lbHV2.Name = "lbHV2";
            this.lbHV2.Size = new System.Drawing.Size(0, 25);
            this.lbHV2.TabIndex = 16;
            // 
            // lbCV2
            // 
            this.lbCV2.AutoSize = true;
            this.lbCV2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCV2.Location = new System.Drawing.Point(126, 273);
            this.lbCV2.Name = "lbCV2";
            this.lbCV2.Size = new System.Drawing.Size(0, 25);
            this.lbCV2.TabIndex = 15;
            // 
            // lbDC2
            // 
            this.lbDC2.AutoSize = true;
            this.lbDC2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDC2.Location = new System.Drawing.Point(126, 241);
            this.lbDC2.Name = "lbDC2";
            this.lbDC2.Size = new System.Drawing.Size(0, 25);
            this.lbDC2.TabIndex = 14;
            // 
            // lbDT2
            // 
            this.lbDT2.AutoSize = true;
            this.lbDT2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDT2.Location = new System.Drawing.Point(126, 207);
            this.lbDT2.Name = "lbDT2";
            this.lbDT2.Size = new System.Drawing.Size(0, 25);
            this.lbDT2.TabIndex = 13;
            // 
            // lbNS2
            // 
            this.lbNS2.AutoSize = true;
            this.lbNS2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNS2.Location = new System.Drawing.Point(126, 171);
            this.lbNS2.Name = "lbNS2";
            this.lbNS2.Size = new System.Drawing.Size(0, 25);
            this.lbNS2.TabIndex = 12;
            this.lbNS2.Click += new System.EventHandler(this.lbNS2_Click);
            // 
            // lbGT2
            // 
            this.lbGT2.AutoSize = true;
            this.lbGT2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGT2.Location = new System.Drawing.Point(126, 138);
            this.lbGT2.Name = "lbGT2";
            this.lbGT2.Size = new System.Drawing.Size(0, 25);
            this.lbGT2.TabIndex = 11;
            this.lbGT2.Click += new System.EventHandler(this.lbGT2_Click);
            // 
            // lbHT2
            // 
            this.lbHT2.AutoSize = true;
            this.lbHT2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHT2.Location = new System.Drawing.Point(126, 104);
            this.lbHT2.Name = "lbHT2";
            this.lbHT2.Size = new System.Drawing.Size(0, 25);
            this.lbHT2.TabIndex = 10;
            this.lbHT2.Click += new System.EventHandler(this.lbHT2_Click);
            // 
            // lbMNV2
            // 
            this.lbMNV2.AutoSize = true;
            this.lbMNV2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMNV2.Location = new System.Drawing.Point(126, 69);
            this.lbMNV2.Name = "lbMNV2";
            this.lbMNV2.Size = new System.Drawing.Size(0, 25);
            this.lbMNV2.TabIndex = 9;
            this.lbMNV2.Click += new System.EventHandler(this.lbMNV2_Click);
            // 
            // lbNNC
            // 
            this.lbNNC.AutoSize = true;
            this.lbNNC.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNNC.Location = new System.Drawing.Point(4, 306);
            this.lbNNC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNNC.Name = "lbNNC";
            this.lbNNC.Size = new System.Drawing.Size(94, 25);
            this.lbNNC.TabIndex = 8;
            this.lbNNC.Text = "Học vấn:";
            // 
            // lbDT
            // 
            this.lbDT.AutoSize = true;
            this.lbDT.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDT.Location = new System.Drawing.Point(4, 208);
            this.lbDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDT.Name = "lbDT";
            this.lbDT.Size = new System.Drawing.Size(113, 25);
            this.lbDT.TabIndex = 7;
            this.lbDT.Text = "Điện thoại:";
            // 
            // lbDC
            // 
            this.lbDC.AutoSize = true;
            this.lbDC.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDC.Location = new System.Drawing.Point(4, 242);
            this.lbDC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDC.Name = "lbDC";
            this.lbDC.Size = new System.Drawing.Size(81, 25);
            this.lbDC.TabIndex = 6;
            this.lbDC.Text = "Địa chỉ:";
            // 
            // lbCV
            // 
            this.lbCV.AutoSize = true;
            this.lbCV.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCV.Location = new System.Drawing.Point(4, 274);
            this.lbCV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCV.Name = "lbCV";
            this.lbCV.Size = new System.Drawing.Size(94, 25);
            this.lbCV.TabIndex = 5;
            this.lbCV.Text = "Chức vụ:";
            // 
            // lbMNV
            // 
            this.lbMNV.AutoSize = true;
            this.lbMNV.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMNV.Location = new System.Drawing.Point(4, 70);
            this.lbMNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMNV.Name = "lbMNV";
            this.lbMNV.Size = new System.Drawing.Size(72, 25);
            this.lbMNV.TabIndex = 4;
            this.lbMNV.Text = "Mã số:";
            // 
            // lbHT
            // 
            this.lbHT.AutoSize = true;
            this.lbHT.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHT.Location = new System.Drawing.Point(4, 104);
            this.lbHT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHT.Name = "lbHT";
            this.lbHT.Size = new System.Drawing.Size(85, 25);
            this.lbHT.TabIndex = 3;
            this.lbHT.Text = "Họ tên: ";
            // 
            // lbGT
            // 
            this.lbGT.AutoSize = true;
            this.lbGT.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGT.Location = new System.Drawing.Point(3, 137);
            this.lbGT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGT.Name = "lbGT";
            this.lbGT.Size = new System.Drawing.Size(95, 25);
            this.lbGT.TabIndex = 2;
            this.lbGT.Text = "Giới tính:";
            // 
            // lbNS
            // 
            this.lbNS.AutoSize = true;
            this.lbNS.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNS.Location = new System.Drawing.Point(4, 172);
            this.lbNS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNS.Name = "lbNS";
            this.lbNS.Size = new System.Drawing.Size(111, 25);
            this.lbNS.TabIndex = 1;
            this.lbNS.Text = "Ngày sinh:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thông tin nhân viên";
            // 
            // btnQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ifNV);
            this.Controls.Add(this.tableNV);
            this.Controls.Add(this.tablePB);
            this.Controls.Add(this.Title);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "btnQuanLy";
            this.Size = new System.Drawing.Size(1468, 818);
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            this.boxAdd.ResumeLayout(false);
            this.boxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icAdd)).EndInit();
            this.boxEdit.ResumeLayout(false);
            this.boxEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.boxdelete.ResumeLayout(false);
            this.boxdelete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            this.tablePB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbPB)).EndInit();
            this.tableNV.ResumeLayout(false);
            this.tableNV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNV)).EndInit();
            this.ifNV.ResumeLayout(false);
            this.ifNV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox delete;
        private System.Windows.Forms.Panel boxdelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel boxEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel boxAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox icAdd;
        private System.Windows.Forms.Panel tablePB;
        private System.Windows.Forms.DataGridView tbPB;
        private System.Windows.Forms.Panel tableNV;
        private System.Windows.Forms.DataGridView tbNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel ifNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbMNV;
        private System.Windows.Forms.Label lbHT;
        private System.Windows.Forms.Label lbGT;
        private System.Windows.Forms.Label lbDT;
        private System.Windows.Forms.Label lbDC;
        private System.Windows.Forms.Label lbCV;
        private System.Windows.Forms.Label lbNNC;
        private System.Windows.Forms.Label lbMNV2;
        private System.Windows.Forms.Label lbGT2;
        private System.Windows.Forms.Label lbHT2;
        private System.Windows.Forms.Label lbNS2;
        private System.Windows.Forms.Label lbHV2;
        private System.Windows.Forms.Label lbCV2;
        private System.Windows.Forms.Label lbDC2;
        private System.Windows.Forms.Label lbDT2;
        private Label lbNS;
    }
}
