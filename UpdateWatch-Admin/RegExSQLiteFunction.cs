using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace UpdateWatch_Admin
{
    [SQLiteFunction(Name = "REGEXP", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class RegExSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(args[1]), Convert.ToString(args[0]));
        }
    }
}