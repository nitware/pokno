using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokno.Business.Helper
{
    public class Range
    {
        public static DateTime Get(DateRange range, DateTime supplyDate)
        {
            try
            {
                DateTime date = DateTime.MinValue;

                switch (range)
                {
                    case DateRange.Start:
                        {
                            date = new DateTime(supplyDate.Year, supplyDate.Month, supplyDate.Day, 0, 0, 0);
                            break;
                        }
                    case DateRange.End:
                        {
                            date = new DateTime(supplyDate.Year, supplyDate.Month, supplyDate.Day, 23, 59, 59);
                            break;
                        }
                }

                return date;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
