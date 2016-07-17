using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WN.DataAccess;
using WN.DataItem;
using WN.ServiceProxy;

namespace WN.ServiceProxy
{
    public class BannerProxy : IBannerProxy
    {
        public object BannerCRUD(BannerItem bannerItem)
        {
            IBannerDAO bannerDao = new BannerDAO();
            return bannerDao.BannerCRUD(bannerItem);
        }
    }
}
