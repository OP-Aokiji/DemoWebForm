using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;

namespace WN.DataAccess
{
    public interface ICategoryLevel1DAO
    {
        object CategoryLevel1CRUD(CategoryLevel1Item categoryLevel1Item);
    }
}