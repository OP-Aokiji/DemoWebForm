using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;
using WN.DataAccess;

namespace WN.ServiceProxy
{
    public class CategoryLevel1Proxy : ICategoryLevel1Proxy
    {
        public object CategoryLevel1CRUD(CategoryLevel1Item categoryLevel1Item) 
        {
            ICategoryLevel1DAO categoryLevel1Dao = new CategoryLevel1DAO();
            return categoryLevel1Dao.CategoryLevel1CRUD(categoryLevel1Item);
        }
    }
}