using DAO;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Linq;
using System.Data.SQLite;
namespace Service
{
    public class WorkerService
    {
        public string cc { get; set; }
        public string pp { get; set; }
        public string ss { get; set; }
        public string mm { get; set; }
        public string ccount { get; set; }
        
        public string DeleteSelectedColumn(List<string> arr)
        {
            string resultStr = "";
            string str = "(";
            if (arr.Count > 0)
            {
                for (var a = 0; a < arr.Count; a++)
                {
                    str += "'" + arr[a] + "',";
                }
            }
            str = str.Substring(0, str.Length - 1) + ")";
            string sqlString = "delete from led_info where id in" + str;
            try
            {
                SQLiteDBHelper.ExecuteNonQuery(sqlString,null);
                resultStr = "删除成功！";
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("" + e.Message);
                resultStr = "删除失败，请联系管理员!";
            }
            return resultStr;
        }
        /// <summary>
        /// 获取LED屏幕设置信息列表
        /// </summary>
        /// <param name="led_id"></param>
        /// <returns></returns>
        public List<ModuleInfo> GetLEDArea(int led_id)
        {
            List<ModuleInfo> lla = new List<ModuleInfo>();

            string sql = string.Format("select * from led_area where led_id = 1", led_id);
            DataTable dtt = SQLiteDBHelper.ExecuteDataTable("select * from led_area where led_id = 1");
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                ModuleInfo la = new ModuleInfo();
                la.Id = Int32.Parse(dtt.Rows[i]["id"].ToString());
                la.Led_id = Int32.Parse(dtt.Rows[i]["led_id"].ToString());
                la.Left_begin = Int32.Parse(dtt.Rows[i]["left_begin"].ToString());
                la.Top_begin = Int32.Parse(dtt.Rows[i]["top_begin"].ToString());
                la.Width = Int32.Parse(dtt.Rows[i]["width"].ToString());
                la.Height = Int32.Parse(dtt.Rows[i]["height"].ToString());
                la.Area_type = Int32.Parse(dtt.Rows[i]["area_type"].ToString());
                la.Module_type = dtt.Rows[i]["module_type"].ToString();
                la.Multi_nAlignment = Int32.Parse(dtt.Rows[i]["multi_nAlignment"].ToString());
                la.Multi_IsVCenter = Int32.Parse(dtt.Rows[i]["multi_IsVCenter"].ToString());
                la.Font_size = Int32.Parse(dtt.Rows[i]["font_size"].ToString());
                la.Font_bold = Int32.Parse(dtt.Rows[i]["font_bold"].ToString());
                la.In_style = Int32.Parse(dtt.Rows[i]["in_style"].ToString());
                la.Delay_time = Int32.Parse(dtt.Rows[i]["delay_time"].ToString());
                la.Speed = Int32.Parse(dtt.Rows[i]["speed"].ToString());
                lla.Add(la);
            }
            return lla;
        }
        private string GetOutputString(string type, string identityId, int checktype)
        {
            string s = "";
            switch (type)
            {
                case "工种实时":
                    s = GetJobCountLEDInfo();
                    break;
                case "工人进出场":
                    s = GetUserInOutInfo(identityId, checktype);
                    break;

                case "项目人数":
                    s = GetProjectCountInfo();//原项目考勤
                    break;
                case "在场人数":
                    s = GetProjCount();
                    break;

                case "人数统计":
                    s = GetWorkerNumLEDInfo();
                    break;
                case "工种线上实时":
                    GetJobCountLEDInfoAsync();
                    s = this.pp;
                    break;
                case "项目线上考勤":
                    UpdateWorkerNumberOnlineAsync();
                    s = this.ss;
                    break;
                case "项目线上人数":
                    GetProjectCountInfoAsync();
                    s = this.mm;
                    break;
                case "工种实时考勤":
                    s = GetJobCount();
                    break;
                default:
                    s = GetTeml(type);
                    break;
            }
            return s;
        }
        /// <summary>
        /// 获取模板内容
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetTeml(string type)
        {
            string sql = "select module_text from led_module where module_type='"+type+"';";
            DataTable dt = SQLiteDBHelper.ExecuteDataTable(sql);
            DataRow row = null;
            string name = "";
            if (dt.Rows.Count > 0)
                row = dt.Rows[0];
            if (null != row)
                name = row["module_text"].ToString();

            return name;
        }
        /// <summary>
        /// 查询当前用户出入信息用于LED显示
        /// </summary>
        /// <param name="identityId"></param>
        /// <param name="checktype"></param>
        /// <returns></returns>
        public string GetUserInOutInfo(string identityId,int checktype)
        {
            string sql = "select * from worker where identityId = '" + identityId + "'";
            DataTable table = SQLiteDBHelper.ExecuteDataTable(sql);
            string userInfo = "";
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                userInfo = row["job"].ToString() + "  " + row["username"].ToString() + (checktype == 1 ? " 进场" : " 出场");
            }
            return userInfo;
        }
        /// <summary>
        /// LED控制主方法
        /// </summary>
        /// <param name="message"></param>
        /// <param name="strFormat"></param>
        public void Ledcontrol(LedInfo info, string identityId, int checktype)
        {
            try
            {
                if (info.LedIp == null)
                {
                    Console.WriteLine("LED参数未设置");
                    return;
                }
                int nResult;
                LedDll.COMMUNICATIONINFO CommunicationInfo = new LedDll.COMMUNICATIONINFO();//定义一通讯参数结构体变量用于对设定的LED通讯，具体对此结构体元素赋值说明见COMMUNICATIONINFO结构体定义部份注示
                CommunicationInfo.SendType = 0;//设为固定IP通讯模式，即TCP通讯
                CommunicationInfo.IpStr = info.LedIp;//给IpStr赋值LED控制卡的IP
                CommunicationInfo.LedNumber = 1;

                nResult = LedDll.LV_SetBasicInfo(ref CommunicationInfo, 2, info.Width, info.Height);
                if (nResult != 0)
                {
                    LEDErrorControl(nResult);
                    return;
                }
                int hProgram;//节目句柄
                
                //nResult = LedDll.LV_TestOnline(ref CommunicationInfo);
                //if (nResult != 0)
                //{
                    /*
                    for (int i = 0; i < 3; i++)
                    {
                        nResult = LedDll.LV_TestOnline(ref CommunicationInfo);
                        if (nResult == 0)
                        {
                            Console.WriteLine("NET连接成功");
                            break;
                        }
                    }
                    */
                    //Console.WriteLine("NET连接失败");
                    //return;
                //}
                
                hProgram = LedDll.LV_CreateProgram(info.Width, info.Height, 2);//根据传的参数创建节目句柄，64是屏宽点数，32是屏高点数，2是屏的颜色，注意此处屏宽高及颜色参数必需与设置屏参的屏宽高及颜色一致，否则发送时会提示错误
                if (hProgram == 0)
                {
                    Console.WriteLine("创建节目对象失败");
                    return;
                }
                nResult = LedDll.LV_AddProgram(hProgram, 1, 0, 0);//添加一个节目，参数说明见函数声明注示
                if (nResult != 0)
                {
                    LEDErrorControl(nResult);
                    return;
                }
                List<ModuleInfo> lla = GetLEDArea(info.Id);
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
                        nResult = LedDll.LV_AddMultiLineTextToImageTextArea(hProgram, 1, la.Id, LedDll.ADDTYPE_STRING, GetOutputString(la.Module_type,identityId,checktype), ref FontProp, ref PlayProp, la.Multi_nAlignment, la.Multi_IsVCenter);
                        if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                        {
                            LEDErrorControl(nResult);
                            return;
                        }
                    }
                    if (la.Area_type == 2)
                    {
                        nResult = LedDll.LV_AddSingleLineTextToImageTextArea(hProgram, 1, la.Id, LedDll.ADDTYPE_STRING, GetOutputString(la.Module_type, identityId, checktype), ref FontProp, ref PlayProp);
                        if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                        {
                            LEDErrorControl(nResult);
                            return;
                        }
                    }
                    #region 数字时钟
#warning 区域号问题
                    if (la.Area_type == 3)
                    {
                        LedDll.DIGITALCLOCKAREAINFO DigitalClockAreaInfo = new LedDll.DIGITALCLOCKAREAINFO();
                        int dateformat = Convert.ToInt32(ConfigurationManager.AppSettings["DateFormat"].ToString());
                        int timeformat = Convert.ToInt32(ConfigurationManager.AppSettings["TimeFormat"].ToString());
                        if (dateformat > 0 && dateformat < 8)
                        {
                            DigitalClockAreaInfo.DateFormat = dateformat;
                            DigitalClockAreaInfo.IsMutleLineShow = 1;
                            DigitalClockAreaInfo.IsShowYear = 1;
                            DigitalClockAreaInfo.IsShowMonth = 1;
                            DigitalClockAreaInfo.IsShowDay = 1;
                        }
                        if (timeformat > 0 && timeformat < 7)
                        {
                            DigitalClockAreaInfo.TimeFormat = timeformat;
                            DigitalClockAreaInfo.IsShowHour = 1;
                            DigitalClockAreaInfo.IsShowMinute = 1;
                            DigitalClockAreaInfo.IsShowSecond = 1;
                            DigitalClockAreaInfo.IsMutleLineShow = 1;
                        }
                        LedDll.LV_AdjustTime(ref CommunicationInfo);
                        nResult = LedDll.LV_AddDigitalClockArea(hProgram, 1, 6, ref AreaRect, ref DigitalClockAreaInfo);//注意区域号不能一样，详见函数声明注示
                        if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                        {
                            LEDErrorControl(nResult);
                            return;
                        }
                    }
                    if(la.Area_type == 4)
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
                        LedDll.LV_AdjustTime(ref CommunicationInfo);
                        nResult = LedDll.LV_AddClockArea(hProgram,1,6,ref AreaRect, ref DigitalClockAreaInfo);//注意区域号不能一样，详见函数声明注示
                        if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                        {
                            LEDErrorControl(nResult);
                            return;
                        }
                    }
                    #endregion
                }
                #warning 这种文本区域的方法与图像区域的方法是互斥的，即如果调用了LV_AddImageTextArea，则再调用此方法，屏幕没有内容显示
                #warning nResult = LedDll.LV_QuickAddSingleLineTextArea(hProgram, 1, 2, ref AreaRect, LedDll.ADDTYPE_STRING, "上海灵信视觉技术股份有限公司", ref FontProp, 4);//快速通过字符添加一个单行文本区域，函数见函数声明注示
                nResult = LedDll.LV_Send(ref CommunicationInfo, hProgram);//发送，见函数声明注示
                LedDll.LV_DeleteProgram(hProgram);//删除节目内存对象，详见函数声明注示
                if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                {
                    string ErrStr;
                    ErrStr = LedDll.LS_GetError(nResult);
                    Console.WriteLine(ErrStr);
                }
                else
                    Console.WriteLine("LED发送成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LedOnlinecontrol(LedInfo info, string identityId, int checktype)
        {
            try
            {
                if (info.LedIp == null)
                {
                    Console.WriteLine("LED参数未设置");
                    return;
                }
                int nResult;
                LedDll.COMMUNICATIONINFO CommunicationInfo = new LedDll.COMMUNICATIONINFO();//定义一通讯参数结构体变量用于对设定的LED通讯，具体对此结构体元素赋值说明见COMMUNICATIONINFO结构体定义部份注示
                CommunicationInfo.SendType = 0;//设为固定IP通讯模式，即TCP通讯
                CommunicationInfo.IpStr = info.LedIp;//给IpStr赋值LED控制卡的IP
                CommunicationInfo.LedNumber = 1;

                nResult = LedDll.LV_SetBasicInfo(ref CommunicationInfo, 2, info.Width, info.Height);
                if (nResult != 0)
                {
                    LEDErrorControl(nResult);
                    return;
                }
                int hProgram;//节目句柄
                nResult = LedDll.LV_TestOnline(ref CommunicationInfo);
                if (nResult != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        nResult = LedDll.LV_TestOnline(ref CommunicationInfo);
                        if (nResult == 0)
                        {
                            Console.WriteLine("NET连接成功");
                            break;
                        }
                    }
                    Console.WriteLine("NET3次连接失败");
                    return;
                }
                hProgram = LedDll.LV_CreateProgram(info.Width, info.Height, 2);//根据传的参数创建节目句柄，64是屏宽点数，32是屏高点数，2是屏的颜色，注意此处屏宽高及颜色参数必需与设置屏参的屏宽高及颜色一致，否则发送时会提示错误
                if (hProgram == 0)
                {
                    Console.WriteLine("创建节目对象失败");
                    return;
                }
                nResult = LedDll.LV_AddProgram(hProgram, 1, 0, 0);//添加一个节目，参数说明见函数声明注示
                if (nResult != 0)
                {
                    LEDErrorControl(nResult);
                    return;
                }
                List<ModuleInfo> lla = GetLEDArea(info.Id);
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
                        nResult = LedDll.LV_AddMultiLineTextToImageTextArea(hProgram, 1, la.Id, LedDll.ADDTYPE_STRING, GetOutputString(la.Module_type, identityId, checktype), ref FontProp, ref PlayProp, la.Multi_nAlignment, la.Multi_IsVCenter);
                        if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                        {
                            LEDErrorControl(nResult);
                            return;
                        }
                    }
                    if (la.Area_type == 2)
                    {
                        nResult = LedDll.LV_AddSingleLineTextToImageTextArea(hProgram, 1, la.Id, LedDll.ADDTYPE_STRING, GetOutputString(la.Module_type, identityId, checktype), ref FontProp, ref PlayProp);
                        if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                        {
                            LEDErrorControl(nResult);
                            return;
                        }
                    }
                    #region 数字时钟
                    #warning 区域号问题
                    if (la.Area_type == 3)
                    {
                        LedDll.DIGITALCLOCKAREAINFO DigitalClockAreaInfo = new LedDll.DIGITALCLOCKAREAINFO();
                        int dateformat = Convert.ToInt32(ConfigurationManager.AppSettings["DateFormat"].ToString());
                        int timeformat = Convert.ToInt32(ConfigurationManager.AppSettings["TimeFormat"].ToString());
                        if (dateformat > 0 && dateformat < 8)
                        {
                            DigitalClockAreaInfo.DateFormat = dateformat;
                            DigitalClockAreaInfo.IsMutleLineShow = 1;
                            DigitalClockAreaInfo.IsShowYear = 1;
                            DigitalClockAreaInfo.IsShowMonth = 1;
                            DigitalClockAreaInfo.IsShowDay = 1;
                        }
                        if (timeformat > 0 && timeformat < 7)
                        {
                            DigitalClockAreaInfo.TimeFormat = timeformat;
                            DigitalClockAreaInfo.IsShowHour = 1;
                            DigitalClockAreaInfo.IsShowMinute = 1;
                            DigitalClockAreaInfo.IsShowSecond = 1;
                            DigitalClockAreaInfo.IsMutleLineShow = 1;
                        }
                        //LedDll.LV_AdjustTime(ref CommunicationInfo);
                        nResult = LedDll.LV_AddDigitalClockArea(hProgram, 1, 6, ref AreaRect, ref DigitalClockAreaInfo);
                        if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                        {
                            LEDErrorControl(nResult);
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
                        LedDll.LV_AdjustTime(ref CommunicationInfo);
                        nResult = LedDll.LV_AddClockArea(hProgram, 1, 3, ref AreaRect, ref DigitalClockAreaInfo);//注意区域号不能一样，详见函数声明注示
                        if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                        {
                            LEDErrorControl(nResult);
                            return;
                        }
                    }
                    #endregion
                }
                #warning 这种文本区域的方法与图像区域的方法是互斥的，即如果调用了LV_AddImageTextArea，则再调用此方法，屏幕没有内容显示
                #warning nResult = LedDll.LV_QuickAddSingleLineTextArea(hProgram, 1, 2, ref AreaRect, LedDll.ADDTYPE_STRING, "上海灵信视觉技术股份有限公司", ref FontProp, 4);//快速通过字符添加一个单行文本区域，函数见函数声明注示
                nResult = LedDll.LV_Send(ref CommunicationInfo, hProgram);//发送，见函数声明注示
                LedDll.LV_DeleteProgram(hProgram);//删除节目内存对象，详见函数声明注示
                if (nResult != 0)//如果失败则可以调用LV_GetError获取中文错误信息
                {
                    string ErrStr;
                    ErrStr = LedDll.LS_GetError(nResult);
                    Console.WriteLine(ErrStr);
                }
                else
                    Console.WriteLine("LED发送成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void LEDErrorControl(int nResult)
        {
            string ErrStr;
            ErrStr = LedDll.LS_GetError(nResult);
            Console.WriteLine(ErrStr);
        }
        public LedInfo GetLEDInfo()
        {
            LedInfo info = new LedInfo();
            string sql = "select * from led_info";
            DataTable dtt = SQLiteDBHelper.ExecuteDataTable(sql);
            if (dtt.Rows.Count > 0)
            {
                info.LedIp = dtt.Rows[0]["led_ip"].ToString();
                info.Width = Int32.Parse(dtt.Rows[0]["width"].ToString());
                info.Height = Int32.Parse(dtt.Rows[0]["height"].ToString());
                info.ProjectName = dtt.Rows[0]["project_name"].ToString();
            }
            return info;
        }
        /// <summary>
        /// 根据项目名及考勤状态查询人数
        /// </summary>
        /// <param name="groupanme"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string UpdateWorkerNumber(string groupanme, int state)
        {
            string sql = string.Format("select count(job) as num from worker where groupname = '{0}' and checkinState = {1} and DATE(checkinTime) = '{2}';",
                groupanme,
                state,
                DateTime.Now.ToString("yyyy-MM-dd"));
            if (state > 1)//统计参与考勤人数
                sql = string.Format("select count(job) as num from worker where groupname = '{0}' and DATE(checkinTime) = '{1}';",
                groupanme,
                DateTime.Now.ToString("yyyy-MM-dd"));
            //Console.WriteLine("+++++" + sql);
            DataTable dt = SQLiteDBHelper.ExecuteDataTable(sql);
            DataRow row = null;
            string num = "未知";
            if (dt != null && dt.Rows != null)
                row = dt.Rows[0];
            if (null != row)
                num = row["num"].ToString();
            return num;
        }
       
        /// <summary>
        /// 异步线上获取考勤人数
        /// </summary>
        public async void UpdateWorkerNumberOnlineAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                    paramList.Add(new KeyValuePair<string, string>("userName", ConfigurationManager.AppSettings["user"].ToString()));
                    paramList.Add(new KeyValuePair<string, string>("password", ConfigurationManager.AppSettings["pwd"].ToString()));
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.PostAsync(new Uri(ConfigurationManager.AppSettings["loginURL"].ToString()), new FormUrlEncodedContent(paramList));
                    string res = response.Content.ReadAsStringAsync().Result;
                   
                    Token t = JsonConvert.DeserializeObject<Token>(res);
                    string postURL = ConfigurationManager.AppSettings["getRecordInfoByProject"].ToString();
                    string data = JObject.FromObject(new
                    {
                        projectName = ConfigurationManager.AppSettings["prorealname"].ToString()
                    }).ToString();
                    HttpContent hc = new StringContent(data);
                    
                    hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    hc.Headers.Add("token", t.token);
                   
                    HttpResponseMessage content = client.PostAsync(postURL, hc).Result;
                    string task = await content.Content.ReadAsStringAsync();
                    Console.WriteLine("项目考勤人数" + task);
                    try
                    {
                        JObject jj = JObject.Parse(task);
                        ccount = jj["count"].ToObject<string>();
                        ss = "考勤人数：" + ccount ?? "0";
                    }
                    catch (Exception ex) {
                        ss = "考勤人数：0";
                        Console.WriteLine("数据解析错误" + ex.Message);
                    }

                }
            }
            catch
            {
                this.cc = "未知";
                return;
            }
        }
        public string GetJobCountLEDInfo()
        {
            string sql = "select distinct job from worker";
            DataTable dt = SQLiteDBHelper.ExecuteDataTable(sql);
            if (dt.Rows.Count <= 0)
                return "暂无工种进场";
            string output = "在场人数：0";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string countsql = string.Format("select count(id) as count from worker where groupname = '{0}' and job = '{1}' and checkinState = 1 and DATE(checkinTime) = '{2}';",
                    System.Configuration.ConfigurationManager.AppSettings["prorealname"].ToString(),
                    dt.Rows[i]["job"].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd")
                    );
                DataTable dtt = SQLiteDBHelper.ExecuteDataTable(countsql);

                if (dtt.Rows.Count > 0)
                {
                    int cc = Int32.Parse(dtt.Rows[0]["count"].ToString());
                    if(cc > 0)
                        output += string.Format("{0} 在场人数：{1} ", dt.Rows[i]["job"].ToString(), cc);
                }
            }
            return output;
        }
        public string GetJobCount()
        {
            string sql = "select distinct job from worker";
            DataTable dt = SQLiteDBHelper.ExecuteDataTable(sql);
            if (dt.Rows.Count <= 0)
                return "暂无工种考勤";
            string output = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string countsql = string.Format("select count(id) as count from worker where groupname = '{0}' and job = '{1}' and DATE(checkinTime) = '{2}';",
                    System.Configuration.ConfigurationManager.AppSettings["prorealname"].ToString(),
                    dt.Rows[i]["job"].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd")
                    );
                DataTable dtt = SQLiteDBHelper.ExecuteDataTable(countsql);

                if (dtt.Rows.Count > 0)
                {
                    int cc = Int32.Parse(dtt.Rows[0]["count"].ToString());
                    if (cc > 0)
                        output += string.Format("{0} 考勤人数：{1} ", dt.Rows[i]["job"].ToString(), cc);
                }
            }
            return output;
        }
        public async void GetJobCountLEDInfoAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                    paramList.Add(new KeyValuePair<string, string>("userName", "Ledjk"));
                    paramList.Add(new KeyValuePair<string, string>("password", ConfigurationManager.AppSettings["pwd"].ToString()));
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.PostAsync(new Uri(ConfigurationManager.AppSettings["loginURL"].ToString()), new FormUrlEncodedContent(paramList));
                    string res = response.Content.ReadAsStringAsync().Result;
                   
                    Token t = JsonConvert.DeserializeObject<Token>(res);
                    string postURL = ConfigurationManager.AppSettings["getRecordInfoByWork"].ToString();
                    string data = JObject.FromObject(new
                    {
                        projectName = ConfigurationManager.AppSettings["prorealname"].ToString()
                    }).ToString();
                    HttpContent hc = new StringContent(data);
                    
                    hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    hc.Headers.Add("token", t.token);
                    
                    HttpResponseMessage content = client.PostAsync(postURL, hc).Result;
                    string task = await content.Content.ReadAsStringAsync();
                    
                    JObject jj = JObject.Parse(task);
                    IList<JToken> results = jj["record"].Children().ToList();

                    IList<Record> searchResults = new List<Record>();
                    foreach (JToken result in results)
                    {
                        Record searchResult = result.ToObject<Record>();
                        searchResults.Add(searchResult);
                    }
                    foreach (Record r in searchResults)
                    {                      
                        string output = "";           
                        output = "考勤人数：" + r.count.ToString();
                        this.pp += r.workKindName + output + ",";                      
                    }

                }
            }
            catch
            {
                this.pp = "考勤人数：0";
                return;
            }
        }
       
        public string GetProjectCountInfo()
        {
            string output = "";
            string countsql = string.Format("select count(id) as count from worker where groupname = '{0}';",
                    System.Configuration.ConfigurationManager.AppSettings["prorealname"].ToString()
                    );
            DataTable dtt = SQLiteDBHelper.ExecuteDataTable(countsql);

            if (dtt.Rows.Count > 0)
            {
                int cc = Int32.Parse(dtt.Rows[0]["count"].ToString());
                if (cc > 0)
                    output += string.Format("项目人数：{0} ", cc);
            }

            return output;
        }

        public string GetProjCount()
        {
            string output = string.Empty;
            string countsql2 = string.Format("select count(id) as count from worker where groupname = '{0}' and checkinState = 1 and DATE(checkinTime) = '{1}';",
                    System.Configuration.ConfigurationManager.AppSettings["prorealname"].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd")
                    );
            DataTable dtt2 = SQLiteDBHelper.ExecuteDataTable(countsql2);

            if (dtt2.Rows.Count > 0)
            {
                int cc = Int32.Parse(dtt2.Rows[0]["count"].ToString());
                if (cc > 0)
                    output += string.Format("在场人数：{0} ", cc);
            }
            return output;
        }
        /// <summary>
        /// 项目人数线上统计
        /// </summary>
        public async void GetProjectCountInfoAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                    paramList.Add(new KeyValuePair<string, string>("userName", ConfigurationManager.AppSettings["user"].ToString()));
                    paramList.Add(new KeyValuePair<string, string>("password", ConfigurationManager.AppSettings["pwd"].ToString()));
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.PostAsync(new Uri(ConfigurationManager.AppSettings["loginURL"].ToString()), new FormUrlEncodedContent(paramList));
                    string res = response.Content.ReadAsStringAsync().Result;
                    
                    Token t = JsonConvert.DeserializeObject<Token>(res);
                    string postURL = ConfigurationManager.AppSettings["postCountURL"].ToString();
                    string data = JObject.FromObject(new
                    {
                        userInfo = new
                        {
                            projectName = ConfigurationManager.AppSettings["prorealname"].ToString()
                        }
                    }).ToString();
                    HttpContent hc = new StringContent(data);
                    
                    hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    hc.Headers.Add("token", t.token);
                    
                    HttpResponseMessage content = client.PostAsync(postURL, hc).Result;
                    string task = await content.Content.ReadAsStringAsync();
                    
                    try
                    {
                        JObject jj = JObject.Parse(task);
                        this.mm = "项目人数："+jj["record"].ToString();
                    }
                    catch (Exception ex) {
                        this.mm = "项目人数：0";
                        Console.WriteLine("数据解析错误" + ex.Message);
                    }
                }
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 人数统计LED模板
        /// </summary>
        /// <returns></returns>
        public string GetWorkerNumLEDInfo()
        {
            return GetWokerNum("项目人数") + GetWokerNum("考勤人数") + GetWokerNum("在场人数");
        }
        public string GetWokerNum(string type)
        {
            string countsql = "";
            if (type == "项目人数")
                countsql = string.Format("select count(identityId) as count from worker where groupname = '{0}';",
                    ConfigurationManager.AppSettings["prorealname"].ToString()
                    );
            if(type == "考勤人数")
                countsql = string.Format("select count(identityId) as count from worker where groupname = '{0}' and DATE(checkinTime) = '{1}';",
                    ConfigurationManager.AppSettings["prorealname"].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd")
                    );
            if (type == "在场人数")
                countsql = string.Format(@"SELECT
	                                            count(identityId) AS count
                                            FROM
	                                            worker
                                            WHERE
	                                            groupname = '{0}'
                                            AND checkinState = 1
                                            AND DATE(checkinTime) = '{1}';",
                    ConfigurationManager.AppSettings["prorealname"].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd")
                    );
            if ("" == countsql)
                return "";
            DataTable dtt = SQLiteDBHelper.ExecuteDataTable(countsql);

            if (dtt.Rows.Count <= 0)
                return "";
            int cc = Int32.Parse(dtt.Rows[0]["count"].ToString());
            if (cc > 0)
                return string.Format(type + "：{0} ", cc);
            else
                return "";
        }

    }
}
