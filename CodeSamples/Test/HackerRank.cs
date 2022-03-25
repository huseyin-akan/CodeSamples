using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Test
{
    public static class HackerRank
    {
        public static int theLoveLetterMystery(string s)
        {
            int result = 0;

            while (s.Length>1)
            {
                char firstChar = s[0];
                char lastChar = s[s.Length - 1];

                //if the first and last chars are not same then we modify them
                if (!firstChar.Equals(lastChar))
                {                    
                    result += Math.Abs((int)firstChar - (int)lastChar);
                }
                //we remove the first and last letters
                s = s.Substring(1, s.Length - 2);
            }

            return result;
        }

        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            var result = 0;

            //if delivery is done on time
            if(y1 < y2 || (y1 == y2 && m1<m2) || (y1 == y2 && m1==m2 && d1<=d2) )
            {
                return result;
            }
            //if delivery is done same month but late
            else if(y1 == y2 && m1 == m2 && d1>d2){
                return (d1 - d2) * 15;
            }
            //if delivery is done same year but another month
            else if(y1 == y2 && m1 > m2)
            {
                return (m1 - m2) * 500;
            }
            //if delivery is done after the calendar year
            else if (y1 > y2)
            {
                return 10000;
            }
            return -1;
        }

        public static int workbook(int n, int k, List<int> questionsOfChapters)
        {
            var result = 0;
            var page = 1;
            var tmp = 0;

            foreach (var questions in questionsOfChapters)
            {
                for (int i = 1; i <= questions; i++)
                {
                    if(tmp == k)
                    {
                        page++;
                        tmp = 0;
                    }

                    if (i == page)
                    {
                        result++;
                    }
                    tmp++;
                }
                page++;
                tmp = 0;
            }  
            return result;
        }

        public static int minimumDistances(List<int> a)
        {
            var result = int.MaxValue;

            for (int i = 0; i < a.Count-1; i++)
            {
                for (int j = i+1; j < a.Count; j++)
                {
                    if(a[i] == a[j] && (j-i)<result) 
                    {
                        result = j - i;
                        break;
                    }
                }
            }

            return result == int.MaxValue ? -1 : result;
        }

        public static List<int> cutTheSticks(List<int> arr)
        {
            List<int> result = new List<int>();

            while (arr.Count > 0)
            {
                result.Add(arr.Count);

                //find the smallest value
                var smallest = arr.Min();

                //cut the pieces and if zero remove from the array
                for (int i = 0; i < arr.Count; i++)
                {
                    arr[i] -= smallest;
                    if (arr[i] == 0)
                    {
                        arr.RemoveAt(i);
                        i--;
                    }
                }
            }

            return result;
        }

        

        public static long taumBday(int b, int w, int bc, int wc, int z)
        {
            long result = 0;
            Product cheaperProduct = new Product();
            Product expensiveProduct = new Product();

            if (bc < wc)
            {
                cheaperProduct.Count = b;
                cheaperProduct.Price = bc;
                expensiveProduct.Count = w;
                expensiveProduct.Price = wc;
            }
            else
            {
                cheaperProduct.Count = w;
                cheaperProduct.Price = wc;
                expensiveProduct.Count = b;
                expensiveProduct.Price = bc;
            }

            //if it is better to buy cheaper and convert
            if (cheaperProduct.Price + z < expensiveProduct.Price)
            {
                result += (cheaperProduct.Price + z) * expensiveProduct.Count;
            }
            else
            {
                result += expensiveProduct.Price * expensiveProduct.Count;
            }

            //in any case we should buy the cheaper also
            result += cheaperProduct.Count * cheaperProduct.Price;
            return result;
        }

        public static long repeatedString(string s, long n)
        {
            long result = 0;
            long fullCountOfS = n / s.Length;
            int divisionCountOfS = Convert.ToInt32(n % s.Length);
            int countOfAInFullS = s.Count(c => c.Equals('a'));
            int countOfAInSubStringS = s.Substring(0, divisionCountOfS)
        .Count(c => c.Equals('a'));

            result += countOfAInFullS * fullCountOfS;
            result += countOfAInSubStringS;

            return result;
        }

        public static int jumpingOnClouds(List<int> c)
        {
            int i = 0;  //current cloud
            int result = 0;

            while (i < c.Count - 1)
            {
                //This happens when we are just one step away from the finish
                if(i+2 >= c.Count)
                {
                    result++;
                    i++;
                    break;
                }
                //try jumping two steps
                if (c[i + 2] != 1)
                {
                    result++;
                    i += 2;
                }
                //if we cant jump two steps then we have to jump one step
                else
                {
                    result++;
                    i++;
                }
            }

            return result;
        }

        public static int squares(int a, int b)
        {
            var count = 0;
            int tmp = 0;

            //find the first square number
            for (int i = a; i <= b; i++)
            {
                float precision = 0.01f;
                float min = 0;
                float max = i;
                float result = 0;

                while (max - min > precision)
                {
                    result = (min + max) / 2;
                    if ((result * result) >= i)
                    {
                        max = result;
                    }
                    else
                    {
                        min = result;
                    }
                }
                int roundedResult = (int)Math.Round(result);
                
                if (roundedResult * roundedResult == i) {
                    count++;
                    tmp = roundedResult + 1;
                    break;
                }   
            }
            while (tmp * tmp <= b && tmp>0)
            {
                count++;
                tmp++;
            }

            return count;
        }

        public static int camelcase(string wordToCheck)
        {
            int count = 0;

            foreach (var charToCheck in wordToCheck)
            {
                if ((int) charToCheck >= 65 && (int) charToCheck <= 90 )
                {
                    count++;
                }
            }

            return count+1;
        }
        public static int chocolateFeast(int n, int c, int m)
        {
            int countOfWrappers = 0;
            countOfWrappers = n / c;
            int chocos = countOfWrappers;
            while (countOfWrappers >= m)
            {
                countOfWrappers = countOfWrappers - m;
                countOfWrappers++;
                chocos++;
            }
            return chocos;
        }

        public static List<string> cavityMap(List<string> grid)
        {
            var result = new List<string>(grid);

            for (int i = 1; i < grid.Count - 1; i++)
            {
                //we only check cells which are located not on borders
                for (int j = 1; j < grid.Count-1; j++)
                {
                    var charToCheck = Convert.ToInt32(grid[i][j].ToString());
                    var leftAdjacent = Convert.ToInt32(grid[i][j - 1].ToString());
                    var rightAdjacent = Convert.ToInt32(grid[i][j + 1].ToString());
                    var upperAdjacent = Convert.ToInt32(grid[i - 1][j].ToString());
                    var lowerAdjacent = Convert.ToInt32(grid[i + 1][j].ToString());

                    if(charToCheck > leftAdjacent && 
                        charToCheck > rightAdjacent && 
                        charToCheck > upperAdjacent && 
                        charToCheck > lowerAdjacent
                        )
                    {
                        result[i]= result[i].Substring(0,j) + 'X' + result[i].Substring(j+1);
                    }
                }
            }
            return result ;
        }

        public static void kaprekarNumbers(int p, int q)
        {
            List<int> numbers= new List<int>();
            

            if(p<4)
            {
                if(p == 1)
                {
                    numbers.Add(1);
                }
                if (q < 4)
                {
                    writeResult(numbers);
                    return;
                }
                p = 4;
            }

            for (int i = p; i <= q; i++)
            {
                string squared = ((long) i * i ).ToString();
                string left = squared.Substring(0, squared.Length/2);
                string right = squared.Substring( squared.Length / 2);
                var result = Convert.ToInt32(left) + Convert.ToInt32(right); 
                if(result == i)
                {
                    numbers.Add(i);
                }
            }
           
            writeResult(numbers);            
        }

        private static void writeResult(List<int> numbers)
        {
            StringBuilder sb = new StringBuilder();
            if (numbers.Count == 0)
            {
                Console.WriteLine("INVALID RANGE");
            }
            else
            {
                foreach (var num in numbers)
                {
                    sb.Append(num + " ");
                }
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }

        public static long strangeCounter(long t)
        {
            long result = 0;
            long tmp = 3;
            int i = 0;
            List<long> specialNums = new List<long>();
            bool rangeFound = false;
            specialNums.Add(1);

            while (!rangeFound)
            {
                specialNums.Add(specialNums[i] + tmp);
                i++;
                
                if(t< specialNums[i] )
                {
                    rangeFound = true;
                    result = specialNums[i] - t;
                }

                tmp *= 2;
            }

            return result;
        }

        public class Product
        {
            public long Price { get; set; }
            public long Count { get; set; }
        }
    }
}
