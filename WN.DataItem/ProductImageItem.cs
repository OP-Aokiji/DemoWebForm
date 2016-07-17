using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.DataItem
{
    public class ProductImageItem
    {
        private string _pro_Id;
        private string _img_Id;
        private string _img_Name;
        private string _img_Description;
        private string _img_Ws;

        public string pro_Id
        {
            get { return _pro_Id; }
            set { _pro_Id = value; }
        }
        public string img_Id
        {
            get { return _img_Id; }
            set { _img_Id = value; }
        }
        public string img_Name
        {
            get { return _img_Name; }
            set { _img_Name = value; }
        }
        public string img_Description
        {
            get { return _img_Description; }
            set { _img_Description = value; }
        }
        public string img_Ws
        {
            get { return _img_Ws; }
            set { _img_Ws = value; }
        }
    }
}