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
            this.TB_hport = new System.Windows.Forms.TextBox();
            this.TB_w2_mes1 = new System.Windows.Forms.TextBox();
            this.TB_w2_mes2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_hid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_hpw = new System.Windows.Forms.TextBox();
            this.CB_disp = new System.Windows.Forms.Button();
            this.RB_SecureSO_A = new System.Windows.Forms.RadioButton();
            this.RB_SecureSO_S = new System.Windows.Forms.RadioButton();
            this.RB_SecureSO_T = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "データファイル一括メール配布（設定）\r\n";
            // 
            // TB_from_ma
            // 
            this.TB_from_ma.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_from_ma.Location = new System.Drawing.Point(184, 82);
            this.TB_from_ma.Margin = new System.Windows.Forms.Padding(4);
            this.TB_from_ma.Name = "TB_from_ma";
            this.TB_from_ma.Size = new System.Drawing.Size(337, 24);
            this.TB_from_ma.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(71, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "送信者アドレス";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(61, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "通信ホストポート";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(81, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "通信ホスト名";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TB_hname
            // 
            this.TB_hname.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hname.Location = new System.Drawing.Point(184, 187);
            this.TB_hname.Margin = new System.Windows.Forms.Padding(4);
            this.TB_hname.Name = "TB_hname";
            this.TB_hname.Size = new System.Drawing.Size(337, 24);
            this.TB_hname.TabIndex = 16;
            // 
            // CB_set
            // 
            this.CB_set.Location = new System.Drawing.Point(479, 34);
            this.CB_set.Margin = new System.Windows.Forms.Padding(4);
            this.CB_set.Name = "CB_set";
            this.CB_set.Size = new System.Drawing.Size(91, 29);
            this.CB_set.TabIndex = 17;
            this.CB_set.Text = "登録";
            this.CB_set.UseVisualStyleBackColor = true;
            this.CB_set.Click += new System.EventHandler(this.CB_set_Click);
            // 
            // TB_hport
            // 
            this.TB_hport.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hport.Location = new System.Drawing.Point(184, 219);
            this.TB_hport.Margin = new System.Windows.Forms.Padding(4);
            this.TB_hport.Name = "TB_hport";
            this.TB_hport.Size = new System.Drawing.Size(80, 24);
            this.TB_hport.TabIndex = 15;
            // 
            // TB_w2_mes1
            // 
            this.TB_w2_mes1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_w2_mes1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_w2_mes1.Location = new System.Drawing.Point(21, 392);
            this.TB_w2_mes1.Margin = new System.Windows.Forms.Padding(4);
            this.TB_w2_mes1.Name = "TB_w2_mes1";
            this.TB_w2_mes1.ReadOnly = true;
            this.TB_w2_mes1.Size = new System.Drawing.Size(549, 15);
            this.TB_w2_mes1.TabIndex = 20;
            // 
            // TB_w2_mes2
            // 
            this.TB_w2_mes2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_w2_mes2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_w2_mes2.Location = new System.Drawing.Point(20, 421);
            this.TB_w2_mes2.Margin = new System.Windows.Forms.Padding(4);
            this.TB_w2_mes2.Name = "TB_w2_mes2";
            this.TB_w2_mes2.ReadOnly = true;
            this.TB_w2_mes2.Size = new System.Drawing.Size(549, 15);
            this.TB_w2_mes2.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(82, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "ホスト登録ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TB_hid
            // 
            this.TB_hid.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hid.Location = new System.Drawing.Point(184, 123);
            this.TB_hid.Margin = new System.Windows.Forms.Padding(4);
            this.TB_hid.Name = "TB_hid";
            this.TB_hid.Size = new System.Drawing.Size(337, 24);
            this.TB_hid.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(76, 164);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "ホスト登録PW";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TB_hpw
            // 
            this.TB_hpw.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_hpw.Location = new System.Drawing.Point(184, 155);
            this.TB_hpw.Margin = new System.Windows.Forms.Padding(4);
            this.TB_hpw.Name = "TB_hpw";
            this.TB_hpw.Size = new System.Drawing.Size(337, 24);
            this.TB_hpw.TabIndex = 25;
            // 
            // CB_disp
            // 
            this.CB_disp.Location = new System.Drawing.Point(380, 34);
            this.CB_disp.Margin = new System.Windows.Forms.Padding(4);
            this.CB_disp.Name = "CB_disp";
            this.CB_disp.Size = new System.Drawing.Size(91, 29);
            this.CB_disp.TabIndex = 27;
            this.CB_disp.Text = "再表示";
            this.CB_disp.UseVisualStyleBackColor = true;
            this.CB_disp.Click += new System.EventHandler(this.CB_disp_Click);
            // 
            // RB_SecureSO_A
            // 
            this.RB_SecureSO_A.AutoSize = true;
            this.RB_SecureSO_A.Checked = true;
            this.RB_SecureSO_A.Location = new System.Drawing.Point(235, 285);
            this.RB_SecureSO_A.Margin = new System.Windows.Forms.Padding(4);
            this.RB_SecureSO_A.Name = "RB_SecureSO_A";
            this.RB_SecureSO_A.Size = new System.Drawing.Size(58, 19);
            this.RB_SecureSO_A.TabIndex = 28;
            this.RB_SecureSO_A.TabStop = true;
            this.RB_SecureSO_A.Text = "Auto";
            this.RB_SecureSO_A.UseVisualStyleBackColor = true;
            this.RB_SecureSO_A.CheckedChanged += new System.EventHandler(this.RB_SecureSO_CheckedChanged);
            // 
            // RB_SecureSO_S
            // 
            this.RB_SecureSO_S.AutoSize = true;
            this.RB_SecureSO_S.Location = new System.Drawing.Point(235, 312);
            this.RB_SecureSO_S.Margin = new System.Windows.Forms.Padding(4);
            this.RB_SecureSO_S.Name = "RB_SecureSO_S";
            this.RB_SecureSO_S.Size = new System.Drawing.Size(90, 19);
            this.RB_SecureSO_S.TabIndex = 29;
            this.RB_SecureSO_S.Text = "Over SSL";
            this.RB_SecureSO_S.UseVisualStyleBackColor = true;
            this.RB_SecureSO_S.CheckedChanged += new System.EventHandler(this.RB_SecureSO_CheckedChanged);
            // 
            // RB_SecureSO_T
            // 
            this.RB_SecureSO_T.AutoSize = true;
            this.RB_SecureSO_T.Location = new System.Drawing.Point(235, 338);
            this.RB_SecureSO_T.Name = "RB_SecureSO_T";
            this.RB_SecureSO_T.Size = new System.Drawing.Size(99, 19);
            this.RB_SecureSO_T.TabIndex = 30;
            this.RB_SecureSO_T.TabStop = true;
            this.RB_SecureSO_T.Text = "STARTTLS";
            this.RB_SecureSO_T.UseVisualStyleBackColor = true;
            this.RB_SecureSO_T.CheckedChanged += new System.EventHandler(this.RB_SecureSO_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(181, 257);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Secure Socket Options";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // CB_back
            // 
            this.CB_back.Location = new System.Drawing.Point(282, 34);
            this.CB_back.Name = "CB_back";
            this.CB_back.Size = new System.Drawing.Size(91, 29);
            this.CB_back.TabIndex = 32;
            this.CB_back.Text = "戻る";
            this.CB_back.UseVisualStyleBackColor = true;
            this.CB_back.Click += new System.EventHandler(this.CB_back_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 451);
            this.Controls.Add(this.CB_back);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RB_SecureSO_T);
            this.Controls.Add(this.RB_SecureSO_S);
            this.Controls.Add(this.RB_SecureSO_A);
            this.Controls.Add(this.CB_disp);
            this.Controls.Add(this.TB_hpw);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TB_hid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_w2_mes2);
            this.Controls.Add(this.TB_w2_mes1);
            this.Controls.Add(this.CB_set);
            this.Controls.Add(this.TB_hname);
            this.Controls.Add(this.TB_hport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_from_ma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox TB_hport;
        private System.Windows.Forms.TextBox TB_w2_mes1;
        private System.Windows.Forms.TextBox TB_w2_mes2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_hid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_hpw;
        private System.Windows.Forms.Button CB_disp;
        private System.Windows.Forms.RadioButton RB_SecureSO_A;
        private System.Windows.Forms.RadioButton RB_SecureSO_S;
        private System.Windows.Forms.RadioButton RB_SecureSO_T;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CB_back;
    }
}