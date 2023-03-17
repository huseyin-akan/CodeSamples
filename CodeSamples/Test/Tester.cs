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

        public int MyFunc2(int age) => age * age;

        public void RaiseEvent()
        {
            Console.WriteLine("Event Raised");
        }

        public void Test(int b)
        {
            int a = 15;
            Husola(a, b, C);
            static void Husola(int a2, int b2, int c2)
            {
                Console.WriteLine(a2 + b2 + c2);
            }
        }

        public Task HusolaAsync()
        {
            for (int i = 0; i < 1_000_000_000; i++)
            {

            }
            Console.WriteLine("İşlem Bitti");
            return Task.FromResult(0);
        }

        public async Task HusolaAsync2()
        {
            for (int i = 0; i < 1_000_000_000; i++)
            {

            }
            Console.WriteLine("İşlem 2 Bitti");
        }

        public async Task<string> MakeTeaAsync()
        {
            var boilingWater = BoilWaterAsync();

            Console.WriteLine("take the cups out");

            var a = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                a += i;
            }

            Console.WriteLine("put tea in cups");

            var water = await boilingWater;

            Console.WriteLine("take the cups out");
            var tea = $"pour {water} in cups";
            Console.WriteLine(tea);

            return tea;
        }

        public async Task<string> BoilWaterAsync()
        {
            Console.WriteLine("Start the kettle");

            Console.WriteLine("waiting for the kettle");
            await Task.Delay(2000);

            Console.WriteLine("kettle finished boiling");

            return "water";
        }

        public string MakeTea()
        {
            var water = BoilWater();

            Console.WriteLine("take the cups out");

            Console.WriteLine("put tea in cups");

            Console.WriteLine("take the cups out");
            var tea = $"pour {water} in cups";
            Console.WriteLine(tea);

            return tea;
        }

        public string BoilWater()
        {
            Console.WriteLine("Start the kettle");

            Console.WriteLine("waiting for the kettle");
            Task.Delay(2000).GetAwaiter().GetResult();

            Console.WriteLine("kettle finished boiling");

            return "water";
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