using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeSamples.Samples.StringSamples
{
    public class RegexSamples
    {
        public static bool CheckIfStartsWith(string input, string matchPattern)
        {
            Regex regex = new("^" + matchPattern);
            return regex.IsMatch(input);
        }

        //Password should have 2 uppercase, 2 lowercase, 2 special chars, 2 digits
        public static bool CheckPasswordHealth(string password)
        {
            Regex regex = new(@"^(?=.*[A-Z].*[A-Z])(?=.*[a-z].*[a-z])(?=.*\d.*\d)(?=.*\W.*\W).{8,}$");
            return regex.IsMatch(password);
        }

        public static bool CheckPasswordHealth2(string password)
        {
            int upper = 0, lower = 0;
            int number = 0, special = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char ch = password[i];
                if (ch >= 'A' && ch <= 'Z')
                    upper++;
                else if (ch >= 'a' && ch <= 'z')
                    lower++;
                else if (ch >= '0' && ch <= '9')
                    number++;
                else
                    special++;
            }

            return upper > 1 && lower > 1 && number > 1 && special > 1;
        }

        public static bool CheckPasswordHealth3(string password)
        {
            int upper = 0, lower = 0;
            int number = 0, special = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char ch = password[i];
                if (ch >= 'A' && ch <= 'Z')
                    upper++;
                else if (ch >= 'a' && ch <= 'z')
                    lower++;
                else if (ch >= '0' && ch <= '9')
                    number++;
                else
                    special++;

                if (upper > 1 && lower > 1 && number > 1 && special > 1)
                {
                    break;
                }
            }

            return upper > 1 && lower > 1 && number > 1 && special > 1;
        }
    }
}
