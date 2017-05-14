using System.Windows.Forms;
using System.Drawing;
namespace 四六级查分器
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.radio6 = new System.Windows.Forms.RadioButton();
            this.radio4 = new System.Windows.Forms.RadioButton();
            this.numericTotal = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericWriting = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericCom = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericReading = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericListening = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericName = new System.Windows.Forms.NumericUpDown();
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWriting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericListening)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(210, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "查询";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Excel文档1";
            // 
            // radio6
            // 
            this.radio6.AutoSize = true;
            this.radio6.Checked = true;
            this.radio6.Location = new System.Drawing.Point(238, 45);
            this.radio6.Name = "radio6";
            this.radio6.Size = new System.Drawing.Size(47, 16);
            this.radio6.TabIndex = 2;
            this.radio6.TabStop = true;
            this.radio6.Text = "六级";
            this.radio6.UseVisualStyleBackColor = true;
            // 
            // radio4
            // 
            this.radio4.AutoSize = true;
            this.radio4.Enabled = false;
            this.radio4.Location = new System.Drawing.Point(185, 45);
            this.radio4.Name = "radio4";
            this.radio4.Size = new System.Drawing.Size(47, 16);
            this.radio4.TabIndex = 2;
            this.radio4.Text = "四级";
            this.radio4.UseVisualStyleBackColor = true;
            // 
            // numericTotal
            // 
            this.numericTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericTotal.Location = new System.Drawing.Point(63, 221);
            this.numericTotal.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericTotal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTotal.Name = "numericTotal";
            this.numericTotal.Size = new System.Drawing.Size(54, 21);
            this.numericTotal.TabIndex = 33;
            this.numericTotal.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "总分:";
            // 
            // numericWriting
            // 
            this.numericWriting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericWriting.Location = new System.Drawing.Point(63, 189);
            this.numericWriting.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericWriting.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWriting.Name = "numericWriting";
            this.numericWriting.Size = new System.Drawing.Size(54, 21);
            this.numericWriting.TabIndex = 31;
            this.numericWriting.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "写作:";
            // 
            // numericCom
            // 
            this.numericCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericCom.Location = new System.Drawing.Point(63, 157);
            this.numericCom.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericCom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCom.Name = "numericCom";
            this.numericCom.Size = new System.Drawing.Size(54, 21);
            this.numericCom.TabIndex = 29;
            this.numericCom.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "综合:";
            // 
            // numericReading
            // 
            this.numericReading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericReading.Location = new System.Drawing.Point(63, 125);
            this.numericReading.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericReading.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericReading.Name = "numericReading";
            this.numericReading.Size = new System.Drawing.Size(54, 21);
            this.numericReading.TabIndex = 27;
            this.numericReading.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "阅读:";
            // 
            // numericListening
            // 
            this.numericListening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericListening.Location = new System.Drawing.Point(63, 93);
            this.numericListening.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericListening.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericListening.Name = "numericListening";
            this.numericListening.Size = new System.Drawing.Size(54, 21);
            this.numericListening.TabIndex = 25;
            this.numericListening.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "听力:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "准考号:";
            // 
            // numericName
            // 
            this.numericName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericName.Location = new System.Drawing.Point(63, 29);
            this.numericName.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericName.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericName.Name = "numericName";
            this.numericName.Size = new System.Drawing.Size(54, 21);
            this.numericName.TabIndex = 21;
            this.numericName.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numId
            // 
            this.numId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numId.Location = new System.Drawing.Point(63, 61);
            this.numId.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(54, 21);
            this.numId.TabIndex = 23;
            this.numId.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "姓名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "Excel文件路径:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericTotal, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericWriting, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.numericName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericCom, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.numId, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericReading, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericListening, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(120, 256);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "选项";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "所在列";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 35;
            this.label11.Text = "从:";
            // 
            // numStart
            // 
            this.numStart.Location = new System.Drawing.Point(215, 87);
            this.numStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStart.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(37, 21);
            this.numStart.TabIndex = 36;
            this.numStart.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(258, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 37;
            this.label12.Text = "行开始";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-6, 280);
            this.progressBar1.Maximum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(359, 23);
            this.progressBar1.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 298);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numStart);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radio4);
            this.Controls.Add(this.radio6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "四六级查分器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWriting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericListening)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnOK;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private RadioButton radio6;
        private RadioButton radio4;
        private NumericUpDown numericTotal;
        private Label label8;
        private NumericUpDown numericWriting;
        private Label label7;
        private NumericUpDown numericCom;
        private Label label6;
        private NumericUpDown numericReading;
        private Label label5;
        private NumericUpDown numericListening;
        private Label label4;
        private Label label3;
        private NumericUpDown numericName;
        private NumericUpDown numId;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label9;
        private Label label10;
        private Label label11;
        private NumericUpDown numStart;
        private Label label12;
        private ProgressBar progressBar1;
    }
}

