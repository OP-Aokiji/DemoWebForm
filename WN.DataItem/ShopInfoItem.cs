using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.DataItem
{
    public class ShopInfoItem
    {
        private string _shop_Name;
        private string _shop_Address;
        private string _shop_Phone;
        private string _shop_Email;
        private string _shop_Email_Password;
        private string _shop_Skype;
        private string _shop_Ws;

        public string shop_Name
        {
            get { return _shop_Name; }
            set { _shop_Name = value; }
        }
        public string shop_Address
        {
            get { return _shop_Address; }
            set { _shop_Address = value; }
        }
        public string shop_Phone
        {
            get { return _shop_Phone; }
            set { _shop_Phone = value; }
        }
        public string shop_Email
        {
            get { return _shop_Email; }
            set { _shop_Email = value; }
        }
        public string shop_Email_Password
        {
            get { return _shop_Email_Password; }
            set { _shop_Email_Password = value; }
        }
        public string shop_Skype
        {
            get { return _shop_Skype; }
            set { _shop_Skype = value; }
        }
      
        public string shop_Ws
        {
            get { return _shop_Ws; }
            set { _shop_Ws = value; }
        }
    }
}