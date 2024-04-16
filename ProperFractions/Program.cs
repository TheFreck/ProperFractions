using ProperFractions;
using System.Diagnostics;

var keepGoing = true;
do
{
    Console.WriteLine("Enter a denominator to see all the reduced fractions that can be made with it");

    var den = Console.ReadLine();
    if (den == string.Empty) keepGoing = false;
    if (int.TryParse(den, out var val))
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var fractions = Fractions.FindFractions(val);
        stopwatch.Stop();
        Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} to find {fractions} reduced fractions");
    }
    Console.WriteLine("Enter another denominator or press enter to finish");
} while (keepGoing);
