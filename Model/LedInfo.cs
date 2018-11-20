using System;

namespace Model
{
    public class LedInfo
    {
        private int id;
        private string projectName;
        private string ledIp;
        private int width;
        private int height;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
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

        public string LedIp
        {
            get { return ledIp; }
            set { ledIp = value; }
        }
    }
}
