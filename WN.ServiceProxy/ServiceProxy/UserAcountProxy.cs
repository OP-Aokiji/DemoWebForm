using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataAccess;
using WN.DataItem;
using System.Data;

namespace WN.ServiceProxy
{
    public class UserAcountProxy : IUserAcountProxy
    {
        public object UserAcountCRUD(UserAcountItem userAcountItem)
        {
            IUserAcountDAO userAcountDao = new UserAcountDAO();
            return userAcountDao.UserAcountCRUD(userAcountItem);
        }

        public DataTable UserAcountChangePassword(UserAcountItem userAcountItem, string newPassword)
        {
            IUserAcountDAO userAcountDao = new UserAcountDAO();
            return userAcountDao.UserAcountChangePassword(userAcountItem,newPassword);
        }

       
    }
}