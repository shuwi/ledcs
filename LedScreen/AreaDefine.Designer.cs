namespace LedScreen
{
    partial class AreaDefine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.width = new System.Windows.Forms.TextBox();
            this.leftBegin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inStyle = new System.Windows.Forms.ComboBox();
            this.delayTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fontBold = new System.Windows.Forms.ComboBox();
            this.multiIsVCenter = new System.Windows.Forms.ComboBox();
            this.multiNAlignment = new System.Windows.Forms.ComboBox();
            this.moduleType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.TextBox();
            this.topBegin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.areaType = new System.Windows.Forms.ComboBox();
            this.fontSize = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TextBox();
            this.moduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.submit = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // width
            // 
            this.width.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.width.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.width.Location = new System.Drawing.Point(143, 45);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(226, 26);
            this.width.TabIndex = 3;
            // 
            // leftBegin
            // 
            this.leftBegin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.leftBegin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.leftBegin.Location = new System.Drawing.Point(143, 6);
            this.leftBegin.Name = "leftBegin";
            this.leftBegin.Size = new System.Drawing.Size(226, 26);
            this.leftBegin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(58, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "区域宽度：";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "区域横坐标：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.21505F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.78494F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel1.Controls.Add(this.inStyle, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.delayTime, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.fontBold, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.multiIsVCenter, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.multiNAlignment, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.moduleType, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.height, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.topBegin, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.leftBegin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.width, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.areaType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.fontSize, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.speed, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.00492F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.35294F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.55882F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 299);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inStyle
            // 
            this.inStyle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.inStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inStyle.FormattingEnabled = true;
            this.inStyle.Items.AddRange(new object[] {
            "立即显示",
            "随机",
            "左移",
            "右移",
            "上移",
            "下移",
            "连续左移",
            "连续右移",
            "连续上移",
            "连续下移",
            "闪烁",
            "激光字(向上)",
            "激光字(向下)",
            "激光字(向左)",
            "激光字(向右)",
            "水平交叉拉幕",
            "上下交叉拉幕",
            "左右切入",
            "上下切入",
            "左覆盖",
            "右覆盖",
            "上覆盖",
            "下覆盖",
            "水平百叶(左右)",
            "水平百叶(右左)",
            "垂直百叶(上下)",
            "垂直百叶(下上)",
            "左右对开",
            "上下对开",
            "左右闭合",
            "上下闭合",
            "向左拉伸",
            "向右拉伸",
            "向上拉伸",
            "向下拉伸",
            "分散向左拉伸",
            "分散向右拉伸",
            "冒泡",
            "下雪"});
            this.inStyle.Location = new System.Drawing.Point(142, 225);
            this.inStyle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inStyle.Name = "inStyle";
            this.inStyle.Size = new System.Drawing.Size(133, 28);
            this.inStyle.TabIndex = 36;
            // 
            // delayTime
            // 
            this.delayTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.delayTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delayTime.Location = new System.Drawing.Point(552, 222);
            this.delayTime.Name = "delayTime";
            this.delayTime.Size = new System.Drawing.Size(132, 26);
            this.delayTime.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(58, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "进场动画：";
            // 
            // fontBold
            // 
            this.fontBold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fontBold.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fontBold.FormattingEnabled = true;
            this.fontBold.Items.AddRange(new object[] {
            "不加粗",
            "加粗"});
            this.fontBold.Location = new System.Drawing.Point(551, 179);
            this.fontBold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fontBold.Name = "fontBold";
            this.fontBold.Size = new System.Drawing.Size(133, 28);
            this.fontBold.TabIndex = 28;
            // 
            // multiIsVCenter
            // 
            this.multiIsVCenter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.multiIsVCenter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.multiIsVCenter.FormattingEnabled = true;
            this.multiIsVCenter.Items.AddRange(new object[] {
            "置顶",
            "垂直居中"});
            this.multiIsVCenter.Location = new System.Drawing.Point(551, 132);
            this.multiIsVCenter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.multiIsVCenter.Name = "multiIsVCenter";
            this.multiIsVCenter.Size = new System.Drawing.Size(133, 28);
            this.multiIsVCenter.TabIndex = 27;
            // 
            // multiNAlignment
            // 
            this.multiNAlignment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.multiNAlignment.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.multiNAlignment.FormattingEnabled = true;
            this.multiNAlignment.Items.AddRange(new object[] {
            "左对齐",
            "右对齐",
            "水平居中"});
            this.multiNAlignment.Location = new System.Drawing.Point(142, 132);
            this.multiNAlignment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.multiNAlignment.Name = "multiNAlignment";
            this.multiNAlignment.Size = new System.Drawing.Size(133, 28);
            this.multiNAlignment.TabIndex = 26;
            // 
            // moduleType
            // 
            this.moduleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moduleType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.moduleType.FormattingEnabled = true;
            this.moduleType.Location = new System.Drawing.Point(551, 87);
            this.moduleType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moduleType.Name = "moduleType";
            this.moduleType.Size = new System.Drawing.Size(133, 28);
            this.moduleType.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(58, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "字体大小：";
            // 
            // height
            // 
            this.height.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.height.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.height.Location = new System.Drawing.Point(552, 45);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(161, 26);
            this.height.TabIndex = 11;
            // 
            // topBegin
            // 
            this.topBegin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.topBegin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topBegin.Location = new System.Drawing.Point(552, 6);
            this.topBegin.Name = "topBegin";
            this.topBegin.Size = new System.Drawing.Size(161, 26);
            this.topBegin.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(453, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "区域纵坐标：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(467, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "区域高度：";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(58, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "区域类型：";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(30, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "水平对齐样式：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(439, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "是否垂直居中：";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(467, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "是否加粗：";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(439, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "输出模板类型：";
            // 
            // areaType
            // 
            this.areaType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.areaType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.areaType.FormattingEnabled = true;
            this.areaType.Items.AddRange(new object[] {
            "请选择",
            "多行文本输入",
            "单行文本输入",
            "数字日期",
            "数字时间",
            "模拟时钟"});
            this.areaType.Location = new System.Drawing.Point(142, 87);
            this.areaType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.areaType.Name = "areaType";
            this.areaType.Size = new System.Drawing.Size(133, 28);
            this.areaType.TabIndex = 24;
            // 
            // fontSize
            // 
            this.fontSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fontSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fontSize.Location = new System.Drawing.Point(143, 176);
            this.fontSize.Name = "fontSize";
            this.fontSize.Size = new System.Drawing.Size(132, 26);
            this.fontSize.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(30, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "动画显示速度：";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(439, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "页面留停时间：";
            // 
            // speed
            // 
            this.speed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.speed.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.speed.Location = new System.Drawing.Point(143, 265);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(132, 26);
            this.speed.TabIndex = 34;
            // 
            // moduleBindingSource
            // 
            this.moduleBindingSource.DataSource = typeof(Model.Module);
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.submit.Location = new System.Drawing.Point(154, 325);
            this.submit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(119, 35);
            this.submit.TabIndex = 1;
            this.submit.Text = "保存";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(410, 325);
            this.cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(121, 35);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // AreaDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(745, 402);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AreaDefine";
            this.Text = "区域编辑页面";
            this.Load += new System.EventHandler(this.AreaDefine_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.TextBox leftBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.TextBox topBegin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fontSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox areaType;
        private System.Windows.Forms.ComboBox moduleType;
        private System.Windows.Forms.ComboBox multiNAlignment;
        private System.Windows.Forms.ComboBox multiIsVCenter;
        private System.Windows.Forms.ComboBox fontBold;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.TextBox delayTime;
        private System.Windows.Forms.ComboBox inStyle;
        private System.Windows.Forms.BindingSource moduleBindingSource;
    }
}