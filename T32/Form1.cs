using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using static System.Console;

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
            {"JDATA3","p=FGK32FM"},
            {"JDATA4","m=FGK-SYSTEMS"},
        };

        // 受信者アドレス dictionary の作成
        static readonly Dictionary<string, string> D_ma = new Dictionary<string, string>();

        // メッセージ関係
        public string s_pos = "";
        public string s_er = "";
        public string s_scmes = "";
        public string s_mlog = "";

        // 実行ホルダ
        static string s_apathfull;             // 実行fullﾊﾟｽ
        static string s_apath;                 // 実行ﾊﾟｽ

        // 参照される　設定項目 jouken0
        public string s_hname = "";            // SMTP ホスト名
        public string s_hport = "";            // SMTP ポート
        public string s_from_ma = "";          // 送信者メールアドレス
        public string s_hid = "";              // ホストのユーザID
        public string s_hpw = "";              // ホストのユーザパスワード
        public string s_SecureSO ="";          // SecureSocketOptions 選択
        public string pd_work;                 // 作業ホルダ
        public string s_test1;                  // テスト条件1
        public string s_test2;                  // テスト条件2

        // 参照される　送信項目 jouken1
        static string pf_jouken1;              // 条件ファイル1
        static string pf_jouken2;              // 条件ファイル2
        static string pf_data;                 // 添付データファイル 
        static string s_bcol;                  // 分割キーカラム
        static string s_btitle;                // 分割キータイトル
        static string pf_maddress;              // アドレスファイル
        static string s_mdaimei;               // メール題名
        static string s_mhonbun;               // メール本文

        // 関係ファイル
        public string pf_logcon;               // メインの制御処理
        public string pf_logmail;              // メール送信
        public string pd_BunkatsuDATA;         // 分割データファイル
        public string pf_status;               // 状況ファイル

        // フォーム1
        public Form1()
        {
            InitializeComponent();
        }

        // ==== メッセージボックス　エラー
        public void EBox(string e1, string e2)
        {  
            MessageBox.Show(e1 + "\r\n" + e2,
                    "ERROR(Excel分割male送信)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        // ==== メッセージボックス　警告
        public void WBox(string e1, string e2)
        {
            MessageBox.Show(e1 + "\r\n" + e2,
                    "Warning(Excel分割male送信)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        // ==== 数値の範囲内チェック
        public Boolean Suucheck(string s1, int n1, int n2)
        {
            Boolean b_rv = false;
            string s_work = s1.Trim();

            if (double.TryParse(s_work, out double d_work))
            {
                if (d_work >= n1)
                {
                    if (d_work <= n2)
                    {
                        b_rv = true;
                    }
                }
            }
            return b_rv;
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

            pf_jouken1 = s_apath + @"\T32jouken1.txt";
            pf_jouken2 = s_apath + @"\T32jouken2.txt";

            pf_status = s_apath + @"\T32status.txt";

            label_pv.Text = s_pv;

            return s_rv;
        }

        // 条件データ表示
        public string A02_joukendisp()
        {
            string s_rv = "";
            try
            {
                s_pos = "a02 01 jouken disp ";
                s_scmes += " \r\n" + s_pos;
                // 分割送信詳細表示
                TB_tenfile.Text = pf_data;
                TB_BCol.Text = s_bcol;
                TB_BTitle.Text = s_btitle;
                TB_pfile_ma.Text = pf_maddress;
                TB_mdaimei.Text = s_mdaimei;
                // メール題名と本文表示 
                TB_mhonbun.Text = s_mhonbun;
                // ヴァージョン表示
                label_pv.Text = s_pv;

                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_pos, ex.Message);
                s_scmes += "\r\n" + s_pos + ex.Message;

                return s_rv;
            }
        }

        // 条件データFを読み、設定条件データの dictionary へ格納
        public string A01_joukenyomikomi()
        {
            string s_rv = "";
            string s_rec;
            string[] a_item;

            try
            {
                s_pos = "a01 01 jouken1 yomikomi ";
                s_scmes += " \r\n" + s_pos;

                // 分割送信詳細条件　取得
                if (File.Exists(pf_jouken1))
                {
                    using (FileStream FS_j1 = new FileStream(
                        pf_jouken1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_j1 = new StreamReader(FS_j1))
                    {
                        while (SR_j1.Peek() >= 0)
                        {
                            s_pos = "a01 03 jouken1 file read";
                            s_rec = SR_j1.ReadLine();
                            s_rec += ",,,,";
                            a_item = s_rec.Split(',');
                            if (D_jo.ContainsKey(a_item[0]))
                            {
                                D_jo[a_item[0]] = a_item[1];
                            } else {
                                D_jo.Add(a_item[0], a_item[1]);
                            }
                        }
                        SR_j1.Close();
                    }
                }
                else
                {
                    // ファイルがないとき
                    s_pos = "a01 04 jouken1 file nashi";
                    s_scmes += " \r\n" + s_pos;
                }
                D_jo.TryGetValue("hname", out s_hname);
                D_jo.TryGetValue("hport", out s_hport);
                D_jo.TryGetValue("from_ma", out s_from_ma);
                D_jo.TryGetValue("hid", out s_hid);
                D_jo.TryGetValue("hpw", out s_hpw);
                D_jo.TryGetValue("SecureSO", out s_SecureSO);
                D_jo.TryGetValue("workdir", out pd_work);
                D_jo.TryGetValue("test1", out s_test1);
                D_jo.TryGetValue("test2", out s_test2);
                D_jo.TryGetValue("pfile_da", out pf_data);
                D_jo.TryGetValue("bcol", out s_bcol);
                D_jo.TryGetValue("btitle", out s_btitle);
                D_jo.TryGetValue("pfile_ma", out pf_maddress);
                D_jo.TryGetValue("mdaimei", out s_mdaimei);

                // メール本文のファイル
                s_pos = "a01 11 jouken2 yomikomi ";
                s_scmes += " \r\n" + s_pos;
                if (File.Exists(pf_jouken2))
                {
                    using (FileStream FS_jouken = new FileStream(
                        pf_jouken2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_jouken = new StreamReader(FS_jouken))
                    {
                        s_pos = "a01 12 jouken2 file read";
                        s_mhonbun = SR_jouken.ReadToEnd();
                        SR_jouken.Close();
                    }
                }
                else
                {
                    // メール本文ファイルがないとき
                    s_pos = "a01 91 jouken file nashi";
                    s_scmes += " \r\n" + s_pos;
                }

                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_pos, ex.Message);
                s_scmes += "\r\n" + s_pos + ex.Message;

                return s_rv;
            }
        }

        // ==== 条件データの画面から格納とチェック
        public string A03_jcheck()
        {
            string s_rv = "";
            string s_check;
            string s_checks = "";
            try
            {
                s_pos = "a03 01 jcheck";
                s_scmes += " \r\n" + s_pos;

                // ==== チェック関係

                s_pos = "a03 21 error check ";
                s_check = "添付ファイル項目記述";
                pf_data = TB_tenfile.Text;
                if (pf_data == "")
                {                    
                    EBox(s_pos, s_check + " が空");
                    s_checks += " \r\n" + s_pos + s_check + " が空";
                }
                if (!(Regex.IsMatch(pf_data, @"^[!-~]*$")))
                {
                    EBox(s_pos, s_check + " に全角文字あり");
                    s_checks += " \r\n" + s_pos + s_check + " に全角文字あり";
                }
                else if (!File.Exists(pf_data))
                {
                    s_pos = "a03 22 error check ";
                    EBox(s_pos, s_check + " は無");
                    s_checks += " \r\n" + s_pos + s_check + " は無";
                }

                s_pos = "a03 23 error check ";
                s_check = "分割列位置数値";
                s_bcol = TB_BCol.Text;
                if (!Suucheck(s_bcol, 1, 9))
                {                    
                    EBox(s_pos, s_check + " が空");
                    s_checks += " \r\n" + s_pos + s_check + " が空";
                }

                s_pos = "a03 24 error check ";
                s_check = "分割列タイトル";
                s_btitle = TB_BTitle.Text;
                if (s_btitle == "")
                {
                    EBox(s_pos, s_check + " が空");
                    s_checks += " \r\n" + s_pos + s_check + " が空";
                }

                s_pos = "a03 31 error check ";
                s_check = "アドレスファイル項目";
                pf_maddress = TB_pfile_ma.Text;             
                if (pf_maddress == "")
                {
                    EBox(s_pos, s_check + " が空");
                    s_checks += " \r\n" + s_pos + s_check + " が空";
                }
                else if (!File.Exists(pf_maddress))
                {
                    EBox(s_pos, s_check + " 有無");
                    s_checks += " \r\n" + s_pos + s_check + " 有無";
                }

                s_pos = "a03 33 error check ";
                s_check = "メール題名の項目";
                s_mdaimei = TB_mdaimei.Text;
                if (s_mdaimei == "")
                {                    
                    EBox(s_pos, s_check + " は空");
                    s_checks += " \r\n" + s_pos + s_check + " は空";
                }

                s_pos = "a03 34 error check ";
                s_check = "メール本文の項目";
                s_mhonbun = TB_mhonbun.Text;
                if (s_mhonbun == "")
                {                    
                    EBox(s_pos, s_check + " は空");
                    s_checks += " \r\n" + s_pos + s_check + " は空";
                }

                if ( s_checks != "")
                {
                    s_rv = "ERROR " + s_checks;
                    s_scmes += s_checks;
                }

                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_pos, ex.Message);
                s_scmes += " \r\n" + s_pos + ex.Message;
                
                return s_rv;
            }
        }

        // ==== 設定条件データ 書き出し
        public string A04_joukenkakidashi()
        {
            string s_rv = "";

            try
            {
                s_pos = "a04 01 条件項目 jouken1 kakidashi";
                s_scmes += " \r\n" + s_pos;

                D_jo["hname"] = s_hname;
                D_jo["hport"] = s_hport;
                D_jo["from_ma"] = s_from_ma;
                D_jo["hid"] = s_hid;
                D_jo["hpw"] = s_hpw;
                D_jo["SecureSO"] = s_SecureSO;
                D_jo["workdir"] = pd_work;
                D_jo["pfile_da"] = pf_data;
                D_jo["bcol"] = s_bcol;
                D_jo["btitle"] = s_btitle;
                D_jo["pfile_ma"] = pf_maddress;
                D_jo["mdaimei"] = s_mdaimei;

                string s_rec;
                using (FileStream FS_jw = new FileStream(pf_jouken1, FileMode.Create))
                using (StreamWriter SW_jw = new StreamWriter(FS_jw))
                {
                    foreach (var px in D_jo)
                    {
                        s_rec = px.Key + "," + px.Value + ",";
                        SW_jw.WriteLine(s_rec);
                    }
                    SW_jw.Close();
                }

                s_pos = "a04 21 本文 jouken2 kakidashi";
                s_scmes += " \r\n" + s_pos;

                using (FileStream FS_jw = new FileStream(pf_jouken2, FileMode.Create))
                using (StreamWriter SW_jw = new StreamWriter(FS_jw))
                {
                    SW_jw.Write(s_mhonbun);
                    SW_jw.Close();
                }

                TB_mes.Text = "保存しました。";
                TB_mes.Focus();
                TB_mes.ScrollToCaret();

                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_pos, ex.Message);
                s_scmes += " \r\n" + s_pos + ex.Message;
                s_rv = "ERROR ";
                return s_rv;
            }
        }

        // ==== アドレスファイルをアレイへ取り込み
        public string A51_bubcheck()
        {
            string s_status = "check";
            using (FileStream FS_status = new FileStream(
                pf_status, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader SR_status = new StreamReader(FS_status))
            {
                s_status = SR_status.ReadToEnd();
                SR_status.Close();
            }
            return s_status;
        }

        // ==== アドレスファイルをアレイへ取り込み
        public string A52_addressfile()
        {
            string s_rv = "";
            int i_rec_ma = 0;
            int i_rec_erma = 0;

            try
            {
                s_pos = "A52 01 アドレス file read ";
                s_scmes += " \r\n" + s_pos;

                IWorkbook oXBa = WorkbookFactory.Create(pf_maddress);

                s_pos = "A52 02 address sheet object get:" + pf_maddress;
                s_scmes += "\r\n" + s_pos;
                ISheet oXSa = oXBa.GetSheetAt(0);

                // 調査:シートで使用されている行の最終行インデックス
                int i_asheetend = oXSa.LastRowNum;

                s_pos = "A52 04 address sheetend row: " + i_asheetend.ToString();
                s_scmes += "\r\n" + s_pos;

                string s_key;
                string s_add;
                string s_adds = "";

                int xrow;
                for (xrow = 0; xrow <= i_asheetend; xrow++)
                {
                    string s_cva = "";
                    string s_cvb = "";

                    IRow wrow = oXSa.GetRow(xrow);
                    if (wrow != null)
                    {
                        ICell wcella = wrow.GetCell(0);
                        switch (wcella.CellType)
                        {
                            case CellType.String:
                                s_cva = wcella.StringCellValue;
                                break;
                            case CellType.Numeric:
                                s_cva = wcella.NumericCellValue.ToString();
                                break;
                            default:
                                break;
                        }
                        ICell wcellb = wrow.GetCell(1);
                        switch (wcellb.CellType)
                        {
                            case CellType.String:
                                s_cvb = wcellb.StringCellValue;
                                break;
                            case CellType.Numeric:
                                s_cvb = wcellb.NumericCellValue.ToString();
                                break;
                            default:
                                break;
                        }
                    }

                    s_key = s_cva.Trim();
                    s_add = s_cvb.Trim();
                    if (Check_mail_address(s_add))
                    {                        
                       if (D_ma.ContainsKey(s_key))
                       {
                            s_scmes += ":";
                            // すてに受信先コードが登録されている
                            s_adds += s_add + ":";
                            D_ma[s_key] = s_adds;
                            i_rec_ma++;
                        }
                        else
                        {
                            s_scmes += ".";
                            // 受信先コードがキー新規
                            s_adds = s_add + ":";
                            D_ma.Add(s_key, s_adds);
                            i_rec_ma++;
                        }
                    }
                    else
                    {
                        i_rec_erma++;
                    }
                }

                s_pos = "A52 91 アドレス count= " + i_rec_ma.ToString() + "  E= " + i_rec_erma.ToString();
                s_scmes += " \r\n" + s_pos;
                return s_rv;

            }
            catch (Exception ex)
            {
                EBox(s_pos, ex.Message);
                s_scmes += " \r\n" + s_pos + ex.Message;

                s_rv = "ERROR ";
                return s_rv;
            }

        }

        // ==== メール送信
        public async Task<string> A53_mailsendAsync()
        {
            // 添付ファイル名等をアレイへ取り込み　対応するアドレスへメール送信
            string s_rv = "";

            int i_count_tenp = 0; // 添付ファイル数
            int i_count_mail;     // メール送信数

            string s_mlogRec;
            string s_mailA;

            s_pos = "A53 01 send Mailprocess start ";
            s_scmes += " \r\n" + s_pos;

            Encoding myEnc = Encoding.GetEncoding("iso-2022-jp");

            try
            {
                pd_BunkatsuDATA = pd_work + @"\BunkatsuDATA";
                // 添付ファイルをholderを調べる
                i_count_mail = 0;
                foreach (string s_pfile_ten in System.IO.Directory.GetFiles(pd_BunkatsuDATA))
                {
                    await Task.Delay(500);

                    // オブジェクト MimeKit.MimeMessage の作成
                    var oMail = new MimeKit.MimeMessage();

                    //送信者
                    s_pos = "A53 11 送信者 " + s_from_ma;
                    s_scmes += " \r\n" + s_pos;
                    oMail.From.Add(new MimeKit.MailboxAddress("", s_from_ma));

                    //件名
                    string s_msubject = D_jo["mdaimei"];
                    s_pos = "A53 12 件名 " + s_msubject;
                    s_scmes += " \r\n" + s_pos;
                    oMail.Headers.Replace(MimeKit.HeaderId.Subject, myEnc, s_msubject);

                    // 本文の設定
                    MimeKit.TextPart oTextPart = new MimeKit.TextPart("plain");
                    oTextPart.SetText(myEnc, s_mhonbun);
                    s_pos = "A53 13 添付 " + s_pfile_ten;
                    s_scmes += " \r\n" + s_pos;
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
                    s_pos = "A53 14 Multipartオブジェクト格納 ";
                    oMail.Body = oMultipart;

                    // 受信者アドレス準備のため、ファイル前の送信先グループのコードを見る
                    i_count_tenp++;
                    string s_file_t = Path.GetFileName(s_pfile_ten);  // ファイル名 
                    string[] a_head = s_file_t.Split('_');            // 送信先グループのコード
                    s_pos = "A53 15 file= " + s_file_t;
                    s_scmes += " \r\n" + s_pos;

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
                                s_mailA = a_mad[i];
                                oMail.To.Add(new MimeKit.MailboxAddress("", s_mailA));
                                s_pos = "A53 16 ToAddress: " + s_mailA + " ";
                                s_scmes += "\r\n" + s_pos;
                                DateTime dt = DateTime.Now;
                                string s_date = dt.ToString("yy/MM/dd-HH:mm:ss");
                                s_mlogRec = s_date + " D=" + s_file_t + "\tA=" + s_mailA;
                                s_mlog += "\r\n" + s_mlogRec;
                                TB_mes.Text = s_mlogRec;
                                TB_mes.Focus();
                                TB_mes.ScrollToCaret();
                            }
                        }
                        
                        // SMTPサーバーとポートを指定
                        s_pos = "A53 17 SMTP host: " + s_hname + " port: " + s_hport + " SecureSO: " + s_SecureSO;
                        s_scmes += " \r\n" + s_pos;
                        int i_port = int.Parse(s_hport);
                        s_pos = "A53 18 host id: " + s_hid + " host pw: " + s_hpw + " ";
                        s_scmes += " \r\n" + s_pos;
                        i_count_mail++;

                        // 送信本体
                        if (s_test1 == "sendskip")
                        {
                            //メールをテストで送信しない
                            s_scmes += "  SKIP";
                        }
                        else
                        {
                            // メール送信 smtp オブジェクト作成
                            using (var oSMTP = new MailKit.Net.Smtp.SmtpClient())
                            {
                                switch (s_SecureSO)
                                {
                                    case "S":
                                        await oSMTP.ConnectAsync(s_hname, i_port, MailKit.Security.SecureSocketOptions.SslOnConnect);
                                        s_pos = "A53 22 AuthenticateAsync: ";
                                        await oSMTP.AuthenticateAsync(s_hid, s_hpw);
                                        s_pos = "A53 23 send: ";
                                        await oSMTP.SendAsync(oMail);
                                        await oSMTP.DisconnectAsync(true);
                                        break;
                                    case "T":
                                        await oSMTP.ConnectAsync(s_hname, i_port, MailKit.Security.SecureSocketOptions.StartTls);
                                        s_pos = "A53 24 AuthenticateAsync: ";
                                        await oSMTP.AuthenticateAsync(s_hid, s_hpw);
                                        s_pos = "A53 25 send: ";
                                        await oSMTP.SendAsync(oMail);
                                        await oSMTP.DisconnectAsync(true);
                                        break;
                                    default:
                                        await oSMTP.ConnectAsync(s_hname, i_port, MailKit.Security.SecureSocketOptions.Auto);
                                        s_pos = "A53 26 AuthenticateAsync: ";
                                        await oSMTP.AuthenticateAsync(s_hid, s_hpw);
                                        s_pos = "A53 27 send: ";
                                        await oSMTP.SendAsync(oMail);
                                        await oSMTP.DisconnectAsync(true);
                                        break;
                                }

                            }
                        }
                    }
                    else
                    {
                        // 送信できない添付ファイル
                         s_pos = "A53 33     (NO ADDRESS) SKIP ";
                         s_scmes += "\r\n" + s_pos;
                         s_mlogRec = "                  D=" + s_file_t + "\tNOADDRESS  ";
                         s_mlog += "\r\n" + s_mlogRec;
                         TB_mes.Text = s_mlogRec;
                         TB_mes.Focus();
                         TB_mes.ScrollToCaret();
                    }                    
                }

                if (i_count_tenp == 0)
                {
                    EBox(s_pos, "添付ファイルがりません。");
                    s_rv = "ERROR";
                }

                s_pos = "A53 91 ";
                if (i_count_mail > 0)
                {
                    s_mlogRec = "mail send count: " + i_count_mail.ToString();                    
                }
                else
                {
                    s_mlogRec = "mail send count:zero";
                    s_rv = "ERROR";
                }
                s_scmes += "\r\n" + s_pos + s_mlogRec;
                s_mlog += "\r\n" + s_mlogRec;
                TB_mes.Text = s_mlogRec + "\r\n送信処理終了";
                TB_mes.Focus();
                TB_mes.ScrollToCaret();
                return s_rv;
            }
            catch (Exception ex)
            {
                EBox(s_pos, ex.Message);
                s_scmes += " \r\n" + s_pos + ex.Message;

                s_rv = "ERROR ";
                return s_rv;
            }
        }

        // ==== 最終処理
        public void A91_end(string m1)
        { 
            if (m1 == "")
            {
                s_scmes += " \r\n" + "A91 91 正常終了 ";
            }
            else
            {
                s_scmes += " \r\n" + "A91 91 中断 ";
            }

            pf_logcon = s_apath + @"\T32logcon.txt";
            using (FileStream FS_logcon = new FileStream(pf_logcon, FileMode.Create))
            using (StreamWriter SW_logcon = new StreamWriter(FS_logcon))
            {
                SW_logcon.Write(s_scmes);
                SW_logcon.Close();
            }

            DateTime dt = DateTime.Now;
            string s_YMDHm = dt.ToString("yyMMddHHmm");
            pf_logmail = pd_work + @"\mailsendlog_" + s_YMDHm + ".txt";
            using (FileStream FS_logmail = new FileStream(pf_logmail, FileMode.Create))
            using (StreamWriter SW_logmail = new StreamWriter(FS_logmail))
            {
                SW_logmail.Write(s_mlog);
                SW_logmail.Close();
            }
        }

        // 呼び出し　条件データFを読み、設定条件データの dictionary へ格納
        private void Form1_Load(object sender, EventArgs e)
        {
            string s_a = "";

            s_a = A00_ini();                           // 起動　ini
            if (s_a == "ERROR")
            {
                A91_end(s_a);                          // 起動　終了処理
                Application.Exit();
            }

            s_a = A01_joukenyomikomi();                // 起動　条件ファイル 1&2 読み込み
            if (s_a == "") s_a = A02_joukendisp();     // 起動　条件データ表示
            if (s_a == "ERROR")
            {
                A91_end(s_a);                          // 起動　終了処理
                Application.Exit();
            }
        }

        // ==== ボタン　送信
        private async void CB_send_ClickAsync(object sender, EventArgs e)
        {
            string s_a = "";

            s_a = A01_joukenyomikomi();                     // 起動　条件ファイル 1&2 読み込み

            if (s_a == "") s_a = A03_jcheck();              // 起動　条件チェック

            if (s_a == "") s_a = A04_joukenkakidashi();     // 起動　条件書き出し

            if (s_a == "")
            {
                Form3 subForm3 = new Form3();
                subForm3.Show();
            }
            s_a = A51_bubcheck();                           // 起動　分割処理終了確認

            if (s_a == "") s_a = A52_addressfile();         // 起動　アドレスファイルの取り込み

            if (s_a == "") s_a = await A53_mailsendAsync(); // 起動　添付ファイル取り込み、設定SMTPで送信

            A91_end(s_a);                                   // 起動　終了処理
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
                pf_maddress = TB_pfile_ma.Text;
            }
            oFD.Dispose();
        }

        // ==== ボタン　設定
        private void CB_settei_Click(object sender, EventArgs e)
        {
            string s_rv;
            s_rv = A04_joukenkakidashi();

            if (s_rv == "")
            {
                Form2 subForm2 = new Form2();
                subForm2.Show();
            }
        }

        // ==== ボタン　保存
        private void CB_hozon_Click(object sender, EventArgs e)
        {
            string s_rv = "";

            if (s_rv == "") s_rv = A01_joukenyomikomi();         // 起動　条件ファイル 1&2 読み込み

            if (s_rv == "") s_rv = A03_jcheck();                 // 起動　条件チェック

            s_rv = A04_joukenkakidashi();                        // 起動　条件ファイルへ書き出し
            if (s_rv != "") EBox("button-hozon", "error");
        }

        // ==== ボタン　終了
        private void CB_end_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==== ボタン  入力ファイル設定
        private void CB_tenfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFDdata = new OpenFileDialog();
            oFDdata.InitialDirectory = @"c:\";
            oFDdata.Title = "入力ファイル設定";

            if (oFDdata.ShowDialog() == DialogResult.OK)
            {
                pf_data = oFDdata.FileName;
            }
            oFDdata.Dispose();
            TB_tenfile.Text = pf_data;
        }
    }
}
