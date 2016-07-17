using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataAccess;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public class ProductProxy : IProductProxy
    {
        public object ProductCRUD(ProductItem productItem)
        {
            IProductDAO productDao = new ProductDAO();
            return productDao.ProductCRUD(productItem);
        }
    }
}