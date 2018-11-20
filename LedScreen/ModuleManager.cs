using DAO;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LedScreen
{
    public partial class ModuleManager : Form
    {
        private WorkerService service;
        public ModuleManager()
        {
            InitializeComponent();
            service = new WorkerService();
        }

        private void add_Click(object sender, EventArgs e)
        {
            var childForm = new ModuleDefine();
            var result = childForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ModuleManager_Load(sender, e);
            }
        }

        private void ModuleManager_Load(object sender, EventArgs e)
        {
            string sql = "select id,module_type as 模板类型,module_text as 内容 from led_module";
            DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
            moduleList.DataSource = table;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            Module minfo = new Module();
            if (this.moduleList.SelectedRows.Count > 0)
            {
                if (this.moduleList.SelectedRows.Count == 1)
                {
                    var row = this.moduleList.SelectedRows[0].Cells;
                    // info. = ;
                    minfo.Id = Int32.Parse(row[0].Value.ToString());
                    minfo.Module_type = row[1].Value.ToString();
                    minfo.Module_text = row[2].Value.ToString();
                    var childForm = new ModuleDefine(minfo);
                    var result = childForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        ModuleManager_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("请选择一条数据进行编辑！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的数据！");
                return;
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
                    if (this.moduleList.SelectedRows.Count > 0)
                    {
                        for (var a = 0; a < this.moduleList.SelectedRows.Count; a++)
                        {
                            var row = this.moduleList.SelectedRows[a].Cells;
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
                        string sql = "delete from led_module where id in " + str;
                        SQLiteDBHelper.ExecuteNonQuery(sql);
                        MessageBox.Show("删除成功", "提示");
                        ModuleManager_Load(sender, e);
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
