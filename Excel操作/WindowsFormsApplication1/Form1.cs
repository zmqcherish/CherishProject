using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 全局变量
        Microsoft.Office.Interop.Excel.Application excel, excelSorted;
    
        List<string> l源姓名 = new List<string>();
        List<string> l源邮箱 = new List<string>();
        List<string> l结果姓名 = new List<string>();
        List<string> l结果邮箱 = new List<string>();

        Worksheet worksheet结果, worksheet源;
        Workbook wbook源, wbook结果;

        Microsoft.Office.Interop.Excel.Range e源姓名,e源邮箱;
        Microsoft.Office.Interop.Excel.Range e结果姓名,e结果邮箱;
        #endregion

        string path源 = @"C:\Users\mingqun\Desktop\源.xlsx";
        string path结果 = @"C:\Users\mingqun\Desktop\结果.xls";
        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();

                wbook源 = excel.Workbooks.Open(path源);
                worksheet源 = (Worksheet)wbook源.Worksheets[2];

                wbook结果 = excel.Workbooks.Open(path结果);
                worksheet结果 = (Worksheet)wbook结果.Worksheets[5];  

                e源姓名 = worksheet源.get_Range("C2", "C256");
                e源邮箱 = worksheet源.get_Range("G2", "G256");

                e结果姓名 = worksheet结果.get_Range("B2", "B173");
                e结果邮箱 = worksheet结果.get_Range("F2", "F173");
        //     MessageBox.Show(worksheet结果.Name);

                Array Array源姓名 = (Array)e源姓名.Cells.Value2;
           
                int len = Array源姓名.GetLength(0);
                for (int i = 1; i <=len ; i++)
                {
                    l源姓名.Add(Array源姓名.GetValue(i,1).ToString());
                }

                 Array Array源邮箱 = (Array)e源邮箱.Cells.Value2;
          
                //len = Array源邮箱.GetLength(0);
                //for (int i = 1; i <= len; i++)
                //{
                //    l源邮箱.Add(Array源邮箱.GetValue(i, 1).ToString());
                //}

                Array Array结果姓名 = (Array)e结果姓名.Cells.Value2;
          
                len = Array结果姓名.GetLength(0);
                for (int i = 1; i <= len; i++)
                {
                    l结果姓名.Add(Array结果姓名.GetValue(i, 1).ToString());
                }

                //Array Array结果邮箱 = (Array)e结果邮箱.Cells.Value2;
         
                //len = Array结果邮箱.GetLength(0);
                //for (int i = 1; i <= len; i++)
                //{
                //    l结果邮箱.Add(Array结果邮箱.GetValue(i, 1).ToString());
                //}

           int index;


           for (int i = 0; i < l结果姓名.Count; i++)
                {
                    index = l源姓名.IndexOf(l结果姓名[i]);
                    if (index == -1)
                        continue;

                    e结果邮箱[i+1, 1] = Array源邮箱.GetValue(index+1, 1);
                }
              //  e结果[1, 1] = "dsad";
                wbook结果.Save();
            //    excel.Cells[1, 1] = "类型";
              //  worksheet结果.Cells[10, 3].Text="试试";
                MessageBox.Show("ax");
             
                 
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                wbook结果.Save();
            }
        }

      

       
    }
}
