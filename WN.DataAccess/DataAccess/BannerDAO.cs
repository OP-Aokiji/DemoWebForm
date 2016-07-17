using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WN.DataItem;
using WN.ADOService;
using WN.Common;

namespace WN.DataAccess
{
    public class BannerDAO : IBannerDAO
    {
        public object BannerCRUD(BannerItem bannerItem)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[]{};
            string procedureName = string.Empty;
            string returnDatatype = string.Empty;

            if (bannerItem.img_Crud.Equals(Constants.WS_QUERY))
            {
                obj = new object[] { "@P_IMG_ID", bannerItem.img_Id };
                procedureName = "SP_BANNER_RETRIEVE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (bannerItem.img_Crud.Equals(Constants.WS_INSERT))
            {
                obj = new object[] {
                                        "@P_IMG_NAME",  bannerItem.img_Name//,
                                        //"@P_IMG_HEADER",bannerItem.img_Header, 
                                        //"@P_IMG_TEXT",  bannerItem.img_Text
                                    };
                procedureName = "SP_BANNER_CREATE";
                returnDatatype = Constants.STRING;
            }
            else if (bannerItem.img_Crud.Equals(Constants.WS_UPDATE))
            {
                obj = new object[] {
                                        "@P_IMG_ID", bannerItem.img_Id,
                                        "@P_IMG_NAME",  bannerItem.img_Name//,
                                       // "@P_IMG_HEADER",bannerItem.img_Header, 
                                        //"@P_IMG_TEXT",  bannerItem.img_Text
                                    };
                procedureName = "SP_BANNER_UPDATE";
                returnDatatype = Constants.STRING;
            }
            else if (bannerItem.img_Crud.Equals(Constants.WS_DELETE))
            {
                obj = new object[] {"@P_IMG_ID", bannerItem.img_Id};
                procedureName = "SP_BANNER_DELETE";
                returnDatatype = Constants.STRING;
            }

            DataTable dataResult = accessObj.ExecuteDatatable(procedureName, obj);

            if (returnDatatype.Equals(Constants.DATATABLE))
                return dataResult;
            else return dataResult.Rows[0][Constants.ERR_CODE].ToString();
        }
    }     
}
