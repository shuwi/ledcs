using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LEDArea
    {
        public int id { get; set; }
        public int led_id { get; set; }
        public int left_begin { get; set; }
        public int top_begin { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int area_type { get; set; }
        public int module_type { get; set; }
        public int multi_nAlignment { get; set; }
        public int multi_IsVCenter { get; set; }
        public int font_size { get; set; }
        public int font_bold { get; set; }
        public int in_style { get; set; }
        public int delay_time { get; set; }
        public int speed { get; set; }
    }
}
