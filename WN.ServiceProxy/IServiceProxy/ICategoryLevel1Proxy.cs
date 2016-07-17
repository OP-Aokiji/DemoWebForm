using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public interface ICategoryLevel1Proxy
    {
        object CategoryLevel1CRUD(CategoryLevel1Item categoryLevel1Item);
    }
}