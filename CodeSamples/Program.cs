using CodeSamples.Collections_Arrays;
using CodeSamples.Number_Samples;
using CodeSamples.String;
using CodeSamples.Test;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodeSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Effing World!");

            List<int> sayilar = new List<int> { 3, 8, 15, 11, 14,1,9, 2, 24,31 };

            Console.WriteLine(HackerRank.strangeCounter(4) ); 
            Console.WriteLine(HackerRank.strangeCounter(5) ); 
            Console.WriteLine(HackerRank.strangeCounter(6) ); 
            Console.WriteLine(HackerRank.strangeCounter(7) ); 
            Console.WriteLine(HackerRank.strangeCounter(94) ); 
            Console.WriteLine(HackerRank.strangeCounter(46) ); 
            //string str = "Huso";
            //int n = str.Length;
            //StringSamples.permute(str, 0, n - 1);
            Console.WriteLine((int) 'A' );
            Console.WriteLine((int) 'Z' );
        }
    }
}
