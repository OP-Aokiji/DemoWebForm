using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace WN.ADOService
{
    public class DataAccessObject:IDataAccessObject
    {
        //BaseLogging logging;
        DataContext dataContext;
        public String GetConnectInfo()
        {
            return ConfigurationManager.ConnectionStrings["eyeVinaConnectInfo"].ConnectionString;
        }
        public DataContext DataClass()
        {
            try
            {
                string connectionString = GetConnectInfo();
                DataContext dataContext = new DataContext(connectionString);
                return dataContext;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckConnect()
        {
            try
            {
                dataContext = DataClass();
                if (dataContext.Connection.State == ConnectionState.Closed)
                    dataContext.Connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataSet ExecuteDataSet(string procedureName, params object[] parList)
        {
            DataSet dataSet = new DataSet();
            if (CheckConnect())
            {
                //DateTime startTime = DateTime.Now;
                using (DbCommand dbCommand = dataContext.Connection.CreateCommand())
                {
                    dbCommand.CommandText = procedureName;
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < parList.Length; i += 2)
                    {
                        DbParameter dbParameter = new SqlParameter(parList[i].ToString(), parList[i + 1]);
                        dbCommand.Parameters.Add(dbParameter);
                    }
                    new SqlDataAdapter((SqlCommand)dbCommand).Fill(dataSet);
                 
                    //DateTime endTime = DateTime.Now;
                    //logging = new CustomLogging();
                    //logging.Trace("PROCEDURE", procedureName, startTime, endTime, parList);
                    return dataSet;
                }
            }
            return dataSet;
        }
        public DataTable ExecuteDatatable(string procedureName, params object[] parList)
        {
            DataSet dataSet = new DataSet();
            if (CheckConnect())
            {
                //DateTime startTime = DateTime.Now;
                using (DbCommand dbCommand = dataContext.Connection.CreateCommand())
                {
                    dbCommand.CommandText = procedureName;
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < parList.Length; i += 2)
                    {
                        DbParameter dbParameter = new SqlParameter(parList[i].ToString(), parList[i + 1]);
                        dbCommand.Parameters.Add(dbParameter);
                    }
                    new SqlDataAdapter((SqlCommand)dbCommand).Fill(dataSet);



                    //DateTime endTime = DateTime.Now;
                    //logging = new CustomLogging();
                    //logging.Trace("PROCEDURE", procedureName, startTime, endTime, parList);
                }
            }
            return dataSet.Tables[0];
        }
        public object ExecuteNonQuery(string procedureName, params object[] parList)
        {
            object obj = new object();
            if (CheckConnect())
            {
                //DateTime startTime = DateTime.Now;
                using (DbCommand dbCommand = dataContext.Connection.CreateCommand())
                {
                    dbCommand.CommandText = procedureName;
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < parList.Length; i += 2)
                    {
                        DbParameter dbParameter = dbCommand.CreateParameter();
                        dbParameter.ParameterName = parList[i].ToString();
                        dbParameter.Value = parList[i + 1];
                        dbCommand.Parameters.Add(dbParameter);
                    }
                    obj = (object)dbCommand.ExecuteNonQuery();
                   

                    //DateTime endTime = DateTime.Now;
                    //logging = new CustomLogging();
                    //logging.Trace("PROCEDURE", procedureName, startTime, endTime, parList);
                }
            }
            return obj;
        }
        public object ExcuteFunction(string functionName, params object[] parList)
        {
            SqlParameter sqlParameter = new SqlParameter("@GlobalSiteType", SqlDbType.NVarChar);
            if (CheckConnect())
            {
                //DateTime startTime = DateTime.Now;
                using (DbCommand dbCommand = dataContext.Connection.CreateCommand())
                {
                    dbCommand.CommandText = functionName;
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < parList.Length; i += 2)
                    {

                        DbParameter dbParameter = dbCommand.CreateParameter();
                        dbParameter.ParameterName = parList[i].ToString();
                        dbParameter.Value = parList[i + 1];
                        dbCommand.Parameters.Add(dbParameter);
                    }
                    sqlParameter.Direction = ParameterDirection.ReturnValue;
                    dbCommand.Parameters.Add(sqlParameter);
                    dbCommand.ExecuteNonQuery();

                    //DateTime endTime = DateTime.Now;
                    //logging = new CustomLogging();
                    //logging.Trace("FUNCTION", functionName, startTime, endTime, parList);
                }
            }
            return (object)sqlParameter.Value;
        }

    }
}
