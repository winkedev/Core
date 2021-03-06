﻿using System;
using System.Data;
using System.Data.Common;

namespace Br.Com.SPI.Core.Extensions
{
    public static class Parse
    {
        public static Int64 ParseToInt64(this DataRow row, string name)
        {
            try
            {
                return Int64.TryParse(row[name]?.ToString(), out Int64 result) ? result : default;
            }
            catch
            {
                return default;
            }
        }

        public static Int32 ParseToInt(this DataRow row, string name)
        {
            try
            {
                return Int32.TryParse(row[name]?.ToString(), out Int32 result) ? result : default;
            }
            catch
            {
                return default;
            }
        }

        public static decimal ParseToDecimal(this DataRow row, string name)
        {
            try
            {
                return decimal.TryParse(row[name]?.ToString(), out decimal result) ? result : default;
            }
            catch
            {
                return default;
            }
        }

        public static DateTime ParseToDatetime(this DataRow row, string name)
        {
            try
            {
                return DateTime.TryParse(row[name]?.ToString(), out DateTime result) ? result : default;
            }
            catch
            {
                return default;
            }
        }

        public static String ParseToString(this DataRow row, string name)
        {
            try
            {
                return row[name]?.ToString() ?? default;
            }
            catch
            {
                return default;
            }
            
        }
    }
}
