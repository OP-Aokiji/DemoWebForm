using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WN.DataItem;
using System.Data;

namespace WN.DataAccess
{
    public interface IUserAcountDAO
    {
        object UserAcountCRUD(UserAcountItem userAcountItem);
        DataTable UserAcountChangePassword(UserAcountItem userAcountItem, string newPassword);
    }
}