using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    public class Image : Media
    {
        private string _height;
        private string _width;
        private string _url;

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
        public Image(string fileSize, string fileName, string height, string width, string url) : base(fileSize, fileName)
        {
            Height = height;
            Width = width;
            Url = url;
        }
    }
}
