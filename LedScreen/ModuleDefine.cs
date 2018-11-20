using DAO;
using Model;
using Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace LedScreen
{
    public partial class ModuleDefine : Form
    {
        private Module minfo;
        public ModuleDefine()
        {
            InitializeComponent();
        }

        public ModuleDefine(Module minfo)
        {
            this.minfo = minfo;
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (moduleText.Text=="") {
                MessageBox.Show("模板内容必填！");
                return;
            }
            if (moduleType.Text =="")
            {
                MessageBox.Show("模板类型必填！");
                return;
            }
            
            string sql = "";
            try {
                if (this.minfo== null)
                {
                    string checkSql = "select * from led_module where module_type='" + moduleType.Text + "'";
                    DataTable table = SQLiteDBHelper.ExecuteDataTable(checkSql);
                    if (table != null && table.Rows.Count > 0)
                    {
                        MessageBox.Show("此类型模板已存在，请前往列表页进行操作！");
                        return;
                    }
                    sql = "insert into led_module (module_type,module_text) values ('"+ moduleType.Text + "','" + moduleText.Text.Trim() + "')";

                }
                else {
                    if (minfo.Module_type!= moduleType.Text) {
                        string checkSql = "select * from led_module where module_type='" + moduleType.Text + "'";
                        DataTable table = SQLiteDBHelper.ExecuteDataTable(checkSql);
                        if (table != null && table.Rows.Count > 0)
                        {
                            MessageBox.Show("此类型模板已存在，请前往列表页进行操作！");
                            return;
                        }
                        else {
                            sql = "update led_module set module_type ='" + moduleType.Text + "',module_text='" + moduleText.Text.Trim() + "' where id=" + this.minfo.Id;
                        }
                    }
                    sql = "update led_module set module_type ='"+ moduleType.Text + "',module_text='" + moduleText.Text.Trim() + "' where id="+this.minfo.Id;
                }
                SQLiteDBHelper.ExecuteNonQuery(sql);
                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception) {
                MessageBox.Show("保存失败，请联系管理员！");
                return;
            }

        }

        private void ModuleDefine_Load(object sender, EventArgs e)
        {
            if (this.minfo!=null) {
                moduleText.Text = this.minfo.Module_text;
                moduleType.Text = this.minfo.Module_type;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
