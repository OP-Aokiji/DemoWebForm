using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.DataItem
{
    public class TagSeoItem
    {
        private string _tag_Seo_Id;
        private string _tag_Seo_Name;
        private string _tag_Seo_Url;
        private string _tag_Seo_Ws;

        public string tag_Seo_Id
        {
            get { return _tag_Seo_Id; }
            set { _tag_Seo_Id = value; }
        }
        public string tag_Seo_Name
        {
            get { return _tag_Seo_Name; }
            set { _tag_Seo_Name = value; }
        }
        public string tag_Seo_Url
        {
            get { return _tag_Seo_Url; }
            set { _tag_Seo_Url = value; }
        }
        public string tag_Seo_Ws
        {
            get { return _tag_Seo_Ws; }
            set { _tag_Seo_Ws = value; }
        }
    }
}