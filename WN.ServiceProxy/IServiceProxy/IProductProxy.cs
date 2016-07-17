using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public interface IProductProxy
    {
        object ProductCRUD(ProductItem productItem);
    }
}
