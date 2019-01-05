using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterSQL
{
    class Utilities
    {
        public static string ToSQLDateFormat(string data)
        {
            /* Required format: YYYY-MM-DD HH:MM:SS */
            string output = "";
            DateTime rawDateTime;
            try
            {
                rawDateTime = Convert.ToDateTime(data);
            }
            catch (System.FormatException)
            {
                /* Return 1-1-1T0:0:0 in case of unrecognized format */
                rawDateTime = new DateTime(0);
            }

            /* Form proper date */
            output += rawDateTime.Year   + "-";

            if (rawDateTime.Month < 10)
            {
                output += "0";
            }
            output += rawDateTime.Month  + "-";

            if (rawDateTime.Day < 10)
            {
                output += "0";
            }
            output += rawDateTime.Day    + " ";

            if (rawDateTime.Hour < 10)
            {
                output += "0";
            }
            output += rawDateTime.Hour   + ":";

            if (rawDateTime.Minute < 10)
            {
                output += "0";
            }
            output += rawDateTime.Minute + ":";

            if (rawDateTime.Second < 10)
            {
                output += "0";
            }
            output += rawDateTime.Second;

            return output;
        }
    }
}
