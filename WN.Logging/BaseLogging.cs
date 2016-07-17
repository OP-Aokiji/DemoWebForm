using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace WN.Logging
{
    public abstract class BaseLogging
    {
       public abstract void Trace(string traceType, string procedureName, DateTime startTime, DateTime endTime, params object[] parList);
       public abstract void Trace(string message);
       public abstract void Trace(Hashtable hashtable);
       public abstract void Trace(DataTable datatable);
    }
}
