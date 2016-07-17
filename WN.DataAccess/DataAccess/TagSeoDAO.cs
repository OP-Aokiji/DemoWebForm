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
    public class TagSeoDAO : ITagSeoDAO
    {
        public object TagSeoCRUD(TagSeoItem tagSeoItem)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[]{};
            string procedureName = string.Empty;
            string returnDatatype = string.Empty;

            if (tagSeoItem.tag_Seo_Ws.Equals(Constants.WS_QUERY))
            {
                obj = new object[] { "@P_TAG_ID", tagSeoItem.tag_Seo_Id };
                procedureName = "SP_TAG_SEO_RETRIEVE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (tagSeoItem.tag_Seo_Ws.Equals(Constants.WS_INSERT))
            {
                obj = new object[] {
                                        "@P_TAG_NAME",  tagSeoItem.tag_Seo_Name,
                                        "@P_TAG_URL",tagSeoItem.tag_Seo_Url
                                    };
                procedureName = "SP_TAG_SEO_CREATE";
                returnDatatype = Constants.STRING;
            }
            else if (tagSeoItem.tag_Seo_Ws.Equals(Constants.WS_UPDATE))
            {
                obj = new object[] {
                                        "@P_TAG_ID",tagSeoItem.tag_Seo_Id ,
                                        "@P_TAG_NAME",  tagSeoItem.tag_Seo_Name,
                                        "@P_TAG_URL",tagSeoItem.tag_Seo_Url
                                    };
                procedureName = "SP_TAG_SEO_UPDATE";
                returnDatatype = Constants.STRING;
            }
            else if (tagSeoItem.tag_Seo_Ws.Equals(Constants.WS_DELETE))
            {
                obj = new object[] { "@P_TAG_ID", tagSeoItem.tag_Seo_Id };
                procedureName = "SP_TAG_SEO_DELETE";
                returnDatatype = Constants.STRING;
            }

            DataTable dataResult = accessObj.ExecuteDatatable(procedureName, obj);

            if (returnDatatype.Equals(Constants.DATATABLE))
                return dataResult;
            else return dataResult.Rows[0][Constants.ERR_CODE].ToString();
        }
    }
}