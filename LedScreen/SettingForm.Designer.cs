namespace LedScreen
{
    partial class SettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSerialPort = new System.Windows.Forms.ComboBox();
            this.lable2 = new System.Windows.Forms.Label();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxValidate = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // cbxSerialPort
            // 
            this.cbxSerialPort.FormattingEnabled = true;
            this.cbxSerialPort.Location = new System.Drawing.Point(228, 64);
            this.cbxSerialPort.Name = "cbxSerialPort";
            this.cbxSerialPort.Size = new System.Drawing.Size(156, 26);
            this.cbxSerialPort.TabIndex = 1;
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Location = new System.Drawing.Point(122, 140);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(62, 18);
            this.lable2.TabIndex = 2;
            this.lable2.Text = "波特率";
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Items.AddRange(new object[] {
            "9600",
            "4800",
            "2400",
            "1800",
            "1200"});
            this.cbxBaudRate.Location = new System.Drawing.Point(228, 140);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(156, 26);
            this.cbxBaudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "校验位";
            // 
            // cbxValidate
            // 
            this.cbxValidate.FormattingEnabled = true;
            this.cbxValidate.Items.AddRange(new object[] {
            "None"});
            this.cbxValidate.Location = new System.Drawing.Point(228, 213);
            this.cbxValidate.Name = "cbxValidate";
            this.cbxValidate.Size = new System.Drawing.Size(156, 26);
            this.cbxValidate.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(374, 288);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 45);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 345);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbxValidate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxBaudRate);
            this.Controls.Add(this.lable2);
            this.Controls.Add(this.cbxSerialPort);
            this.Controls.Add(this.label1);
            this.Name = "SettingForm";
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSerialPort;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxValidate;
        private System.Windows.Forms.Button btnOK;
    }
}