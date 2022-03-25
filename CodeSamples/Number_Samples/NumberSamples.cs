using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Number_Samples
{
    public static class NumberSamples
    {
        public static float FindSquareRoot(int number)
        {
            float precision = 0.01f;
            float min = 0;
            float max = number;
            float result = 0;

            int countOfIteration = 0;
            while (max - min > precision)
            {
                result = (min + max) / 2;
                if ((result * result) >= number)
                {
                    max = result;
                }
                else
                {
                    min = result;
                }
                countOfIteration++;
            }
            Console.WriteLine($"It took {countOfIteration} iterations to find the result");
            int roundedResult = (int) Math.Round(result);
            return roundedResult * roundedResult == number ? roundedResult : result ;
        }
    }
}
