using ProperFractions;
using System.Diagnostics;

var keepGoing = true;
do
{
    //Console.WriteLine("Enter an integer to get its factors");
    //var integer = Console.ReadLine();
    //if (integer == string.Empty) keepGoing = false;
    //if (int.TryParse(integer, out int val))
    //{
    //    var stopwatch = new Stopwatch();
    //    stopwatch.Start();
    //    var factors = Fractions.FindFactors(val);
    //    stopwatch.Stop();
    //    Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} ms to find the factors:");
    //    for (var i = 0; i < factors.Count; i++)
    //    {
    //        Console.WriteLine(factors[i]);
    //    }
    //    Console.WriteLine(";");
    //}
    //Console.WriteLine("Enter another integer or press enter to finish");

    Console.WriteLine("Enter a denominator to see all the reduced fractions that can be made with it");

    var den = Console.ReadLine();
    if (den == string.Empty) keepGoing = false;
    if (int.TryParse(den, out var val))
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var fractions = Fractions.ProperFractions(val);
        stopwatch.Stop();
        Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} to find {fractions} reduced fractions");
    }
    Console.WriteLine("Enter another denominator or press enter to finish");

    //Console.WriteLine("Enter an integer to get its factors");
    //var integer = Console.ReadLine();
    //if (integer == string.Empty) keepGoing = false;
    //if (int.TryParse(integer, out int val))
    //{
    //    var next = false;
    //    var batch = 0;
    //    var batchSize = val <= 1000 ? val : 1000;
    //    do
    //    {
    //        for (var i = batch; i < batch + batchSize; i++)
    //        {
    //            var factors = Fractions.ProperFractions(i);
    //            Console.WriteLine(factors);
    //        }
    //        var more = Console.ReadLine();
    //        batch += batchSize;
    //        next = batch <= val ? true : false;
    //        Console.WriteLine("============================================");
    //    } while (next);

    //}
    //Console.WriteLine("Enter another integer or press enter to finish");
} while (keepGoing);
