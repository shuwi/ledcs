using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Module
    {
        private int id;
        private string module_type;
        private string module_text;
        public int Id {
            get { return id; }
            set { id = value; }
        }
        public string Module_type
        {
            get { return module_type; }
            set { module_type = value; }
        }
        public string Module_text
        {
            get { return module_text; }
            set { module_text = value; }
        }
    }
}
