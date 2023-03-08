using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Test
{
    public class Tester
    {
        public int C { get; set; }

        
        public static Func<int, int> MyFunc = num => num * num;

        public int MyFunc2(int age)  => age * age;

        public void RaiseEvent()
        {
            Console.WriteLine("Event Raised");
        }

        public void Test(int b)
        {
            int a = 15;
            Husola(a,b,C);
            static void Husola(int a2, int b2, int c2)
            {
                Console.WriteLine( a2 + b2 + c2);
            }
        }

        public static int KatsayiToplayici(int Baslangic, int Bitis, int Katsayi, int Toplam = 0)
        {
            if (Baslangic <= Bitis)
            {
                if (Baslangic % Katsayi == 0)
                {
                    Toplam += Baslangic;
                }
                return Toplam + KatsayiToplayici(++Baslangic, Bitis, Katsayi);
            }
            return 0;
        }
        
    }

    public class TestValueClass
    {
        public int Val1 { get; set; }
    }

    public struct TestValueStruct
    {
        public int Val1 { get; set; }
    }
}
