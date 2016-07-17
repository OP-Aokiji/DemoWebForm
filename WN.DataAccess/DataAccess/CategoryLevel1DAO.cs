using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;
using System.Data;
using WN.ADOService;
using WN.Common;

namespace WN.DataAccess
{
    public class CategoryLevel1DAO : ICategoryLevel1DAO
    {
        public object CategoryLevel1CRUD(CategoryLevel1Item categoryLevel1Item)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[] { };
            string procedureName = string.Empty;
            string returnDatatype = string.Empty;

            if (categoryLevel1Item.cat_L1_Ws.Equals(Constants.WS_QUERY))
            {
                obj = new object[] { "@P_CAT_L1_ID", categoryLevel1Item.cat_L1_Id };
                procedureName = "SP_CATEGORY_LEVEL1_RETRIEVE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (categoryLevel1Item.cat_L1_Ws.Equals(Constants.WS_RETRIEVE_PRODUCT_RETRIEVE_BY_CAT_L1))
            {
                obj = new object[] { "@P_CAT_L1_ID", categoryLevel1Item.cat_L1_Id };
                procedureName = "SP_PRODUCT_RETRIEVE_BY_CAT_L1";
                returnDatatype = Constants.DATATABLE;
            }
            else if (categoryLevel1Item.cat_L1_Ws.Equals(Constants.WS_INSERT))
            {
                obj = new object[] {
                                        "@P_CAT_L1_NAME",  categoryLevel1Item.cat_L1_Name,
                                        "@P_CAT_L1_DESCRIPTION",categoryLevel1Item.cat_L1_Description, 
                                    };
                procedureName = "SP_CATEGORY_LEVEL1_CREATE";
                returnDatatype = Constants.STRING;
            }
            else if (categoryLevel1Item.cat_L1_Ws.Equals(Constants.WS_UPDATE))
            {
                obj = new object[] {
                                        "@P_CAT_L1_ID", categoryLevel1Item.cat_L1_Id,
                                        "@P_CAT_L1_NAME",  categoryLevel1Item.cat_L1_Name,
                                        "@P_CAT_L1_DESCRIPTION",categoryLevel1Item.cat_L1_Description, 
                                    };
                procedureName = "SP_CATEGORY_LEVEL1_UPDATE";
                returnDatatype = Constants.STRING;
            }
            else if (categoryLevel1Item.cat_L1_Ws.Equals(Constants.WS_DELETE))
            {
                obj = new object[] { "@P_CAT_L1_ID", categoryLevel1Item.cat_L1_Id };
                procedureName = "SP_CATEGORY_LEVEL1_DELETE";
                returnDatatype = Constants.STRING;
            }

            DataTable dataResult = accessObj.ExecuteDatatable(procedureName, obj);

            if (returnDatatype.Equals(Constants.DATATABLE))
                return dataResult;
            else return dataResult.Rows[0][Constants.ERR_CODE].ToString();
        }
    }
}