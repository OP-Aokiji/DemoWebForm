using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataAccess;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public class TagSeoProxy : ITagSeoProxy
    {
        public object TagSeoCRUD(TagSeoItem tagSeoItem)
        {
            ITagSeoDAO tagSeoDao = new TagSeoDAO();
            return tagSeoDao.TagSeoCRUD(tagSeoItem);
        }
    }
}