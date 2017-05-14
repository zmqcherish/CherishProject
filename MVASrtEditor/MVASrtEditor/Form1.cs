using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MVASrtEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        string line,folderPath,filePath;
        StringBuilder fileContent = new StringBuilder();
        bool isFolder;
        int sectionCount=0;
        //List<string> filesContent = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (SrtfolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = SrtfolderBrowserDialog.SelectedPath;

                progressBar1.Maximum = Directory.GetFiles(folderPath, "*.srt").Length;
                progressBar1.Value = 0;

                btnAnalysis.Enabled = true;
                isFolder = true;
            }
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            if (isFolder)
            {
                foreach (string path in Directory.GetFiles(folderPath, "*.srt"))
                {
                    EditFile(path);
                }
            }
            else
            {
                EditFile(filePath);
            }
           
            MessageBox.Show("修改完成！");
        }

        private void EditFile(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(file, Encoding.Default);
            StreamWriter sw = new StreamWriter(file);

            while (!(line = sr.ReadLine()).Contains("-->")) ;

            fileContent.AppendLine(line);
            sectionCount++;
            fileContent.Insert(fileContent.Length - line.Length - 2, sectionCount + "\n");

            while ((line = sr.ReadLine()) != null)
            {
                fileContent.AppendLine(line);
                if (line.Contains("-->"))
                {
                    sectionCount++;
                    fileContent.Insert(fileContent.Length - line.Length - 2, sectionCount + "\n");
                    //  file.Seek(-line.Length, SeekOrigin.Begin);
                }
            }

            file.Position = 0;
            sw.Write(fileContent.ToString());
            // file.Position = 0;

            fileContent.Clear();
            sectionCount = 0;

            sw.Close();
            sr.Close();
            file.Close();

            progressBar1.Value++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            srtFileDialog.Filter= "srt files (*.srt)|*.srt";
            if (srtFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = srtFileDialog.FileName;

                progressBar1.Maximum =1;
                progressBar1.Value = 0;

                btnAnalysis.Enabled = true;
                isFolder = false;
            }
        }
    }
}
