using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.DataItem
{
    public class EmailItem
    {
        private string _from_Email_Address;
        private string _from_Email_Password;
        private string _from_Display;
        private string _to_Email_Address;
        private string _subject;
        private string _body;

        public string from_Email_Address
        {
            get { return _from_Email_Address; }
            set { _from_Email_Address = value; }
        }
        public string from_Email_Password
        {
            get { return _from_Email_Password; }
            set { _from_Email_Password = value; }
        }
        public string from_Display
        {
            get { return _from_Display; }
            set { _from_Display = value; }
        }
        public string to_Email_Address
        {
            get { return _to_Email_Address; }
            set { _to_Email_Address = value; }
        }
        public string subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public string body
        {
            get { return _body; }
            set { _body = value; }
        }
    }
}