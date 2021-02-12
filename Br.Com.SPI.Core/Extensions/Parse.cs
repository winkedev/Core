using System;
using System.Data.Common;

namespace Br.Com.SPI.Core.Extensions
{
    public static class Parse
    {
        public static Int64 ParseToInt64(this DbDataReader row, string name)
        {
            return Int64.TryParse(row[name].ToString(), out Int64 result) ? result : throw new Exception($"Can't convert {name} into Int64");
        }

        public static Int32 ParseToInt(this DbDataReader row, string name)
        {
            return Int32.TryParse(row[name].ToString(), out Int32 result) ? result : throw new Exception($"Can't convert {name} into Int32");
        }

        public static decimal ParseToDecimal(this DbDataReader row, string name)
        {
            return decimal.TryParse(row[name].ToString(), out decimal result) ? result : throw new Exception($"Can't convert {name} into decimal");
        }

        public static DateTime ParseToDatetime(this DbDataReader row, string name)
        {
            return DateTime.TryParse(row[name].ToString(), out DateTime result) ? result : throw new Exception($"Can't convert {name} into DateTime");
        }

        public static String ParseToString(this DbDataReader row, string name)
        {
            return row[name].ToString();
        }
    }
}
