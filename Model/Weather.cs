using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Weather
    {
        /**
         * "date":"2018-11-08",
                    "week":"4",
                    "dayweather":"小雨",
                    "nightweather":"多云",
                    "daytemp":"12",
                    "nighttemp":"6",
                    "daywind":"西",
                    "nightwind":"西",
                    "daypower":"6",
                    "nightpower":"5"
    */
        public string date { get; set; }
        public string week { get; set; }
        public string dayweather { get; set; }
        public string nightweather { get; set; }
        public string daytemp { get; set; }
        public string nighttemp { get; set; }
        public string daywind { get; set; }
        public string nightwind { get; set; }
        public string daypower { get; set; }
        public string nightpower { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", this.date,this.week,this.dayweather,this.nightweather,this.daytemp,this.nighttemp,this.daywind,this.nightwind,this.daypower,this.nightpower);
        }
    }
}
