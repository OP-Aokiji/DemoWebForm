using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public interface ICategoryLevel2Proxy
    {
        object CategoryLevel2CRUD(CategoryLevel2Item categoryLevel2Item);
    }
}