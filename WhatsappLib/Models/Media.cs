using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    /// <summary>
    /// This class represente media
    /// </summary>
    public class Media
    {
        private string _fileSize;
        private string _fileName;


        public string FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        public Media(string fileSize, string fileName)
        {
            FileSize = fileSize;
            FileName = fileName;
        }
    }
}
