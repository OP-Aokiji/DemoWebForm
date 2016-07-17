using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataAccess;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public class ShopInfoProxy : IShopInfoProxy
    {
        public object ShopInfoCRUD(ShopInfoItem shopInfoItem)
        {
            IShopInfoDAO shopInfoDao = new ShopInfoDAO();
            return shopInfoDao.ShopInfoCRUD(shopInfoItem);
        }
    }
}