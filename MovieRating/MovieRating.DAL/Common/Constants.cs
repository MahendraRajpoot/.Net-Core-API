//=============================================
//Author:           Mahendra Singh Rajpoot
//Created Date:	    18-Jan-2021
//Description:      Declare data base constants
//Modified By:      
//Modified Date:    
//Modified Reason: 
//=============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRating.DAL
{
    public struct Constants
    {
        public struct DBcodeValues
        {
            /// <summary>
            /// Default value for DB NULL Integer
            /// </summary>
            public static int NULL_INT = Convert.ToInt16("0");
            /// <summary>
            /// Default value for DB NULL Date
            /// </summary>
            public static DateTime NULL_DATE = DateTime.MinValue;
            /// <summary>
            /// Default value for DB NULL Double
            /// </summary>
            public static double NULL_DOUBLE = Convert.ToDouble("0");
            /// <summary>
            /// Default value for DB NULL Bool
            /// </summary>
            public static bool NULL_BOOL = false;
            /// <summary>
            /// Default value for DB NULL Float
            /// </summary>
            public static float NULL_FLOAT = (float)Convert.ToDouble("0");
            /// <summary>
            /// Default value for DB NULL Short
            /// </summary>
            public static short NULL_SHORT = Convert.ToInt16("0");
            /// <summary>
            /// Default value for DB NULL Decimal
            /// </summary>
            public static decimal NULL_DECIMAL = Convert.ToDecimal("0");
            /// <summary>
            public static Int64 NULL_INT_64 = Convert.ToInt64("0");
        }      

    }
}
