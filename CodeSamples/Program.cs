using System;
using System.Text.RegularExpressions;

var pattern = @"[(]\d{3}[)]\s\d{3}\s\d{2}\s\d{2}";
Regex regex = new(pattern);
Console.WriteLine(regex.IsMatch("(554) 73991 14")); //true
Console.WriteLine(regex.IsMatch("123AsV")); //false
Console.WriteLine(regex.IsMatch("123AbC")); //false
Console.WriteLine(regex.IsMatch("123ABCD")); //true



