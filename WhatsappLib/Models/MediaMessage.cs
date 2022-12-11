using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    /// <summary>
    /// Represente media type of message
    /// </summary>
    public class MediaMessage : MessageType
    {
        private string _description;
        private Media _fileType;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Media FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }
        public MediaMessage(string description, Media fileType)
        {
            Description = description;
            FileType = fileType;
        }
    }
}
