using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModuleInfo
    {
        private int id;                          //主键
        private int led_id;                      //led屏id   
        private int left_begin;                  //区域原点横坐标
        private int top_begin;                   //区域原点纵坐标
        private int width;                       //区域宽度
        private int height;                      //区域高度
        private int area_type;                   //区域类型
        private string module_type;                 //区域内容类型
        private int multi_nAlignment;            //水平对齐样式
        private int multi_IsVCenter;             //是否垂直居中
        private int font_size;                   //字体大小
        private int font_bold;                   //是否加粗默认不加粗0，加粗1
        private int in_style;                    //入场动画
        private int delay_time;                  //页面留停时间(1-65535)
        private int speed;                       //动画的显示速度
        private int area_no;                     //区域号，最大值为6，唯一
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Led_id
        {
            get { return led_id; }
            set { led_id = value; }
        }

        public int Left_begin
        {
            get { return left_begin; }
            set { left_begin = value; }
        }

        public int Top_begin
        {
            get { return top_begin; }
            set { top_begin = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Area_type
        {
            get { return area_type; }
            set { area_type = value; }
        }
        public string Module_type
        {
            get { return module_type; }
            set { module_type = value; }
        }
        public int Multi_nAlignment
        {
            get { return multi_nAlignment; }
            set { multi_nAlignment = value; }
        }
        public int Multi_IsVCenter
        {
            get { return multi_IsVCenter; }
            set { multi_IsVCenter = value; }
        }
        public int Font_size
        {
            get { return font_size; }
            set { font_size = value; }
        }
        public int Font_bold
        {
            get { return font_bold; }
            set { font_bold = value; }
        }
        public int In_style
        {
            get { return in_style; }
            set { in_style = value; }
        }
        public int Delay_time
        {
            get { return delay_time; }
            set { delay_time = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Area_no
        {
            get { return area_no; }
            set { area_no = value; }
        }
    }
}
