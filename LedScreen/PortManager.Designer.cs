namespace LedScreen
{
    partial class PortManager
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
            this.port = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baudRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.personStatus = new System.Windows.Forms.ComboBox();
            this.add = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号：";
            // 
            // port
            // 
            this.port.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.port.FormattingEnabled = true;
            this.port.Location = new System.Drawing.Point(124, 21);
            this.port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(130, 29);
            this.port.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(269, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // baudRate
            // 
            this.baudRate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baudRate.Location = new System.Drawing.Point(369, 21);
            this.baudRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(108, 29);
            this.baudRate.TabIndex = 3;
            this.baudRate.Text = "9600";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-1, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "人员状态：";
            // 
            // personStatus
            // 
            this.personStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.personStatus.FormattingEnabled = true;
            this.personStatus.Items.AddRange(new object[] {
            "请选择",
            "进场",
            "出场"});
            this.personStatus.Location = new System.Drawing.Point(124, 83);
            this.personStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.personStatus.Name = "personStatus";
            this.personStatus.Size = new System.Drawing.Size(130, 29);
            this.personStatus.TabIndex = 5;
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.add.Location = new System.Drawing.Point(124, 142);
            this.add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(130, 37);
            this.add.TabIndex = 6;
            this.add.Text = "保存";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(353, 142);
            this.cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(124, 37);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // PortManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(511, 218);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.add);
            this.Controls.Add(this.personStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PortManager";
            this.Text = "串口编辑页面";
            this.Load += new System.EventHandler(this.PortManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox baudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox personStatus;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button cancel;
    }
}