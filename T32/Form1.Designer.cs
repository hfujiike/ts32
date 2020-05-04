namespace T32
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_pfile_ma = new System.Windows.Forms.Button();
            this.TB_pfile_ma = new System.Windows.Forms.TextBox();
            this.TB_mdaimei = new System.Windows.Forms.TextBox();
            this.TB_mhonbun = new System.Windows.Forms.TextBox();
            this.TB_mes = new System.Windows.Forms.TextBox();
            this.CB_send = new System.Windows.Forms.Button();
            this.label_pv = new System.Windows.Forms.Label();
            this.CB_settei = new System.Windows.Forms.Button();
            this.CB_hozon = new System.Windows.Forms.Button();
            this.CB_end = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_BCol = new System.Windows.Forms.TextBox();
            this.TB_BTitle = new System.Windows.Forms.TextBox();
            this.CB_tenfile = new System.Windows.Forms.Button();
            this.TB_tenfile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "データファイルの宛先別分割とメール送信\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(89, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "アドレスデータ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(103, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "メール題名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(103, 207);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "メール本文";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(105, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "送信データ";
            // 
            // CB_pfile_ma
            // 
            this.CB_pfile_ma.Location = new System.Drawing.Point(187, 137);
            this.CB_pfile_ma.Margin = new System.Windows.Forms.Padding(4);
            this.CB_pfile_ma.Name = "CB_pfile_ma";
            this.CB_pfile_ma.Size = new System.Drawing.Size(59, 22);
            this.CB_pfile_ma.TabIndex = 8;
            this.CB_pfile_ma.Text = "参照";
            this.CB_pfile_ma.UseVisualStyleBackColor = true;
            this.CB_pfile_ma.Click += new System.EventHandler(this.CB_pfile_ma_Click);
            // 
            // TB_pfile_ma
            // 
            this.TB_pfile_ma.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_pfile_ma.Location = new System.Drawing.Point(254, 137);
            this.TB_pfile_ma.Margin = new System.Windows.Forms.Padding(4);
            this.TB_pfile_ma.Name = "TB_pfile_ma";
            this.TB_pfile_ma.Size = new System.Drawing.Size(572, 24);
            this.TB_pfile_ma.TabIndex = 9;
            // 
            // TB_mdaimei
            // 
            this.TB_mdaimei.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_mdaimei.Location = new System.Drawing.Point(187, 177);
            this.TB_mdaimei.Margin = new System.Windows.Forms.Padding(4);
            this.TB_mdaimei.Name = "TB_mdaimei";
            this.TB_mdaimei.Size = new System.Drawing.Size(639, 24);
            this.TB_mdaimei.TabIndex = 11;
            // 
            // TB_mhonbun
            // 
            this.TB_mhonbun.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_mhonbun.Location = new System.Drawing.Point(187, 203);
            this.TB_mhonbun.Margin = new System.Windows.Forms.Padding(4);
            this.TB_mhonbun.Multiline = true;
            this.TB_mhonbun.Name = "TB_mhonbun";
            this.TB_mhonbun.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_mhonbun.Size = new System.Drawing.Size(639, 179);
            this.TB_mhonbun.TabIndex = 12;
            // 
            // TB_mes
            // 
            this.TB_mes.Location = new System.Drawing.Point(25, 400);
            this.TB_mes.Margin = new System.Windows.Forms.Padding(4);
            this.TB_mes.Multiline = true;
            this.TB_mes.Name = "TB_mes";
            this.TB_mes.ReadOnly = true;
            this.TB_mes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_mes.Size = new System.Drawing.Size(800, 77);
            this.TB_mes.TabIndex = 13;
            // 
            // CB_send
            // 
            this.CB_send.Location = new System.Drawing.Point(735, 13);
            this.CB_send.Margin = new System.Windows.Forms.Padding(4);
            this.CB_send.Name = "CB_send";
            this.CB_send.Size = new System.Drawing.Size(91, 29);
            this.CB_send.TabIndex = 14;
            this.CB_send.Text = "送信";
            this.CB_send.UseVisualStyleBackColor = true;
            this.CB_send.Click += new System.EventHandler(this.CB_send_ClickAsync);
            // 
            // label_pv
            // 
            this.label_pv.AutoSize = true;
            this.label_pv.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_pv.Location = new System.Drawing.Point(22, 489);
            this.label_pv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_pv.Name = "label_pv";
            this.label_pv.Size = new System.Drawing.Size(66, 14);
            this.label_pv.TabIndex = 17;
            this.label_pv.Text = "ヴァージョン";
            // 
            // CB_settei
            // 
            this.CB_settei.Location = new System.Drawing.Point(581, 13);
            this.CB_settei.Margin = new System.Windows.Forms.Padding(4);
            this.CB_settei.Name = "CB_settei";
            this.CB_settei.Size = new System.Drawing.Size(69, 29);
            this.CB_settei.TabIndex = 18;
            this.CB_settei.Text = "設定";
            this.CB_settei.UseVisualStyleBackColor = true;
            this.CB_settei.Click += new System.EventHandler(this.CB_settei_Click);
            // 
            // CB_hozon
            // 
            this.CB_hozon.Location = new System.Drawing.Point(658, 13);
            this.CB_hozon.Margin = new System.Windows.Forms.Padding(4);
            this.CB_hozon.Name = "CB_hozon";
            this.CB_hozon.Size = new System.Drawing.Size(69, 29);
            this.CB_hozon.TabIndex = 19;
            this.CB_hozon.Text = "保存";
            this.CB_hozon.UseVisualStyleBackColor = true;
            this.CB_hozon.Click += new System.EventHandler(this.CB_hozon_Click);
            // 
            // CB_end
            // 
            this.CB_end.Location = new System.Drawing.Point(505, 12);
            this.CB_end.Name = "CB_end";
            this.CB_end.Size = new System.Drawing.Size(69, 29);
            this.CB_end.TabIndex = 20;
            this.CB_end.Text = "終了";
            this.CB_end.UseVisualStyleBackColor = true;
            this.CB_end.Click += new System.EventHandler(this.CB_end_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "分割列位置";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(504, 108);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "分割列タイトル名";
            // 
            // TB_BCol
            // 
            this.TB_BCol.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_BCol.Location = new System.Drawing.Point(363, 104);
            this.TB_BCol.Margin = new System.Windows.Forms.Padding(4);
            this.TB_BCol.Name = "TB_BCol";
            this.TB_BCol.Size = new System.Drawing.Size(92, 24);
            this.TB_BCol.TabIndex = 23;
            // 
            // TB_BTitle
            // 
            this.TB_BTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_BTitle.Location = new System.Drawing.Point(619, 104);
            this.TB_BTitle.Margin = new System.Windows.Forms.Padding(4);
            this.TB_BTitle.Name = "TB_BTitle";
            this.TB_BTitle.Size = new System.Drawing.Size(92, 24);
            this.TB_BTitle.TabIndex = 24;
            // 
            // CB_tenfile
            // 
            this.CB_tenfile.Location = new System.Drawing.Point(187, 76);
            this.CB_tenfile.Margin = new System.Windows.Forms.Padding(4);
            this.CB_tenfile.Name = "CB_tenfile";
            this.CB_tenfile.Size = new System.Drawing.Size(59, 22);
            this.CB_tenfile.TabIndex = 25;
            this.CB_tenfile.Text = "参照";
            this.CB_tenfile.UseVisualStyleBackColor = true;
            this.CB_tenfile.Click += new System.EventHandler(this.CB_tenfile_Click);
            // 
            // TB_tenfile
            // 
            this.TB_tenfile.Location = new System.Drawing.Point(253, 76);
            this.TB_tenfile.Name = "TB_tenfile";
            this.TB_tenfile.Size = new System.Drawing.Size(572, 22);
            this.TB_tenfile.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 509);
            this.Controls.Add(this.TB_tenfile);
            this.Controls.Add(this.CB_tenfile);
            this.Controls.Add(this.TB_BTitle);
            this.Controls.Add(this.TB_BCol);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CB_end);
            this.Controls.Add(this.CB_hozon);
            this.Controls.Add(this.CB_settei);
            this.Controls.Add(this.label_pv);
            this.Controls.Add(this.CB_send);
            this.Controls.Add(this.TB_mes);
            this.Controls.Add(this.TB_mhonbun);
            this.Controls.Add(this.TB_mdaimei);
            this.Controls.Add(this.TB_pfile_ma);
            this.Controls.Add(this.CB_pfile_ma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "dMail-Send";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CB_pfile_ma;
        private System.Windows.Forms.TextBox TB_pfile_ma;
        private System.Windows.Forms.TextBox TB_mdaimei;
        private System.Windows.Forms.TextBox TB_mhonbun;
        private System.Windows.Forms.TextBox TB_mes;
        private System.Windows.Forms.Button CB_send;
        private System.Windows.Forms.Label label_pv;
        private System.Windows.Forms.Button CB_settei;
        private System.Windows.Forms.Button CB_hozon;
        private System.Windows.Forms.Button CB_end;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_BCol;
        private System.Windows.Forms.TextBox TB_BTitle;
        private System.Windows.Forms.Button CB_tenfile;
        private System.Windows.Forms.TextBox TB_tenfile;
    }
}

