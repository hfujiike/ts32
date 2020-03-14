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
            this.CB_dir_ten = new System.Windows.Forms.Button();
            this.TB_dir_ten = new System.Windows.Forms.TextBox();
            this.CB_pfile_ma = new System.Windows.Forms.Button();
            this.TB_pfile_ma = new System.Windows.Forms.TextBox();
            this.TB_mdaimei = new System.Windows.Forms.TextBox();
            this.TB_mhonbun = new System.Windows.Forms.TextBox();
            this.TB_mes = new System.Windows.Forms.TextBox();
            this.CB_send = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label_pv = new System.Windows.Forms.Label();
            this.CB_settei = new System.Windows.Forms.Button();
            this.CB_hozon = new System.Windows.Forms.Button();
            this.CB_end = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "データファイル宛先別一括メール送信\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(37, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "アドレスファイル(CSV)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(103, 145);
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
            this.label4.Location = new System.Drawing.Point(103, 172);
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
            this.label5.Location = new System.Drawing.Point(56, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "添付ファイルホルダ";
            // 
            // CB_dir_ten
            // 
            this.CB_dir_ten.Location = new System.Drawing.Point(187, 99);
            this.CB_dir_ten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_dir_ten.Name = "CB_dir_ten";
            this.CB_dir_ten.Size = new System.Drawing.Size(59, 29);
            this.CB_dir_ten.TabIndex = 6;
            this.CB_dir_ten.Text = "参照";
            this.CB_dir_ten.UseVisualStyleBackColor = true;
            this.CB_dir_ten.Click += new System.EventHandler(this.CB_dir_ten_Click);
            // 
            // TB_dir_ten
            // 
            this.TB_dir_ten.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_dir_ten.Location = new System.Drawing.Point(253, 100);
            this.TB_dir_ten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_dir_ten.Name = "TB_dir_ten";
            this.TB_dir_ten.Size = new System.Drawing.Size(572, 24);
            this.TB_dir_ten.TabIndex = 7;
            // 
            // CB_pfile_ma
            // 
            this.CB_pfile_ma.Location = new System.Drawing.Point(187, 61);
            this.CB_pfile_ma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_pfile_ma.Name = "CB_pfile_ma";
            this.CB_pfile_ma.Size = new System.Drawing.Size(59, 29);
            this.CB_pfile_ma.TabIndex = 8;
            this.CB_pfile_ma.Text = "参照";
            this.CB_pfile_ma.UseVisualStyleBackColor = true;
            this.CB_pfile_ma.Click += new System.EventHandler(this.CB_pfile_ma_Click);
            // 
            // TB_pfile_ma
            // 
            this.TB_pfile_ma.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_pfile_ma.Location = new System.Drawing.Point(253, 68);
            this.TB_pfile_ma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_pfile_ma.Name = "TB_pfile_ma";
            this.TB_pfile_ma.Size = new System.Drawing.Size(572, 24);
            this.TB_pfile_ma.TabIndex = 9;
            // 
            // TB_mdaimei
            // 
            this.TB_mdaimei.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_mdaimei.Location = new System.Drawing.Point(187, 135);
            this.TB_mdaimei.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_mdaimei.Name = "TB_mdaimei";
            this.TB_mdaimei.Size = new System.Drawing.Size(639, 24);
            this.TB_mdaimei.TabIndex = 11;
            // 
            // TB_mhonbun
            // 
            this.TB_mhonbun.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_mhonbun.Location = new System.Drawing.Point(187, 168);
            this.TB_mhonbun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_mhonbun.Multiline = true;
            this.TB_mhonbun.Name = "TB_mhonbun";
            this.TB_mhonbun.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_mhonbun.Size = new System.Drawing.Size(639, 179);
            this.TB_mhonbun.TabIndex = 12;
            // 
            // TB_mes
            // 
            this.TB_mes.Location = new System.Drawing.Point(49, 360);
            this.TB_mes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_mes.Multiline = true;
            this.TB_mes.Name = "TB_mes";
            this.TB_mes.ReadOnly = true;
            this.TB_mes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_mes.Size = new System.Drawing.Size(677, 162);
            this.TB_mes.TabIndex = 13;
            // 
            // CB_send
            // 
            this.CB_send.Location = new System.Drawing.Point(735, 31);
            this.CB_send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_send.Name = "CB_send";
            this.CB_send.Size = new System.Drawing.Size(91, 29);
            this.CB_send.TabIndex = 14;
            this.CB_send.Text = "送信";
            this.CB_send.UseVisualStyleBackColor = true;
            this.CB_send.Click += new System.EventHandler(this.CB_send_ClickAsync);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(47, 341);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "実行状況";
            // 
            // label_pv
            // 
            this.label_pv.AutoSize = true;
            this.label_pv.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_pv.Location = new System.Drawing.Point(23, 531);
            this.label_pv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_pv.Name = "label_pv";
            this.label_pv.Size = new System.Drawing.Size(66, 14);
            this.label_pv.TabIndex = 17;
            this.label_pv.Text = "ヴァージョン";
            // 
            // CB_settei
            // 
            this.CB_settei.Location = new System.Drawing.Point(581, 31);
            this.CB_settei.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_settei.Name = "CB_settei";
            this.CB_settei.Size = new System.Drawing.Size(69, 29);
            this.CB_settei.TabIndex = 18;
            this.CB_settei.Text = "設定";
            this.CB_settei.UseVisualStyleBackColor = true;
            this.CB_settei.Click += new System.EventHandler(this.CB_settei_Click);
            // 
            // CB_hozon
            // 
            this.CB_hozon.Location = new System.Drawing.Point(658, 31);
            this.CB_hozon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_hozon.Name = "CB_hozon";
            this.CB_hozon.Size = new System.Drawing.Size(69, 29);
            this.CB_hozon.TabIndex = 19;
            this.CB_hozon.Text = "保存";
            this.CB_hozon.UseVisualStyleBackColor = true;
            this.CB_hozon.Click += new System.EventHandler(this.CB_hozon_Click);
            // 
            // CB_end
            // 
            this.CB_end.Location = new System.Drawing.Point(505, 32);
            this.CB_end.Name = "CB_end";
            this.CB_end.Size = new System.Drawing.Size(69, 29);
            this.CB_end.TabIndex = 20;
            this.CB_end.Text = "終了";
            this.CB_end.UseVisualStyleBackColor = true;
            this.CB_end.Click += new System.EventHandler(this.CB_end_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 556);
            this.Controls.Add(this.CB_end);
            this.Controls.Add(this.CB_hozon);
            this.Controls.Add(this.CB_settei);
            this.Controls.Add(this.label_pv);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CB_send);
            this.Controls.Add(this.TB_mes);
            this.Controls.Add(this.TB_mhonbun);
            this.Controls.Add(this.TB_mdaimei);
            this.Controls.Add(this.TB_pfile_ma);
            this.Controls.Add(this.CB_pfile_ma);
            this.Controls.Add(this.TB_dir_ten);
            this.Controls.Add(this.CB_dir_ten);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "FILE配布";
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
        private System.Windows.Forms.Button CB_dir_ten;
        private System.Windows.Forms.TextBox TB_dir_ten;
        private System.Windows.Forms.Button CB_pfile_ma;
        private System.Windows.Forms.TextBox TB_pfile_ma;
        private System.Windows.Forms.TextBox TB_mdaimei;
        private System.Windows.Forms.TextBox TB_mhonbun;
        private System.Windows.Forms.TextBox TB_mes;
        private System.Windows.Forms.Button CB_send;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_pv;
        private System.Windows.Forms.Button CB_settei;
        private System.Windows.Forms.Button CB_hozon;
        private System.Windows.Forms.Button CB_end;
    }
}

