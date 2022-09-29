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
            int i = 0, j = 0;
            ulong temp_sum = 0;
            while(j < list.Count)
            {
                temp_sum += list[j];
                while (i < j && temp_sum > sum)
                {
                    temp_sum -= list[i];    
                    i++;
                }
                if(temp_sum == sum)
                {
                    start = i;
                    end = j + 1;
                    return;
                }
                j++;
            }
            

        }

        public static void Main(String[] argv)
        {
            int start, end;
            FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 11, out start, out end); //start будет равен 5 и end 7;
            System.Console.WriteLine(start + " " + end);
            FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 0, 0, 0, 6, 7 }, 11, out start, out end); //start будет равен 5 и end 10;
            System.Console.WriteLine(start + " " + end);
            FindElementsForSum(new List<uint> { 4, 5, 6, 7 }, 18, out start, out end); //start будет равен 1 и end 4;
            System.Console.WriteLine(start + " " + end);
            FindElementsForSum(new List<uint> { 4, 36, 5, 6, 7 }, 18, out start, out end); //start будет равен 2 и end 5;
            System.Console.WriteLine(start + " " + end);
            FindElementsForSum(new List<uint> { 4, 36, 6, 7 }, 18, out start, out end); //start будет равен 0 и end 0;
            System.Console.WriteLine(start + " " + end);
            FindElementsForSum(new List<uint> { 4, 5, 6, 7 }, 4, out start, out end); //start будет равен 0 и end 1;
            System.Console.WriteLine(start + " " + end);
            FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 88, out start, out end); //start будет равен 0 и end 0;
            System.Console.WriteLine(start + " " + end);

            var testList = new List<uint>(5000000);

            for(uint i = 0; i < 5000000; ++i)
            {
                testList.Add(1);
            }
            FindElementsForSum(testList, 4999999, out start, out end); //start будет равен 0 и end 4999999;
            System.Console.WriteLine(start + " " + end);
        }
    }
}
