using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.DataItem
{
    public class UserAcountItem
    {
        private string _user_Id;
        private string _user_Name;
        private string _user_fullname;
        private string _user_Password;
        private string _user_Email;
        private string _user_Ws;

        public string user_Id
        {
            get { return _user_Id; }
            set { _user_Id = value; }
        }
        public string user_Name
        {
            get { return _user_Name; }
            set { _user_Name = value; }
        }
        public string user_fullname
        {
            get { return _user_fullname; }
            set { _user_fullname = value; }
        }
        public string user_Password
        {
            get { return _user_Password; }
            set { _user_Password = value; }
        }
        public string user_Email
        {
            get { return _user_Email; }
            set { _user_Email = value; }
        }
        public string user_Ws
        {
            get { return _user_Ws; }
            set { _user_Ws = value; }
        }
    }
}