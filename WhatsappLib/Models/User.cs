using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    /// <summary>
    /// This class represent user of the application
    /// </summary>
    public class User : IEquatable<User>
    {
        private string _pseudo;
        private string _phoneNumber;
        private string _country;
        private string _status;
        private DateTime _lastSeen;
        private Image _profilePicture;
        private ICollection<User> _contacts = new List<User>();
        private ICollection<User> _blockedContacts = new List<User>();
        private ICollection<Message> _messages = new List<Message>();



        public string Pseudo
        {
            get { return _pseudo; }
            set { _pseudo = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public DateTime LastSeen
        {
            get { return _lastSeen; }
            set { _lastSeen = value; }
        }

        public Image ProfilePicture
        {
            get { return _profilePicture; }
            set { _profilePicture = value; }
        }

        public ReadOnlyCollection<User> Contacts { get; }

        public User(string pseudo, string phoneNumber, string country, string status, DateTime lastSeen, Image profilePicture)
        {
            _pseudo = pseudo;
            _phoneNumber = phoneNumber;
            _country = country;
            _status = status;
            _lastSeen = lastSeen;
            _profilePicture = profilePicture;
        }

        //constructor for the user who is connected
        public User(string pseudo, string phoneNumber, string country, string status, DateTime lastSeen, Image profilePicture, ICollection<User> contacts, ICollection<User> blockedContacts, ICollection<Message> messages)
        {
            _pseudo = pseudo;
            _phoneNumber = phoneNumber;
            _country = country;
            _status = status;
            _lastSeen = lastSeen;
            _profilePicture = profilePicture;
            _contacts = contacts;
            _blockedContacts = blockedContacts;
            _messages = messages;
        }

        public void AddContact(User contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            if (contact.Equals(this)) throw new ArgumentException("You can't add yourself as a contact");
            if (this._contacts.Contains(contact)) throw new ArgumentException("This contact already exists");
            this._contacts.Add(contact);
        }

        public void RemoveContact(User contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            if (!this._contacts.Contains(contact)) throw new ArgumentException("This contact doesn't exist");
            this._contacts.Remove(contact);
        }

        public void BlockContact(User contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            if (contact.Equals(this)) throw new ArgumentException("You can't block yourself");
            if (this._blockedContacts.Contains(contact)) throw new ArgumentException("This contact is already blocked");
            this._blockedContacts.Add(contact);
        }

        public void UnblockContact(User contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            if (!this._blockedContacts.Contains(contact)) throw new ArgumentException("This contact is not blocked");
            this._blockedContacts.Remove(contact);
        }

        public void SendMessage(Message message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (message.Sender == null) throw new ArgumentException("The sender of the message is null");
            if (message.Receiver == null) throw new ArgumentException("The receiver of the message is null");
            if (this._blockedContacts.Contains(message.Receiver)) throw new ArgumentException("You can't send a message to a contact that is blocked");
            this._messages.Add(message);
        }

        public void ReceiveMessage(Message message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (message.Sender == null) throw new ArgumentException("The sender of the message is null");
            if (message.Receiver == null) throw new ArgumentException("The receiver of the message is null");
            if (this._blockedContacts.Contains(message.Sender)) throw new ArgumentException("You can't receive a message from a contact that is blocked");
            this._messages.Add(message);
        }

        public ReadOnlyCollection<Message> GetMessages()
        {
            return new ReadOnlyCollection<Message>(this._messages.ToList());
        }

        public ReadOnlyCollection<Message> GetMessages(User contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            if (!this._contacts.Contains(contact)) throw new ArgumentException("This contact doesn't exist");
            return new ReadOnlyCollection<Message>(this._messages.Where(m => m.Sender.Equals(contact) || m.Receiver.Equals(contact)).ToList());
        }

        // public ReadOnlyCollection<Message> GetMessages(User contact, DateTime date)
        // {
        //     if (contact == null) throw new ArgumentNullException(nameof(contact));
        //     if (!this._contacts.Contains(contact)) throw new ArgumentException("This contact doesn't exist");
        //     return new ReadOnlyCollection<Message>(this._messages.Where(m => (m.Sender.Equals(contact) || m.Receiver.Equals(contact)) && m.Date.Date.Equals(date.Date)).ToList());
        // }

        // public ReadOnlyCollection<Message> GetMessages(User contact, DateTime startDate, DateTime endDate)
        // {
        //     if (contact == null) throw new ArgumentNullException(nameof(contact));
        //     if (!this._contacts.Contains(contact)) throw new ArgumentException("This contact doesn't exist");
        //     return new ReadOnlyCollection<Message>(this._messages.Where(m => (m.Sender.Equals(contact) || m.Receiver.Equals(contact)) && m.Date.Date >= startDate.Date && m.Date.Date <= endDate.Date).ToList());
        // }

        public bool Equals(User? other)
        {
            if (other == null) return false;
            return this.PhoneNumber.Equals(other.PhoneNumber);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.GetType() != obj.GetType()) return false;
            return Equals(obj as User);
        }

        public override int GetHashCode()
        {
            return PhoneNumber.GetHashCode();
        }
    }
}
