using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public interface IBannerProxy
    {
        object BannerCRUD(BannerItem bannerItem);
    }
}
