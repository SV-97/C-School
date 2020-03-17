using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _036_Mathe
{
    class Mathe
    {
        public static int Faculty(int n)
        {
            if (n<0)
            {
                throw new ArgumentException();
            }
            switch (n) {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return n * Faculty(n - 1);
            }
        }

        public static int Summe(params int[] list)
        {
            int val = 0;
            for (int i = 0; i<list.Length; i++)
            {
                val += list[i];
            }
            return val;
        }

        public static int Sum(params int[] list)
        {
            return list.Aggregate(0, (sum, next) => sum+next);
            // return list.Sum();
        }
    }
}
