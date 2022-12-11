using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    public class Video:Media
    {
        private string _height;
        private string _width;
        private string _url;
        private string _duration;

        public string Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public string Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public Video(string fileSize, string fileName, string height, string width, string url, string duration) : base(fileSize, fileName)
        {
            Height = height;
            Width = width;
            Url = url;
            Duration = duration;
        }
    }
}
