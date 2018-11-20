using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using Microsoft.Win32;
using Service;

namespace LedScreen
{
    public partial class SettingForm : Form
    {
        private WorkerService service;
        public SettingForm()
        {
            InitializeComponent();
            service=new WorkerService();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            GetComList();

        }


        /// <summary> 
        /// 从注册表获取系统串口列表 
        /// </summary> 
        private void GetComList()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                cbxSerialPort.Items.Clear();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    cbxSerialPort.Items.Add(sValue);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //获取用户设置的配置内容，并保存到数据库，数据库ledscreen,表名 setting_info
                string execSql = "delete from setting_info";
                SQLiteDBHelper.ExecuteNonQuery(execSql);
                string serialPort = this.cbxSerialPort.Text.Trim();
                string baudRate = this.cbxBaudRate.Text.Trim();
                string oddEvenValid = this.cbxValidate.Text.Trim();
                string sql = "insert into setting_info(port,baud_rate,odd_even_valid) values('" + serialPort + "','" +
                             baudRate + "','" + oddEvenValid + "')";
                int count = SQLiteDBHelper.ExecuteNonQuery(sql);
                if (count > 0)
                {
                    MessageBox.Show("参数设置成功！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("参数设置失败！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("参数设置出错", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
