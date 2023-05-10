using CodeSamples.CSharpFeatures.CSharp11;
using RabbitMQ.Client;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

const int numFlips = 1000;
int harunScore = 0;
int muhsinScore = 0;
Random random = new Random();

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Yarış Başlasın....\n");

// Flip the coin 1000 times
for (int i = 0; i < numFlips; i++)
{

    // Simulate a coin flip by generating a random number (0 or 1)
    int flipResult = random.Next(2);

    // Check the result of the coin flip and update the scores and console output
    if (flipResult == 0)
    {
        harunScore++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Yazı geldi. Harun kazandı");
    }
    else
    {
        muhsinScore++;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Tura geldi. Muhsin kazandı");
    }

    Console.ResetColor();
    Console.WriteLine($"Harun {harunScore} - Muhsin {muhsinScore}\n");

    // Sleep for 200 ms to make the output easier to read
    System.Threading.Thread.Sleep(1000);
}

Console.WriteLine($"Final score: Harun {harunScore} - Muhsin {muhsinScore}");

if (harunScore > muhsinScore)
{
    Console.WriteLine("Harun kazandı. Balkonlu oda Harun'un. Muhsin kalk çay koy!!");
}
else if (muhsinScore > harunScore)
{
    Console.WriteLine("Muhsin kazandı. Balkonlu oda Harun'un. Muhsin kalk çay koy!!");
}
else
{
    Console.WriteLine("Berabere bitti. Tekrar yarışılacak!!!!");
}

Console.ReadLine();
