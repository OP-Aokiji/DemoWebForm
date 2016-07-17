using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.DataItem
{
    public class CategoryLevel1Item
    {
        private string _cat_L1_Id;
        private string _cat_L1_Name;
        private string _cat_L1_Description;
        private string _cat_L1_Ws;

        public string cat_L1_Id
        {
            get { return _cat_L1_Id; }
            set { _cat_L1_Id = value; }
        }
        public string cat_L1_Name
        {
            get { return _cat_L1_Name; }
            set { _cat_L1_Name = value; }
        }
        public string cat_L1_Description
        {
            get { return _cat_L1_Description; }
            set { _cat_L1_Description = value; }
        }
        public string cat_L1_Ws
        {
            get { return _cat_L1_Ws; }
            set { _cat_L1_Ws = value; }
        }
    }
}