using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace T32
{
    // フォーム2
    public partial class Form2 : Form
    {
        // 設定条件データの dictionary の作成
        static readonly Dictionary<string, string> D_jo = new Dictionary<string, string>()
        {
            {"jobname","メール送信（ホルダ内ファイルの宛先別の一括送信）"},
            {"make","FGK-SYSTEMS"},
        };

        // 実行ホルダ
        static string s_apathfull;             // 実行fullﾊﾟｽ
        static string s_apath;                 // 実行ﾊﾟｽ

        // その他
        static string s_jfile0;                // 条件ファイル0
        public string s_SecureSO;              // SecureSocketOptions 選択

        // メッセージ用
        static string s_ermes = "";
        
        // form2
        public Form2()
        {
            InitializeComponent();
        }

        // MessageBoxIcon.Warning
        public void WBox(string e1, string e2)
        {
            MessageBox.Show(e1 + "\r\n" + e2,
                    "FILE配布",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        //ﾒｰﾙｱﾄﾞﾚｽのﾁｪｯｸ
        private bool Check_mail_address(string m_addr)
        {
            string s_jo = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$";

            if (System.Text.RegularExpressions.Regex.IsMatch(
                m_addr, s_jo,
                System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // ==== 条件データFを読み、設定条件データの dictionary を格納
        public void A21_yomikomi()
        {
            string s_rec = "";
            string[] a_item;

            try
            {
                s_ermes += "CB_disp_Click 1 ";

                if (File.Exists(s_jfile0))
                {
                    using (FileStream FS_jouken = new FileStream(
                        s_jfile0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_jouken = new StreamReader(FS_jouken))
                    {
                        while (SR_jouken.Peek() >= 0)
                        {
                            s_ermes = "CB_disp_Click 2 ";

                            s_rec = SR_jouken.ReadLine();
                            s_rec += ",,,,";
                            a_item = s_rec.Split(',');
                            string s_djo_k = a_item[0];
                            D_jo[s_djo_k] = a_item[1];
                        }
                        SR_jouken.Close();
                    }

                }

                D_jo.TryGetValue("hname", out string s_hname);
                D_jo.TryGetValue("hport", out string s_hport);
                D_jo.TryGetValue("from_ma", out string s_from_ma);
                D_jo.TryGetValue("hid", out string s_hid);
                D_jo.TryGetValue("hpw", out string s_hpw);
                D_jo.TryGetValue("SecureSO", out s_SecureSO);

                TB_hname.Text = s_hname;
                TB_hport.Text = s_hport;
                TB_from_ma.Text = s_from_ma;
                TB_hid.Text = s_hid;
                TB_hpw.Text = s_hpw;

                switch (s_SecureSO)
                {
                    case "S":
                        RB_SecureSO_A.Checked = false;
                        RB_SecureSO_S.Checked = true;
                        RB_SecureSO_T.Checked = false;
                        break;
                    case "T":
                        RB_SecureSO_A.Checked = false;
                        RB_SecureSO_S.Checked = false;
                        RB_SecureSO_T.Checked = true;
                        break;
                    default:
                        RB_SecureSO_A.Checked = true;
                        RB_SecureSO_S.Checked = false;
                        RB_SecureSO_T.Checked = false;
                        break;
                }

                return;

            }
            catch (Exception ex)
            {
                WBox(s_ermes, ex.Message);
                return;
            }
        }

        // ==== チェック
        public void A22_check()
        {
            s_ermes = "メール送信ホストID";
            D_jo["hid"] = TB_hid.Text;

            s_ermes = "メール送信ホストパスワード";
            D_jo["hpw"] = TB_hpw.Text;

            s_ermes = "メール送信ホスト";
            D_jo["hname"] = TB_hname.Text;
            if (TB_hname.Text == "")
            {
                WBox(s_ermes, "空です?\r\n正しいホスト名を入れてください");
            }

            s_ermes = "メール送信ホストのポート";
            D_jo["hport"] = TB_hport.Text;
            if (TB_hport.Text == "25" || TB_hport.Text == "587" || TB_hport.Text == "465" || TB_hport.Text == "")
            {
                D_jo["hport"] = TB_hport.Text;
            }
            else
            {
                WBox(s_ermes, "設定不可?\r\n正しいポートを入れてください");

            }

            TB_w2_mes1.Text = "受付ました。ここで通信確認はしていません。";
            TB_w2_mes2.Text = "本番の送信で確認されます。";

            s_ermes = "ホスト登録アドレスチェック";
            D_jo["from_ma"] = TB_from_ma.Text;
            if (!Check_mail_address(TB_from_ma.Text))
            {
                WBox(s_ermes, "送信者アドレスとして正しくない。\r\n入れなおしてください。");
            }

            s_ermes = "ホスト送信方式チェック";
            if (RB_SecureSO_A.Checked)
            {
                s_SecureSO = "A";
                D_jo["SecureSO"] = s_SecureSO;
            }
            if (RB_SecureSO_S.Checked)
            {
                s_SecureSO = "S";
                D_jo["SecureSO"] = s_SecureSO;
            }
            if (RB_SecureSO_T.Checked)
            {
                s_SecureSO = "T";
                D_jo["SecureSO"] = s_SecureSO;
            }
        }

        // ==== 条件のファイルの書き出し
        public void A23_kakidashi()
        {
            try
            {
                s_ermes = "CB_disp_Clic 1";

                string s_rec;
                using (FileStream FS_jw = new FileStream(s_jfile0, FileMode.Create))
                using (StreamWriter SW_jw = new StreamWriter(FS_jw))
                {
                    foreach (var px in D_jo)
                    {
                        s_rec = px.Key + "," + px.Value + ",";
                        SW_jw.WriteLine(s_rec);

                    }
                    SW_jw.Close();

                }

                TB_w2_mes1.Text = "設定条件が保存されました。";
                TB_w2_mes2.Text = "";

                return;
            }
            catch (Exception ex)
            {
                WBox(s_ermes, ex.Message);

                return;
            }
        }

        // ==== チェックと書き出し
        private void CB_set_Click(object sender, EventArgs e)
        {
            A22_check();

            A23_kakidashi();

        }

        // ==== form load process
        private void Form2_Load(object sender, EventArgs e)
        {
            s_apathfull = System.Reflection.Assembly.GetExecutingAssembly().Location;
            s_apath = Path.GetDirectoryName(s_apathfull);

            s_jfile0 = s_apath + @"\T32jouken0.txt";

            A21_yomikomi();

            TB_w2_mes1.Text = "現在の設定条件を表示しています。";
            TB_w2_mes2.Text = "";

        }

        // ==== 表示
        private void CB_disp_Click(object sender, EventArgs e)
        {
            A21_yomikomi();

            TB_w2_mes1.Text = "登録された設定条件を再表示しています。";
            TB_w2_mes2.Text = "";
        }

        // Radio 1,2
        private void RB_SecureSO_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_SecureSO_A.Checked)
            {
                s_SecureSO = "A";
            }
            if (RB_SecureSO_S.Checked)
            {
                s_SecureSO = "S";
            }
            if (RB_SecureSO_T.Checked)
            {
                s_SecureSO = "T";
            }
        }

        // 戻るボタン
        private void CB_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    // ----------------------------------------------------------------
    // ----------
    // ---------- 2020/03/04 fgk
}
