﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAO;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/**
* 作者：haoran xu
* 时间：2018/3/22 19:17:00
* 版权：星云网格
* update by xiaohui
*/
namespace LedScreen
{
    class CommonUtil
    {
        //工人数据表SQL
        public static string workersql = @"
                CREATE TABLE worker (
                  id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                  identityId varchar(255) NOT NULL,
                  username varchar(255) NOT NULL,
                  contact varchar(255) NOT NULL,
                  job varchar(255) NOT NULL,
                  groupname varchar(255) NOT NULL,
                  addtime varchar(255) NOT NULL,
                  checkinState int(2) NOT NULL,
                  checkinTime datetime NOT NULL,
                  identityPhoto TEXT NOT NULL
                )
            ";
        //工种数据表SQL
        public static string jobsql = @"
            CREATE TABLE job (
              id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
              jname varchar(255) NOT NULL
            )
        ";
        //LED区域划分表SQL
        public static string ledareasql = @"
            CREATE TABLE led_area (
              id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
              led_id integer NOT NULL,
              left_begin integer NOT NULL,
              top_begin integer NOT NULL,
              width integer NOT NULL,
              height integer NOT NULL,
              area_type integer NOT NULL,
              module_type varchar(11) NOT NULL,
              multi_nAlignment integer,
              multi_IsVCenter integer,
              font_size integer,
              font_bold integer,
              in_style integer,
              delay_time integer,
              speed integer,
              area_no integer 
            )
        ";
        //LED主信息表SQL
        public static string ledinfosql = @"
            CREATE TABLE led_info (
              id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
              led_ip varchar(50) NOT NULL,
              width integer NOT NULL,
              height integer NOT NULL,
              project_name varchar(200)
            )
        ";
        //LED模板数据表SQL
        public static string ledmodulesql = @"
            CREATE TABLE led_module (
              id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
              module_type varchar(110) NOT NULL,
              module_text TEXT
            )
        ";
        //串口设置数据表SQL
        public static string settinginfosql = @"
            CREATE TABLE setting_info (
              id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
              port varchar(255) NOT NULL,
              baud_rate varchar(255) NOT NULL,
              odd_even_valid varchar(20) NOT NULL,
              tag integer
            )
        ";
        public static string asyncdatasql = @"
            CREATE TABLE IF NOT EXISTS asyncdata (
              id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
              functionname varchar(255) NOT NULL,
              res TEXT NOT NULL
            )
        ";
        /// <summary>
        /// 异步网络请求数据
        /// </summary>
        /// <param name="postURL">请求地址</param>
        /// <param name="data">请求携带的数据</param>
        /// <returns>请求结果，可转为json</returns>
        public static async Task<string> GetResponseAsync(string postURL,string data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Referer", GetConfigValue("referer"));
                    List<KeyValuePair<string, string>> paramList = new List<KeyValuePair<string, string>>();
                    paramList.Add(new KeyValuePair<string, string>("userName", GetConfigValue("user")));
                    paramList.Add(new KeyValuePair<string, string>("password", GetConfigValue("pwd")));
                    HttpResponseMessage response = new HttpResponseMessage();
                    HttpContent ct = new FormUrlEncodedContent(paramList);
                    response = await client.PostAsync(new Uri(GetConfigValue("loginURL")), ct);
                    //Console.WriteLine(string.Format("登录请求：{0}", ct));
                    
                    string res = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(string.Format("登录结果：{0}", res));
                    Token t = JsonConvert.DeserializeObject<Token>(res);
                    //Console.WriteLine("data = {0}", data);
                    HttpContent hc = new StringContent(data);
                    hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    hc.Headers.Add("token", t.token);
                    HttpResponseMessage content = client.PostAsync(postURL, hc).Result;
                    //Console.WriteLine("开始异步访问网络...");
                    string task = await content.Content.ReadAsStringAsync();
                    return task;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
        /// <summary>
        /// 持久化需要线上获取的统计信息
        /// </summary>
        /// <param name="functionname"></param>
        /// <param name="res"></param>
        public static void updateAsyncData(string functionname, string res)
        {

            DataTable dt = SQLiteDBHelper.ExecuteDataTable(string.Format("select * from asyncdata where functionname = '{0}'", functionname));
            Console.WriteLine(string.Format("select * from asyncdata where functionname = '{0}'", functionname));
            DataRow row = null;
            if (dt.Rows.Count > 0)
                row = dt.Rows[0];
            if (null == row)
            {
                string insertsql = string.Format("insert into asyncdata(functionname,res)values('{0}','{1}')",
                    functionname,
                    res
                    );
                if (SQLiteDBHelper.ExecuteNonQuery(insertsql) > 0)
                {
                    Console.WriteLine("新增模板记录成功！");
                }
            }
            else
            {
                string insertsql = string.Format("update asyncdata set res = '{0}' where functionname = '{1}'",
                    res, functionname
                    );
                if (SQLiteDBHelper.ExecuteNonQuery(insertsql) > 0)
                {
                    //Console.WriteLine("修改模板记录成功！");
                }
            }

        }
        public static string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        public static bool IsNumeric(string value)
        {
            if ("".Equals(value))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
            }
        }

        public static void DebugConsole(string mess)
        {
#if DEBUG
            Console.WriteLine(mess);
#endif
        }
    }
}
