﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WN.DataItem;

namespace WN.DataAccess
{
    public interface IProductDAO
    {
        object ProductCRUD(ProductItem productItem);
    }
}