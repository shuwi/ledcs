namespace LedScreen
{
    partial class ModuleDefine
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
            this.label2 = new System.Windows.Forms.Label();
            this.moduleText = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.moduleType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "模板内容：";
            // 
            // moduleText
            // 
            this.moduleText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.moduleText.Location = new System.Drawing.Point(135, 17);
            this.moduleText.Margin = new System.Windows.Forms.Padding(2);
            this.moduleText.Multiline = true;
            this.moduleText.Name = "moduleText";
            this.moduleText.Size = new System.Drawing.Size(306, 103);
            this.moduleText.TabIndex = 2;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.submit.Location = new System.Drawing.Point(135, 213);
            this.submit.Margin = new System.Windows.Forms.Padding(2);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(115, 35);
            this.submit.TabIndex = 3;
            this.submit.Text = "保存";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(325, 213);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(116, 35);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "模板类型：";
            // 
            // moduleType
            // 
            this.moduleType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.moduleType.Location = new System.Drawing.Point(135, 145);
            this.moduleType.Margin = new System.Windows.Forms.Padding(2);
            this.moduleType.Name = "moduleType";
            this.moduleType.Size = new System.Drawing.Size(306, 26);
            this.moduleType.TabIndex = 6;
            // 
            // ModuleDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(462, 291);
            this.Controls.Add(this.moduleType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.moduleText);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModuleDefine";
            this.Text = "模板编辑页";
            this.Load += new System.EventHandler(this.ModuleDefine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox moduleText;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox moduleType;
    }
}