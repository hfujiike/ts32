using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace T32
{
    public partial class Form1 : Form
    {

        static System.Diagnostics.FileVersionInfo oFVI =
            System.Diagnostics.FileVersionInfo.GetVersionInfo(
            System.Reflection.Assembly.GetExecutingAssembly().Location);

        static string s_pv = oFVI.FileVersion;

        // 設定条件データの dictionary の作成
        static Dictionary<string, string> D_jo = new Dictionary<string, string>()
        {
            {"pid","FGK32FM"},
            {"make","FGK-SYSTEMS"},
        };

        // 受信者アドレス dictionary の作成
        static Dictionary<string, string> D_ma = new Dictionary<string, string>();


        // メッセージ関係
        static string s_ermes = "";
        static string s_scmes = "";

        // 実行ホルダ
        static string s_apathfull;             // 実行fullﾊﾟｽ
        static string s_apath;                 // 実行ﾊﾟｽ

        // 参照される
        public string s_hname = "";            // SMTP ホスト名
        public string s_hport = "";            // SMTP ポート
        public string s_from_ma = "";          // 送信者メールアドレス
        public string s_Lkey = "";             // ライセンスキー
        public string s_hid = "";              // ホストのユーザID
        public string s_hpw = "";              // ホストのユーザパスワード
        public string s_sendm ="";             // SSL
        public bool b_ssl = false;             // SSL

        // その他
        static string s_jfile0;                // 条件ファイル0
        static string s_jfile1;                // 条件ファイル1
        static string s_jfile2;                // 条件ファイル2
        static bool b_shikyoumode = false;     // 試供モード
        static string s_pfile_ma;              // アドレスファイル
        static string s_dir_ten;               // 添付ホルダ
        static string s_mdaimei;               // メール題名
        static string s_mhonbun;               // メール本文
        static string s_ssl;                   // SSL Y/N



        public Form1()
        {
            InitializeComponent();
        }

        public void EBox(string e1, string e2)
        {
            // ==== メッセージボックス　エラー

            MessageBox.Show(e1 + "\r\n" + e2,
                    "FILE配布",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        public void WBox(string e1, string e2)
        {
            // ==== メッセージボックス　警告

            MessageBox.Show(e1 + "\r\n" + e2,
                    "FILE配布",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private bool check_mail_address(string m_addr)
        {
            // ==== ﾒｰﾙｱﾄﾞﾚｽのﾁｪｯｸ　

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


        private static string encode_daimei(string str, System.Text.Encoding enc)
        {
            // ==== メール題名専用のエンコーディング
            {
                string base64str = Convert.ToBase64String(enc.GetBytes(str));
                return string.Format("=?{0}?B?{1}?=", enc.BodyName, base64str);
            }
        }


        public string a00_ini()
        {
            // ==== 初期化

            string s_rv = "";

            s_scmes += "a00 01 ini  ";
            s_scmes += " \r\n" + s_ermes;

            s_apathfull = System.Reflection.Assembly.GetExecutingAssembly().Location;
            s_apath = Path.GetDirectoryName(s_apathfull);

            s_jfile0 = s_apath + @"\T32jouken0.txt";
            s_jfile1 = s_apath + @"\T32jouken1.txt";
            s_jfile2 = s_apath + @"\T32jouken2.txt";

            label_pv.Text = s_pv;

            return s_rv;
        }

        public string a01_joukenyomikomi()
        {
            // 条件データFを読み、設定条件データの dictionary へ格納
            string s_rv = "";

            string s_rec = "";
            string[] a_item;

            try
            {
                s_scmes += "a01 01 jouken1 yomikomi ";
                s_scmes += " \r\n" + s_ermes;

                if (File.Exists(s_jfile1))
                {

                    using (FileStream FS_jouken = new FileStream(
                        s_jfile1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_jouken = new StreamReader(FS_jouken))
                    {
                        while (SR_jouken.Peek() >= 0)
                        {
                            s_ermes = "a01 02 jouken1 file read";

                            s_rec = SR_jouken.ReadLine();
                            s_rec += ",,,,";
                            a_item = s_rec.Split(',');
                            string s_djo_k = a_item[0];
                            D_jo[s_djo_k] = a_item[1];
                        }
                        SR_jouken.Close();
                    }

                }
                else
                {
                    // ファイルがないとき
                    s_scmes += "a01 09 jouken file1 nashi";
                    s_scmes += " \r\n" + s_ermes;
                }

                s_scmes += "a01 11 jouken2 yomikomi ";
                s_scmes += " \r\n" + s_ermes;

                if (File.Exists(s_jfile2))
                {

                    using (FileStream FS_jouken = new FileStream(
                        s_jfile2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_jouken = new StreamReader(FS_jouken))
                    {
                        s_ermes = "a01 12 jouken2 file read";

                        s_mhonbun = SR_jouken.ReadToEnd();
                        
                        SR_jouken.Close();
                    }

                }
                else
                {
                    // ファイルがないとき
                    s_scmes += "a01 91 jouken file nashi";
                    s_scmes += " \r\n" + s_ermes;
                }

                D_jo.TryGetValue("pfile_ma", out s_pfile_ma);
                D_jo.TryGetValue("dir_ten", out s_dir_ten);
                D_jo.TryGetValue("mdaimei", out s_mdaimei);
                
                TB_dir_ten.Text = s_dir_ten;
                TB_mdaimei.Text = s_mdaimei;
                TB_pfile_ma.Text = s_pfile_ma;
                label_pv.Text = s_pv;

                TB_mhonbun.Text = s_mhonbun;

                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                return s_rv;

            }
            catch (Exception ex)
            {
                EBox(s_ermes, ex.Message);
                s_scmes += s_ermes + ex.Message + "\r\n";
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR";
                return s_rv;
            }
        }


        public string a02_joukenhyouji()
        {
            // ==== 設定条件データ dictionary から画面表示

            string s_rv = "";

            string s_rec = "";
            string[] a_item;

            s_scmes += "a02 01 joukenhyouj0 ";
            s_scmes += " \r\n" + s_ermes;

            if (File.Exists(s_jfile0))
            {

                using (FileStream FS_j0 = new FileStream(
                    s_jfile0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader SR_jouken = new StreamReader(FS_j0))

                {
                    while (SR_jouken.Peek() >= 0)
                    {
                        s_ermes = "a02 02 jouken0 file read";

                        s_rec = SR_jouken.ReadLine();
                        s_rec += ",,,,";
                        a_item = s_rec.Split(',');
                        string s_djo_k = a_item[0];
                        D_jo[s_djo_k] = a_item[1];
                    }
                    SR_jouken.Close();
                }

            }
            else
            {
                // ファイルがないとき
                s_scmes += "a02 09 jouken0 file1 nashi";
                s_scmes += " \r\n" + s_ermes;
            }


            D_jo.TryGetValue("hname", out s_hname);
            D_jo.TryGetValue("hport", out s_hport);
            D_jo.TryGetValue("from_ma", out s_from_ma);
            D_jo.TryGetValue("Lkey", out s_Lkey);
            D_jo.TryGetValue("hid", out s_hid);
            D_jo.TryGetValue("hpw", out s_hpw);
            D_jo.TryGetValue("ssl", out s_ssl);
            D_jo.TryGetValue("sendm", out s_sendm);

            // ssl string to bool
            b_ssl = false;
            if (s_ssl == "Y")
            {
                b_ssl = true;
            }

            return s_rv; 
        }


        public string a03_jcheck()
        {
            // ==== 条件データのチェック

            string s_rv = "";

            try
            {
                s_ermes = "a03 01 jcheck";
                s_scmes += " \r\n" + s_ermes;

                s_pfile_ma = TB_pfile_ma.Text;
                s_dir_ten = TB_dir_ten.Text;
                s_mdaimei = TB_mdaimei.Text;

                s_mhonbun = TB_mhonbun.Text;

                D_jo["pfile_ma"] = s_pfile_ma;
                D_jo["dir_ten"] = s_dir_ten;
                D_jo["mdaimei"] = s_mdaimei;
                D_jo["from_ma"] = s_from_ma;

                // ====　設定関係 

                // ホスト名
                D_jo["hname"] = s_hname;
                // ホストポート
                D_jo["hport"] = s_hport;
                // ライセンスキー
                D_jo["Lkey"] = s_Lkey;
                // SSL ( bool to string )
                D_jo["ssl"] = s_ssl;
                s_ssl = "N";
                if (b_ssl)
                {
                    s_ssl = "Y";
                }
                // ホストID
                D_jo["hid"] = s_hid;
                // ホストパスワード
                D_jo["hpw"] = s_hpw;

                // ==== チェック関係

                s_ermes = "a03 31チェック アドレスファイル";                
                if (TB_pfile_ma.Text == "")
                {
                    EBox(s_ermes, "アドレスファイルがありません。");
                    s_rv = "ERROR";
                }

                s_ermes = "a03 32チェック 添付ホルダ";               
                if (TB_dir_ten.Text == "")
                {
                    EBox(s_ermes, "添付ホルダがありません。");
                    s_rv = "ERROR";
                }
                
                s_ermes = "a03 33 チェック メール題名";                
                if (TB_mdaimei.Text == "")
                {
                    EBox(s_ermes, "メール題名がありません。");
                    s_rv = "ERROR";
                }

                s_ermes = "a03 34 チェック メール本文";
                
                if (TB_mhonbun.Text == "")
                {
                    EBox(s_ermes, "メール本文がありません。");
                    s_rv = "ERROR";
                }

                s_ermes = "a03 35 チェック 送信者アドレス";                
                if (!check_mail_address(s_from_ma))
                {
                    WBox(s_ermes, "正しくないかもしれません?\r\n問題なければこのまま使用します。");
                }
　  　
                s_ermes = "a03 36 チェック ホスト名";                
                if (s_hname == "")
                {
                    EBox(s_ermes, "ホスト名がありません。");
                    s_rv = "ERROR";
                }                

                s_ermes = "a03 37 チェック ポート";                
                if (s_hport == "")
                {
                    EBox(s_ermes, "ホストのポートがありません。");
                    s_rv = "ERROR";
                }
                
                s_ermes = "a03 38 チェック ライセンスキー";  // (shimoren 3189) + (YYMM 1707) + (t3200)  = (8096)                
                if (s_Lkey != "fgk8096")
                {
                    b_shikyoumode = true;
                }

                if ( s_rv != "")
                {
                    EBox(s_ermes, "");
                    s_scmes += "a03 81 jcheck" + s_ermes + "\r\n";
                    TB_mes.Text = s_scmes;
                    TB_mes.SelectionStart = TB_mes.Text.Length;
                    TB_mes.Focus();
                    TB_mes.ScrollToCaret();
                }

                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_ermes, ex.Message);
                s_scmes += " \r\n" + s_ermes;
                s_scmes += " \r\n" + "a03 91 jcheck";
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                return s_rv;
            }
        }

        public string a04_joukenkakidashi()
        {
            // ==== 設定条件データ 書き出し

            string s_rv = "";

            try
            {
                s_ermes = "a04 01 jouken1 kakidashi";
                s_scmes += " \r\n" + s_ermes;

                string s_rec;
                using (FileStream FS_jw = new FileStream(s_jfile1, FileMode.Create))
                using (StreamWriter SW_jw = new StreamWriter(FS_jw))
                {
                    foreach (var px in D_jo)
                    {
                        s_rec = px.Key + "," + px.Value + ",";
                        SW_jw.WriteLine(s_rec);

                    }
                    SW_jw.Close();

                }

                s_ermes = "a04 02 jouken2 kakidashi";
                s_scmes += " \r\n" + s_ermes;

                using (FileStream FS_jw = new FileStream(s_jfile2, FileMode.Create))
                using (StreamWriter SW_jw = new StreamWriter(FS_jw))
                {
                    SW_jw.Write(s_mhonbun);

                    SW_jw.Close();

                }

                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_ermes, ex.Message);
                s_scmes += " \r\n" + s_ermes + ex.Message;
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR ";
                return s_rv;
            }
        }

        public string a11_addressfile()
        {
            // ==== アドレスファイルをアレイへ取り込み

            string s_rv = "";

            string s_rec = "";
            string[] a_item;
            int i_rec_ma = 0;
            int i_rec_erma = 0;

            try
            {
                //
                s_ermes = "a11 01 アドレス file open ";
                s_scmes += " \r\n" + s_ermes;

                using (FileStream FS_address = new FileStream(
                    s_pfile_ma, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader SR_address = new StreamReader(FS_address))
                {
                    string rkey = "";
                    string radd = "";
                    string s_key;
                    string s_add;                    

                    while (SR_address.Peek() >= 0)
                    {
                        s_ermes = "a01 02 jouken file read";

                        s_rec = SR_address.ReadLine();
                        i_rec_ma++;
                        s_rec += ",,,,";
                        a_item = s_rec.Split(',');
                        s_key = a_item[0];
                        rkey = s_key.Trim();
                        s_add = a_item[1].Trim();

                        if (check_mail_address(s_add))
                        {
                            if (D_ma.ContainsKey(rkey))
                            {
                                // すてに受信先コードがキー登録されている
                                radd += s_add + ":";
                                D_ma[rkey] = radd;
                            }
                            else
                            {
                                // 受信先コードがキー新規
                                radd = a_item[1] + ":";
                                D_ma.Add(rkey, radd);
                            }
                        }
                        else
                        {
                            i_rec_erma++;
                        }
                    }
                    SR_address.Close();
                }

                s_ermes = "a11 91 アドレス count= " + i_rec_ma.ToString() + "  E= " + i_rec_erma.ToString();
                s_scmes += " \r\n" + s_ermes;
                return s_rv;

            }
            catch (Exception ex)
            {
                EBox(s_ermes, ex.Message);
                s_scmes += " \r\n" + s_ermes + ex.Message;
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR ";
                return s_rv;
            }

        }

        public string a12_tenpufile()
        {
            // ==== メール送信
                // 添付ファイル名等をアレイへ取り込み　対応するアドレスへメール送信

            string s_rv = "";

            int i_count_tenp = 0; // 添付ファイル数
            int i_count_mail = 0; // メール送信数

            s_ermes = "a12 01 send process start ";
            s_scmes += " \r\n" + s_ermes;
            TB_mes.Text = s_scmes;
            TB_mes.SelectionStart = TB_mes.Text.Length;
            TB_mes.Focus();
            TB_mes.ScrollToCaret();

            Encoding myEnc = Encoding.GetEncoding("iso-2022-jp");

            try
            {
                s_ermes = "a12 02 start MailMessage ";
                s_scmes += " \r\n" + s_ermes;
                MailMessage oMM = new MailMessage();

                //送信者
                s_ermes = "a12 11 送信者 " + s_from_ma + " \r\n";
                oMM.From = new MailAddress(s_from_ma);

                //件名                
                string s_mmSubject = D_jo["mdaimei"];
                oMM.Subject = encode_daimei(s_mmSubject, myEnc);

                s_ermes += "a12 12 件名 " + s_mmSubject + " \r\n";

                //本文(.Body)
                string s_mmBody = s_mhonbun;
                AlternateView altView = AlternateView.CreateAlternateViewFromString(
                    s_mmBody, myEnc, System.Net.Mime.MediaTypeNames.Text.Plain);
                altView.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
                oMM.AlternateViews.Add(altView);

                // 添付ファイルをholderを調べる
                i_count_mail = 0;
                foreach (string s_pfile_ten in System.IO.Directory.GetFiles(s_dir_ten))
                {
                    // 添付ファイルの設定
                    s_ermes += "a12 13 添付 " + s_pfile_ten + " \r\n";
                    Attachment attach1 = new Attachment(s_pfile_ten);
                    oMM.Attachments.Add(attach1);  // 添付する

                    // 受信者アドレス準備のため、ファイル前の送信先グループのコードを見る
                    i_count_tenp++;
                    string s_file_t = Path.GetFileName(s_pfile_ten);  // ファイル名 
                    string[] a_head = s_file_t.Split('_');            // 送信先グループのコード
                    s_ermes = "a12 14 file= " + s_file_t;
                    s_scmes += " \r\n" + s_ermes;
                    TB_mes.Text = s_scmes;
                    TB_mes.SelectionStart = TB_mes.Text.Length;
                    TB_mes.Focus();
                    TB_mes.ScrollToCaret();

                    if (D_ma.ContainsKey(a_head[0]))
                    {
                        // アドレス複数をとりだし
                        string s_mas = D_ma[a_head[0]] + "::";
                        string[] a_mad = s_mas.Split(':');
                        for ( int i = 0; i < a_mad.Length; i++ )
                        {
                            if (a_mad[i] != "")
                            {
                                //宛先（To）                                
                                oMM.To.Add(new MailAddress(a_mad[i]));
                                s_ermes = "a12 15 start (To.Add） " + a_mad[i] + " \r\n";
                            }

                        }

                        // メール送信 smtp オブジェクト作成
                        s_ermes = "a12 16 start smtp オブジェクト " + " \r\n";                       
                        SmtpClient oSMTP = new SmtpClient();
                        oSMTP.DeliveryMethod = SmtpDeliveryMethod.Network;

                        // SMTPサーバーを指定
                        oSMTP.Host = s_hname;
                        // ポート
                        s_ermes += "a12 17 start port " + s_hport + " \r\n";
                        oSMTP.Port = int.Parse(s_hport);

                        // 通信ホスト認証                            
                        if (s_hid != "" && s_hpw != "")
                        {
                            s_ermes += "a12 18 start (NetworkCredential) " + s_hid + "/" + s_hpw + " \r\n";
                            oSMTP.Credentials = new System.Net.NetworkCredential(s_hid, s_hpw);
                        }

                        // SSL
                        if (b_ssl)
                        {
                            s_ermes += "a12 19 EnableSsl = true " + " \r\n";
                            oSMTP.EnableSsl = true;
                        }

                        try
                        {
                            // 送信
                            s_ermes += "a12 21 send ";
                            oSMTP.Send(oMM);
                            i_count_mail++;
                        }
                        catch(Exception ex)
                        {
                            s_ermes = "a12 29       SMTP send " + ex.Message + " ERROR ";
                            s_scmes += " \r\n" + s_ermes;
                            TB_mes.Text = s_scmes;
                            TB_mes.SelectionStart = TB_mes.Text.Length;
                            TB_mes.Focus();
                            TB_mes.ScrollToCaret();
                        }

                        // メール送信 smtp オブジェクト破棄
                        oSMTP.Dispose();

                    }
                    else
                    {
                        // 送信できない添付ファイル
                         s_ermes = "a12 33       (NO ADDRESS) SKIP ";
                         s_scmes += " \r\n" + s_ermes;
                    }

                    if (b_shikyoumode)
                    {
                        if ( i_count_tenp > 9 )
                        {
                            s_ermes = "a12 38 試供モードの制限の添付ファイル数10です";
                            s_scmes += " \r\n" + s_ermes;
                            WBox(s_ermes, "中止します。");
                            break;
                        }
                    }
                    
                }

                if (i_count_tenp == 0)
                {
                    EBox(s_ermes, "添付ファイルがりません。");
                    s_rv = "ERROR";
                }

                s_ermes = "a12 91 mail send = " + i_count_mail.ToString();
                s_scmes += " \r\n" + s_ermes;
                if (i_count_mail == 0)
                {
                    s_ermes = "a12 92 ERROR mail zero ";
                    s_scmes += " \r\n" + s_ermes;
                    s_rv = "ERROR";
                }
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();

                oMM.Dispose();

                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_ermes, ex.Message);
                s_scmes += " \r\n" + s_ermes + ex.Message;
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR ";
                return s_rv;
            }
        }


        public string a13_olook()
        {
            // ==== outlook 送信

            string s_rv = "";

            int i_count_tenp = 0; // 添付ファイル数
            int i_count_mail = 0; // メール送信数

            s_ermes = "a13 01 send process start ";
            s_scmes += " \r\n" + s_ermes;
            TB_mes.Text = s_scmes;
            TB_mes.SelectionStart = TB_mes.Text.Length;
            TB_mes.Focus();
            TB_mes.ScrollToCaret();

            try
            {
                s_ermes = "a13 11  Outlook application "  + " \r\n";
                // Create the Outlook application by using inline initialization.
                Outlook.Application oApp = new Outlook.Application();

                // 添付ファイルをholderを調べる
                i_count_mail = 0;
                foreach (string s_pfile_ten in System.IO.Directory.GetFiles(s_dir_ten))
                {
                    // 添付ファイルを取り出す
                    string s_file_t = Path.GetFileName(s_pfile_ten);  // ファイル名 
                    string[] a_head = s_file_t.Split('_');            // 送信先グループのコード
                    s_ermes = "a13 12 file= " + s_file_t;
                    s_scmes += " \r\n" + s_ermes;
                    TB_mes.Text = s_scmes;
                    TB_mes.SelectionStart = TB_mes.Text.Length;
                    TB_mes.Focus();
                    TB_mes.ScrollToCaret();

                    //Create the new message by using the simplest approach.
                    Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                    //件名
                    s_ermes = "a13 13  subjects= " + D_jo["mdaimei"] + " \r\n";
                    string s_mmSubject = D_jo["mdaimei"];
                    oMsg.Subject = s_mmSubject;

                    //本文(.Body)
                    string s_mmBody = s_mhonbun;
                    oMsg.Body = s_mmBody;

                    // 添付ファイルを追加します。
                    string s_DN = s_file_t;
                    int i_AP = (int)oMsg.Body.Length + 1;
                    int i_AT = (int)Outlook.OlAttachmentType.olByValue;
                    s_ermes += "a13 14 添付 " + s_pfile_ten + " \r\n";
                    Outlook.Attachment oAttach = oMsg.Attachments.Add(s_pfile_ten, i_AT, i_AP, s_DN);

                    // 受信者アドレス準備のため、ファイル前の送信先グループのコードを見る
                    i_count_tenp++;
                    
                    s_ermes += "a13 15 send gruoup code= " + a_head[0] + " \r\n";

                    if (D_ma.ContainsKey(a_head[0]))
                    {
                        // アドレス複数をとりだし
                        string s_mas = D_ma[a_head[0]] + "::";
                        string[] a_mad = s_mas.Split(':');
                        string s_mailto = "";
                        for (int i = 0; i < a_mad.Length; i++)
                        {
                            if (a_mad[i] != "")
                            {
                                //宛先
                                s_ermes += "a13 16 start mailto= " + a_mad[i] + " \r\n";
                                s_mailto += a_mad[i] + ";";
                                
                            }

                        } // 宛先ループの終わり

                        try
                        {
                            // 宛先セット
                            oMsg.To = s_mailto;

                            // 送信
                            s_ermes += "a13 21 send " + " \r\n";
                            oMsg.Save();
                            oMsg.Send();
                            i_count_mail++;
                        }
                        catch (Exception ex)
                        {
                            // OutLook送信できない
                            s_ermes = "a13 29       outlook send " + ex.Message + " ERROR ";
                            s_scmes += " \r\n" + s_ermes;
                        }
                          


                        // アドレスのアレイがあるときの範囲の終わり
                    }
                    else
                    {
                        // アドレスのアレイないとき
                        s_ermes = "a13 33       (NO ADDRESS) SKIP";
                        s_scmes += " \r\n" + s_ermes;
                    }


                    // Explicitly release objects
                    oMsg = null;

                    if (b_shikyoumode)
                    {
                        if (i_count_tenp > 9)
                        {
                            s_ermes = "a13 38 試供モードの制限の添付ファイル数10です";
                            s_scmes += " \r\n" + s_ermes;
                            WBox(s_ermes, "中止します。");
                            break;
                        }
                    }

                }  // 添付ファイル取り出しループの終わり

                if (i_count_tenp == 0)
                {
                    EBox(s_ermes, "添付ファイルがりません。");
                }

                //Explicitly release objects
                oApp = null;

                s_ermes = "a13 91 mail send = " + i_count_mail.ToString();
                s_scmes += " \r\n" + s_ermes;
                if (i_count_mail == 0)
                {
                    s_ermes = "a13 92 ERROR mail zero ";
                    s_scmes += " \r\n" + s_ermes;
                    s_rv = "ERROR";
                }

                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();

                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_ermes, ex.Message);
                s_scmes += " \r\n" + s_ermes + ex.Message;
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR";
                return s_rv;
            }
        }


        public void a91_end(string m1)
        {
            // ==== 最終処理

            if (m1 == "")
            {
                s_scmes += " \r\n" + "a91 91 正常終了 ";
            }
            else
            {
                s_scmes += " \r\n" + "a91 91 中断 ";
            }
                        
            TB_mes.Text = s_scmes;
            TB_mes.SelectionStart = TB_mes.Text.Length;
            TB_mes.Focus();
            TB_mes.ScrollToCaret();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // 呼び出し　条件データFを読み、設定条件データの dictionary へ格納

            string s_a = "";

            s_a = a00_ini();                           // 起動　ini
            if (s_a == "ERROR") Application.Exit();

            s_a = a01_joukenyomikomi();                // 起動　条件ファイル 1&2 読み込み
            if (s_a == "ERROR") Application.Exit();


        }

        private void CB_send_Click(object sender, EventArgs e)
        {
            // ==== ボタン　送信

            string s_a = "";

            s_a = a02_joukenhyouji();                　// 起動　条件ファイル 0 読み込み

            s_a = a03_jcheck();                        // 起動　条件チェック

            s_a = a04_joukenkakidashi();               // 起動　条件書き出し

            if (s_a == "")
            {
                s_a = a11_addressfile();               // 起動　アドレスファイルの取り込み
            }

            if (s_a == "")
            {
                if (s_sendm == "M")
                {
                    s_a = a13_olook();                 // 起動　添付ファイル取り込み、Outlookで送信
                }
                else
                {
                    s_a = a12_tenpufile();             // 起動　添付ファイル取り込み、設定SMTPで送信
                }
            }

            a91_end(s_a);                                 // 起動　終了処理

        }



        private void CB_dir_ten_Click(object sender, EventArgs e)
        {
            // ==== 添付ファイルホルダの選択ﾎﾞﾀﾝ

            FolderBrowserDialog oFolderBD1 = new FolderBrowserDialog();
            oFolderBD1.Description = "添付ファイルホルダ設定";
            oFolderBD1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            oFolderBD1.SelectedPath = @"C:\windows\";
            if (oFolderBD1.ShowDialog() == DialogResult.OK)
            {
                TB_dir_ten.Text = oFolderBD1.SelectedPath;
                s_dir_ten = TB_dir_ten.Text;
            }
            oFolderBD1.Dispose();
        }

        private void CB_pfile_ma_Click(object sender, EventArgs e)
        {
            // ==== 宛先アドレスファイルの選択ﾎﾞﾀﾝ

            OpenFileDialog oFD = new OpenFileDialog();
            oFD.InitialDirectory = @"c:\";
            oFD.Title = "宛先アドレスファイル設定";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                TB_pfile_ma.Text = oFD.FileName;
                s_pfile_ma = TB_pfile_ma.Text;
            }
            oFD.Dispose();
        }

        private void CB_settei_Click(object sender, EventArgs e)
        {
            // ==== ボタン　設定

            Form2 subForm2 = new Form2();
            subForm2.Show();

        }

        private void CB_hozon_Click(object sender, EventArgs e)
        {
            // ==== ボタン　保存

            string s_rv = "";

            s_rv = a02_joukenhyouji();                　// 起動　条件ファイル 0 読み込み

            s_rv = a03_jcheck();

            s_rv = a04_joukenkakidashi();
        }
    }
}
