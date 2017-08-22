using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.Helpers
{
    public class StringUtils
    {

        public static int ParseIntValue(string value)
        {
            if(value == null)
            {
                return -1;
            }

            if (int.TryParse(value, out int intValue))
            {
                return intValue;
            }
            return -1;
        }

        public static double ParseDoubleValue(string value)
        {
            if (value == null)
            {
                return -1D;
            }

            if (double.TryParse(value, out double doubleValue))
            {
                return doubleValue;
            }
            return -1D;
        }

        public static bool ParseWhooingBooleanValue(string value)
        {
            if (value == null)
            {
                return false;
            }

            if (value == "Y"||
                value == "y")
            {
                return true;
            }
            return false;
        }
    }
}
