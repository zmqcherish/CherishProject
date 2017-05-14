#region using
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
#endregion

namespace CloudBirdReader
{
    public partial class Form1 : Form
    {
        #region 构造函数
        public Form1()
        {
            InitializeComponent();

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        #endregion


        #region 全局变量
        Microsoft.Office.Interop.Excel.Application excel, excelSorted;
        string excelPath, excelSortedPath;
        string folderPath;
        string fileContent;
        List<string> filesContent = new List<string>();
        string[] worksheetSortedName = new string[] { "微软创新杯", "软妹百科", "软妹贴士", "软妹夜聊", "其他原创", "转发" };
        int ListLength = 0;
        int singalListLength;
        string temp;
        string date;

        Worksheet worksheet, worksheetSorted;
        Workbook wbook, wbookSorted;
        Microsoft.Office.Interop.Excel.Range er;
        Microsoft.Office.Interop.Excel.Range er2;
        #endregion



        #region btnAnalysis_Click
        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                #region 初始化Excel
                excel = new Microsoft.Office.Interop.Excel.Application();
                wbook = excel.Workbooks.Add();
                worksheet = (Worksheet)wbook.Worksheets[1];
                excel.Cells[1, 1] = "类型";
                excel.Cells[1, 2] = "时间";
                excel.Cells[1, 3] = "内容";
                excel.Cells[1, 4] = "被转账号";
                excel.Cells[1, 5] = "转发链接";
                #endregion

                ListLength = 0;
                progressBar1.Maximum = filesContent.Count * 5;
                progressBar1.Value = 0;
                Fun();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #endregion


        #region 分析文件
        private void Fun()
        {
            for (int fileIndex = 0; fileIndex < filesContent.Count; fileIndex++)
            {
                fileContent = filesContent[fileIndex];


                #region 读取微博内容
                string[] contents = fileContent.Split(new string[] { "<div class=\"tweet_content\">" }, StringSplitOptions.RemoveEmptyEntries);

                singalListLength = contents.Length;

                for (int i = 1; i < singalListLength; i++)
                {
                    excel.Cells[ListLength + i + 2, 3] = contents[i].Split(new string[] { "</div>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                progressBar1.Value++;
                #endregion


                #region 读取微博发送时间
                string[] timeTemp = fileContent.Split(new string[] { "<div class=\"stime\">" }, StringSplitOptions.RemoveEmptyEntries);
                date = fileContent.Split(new string[] { "<span class=\"tab_date icon icon_calendar\">" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "</span>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                for (int i = 1; i < singalListLength; i++)
                {
                    excel.Cells[ListLength + i + 2, 2] = date + "\r\n\r\n" + timeTemp[i].Split(new string[] { "</div>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                progressBar1.Value++;
                #endregion


                #region 读取微博的类型（转发、直发）
                string[] typeTemp = fileContent.Split(new string[] { "<div class=\"task_type\">" }, StringSplitOptions.RemoveEmptyEntries);
                bool[] isForward = new bool[singalListLength];
                for (int i = 1; i < singalListLength; i++)
                {
                    temp = typeTemp[i].Split(new string[] { "title=\"" }, StringSplitOptions.RemoveEmptyEntries)[1].Substring(0, 2);
                    excel.Cells[ListLength + i + 2, 1] = temp;
                    isForward[i] = temp == "转发";
                }
                progressBar1.Value++;
                #endregion


                #region 读取被转账号
                string[] forwardAccountTemp = fileContent.Split(new string[] { "被转账号" }, StringSplitOptions.RemoveEmptyEntries);
                int j = 0;
                for (int i = 1; i < singalListLength; i++)
                {
                    if (isForward[i])
                    {
                        j++;
                        temp = forwardAccountTemp[j].Split(new string[] { "转发链接" }, StringSplitOptions.RemoveEmptyEntries)[0];
                        excel.Cells[ListLength + i + 2, 4] = temp.Split(new string[] { "target=\"_blank\">" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "</a>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                }
                progressBar1.Value++;
                #endregion


                #region 读取转发链接
                string[] forwardLinkTemp = fileContent.Split(new string[] { "转发链接" }, StringSplitOptions.RemoveEmptyEntries);
                j = 0;
                for (int i = 1; i < singalListLength; i++)
                {
                    if (isForward[i])
                    {
                        j++;
                        temp = forwardLinkTemp[j].Split(new string[] { "</a>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                        excel.Cells[ListLength + i + 2, 5] = temp.Split(new string[] { "target=\"_blank\">" }, StringSplitOptions.RemoveEmptyEntries)[0].Substring(8);
                    }
                }
                progressBar1.Value++;
                #endregion


                excel.Cells[ListLength + 2, 1] = date;
                excel.Cells[ListLength + 2, 1].Interior.ColorIndex = 39;
                ListLength += singalListLength;
            }

            #region 设置Excel格式
            er = worksheet.get_Range("A1", "E" + (ListLength + 1));
            er.Font.Name = "微软雅黑";
            //er.VerticalAlignment = Xlce
            er.EntireColumn.AutoFit();
            er.EntireRow.AutoFit();

            er = worksheet.get_Range("C1", "C" + (ListLength + 1));
            er.ColumnWidth = 60;
            er.WrapText = true;
            #endregion


            wbook.SaveAs(excelPath);

            if (MessageBox.Show("分析完成。是否执行分类？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sorted();
            }
        }
        #endregion



        #region Sorted
        private void Sorted()
        {
            try
            {
                #region 初始化Excel
                excelSorted = new Microsoft.Office.Interop.Excel.Application();
                wbookSorted = excelSorted.Workbooks.Add();
                for (int i = 5; i >= 0; i--)
                {
                    worksheetSorted = (Worksheet)wbookSorted.Worksheets.Add();
                    worksheetSorted.Name = worksheetSortedName[i];
                    excelSorted.Cells[1, 1] = "类型";
                    excelSorted.Cells[1, 2] = "时间";
                    excelSorted.Cells[1, 3] = "内容";
                    if (i == 5)
                    {
                        excelSorted.Cells[1, 4] = "被转账号";
                        excelSorted.Cells[1, 5] = "转发链接";
                    }

                    er = worksheetSorted.get_Range("A1", "E" + (ListLength + 1));
                    er.Font.Name = "微软雅黑";
                    er.EntireColumn.AutoFit();
                    er.EntireRow.AutoFit();

                    er = worksheetSorted.get_Range("C1", "C" + (ListLength + 1));
                    er.ColumnWidth = 60;
                    er.WrapText = true;
                }
                #endregion

                progressBar1.Value = 0;
                progressBar1.Maximum = ListLength + 1;

                SortedFun();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #endregion


        #region 微博分类
        private void SortedFun()
        {
            int[] lens = new int[6] { 2, 2, 2, 2, 2, 2 };
            int sheetIndex = 0;

            for (int i = 3; i < ListLength + 2; i++)
            {
                progressBar1.Value = i;
                er = worksheet.get_Range("A" + i, "E" + i);

                if (worksheet.Cells[i, 1].Text == "直发")
                {
                    temp = worksheet.Cells[i, 3].Text;
                    if (temp.Contains("#微软创新杯#"))
                    {
                        sheetIndex = 0;
                    }
                    else if (temp.Contains("#软妹百科#"))
                    {
                        sheetIndex = 1;
                    }
                    else if (temp.Contains("#软妹贴士#"))
                    {
                        sheetIndex = 2;
                    }
                    else if (temp.Contains("#软妹夜聊#"))
                    {
                        sheetIndex = 3;
                    }
                    else//其他原创
                    {
                        sheetIndex = 4;
                    }
                }
                else if (worksheet.Cells[i, 1].Text == "转发")
                {
                    sheetIndex = 5;
                }
                else//日期
                {
                    continue;
                }

                worksheetSorted = (Worksheet)wbookSorted.Worksheets[sheetIndex + 1];
                er2 = worksheetSorted.get_Range("A" + lens[sheetIndex], "E" + lens[sheetIndex]);
                lens[sheetIndex]++;
                er2.Value = er.Value;
            }

            wbookSorted.SaveAs(excelSortedPath);
            excel.Quit();
            excelSorted.Quit();
            KillSpecialExcel();

            if (MessageBox.Show("分析完成，汇总文件位于：" + excelPath + "。是否打开汇总文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start(excelPath);
            }

            if (MessageBox.Show("分类文件位于：" + excelSortedPath + "。是否打开分类文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start(excelSortedPath);
            }
        }
        #endregion



        #region 确定htm文件夹位置
        private void button2_Click(object sender, EventArgs e)
        {
            if (ExcelfolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = ExcelfolderBrowserDialog.SelectedPath;
                //folderPath=  @"C:\Users\mingqun\Desktop\创新杯运营\小鸟分析器";
                excelPath = folderPath + "\\汇总表" + DateTime.Now.Day + ".xlsx";
                excelSortedPath = folderPath + "\\分类表" + DateTime.Now.Day + ".xlsx";
                foreach (string path in Directory.GetFiles(folderPath, "*.htm"))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        filesContent.Add(sr.ReadToEnd());
                    }
                }

                btnAnalysis.Enabled = true;
            }
        }
        #endregion


        #region 退出Excel进程
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        public void KillSpecialExcel()
        {
            try
            {
                if (excel != null)
                {
                    int lpdwProcessId;

                    GetWindowThreadProcessId(new IntPtr(excel.Hwnd), out lpdwProcessId);
                    Process.GetProcessById(lpdwProcessId).Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Excel Process Error:" + ex.Message);
            }
        }
        #endregion
    }
}