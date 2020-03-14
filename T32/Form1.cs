using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace T32
{
    // フォームクラス
    public partial class Form1 : Form
    {
        public static readonly System.Diagnostics.FileVersionInfo oFVI =
            System.Diagnostics.FileVersionInfo.GetVersionInfo(
            System.Reflection.Assembly.GetExecutingAssembly().Location);

        static readonly string s_pv = oFVI.FileVersion;

        // 設定条件データの dictionary の作成
        static readonly Dictionary<string, string> D_jo = new Dictionary<string, string>()
        {
            {"pid","FGK32FM"},
            {"make","FGK-SYSTEMS"},
        };

        // 受信者アドレス dictionary の作成
        static readonly Dictionary<string, string> D_ma = new Dictionary<string, string>();

        // メッセージ関係
        public string s_pos = "";
        public string s_scmes = "";

        // 実行ホルダ
        static string s_apathfull;             // 実行fullﾊﾟｽ
        static string s_apath;                 // 実行ﾊﾟｽ

        // 参照される
        public string s_hname = "";            // SMTP ホスト名
        public string s_hport = "";            // SMTP ポート
        public string s_from_ma = "";          // 送信者メールアドレス
        public string s_hid = "";              // ホストのユーザID
        public string s_hpw = "";              // ホストのユーザパスワード
        public string s_SecureSO ="";          // SecureSocketOptions 選択

        // その他
        static string s_jfile0;                // 条件ファイル0
        static string s_jfile1;                // 条件ファイル1
        static string s_jfile2;                // 条件ファイル2
        static string s_pfile_ma;              // アドレスファイル
        static string s_dir_ten;               // 添付ホルダ
        static string s_mdaimei;               // メール題名
        static string s_mhonbun;               // メール本文

        // フォーム1
        public Form1()
        {
            InitializeComponent();
        }

        // ==== メッセージボックス　エラー
        public void EBox(string e1, string e2)
        {  
            MessageBox.Show(e1 + "\r\n" + e2,
                    "FILE配布",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        // ==== メッセージボックス　警告
        public void WBox(string e1, string e2)
        {
            MessageBox.Show(e1 + "\r\n" + e2,
                    "FILE配布",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        // ==== ﾒｰﾙｱﾄﾞﾚｽのﾁｪｯｸ
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

        // ==== 初期化
        public string A00_ini()
        {
            string s_rv = "";

            s_pos = "a00 01 ini  ";
            s_scmes += " \r\n" + s_pos;

            s_apathfull = System.Reflection.Assembly.GetExecutingAssembly().Location;
            s_apath = Path.GetDirectoryName(s_apathfull);

            s_jfile0 = s_apath + @"\T32jouken0.txt";
            s_jfile1 = s_apath + @"\T32jouken1.txt";
            s_jfile2 = s_apath + @"\T32jouken2.txt";

            label_pv.Text = s_pv;

            return s_rv;
        }

        // 条件データFを読み、設定条件データの dictionary へ格納
        public string A01_joukenyomikomi()
        {
            string s_rv = "";

            string s_rec = "";
            string[] a_item;

            try
            {
                s_pos = "a01 01 jouken1 yomikomi ";
                s_scmes += " \r\n" + s_pos;

                if (File.Exists(s_jfile1))
                {

                    using (FileStream FS_jouken = new FileStream(
                        s_jfile1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_jouken = new StreamReader(FS_jouken))
                    {
                        while (SR_jouken.Peek() >= 0)
                        {
                            s_pos = "a01 02 jouken1 file read";

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
                    s_pos = "a01 09 jouken file1 nashi";
                    s_scmes += " \r\n" + s_pos;
                }

                s_pos = "a01 11 jouken2 yomikomi ";
                s_scmes += " \r\n" + s_pos;

                if (File.Exists(s_jfile2))
                {

                    using (FileStream FS_jouken = new FileStream(
                        s_jfile2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_jouken = new StreamReader(FS_jouken))
                    {
                        s_pos = "a01 12 jouken2 file read";

                        s_mhonbun = SR_jouken.ReadToEnd();
                        
                        SR_jouken.Close();
                    }

                }
                else
                {
                    // ファイルがないとき
                    s_pos = "a01 91 jouken file nashi";
                    s_scmes += " \r\n" + s_pos;
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
                EBox(s_pos, ex.Message);
                s_scmes += s_pos + ex.Message + "\r\n";
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR";
                return s_rv;
            }
        }

        // ==== 設定条件データ dictionary から画面表示
        public string A02_joukenhyouji()
        {
            string s_rv = "";

            string s_rec = "";
            string[] a_item;

            s_pos = "a02 01 joukenhyouj0 ";
            s_scmes += " \r\n" + s_pos;

            if (File.Exists(s_jfile0))
            {
                using (FileStream FS_j0 = new FileStream(
                    s_jfile0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader SR_jouken = new StreamReader(FS_j0))

                {
                    while (SR_jouken.Peek() >= 0)
                    {
                        s_pos = "a02 02 jouken0 file read";

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
                s_pos = "a02 09 jouken0 file1 nashi";
                s_scmes += " \r\n" + s_pos;
            }

            D_jo.TryGetValue("hname", out s_hname);
            D_jo.TryGetValue("hport", out s_hport);
            D_jo.TryGetValue("from_ma", out s_from_ma);
            D_jo.TryGetValue("hid", out s_hid);
            D_jo.TryGetValue("hpw", out s_hpw);
            D_jo.TryGetValue("SecureSO", out s_SecureSO);

            return s_rv; 
        }

        // ==== 条件データのチェック
        public string A03_jcheck()
        {
            string s_rv = "";

            try
            {
                s_pos = "a03 01 jcheck";
                s_scmes += " \r\n" + s_pos;

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
                // ホストID
                D_jo["hid"] = s_hid;
                // ホストパスワード
                D_jo["hpw"] = s_hpw;

                // ==== チェック関係

                s_pos = "a03 31チェック アドレスファイル";                
                if (TB_pfile_ma.Text == "")
                {
                    EBox(s_pos, "アドレスファイルがありません。");
                    s_rv = "ERROR";
                    s_scmes += " \r\n" + s_pos + s_rv;
                }

                s_pos = "a03 32チェック 添付ホルダ";               
                if (TB_dir_ten.Text == "")
                {
                    EBox(s_pos, "添付ホルダがありません。");
                    s_rv = "ERROR";
                    s_scmes += " \r\n" + s_pos + s_rv;
                }
                
                s_pos = "a03 33 チェック メール題名";                
                if (TB_mdaimei.Text == "")
                {
                    EBox(s_pos, "メール題名がありません。");
                    s_rv = "ERROR";
                    s_scmes += " \r\n" + s_pos + s_rv;
                }

                s_pos = "a03 34 チェック メール本文";
                
                if (TB_mhonbun.Text == "")
                {
                    EBox(s_pos, "メール本文がありません。");
                    s_rv = "ERROR";
                    s_scmes += " \r\n" + s_pos + s_rv;
                }

                s_pos = "a03 35 チェック 送信者アドレス";                
                if (!Check_mail_address(s_from_ma))
                {
                    WBox(s_pos, "正しくないかもしれません?\r\n問題なければこのまま使用します。");
                }
　  　
                s_pos = "a03 36 チェック ホスト名";                
                if (s_hname == "")
                {
                    EBox(s_pos, "ホスト名がありません。");
                    s_rv = "ERROR";
                    s_scmes += " \r\n" + s_pos + s_rv;
                }                

                s_pos = "a03 37 チェック ポート";                
                if (s_hport == "")
                {
                    EBox(s_pos, "ホストのポートがありません。");
                    s_rv = "ERROR";
                    s_scmes += " \r\n" + s_pos + s_rv;
                }

                if ( s_rv != "")                {
                    TB_mes.Text = s_scmes;
                    TB_mes.SelectionStart = TB_mes.Text.Length;
                    TB_mes.Focus();
                    TB_mes.ScrollToCaret();
                }

                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_pos, ex.Message);
                s_scmes += " \r\n" + "a03 91 jcheck";
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                return s_rv;
            }
        }

        // ==== 設定条件データ 書き出し
        public string A04_joukenkakidashi()
        {
            string s_rv = "";

            try
            {
                s_pos = "a04 01 jouken1 kakidashi";
                s_scmes += " \r\n" + s_pos;

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

                s_pos = "a04 02 jouken2 kakidashi";
                s_scmes += " \r\n" + s_pos;

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
                EBox(s_pos, ex.Message);
                s_scmes += " \r\n" + s_pos + ex.Message;
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR ";
                return s_rv;
            }
        }

        // ==== アドレスファイルをアレイへ取り込み
        public string A11_addressfile()
        {
            string s_rv = "";
            string s_rec = "";
            string[] a_item;
            int i_rec_ma = 0;
            int i_rec_erma = 0;

            try
            {
                s_pos = "a11 01 アドレス file read ";
                s_scmes += " \r\n" + s_pos;

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
                        s_rec = SR_address.ReadLine();
                        i_rec_ma++;
                        s_rec += ",,,,";
                        a_item = s_rec.Split(',');
                        s_key = a_item[0];
                        rkey = s_key.Trim();
                        s_add = a_item[1].Trim();

                        if (Check_mail_address(s_add))
                        {
                            if (D_ma.ContainsKey(rkey))
                            {
                                s_scmes += ":";
                                // すてに受信先コードがキー登録されている
                                radd += s_add + ":";
                                D_ma[rkey] = radd;
                            }
                            else
                            {
                                s_scmes += ".";
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

                s_pos = "a11 91 アドレス count= " + i_rec_ma.ToString() + "  E= " + i_rec_erma.ToString();
                s_scmes += " \r\n" + s_pos;
                return s_rv;

            }
            catch (Exception ex)
            {
                EBox(s_pos, ex.Message);
                s_scmes += " \r\n" + s_pos + ex.Message;
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR ";
                return s_rv;
            }

        }

        // ==== メール送信
        public async System.Threading.Tasks.Task<string> A12_mailsendAsync()
        {
                // 添付ファイル名等をアレイへ取り込み　対応するアドレスへメール送信
            string s_rv = "";

            int i_count_tenp = 0; // 添付ファイル数
            int i_count_mail;     // メール送信数

            s_pos = "a12 01 send Mailprocess start ";
            s_scmes += " \r\n" + s_pos;
            TB_mes.Text = s_scmes;
            TB_mes.SelectionStart = TB_mes.Text.Length;
            TB_mes.Focus();
            TB_mes.ScrollToCaret();

            Encoding myEnc = Encoding.GetEncoding("iso-2022-jp");

            try
            {   
                // 添付ファイルをholderを調べる
                i_count_mail = 0;
                foreach (string s_pfile_ten in System.IO.Directory.GetFiles(s_dir_ten))
                {
                    // オブジェクト MimeKit.MimeMessage の作成
                    var oMail = new MimeKit.MimeMessage();

                    //送信者
                    s_pos = "a12 11 送信者 " + s_from_ma + " \r\n";
                    oMail.From.Add(new MimeKit.MailboxAddress("", s_from_ma));

                    //件名
                    string s_msubject = D_jo["mdaimei"];
                    s_pos = "a12 12 件名 " + s_msubject + " \r\n";
                    oMail.Headers.Replace(MimeKit.HeaderId.Subject, myEnc, s_msubject);

                    // 本文の設定
                    MimeKit.TextPart oTextPart = new MimeKit.TextPart("plain");
                    oTextPart.SetText(myEnc, s_mhonbun);
                    s_pos = "a12 13 添付 " + s_pfile_ten + " \r\n";
                    // 添付ファイルを設定
                    var oMimeType = MimeKit.MimeTypes.GetMimeType(s_pfile_ten);
                    // 添付ファイルの拡張子からMIMEタイプを取得する
                    var oAttachment = new MimeKit.MimePart(oMimeType)
                    {
                        Content = new MimeKit.MimeContent(System.IO.File.OpenRead(s_pfile_ten)),
                        ContentDisposition = new MimeKit.ContentDisposition(),
                        ContentTransferEncoding = MimeKit.ContentEncoding.Base64,
                        FileName = System.IO.Path.GetFileName(s_pfile_ten)
                    };
                    // オブジェクト Multipartの作成
                    var oMultipart = new MimeKit.Multipart("mixed")
                    {
                        oTextPart,
                        oAttachment
                    };
                    s_pos = "a12 14 Multipartオブジェクト格納 ";
                    oMail.Body = oMultipart;

                    // 受信者アドレス準備のため、ファイル前の送信先グループのコードを見る
                    i_count_tenp++;
                    string s_file_t = Path.GetFileName(s_pfile_ten);  // ファイル名 
                    string[] a_head = s_file_t.Split('_');            // 送信先グループのコード
                    s_pos = "a12 15 file= " + s_file_t;
                    s_scmes += " \r\n" + s_pos;
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
                                oMail.To.Add(new MimeKit.MailboxAddress("", a_mad[i]));
                                s_pos = "a12 16 ToAddress: " + a_mad[i] + " ";
                                s_scmes += " \r\n" + s_pos;
                            }
                        }

                        // メール送信 smtp オブジェクト作成
                        using (var oSMTP = new MailKit.Net.Smtp.SmtpClient())
                        {
                            // SMTPサーバーを指定
                            s_pos = "a12 17 SMTP host:port " + s_hname + ":" + s_hport + ":" + s_SecureSO;
                            s_scmes += " \r\n" + s_pos;
                            int i_port = int.Parse(s_hport);
                            switch (s_SecureSO)
                            {
                                case "S":
                                    await oSMTP.ConnectAsync(s_hname, i_port, MailKit.Security.SecureSocketOptions.SslOnConnect);
                                    break;
                                case "T":
                                    await oSMTP.ConnectAsync(s_hname, i_port, MailKit.Security.SecureSocketOptions.StartTls);
                                    break;
                                default:
                                    await oSMTP.ConnectAsync(s_hname, i_port, MailKit.Security.SecureSocketOptions.Auto);
                                    break;
                            }
                 
                            // 通信ホスト認証                            
                            if (s_hid != "" && s_hpw != "")
                            {
                                s_pos = "a12 18 NetworkCredential: " + s_hid + "/" + s_hpw + "  ";
                                s_scmes += " \r\n" + s_pos;
                                await oSMTP.AuthenticateAsync(s_hid, s_hpw);
                            }

                            //メールを送信
                            s_pos = "a12 21 send mail ";
                            s_scmes += " \r\n" + s_pos;
                            await oSMTP.SendAsync(oMail);
                            await oSMTP.DisconnectAsync(true);
                            i_count_mail++;
                        }
                    }
                    else
                    {
                        // 送信できない添付ファイル
                         s_pos = "a12 33     (NO ADDRESS) SKIP ";
                         s_scmes += " \r\n" + s_pos;
                    }                    
                }

                if (i_count_tenp == 0)
                {
                    EBox(s_pos, "添付ファイルがりません。");
                    s_rv = "ERROR";
                }

                s_pos = "a12 91 mail send count = " + i_count_mail.ToString();
                s_scmes += " \r\n" + s_pos;
                if (i_count_mail == 0)
                {
                    s_pos = "a12 92 ERROR mail zero ";
                    s_scmes += " \r\n" + s_pos;
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
                EBox(s_pos, ex.Message);
                s_scmes += " \r\n" + s_pos + ex.Message;
                TB_mes.Text = s_scmes;
                TB_mes.SelectionStart = TB_mes.Text.Length;
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                s_rv = "ERROR ";
                return s_rv;
            }
        }

        // ==== 最終処理
        public void A91_end(string m1)
        {
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

        // 呼び出し　条件データFを読み、設定条件データの dictionary へ格納
        private void Form1_Load(object sender, EventArgs e)
        {
            string s_a = "";

            s_a = A00_ini();                           // 起動　ini
            if (s_a == "ERROR") Application.Exit();

            s_a = A01_joukenyomikomi();                // 起動　条件ファイル 1&2 読み込み
            if (s_a == "ERROR") Application.Exit();


        }

        // ==== ボタン　送信
        private async void CB_send_ClickAsync(object sender, EventArgs e)
        {
            string s_a;

            s_a = A02_joukenhyouji();                　// 起動　条件ファイル 0 読み込み

            s_a = A03_jcheck();                        // 起動　条件チェック

            s_a = A04_joukenkakidashi();               // 起動　条件書き出し

            if (s_a == "")
            {
                s_a = A11_addressfile();               // 起動　アドレスファイルの取り込み
            }

            if (s_a == "")
            {
                s_a = await A12_mailsendAsync();       // 起動　添付ファイル取り込み、設定SMTPで送信
            }

            A91_end(s_a);                              // 起動　終了処理

        }

        // ==== 添付ファイルホルダの選択ﾎﾞﾀﾝ
        private void CB_dir_ten_Click(object sender, EventArgs e)
        {
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

        // ==== 宛先アドレスファイルの選択ﾎﾞﾀﾝ
        private void CB_pfile_ma_Click(object sender, EventArgs e)
        {
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

        // ==== ボタン　設定
        private void CB_settei_Click(object sender, EventArgs e)
        {
            Form2 subForm2 = new Form2();
            subForm2.Show();

        }

        // ==== ボタン　保存
        private void CB_hozon_Click(object sender, EventArgs e)
        {
            string s_rv = "";

            s_rv = A02_joukenhyouji();                　// 起動　条件ファイル 0 読み込み

            s_rv = A03_jcheck();

            s_rv = A04_joukenkakidashi();
        }

        // ==== ボタン　終了
        private void CB_end_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
