namespace QL_THUVIEN2
{
    partial class frm9TheLoai
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btht = new System.Windows.Forms.LinkLabel();
            this.bttk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbtk = new System.Windows.Forms.TextBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.ma = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvpn1madg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttqlnvxoa = new System.Windows.Forms.Button();
            this.btsua = new System.Windows.Forms.Button();
            this.bttthemmoi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btht);
            this.panel1.Controls.Add(this.bttk);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbtk);
            this.panel1.Controls.Add(this.ten);
            this.panel1.Controls.Add(this.ma);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.bttqlnvxoa);
            this.panel1.Controls.Add(this.btsua);
            this.panel1.Controls.Add(this.bttthemmoi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 543);
            this.panel1.TabIndex = 1;
            // 
            // btht
            // 
            this.btht.AutoSize = true;
            this.btht.Location = new System.Drawing.Point(15, 238);
            this.btht.Name = "btht";
            this.btht.Size = new System.Drawing.Size(120, 22);
            this.btht.TabIndex = 36;
            this.btht.TabStop = true;
            this.btht.Text = "Hiển thị tất cả";
            this.btht.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btht_LinkClicked);
            // 
            // bttk
            // 
            this.bttk.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttk.Image = global::QL_THUVIEN2.Properties.Resources.page_search;
            this.bttk.Location = new System.Drawing.Point(536, 152);
            this.bttk.Name = "bttk";
            this.bttk.Size = new System.Drawing.Size(147, 51);
            this.bttk.TabIndex = 34;
            this.bttk.Text = "Tìm";
            this.bttk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttk.UseVisualStyleBackColor = false;
            this.bttk.Click += new System.EventHandler(this.bttk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(299, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 22);
            this.label3.TabIndex = 32;
            this.label3.Text = "Thông Tin Tìm";
            // 
            // tbtk
            // 
            this.tbtk.Location = new System.Drawing.Point(444, 116);
            this.tbtk.Name = "tbtk";
            this.tbtk.Size = new System.Drawing.Size(239, 30);
            this.tbtk.TabIndex = 31;
            // 
            // ten
            // 
            this.ten.Location = new System.Drawing.Point(444, 71);
            this.ten.Margin = new System.Windows.Forms.Padding(4);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(239, 30);
            this.ten.TabIndex = 30;
            // 
            // ma
            // 
            this.ma.Location = new System.Drawing.Point(445, 27);
            this.ma.Margin = new System.Windows.Forms.Padding(4);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(239, 30);
            this.ma.TabIndex = 29;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Image = global::QL_THUVIEN2.Properties.Resources.process_delete;
            this.button2.Location = new System.Drawing.Point(536, 209);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 51);
            this.button2.TabIndex = 27;
            this.button2.Text = "Thoát";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dgvpn1madg});
            this.dgv.Location = new System.Drawing.Point(-47, 268);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(766, 274);
            this.dgv.TabIndex = 8;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaTL";
            this.Column1.HeaderText = "Mã Thể Loại";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvpn1madg
            // 
            this.dgvpn1madg.DataPropertyName = "TenTL";
            this.dgvpn1madg.HeaderText = "Tên Thể Loại";
            this.dgvpn1madg.MinimumWidth = 6;
            this.dgvpn1madg.Name = "dgvpn1madg";
            // 
            // bttqlnvxoa
            // 
            this.bttqlnvxoa.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bttqlnvxoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttqlnvxoa.Location = new System.Drawing.Point(19, 142);
            this.bttqlnvxoa.Margin = new System.Windows.Forms.Padding(4);
            this.bttqlnvxoa.Name = "bttqlnvxoa";
            this.bttqlnvxoa.Size = new System.Drawing.Size(115, 47);
            this.bttqlnvxoa.TabIndex = 26;
            this.bttqlnvxoa.Text = "Xóa";
            this.bttqlnvxoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttqlnvxoa.UseVisualStyleBackColor = false;
            this.bttqlnvxoa.Click += new System.EventHandler(this.bttqlnvxoa_Click);
            // 
            // btsua
            // 
            this.btsua.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btsua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btsua.Location = new System.Drawing.Point(19, 84);
            this.btsua.Margin = new System.Windows.Forms.Padding(4);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(115, 50);
            this.btsua.TabIndex = 24;
            this.btsua.Text = "Sửa";
            this.btsua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btsua.UseVisualStyleBackColor = false;
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
            // 
            // bttthemmoi
            // 
            this.bttthemmoi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bttthemmoi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttthemmoi.Location = new System.Drawing.Point(19, 27);
            this.bttthemmoi.Margin = new System.Windows.Forms.Padding(4);
            this.bttthemmoi.Name = "bttthemmoi";
            this.bttthemmoi.Size = new System.Drawing.Size(115, 49);
            this.bttthemmoi.TabIndex = 23;
            this.bttthemmoi.Text = "Thêm Mới";
            this.bttthemmoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttthemmoi.UseVisualStyleBackColor = false;
            this.bttthemmoi.Click += new System.EventHandler(this.bttthemmoi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(299, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Thể Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(299, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Thể Loại";
            // 
            // frm9TheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QL_THUVIEN2.Properties.Resources._2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(721, 544);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm9TheLoai";
            this.Text = "Thể Loại";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button bttqlnvxoa;
        private System.Windows.Forms.Button btsua;
        private System.Windows.Forms.Button bttthemmoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvpn1madg;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.TextBox ma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbtk;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.LinkLabel btht;
    }
}