using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SettingInfo
    {
        private int id;
        private string port;
        private string baud_rate;
        private string odd_even_valid;
        private string tag;

        public int Id {
            get { return id; }
            set { id = value; }
        }
        public string Port {
            get { return port; }
            set { port = value; }
        }
        public string Baud_rate
        {
            get { return baud_rate; }
            set { baud_rate = value; }
        }
        public string Odd_even_valid
        {
            get { return odd_even_valid; }
            set { odd_even_valid = value; }
        }
        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }
    }
}
