using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;
using WN.DataAccess;

namespace WN.ServiceProxy
{
    public class CategoryLevel2Proxy : ICategoryLevel2Proxy
    {
        public object CategoryLevel2CRUD(CategoryLevel2Item categoryLevel2Item) 
        {
            ICategoryLevel2DAO categoryLevel2Dao = new CategoryLevel2DAO();
            return categoryLevel2Dao.CategoryLevel2CRUD(categoryLevel2Item);
        }
    }
}