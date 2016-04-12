namespace MainForm
{
    partial class KetNoiDaTa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KetNoiDaTa));
            this.servertxt = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ketnoiclick = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.logintxt = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.passtxt = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MainForm.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.servertxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logintxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passtxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // servertxt
            // 
            this.servertxt.Location = new System.Drawing.Point(125, 182);
            this.servertxt.Name = "servertxt";
            this.servertxt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servertxt.Properties.Appearance.Options.UseFont = true;
            this.servertxt.Size = new System.Drawing.Size(253, 24);
            this.servertxt.TabIndex = 0;
            this.servertxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Duongdantext_KeyPress);
            this.servertxt.Validated += new System.EventHandler(this.Duongdantext_Validated);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(36, 185);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tên server : ";
            // 
            // ketnoiclick
            // 
            this.ketnoiclick.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketnoiclick.Appearance.Options.UseFont = true;
            this.ketnoiclick.Image = ((System.Drawing.Image)(resources.GetObject("ketnoiclick.Image")));
            this.ketnoiclick.Location = new System.Drawing.Point(193, 302);
            this.ketnoiclick.Name = "ketnoiclick";
            this.ketnoiclick.Size = new System.Drawing.Size(116, 35);
            this.ketnoiclick.TabIndex = 2;
            this.ketnoiclick.Text = "Kết nối";
            this.ketnoiclick.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(24, 232);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 16);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Tên đăng nhập : ";
            // 
            // logintxt
            // 
            this.logintxt.Location = new System.Drawing.Point(145, 229);
            this.logintxt.Name = "logintxt";
            this.logintxt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logintxt.Properties.Appearance.Options.UseFont = true;
            this.logintxt.Size = new System.Drawing.Size(233, 24);
            this.logintxt.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(56, 262);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 16);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Mật khẩu : ";
            // 
            // passtxt
            // 
            this.passtxt.Location = new System.Drawing.Point(145, 259);
            this.passtxt.Name = "passtxt";
            this.passtxt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passtxt.Properties.Appearance.Options.UseFont = true;
            this.passtxt.Properties.UseSystemPasswordChar = true;
            this.passtxt.Size = new System.Drawing.Size(233, 24);
            this.passtxt.TabIndex = 8;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(174, 30);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(135, 132);
            this.pictureEdit1.TabIndex = 10;
            // 
            // KetNoiDaTa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 372);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.logintxt);
            this.Controls.Add(this.ketnoiclick);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.servertxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "KetNoiDaTa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kết nối cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.ketnoidata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servertxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logintxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passtxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit servertxt;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton ketnoiclick;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit logintxt;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit passtxt;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
    }
}