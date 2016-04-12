namespace MainForm.FForm
{
    partial class DoiPass
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.matkhaumoitxt = new System.Windows.Forms.TextBox();
            this.matkhaucutxt = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.nhaplaimatkhaumoitxt = new System.Windows.Forms.TextBox();
            this.tentaikhoanlbl = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(498, 339);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(116, 27);
            this.simpleButton1.TabIndex = 17;
            this.simpleButton1.Text = "Đổi mật khẩu";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(315, 240);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 16);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Mật khẩu mới";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(315, 199);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 16);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Mật khẩu cũ";
            // 
            // matkhaumoitxt
            // 
            this.matkhaumoitxt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matkhaumoitxt.ForeColor = System.Drawing.Color.Navy;
            this.matkhaumoitxt.Location = new System.Drawing.Point(460, 237);
            this.matkhaumoitxt.Name = "matkhaumoitxt";
            this.matkhaumoitxt.Size = new System.Drawing.Size(205, 23);
            this.matkhaumoitxt.TabIndex = 14;
            this.matkhaumoitxt.UseSystemPasswordChar = true;
            this.matkhaumoitxt.Validated += new System.EventHandler(this.passtxt_Validated);
            // 
            // matkhaucutxt
            // 
            this.matkhaucutxt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matkhaucutxt.ForeColor = System.Drawing.Color.Navy;
            this.matkhaucutxt.Location = new System.Drawing.Point(460, 197);
            this.matkhaucutxt.Name = "matkhaucutxt";
            this.matkhaucutxt.Size = new System.Drawing.Size(205, 23);
            this.matkhaucutxt.TabIndex = 13;
            this.matkhaucutxt.UseSystemPasswordChar = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl2.Location = new System.Drawing.Point(315, 161);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 16);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Tài khoản : ";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(315, 277);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(140, 16);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Nhập lại mật khẩu mới";
            // 
            // nhaplaimatkhaumoitxt
            // 
            this.nhaplaimatkhaumoitxt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhaplaimatkhaumoitxt.ForeColor = System.Drawing.Color.Navy;
            this.nhaplaimatkhaumoitxt.Location = new System.Drawing.Point(460, 277);
            this.nhaplaimatkhaumoitxt.Name = "nhaplaimatkhaumoitxt";
            this.nhaplaimatkhaumoitxt.Size = new System.Drawing.Size(205, 23);
            this.nhaplaimatkhaumoitxt.TabIndex = 20;
            this.nhaplaimatkhaumoitxt.UseSystemPasswordChar = true;
            // 
            // tentaikhoanlbl
            // 
            this.tentaikhoanlbl.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentaikhoanlbl.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.tentaikhoanlbl.Location = new System.Drawing.Point(515, 161);
            this.tentaikhoanlbl.Name = "tentaikhoanlbl";
            this.tentaikhoanlbl.Size = new System.Drawing.Size(65, 16);
            this.tentaikhoanlbl.TabIndex = 22;
            this.tentaikhoanlbl.Text = "Tài khoản ";
            // 
            // DoiPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 557);
            this.Controls.Add(this.tentaikhoanlbl);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.nhaplaimatkhaumoitxt);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.matkhaumoitxt);
            this.Controls.Add(this.matkhaucutxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoiPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.doipass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox matkhaumoitxt;
        private System.Windows.Forms.TextBox matkhaucutxt;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox nhaplaimatkhaumoitxt;
        private DevExpress.XtraEditors.LabelControl tentaikhoanlbl;
    }
}