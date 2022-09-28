using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSum
{
    internal class MainClass
    {
        static void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {
            start = 0;
            end = 0;
            List<ulong> remainder = new List<ulong>(list.Count);
            remainder.Add(list[0] % sum);
            HashSet<ulong> set = new HashSet<ulong>();
            if (list[0] != 0)
            {
                set.Add(remainder[0]);
            }
            ulong? ost = null;
            for (int i = 1; i < list.Count() && ost == null; ++i)
            {
                remainder.Add(list[i] == 0 ? sum : (remainder[i - 1] +  list[i] % sum) % sum);
                if (set.Contains(remainder[i]))
                {
                    ost = remainder[i];
                }
                else if (remainder[i] != sum)
                {
                    set.Add(remainder[i]);
                }
            }
            if(ost != null)
            {
                for(int i = 0; i < list.Count && end == 0; ++i)
                {
                    if (remainder[i] == ost){
                        if(start == 0)
                        {
                            start = i + 1;
                        }
                        else
                        {
                            end = i + 1;
                        }
                    }
                }
            }

        }

        public static void Main(String[] argv)
        {
            int start, end;
            FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 11, out start, out end); //start будет равен 5 и end 7;
            System.Console.WriteLine(start + " " + end);
            FindElementsForSum(new List<uint> { 4, 5, 6, 7 }, 18, out start, out end); //start будет равен 1 и end 4;
            System.Console.WriteLine(start + " " + end);
            FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 88, out start, out end); //start будет равен 0 и end 0;
            System.Console.WriteLine(start + " " + end);
        }
    }
}
