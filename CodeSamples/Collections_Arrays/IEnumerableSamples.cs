using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Collections_Arrays
{
    public class IEnumerableSamples
    {
        //compare ExecuteInForeach() and ExecuteWithToList() methods.
        public void ExecuteInForeach()
        {
            var names = new List<string> { "sam", "alexia", "simon", "sumanth", "tony", "sam", "amr", "mark", "drew" };
            var moreThanFiveLetters = names.Where(w => w.Length > 5);
            names[0] = "benjamin";

            foreach (var name in moreThanFiveLetters)
            {
                Console.WriteLine(name);    //writes benjamin, alexia, sumanth
            }
        }

        public void ExecuteWithToList()
        {
            var names = new List<string> { "sam", "alexia", "simon", "sumanth", "tony", "sam", "amr", "mark", "drew" };
            var moreThanFiveLetters = names.Where(w => w.Length > 5).ToList();   //Query is executed right here due to ToList() method
            names[0] = "benjamin";

            foreach (var name in moreThanFiveLetters)
            {
                Console.WriteLine(name);    //writes alexia, sumanth
            }
        }
    }
}
