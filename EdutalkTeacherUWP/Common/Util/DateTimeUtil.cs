using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Common.Util
{
    public class DateTimeUtil
    {
        public static (int, int)[] GetAllMonths(int startMonth, int startY)
        {
            var endM = DateTime.Now.Month;
            var endY = DateTime.Now.Year;

            var list = new List<(int, int)>();
            for (int i = startY; i <= endY; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (i == startY && j < startMonth)
                    {
                        continue;
                    }
                    if (i == endY && j > endM)
                    {
                        return list.ToArray();
                    }
                    list.Add((i, j));
                }
            }
            return list.ToArray();
        }
    }
}
