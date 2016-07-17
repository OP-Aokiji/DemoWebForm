using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public interface IShopInfoProxy
    {
        object ShopInfoCRUD(ShopInfoItem shopInfoItem);
    }
}