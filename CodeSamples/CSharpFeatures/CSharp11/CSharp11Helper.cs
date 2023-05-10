using CodeSamples.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.CSharpFeatures.CSharp11
{
    public class CSharp11Helper
    {
        public static string RawStringLiterals()
        {
            var newString = """
                Write anything you want here and also whitespaces and then check it out in console.
                    some blanks                 and some more of'em
                Write any special char you want such as : " ' { } : and etc.
                Awesome : "YEAAAAAAAAH!!!!!!"
                If you want to write JSON you can do it as well : 
                husoka : {"name":"husoka", "age":13} 
                """;
                //Any whitespace to the left of the closing double quotes will be removed from the string literal

            var randomNum = new Random().Next(100);
            
            //If you use only one $ sign, then you should use interpolation with 1 curly brace
            newString += $"""

                New random number added to the string : {randomNum}
                """;

            //2 dollar signs then we need 2 curly braces :
            newString += $$"""

                And another new random number is : {{new Random().Next(100)}}
                """;

            //And obviously 3 dollar sign means:
            newString += $$$"""

                We dont even need to explain it anymore  {{{new Random().Next(100) }}}
                """;

            //Use more double quote chars if needed:
            newString += """" 

                And if needed to use """ in a raw string literal, then just use 4 of double quote characters :) 
                """";

            return newString;
        }
    }
}
