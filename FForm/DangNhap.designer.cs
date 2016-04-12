namespace MainForm.FForm
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.tendntxt = new System.Windows.Forms.TextBox();
            this.passtxt = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.nhotendnchk = new DevExpress.XtraEditors.CheckEdit();
            this.nhomkchk = new DevExpress.XtraEditors.CheckEdit();
            this.tudongdnchk = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.nhotendnchk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhomkchk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tudongdnchk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tendntxt
            // 
            this.tendntxt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendntxt.ForeColor = System.Drawing.Color.Navy;
            this.tendntxt.Location = new System.Drawing.Point(193, 90);
            this.tendntxt.Name = "tendntxt";
            this.tendntxt.Size = new System.Drawing.Size(173, 23);
            this.tendntxt.TabIndex = 3;
            this.tendntxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tendntxt_KeyPress);
            // 
            // passtxt
            // 
            this.passtxt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passtxt.ForeColor = System.Drawing.Color.Navy;
            this.passtxt.Location = new System.Drawing.Point(194, 128);
            this.passtxt.Name = "passtxt";
            this.passtxt.Size = new System.Drawing.Size(173, 23);
            this.passtxt.TabIndex = 4;
            this.passtxt.UseSystemPasswordChar = true;
            this.passtxt.TextChanged += new System.EventHandler(this.passtxt_TextChanged);
            this.passtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passtxt_KeyPress);
            this.passtxt.Validated += new System.EventHandler(this.passtxt_Validated);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(89, 92);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(97, 16);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Tên Đăng Nhập";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(92, 132);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Mật khẩu";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(228, 236);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(116, 27);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Đăng Nhập";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // nhotendnchk
            // 
            this.nhotendnchk.Location = new System.Drawing.Point(226, 161);
            this.nhotendnchk.Name = "nhotendnchk";
            this.nhotendnchk.Properties.Caption = "Nhớ tên đăng nhập";
            this.nhotendnchk.Size = new System.Drawing.Size(118, 19);
            this.nhotendnchk.TabIndex = 9;
            this.nhotendnchk.CheckedChanged += new System.EventHandler(this.nhotendnchk_CheckedChanged);
            // 
            // nhomkchk
            // 
            this.nhomkchk.Location = new System.Drawing.Point(226, 186);
            this.nhomkchk.Name = "nhomkchk";
            this.nhomkchk.Properties.Caption = "Nhớ mật khẩu";
            this.nhomkchk.Size = new System.Drawing.Size(118, 19);
            this.nhomkchk.TabIndex = 10;
            this.nhomkchk.CheckedChanged += new System.EventHandler(this.nhomkchk_CheckedChanged);
            // 
            // tudongdnchk
            // 
            this.tudongdnchk.Location = new System.Drawing.Point(226, 211);
            this.tudongdnchk.Name = "tudongdnchk";
            this.tudongdnchk.Properties.Caption = "Tự động đăng nhập";
            this.tudongdnchk.Size = new System.Drawing.Size(118, 19);
            this.tudongdnchk.TabIndex = 11;
            this.tudongdnchk.CheckedChanged += new System.EventHandler(this.tudongdnchk_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Location = new System.Drawing.Point(212, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(132, 16);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Đăng nhập hệ thống";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl4.Location = new System.Drawing.Point(453, 282);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(96, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Kết nối cơ sở dữ liệu";
            this.labelControl4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelControl4_MouseClick);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(173, 32);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(35, 38);
            this.pictureEdit1.TabIndex = 16;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 298);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.tudongdnchk);
            this.Controls.Add(this.nhomkchk);
            this.Controls.Add(this.nhotendnchk);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.tendntxt);
            this.MaximizeBox = false;
            this.Name = "DangNhap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.Load += new System.EventHandler(this.dangnhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nhotendnchk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhomkchk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tudongdnchk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tendntxt;
        private System.Windows.Forms.TextBox passtxt;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckEdit nhotendnchk;
        private DevExpress.XtraEditors.CheckEdit nhomkchk;
        private DevExpress.XtraEditors.CheckEdit tudongdnchk;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;

        
    }
}