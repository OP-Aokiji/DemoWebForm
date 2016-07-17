using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WN.DataItem;
using WN.ADOService;
using WN.Common;

namespace WN.DataAccess
{
    public class ProductImageDAO : IProductImageDAO
    {
        public object ProductImageCRUD(ProductImageItem productImageItem)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[] { };
            string procedureName = string.Empty;
            string returnDatatype = string.Empty;

            if (productImageItem.img_Ws.Equals(Constants.WS_QUERY))
            {
                obj = new object[] { "@P_PRO_ID", productImageItem.pro_Id };
                procedureName = "SP_PRODUCT_IMAGE_RETRIEVE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (productImageItem.img_Ws.Equals(Constants.WS_INSERT))
            {
                obj = new object[] {    "@P_PRO_ID", productImageItem.pro_Id,
                                        "@P_IMG_NAME",  productImageItem.img_Name,
                                        "@P_IMG_DESCRIPTION",  productImageItem.img_Description
                                    };
                procedureName = "SP_PRODUCT_IMAGE_CREATE";
                returnDatatype = Constants.STRING;
            }
            else if (productImageItem.img_Ws.Equals(Constants.WS_UPDATE))
            {
                obj = new object[] {
                                        "@P_PRO_ID",  productImageItem.pro_Id,
                                        "@P_IMG_ID",productImageItem.img_Id, 
                                        "@P_IMG_NAME",  productImageItem.img_Name,
                                        "@P_IMG_DESCRIPTION",  productImageItem.img_Description
                                    };
                procedureName = "SP_PRODUCT_IMAGE_UPDATE";
                returnDatatype = Constants.STRING;
            }
            else if (productImageItem.img_Ws.Equals(Constants.WS_DELETE))
            {
                obj = new object[] { "@P_IMG_ID",productImageItem.img_Id  };
                procedureName = "SP_PRODUCT_IMAGE_DELETE";
                returnDatatype = Constants.STRING;
            }

            DataTable dataResult = accessObj.ExecuteDatatable(procedureName, obj);

            if (returnDatatype.Equals(Constants.DATATABLE))
                return dataResult;
            else return dataResult.Rows[0][Constants.ERR_CODE].ToString();
        }
    }
}