using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataAccess;
using WN.DataItem;

namespace WN.ServiceProxy
{
    public class ProductImageProxy : IProductImageProxy
    {
        public object ProductImageCRUD(ProductImageItem productImageItem)
        {
            IProductImageDAO productImageDao = new ProductImageDAO();
            return productImageDao.ProductImageCRUD(productImageItem);
        }
    }
}