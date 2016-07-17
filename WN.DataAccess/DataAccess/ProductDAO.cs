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
    public class ProductDAO : IProductDAO
    {
        public object ProductCRUD(ProductItem productItem)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[] { };
            string procedureName = string.Empty;
            string returnDatatype = string.Empty;

            if (productItem.pro_Ws.Equals(Constants.WS_QUERY))
            {
                obj = new object[] { "@P_PRO_ID", productItem.pro_Id };
                procedureName = "SP_PRODUCT_RETRIEVE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_RETRIEVE_PRODUCT_RETRIEVE_BY_CAT_L2))
            {
                obj = new object[] { "@P_CAT_L2_ID", productItem.cat_L2_Id };
                procedureName = "SP_PRODUCT_RETRIEVE_BY_CAT_L2";
                returnDatatype = Constants.DATATABLE;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_RETRIEVE_PRODUCT_BY_GENDER))
            {
                obj = new object[] { "@P_GENDER", productItem.pro_Gender };
                procedureName = "SP_PRODUCT_RETRIEVE_BY_GENDER";
                returnDatatype = Constants.DATATABLE;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_SEARCH_PRODUCT))
            {
                obj = new object[] { "@P_PRO_NAME", productItem.pro_Name };
                procedureName = "SP_PRODUCT_SEARCH_BY_PRO_NAME";
                returnDatatype = Constants.DATATABLE;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_INSERT))
            {
                obj = new object[] {
                                        "@P_PRO_NAME",  productItem.pro_Name,
                                        "@P_CAT_L2_ID",  productItem.cat_L2_Id,
                                        "@P_PRO_OLD_PRICE", productItem.pro_Old_Price,
                                        "@P_PRO_PRICE",  productItem.pro_Price,
                                        "@P_PRO_GENDER",productItem.pro_Gender,
                                        "@P_PRO_HOME_PAGE",  productItem.pro_Home_Page,
                                        "@P_PRO_DESCRIPTION",  productItem.pro_Description,
                                    };
                procedureName = "SP_PRODUCT_CREATE";
                returnDatatype = Constants.STRING;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_UPDATE))
            {
                obj = new object[] {
                                        "@P_PRO_ID",  productItem.pro_Id,
                                        "@P_PRO_NAME",  productItem.pro_Name,
                                        "@P_CAT_L2_ID",  productItem.cat_L2_Id,
                                        "@P_PRO_OLD_PRICE", productItem.pro_Old_Price,
                                        "@P_PRO_PRICE",  productItem.pro_Price,
                                        "@P_PRO_GENDER",productItem.pro_Gender,
                                        "@P_PRO_HOME_PAGE",  productItem.pro_Home_Page,
                                        "@P_PRO_DESCRIPTION",  productItem.pro_Description,
                                    };
                procedureName = "SP_PRODUCT_UPDATE";
                returnDatatype = Constants.STRING;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_DELETE))
            {
                obj = new object[] { "@P_PRO_ID", productItem.pro_Id };
                procedureName = "SP_PRODUCT_DELETE";
                returnDatatype = Constants.STRING;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_RETRIEVE_PRODUCT_HOME_PAGE))
            {
                obj = new object[] { 
                                   };
                procedureName = "SP_PRODUCT_RETRIEVE_HOME_PAGE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_AC_RETRIEVE_PRODUCT_HOME_PAGE))
            {
                obj = new object[] { "@P_PRO_NAME_STRING", productItem.pro_Name };
                procedureName = "SP_AC_PRODUCT_RETRIEVE_HOME_PAGE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_REMOVE_PRODUCT_FROM_HOME_PAGE))
            {
                obj = new object[] { "@P_PRO_ID", productItem.pro_Id };
                procedureName = "SP_PRODUCT_REMOVE_HOME_PAGE";
                returnDatatype = Constants.STRING;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_RETRIEVE_PRODUCT_DETAIL))
            {
                obj = new object[] { "@P_PRO_ID", productItem.pro_Id };
                procedureName = "SP_PRODUCT_DETAIL";
                returnDatatype = Constants.DATASET;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_AC_SEARCH_PRODUCT))
            {
                obj = new object[] { "@P_PRO_NAME_STRING", productItem.pro_Name };
                procedureName = "SP_AC_PRODUCT_SEARCH_DATA";
                returnDatatype = Constants.DATATABLE;
            }
            else if (productItem.pro_Ws.Equals(Constants.WS_SEARCH_PRODUCT))
            {
                obj = new object[] { "@P_PRO_NAME_STRING", productItem.pro_Name 
                                   };
                procedureName = "SP_PRODUCT_SEARCH_DATA";
                returnDatatype = Constants.DATATABLE;
            }
            if (returnDatatype.Equals(Constants.DATATABLE))
            {
                return accessObj.ExecuteDatatable(procedureName, obj); //Datatable
            }
            else if (returnDatatype.Equals(Constants.DATASET))
            {
                return accessObj.ExecuteDataSet(procedureName, obj);//Dataset
            }
            else
            {
                return accessObj.ExecuteDatatable(procedureName, obj).Rows[0][Constants.ERR_CODE].ToString(); //String
            }
        }
    }
}