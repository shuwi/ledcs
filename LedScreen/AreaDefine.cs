using DAO;
using Model;
using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LedScreen
{
    public partial class AreaDefine : Form
    {
        private ModuleInfo info;
        private WorkerService service;
        public AreaDefine()
        {
            InitializeComponent();
            service = new WorkerService();
        }

        public AreaDefine(ModuleInfo info)
        {
            InitializeComponent();
            this.info = info;
            service = new WorkerService();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            int tmp;
            if (leftBegin.Text == "")
            {
                MessageBox.Show("区域横坐标不能为空！");
                return;
            }
            if (topBegin.Text == "")
            {
                MessageBox.Show("区域纵坐标不能为空！");
                return;
            }
            if (width.Text == "")
            {
                MessageBox.Show("led屏宽度不能为空！");
                return;
            }
            else if (!int.TryParse(width.Text, out tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if (height.Text == "")
            {
                MessageBox.Show("led屏高度不能为空！");
                return;
            }
            else if (!int.TryParse(height.Text, out tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if (areaType.SelectedIndex<=0)
            {
                MessageBox.Show("区域类型必选！");
                return;
            }
            /*
            if (moduleType.Text==""||moduleType.Text=="请选择")
            {
                MessageBox.Show("输出模板类型必选！");
                return;
            }
            */
            if (multiNAlignment.SelectedIndex < 0)
            {
                if (areaType.SelectedIndex==1) {
                    MessageBox.Show("水平对齐样式必选！");
                    return;
                }
                
            }
            if (multiIsVCenter.SelectedIndex < 0)
            {
                if (areaType.SelectedIndex == 1)
                {
                    MessageBox.Show("是否垂直居中必选！");
                    return;
                }
            }
            if (fontSize.Text == "")
            {
                MessageBox.Show("字体大小不能为空！");
                return;
            }
            else if (!int.TryParse(fontSize.Text, out tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if (fontBold.SelectedIndex < 0)
            {
                MessageBox.Show("字体是否加粗必选！");
                return;                
            }
            if (inStyle.SelectedIndex < 0)
            {
                if (areaType.SelectedIndex == 2)
                {
                    MessageBox.Show("进场动画必选！");
                    return;
                }
                else {
                    inStyle.SelectedIndex = 0;
                }
            }
            if (delayTime.Text == "")
            {
                if (areaType.SelectedIndex == 2)
                {
                    MessageBox.Show("页面留停时间不能为空！");
                    return;
                }
                else {
                    delayTime.Text = "0";
                }
            }
            else if (!int.TryParse(delayTime.Text, out tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if (speed.Text == "")
            {
                if (areaType.SelectedIndex == 2)
                {
                    MessageBox.Show("页面留停时间不能为空！");
                    return;
                }
                else
                {
                    speed.Text = "0";
                }
            }
            else if (!int.TryParse(speed.Text, out tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            try
            {
                if (info.Id == 0)//新增led主参数
                {
                    string sqlStr = "insert into led_area(led_id,left_begin,top_begin,width,height,area_type,module_type," +
                        "multi_nAlignment,multi_IsVCenter,font_size,font_bold,in_style,delay_time,speed) values" +
                        "('" + info.Led_id + "','" + leftBegin.Text.Trim() + "','" + topBegin.Text.Trim() + "','" + width.Text.Trim() + "','" +
                        height.Text.Trim() + "','" + areaType.SelectedIndex + "','" + moduleType.Text + "','" + multiNAlignment.SelectedIndex + "','" +
                        multiIsVCenter.SelectedIndex + "','" + fontSize.Text.Trim() + "','" + fontBold.SelectedIndex + "','" + inStyle.SelectedIndex + "','" +
                        delayTime.Text.Trim() + "','" + speed.Text.Trim() + "')";
                    SQLiteDBHelper.ExecuteNonQuery(sqlStr);
                    MessageBox.Show("保存成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {//编辑led主参数

                    string sqlStr = "update led_area set left_begin='" + leftBegin.Text.Trim() + "',top_begin='" + topBegin.Text.Trim() + "'," +
                        "width='" + width.Text.Trim() + "',height='" + height.Text.Trim() + "',area_type ='" + areaType.SelectedIndex + "'," +
                        "module_type = '" + moduleType.Text + "',multi_nAlignment = '" + multiNAlignment.SelectedIndex + "'," +
                        "multi_IsVCenter='" + multiIsVCenter.SelectedIndex + "',font_size = '" + fontSize.Text.Trim() + "'," +
                        "font_bold='" + fontBold.SelectedIndex + "',in_style='" + inStyle.SelectedIndex + "',delay_time='" + delayTime.Text.Trim() + "'," +
                        "speed='" + speed.Text.Trim() + "' where id='" + info.Id + "'";
                    SQLiteDBHelper.ExecuteNonQuery(sqlStr);
                    MessageBox.Show("编辑成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败，请联系管理员！");
            }
        }

        private void AreaDefine_Load(object sender, EventArgs e)
        {
            string sql = "select module_type from led_module";
            DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
            if (table.Rows.Count>0) {
                for (int i = 0; i < table.Rows.Count; i++) {
                    moduleType.Items.Add(table.Rows[i]["module_type"]);
                }
            } else {
                MessageBox.Show("输出模板选项为空，请前往模板管理页面新增！");
            }
            if (info.Id>0)
            {
                leftBegin.Text = info.Left_begin.ToString();
                topBegin.Text = info.Top_begin.ToString();
                width.Text = info.Width.ToString();
                height.Text = info.Height.ToString();
                areaType.SelectedIndex = info.Area_type;
                moduleType.Text = info.Module_type;
                multiNAlignment.SelectedIndex = info.Multi_nAlignment;
                multiIsVCenter.SelectedIndex = info.Multi_IsVCenter;
                fontSize.Text = info.Font_size.ToString();
                fontBold.SelectedIndex =info.Font_bold;
                inStyle.SelectedIndex = info.In_style;
                delayTime.Text =info.Delay_time.ToString();
                speed.Text = info.Speed.ToString();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
