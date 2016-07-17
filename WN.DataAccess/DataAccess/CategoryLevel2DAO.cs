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
    public class CategoryLevel2DAO : ICategoryLevel2DAO
    {
        public object CategoryLevel2CRUD(CategoryLevel2Item categoryLevel2Item)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[] { };
            string procedureName = string.Empty;
            string returnDatatype = string.Empty;

            if (categoryLevel2Item.cat_L2_Ws.Equals(Constants.WS_QUERY))
            {
                obj = new object[] { "@P_CAT_L2_ID", categoryLevel2Item.cat_L2_Id };
                procedureName = "SP_CATEGORY_LEVEL2_RETRIEVE";
                returnDatatype = Constants.DATATABLE;
            }
            if (categoryLevel2Item.cat_L2_Ws.Equals(Constants.WS_RETRIEVE_CATEGORY_LEVEL2_BY_CAT_L1))
            {
                obj = new object[] { "@P_CAT_L1_ID", categoryLevel2Item.cat_L1_Id };
                procedureName = "SP_CATEGORY_LEVEL2_RETRIEVE_BY_CAT_L1";
                returnDatatype = Constants.DATATABLE;
            }
            else if (categoryLevel2Item.cat_L2_Ws.Equals(Constants.WS_INSERT))
            {
                obj = new object[] {
                                        "@P_CAT_L1_ID",  categoryLevel2Item.cat_L1_Id,
                                        "@P_CAT_L2_NAME",  categoryLevel2Item.cat_L2_Name,
                                        "@P_CAT_L2_DESCRIPTION",categoryLevel2Item.cat_L2_Description, 
                                    };
                procedureName = "SP_CATEGORY_LEVEL2_CREATE";
                returnDatatype = Constants.STRING;
            }
            else if (categoryLevel2Item.cat_L2_Ws.Equals(Constants.WS_UPDATE))
            {
                obj = new object[] {
                                        "@P_CAT_L2_ID", categoryLevel2Item.cat_L2_Id,
                                        "@P_CAT_L1_ID",  categoryLevel2Item.cat_L1_Id,
                                        "@P_CAT_L2_NAME",  categoryLevel2Item.cat_L2_Name,
                                        "@P_CAT_L2_DESCRIPTION",categoryLevel2Item.cat_L2_Description, 
                                    };
                procedureName = "SP_CATEGORY_LEVEL2_UPDATE";
                returnDatatype = Constants.STRING;
            }
            else if (categoryLevel2Item.cat_L2_Ws.Equals(Constants.WS_DELETE))
            {
                obj = new object[] { "@P_CAT_L2_ID", categoryLevel2Item.cat_L2_Id };
                procedureName = "SP_CATEGORY_LEVEL2_DELETE";
                returnDatatype = Constants.STRING;
            }

            DataTable dataResult = accessObj.ExecuteDatatable(procedureName, obj);

            if (returnDatatype.Equals(Constants.DATATABLE))
                return dataResult;
            else return dataResult.Rows[0][Constants.ERR_CODE].ToString();
        }
    }
}