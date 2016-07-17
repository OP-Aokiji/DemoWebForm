using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.DataItem
{
    public class CategoryLevel2Item
    {
        private string _cat_L1_Id;
        private string _cat_L2_Id;
        private string _cat_L2_Name;
        private string _cat_L2_Description;
        private string _cat_L2_Ws;

        public string cat_L1_Id
        {
            get { return _cat_L1_Id; }
            set { _cat_L1_Id = value; }
        }
        public string cat_L2_Id
        {
            get { return _cat_L2_Id; }
            set { _cat_L2_Id = value; }
        }
        public string cat_L2_Name
        {
            get { return _cat_L2_Name; }
            set { _cat_L2_Name = value; }
        }
        public string cat_L2_Description
        {
            get { return _cat_L2_Description; }
            set { _cat_L2_Description = value; }
        }
        public string cat_L2_Ws
        {
            get { return _cat_L2_Ws; }
            set { _cat_L2_Ws = value; }
        }
    }
}