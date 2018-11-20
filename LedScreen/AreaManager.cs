using DAO;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LedScreen
{
    public partial class AreaManager : Form
    {
        private LedInfo info;
        private WorkerService service;

        public AreaManager()
        {
            InitializeComponent();
            service = new WorkerService();
        }

        public AreaManager(LedInfo info)
        {
            InitializeComponent();
            this.info = info;
            service = new WorkerService();
        }

        private void add_Click(object sender, EventArgs e)
        {
            ModuleInfo minfo = new ModuleInfo();
            minfo.Led_id = info.Id;
            var childForm = new AreaDefine(minfo);
            var result = childForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ModuleManager_Load(sender, e);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            ModuleInfo minfo = new ModuleInfo();
            minfo.Led_id = info.Id;
            if (this.moduleList.SelectedRows.Count > 0)
            {
                if (this.moduleList.SelectedRows.Count == 1)
                {
                    var row = this.moduleList.SelectedRows[0].Cells;
                   // info. = ;
                    minfo.Id = Int32.Parse(row[0].Value.ToString());
                    minfo.Left_begin = Int32.Parse(row[1].Value.ToString());
                    minfo.Top_begin = Int32.Parse(row[2].Value.ToString());
                    minfo.Width = Int32.Parse(row[3].Value.ToString());
                    minfo.Height = Int32.Parse(row[4].Value.ToString());
                    minfo.Area_type = Int32.Parse(row[5].Value.ToString());
                    minfo.Module_type = row[6].Value.ToString();
                    minfo.Multi_nAlignment = Int32.Parse(row[7].Value.ToString());
                    minfo.Multi_IsVCenter = Int32.Parse(row[8].Value.ToString());
                    minfo.Font_size = Int32.Parse(row[9].Value.ToString());
                    minfo.Font_bold = Int32.Parse(row[10].Value.ToString());
                    minfo.In_style = Int32.Parse(row[11].Value.ToString());
                    minfo.Delay_time = Int32.Parse(row[12].Value.ToString());
                    minfo.Speed = Int32.Parse(row[13].Value.ToString());
                    var childForm = new AreaDefine(minfo);
                    var result = childForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        ModuleManager_Load(sender,e);
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

        private void ModuleManager_Load(object sender, EventArgs e)
        {
            string sql = "select id,left_begin as 区域横坐标,top_begin as 区域纵坐标,"+
                "width as 区域宽度,height as 区域高度,area_type as 区域类型,module_type as 输出模板类型,multi_nAlignment as 水平对齐样式," +
                "multi_IsVCenter as 是否垂直居中,font_size as 字体大小,font_bold as 是否加粗,in_style as 进场动画,delay_time as 页面留停时间,"+
                "speed as 动画的显示速度 from led_area where led_id='" + info.Id+"'";
            DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
            moduleList.DataSource = table;
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
                        string sql = "delete from led_area where id in " + str;
                        SQLiteDBHelper.ExecuteNonQuery(sql);
                        MessageBox.Show("删除成功", "提示");
                        ModuleManager_Load(sender,e);
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
