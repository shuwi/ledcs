using DAO;
using Microsoft.Win32;
using Model;
using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LedScreen
{
    public partial class PortManager : Form
    {
        private WorkerService service;
        private SettingInfo sForm;

        public PortManager()
        {
            InitializeComponent();
            service = new WorkerService();
        }

        public PortManager(SettingInfo sForm)
        {
            this.sForm = sForm;
            InitializeComponent();
            service = new WorkerService();
        }

        private void PortManager_Load(object sender, EventArgs e)
        {
            GetComList();
            if (this.sForm != null)
            {
                port.Text = this.sForm.Port;
                baudRate.Text = this.sForm.Baud_rate;
                personStatus.Text = this.sForm.Tag;
            }
        }
        private void GetComList()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                //string[] sSubKeys = { "串口1", "串口2", "串口3", "串口4", "串口5", "串口6", "串口7", "串口8", "串口9", "串口10", "串口11", "串口12", "串口13", "串口14" };
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    //string sValue = sName;
                    // combo.Items.Clear();
                    port.Items.Add(sValue);
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (port.Text.Trim() == "")
            {
                MessageBox.Show("串口号必选！");
                return;
            }
            if (personStatus.SelectedIndex <= 0)
            {
                MessageBox.Show("人员状态必选！");
                return;
            }
            if (baudRate.Text.Trim() == "")
            {
                MessageBox.Show("比特率必填！");
                return;
            }
            string sql = "";
            
                if (personStatus.SelectedIndex == 1)
                {
                    if (this.sForm == null)
                    {
                        string checkSql = "select * from setting_info where port='" + port.Text.Trim() + "'";
                        DataTable table = SQLiteDBHelper.ExecuteDataTable(checkSql);
                        if (table != null && table.Rows.Count > 0)
                        {
                            MessageBox.Show("此串口已被占用！");
                            return;
                        }
                        sql = "insert into setting_info (port,baud_rate,odd_even_valid,tag) values ('" + port.Text.Trim() + "','" + baudRate.Text.Trim() + "','None',1)";
                    }
                    else
                    {
                        if (this.sForm.Port != port.Text.Trim())
                        {
                            string checkSql = "select * from setting_info where port='" + port.Text.Trim() + "'";
                            DataTable table = SQLiteDBHelper.ExecuteDataTable(checkSql);
                            if (table != null && table.Rows.Count > 0)
                            {
                                MessageBox.Show("此串口已被占用！");
                                return;
                            }
                            else
                            {
                                sql = "update setting_info set port='" + port.Text.Trim() + "',baud_rate='" + baudRate.Text.Trim() + "' where id=" + this.sForm.Id;
                            }
                        }
                        sql = "update setting_info set port='" + port.Text.Trim() + "',baud_rate='" + baudRate.Text.Trim() + "',tag='"+ personStatus.SelectedIndex + "' where id=" + this.sForm.Id;
                    }
                }
                else
                {

                    if (this.sForm == null)
                    {
                        string checkSql = "select * from setting_info where port='" + port.Text.Trim() + "'";
                        DataTable table = SQLiteDBHelper.ExecuteDataTable(checkSql);
                        if (table != null && table.Rows.Count > 0)
                        {
                            MessageBox.Show("此串口已被占用！");
                            return;
                        }
                        sql = "insert into setting_info (port,baud_rate,odd_even_valid,tag) values ('" + port.Text.Trim() + "','" + baudRate.Text.Trim() + "','None',2)";
                    }
                    else
                    {
                        if (this.sForm.Port != port.Text.Trim())
                        {
                            string checkSql = "select * from setting_info where port='" + port.Text.Trim() + "'";
                            DataTable table = SQLiteDBHelper.ExecuteDataTable(checkSql);
                            if (table != null && table.Rows.Count > 0)
                            {
                                MessageBox.Show("此串口已被占用！");
                                return;
                            }
                            else
                            {
                                sql = "update setting_info set port='" + port.Text.Trim() + "',baud_rate='" + baudRate.Text.Trim() + "' where id=" + this.sForm.Id;
                            }
                        }
                        sql = "update setting_info set port='" + port.Text.Trim() + "',baud_rate='" + baudRate.Text.Trim() + "',tag='" + personStatus.SelectedIndex + "' where id=" + this.sForm.Id;
                    }
                }
                SQLiteDBHelper.ExecuteNonQuery(sql);
                MessageBox.Show("串口保存成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
