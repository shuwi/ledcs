using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResponseWorker
    {
        public string userName { get; set; }//人员姓名
        public string userId { get; set; }//身份证号
        public string mobile { get; set; }//手机号码
        public int workKind { get; set; }//工种值
        public string workKindName { get; set; }//工种名
        public string classNo { get; set; }//班组
        public string photo { get; set; }//身份证照片(base64)
        public string createDate { get; set; }//录入时间
    }
}
