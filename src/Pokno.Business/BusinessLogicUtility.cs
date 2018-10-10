using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokno.Business
{
    public class BusinessLogicUtility
    {
        //public static DateTime GetDate()
        //{
        //    DateTime date = new DateTime(2014, 09, 07);
        //    return date;

        //}

        public static string DateFormat = "yyyy-MM-dd";
        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public static string PaddNumber(long id, int maxCount)
        {
            try
            {
                string paddNumbers = "";
                string idInString = id.ToString();

                if (idInString.Count() < maxCount)
                {
                    int zeroCount = maxCount - id.ToString().Count();
                    StringBuilder builder = new StringBuilder();
                    for (int counter = 0; counter < zeroCount; counter++)
                    {
                        builder.Append("0");
                    }

                    builder.Append(id);
                    paddNumbers = builder.ToString();

                    return paddNumbers;
                }

                return paddNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetMonthString(int month)
        {
            try
            {
                string currentMonth = month.ToString();
                currentMonth = currentMonth.Length == 1 ? currentMonth = "0" + currentMonth : currentMonth;
                return currentMonth;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    
}
