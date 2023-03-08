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

        public static void CreateUnDublicateList(List<int> input)
        {
            int[] result = new int[input.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }
            int tmpIndex = 0;
            int innerLoopLength;

            for (int i = 0; i < input.Count; i++)
            {
                innerLoopLength = tmpIndex;
                for (int j = 0; j < innerLoopLength + 1; j++)
                {
                    if (result[j] == input[i])
                    {
                        break;
                    }
                    else if (j == tmpIndex)
                    {
                        result[tmpIndex] = input[i];
                        tmpIndex++;
                    }
                }
            }
        }

        public static void CreateUnDublicateList2(List<int> input)
        {
           input.ToHashSet().ToArray();
        }

        public static void CreateUnDublicateList3(List<int> input)
        {
            int[] result = new int[input.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = input[0];
            }
            int foundElements = 1;
            for (int i = 1; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (input[i] == result[j])
                    {
                        break;
                    }
                    else if(j == foundElements-1)
                    {
                        
                    }
                }
            }
        }

    }
}
