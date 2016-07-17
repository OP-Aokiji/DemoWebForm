using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.DataItem
{
    public class ProductItem
    {
        private string _pro_Id;
        private string _pro_Name;
        private string _cat_L2_Id;
        private string _pro_Old_Price;
        private string _pro_Price;
        private string _pro_Gender;
        private bool _pro_Home_Page;
        private string _pro_Description;
        private string _pro_Ws;
       
        public string pro_Id
        {
            get { return _pro_Id; }
            set { _pro_Id = value; }
        }
        public string pro_Name
        {
            get { return _pro_Name; }
            set { _pro_Name = value; }
        }
     
        public string cat_L2_Id
        {
            get { return _cat_L2_Id; }
            set { _cat_L2_Id = value; }
        }
        public string pro_Old_Price
        {
            get { return _pro_Old_Price; }
            set { _pro_Old_Price = value; }
        }
        public string pro_Price
        {
            get { return _pro_Price; }
            set { _pro_Price = value; }
        }
    
        public string pro_Discount
        {
            get { return _pro_Gender; }
            set { _pro_Gender = value; }
        }
        public bool pro_Home_Page
        {
            get { return _pro_Home_Page; }
            set { _pro_Home_Page = value; }
        }
        public string pro_Gender
        {
            get { return _pro_Gender; }
            set { _pro_Gender = value; }
        }
        public string pro_Description
        {
            get { return _pro_Description; }
            set { _pro_Description = value; }
        }
        public string pro_Ws
        {
            get { return _pro_Ws; }
            set { _pro_Ws = value; }
        }
    }
}