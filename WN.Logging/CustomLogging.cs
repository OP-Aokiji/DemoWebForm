using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;

namespace WN.Logging
{
    public class CustomLogging : BaseLogging
    {
        public override void Trace(string traceType, string procedureName, DateTime startTime, DateTime endTime, params object[] parList)
        {
            string paramList = string.Empty;
            if (parList.Length > 0)
            {
                for (int i = 0; i < parList.Length; i += 2)
                {
                    paramList += parList[i].ToString() + " = " + parList[i + 1].ToString() + ", ";
                }
                paramList = paramList.Substring(0, paramList.Length - 2);
            }
            else
            {
                paramList = "No parameter(s)";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n#------------------------------------------------#\n");
            stringBuilder.Append("[Request Time     : " + startTime + "]\n");
            stringBuilder.Append("[" + traceType + " Name   : " + procedureName + "]\n");
            stringBuilder.Append("[Parameter List   : " + paramList + "]\n");

            if (traceType.Equals("PROCEDURE"))
            {
                if (parList.Length > 0)
                    stringBuilder.Append("[Query string     : Exec DBO." + procedureName + " " + paramList + "]\n");
                else
                    stringBuilder.Append("[Query string     : Exec DBO." + procedureName + "]\n");
            }
            else if (traceType.Equals("FUNCTION"))
            {
                if (parList.Length > 0)
                   stringBuilder.Append("[Query string      : SELECT DBO." + procedureName + "(" + paramList + ")]\n");
                else
                    stringBuilder.Append("[Query string     : SELECT DBO." + procedureName + "()]\n");
            }

            stringBuilder.Append("[Runnig Time      : " + endTime.Subtract(startTime) + "]\n");
            stringBuilder.Append("#------------------------------------------------#\n");
            System.Diagnostics.Debug.WriteLine(stringBuilder.ToString());

        }
        public override void Trace(string message)
        {
            Console.WriteLine("\n#------------------------------------------------#\n");
            Console.WriteLine("[" + DateTime.Now.ToString("dd/MM/yyy HH:hh:ss") + "]:" );
            Console.WriteLine(message);
            Console.WriteLine("\n#------------------------------------------------#\n");
        }
        public override void Trace(Hashtable hashtable)
        {
            if (hashtable.Count <= 0)
                return;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n#------------------------------------------------#\n");
            stringBuilder.Append("[" + DateTime.Now.ToString("dd/MM/yyy HH:hh:ss") + "] ");
            foreach (DictionaryEntry dictionaryEntry in hashtable)
            {
                stringBuilder.Append(dictionaryEntry.Key + ": " + dictionaryEntry.Value);
            }
            stringBuilder.Append("\n#------------------------------------------------#\n");
            System.Diagnostics.Debug.WriteLine(stringBuilder.ToString());

        }
        public override void Trace(DataTable dataTable)
        {
            int rowCount = dataTable.Rows.Count;
            int colCount = dataTable.Columns.Count;
            StringBuilder stringBuilder = new StringBuilder();
            // Header
            stringBuilder.Append("\n#------------------------------------------------#\n");
            stringBuilder.Append("[" + DateTime.Now.ToString("dd/MM/yyy HH:hh:ss") + "]");
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                string item = dataTable.Columns[i].ToString();
                stringBuilder.Append(String.Format("{0,-20} | ", item));
            }
            stringBuilder.Append(Environment.NewLine);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                stringBuilder.Append("---------------------|-");
            }
            stringBuilder.Append(Environment.NewLine);

            // Data
            for (int i = 0; i < rowCount; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                for (int j = 0; j < colCount; j++)
                {
                    string item = dataRow[j].ToString();
                    if (item.Length > 20) item = item.Substring(0, 17) + "...";
                    stringBuilder.Append(String.Format("{0,-20} | ", item));
                }
                stringBuilder.Append(Environment.NewLine);
            }
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                stringBuilder.Append("---------------------|-");
            }
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("\n#------------------------------------------------#\n");
            System.Diagnostics.Debug.WriteLine(stringBuilder.ToString());
            
        }
    }
}
