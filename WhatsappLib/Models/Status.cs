using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    /// <summary>
    /// Class to represent a status message
    /// </summary>
    public class Status
    {
        private string _statusMessage;

        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; }
        }
    }
}
