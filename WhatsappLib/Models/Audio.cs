using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    public class Audio:Media
    {
        private string _duration;
        private string _url;

        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public Audio(string fileSize, string fileName, string duration, string url) : base(fileSize, fileName)
        {
            Duration = duration;
            Url = url;
        }
    }
}
