using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;

namespace T32
{
    public partial class Form3 : Form
    {
        // 設定条件データの dictionary の作成
        static readonly Dictionary<string, string> D_jo = new Dictionary<string, string>();

        // 分割アレイ作成
        public ArrayList al_bcode = new ArrayList();    // 分割コード
        public ArrayList al_browtop = new ArrayList();  // エクセル行前削除カラ
        public ArrayList al_browend = new ArrayList();  // エクセル行前削除マデ
        public int i_bcodearray = 0;                    // このアレイの数

        // メッセージ関係
        static string s_pos;
        static string s_er;
        static string s_scmes = "";

        // 実行ホルダ
        static string s_apathfull;             // 実行fullﾊﾟｽ
        static string s_apath;                 // 実行ﾊﾟｽ

        // その他
        static string s_jfile;                 // 条件ファイル
        static int xr_headend;                 // エクセル行　ヘッダーエンド
        static int xr_datatop;                 // エクセル行　データトップ
        static int xr_dataend;                 // エクセル行　データエンド
        static int xr_sheetend;                // エクセル行シートの中の最終行

        // 取得条件
        public string pf_data;                 // 添付元のデータファイルパス
        public int i_xcol;                     // 分割キーのカラム列番号
        public string s_btitle;                // 分割キーのカラム列タイトル名
        public string fp_bunFile;              // 添付ファイル
        public string pd_work;                 // 作業ホルダ

        // 関係ファイル
        public string pf_logbun;               // ログファイル
        public string pf_status;               // 状況ファイル
        public string pd_BunkatsuDATA;         // 分割データファイル

        // 取得条件加工
        public string s_fname;                 // ファイル名

        // ==== メッセージボックス
        static string MBox(string e1, string e2)
        {
            MessageBox.Show(e1 + "\r\n" + e2,
                        "ERROR(Excel分割male送信)",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            return "";
        }

        // ==== 条件データFを読み、設定条件データの dictionary へ格納
        public string A31_joukenyomikomi()
        {
            string s_rv = "";
            string[] a_item;

            s_apathfull = System.Reflection.Assembly.GetExecutingAssembly().Location;
            s_apath = Path.GetDirectoryName(s_apathfull);

            s_jfile = s_apath + @"\T32jouken1.txt";

            try
            {
                if (File.Exists(s_jfile))
                {
                    s_pos = "A31 01 jouken file open ";
                    s_scmes += "\r\n" + s_pos;

                    using (FileStream FS_jouken = new FileStream(
                        s_jfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader SR_jouken = new StreamReader(FS_jouken))
                    {
                        while (SR_jouken.Peek() >= 0)
                        {
                            s_pos = "A31 02 jouken file read";

                            string s_rec = SR_jouken.ReadLine();
                            s_rec += ",,,,";
                            a_item = s_rec.Split(',');
                            D_jo.Add(a_item[0], a_item[1]);
                        }
                        SR_jouken.Close();

                        s_pos = "A31 03 jouken each item set ";
                        s_scmes += "\r\n" + s_pos;
                        pf_data = D_jo["pfile_da"];
                        i_xcol = int.Parse(D_jo["bcol"]);
                        s_btitle = D_jo["btitle"];
                        pd_work = D_jo["workdir"];

                        s_fname = Path.GetFileName(pf_data);
                    }
                }
                else
                {
                    // ファイルがないとき
                    s_er = "jouken file nashi";
                    MBox(s_pos, s_er);
                    s_scmes += "\r\n" + s_pos + s_er;
                    s_rv = "ERROR " + s_pos + s_er;
                }

                return s_rv;

            }
            catch (Exception ex)
            {
                MBox(s_pos, ex.Message);
                s_scmes += "\r\n" + s_pos + ex.Message;
                s_rv = "ERROR " + s_pos + ex.Message;

                return s_rv;
            }
        }

        // ==== インプットのエクセルファイルを調査
        public string A35_excelin()
        {
            string s_rv = "";

            try
            {
                s_pos = "A35 01 excelin ブックオブジェクトを作成 ";
                s_scmes += "\r\n" + s_pos;

                IWorkbook oXBi = WorkbookFactory.Create(pf_data);

                s_pos = "A35 02 excelin シートオブジェクトを作成 sheet:" + pf_data;
                s_scmes += "\r\n" + s_pos;
                ISheet oXS = oXBi.GetSheetAt(0);

                // 調査:シートで使用されている行の最終行インデックス
                s_pos = "A35 03 excelin 調査 1 ";
                s_scmes += "\r\n" + s_pos;
                xr_sheetend = oXS.LastRowNum;

                s_pos = "A35 04 sheetend row: " + xr_sheetend.ToString();
                s_scmes += "\r\n" + s_pos;

                // 分割列
                s_pos = "A35 06 excelin 分割列 ";
                s_scmes += "\r\n" + s_pos;
                
                

                s_scmes += "\r\nA35 07 excelin ヘッダーの終わり調査 ";
                s_scmes += "\r\nA35 07 excelin i_xcol: " + i_xcol.ToString();
                s_scmes += "\r\nA35 07 excelin s_btitle: " + s_btitle;

                s_pos = "A35 09 excelin タイトルcol:" + i_xcol.ToString() + " ";
                s_scmes += "\r\n" + s_pos;
                int xrow;
                for (xrow = 0; xrow < 111; xrow++)
                {
                    s_pos = "A35 09 excelin タイトルrow  " + xrow.ToString();
                    IRow wrow = oXS.GetRow(xrow);
                    if (wrow != null)
                    {
                        s_pos = "A35 09 excelin タイトルcell " + xrow.ToString() + " ";
                        ICell wcell = wrow.GetCell(i_xcol - 1);

                        if (wcell != null)
                        {
                            if (wcell.CellType == CellType.String)
                            {
                                string s_ebun = wcell.StringCellValue;
                                if (s_ebun == s_btitle)
                                {
                                    s_pos = "A35 09 excelin タイトル行  ";
                                    xr_headend = xrow;
                                    break;
                                }
                            }
                        }
                    }
                    if (xrow > 99)
                    {
                        // ヘッダーの終わり（タイトル行）がない
                        s_pos = "A35 12 excelin タイトルrow  " + xrow.ToString() + " ";
                        s_er = "notfined keys title";
                        MBox(s_pos, s_er);
                        s_scmes += "\r\n" + s_pos + s_er;
                        s_rv = "ERROR " + s_pos + s_er;

                        break;
                    }
                }
                s_scmes += "\r\nA35 12 excelin xrow: " + xrow.ToString();
                s_scmes += "\r\nA35 12 excelin xr_headend: " + xr_headend.ToString();
                if (s_rv == "")
                {
                    s_pos = "A35 13 excelin データ部分の endline調査 ";
                    s_scmes += "\r\n" + s_pos;
                    xr_datatop = xr_headend + 1;
                    xr_dataend = xr_sheetend;
                    string s_buncode;
                    s_scmes += "\r\nA35 13 excelin xr_datatop: " + xr_datatop.ToString();
                    s_scmes += "\r\nA35 13 excelin xr_dataend: " + xr_dataend.ToString();
                    for (xrow = xr_datatop; xrow <= xr_sheetend; xrow++)
                    {
                        s_pos = "A35 14 excelin データ部分のデータ部分の終わり xrow= " + xrow.ToString();
                        ICell wcell = oXS.GetRow(xrow - 1).GetCell(i_xcol - 1);
                        if (wcell == null)
                        {
                            // データ部分の終わり
                            xr_dataend = xrow - 1;
                            break;
                        }
                        try
                        {
                            // 数値なら文字列に変換
                            if (wcell.CellType == CellType.Numeric)
                            {
                                s_buncode = wcell.NumericCellValue.ToString();
                                wcell.SetCellValue(s_buncode);
                            }
                        }
                        catch (Exception ex)
                        {
                            MBox(s_pos, ex.Message);
                            s_scmes += "\r\n" + s_pos + ex.Message;
                            s_rv = "ERROR " + s_pos + ex.Message;
                        }
                    }
                }
                if (s_rv == "")
                {
                    s_pos = "A35 17 excelin 分割アレイ作成 ";
                    s_scmes += "\r\n" + s_pos;

                    // データ行の最初
                    string s_ima;
                    string s_mae;
                    //s_ima = oXS.Cells[xr_datatop, i_xcol].Value;
                    ICell wcell = oXS.GetRow(xr_datatop).GetCell(i_xcol - 1);
                    s_ima = wcell.StringCellValue;
                    al_bcode.Add(s_ima);
                    al_browtop.Add(xr_datatop);
                    // データ行の2行目以降
                    for (xrow = xr_datatop + 1; xrow < xr_dataend; xrow++)
                    {
                        s_mae = s_ima;
                        ICell wwcell = oXS.GetRow(xrow - 1).GetCell(i_xcol - 1);
                        s_ima = wwcell.StringCellValue;
                        if (s_ima != s_mae)
                        {
                            // ブレイクした
                            al_browend.Add(xrow - 1);
                            al_bcode.Add(s_ima);
                            al_browtop.Add(xrow);
                            i_bcodearray++;
                        }
                        else
                        {
                            // 同じだ なにもしない                            
                        }
                    }
                    // データ行の最後
                    al_browend.Add(xr_dataend);
                }
                return s_rv;
            }
            catch (Exception ex)
            {
                MBox(s_pos, ex.Message);
                s_scmes += "\r\n" + s_pos + ex.Message;
                s_rv = "ERROR " + s_pos + ex.Message;

                return s_rv;
            }
        }

        // ==== アウトプットのエクセルファイル作成
        public string A36_excelcopy()
        {
            string s_rv = "";
            string s_bcode;
            int i_browtop;
            int i_browend;

            try
            {
                s_pos = "A36 11 excel out horder make    ";
                s_scmes += "\r\n" + s_pos;
                pd_BunkatsuDATA = pd_work + @"\BunkatsuDATA";
                //フォルダ「BunkatsuDATA」があれば削除
                if (Directory.Exists(pd_BunkatsuDATA)) Directory.Delete(pd_BunkatsuDATA, true);
                //フォルダ「BunkatsuDATA」を作成（親がなければ親ごと）
                Directory.CreateDirectory(pd_BunkatsuDATA);
        
                s_pos = "A36 21 excel out start    ";
                s_scmes += "\r\n" + s_pos;
                for (int i = 0; i <= i_bcodearray; i++)
                {
                    s_pos = "A36 22 excel out for  ( " + (i + 1).ToString() + "/" + (i_bcodearray + 1).ToString() + ")";
                    s_scmes += "\r\n" + s_pos;
                    s_bcode = (String)al_bcode[i];
                    i_browtop = (int)al_browtop[i];
                    i_browend = (int)al_browend[i];

                    fp_bunFile = pd_BunkatsuDATA + @"\" + s_bcode + "_" + s_fname;

                    if (File.Exists(fp_bunFile))
                    {
                        File.Delete(fp_bunFile);
                    }

                    s_pos = "A36 23 excel out call(A37_excel_del) ";
                    s_rv = A37_bunExlMake(pf_data,
                        i_browtop, i_browend,
                        xr_datatop, xr_dataend, fp_bunFile);
                }
                s_pos = "A36 91 excel out end ";
                s_scmes += "\r\n" + s_pos;

                return s_rv;
            }
            catch (Exception ex)
            {
                MBox(s_pos, ex.Message);
                s_scmes += "\r\n" + s_pos + ex.Message;
                s_rv = "ERROR " + s_pos + ex.Message;

                return s_rv;
            }
        }

        // ==== アウトプットのエクセルファイル作成と不要行削除
        public string A37_bunExlMake(string xFi, int Brs, int Bre, int Drs, int Dre, string xFo)
        {
            string s_rv = "";

            try
            {
                s_pos = "A37 02 添付用のエクセルブック作成 ";
                var oXBs = WorkbookFactory.Create(xFi);
                ISheet oXSs = oXBs.GetSheetAt(0);

                TB_f3mes.Text = "添付用のエクセルブック作成: " + xFi;
                TB_f3mes.SelectionStart = TB_f3mes.Text.Length;
                TB_f3mes.Focus();
                TB_f3mes.ScrollToCaret();

                string s_delrow;

                if (Dre > Bre)
                {
                    // データ行エンド > 分割部分行エンド
                    // 分割部分の後ろ部分の行幅削除
                    s_delrow = (Bre + 1).ToString() + ":" + (Dre + 1).ToString();
                    s_scmes += "\r\nA37 11 ex back  other rows del: " + s_delrow + " ";

                    for (int i = Bre; i < Dre + 1; i++)
                    {
                        IRow oR = oXSs.GetRow(i);
                        oXSs.RemoveRow(oR);
                        s_scmes += ".";
                    }
                }

                if (Drs < Brs)
                {
                    // データ行スタート < 分割部分行スタート
                    // 分割部分の前部分の行幅削除
                    s_delrow = Drs.ToString() + ":" + (Brs - 1).ToString();
                    s_scmes += "\r\nA37 12 ex front other rows del: " + s_delrow + " ";

                    for (int i = Drs; i < Brs - 1; i++)
                    {
                        IRow oR = oXSs.GetRow(i);
                        oXSs.RemoveRow(oR);
                        s_scmes += ".";
                    }

                    // 前部分削除をつめる
                    oXSs.ShiftRows(Brs - 1, Bre, Drs - Brs + 1);
                }

                // 格納のセーブ
                s_pos = "A37 21 格納のセーブ ";
                s_scmes += "\r\n" + s_pos + " " + xFo;
                using (var f_xf = new FileStream(xFo, FileMode.Create))
                {
                    oXBs.Write(f_xf);
                    f_xf.Close();
                }

                return s_rv;
            }
            catch (Exception ex)
            {
                MBox(s_pos, ex.Message);
                s_scmes += "\r\n" + s_pos + ex.Message;
                s_rv = "ERROR " + s_pos + ex.Message;

                return s_rv;
            }
        }

        // ==== 最終処理
        public void A39_end(string rv)
        {

            s_scmes += "\r\nA39 91  " + rv;

            // log
            pf_logbun = s_apath + @"\T32logbun.txt";
            using (FileStream FS_logbun = new FileStream(pf_logbun, FileMode.Create))
            using (StreamWriter SW_logbun = new StreamWriter(FS_logbun))
            {
                SW_logbun.Write(s_scmes);
                SW_logbun.Close();
            }
            // status
            pf_status = s_apath + @"\T32status.txt";
            using (FileStream FS_status = new FileStream(pf_status, FileMode.Create))
                using (StreamWriter SW_status = new StreamWriter(FS_status))
            {
                SW_status.Write(rv);
                SW_status.Close();
            }
        }

        // フォーム3　InitializeComponent
        public Form3()
        {
            InitializeComponent();
        }

        // フォーム3 LOAD
        private void Form3_Load(object sender, EventArgs e)
        {
            string s_a;

            s_a = A31_joukenyomikomi();                   // 起動　条件ファイル読み込み

            if (s_a == "") s_a = A35_excelin();           // 起動　エクセル読み込み

            if (s_a == "") s_a = A36_excelcopy();         // 起動　エクセル分割コピーと不要行削除とセーブ

            A39_end(s_a);                                 // 起動　終了処理

            this.Close();
        }
    }
}
