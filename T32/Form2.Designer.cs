namespace T32
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_from_ma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_hname = new System.Windows.Forms.TextBox();
            this.CB_set = new System.Windows.Forms.Button();
            this.TB_Lkey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_hport = new System.Windows.Forms.TextBox();
            this.TB_hname_mes = new System.Windows.Forms.TextBox();
            this.TB_hport_mes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_hid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_hpw = new System.Windows.Forms.TextBox();
            this.CF_ssl = new System.Windows.Forms.CheckBox();
            this.CB_disp = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "データファイル一括メール配布（設定）\r\n";
            // 
            // TB_from_ma
            // 
            this.TB_from_ma.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_from_ma.Location = new System.Drawing.Point(95, 65);
            this.TB_from_ma.Name = "TB_from_ma";
            this.TB_from_ma.Size = new System.Drawing.Size(254, 20);
            this.TB_from_ma.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(14, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "送信者アドレス";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(48, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "通信ホストポート";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(64, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "通信ホスト名";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TB_hname
            // 
            this.TB_hname.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hname.Location = new System.Drawing.Point(138, 230);
            this.TB_hname.Name = "TB_hname";
            this.TB_hname.Size = new System.Drawing.Size(254, 20);
            this.TB_hname.TabIndex = 16;
            // 
            // CB_set
            // 
            this.CB_set.Location = new System.Drawing.Point(359, 27);
            this.CB_set.Name = "CB_set";
            this.CB_set.Size = new System.Drawing.Size(68, 23);
            this.CB_set.TabIndex = 17;
            this.CB_set.Text = "登録";
            this.CB_set.UseVisualStyleBackColor = true;
            this.CB_set.Click += new System.EventHandler(this.CB_set_Click);
            // 
            // TB_Lkey
            // 
            this.TB_Lkey.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_Lkey.Location = new System.Drawing.Point(95, 93);
            this.TB_Lkey.Name = "TB_Lkey";
            this.TB_Lkey.Size = new System.Drawing.Size(254, 20);
            this.TB_Lkey.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(21, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "ライセンスキー";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TB_hport
            // 
            this.TB_hport.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hport.Location = new System.Drawing.Point(138, 258);
            this.TB_hport.Name = "TB_hport";
            this.TB_hport.Size = new System.Drawing.Size(61, 20);
            this.TB_hport.TabIndex = 15;
            // 
            // TB_hname_mes
            // 
            this.TB_hname_mes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_hname_mes.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hname_mes.Location = new System.Drawing.Point(16, 314);
            this.TB_hname_mes.Name = "TB_hname_mes";
            this.TB_hname_mes.ReadOnly = true;
            this.TB_hname_mes.Size = new System.Drawing.Size(412, 12);
            this.TB_hname_mes.TabIndex = 20;
            // 
            // TB_hport_mes
            // 
            this.TB_hport_mes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_hport_mes.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hport_mes.Location = new System.Drawing.Point(15, 337);
            this.TB_hport_mes.Name = "TB_hport_mes";
            this.TB_hport_mes.ReadOnly = true;
            this.TB_hport_mes.Size = new System.Drawing.Size(412, 12);
            this.TB_hport_mes.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(65, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "ホスト登録ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TB_hid
            // 
            this.TB_hid.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hid.Location = new System.Drawing.Point(138, 175);
            this.TB_hid.Name = "TB_hid";
            this.TB_hid.Size = new System.Drawing.Size(254, 20);
            this.TB_hid.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(60, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "ホスト登録PW";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TB_hpw
            // 
            this.TB_hpw.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hpw.Location = new System.Drawing.Point(138, 201);
            this.TB_hpw.Name = "TB_hpw";
            this.TB_hpw.Size = new System.Drawing.Size(254, 20);
            this.TB_hpw.TabIndex = 25;
            // 
            // CF_ssl
            // 
            this.CF_ssl.AutoSize = true;
            this.CF_ssl.Location = new System.Drawing.Point(138, 284);
            this.CF_ssl.Name = "CF_ssl";
            this.CF_ssl.Size = new System.Drawing.Size(44, 16);
            this.CF_ssl.TabIndex = 26;
            this.CF_ssl.Text = "SSL";
            this.CF_ssl.UseVisualStyleBackColor = true;
            // 
            // CB_disp
            // 
            this.CB_disp.Location = new System.Drawing.Point(285, 27);
            this.CB_disp.Name = "CB_disp";
            this.CB_disp.Size = new System.Drawing.Size(68, 23);
            this.CB_disp.TabIndex = 27;
            this.CB_disp.Text = "表示";
            this.CB_disp.UseVisualStyleBackColor = true;
            this.CB_disp.Click += new System.EventHandler(this.CB_disp_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(50, 131);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(232, 16);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "送信には自分のPC の Outlook 2016 を使う";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(50, 153);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(223, 16);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.Text = "送信にはイントラネットのSMTPサーバを使う";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 361);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.CB_disp);
            this.Controls.Add(this.CF_ssl);
            this.Controls.Add(this.TB_hpw);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TB_hid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_hport_mes);
            this.Controls.Add(this.TB_hname_mes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Lkey);
            this.Controls.Add(this.CB_set);
            this.Controls.Add(this.TB_hname);
            this.Controls.Add(this.TB_hport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_from_ma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "FILE配布";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_from_ma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_hname;
        private System.Windows.Forms.Button CB_set;
        private System.Windows.Forms.TextBox TB_Lkey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_hport;
        private System.Windows.Forms.TextBox TB_hname_mes;
        private System.Windows.Forms.TextBox TB_hport_mes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_hid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_hpw;
        private System.Windows.Forms.CheckBox CF_ssl;
        private System.Windows.Forms.Button CB_disp;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}