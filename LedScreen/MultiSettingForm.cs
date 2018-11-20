using DAO;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LedScreen
{
    public partial class MultiSettingForm : Form
    {
        private WorkerService workerService;
        public MultiSettingForm()
        {
            InitializeComponent();
            workerService = new WorkerService();

        }

        private void add_Click(object sender, EventArgs e)
        {
            var childForm = new PortManager();
            var result = childForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                MultiSettingForm_Load(sender, e);
            }
        }


        private void MultiSettingForm_Load(object sender, EventArgs e)
        {
            string sql = "select id,port as 串口,baud_rate as 波特率,(case tag when 1 then '进场' when 2 then '出场' end) as 人员状态 from setting_info";
            DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
            portData.DataSource = table;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            SettingInfo sForm = new SettingInfo();
            if (this.portData.SelectedRows.Count > 0)
            {
                if (this.portData.SelectedRows.Count == 1)
                {
                    var row = this.portData.SelectedRows[0].Cells;
                    // info. = ;
                    sForm.Id = Int32.Parse(row[0].Value.ToString());
                    sForm.Port = row[1].Value.ToString();
                    sForm.Baud_rate = row[2].Value.ToString();
                    sForm.Tag= row[3].Value.ToString();
                    var childForm = new PortManager(sForm);
                    var result = childForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MultiSettingForm_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("请选择一条数据进行编辑！");
                    return;
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> arr = new List<int>();
                int id;
                if (MessageBox.Show("您真的要删除吗？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.portData.SelectedRows.Count > 0)
                    {
                        for (var a = 0; a < this.portData.SelectedRows.Count; a++)
                        {
                            var row = this.portData.SelectedRows[a].Cells;
                            id = Int32.Parse(row[0].Value.ToString());
                            arr.Add(id);
                        }
                        string str = "(";
                        if (arr.Count > 0)
                        {
                            for (var a = 0; a < arr.Count; a++)
                            {
                                str += "'" + arr[a] + "',";
                            }
                        }
                        str = str.Substring(0, str.Length - 1) + ")";
                        string sql = "delete from setting_info where id in " + str;
                        SQLiteDBHelper.ExecuteNonQuery(sql);
                        MessageBox.Show("删除成功", "提示");
                        MultiSettingForm_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("请先选择数据！", "提示");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("删除失败，请联系管理员！");
            }
        }
    }
}
