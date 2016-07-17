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
    public class ShopInfoDAO : IShopInfoDAO
    {
        public object ShopInfoCRUD(ShopInfoItem shopInfoItem)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[] { };
            string procedureName = string.Empty;
            string returnDatatype = string.Empty;

            if (shopInfoItem.shop_Ws.Equals(Constants.WS_QUERY))
            {
                obj = new object[] { };
                procedureName = "SP_SHOP_INFO_RETRIEVE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (shopInfoItem.shop_Ws.Equals(Constants.WS_UPDATE))
            {
                obj = new object[] {
                                        "@P_SHOP_NAME", shopInfoItem.shop_Name,
                                        "@P_SHOP_ADDRESS",  shopInfoItem.shop_Address,
                                        "@P_SHOP_PHONE",shopInfoItem.shop_Phone, 
                                        "@P_SHOP_EMAIL",shopInfoItem.shop_Email, 
                                        "@P_SHOP_EMAIL_PASSWORD",shopInfoItem.shop_Email_Password, 
                                        "@P_SHOP_SKYPE",shopInfoItem.shop_Skype
                                    };
                procedureName = "SP_SHOP_INFO_UPDATE";
                returnDatatype = Constants.STRING;
            }

            DataTable dataResult = accessObj.ExecuteDatatable(procedureName, obj);

            if (returnDatatype.Equals(Constants.DATATABLE))
                return dataResult;
            else return dataResult.Rows[0][Constants.ERR_CODE].ToString();
        }
    }
}