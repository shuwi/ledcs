using DAO;
using Model;
using Newtonsoft.Json.Linq;
using NVRCsharpDemo;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LedScreen
{
    public partial class Home : Form
    {

        public delegate void HandleInterfaceUpdataDelegate(string text); //委托，此为重点 
        private HandleInterfaceUpdataDelegate interfaceUpdataHandle;
        private WorkerService workerService;
        private Color RowBackColorAlt = Color.FromArgb(32, 32, 48);//交替色 
        private Color RowBackColorSel = Color.FromArgb(32, 32, 48);//选择项目颜色 
        private Color BorderColor = Color.FromArgb(178, 178, 185);
        private ArrayList serialPortsList;
        private int Step = 0;

        /*****视频监控部分******/
        private bool m_bInitSDK = false;
        //private bool m_bRecord = false;
        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private Int32 m_lRealHandle = -1;
        private string str1;
        private string str2;
        private Int32 i = 0;
        private Int32 m_lTree = 0;
        private string str;
        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        private int[] iIPDevID = new int[96];
        private int[] iChannelNum = new int[96];
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_STREAM_MODE m_struStreamMode;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;
        public CHCNetSDK.NET_DVR_IPCHANINFO_V40 m_struChanInfoV40;
        public delegate void MyDebugInfo(string str);

        /*****以上为视频监控所需字段*******/

        //出勤人员头像图片数组
        private List<Image> images = new List<Image>();
        static DataTable dtb = new DataTable();
        private DataRow currentUserInfo = dtb.NewRow();
        string pname = "";

        double formWidth;//窗体原始宽度
        double formHeight;//窗体原始高度
        double scaleX;//水平缩放比例
        double scaleY;//垂直缩放比例
        Dictionary<string, string> ControlsInfo = new Dictionary<string, string>();//控件中心Left,Top,控件Width,控件Height,控件字体Size

        protected void GetAllInitInfo(Control ctrlContainer)
        {
            if (ctrlContainer.Parent == this)//获取窗体的高度和宽度
            {
                formWidth = Convert.ToDouble(ctrlContainer.Width);
                formHeight = Convert.ToDouble(ctrlContainer.Height);
            }
            foreach (Control item in ctrlContainer.Controls)
            {
                if (item.Name.Trim() != "")
                {
                    //添加信息：键值：控件名，内容：据左边距离，距顶部距离，控件宽度，控件高度，控件字体。
                    ControlsInfo.Add(item.Name, (item.Left + item.Width / 2) + "," + (item.Top + item.Height / 2) + "," + item.Width + "," + item.Height + "," + item.Font.Size);
                }
                if ((item as UserControl) == null && item.Controls.Count > 0)
                {
                    GetAllInitInfo(item);
                }
            }

        }
        private void ControlsChaneInit(Control ctrlContainer)
        {
            scaleX = (Convert.ToDouble(ctrlContainer.Width) / formWidth);
            scaleY = (Convert.ToDouble(ctrlContainer.Height) / formHeight);
        }
        /// <summary>
        /// 改变控件大小
        /// </summary>
        /// <param name="ctrlContainer"></param>
        private void ControlsChange(Control ctrlContainer)
        {
            double[] pos = new double[5];//pos数组保存当前控件中心Left,Top,控件Width,控件Height,控件字体Size
            foreach (Control item in ctrlContainer.Controls)//遍历控件
            {
                if (item.Name.Trim() != "")//如果控件名不是空，则执行
                {
                    if ((item as UserControl) == null && item.Controls.Count > 0)//如果不是自定义控件
                    {
                        ControlsChange(item);//循环执行
                    }
                    string[] strs = ControlsInfo[item.Name].Split(',');//从字典中查出的数据，以‘，’分割成字符串组

                    for (int i = 0; i < 5; i++)
                    {
                        pos[i] = Convert.ToDouble(strs[i]);//添加到临时数组
                    }
                    double itemWidth = pos[2] * scaleX;     //计算控件宽度，double类型
                    double itemHeight = pos[3] * scaleY;    //计算控件高度
                    item.Left = Convert.ToInt32(pos[0] * scaleX - itemWidth / 2);//计算控件距离左边距离
                    item.Top = Convert.ToInt32(pos[1] * scaleY - itemHeight / 2);//计算控件距离顶部距离
                    item.Width = Convert.ToInt32(itemWidth);//控件宽度，int类型
                    item.Height = Convert.ToInt32(itemHeight);//控件高度
                    float emSize = float.Parse((pos[4] * Math.Min(scaleX, scaleY)).ToString());
                    if (emSize > System.Single.MaxValue)
                        emSize = System.Single.MaxValue;
                    if (emSize <= 0)
                        emSize = 12;
                    item.Font = new Font(item.Font.Name, emSize);//字体
                    item.Refresh();
                }
            }

        }

        public Home()
        {
            InitializeComponent();

            workerService = new WorkerService();
            //lstBoxWorker.DrawMode = DrawMode.OwnerDrawVariable;
            //lstBoxWorker.ItemHeight = 100;
            serialPortsList = new ArrayList();
            OpenCameraWatch();
            pname = CommonUtil.GetConfigValue("prorealname");//确保填写正确，用于远程获取时传参
            this.labproname.Text = CommonUtil.GetConfigValue("proname");//用于定制显示项目名;
            this.slogen.Text = CommonUtil.GetConfigValue("slogen");
            this.foundation.Text = CommonUtil.GetConfigValue("foundation");


            //this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 
            this.AutoScaleMode = AutoScaleMode.Font;
            tlp.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tlp, true, null);

            GetcountFromURL(pname);
            UpadteAllAtUsers(pname);

            GetAllInitInfo(this.Controls[0]);
            this.GetWeatherAsync();
            this.logo();

            this.labelTime.Text = DateTime.Now.ToString("yyyy年 MM月dd日 dddd");
            this.timenow.Text = DateTime.Now.ToString("T");

        }

        private void logo()
        {
            Bitmap b = new Bitmap(new MemoryStream(Convert.FromBase64String(CommonUtil.GetConfigValue("logo"))));
            Bitmap cr = new Bitmap(new MemoryStream(Convert.FromBase64String(CommonUtil.GetConfigValue("bgpic"))));
            this.logopic.BackgroundImage = b;
            this.panel4.BackgroundImage = cr;
        }

        /// <summary>
        /// 查询各工种考勤统计信息
        /// </summary>
        private void UpdateWorkerJobCount()
        {
            string sql = "select distinct job from worker where groupname='" + ConfigurationManager.AppSettings["prorealname"].ToString() + "';";
            DataTable dt = SQLiteDBHelper.ExecuteDataTable(sql);
            if (dt.Rows.Count <= 0)
                return;
            
            if (this.Step < Math.Ceiling((double)dt.Rows.Count / 10))
            {
                tlp.Controls.Clear();
                int s = this.Step * 10;
                for (int i = s; i < 10 * (this.Step + 1); i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        
                        jobLableGroup(dt, i);
                    }
                        
                }
                this.Step++;
            }
            else
            {
                this.Step = 0;
            }

        }
        private void jobLableGroup(DataTable dt, int i)
        {
            try
            {
                Label lab = new Label();
                string countsql = string.Format("select count(id) as count from worker where groupname = '{0}' and job = '{1}' and DATE(checkinTime) = '{2}';",
                    pname,
                    dt.Rows[i]["job"].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd")
                    );
                DataTable dtt = SQLiteDBHelper.ExecuteDataTable(countsql);
                string output = "";
                if (dtt.Rows.Count > 0)
                    output = "\n考勤人数：" + dtt.Rows[0]["count"].ToString();
                lab.Text = dt.Rows[i]["job"].ToString() + output;
                lab.AutoSize = true;
                FontFamily ff = new FontFamily("微软雅黑");
                //lab.Font = new Font(ff, 16, FontStyle.Regular, GraphicsUnit.World);
                //通过Anchor 设置Label 列居中
                lab.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                tlp.Controls.Add(lab);
            }
            catch (Exception ex) { Console.WriteLine(string.Format("考勤人数查询出错：{0}", ex.Message)); }
        }
        /// <summary>
        /// 线上查询各工种考勤统计信息
        /// </summary>
        private async void UpdateWorkerJobCountOnlineAsync()
        {
            
            string postURL = ConfigurationManager.AppSettings["getRecordInfoByWork"].ToString();
            string data = JObject.FromObject(new
            {
                projectName = ConfigurationManager.AppSettings["prorealname"].ToString()
            }).ToString();
            try
            {
                string task = await CommonUtil.GetResponseAsync(postURL, data);
                JObject jj = JObject.Parse(task);
                IList<JToken> results = jj["record"].Children().ToList();
                IList<Record> searchResults = new List<Record>();
                foreach (JToken result in results)
                {
                    Record searchResult = result.ToObject<Record>();
                    searchResults.Add(searchResult);
                }

                if (this.Step < Math.Ceiling((double)searchResults.Count / 10))
                {
                    tlp.Controls.Clear();
                    int s = this.Step * 10;
                    for (int i = s; i < 10 * (this.Step + 1); i++)
                    {
                        
                        if (i < searchResults.Count)
                        {
                            
                            setJobCountGroup(searchResults[i]);
                        }
                    }
                    this.Step++;
                }
                else
                {
                    this.Step = 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("***" + ex.Message);
            }
        }
        private void setJobCountGroup(Record r)
        {

            Label lab = new Label();
            string output = "";

            output = "\n考勤人数：" + r.count.ToString();
            lab.Text = r.workKindName + output;
            lab.AutoSize = true;
            FontFamily ff = new FontFamily("微软雅黑");
            //lab.Font = new Font(ff, 16, FontStyle.Regular, GraphicsUnit.World);
            //通过Anchor 设置Label 列居中
            lab.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            tlp.Controls.Add(lab);

        }
        /// <summary>
        /// 在线获取项目考勤人数
        /// </summary>
        /// <param name="pname">项目名</param>
        public async void GetcountFromURL(string pname)
        {
            string data = JObject.FromObject(new
            {
                userInfo = new
                {
                    projectName = pname
                }
            }).ToString();
            try
            {
                string task = await CommonUtil.GetResponseAsync(CommonUtil.GetConfigValue("postCountURL"), data);
                JObject jj = JObject.Parse(task);
                string v = jj["record"].ToObject<string>();
                Console.WriteLine("%%%%%%");
                Console.WriteLine(task);
                this.label6.Text = v;
            }
            catch (Exception ex)
            {
                Console.WriteLine("***" + ex.Message);
                this.label6.Text = "未知";
            }
            this.label6.Refresh();
        }
        public async void UpadteAllAtUsers(string pname)
        {
            string data = JObject.FromObject(new
            {
                projectName = pname
            }).ToString();
            try
            {
                string task = await CommonUtil.GetResponseAsync(CommonUtil.GetConfigValue("getRecordInfoByProject"), data);
                JObject jj = JObject.Parse(task);
                string v = jj["count"].ToObject<string>();
                this.label2.Text = v;
            }
            catch
            {
                this.label2.Text = "未知";
            }
            this.label2.Refresh();
        }
        /// <summary>
        /// 获取项目下所有工人信息
        /// </summary>
        /// <param name="pname"></param>
        private async void GetAllUsers(string pname)
        {
            string postURL = ConfigurationManager.AppSettings["postlistURL"].ToString();
            string data = JObject.FromObject(new
            {
                userInfo = new
                {
                    projectName = pname
                }
            }).ToString();
            try
            {
                string task = await CommonUtil.GetResponseAsync(postURL, data);

                JObject jj = JObject.Parse(task);

                IList<JToken> results = jj["items"].Children().ToList();
                IList<UserInfo> searchResults = new List<UserInfo>();
                foreach (JToken result in results)
                {
                    UserInfo searchResult = result.ToObject<UserInfo>();
                    searchResults.Add(searchResult);
                }
                foreach (UserInfo u in searchResults)
                {
                    CommonUtil.DebugConsole("用户为：" + u.userName);
                    DataTable dt = SQLiteDBHelper.ExecuteDataTable(string.Format("select * from worker where identityId = '{0}' and groupname = '{1}';", u.userId, pname));
                    DataRow row = null;
                    if (dt.Rows.Count > 0)
                        row = dt.Rows[0];
                    if (null == row)
                    {
                        string insertsql = string.Format("insert into worker(identityId,username,contact,job,groupname,addtime,checkinState,checkinTime,identityPhoto)values('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}');",
                            u.userId,
                            u.userName,
                            u.mobile,
                            u.workKindName,
                            u.projectName,
                            u.createTime,
                            0,
                            "1990-12-12",
                            u.photo
                            );
                        if (SQLiteDBHelper.ExecuteNonQuery(insertsql) > 0)
                        {
                            CommonUtil.DebugConsole("新增用户成功");
                        }
                    }
                }
                CommonUtil.DebugConsole("用户总数为：" + searchResults.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("***" + ex.Message);
            }

        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
            timer2_Tick(null, null);
        }

        /***
         * 
         * 开启串口通信
         * 
         */
        private void startSerialPort()
        {
            try
            {
                string sql = "select port,baud_rate,odd_even_valid from setting_info";
                DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
                if (table.Rows.Count < 0)
                {
                    MessageBox.Show("请先设置串口参数", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                DataRow row = table.Rows[0];
                this.serialPort.PortName = row["port"].ToString();
                this.serialPort.BaudRate = Convert.ToInt32(row["baud_rate"].ToString());
                this.serialPort.Parity = Parity.None;
                this.serialPort.StopBits = StopBits.One;
                this.serialPort.DataReceived += new SerialDataReceivedEventHandler(Sp_DataReceived);
                interfaceUpdataHandle = new HandleInterfaceUpdataDelegate(UpdateSerialPortData);//实例化委托对象
                this.serialPort.ReceivedBytesThreshold = 1;
                try
                {
                    if (!this.serialPort.IsOpen)
                    {
                        this.serialPort.Open();
                        MessageBox.Show("端口" + serialPort + "打开成功！");
                        btnSwitchPort.Text = "关闭串口";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("端口" + serialPort + "打开失败！");
                }
            }
            catch
            {
                return;
            }
        }

        /**
         * 开启多串口的通信串口
         */
        private void startSerialPort2()
        {
            try
            {
                if (serialPortsList.Count > 0)
                {
                    serialPortsList.Clear();
                }
                string sql = "select port,baud_rate,odd_even_valid,tag from setting_info";
                DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
                int count = table.Rows.Count;
                if (count <= 0)
                {
                    MessageBox.Show("请先设置串口参数", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < count; i++)
                {
                    DataRow row = table.Rows[i];
                    SerialPort port = new SerialPort();
                    SerialDataReceiveHandler handler = new SerialDataReceiveHandler(port, this, Convert.ToInt32(row["tag"].ToString()), this.lstBoxWorker, images, this.inuser,
                    this.outuser,
                    this.nowinname,
                    this.nowoutname,
                    this.nowindate,
                    this.nowoutdate,
                    this.nowingroup,
                    this.nowoutgroup,
                    this.nowintime,
                    this.nowouttime,
                    this.nowinjob,
                    this.nowoutjob);

                    port.PortName = row["port"].ToString();
                    port.BaudRate = Convert.ToInt32(row["baud_rate"].ToString());
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.DataReceived += new SerialDataReceivedEventHandler(handler.Sp_DataReceived);
                    port.ReceivedBytesThreshold = 1;
                    serialPortsList.Add(port);
                    try
                    {
                        if (!port.IsOpen)
                        {
                            port.Open();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("端口" + port + "打开失败！" + ex.Message);
                        CloseAllPorts();
                        return;
                    }
                }
                MessageBox.Show("端口打开成功");
                btnSwitchPort.Text = "关闭串口";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CloseAllPorts()
        {
            foreach (SerialPort port in serialPortsList)
            {
                try
                {
                    if (port.IsOpen)
                    {
                        port.DiscardInBuffer();
                        port.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /**
         * 串口接收数据处理事件
         * 
         */
        public void Sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                int i = this.serialPort.BytesToRead;
                if (i > 0)
                {
                    try
                    {
                        string message = this.serialPort.ReadExisting();
                        this.Invoke(interfaceUpdataHandle, message);

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /***
         * 
         * dataReceive处理后的下一步委托事件处理方法
         */
        public void UpdateSerialPortData(String message)
        {
            if (message.IndexOf("\r\n") != -1)
            {
                message = message.Replace("\r\n", "");
            }
            if (message.Substring(0, 3).IndexOf("00") != -1)
            {
                int len = message.Length;
                message = message.Substring(2, len - 2);
            }
            MessageBox.Show(message);
        }

        /***
         * 
         * "设置"按钮点击事件
         */
        private void btnSetting_Click(object sender, EventArgs e)
        {
            /*    SettingForm settingForm=new SettingForm();
                settingForm.ShowDialog();*/
            MultiSettingForm settingForm = new MultiSettingForm();
            settingForm.ShowDialog();
        }

        /***
         * 窗体关闭时候事件处理
         */
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAllPorts();
            Application.Exit();
        }

        /***
         * 开启/关闭串口事件
         */
        private void SwitchPortClick(object sender, EventArgs e)
        {
            try
            {
                foreach (SerialPort port in serialPortsList)
                {
                    if (port.IsOpen)
                    {
                        CloseAllPorts();
                        btnSwitchPort.Text = "开启串口";
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("端口关闭异常");
                return;
            }
            startSerialPort2();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.labelTime.Text = DateTime.Now.ToString("yyyy年 MM月dd日 dddd");
        }
        //工人考勤轮播绘图事件
        private void lstBoxWorker_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush myBrush = new SolidBrush(Color.FromArgb(32, 32, 48));
            e.Graphics.FillRectangle(myBrush, e.Bounds);
            e.DrawFocusRectangle();//焦点框 

            if (images == null || images.Count == 0)
                return;
            Image image = images[e.Index];
            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;
            Rectangle imageRect = new Rectangle(
                bounds.X,
                bounds.Y + 5,
                bounds.Height / 16 * 14,
                bounds.Height);
            Rectangle textRect = new Rectangle(
                imageRect.Right + 15,
                bounds.Y + 5,
                bounds.Width - imageRect.Right,
                bounds.Height);

            if (image != null)
            {
                g.DrawImage(
                    image,
                    imageRect,
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel);
            }

            //文本 
            StringFormat strFormat = new StringFormat();

            strFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(lstBoxWorker.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), textRect, strFormat);
            this.lstBoxWorker.ScrollAlwaysVisible = false;

        }


        /********   视频监控部分    **************************************************/
        /// <summary>
        /// 初始化视频
        /// </summary>
        private void InitCamera()
        {
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("初始化监控失败！");
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);

                for (int i = 0; i < 64; i++)
                {
                    iIPDevID[i] = -1;
                    iChannelNum[i] = -1;
                }
            }
        }


        //开启视频监控
        private void OpenCameraWatch()
        {
            string CameraSupply = ConfigurationManager.AppSettings["CameraSupply"].ToString();
            //判断视频厂商，暂时先用海康的接口，如果不是海康则不启用视频
            if (CameraSupply != "海康")
            {
                return;
            }
            InitCamera();
            string ipAddress = CommonUtil.GetConfigValue("CameraIp");
            string cameraPort = CommonUtil.GetConfigValue("CameraPort");
            string cameraUser = CommonUtil.GetConfigValue("CameraUser");
            string cameraPwd = CommonUtil.GetConfigValue("CameraPwd");
            //登录设备 Login the device
            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(ipAddress, Int16.Parse(cameraPort), cameraUser, cameraPwd, ref DeviceInfo);
            if (m_lUserID < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                MessageBox.Show("监控连接出错" + iLastErr);
                return;
            }
            else
            {
                dwAChanTotalNum = (uint)DeviceInfo.byChanNum;
                dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;
                if (dwDChanTotalNum > 0)
                {
                    InfoIPChannel();
                    PreviewAction();
                }
                else
                {
                    for (i = 0; i < dwAChanTotalNum; i++)
                    {
                        ListAnalogChannel(i + 1, 1);
                        iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                    }
                }
            }
        }

        public void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0;  //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取

            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr;
                //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
                MessageBox.Show(str);
            }
            else
            {
                //MessageBox.Show("视频开启成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine("视频开启成功!");
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));

                for (i = 0; i < dwAChanTotalNum; i++)
                {
                    ListAnalogChannel(i + 1, m_struIpParaCfgV40.byAnalogChanEnable[i]);
                    iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                }

                byte byStreamType = 0;
                uint iDChanNum = 64;

                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //如果设备IP通道小于64路，按实际路数获取
                }

                for (i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;
                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;

                    dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40.struStreamMode[i].uGetStream);
                    switch (byStreamType)
                    {
                        //目前NVR仅支持直接从设备取流 NVR supports only the mode: get stream from device directly
                        case 0:
                            IntPtr ptrChanInfo = Marshal.AllocHGlobal((Int32)dwSize);
                            Marshal.StructureToPtr(m_struIpParaCfgV40.struStreamMode[i].uGetStream, ptrChanInfo, false);
                            m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(ptrChanInfo, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));

                            //列出IP通道 List the IP channel
                            //ListIPChannel(i + 1, m_struChanInfo.byEnable, m_struChanInfo.byIPID);
                            iIPDevID[i] = m_struChanInfo.byIPID + m_struChanInfo.byIPIDHigh * 256 - iGroupNo * 64 - 1;

                            Marshal.FreeHGlobal(ptrChanInfo);
                            break;
                        case 6:
                            IntPtr ptrChanInfoV40 = Marshal.AllocHGlobal((Int32)dwSize);
                            Marshal.StructureToPtr(m_struIpParaCfgV40.struStreamMode[i].uGetStream, ptrChanInfoV40, false);
                            m_struChanInfoV40 = (CHCNetSDK.NET_DVR_IPCHANINFO_V40)Marshal.PtrToStructure(ptrChanInfoV40, typeof(CHCNetSDK.NET_DVR_IPCHANINFO_V40));

                            //列出IP通道 List the IP channel
                            // ListIPChannel(i + 1, m_struChanInfoV40.byEnable, m_struChanInfoV40.wIPID);
                            iIPDevID[i] = m_struChanInfoV40.wIPID - iGroupNo * 64 - 1;

                            Marshal.FreeHGlobal(ptrChanInfoV40);
                            break;
                        default:
                            break;
                    }
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);

        }

        public void ListAnalogChannel(Int32 iChanNo, byte byEnable)
        {
            str1 = String.Format("Camera {0}", iChanNo);
            m_lTree++;

            if (byEnable == 0)
            {
                str2 = "Disabled"; //通道已被禁用 This channel has been disabled               
            }
            else
            {
                str2 = "Enabled"; //通道处于启用状态 This channel has been enabled
            }
        }

        public void PreviewAction()
        {
            Preview(this.pictureBox1, 0);
        }

        private void Preview(PictureBox RealPlayWnd, int selectIndex)
        {
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;//预览窗口 live view window
            lpPreviewInfo.lChannel = iChannelNum[selectIndex];//预览的设备通道 the device channel number
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 15; //播放库显示缓冲区最大帧数
            IntPtr pUser = IntPtr.Zero;//用户数据 user data 
                                       //打开预览 Start live view 
            m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
            RealPlayWnd.Invalidate();
        }

        /// <summary>
        /// 定时更新在场人数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CommonUtil.GetConfigValue("mode") == "local")
            {
                this.label4.Text = workerService.UpdateWorkerNumber(pname, 1);
                this.label4.Refresh();
            }
        }
        /// <summary>
        /// 定时线上查询更新各工种考勤人数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {

            if (CommonUtil.GetConfigValue("mode") == "local")
                UpdateWorkerJobCount();
            else
                UpdateWorkerJobCountOnlineAsync();

        }
        /// <summary>
        /// 定时更新考勤人数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer4_Tick(object sender, EventArgs e)
        {
            UpadteAllAtUsers(ConfigurationManager.AppSettings["prorealname"].ToString());
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (ControlsInfo.Count > 0)//如果字典中有数据，即窗体改变
            {
                ControlsChaneInit(this.Controls[0]);//表示pannel控件
                ControlsChange(this.Controls[0]);
            }
        }
        /// <summary>
        /// 单击标题获取项目下所有人员信息至数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labproname_Click(object sender, EventArgs e)
        {
            GetAllUsers(ConfigurationManager.AppSettings["prorealname"].ToString());
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SerialPort port in serialPortsList)
                {
                    if (port.IsOpen)
                    {
                        CloseAllPorts();
                        btnSwitchPort.Text = "开启串口";
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("端口关闭异常");
                return;
            }
            startSerialPort2();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            /*    SettingForm settingForm=new SettingForm();
                settingForm.ShowDialog();*/
            MultiSettingForm settingForm = new MultiSettingForm();
            settingForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            LedInfo info = new LedInfo();
            string sql = "select * from led_info";
            DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                row = table.Rows[0];
                info.Id = Int32.Parse(row["id"].ToString());
                info.ProjectName = row["project_name"].ToString();
                info.LedIp = row["led_ip"].ToString();
                info.Width = Int32.Parse(row["width"].ToString());
                info.Height = Int32.Parse(row["height"].ToString());
                LedModify ledModify = new LedModify(info);
                //   LedModify ledModify = new LedModify(info);
                ledModify.ShowDialog();
            }
            else
            {
                LedModify ledModify = new LedModify();
                //   LedModify ledModify = new LedModify(info);
                ledModify.ShowDialog();
            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 12 && DateTime.Now.Minute == 1)
                GetcountFromURL(ConfigurationManager.AppSettings["prorealname"].ToString());
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 23 && DateTime.Now.Minute == 59)
                this.lstBoxWorker.Items.Clear();
        }

        private void labelTime_Click(object sender, EventArgs e)
        {
            LedInfo li = workerService.GetLEDInfo();
            if (null == li.LedIp)
            {
                MessageBox.Show("屏幕参数未设置", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int nResult;
            LedDll.COMMUNICATIONINFO CommunicationInfo = new LedDll.COMMUNICATIONINFO();//定义一通讯参数结构体变量用于对设定的LED通讯，具体对此结构体元素赋值说明见COMMUNICATIONINFO结构体定义部份注示
            //ZeroMemory(&CommunicationInfo,sizeof(COMMUNICATIONINFO));
            //TCP通讯********************************************************************************
            CommunicationInfo.SendType = 0;//设为固定IP通讯模式，即TCP通讯
            CommunicationInfo.IpStr = li.LedIp;//给IpStr赋值LED控制卡的IP
            CommunicationInfo.LedNumber = 1;//LED屏号为1，注意socket通讯和232通讯不识别屏号，默认赋1就行了，485必需根据屏的实际屏号进行赋值

            nResult = LedDll.LV_SetBasicInfo(ref CommunicationInfo, 2, li.Width, li.Height);//设置屏参，屏的颜色为2即为双基色，64为屏宽点数，32为屏高点数，具体函数参数说明见函数声明注示
            if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
            {
                string ErrStr;
                ErrStr = LedDll.LS_GetError(nResult);
                MessageBox.Show(ErrStr, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int hProgram;//节目句柄
            nResult = LedDll.LV_TestOnline(ref CommunicationInfo);
            if (nResult != 0)
            {
                MessageBox.Show(LedDll.LS_GetError(nResult), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nResult = LedDll.LV_AdjustTime(ref CommunicationInfo);
            if (nResult != 0)
                MessageBox.Show(LedDll.LS_GetError(nResult), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);//只报错，不退出
            hProgram = LedDll.LV_CreateProgram(li.Width, li.Height, 2);//根据传的参数创建节目句柄，64是屏宽点数，32是屏高点数，2是屏的颜色，注意此处屏宽高及颜色参数必需与设置屏参的屏宽高及颜色一致，否则发送时会提示错误
            if (hProgram == 0)
            {
                MessageBox.Show("创建节目对象失败", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nResult = LedDll.LV_AddProgram(hProgram, 1, 0, 0);//添加一个节目，参数说明见函数声明注示
            if (nResult != 0)
            {
                MessageBox.Show(LedDll.LS_GetError(nResult), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<ModuleInfo> lla = workerService.GetLEDArea(li.Id);
            foreach (ModuleInfo la in lla)
            {
                LedDll.AREARECT AreaRect = new LedDll.AREARECT();//区域坐标属性结构体变量
                AreaRect.left = la.Left_begin;
                AreaRect.top = la.Top_begin;
                AreaRect.width = la.Width;
                AreaRect.height = la.Height;

                LedDll.LV_AddImageTextArea(hProgram, 1, la.Id, ref AreaRect, 1);

                LedDll.FONTPROP FontProp = new LedDll.FONTPROP();//文字属性
                FontProp.FontName = "宋体";
                FontProp.FontSize = la.Font_size;
                FontProp.FontColor = LedDll.COLOR_RED;
                FontProp.FontBold = la.Font_bold;

                LedDll.PLAYPROP PlayProp = new LedDll.PLAYPROP();
                PlayProp.InStyle = la.In_style;
                PlayProp.DelayTime = la.Delay_time;
                PlayProp.Speed = la.Speed;
                //可以添加多个子项到图文区，如下添加可以选一个或多个添加（注意点：调用添加子项到图文区域这些方法前都必须要先调用LV_AddImageTextArea）
                if (la.Area_type == 1 || la.Area_type == 5 || la.Area_type == 6)
                {
                    nResult = LedDll.LV_AddMultiLineTextToImageTextArea(hProgram, 1, la.Id, LedDll.ADDTYPE_STRING, "这是一个测试文本", ref FontProp, ref PlayProp, la.Multi_nAlignment, la.Multi_IsVCenter);
                    if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                    {
                        MessageBox.Show(LedDll.LS_GetError(nResult), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (la.Area_type == 2)
                {
                    nResult = LedDll.LV_AddSingleLineTextToImageTextArea(hProgram, 1, la.Id, LedDll.ADDTYPE_STRING, "这是另一个测试文本", ref FontProp, ref PlayProp);
                    if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                    {
                        MessageBox.Show(LedDll.LS_GetError(nResult), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #region 数字时钟
                if (la.Area_type == 3)
                {
                    int aid = la.Id;
                    LedDll.TIMEAREAINFO DigitalClockAreaInfo = new LedDll.TIMEAREAINFO();
                    DigitalClockAreaInfo.ShowFormat = 0;
                    DigitalClockAreaInfo.IsShowHour = 1;
                    DigitalClockAreaInfo.IsShowMinute = 1;
                    nResult = LedDll.LV_AddTimeArea(hProgram, 1, la.Id, ref AreaRect, ref DigitalClockAreaInfo);//注意区域号不能一样，详见函数声明注示
                    if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                    {
                        MessageBox.Show(LedDll.LS_GetError(nResult), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (la.Area_type == 4)
                {
                    int aid = la.Id;
                    LedDll.CLOCKAREAINFO DigitalClockAreaInfo = new LedDll.CLOCKAREAINFO();
                    DigitalClockAreaInfo.ClockType = 0;
                    DigitalClockAreaInfo.DateFormat = 1;
                    DigitalClockAreaInfo.HourMarkColor = 1;
                    DigitalClockAreaInfo.HourMarkType = 0;
                    DigitalClockAreaInfo.HourMarkWidth = 2;
                    DigitalClockAreaInfo.MiniteMarkColor = LedDll.COLOR_RED;
                    DigitalClockAreaInfo.MiniteMarkType = 0;
                    DigitalClockAreaInfo.MiniteMarkWidth = 1;
                    DigitalClockAreaInfo.HourMarkColor = LedDll.COLOR_RED;
                    DigitalClockAreaInfo.MinutePointerColor = LedDll.COLOR_RED;
                    DigitalClockAreaInfo.SecondPointerColor = LedDll.COLOR_RED;
                    DigitalClockAreaInfo.MinutePointerWidth = 2;
                    DigitalClockAreaInfo.HourPointerWidth = 3;
                    DigitalClockAreaInfo.SecondPointerWidth = 1;
                    nResult = LedDll.LV_AddClockArea(hProgram, 1, la.Id, ref AreaRect, ref DigitalClockAreaInfo);//注意区域号不能一样，详见函数声明注示
                    if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                    {
                        MessageBox.Show(LedDll.LS_GetError(nResult), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion
            }
            nResult = LedDll.LV_Send(ref CommunicationInfo, hProgram);//发送，见函数声明注示
            LedDll.LV_DeleteProgram(hProgram);//删除节目内存对象，详见函数声明注示
            if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                MessageBox.Show(LedDll.LS_GetError(nResult), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("LED发送成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void label4_ClickAsync(object sender, EventArgs e)
        {
            workerService.Ledcontrol(workerService.GetLEDInfo(), "", 3);
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (CommonUtil.GetConfigValue("mode") != "local")
                workerService.Ledcontrol(workerService.GetLEDInfo(), "", 3);
        }

        private void GetWeatherAsync()
        {
            string strURL = "https://restapi.amap.com/v3/weather/weatherInfo?key=0a73c5c6be50f0a6dcebcaf3f7eaa2e0&extensions=all&city=" + CommonUtil.GetConfigValue("city");
            try
            {
                System.Net.HttpWebRequest request;
                // 创建一个HTTP请求
                request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);

                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string responseText = myreader.ReadToEnd();
                Console.WriteLine("返回：" + responseText);
                JObject googleSearch = JObject.Parse(responseText);

                // get JSON result objects into a list
                IList<JToken> results = googleSearch["forecasts"][0]["casts"].Children().ToList();

                // serialize JSON results into .NET objects
                IList<Weather> searchResults = new List<Weather>();
                foreach (JToken result in results)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    Weather searchResult = result.ToObject<Weather>();
                    searchResults.Add(searchResult);
                }

                this.wpicture.BackgroundImage = Image.FromFile(Application.StartupPath + @"\Resources\3d_60\" + searchResults[0].dayweather + ".png");
                this.ttemp.Text = string.Format("{0}℃ ~ {1}℃", searchResults[0].daytemp, searchResults[0].nighttemp);
                if (!searchResults[0].dayweather.Equals(searchResults[0].nightweather))//避免多云转多云这种尴尬的情况
                    this.tw.Text = string.Format("{0}转{1}", searchResults[0].dayweather, searchResults[0].nightweather);
                else
                    this.tw.Text = string.Format("{0}", searchResults[0].dayweather);
                this.twind.Text = string.Format("{0}风 {1}级", searchResults[0].daywind, searchResults[0].daypower);
                this.nweather.Text = string.Format("{0}℃ ~ {1}℃ {2}", searchResults[1].daytemp, searchResults[1].nighttemp, searchResults[0].dayweather);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 10 && DateTime.Now.Minute == 30)
            {
                Console.WriteLine("天气更新");
                this.GetWeatherAsync();
            }
        }
        //DrawBorder(Graphics graphics, Rectangle bounds, Color color, ButtonBorderStyle style);
        private void tlp_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                 e.Graphics,
                 tlp.ClientRectangle,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid
                 );
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                 e.Graphics,
                 panel9.ClientRectangle,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid
                 );
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                 e.Graphics,
                 tableLayoutPanel1.ClientRectangle,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid
                 );
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
               e.Graphics,
                panel8.ClientRectangle,
                Color.Gray,
                0,
                ButtonBorderStyle.Solid,
                Color.Gray,
                0,
                ButtonBorderStyle.Solid,
                Color.Gray,
                1,
                ButtonBorderStyle.Solid,
                Color.Gray,
                0,
                ButtonBorderStyle.Solid
                );
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                e.Graphics,
                panel8.ClientRectangle,
                Color.Gray,
                0,
                ButtonBorderStyle.Solid,
                Color.Gray,
                0,
                ButtonBorderStyle.Solid,
                Color.Gray,
                1,
                ButtonBorderStyle.Solid,
                Color.Gray,
                0,
                ButtonBorderStyle.Solid
                );
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                 e.Graphics,
                 panel4.ClientRectangle,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid,
                 BorderColor,
                 3,
                 ButtonBorderStyle.Solid
                 );
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            this.timenow.Text = DateTime.Now.ToString("T");
        }
    }

}
