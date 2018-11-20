using DAO;
using Model;
using Service;
using System;
using System.Windows.Forms;

namespace LedScreen
{
    public partial class LedModify : Form
    {
        private int id=-1;
        private LedInfo info;
        public LedModify()
        {
            InitializeComponent();
        }

        public LedModify(LedInfo info)
        {
            InitializeComponent();
            this.info = info;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            int tmp;
            if (ledIp.Text == "") {
                MessageBox.Show("led屏ip不能为空！");
                return;
            }
            if (width.Text=="") {
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
            
            try
            {
                if (id==-1)//新增led主参数
                {
                    string sqlStr = "insert into led_info(id,led_ip,width,height) values" +
                        "('" + ledIp.Text.Trim() + "','" + width.Text.Trim() + "','" + height.Text.Trim() + "',)";
                    SQLiteDBHelper.ExecuteNonQuery(sqlStr);
                    MessageBox.Show("保存成功！");
                }
                else
                {//编辑led主参数
                    string sqlStr = "update led_info set led_ip='"+ ledIp.Text.Trim() + "',width='"+ width.Text.Trim() + "',height='"+height.Text.Trim()+"' where id='"+ id + "'";
                    SQLiteDBHelper.ExecuteNonQuery(sqlStr);
                    MessageBox.Show("编辑成功！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败，请联系管理员！");
            }
        }

        private void LedModify_Load(object sender, EventArgs e)
        {
            id = info.Id;
            ledIp.Text = info.LedIp;
            width.Text = info.Width.ToString();
            height.Text = info.Height.ToString();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void areaSetting_Click(object sender, EventArgs e)
        {
            AreaManager moduleManager = new AreaManager(info);
            //   LedModify ledModify = new LedModify(info);
            moduleManager.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuleManager moduleManager = new ModuleManager();
            moduleManager.ShowDialog();
        }
    }
}
