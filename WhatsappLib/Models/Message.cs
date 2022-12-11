using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    public class Message : IEquatable<Message>
    {
        private Status _statut;
        private MessageType _content;
        private User _sender;
        private User _receiver;
        private DateTime _receivedDate;
        private DateTime _sentDate;

        public Status Statut
        {
            get { return _statut; }
            set { _statut = value; }
        }

        public MessageType Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public User Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        public User Receiver
        {
            get { return _receiver; }
            set { _receiver = value; }
        }

        public DateTime ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        public DateTime SentDate
        {
            get { return _sentDate; }
            set { _sentDate = value; }
        }

        public Message(Status statut, MessageType content, User sender, User receiver, DateTime receivedDate, DateTime sentDate)
        {
            _statut = statut;
            _content = content;
            _sender = sender;
            _receiver = receiver;
            _receivedDate = receivedDate;
            _sentDate = sentDate;
        }

        public bool Equals(Message? other)
        {
            return this.Sender.Equals(other.Sender) && this.Receiver.Equals(other.Receiver) && this.Content.Equals(other.Content);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            return this.Equals(obj as Message);
        }
    }
}
