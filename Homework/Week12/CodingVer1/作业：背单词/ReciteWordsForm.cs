using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace 作业_背单词
{
    public partial class ReciteWordsForm : Form
    {
        public ReciteWordsForm()
        {
            InitializeComponent();
        }

        private void ReciteWordsForm_Load(object sender, EventArgs e)
        {
            this.Text = "背单词：大学四级 (共收录单词" + GenerateDict().ToString() + "条)";
            DisplayWord();
        }

        //定义泛型，存放单词本的所有行
        private List<string> listEnToCnLines = new List<string>();

        //定义泛型，存放单词本的英语
        private List<string> listEnglish = new List<string>();

        //定义词典，存放单词与对应的汉语
        private Dictionary<string, string> dicEnToCn = new Dictionary<string, string>();

        #region 私有方法：从Excel2013载入xlsx文件  LoadFromExcel(string _excelFileName)      
        private void LoadFromExcel(string _excelFileName)
        {           
            try
            {
                string connectionString = "";
                connectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES'", _excelFileName);
                // If you don't want to show the header row (first row),Use 'HDR=NO' in the string  
                Application.DoEvents();
                string strSQL = "SELECT * FROM [Sheet1$]";

                OleDbConnection excelConnection = new OleDbConnection(connectionString);
                excelConnection.Open(); // This code will open excel file.

                OleDbCommand dbCommand = new OleDbCommand(strSQL, excelConnection);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);

                // create data table
                 DataTable tableWords = new DataTable();
                dataAdapter.Fill(tableWords);
                
                for (int i = 0; i < tableWords.Rows.Count; i++)
                {
                    string ss = "";
                    for (int j = 0; j < tableWords.Columns.Count; j++)
                    {
                        ss += tableWords.Rows[i][j]+" ";
                    }                  
                    listEnToCnLines.Add(ss);
                }

                // dispose used objects
                tableWords.Dispose();
                dataAdapter.Dispose();
                dbCommand.Dispose();

                excelConnection.Close();
                excelConnection.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("载入Excel文件\" {0} \"时出错！\n{1}\n", _excelFileName, ex.Message));               
            }
        }
        #endregion

        private int GenerateDict()
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\College_Grade4.xlsx";
           
            listEnToCnLines.Clear();
            dicEnToCn.Clear();

            LoadFromExcel(path);         


            for (int i = 0; i < listEnToCnLines.Count; i++)
            {
                //使用Split方法 移除空的单个字符
                string[] strArr = listEnToCnLines[i].Split(new char[] { ' ', ' ' }, StringSplitOptions.RemoveEmptyEntries);


                //避免重复添加             
                if (dicEnToCn.Keys.Contains(strArr[0]) == false)
                {
                    //则将数组里的键(英文单词) 和值(中文翻译) 添加到泛型字典里
                    dicEnToCn.Add(strArr[0], strArr[1]);
                    listEnglish.Add(strArr[0]);
                }
            }
            return listEnToCnLines.Count;
        }

        private int dictIndex = 0;

        private void DisplayWord()
        {
            string ch;
            dicEnToCn.TryGetValue(listEnglish[dictIndex], out ch);
            tboEnglishWord.Text = listEnglish[dictIndex];
            tboChinese.Text = ch;
            if (btnRandom.Text == "顺序")
            {
                dictIndex = new Random().Next(0, listEnToCnLines.Count);
            }
            else
            {
                dictIndex++;
                dictIndex = dictIndex >= listEnToCnLines.Count ? 0 : dictIndex;
            }
            trackBarMoveSpeed.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayWord();
        }

        private void trackBarMoveSpeed_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBarMoveSpeed.Value;
        }

        private string pathReciteWordsINI = System.Windows.Forms.Application.StartupPath + "\\ReciteWords.ini";

        private void btnSaveProgress_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter(pathReciteWordsINI, false, System.Text.Encoding.Default);
            if (sw != null)
            {
                sw.WriteLine(dictIndex);
                sw.WriteLine(timer1.Interval);
                MessageBox.Show("保存成功！");
            }
            sw.Close();
        }

        private void btnOpenProgress_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(pathReciteWordsINI, System.Text.Encoding.Default);
            if (sr != null)
            {
                dictIndex = int.Parse(sr.ReadLine());
                timer1.Interval = int.Parse(sr.ReadLine());
                MessageBox.Show("读取成功！");
            }
            sr.Close();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if(btnPause.Text=="暂停")
            {
                btnPause.Text = "继续";
                timer1.Stop();
            }
            else
            {
                btnPause.Text = "暂停";
                timer1.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (btnStop.Text == "停止")
            {
                btnStop.Text = "开始";
                timer1.Enabled = false;
                btnPause.Enabled = false;
                btnOpenProgress.Enabled = false;
                btnSaveProgress.Enabled = false;
                trackBarMoveSpeed.Enabled = false;
            }
            else
            {
                btnStop.Text = "停止";
                timer1.Enabled = true;
                btnPause.Enabled = true;
                btnOpenProgress.Enabled = true;
                btnSaveProgress.Enabled = true;
                trackBarMoveSpeed.Enabled = true;
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (btnRandom.Text == "随机")
            {
                btnRandom.Text = "顺序";

            }
            else
            {
                btnRandom.Text = "随机";
            }
        }

    }
}
