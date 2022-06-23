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
            //Console.WriteLine(HackerRank.quickSort(new List<int> { 4, 5, 3, 7, 2 }));
            var queries = new List<int> { 5, 9, 7, 8, 12, 5 }; 

            Console.WriteLine(HackerRank.weightedUniformStrings("aaabbbbcccddd", queries));
            
        }
    }
}
