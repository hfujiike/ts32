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
        private static readonly Dictionary<string, string> D_f2jo = new Dictionary<string, string>()
        {
            {"JDATA1","1"},
            {"JDATA2","2"},
        };

        // 実行ホルダ
        static string s_apathfull;             // 実行fullﾊﾟｽ
        static string s_apath;                 // 実行ﾊﾟｽ

        // 設定のパスファイル
        static string pf_jouken;                // 条件ファイル0

        // 設定項目
        public string pd_work;                 // 作業ホルダー
        public string s_hname;                 // ホスト名
        public string s_hport;                 // ホストポート
        public string s_SecureSO;              // SecureSocketOptions 選択
        public string s_from_ma;               // 送信者アドレス
        public string s_hid;                   // ホストid
        public string s_hpw;                   // ホストpassword

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
                    "Warning(Excel分割male送信)",
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
                s_ermes += "A21_yomikomi 1 start ";

                if (File.Exists(pf_jouken))
                {
                    using (FileStream FS_jouken = new FileStream(
                        pf_jouken, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_jouken = new StreamReader(FS_jouken))
                    {
                        while (SR_jouken.Peek() >= 0)
                        {
                            s_ermes = "A21_yomikomi 2 fileread";

                            s_rec = SR_jouken.ReadLine();
                            s_rec += ",,,,";
                            a_item = s_rec.Split(',');
                            if (D_f2jo.ContainsKey(a_item[0]))
                            {
                                D_f2jo[a_item[0]] = a_item[1];
                            }
                            else
                            {
                                D_f2jo.Add(a_item[0], a_item[1]);
                            }
                        }
                        SR_jouken.Close();
                    }
                }

                s_ermes = "A21_yomikomi 3 item set";

                D_f2jo.TryGetValue("hname", out s_hname);
                D_f2jo.TryGetValue("hport", out s_hport);
                D_f2jo.TryGetValue("from_ma", out s_from_ma);
                D_f2jo.TryGetValue("hid", out s_hid);
                D_f2jo.TryGetValue("hpw", out s_hpw);
                D_f2jo.TryGetValue("SecureSO", out s_SecureSO);
                D_f2jo.TryGetValue("workdir", out pd_work);

                s_ermes = "A21_yomikomi 4 item disp";

                TB_hname.Text = s_hname;
                TB_hport.Text = s_hport;
                TB_from_ma.Text = s_from_ma;
                TB_hid.Text = s_hid;
                TB_hpw.Text = s_hpw;
                TB_workdir.Text = pd_work;

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
            D_f2jo["hid"] = TB_hid.Text;

            s_ermes = "メール送信ホストパスワード";
            D_f2jo["hpw"] = TB_hpw.Text;

            s_ermes = "メール送信ホスト";
            D_f2jo["hname"] = TB_hname.Text;
            if (TB_hname.Text == "")
            {
                WBox(s_ermes, "空です?\r\n正しいホスト名を入れてください");
            }

            s_ermes = "メール送信ホストのポート";
            D_f2jo["hport"] = TB_hport.Text;
            if (TB_hport.Text == "25" || TB_hport.Text == "587" || TB_hport.Text == "465" || TB_hport.Text == "")
            {
                D_f2jo["hport"] = TB_hport.Text;
            }
            else
            {
                WBox(s_ermes, "設定不可?\r\n正しいポートを入れてください");
            }

            TB_w2_mes1.Text = "受付ました。ここで通信確認はしていません。";
            TB_w2_mes2.Text = "本番の送信で確認されます。";

            s_ermes = "送信者アドレスチェック";
            D_f2jo["from_ma"] = TB_from_ma.Text;
            if (!Check_mail_address(TB_from_ma.Text))
            {
                WBox(s_ermes, "送信者アドレスとして正しくない。\r\n入れなおしてください。");
            }

            s_ermes = "ホスト送信方式チェック";
            if (RB_SecureSO_A.Checked)
            {
                s_SecureSO = "A";
                D_f2jo["SecureSO"] = s_SecureSO;
            }
            if (RB_SecureSO_S.Checked)
            {
                s_SecureSO = "S";
                D_f2jo["SecureSO"] = s_SecureSO;
            }
            if (RB_SecureSO_T.Checked)
            {
                s_SecureSO = "T";
                D_f2jo["SecureSO"] = s_SecureSO;
            }

            s_ermes = "作業ホルダー";
            D_f2jo["workdir"] = TB_workdir.Text;
            if (TB_workdir.Text == "")
            {
                WBox(s_ermes, "空です?\r\n正しい作業ホルダーを入れてください");
            }
            if (!Directory.Exists(D_f2jo["workdir"]))
            {
                WBox(s_ermes, "ホルダが存在しません。");
            }

        }

        // ==== 条件のファイルの書き出し
        public void A23_kakidashi()
        {
            try
            {
                s_ermes = "A23_kakidashi 1";

                string s_rec;
                using (FileStream FS_jw = new FileStream(pf_jouken, FileMode.Create))
                using (StreamWriter SW_jw = new StreamWriter(FS_jw))
                {
                    foreach (var px in D_f2jo)
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

        // ====ボタン(チェックと書き出し)
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

            pf_jouken = s_apath + @"\T32jouken1.txt";

            A21_yomikomi();

            TB_w2_mes1.Text = "現在の設定条件を表示しています。";
            TB_w2_mes2.Text = "";

        }

        // ====ボタン(再表示)
        private void CB_disp_Click(object sender, EventArgs e)
        {
            A21_yomikomi();

            TB_w2_mes1.Text = "登録された設定条件を再表示しています。";
            TB_w2_mes2.Text = "";
        }

        // ===ボタン(送信条件 Radio A,S,T)
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

        // ===ボタン(戻る)
        private void CB_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===ボタン(作業ホルダ)
        private void CB_workdirset_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog oFolderBDWH = new FolderBrowserDialog();
            oFolderBDWH.Description = "出力ﾌｫﾙﾀﾞ設定";
            oFolderBDWH.RootFolder = System.Environment.SpecialFolder.MyComputer;
            oFolderBDWH.SelectedPath = TB_workdir.Text;
            if (oFolderBDWH.ShowDialog() == DialogResult.OK)
            {
                TB_workdir.Text = oFolderBDWH.SelectedPath;
            }
            oFolderBDWH.Dispose();
        }

    }
    // ----------------------------------------------------------------
    // ----------
    // ---------- 2020/03/04 fgk
}
