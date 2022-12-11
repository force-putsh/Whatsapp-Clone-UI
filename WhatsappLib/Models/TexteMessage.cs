using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    public class TexteMessage:MessageType
    {
        private string _texte;

        public string Texte
        {
            get { return _texte; }
            set { _texte = value; }
        }

        public TexteMessage(string texte)
        {
            _texte = texte;
        }
    }
}
