using System.Drawing;

namespace LedScreen
{
    partial class Home
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btnSetting = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnSwitchPort = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstBoxWorker = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.labproname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.nowoutdate = new System.Windows.Forms.Label();
            this.nowouttime = new System.Windows.Forms.Label();
            this.nowoutgroup = new System.Windows.Forms.Label();
            this.nowoutname = new System.Windows.Forms.Label();
            this.nowoutjob = new System.Windows.Forms.Label();
            this.outuser = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.nowindate = new System.Windows.Forms.Label();
            this.nowintime = new System.Windows.Forms.Label();
            this.nowingroup = new System.Windows.Forms.Label();
            this.nowinname = new System.Windows.Forms.Label();
            this.nowinjob = new System.Windows.Forms.Label();
            this.inuser = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.slogen = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timenow = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tweather = new System.Windows.Forms.TableLayoutPanel();
            this.wpicture = new System.Windows.Forms.PictureBox();
            this.twind = new System.Windows.Forms.Label();
            this.tw = new System.Windows.Forms.Label();
            this.ttemp = new System.Windows.Forms.Label();
            this.nweather = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.foundation = new System.Windows.Forms.Label();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.timer8 = new System.Windows.Forms.Timer(this.components);
            this.timer9 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outuser)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inuser)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tweather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wpicture)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.Location = new System.Drawing.Point(2, -1);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(71, 33);
            this.btnSetting.TabIndex = 2;
            this.btnSetting.Text = "串口设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Visible = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnSwitchPort
            // 
            this.btnSwitchPort.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitchPort.Location = new System.Drawing.Point(77, 0);
            this.btnSwitchPort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSwitchPort.Name = "btnSwitchPort";
            this.btnSwitchPort.Size = new System.Drawing.Size(73, 33);
            this.btnSwitchPort.TabIndex = 3;
            this.btnSwitchPort.Text = "开启串口";
            this.btnSwitchPort.UseVisualStyleBackColor = true;
            this.btnSwitchPort.Visible = false;
            this.btnSwitchPort.Click += new System.EventHandler(this.SwitchPortClick);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(31, 18);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 20);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(70, 20);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "loading...";
            this.labelTime.Click += new System.EventHandler(this.labelTime_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(214, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "在场人数";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(214, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 85);
            this.label4.TabIndex = 1;
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Click += new System.EventHandler(this.label4_ClickAsync);
            // 
            // lstBoxWorker
            // 
            this.lstBoxWorker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.lstBoxWorker.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoxWorker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstBoxWorker.Enabled = false;
            this.lstBoxWorker.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstBoxWorker.ForeColor = System.Drawing.Color.Cyan;
            this.lstBoxWorker.FormattingEnabled = true;
            this.lstBoxWorker.IntegralHeight = false;
            this.lstBoxWorker.ItemHeight = 120;
            this.lstBoxWorker.Location = new System.Drawing.Point(25, 48);
            this.lstBoxWorker.Margin = new System.Windows.Forms.Padding(2, 2, 20, 20);
            this.lstBoxWorker.Name = "lstBoxWorker";
            this.lstBoxWorker.Size = new System.Drawing.Size(496, 376);
            this.lstBoxWorker.Sorted = true;
            this.lstBoxWorker.TabIndex = 8;
            this.lstBoxWorker.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBoxWorker_DrawItem);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(1415, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 33);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // tlp
            // 
            this.tlp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.tlp.ColumnCount = 5;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlp.ForeColor = System.Drawing.Color.White;
            this.tlp.Location = new System.Drawing.Point(364, 602);
            this.tlp.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.tlp.Name = "tlp";
            this.tlp.Padding = new System.Windows.Forms.Padding(4);
            this.tlp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tlp.RowCount = 2;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.Size = new System.Drawing.Size(1120, 174);
            this.tlp.TabIndex = 12;
            // 
            // labproname
            // 
            this.labproname.AutoSize = true;
            this.labproname.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labproname.ForeColor = System.Drawing.Color.Aqua;
            this.labproname.Location = new System.Drawing.Point(526, 6);
            this.labproname.Margin = new System.Windows.Forms.Padding(0);
            this.labproname.MaximumSize = new System.Drawing.Size(741, 0);
            this.labproname.Name = "labproname";
            this.labproname.Size = new System.Drawing.Size(125, 46);
            this.labproname.TabIndex = 14;
            this.labproname.Text = "label5";
            this.labproname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labproname.Click += new System.EventHandler(this.labproname_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(109, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "考勤人数";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(109, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 85);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "项目人数";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 2);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 85);
            this.label6.TabIndex = 1;
            this.label6.Text = "0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(154, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 32);
            this.button1.TabIndex = 11;
            this.button1.Text = "LED配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.label3_Click);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 300000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Interval = 300000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tlp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1496, 788);
            this.panel1.TabIndex = 17;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.panel8.Controls.Add(this.tableLayoutPanel3);
            this.panel8.Controls.Add(this.outuser);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Location = new System.Drawing.Point(656, 133);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(250, 455);
            this.panel8.TabIndex = 22;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.nowoutdate, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.nowouttime, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.nowoutgroup, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.nowoutname, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.nowoutjob, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(45, 298);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(166, 126);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // nowoutdate
            // 
            this.nowoutdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nowoutdate.AutoSize = true;
            this.nowoutdate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowoutdate.ForeColor = System.Drawing.Color.Cyan;
            this.nowoutdate.Location = new System.Drawing.Point(80, 42);
            this.nowoutdate.Name = "nowoutdate";
            this.nowoutdate.Size = new System.Drawing.Size(0, 20);
            this.nowoutdate.TabIndex = 2;
            // 
            // nowouttime
            // 
            this.nowouttime.AutoSize = true;
            this.nowouttime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowouttime.ForeColor = System.Drawing.Color.Cyan;
            this.nowouttime.Location = new System.Drawing.Point(86, 42);
            this.nowouttime.Name = "nowouttime";
            this.nowouttime.Size = new System.Drawing.Size(0, 21);
            this.nowouttime.TabIndex = 3;
            // 
            // nowoutgroup
            // 
            this.nowoutgroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nowoutgroup.AutoSize = true;
            this.nowoutgroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowoutgroup.ForeColor = System.Drawing.Color.White;
            this.nowoutgroup.Location = new System.Drawing.Point(80, 84);
            this.nowoutgroup.Name = "nowoutgroup";
            this.nowoutgroup.Size = new System.Drawing.Size(0, 21);
            this.nowoutgroup.TabIndex = 4;
            // 
            // nowoutname
            // 
            this.nowoutname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nowoutname.AutoSize = true;
            this.nowoutname.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowoutname.ForeColor = System.Drawing.Color.Cyan;
            this.nowoutname.Location = new System.Drawing.Point(80, 0);
            this.nowoutname.Name = "nowoutname";
            this.nowoutname.Size = new System.Drawing.Size(0, 25);
            this.nowoutname.TabIndex = 0;
            this.nowoutname.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nowoutjob
            // 
            this.nowoutjob.AutoSize = true;
            this.nowoutjob.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowoutjob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nowoutjob.Location = new System.Drawing.Point(86, 0);
            this.nowoutjob.Name = "nowoutjob";
            this.nowoutjob.Size = new System.Drawing.Size(0, 20);
            this.nowoutjob.TabIndex = 1;
            // 
            // outuser
            // 
            this.outuser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.outuser.Location = new System.Drawing.Point(45, 48);
            this.outuser.Name = "outuser";
            this.outuser.Size = new System.Drawing.Size(166, 217);
            this.outuser.TabIndex = 11;
            this.outuser.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Location = new System.Drawing.Point(24, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "最新出场人员";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.lstBoxWorker);
            this.panel7.ForeColor = System.Drawing.Color.Transparent;
            this.panel7.Location = new System.Drawing.Point(942, 133);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(542, 455);
            this.panel7.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(21, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "历史进出场人员";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Controls.Add(this.inuser);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(364, 133);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(249, 455);
            this.panel6.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.nowindate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.nowintime, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.nowingroup, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.nowinname, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nowinjob, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(41, 298);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(166, 126);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // nowindate
            // 
            this.nowindate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nowindate.AutoSize = true;
            this.nowindate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowindate.ForeColor = System.Drawing.Color.Cyan;
            this.nowindate.Location = new System.Drawing.Point(80, 42);
            this.nowindate.Name = "nowindate";
            this.nowindate.Size = new System.Drawing.Size(0, 20);
            this.nowindate.TabIndex = 2;
            // 
            // nowintime
            // 
            this.nowintime.AutoSize = true;
            this.nowintime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowintime.ForeColor = System.Drawing.Color.Cyan;
            this.nowintime.Location = new System.Drawing.Point(86, 42);
            this.nowintime.Name = "nowintime";
            this.nowintime.Size = new System.Drawing.Size(0, 21);
            this.nowintime.TabIndex = 3;
            // 
            // nowingroup
            // 
            this.nowingroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nowingroup.AutoSize = true;
            this.nowingroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowingroup.ForeColor = System.Drawing.Color.White;
            this.nowingroup.Location = new System.Drawing.Point(80, 84);
            this.nowingroup.Name = "nowingroup";
            this.nowingroup.Size = new System.Drawing.Size(0, 21);
            this.nowingroup.TabIndex = 4;
            // 
            // nowinname
            // 
            this.nowinname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nowinname.AutoSize = true;
            this.nowinname.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowinname.ForeColor = System.Drawing.Color.Cyan;
            this.nowinname.Location = new System.Drawing.Point(80, 0);
            this.nowinname.Name = "nowinname";
            this.nowinname.Size = new System.Drawing.Size(0, 25);
            this.nowinname.TabIndex = 0;
            this.nowinname.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nowinjob
            // 
            this.nowinjob.AutoSize = true;
            this.nowinjob.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowinjob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nowinjob.Location = new System.Drawing.Point(86, 0);
            this.nowinjob.Name = "nowinjob";
            this.nowinjob.Size = new System.Drawing.Size(0, 20);
            this.nowinjob.TabIndex = 1;
            // 
            // inuser
            // 
            this.inuser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.inuser.Location = new System.Drawing.Point(41, 49);
            this.inuser.Name = "inuser";
            this.inuser.Size = new System.Drawing.Size(166, 217);
            this.inuser.TabIndex = 1;
            this.inuser.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(18, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "最近进场人员";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel5.Controls.Add(this.slogen);
            this.panel5.Controls.Add(this.btnSetting);
            this.panel5.Controls.Add(this.btnSwitchPort);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Location = new System.Drawing.Point(3, 78);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1490, 34);
            this.panel5.TabIndex = 20;
            // 
            // slogen
            // 
            this.slogen.AutoSize = true;
            this.slogen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.slogen.ForeColor = System.Drawing.Color.White;
            this.slogen.Location = new System.Drawing.Point(364, 11);
            this.slogen.Name = "slogen";
            this.slogen.Size = new System.Drawing.Size(43, 17);
            this.slogen.TabIndex = 0;
            this.slogen.Text = "label7";
            this.slogen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(254)))));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Controls.Add(this.timenow);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.labelTime);
            this.panel3.Location = new System.Drawing.Point(15, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 455);
            this.panel3.TabIndex = 19;
            // 
            // timenow
            // 
            this.timenow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timenow.AutoSize = true;
            this.timenow.Font = new System.Drawing.Font("Bahnschrift SemiBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timenow.ForeColor = System.Drawing.Color.Transparent;
            this.timenow.Location = new System.Drawing.Point(19, 77);
            this.timenow.Name = "timenow";
            this.timenow.Size = new System.Drawing.Size(215, 58);
            this.timenow.TabIndex = 21;
            this.timenow.Text = "loading...";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.tweather);
            this.panel4.Controls.Add(this.nweather);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 173);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(320, 282);
            this.panel4.TabIndex = 20;
            // 
            // tweather
            // 
            this.tweather.ColumnCount = 1;
            this.tweather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tweather.Controls.Add(this.wpicture, 0, 0);
            this.tweather.Controls.Add(this.twind, 0, 3);
            this.tweather.Controls.Add(this.tw, 0, 2);
            this.tweather.Controls.Add(this.ttemp, 0, 1);
            this.tweather.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tweather.ForeColor = System.Drawing.Color.White;
            this.tweather.Location = new System.Drawing.Point(20, 19);
            this.tweather.Name = "tweather";
            this.tweather.RowCount = 4;
            this.tweather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tweather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tweather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tweather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tweather.Size = new System.Drawing.Size(131, 143);
            this.tweather.TabIndex = 22;
            // 
            // wpicture
            // 
            this.wpicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.wpicture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("wpicture.ErrorImage")));
            this.wpicture.Location = new System.Drawing.Point(3, 3);
            this.wpicture.Name = "wpicture";
            this.wpicture.Size = new System.Drawing.Size(37, 29);
            this.wpicture.TabIndex = 22;
            this.wpicture.TabStop = false;
            // 
            // twind
            // 
            this.twind.AutoSize = true;
            this.twind.Location = new System.Drawing.Point(3, 105);
            this.twind.Name = "twind";
            this.twind.Size = new System.Drawing.Size(32, 17);
            this.twind.TabIndex = 22;
            this.twind.Text = "风力";
            // 
            // tw
            // 
            this.tw.AutoSize = true;
            this.tw.Location = new System.Drawing.Point(3, 70);
            this.tw.Name = "tw";
            this.tw.Size = new System.Drawing.Size(32, 17);
            this.tw.TabIndex = 22;
            this.tw.Text = "天气";
            // 
            // ttemp
            // 
            this.ttemp.AutoSize = true;
            this.ttemp.Location = new System.Drawing.Point(3, 35);
            this.ttemp.Name = "ttemp";
            this.ttemp.Size = new System.Drawing.Size(32, 17);
            this.ttemp.TabIndex = 22;
            this.ttemp.Text = "气温";
            // 
            // nweather
            // 
            this.nweather.AutoSize = true;
            this.nweather.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nweather.ForeColor = System.Drawing.Color.White;
            this.nweather.Location = new System.Drawing.Point(17, 234);
            this.nweather.Name = "nweather";
            this.nweather.Size = new System.Drawing.Size(53, 17);
            this.nweather.TabIndex = 22;
            this.nweather.Text = "加载中...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "明日天气";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 602);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 174);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.foundation);
            this.panel2.Controls.Add(this.labproname);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1493, 69);
            this.panel2.TabIndex = 17;
            // 
            // foundation
            // 
            this.foundation.AutoSize = true;
            this.foundation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.foundation.ForeColor = System.Drawing.Color.White;
            this.foundation.Location = new System.Drawing.Point(12, 23);
            this.foundation.Name = "foundation";
            this.foundation.Size = new System.Drawing.Size(43, 17);
            this.foundation.TabIndex = 15;
            this.foundation.Text = "label7";
            // 
            // timer5
            // 
            this.timer5.Enabled = true;
            this.timer5.Interval = 60000;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // timer6
            // 
            this.timer6.Enabled = true;
            this.timer6.Interval = 60000;
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // timer7
            // 
            this.timer7.Enabled = true;
            this.timer7.Interval = 300000;
            this.timer7.Tick += new System.EventHandler(this.timer7_Tick);
            // 
            // timer8
            // 
            this.timer8.Enabled = true;
            this.timer8.Interval = 1000;
            this.timer8.Tick += new System.EventHandler(this.timer8_Tick);
            // 
            // timer9
            // 
            this.timer9.Enabled = true;
            this.timer9.Interval = 60000;
            this.timer9.Tick += new System.EventHandler(this.timer9_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1496, 788);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工人进场信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outuser)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inuser)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tweather.ResumeLayout(false);
            this.tweather.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wpicture)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSetting;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnSwitchPort;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstBoxWorker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Label labproname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label slogen;
        private System.Windows.Forms.Label foundation;
        private System.Windows.Forms.Timer timer8;
        private System.Windows.Forms.Label timenow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label nweather;
        private System.Windows.Forms.TableLayoutPanel tweather;
        private System.Windows.Forms.Label twind;
        private System.Windows.Forms.Label tw;
        private System.Windows.Forms.Label ttemp;
        private System.Windows.Forms.PictureBox wpicture;
        private System.Windows.Forms.Timer timer9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label nowinname;
        private System.Windows.Forms.Label nowinjob;
        private System.Windows.Forms.Label nowindate;
        private System.Windows.Forms.Label nowintime;
        private System.Windows.Forms.Label nowingroup;
        private System.Windows.Forms.PictureBox inuser;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label nowoutdate;
        private System.Windows.Forms.Label nowouttime;
        private System.Windows.Forms.Label nowoutgroup;
        private System.Windows.Forms.Label nowoutname;
        private System.Windows.Forms.Label nowoutjob;
        private System.Windows.Forms.PictureBox outuser;
    }
}

