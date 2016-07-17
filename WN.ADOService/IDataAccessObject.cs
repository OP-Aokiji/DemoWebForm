using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;

namespace WN.ADOService
{
    public interface IDataAccessObject
    {
        String GetConnectInfo();
        DataContext DataClass();
        DataSet ExecuteDataSet(string procedureName, params object[] parList);
        DataTable ExecuteDatatable(string procedureName, params object[] parList);
        object ExecuteNonQuery(string procedureName, params object[] parList);
        object ExcuteFunction(string functionName, params object[] parList);
    }
}
