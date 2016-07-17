using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;

namespace WN.DataAccess
{
    public interface ICategoryLevel2DAO
    {
        object CategoryLevel2CRUD(CategoryLevel2Item categoryLevel2Item);
    }
}