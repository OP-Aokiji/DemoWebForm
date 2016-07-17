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
    public class UserAcountDAO : IUserAcountDAO
    {
        public object UserAcountCRUD(UserAcountItem userAcountItem)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[] { };
            string procedureName = string.Empty;
            string returnDatatype = string.Empty;

            if (userAcountItem.user_Ws.Equals(Constants.WS_QUERY))
            {
                obj = new object[] { "@P_USER_ID", userAcountItem.user_Id };
                procedureName = "SP_USER_ACOUNT_RETRIEVE";
                returnDatatype = Constants.DATATABLE;
            }
            else if (userAcountItem.user_Ws.Equals(Constants.WS_INSERT))
            {
                obj = new object[] {    "@P_USER_NAME", userAcountItem.user_Name,
                                        "@P_USER_PASSWORD",   userAcountItem.user_Password,
                                        "@P_USER_FULLNAME",  userAcountItem.user_fullname
                                        //"@P_USER_EMAIL",     userAcountItem.user_Email, 
                                    };
                procedureName = "SP_USER_ACOUNT_CREATE";
                returnDatatype = Constants.STRING;
            }
            else if (userAcountItem.user_Ws.Equals(Constants.WS_UPDATE))
            {
                obj = new object[] {    "@P_USER_ID",userAcountItem.user_Id,
                                        "@P_USER_FULLNAME",  userAcountItem.user_fullname
                                        //"@P_USER_EMAIL",     userAcountItem.user_Email, 
                                    };
                procedureName = "SP_USER_ACOUNT_UPDATE";
                returnDatatype = Constants.STRING;
            }
            else if (userAcountItem.user_Ws.Equals(Constants.WS_DELETE))
            {
                obj = new object[] { "@P_USER_ID", userAcountItem.user_Id };
                procedureName = "SP_USER_ACOUNT_DELETE";
            }
            else if (userAcountItem.user_Ws.Equals(Constants.WS_LOGIN))
            {
                obj = new object[] { 
                                        "@P_USER_NAME", userAcountItem.user_Name,
                                        "@P_USER_PASSWORD",   userAcountItem.user_Password
                                    };
                procedureName = "SP_USER_ACOUNT_LOGIN";
                returnDatatype = Constants.DATATABLE;
            }
           
            DataTable dataResult = accessObj.ExecuteDatatable(procedureName, obj);

            if (returnDatatype.Equals(Constants.DATATABLE))
                return dataResult;
            else return dataResult.Rows[0][Constants.ERR_CODE].ToString();
        }
        public DataTable UserAcountChangePassword(UserAcountItem userAcountItem, string newPassword)
        {
            IDataAccessObject accessObj = new DataAccessObject();
            object[] obj = new object[] {
                                            "@P_USER_NAME",     userAcountItem.user_Name,      
                                            "@P_USER_PASSWORD", userAcountItem.user_Password, 
                                            "@P_NEW_PASSWORD",  newPassword
                                        };
            return (DataTable)accessObj.ExecuteDatatable("SP_USER_ACOUNT_UPDATE_PASSWORD", obj);
        }
    }
}