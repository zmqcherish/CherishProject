using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace 四六级查分器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //锁定窗体大小
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            ProgressBar.CheckForIllegalCrossThreadCalls = false;  //取消进度条不是主线程调用时的检测
        }
        Microsoft.Office.Interop.Excel.Application app;
        string excelPath;
        Thread thread;
        Worksheet worksheet;
        Workbook wbook;
        private void btnOK_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(ThreadFun));   //创建线程对象,实为通过委托传入方法参数
            thread.Start();
            thread.IsBackground = true;        // //线程默认是前台线程,设置为后台线程

            btnOK.Text = "正在查询";
            btnOK.Enabled = false;
        }

        public void ExcelHelper(string filename)     //根据文件名初始化Excel相关参数
        {
            app = new Microsoft.Office.Interop.Excel.Application();
            wbook = app.Workbooks.Open(filename);
            worksheet = (Worksheet)wbook.Worksheets[1];
        }

        private void ThreadFun()   //查询进程
        {
            ExcelHelper(excelPath);
            int length = worksheet.UsedRange.CurrentRegion.Rows.Count;           //!!!使用worksheet.UsedRange.Rows.Count;错误,得到的是已经使用过的行数
            progressBar1.Maximum = length;
            string id,name;
            string referer = "http://cet.99sushe.com/";
            string str1 = "POST /s HTTP/1.1\r\nHost:cet.99sushe.com\r\nReferer: " + referer + "\r\nContent-Length: ";

            Encoding encodeGb2312 = Encoding.GetEncoding("GB2312");
            Encoding encodeUtf8 = Encoding.GetEncoding("utf-8");

            int start = Convert.ToInt32(numStart.Value);
            for (int i = start; i <= length; i++)
            {
                try
                {
                    name = (worksheet.Cells[i, numericName.Value].Text).Substring(0, 2);
                    id = (worksheet.Cells[i, numId.Value].Text).Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误:" + ex.Message);
                    btnOK.Text = "查询";
                    return;
                }

                string content = "id=" + id + "&name=" + System.Web.HttpUtility.UrlEncode(name, encodeGb2312).ToUpper();
                string str = str1 + encodeUtf8.GetBytes(content).Length + "\r\n\r\n" + content;

                string result = PostData(str);  //接收数据,核心

                if (result == "failed")
                {
                    MessageBox.Show("未知错误!");
                    wbook.Save();
                    KillSpecialExcel();
                    thread.Abort();
                    return;
                }

                WriteResult(result, i);  //写入Excel文件
                progressBar1.Value = i;
            }
            wbook.Save();
            KillSpecialExcel();
            if (MessageBox.Show("操作完成，现在是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start(excelPath);
            }
            btnOK.Enabled = true;
            btnOK.Text = "查询";
        }

        //确定Excel文件路径
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "excel文档 (*.xls;*.xlsx)|*.xls;*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excelPath = openFileDialog1.FileName;
                btnOK.Enabled = true;
            }
        }

        IPAddress address = Dns.GetHostAddresses("58.205.216.37")[0];
        Socket socket;
        //Socket通信
        public string PostData(string postString)
        {
            Encoding encode = Encoding.GetEncoding("utf-8");
            Byte[] ByteGet = encode.GetBytes(postString);

            IPEndPoint EPhost = new IPEndPoint(address, 80);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(EPhost);
                if (!socket.Connected)
                {
                    return "failed";
                }
                socket.Send(ByteGet, ByteGet.Length, SocketFlags.None);
            }
            catch (Exception)
            {
                return "failed";
            }

            Byte[] buffer = new Byte[500];
            StringBuilder sb = new StringBuilder();

            int len = socket.Receive(buffer);
            sb.Append(encode.GetString(buffer, 0, len));

            socket.Close();
            return sb.ToString();
        }

        //将数据写入Excel文件
        public void WriteResult(string result, int i)
        {
            string[] part = result.Substring(result.IndexOf("\r\n\r\n")).Split(',');
            app.Cells[i, numericListening.Value] = part[1];  //听力
            app.Cells[i, numericReading.Value] = part[2];  //阅读
            app.Cells[i, numericCom.Value] = part[3];  //综合
            app.Cells[i, numericWriting.Value] = part[4];  //写作
            app.Cells[i, numericTotal.Value] = part[5];  //总分
        }

        //退出Excel进程
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        public void KillSpecialExcel()
        {
            try
            {
                if (app != null)
                {
                    int lpdwProcessId;

                    GetWindowThreadProcessId(new IntPtr(app.Hwnd), out lpdwProcessId);
                    Process.GetProcessById(lpdwProcessId).Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Excel Process Error:" + ex.Message);
            }
        }

        //关闭时如果为查找完成,提示
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)  //退出时完成扫尾工作
        {
            if (progressBar1.Value != progressBar1.Maximum && progressBar1.Maximum!=1)   //如果进度条未完成,或者开始查询
            {
                if (MessageBox.Show("查询未完成，确定退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)                    //提示
                {
                    wbook.Save();                                   //好像有错,
                    KillSpecialExcel();
                    thread.Abort();
                    System.Windows.Forms.Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}