//=============================================
//Author:           Mahendra Singh Rajpoot
//Created Date:	    18-Jan-2021
//Description:      Data base helper class
//Modified By:      
//Modified Date:    
//Modified Reason: 
//=============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MovieRating.DAL
{
    internal class DbHelper
    {         
        /// <summary>
        /// Static methods only. Hence, making constructor as private.
        /// </summary>
        private DbHelper()
        {
        }

        /// <summary>
        /// Get truncated value from left
        /// </summary>
        /// <param name="stringName"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        internal static string TuncateStringRight(string stringName, int length)
        {
            string retrunString = stringName;
            if (!string.IsNullOrWhiteSpace(stringName))
            {
                if (stringName.Length > length)
                    retrunString = stringName.Substring(stringName.Length - 100);
            }
            return retrunString;
        }
        internal static string TruncateValue(object obj, int length)
        {
            if (obj == DBNull.Value || obj == null)
                return string.Empty;
            else
            {
                string value = (string)obj;
                if (string.IsNullOrWhiteSpace(value))
                    value = value.Trim();
                if (value.Length > length)
                    value = value.Substring(0, length-1);
                return value;
            }
        }
        /// <summary>
        /// Convert object to Data Time. Will return min date value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static DateTime CheckDBDate(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_DATE;
            else
                return Convert.ToDateTime(obj);
        }
        /// <summary>
        /// Convert object to Data Time. Will return null value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static DateTime? CheckDBNullDate(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return Convert.ToDateTime(obj);
        }
        /// <summary>
        /// Convert object to Long. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static long CheckDbLong(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_INT;
            else
                return Convert.ToInt64(obj);
        }
        /// <summary>
        /// Convert object to Long. Will return null of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static long? CheckDbNullLong(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return Convert.ToInt64(obj);
        }
        /// <summary>
        /// Convert object to Decimal. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static decimal CheckDbDecimal(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_DECIMAL;
            else
                return Convert.ToDecimal(obj);
        }
        /// <summary>
        /// Convert object to Decimal. Will return null of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static decimal? CheckDbNullDecimal(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return Convert.ToDecimal(obj);
        }      
        /// <summary>
        /// Convert object to Double. Will return null value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static double? CheckDbNullDouble(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return Convert.ToDouble(obj);
        }
        /// <summary>
        /// Convert object to Double. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static double CheckDbDouble(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_DOUBLE;
            else
                return Convert.ToDouble(obj);
        }
        /// <summary>
        /// Convert object to Int. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static int CheckDbInt(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_INT;
            else
                return Convert.ToInt32(obj);
        }
        /// <summary>
        /// Convert object to Decimal. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static int? CheckDbNullInt(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return Convert.ToInt32(obj);
        }
        /// <summary>
        /// Convert object to String. Will return empty value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string CheckDbNullString(object obj)
        {
            string value = string.Empty;

            if (obj == DBNull.Value || obj == null)
                value = string.Empty;
            else
                value = (string)obj;

            if (!string.IsNullOrWhiteSpace(value))
                value = value.Trim();

            return value;
        }
       
        /// <summary>
        /// Convert object to Short. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static short CheckDbShort(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_SHORT;
            else
                return (short)obj;
        }
        /// Convert object to Short. Will return null value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static short? CheckDbNullShort(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return (short)obj;
        }
        /// <summary>
        /// Convert object to Float. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static float CheckDbFloat(object obj)
        {
            float returnResult;
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_FLOAT;
            else
            {
                float.TryParse(Convert.ToString(obj), out returnResult);
                return returnResult;
            }
        }
        /// <summary>
        /// Convert object to Float. Will return null value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static float? CheckDbNullFloat(object obj)
        {
            float returnResult;
            if (obj == DBNull.Value || obj == null)
                return null;
            else
            {
                float.TryParse(Convert.ToString(obj), out returnResult);
                return returnResult;
            }
        }
        /// <summary>
        /// Convert object to Bool. Will return false of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static bool CheckDbBool(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_BOOL;
            else
                return (bool)obj;
        }

       /// <summary>
        /// Convert object to Bool. Will return null of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static bool? CheckDbNullBool(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return (bool)obj;
        }
        /// <summary>
        /// Convert object to Byte. Will return null value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static byte? DbNullByte(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return (byte)obj;
        }
        internal static byte[] DbByteArrary(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return (byte[])obj;
        }
        /// <summary>
        /// Replace string space with hyphen
        /// </summary>
        /// <param name="stringName"></param>
        /// <returns></returns>
        internal static string ReplaceStringSpaceWithHyphen(string stringName)
        {
            string retrunString = string.Empty;
            if (!string.IsNullOrWhiteSpace(stringName))
                retrunString = Regex.Replace(stringName.Trim(), @"\s+", "-").ToLower();

            return retrunString;
        }

        /// <summary>
        /// Replace all special characters with hyphen
        /// </summary>
        /// <param name="stringName"></param>
        /// <returns></returns>
        internal static string GetUniqueName(string strName)
        {
            if (!string.IsNullOrWhiteSpace(strName))
            {
                strName = Regex.Replace(strName.Trim(), " ", "-").ToLower();
                strName = Regex.Replace(strName.Trim(), @"\$", "-");
                strName = Regex.Replace(strName.Trim(), "~", "-");
                strName = Regex.Replace(strName.Trim(), "`", "-");
                strName = Regex.Replace(strName.Trim(), "@", "-");
                strName = Regex.Replace(strName.Trim(), "#", "-");
                strName = Regex.Replace(strName.Trim(), "%", "-");
                strName = Regex.Replace(strName.Trim(), @"\^", "-");
                strName = Regex.Replace(strName.Trim(), "&", "-");
                strName = Regex.Replace(strName.Trim(), @"\*", "-");
                strName = Regex.Replace(strName.Trim(), @"\(", "-");
                strName = Regex.Replace(strName.Trim(), @"\)", "-");
                strName = Regex.Replace(strName.Trim(), "_", "-");
                strName = Regex.Replace(strName.Trim(), "=", "-");
                strName = Regex.Replace(strName.Trim(), @"\+", "-");
                strName = Regex.Replace(strName.Trim(), @"\|", "-");
                strName = Regex.Replace(strName.Trim(), "\"", "-");
                strName = Regex.Replace(strName.Trim(), "/", "-");
                strName = Regex.Replace(strName.Trim(), @"\?", "-");
                strName = Regex.Replace(strName.Trim(), ">", "-");
                strName = Regex.Replace(strName.Trim(), "<", "-");
                strName = Regex.Replace(strName.Trim(), "{", "-");
                strName = Regex.Replace(strName.Trim(), "}", "-");
                strName = Regex.Replace(strName.Trim(), @"\[", "-");
                strName = Regex.Replace(strName.Trim(), @"\]", "-");
                strName = Regex.Replace(strName.Trim(), "-", "-");
            }
            return strName;
        }

        /// <summary>
        /// Convert object to Int64. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static Int64 CheckDbInt64(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return Constants.DBcodeValues.NULL_INT_64;
            else
                return Convert.ToInt64(obj);
        }
        /// <summary>
        /// Convert object to Int64. Will return min value of object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static Int64? CheckDbNullInt64(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return Convert.ToInt64(obj);
        }

        internal static char? CheckDbChar(object obj)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return null;
            } else
                return Convert.ToChar(obj);
        }
    }
}
