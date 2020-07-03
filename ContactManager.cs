using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;

namespace Practise
{
    class ContactManager
    {
        private List<ContactEntry> _entries;
        private string _filePath;

        public ContactManager()
        {
            _entries= new List<ContactEntry>();
            _filePath ="";
        }
        public ContactManager(string filePath)
        {
            _entries = new List<ContactEntry>();
            ReadFromFile(filePath);
            _filePath = filePath;
        }
        public bool ReadFromFile(string filePath) {
            _filePath = filePath;
            if (!File.Exists(filePath)) 
            return false;
            StreamReader sr = File.OpenText(_filePath);
            while (!sr.EndOfStream)
            {
                this.AddEntryFromFileLine(sr.ReadLine());
            }
            return true;
        }
        public void AddEntry(ContactEntry contact)
        {
            _entries.Add(contact);
        }
        public void AddEntry(ContactEntry contact, bool forceCommit)
        {
            AddEntry(contact);

            if (forceCommit)
                Commit();
        }

        public void Commit()
        {
            StreamWriter sw = File.CreateText(_filePath);

            foreach (ContactEntry ce in _entries)
            {
                sw.WriteLine(string.Format("{0}|{1}|{2}|{3}",
                  ce.LastName,
                  ce.FirstName,
                  ce.PhoneNumber,
                  ce.Email));
            }
            sw.Close();

        }
        public IEnumerable<ContactEntry> Entries
        {
            get {return _entries.AsReadOnly(); }
        }
        public ContactEntry SearchForContact(string lastName, string firstName)
        {
            foreach (ContactEntry ce in _entries)
                if (ce.LastName == lastName && ce.FirstName == firstName)
                    return ce;
            return null;
        }
        public void RemoveEntry(ContactEntry contact)
        {
            _entries.Remove(contact);
        }

        private void AddEntryFromFileLine(string line) {
            string[] fields =line.Split('|');

            ContactEntry ce = new ContactEntry();
            ce.LastName = fields[0];
            ce.FirstName = fields[1];
            ce.PhoneNumber = fields[2];
            ce.Email = fields[3];


            _entries.Add(ce); 
        }
    }
}
