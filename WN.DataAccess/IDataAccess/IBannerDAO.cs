using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WN.DataItem;

namespace WN.DataAccess
{
    public interface IBannerDAO
    {
        object BannerCRUD(BannerItem bannerItem);
    }
}
