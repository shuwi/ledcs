using DAO;
using Model;
using Newtonsoft.Json.Linq;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net.Http;
using System.Windows.Forms;

/**
* 作者：haoran xu
* 时间：2018/3/22 15:20:48
* 版权：星云网格
*
*/
namespace LedScreen
{
    public class SerialDataReceiveHandler
    {
        public delegate void HandleInterfaceUpdataDelegate(string text); //委托，此为重点 
        private HandleInterfaceUpdataDelegate interfaceUpdataHandle;
        private WorkerService workerService;
        public SerialPort MySerialPort;
        public Control MControl;
        //Tag指的就是串口tag
        public int Tag;
        //出勤人员头像图片数组
        private List<Image> images;
        private ListBox lstBoxWorker;
        private PictureBox inuser;
        private PictureBox outuser;
        private Label nowinname;
        private Label nowoutname;
        private Label nowindate;
        private Label nowoutdate;
        private Label nowingroup;
        private Label nowoutgroup;
        private Label nowintime;
        private Label nowouttime;
        private Label nowinjob;
        private Label nowoutjob;
        public SerialDataReceiveHandler()
        {

        }

        public SerialDataReceiveHandler(SerialPort serialPort, Control control)
        {
            this.MySerialPort = serialPort;
            this.MControl = control;
            interfaceUpdataHandle = new HandleInterfaceUpdataDelegate(UpdateSerialPortData);//实例化委托对象 
        }

        public SerialDataReceiveHandler(SerialPort serialPort,
            Control control,
            int tag,
            ListBox lstBoxWorker,
            List<Image> images,
            PictureBox inuser,
            PictureBox outuser,
            Label nowinname,
            Label nowoutname,
            Label nowindate,
            Label nowoutdate,
            Label nowingroup,
            Label nowoutgroup,
            Label nowintime,
            Label nowouttime,
            Label nowinjob,
            Label nowoutjob
            ) : this(serialPort, control)
        {
            workerService = new WorkerService();
            this.Tag = tag;
            this.images = images;
            this.lstBoxWorker = lstBoxWorker;
            this.inuser = inuser;
            this.outuser = outuser;
            this.nowinname = nowinname;
            this.nowoutname = nowoutname;
            this.nowindate = nowindate;
            this.nowoutdate = nowoutdate;
            this.nowingroup = nowingroup;
            this.nowoutgroup = nowoutgroup;
            this.nowintime = nowintime;
            this.nowouttime = nowouttime;
            this.nowinjob = nowinjob;
            this.nowoutjob = nowoutjob;
        }

        public void Sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                int i = this.MySerialPort.BytesToRead;
                if (i > 0)
                {
                    try
                    {
                        string message = this.MySerialPort.ReadLine();
                        this.MControl.Invoke(interfaceUpdataHandle, message);

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            catch
            {

            }
        }

        public void UpdateSerialPortData(String message)
        {
            try
            {
                if (message.IndexOf("\r") == -1)
                {
                    return;
                }
                message = message.Replace("\r", "").Replace("\n", "");
                if (message.Length < 20)
                {
                    return;
                }
                if (message.Substring(0, 3).IndexOf("000") != -1)
                {
                    message = message.Substring(3, message.Length - 3) + "X";
                }
                else if (message.Substring(0, 2).IndexOf("00") != -1)
                {
                    int len = message.Length;
                    message = message.Substring(2, len - 2);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("请重新考勤");
                return;
            }

            switch (this.Tag)
            {
                case 1:
                    getUserInfo(message, 1);
                    ledcheckInfo(ConfigurationManager.AppSettings["prorealname"].ToString(), message, 1);
                    UserInOut(message, 1);
                    Console.WriteLine("进场");
                    break;
                case 2:
                    getUserInfo(message, 0);
                    ledcheckInfo(ConfigurationManager.AppSettings["prorealname"].ToString(), message, 0);
                    UserInOut(message, 0);
                    Console.WriteLine(workerService.GetJobCountLEDInfo());
                    Console.WriteLine("离场");
                    break;
                default:
                    MessageBox.Show(message);
                    break;
            }

        }

        public void getUserInfo(string message, int type)
        {

            string sql = "select * from worker where identityId = '" + message + "';";
            DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
            if (table.Rows.Count == 0)
            {
                Console.WriteLine("查无数据，可能正在远程获取，请确保项目名和身份证号录入正确！");
                return;
            }
            DataRow row = table.Rows[0];

            string userInfo = string.Format("{0} [{1}]\n{2}（{3}）", row["username"].ToString(), row["job"].ToString(), DateTime.Now.ToString("MM月dd日 HH:mm:ss"), (type == 1 ? "进场" : "出场"));

            string updateuser = string.Format("update worker set checkinState = {0},checkinTime = '{1}' where identityId = '{2}';", type, DateTime.Now.ToString("yyyy-MM-dd"), message);
            SQLiteDBHelper.ExecuteNonQuery(updateuser);
            string base64 = "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";
            if ("" != row["identityPhoto"].ToString())
                base64 = row["identityPhoto"].ToString();
            if (images.Count > 3)
            {
                this.lstBoxWorker.Items.Clear();
                images.Clear();
            }
            Bitmap b = new Bitmap(new MemoryStream(Convert.FromBase64String(base64)));
            images.Add(b);
            lstBoxWorker.ScrollAlwaysVisible = false;
            lstBoxWorker.Items.Add(userInfo);
            if (type == 1)
            {
                this.inuser.BackgroundImage = b;
                this.nowinname.Text = row["username"].ToString();
                this.nowindate.Text = DateTime.Now.ToString("MM月dd日");
                this.nowingroup.Text = row["job"].ToString() + "组";
                this.nowinjob.Text = row["job"].ToString();
                this.nowintime.Text = DateTime.Now.ToString("HH:mm");
            }
            else {
                this.outuser.BackgroundImage = b;
                this.nowoutname.Text = row["username"].ToString();
                this.nowoutdate.Text = DateTime.Now.ToString("MM月dd日");
                this.nowoutgroup.Text = row["job"].ToString() + "组";
                this.nowoutjob.Text = row["job"].ToString();
                this.nowouttime.Text = DateTime.Now.ToString("HH:mm");
            }
        }
        /// <summary>
        /// 控制LED实时显示
        /// </summary>
        /// <param name="proname"></param>
        /// <param name="identityId"></param>
        public void ledcheckInfo(string proname, string identityId, int checktype)
        {
            GetUserInfo(identityId, proname, checktype);
            string sql = "select * from worker where identityId = '" + identityId + "';";
            DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string userInfo = row["job"].ToString() + row["username"].ToString() + (checktype == 1 ? "进场" : "出场");
                workerService.Ledcontrol(workerService.GetLEDInfo(), identityId, checktype);
            }

        }

        /// <summary>
        /// 通用方法：根据用户身份证号和项目名联网获取用户信息
        /// </summary>
        /// <param name="userId">用户身份证号</param>
        /// <param name="projectName">项目名</param>
        private async void GetUserInfo(string userId, string projectName, int checktype)
        {
            string postURL = ConfigurationManager.AppSettings["postSingleURL"].ToString();
            string data = JObject.FromObject(new
            {
                userInfo = new
                {
                    userId = userId,
                    projectName = projectName
                }
            }).ToString();
            try
            {
                string task = await CommonUtil.GetResponseAsync(postURL, data);
            
                JObject jj = JObject.Parse(task);
                UserInfo v = jj["items"].ToObject<UserInfo>();
                if (null == v.userId)
                {
                    CommonUtil.DebugConsole("数据解析错误");
                    return;
                }
                Userinfoopt(v, checktype);
            }
            catch (Exception ex) { CommonUtil.DebugConsole("数据解析错误" + ex.Message); }
        }

        /// <summary>
        /// 根据联网获取的用户信息同步至本地数据库
        /// </summary>
        /// <param name="ui">联网获取的用户对象</param>
        /// <param name="checktype">1：检入；0：检出</param>
        private void Userinfoopt(UserInfo ui, int checktype)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = SQLiteDBHelper.ExecuteDataTable("select * from worker where identityId = '" + ui.userId + "';");
                DataRow row = null;
                if (dt.Rows.Count > 0)
                    row = dt.Rows[0];

                ///本地已有数据则更新工人状态
                if (null != row)
                {
                    string sql = string.Format("update worker set checkinState = {0},checkinTime = '{1}',job='{2}',groupname='{3}' where identityId='{4}';", checktype, DateTime.Now.ToString("yyyy-MM-dd"), ui.workKindName, ui.projectName, ui.userId);
                    SQLiteDBHelper.ExecuteNonQuery(sql);
                    return;
                }
                string insertsql = string.Format("insert into worker(identityId,username,contact,job,groupname,addtime,checkinState,checkinTime,identityPhoto)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');",
                    ui.userId,
                    ui.userName,
                    ui.mobile,
                    ui.workKindName,
                    ui.projectName,
                    ui.createTime,
                    checktype,
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    ui.photo
                    );
                if (SQLiteDBHelper.ExecuteNonQuery(insertsql) > 0)
                    Console.WriteLine("新增用户成功");
            }
        }

        private void UserInOut(String userid, int checktype)
        {
            string insertsql = string.Format("insert into workerinout(identityId,checkinState,checkinTime)values('{0}',{1},'{2}');",
                    userid,
                    checktype,
                    DateTime.Now.ToString("yyyy-MM-dd")
                    );
            if (SQLiteDBHelper.ExecuteNonQuery(insertsql) > 0)
                Console.WriteLine("新增用户考勤信息成功");
        }

    }
}
