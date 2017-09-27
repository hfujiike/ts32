using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T32
{
    public partial class Form2 : Form
    {

        // 設定条件データの dictionary の作成
        static Dictionary<string, string> D_jo = new Dictionary<string, string>()
        {
            {"pv","FGK32FM 7.1.1.1707"},
            {"make","FGK-SYSTEMS"},
        };

        // 実行ホルダ
        static string s_apathfull;             // 実行fullﾊﾟｽ
        static string s_apath;                 // 実行ﾊﾟｽ

        // その他
        static string s_jfile0;                // 条件ファイル0
        static string s_sendm;                 // 送信方法　M=Outlook/D=intraSERVER

        // メッセージ用
        static string s_ermes = "";



        public Form2()
        {
            InitializeComponent();
        }

        public void WBox(string e1, string e2)
        {
            MessageBox.Show(e1 + "\r\n" + e2,
                    "FILE配布",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private bool check_mail_address(string m_addr)
        {
            //ﾒｰﾙｱﾄﾞﾚｽのﾁｪｯｸ　

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


        public void a21_yomikomi()
        {
            // ==== 条件データFを読み、設定条件データの dictionary を格納

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
                string s_hname;
                string s_hport;
                string s_from_ma;
                string s_Lkey;
                string s_hid;
                string s_hpw;
                string s_ssl;

                D_jo.TryGetValue("hname", out s_hname);
                D_jo.TryGetValue("hport", out s_hport);
                D_jo.TryGetValue("from_ma", out s_from_ma);
                D_jo.TryGetValue("Lkey", out s_Lkey);
                D_jo.TryGetValue("hid", out s_hid);
                D_jo.TryGetValue("hpw", out s_hpw);
                D_jo.TryGetValue("ssl", out s_ssl);
                D_jo.TryGetValue("sendm", out s_sendm);

                TB_hname.Text = s_hname;
                TB_hport.Text = s_hport;
                TB_from_ma.Text = s_from_ma;
                TB_Lkey.Text = s_Lkey;
                TB_hid.Text = s_hid;
                TB_hpw.Text = s_hpw;

                if (s_ssl == "Y")
                {
                    CF_ssl.Checked = true;
                }
                else
                {
                    CF_ssl.Checked = false;
                }

                if (s_sendm == "M")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }

                return;

            }
            catch (Exception ex)
            {
                WBox(s_ermes, ex.Message);
                return;
            }
        }


        public void a22_check()
        {
            // ==== チェック

            s_ermes = "メール送信ホストID";
            D_jo["hid"] = TB_hid.Text;

            s_ermes = "メール送信ホストパスワード";
            D_jo["hpw"] = TB_hpw.Text;

            s_ermes = "メール送信ホストSSL";
            D_jo["ssl"] = "N";
            if (CF_ssl.Checked)
            {
                D_jo["ssl"] = "Y";
            }

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

            TB_hname_mes.Text = "受付ました。ここで通信確認はしていません。";
            TB_hport_mes.Text = "本番の送信で確認されます。";

            s_ermes = "ホスト登録アドレスチェック";
            D_jo["from_ma"] = TB_from_ma.Text;
            if (!check_mail_address(TB_from_ma.Text))
            {
                WBox(s_ermes, "送信者アドレスとして正しくない。\r\n入れなおしてください。");
            }

            s_ermes = "ホスト送信方式チェック";
            if (radioButton1.Checked)
            {
                s_sendm = "M";
                D_jo["sendm"] = s_sendm;
            }
            if (radioButton2.Checked)
            {
                s_sendm = "D";
                D_jo["sendm"] = s_sendm;
            }

            // ライセンスキー (shimoren 3189) + (YYMM 1707) + (t3200)  = 8096
            s_ermes = "ライセンスキー";
            D_jo["Lkey"] = TB_Lkey.Text;
            if (TB_Lkey.Text == "fgk8096")
            {
                WBox(s_ermes, "照合しています。十分にメールが送信可能です。");
            }
            else
            {
                WBox(s_ermes, "照合していません。試供モードで1回10メールまで送信可能");
            }
        }



        public void a23_kakidashi()
        {
            // ==== 条件のファイルの書き出し　
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

                TB_hname_mes.Text = "登録または修正を";
                TB_hport_mes.Text = "開始してください。";

                return;
            }
            catch (Exception ex)
            {
                WBox(s_ermes, ex.Message);

                return;
            }
        }


        public void a24_radio()
        {
            // ==== 送信方式による入力用表示変更

            if (s_sendm == "M")
            {
                TB_hname.ReadOnly = true;
                TB_hport.ReadOnly = true;
                TB_hid.ReadOnly = true;
                TB_hpw.ReadOnly = true;
            }
            else
            {
                TB_hname.ReadOnly = false;
                TB_hport.ReadOnly = false;
                TB_hid.ReadOnly = false;
                TB_hpw.ReadOnly = false;
            }
        }


        private void CB_set_Click(object sender, EventArgs e)
        {
            // ==== チェックと書き出し

            a22_check();

            a23_kakidashi();

            a24_radio();

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            // ==== form load process

            s_apathfull = System.Reflection.Assembly.GetExecutingAssembly().Location;
            s_apath = Path.GetDirectoryName(s_apathfull);

            s_jfile0 = s_apath + @"\T32jouken0.txt";

            TB_hname_mes.Text = "登録または修正する場合は";
            TB_hport_mes.Text = "表示ボタンをクリックください。";

            a21_yomikomi();

            a24_radio();

        }

        private void CB_disp_Click(object sender, EventArgs e)
        {
            // ==== hyouji

            a21_yomikomi();

            a24_radio();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                s_sendm = "M";
            }
            else
            {
                s_sendm = "D";
            }

            a24_radio();
        }
    }
    // ----------------------------------------------------------------
    // ----------
    // ----------
}
