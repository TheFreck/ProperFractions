using ProperFractions;
using System.Diagnostics;

var keepGoing = true;
do
{
    Console.WriteLine("1: Find fractions");
    Console.WriteLine("2: Find the Greatest Common Factor of two numbers");
    Console.WriteLine("3: Find factors");

    var input = Console.ReadLine();
    if (input == "") keepGoing = false;

    if (int.TryParse(input, out int choice))
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter an integer to find the number of proper fractions that can be made with it as denominator");
                var case1 = Console.ReadLine();
                if (case1 == "")
                {
                    keepGoing = false;
                    break;
                }
                if (long.TryParse(case1, out long num))
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var method1 = Fractions.FindFractions(num);
                    stopwatch.Stop();
                    Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds}ms and  {stopwatch.ElapsedTicks} ticks to find {method1} proper fractions using method 1");
                    stopwatch.Reset();
                    stopwatch.Start();
                    var method2 = Fractions.GCFMethod(num);
                    stopwatch.Stop();
                    Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds}ms and  {stopwatch.ElapsedTicks} ticks to find {method2} proper fractions using method 2");
                }
                break;
            case 2:
                Console.WriteLine("Enter a pair of integers separated by a space to get their greatest common factor");
                var case3 = Console.ReadLine();
                if (case3 == "")
                {
                    keepGoing = false;
                    break;
                }
                var num1 = case3.Split(" ")[0];
                var num2 = case3.Split(" ")[1];
                if (long.TryParse(num1, out var first) && long.TryParse(num2, out var second))
                {
                    Console.WriteLine("How many times would you like it to run?");
                    var timesText = Console.ReadLine();
                    var stopwatch = new Stopwatch();
                    bool gcf = false;
                    bool commonFactors = false;
                    long elapsed1 = 0;
                    long elapsed2 = 0;
                    if (int.TryParse(timesText, out int times))
                    {
                        stopwatch.Start();
                        for (var i = 0; i < times; i++)
                        {
                            var firstFactors = Fractions.FindFactors(first);
                            var secondFactors = Fractions.FindFactors(second);
                            if (firstFactors.Where(f => secondFactors.Contains(f)).Any()) commonFactors = true;
                        }
                        stopwatch.Stop();
                        elapsed1 += stopwatch.ElapsedMilliseconds;
                        stopwatch.Reset();
                        stopwatch.Start();
                        for (var i = 0; i < times; i++)
                        {
                            gcf = Fractions.GreatestCommonFactor(first, second);
                        }
                        stopwatch.Stop();
                        elapsed2 += stopwatch.ElapsedMilliseconds;
                    }
                    var does = gcf ? "do" : "don't";
                    var has = commonFactors ? "do" : "don't";

                    Console.WriteLine($"it took {elapsed1}ms to find that {first} and {second} {does} have a commond factor larger than 1 using method 1");
                    Console.WriteLine($"it took {elapsed2}ms to find that {first} and {second} {has} have a commond factor larger than 1 using method 2");
                }
                break;
            case 3:
                Console.WriteLine("Enter an integer to find its factors");
                break;
            default:
                break;
        }
    }

    Console.WriteLine("Try again");

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

    //Console.WriteLine("Enter a denominator to see all the reduced fractions that can be made with it");

    //var den = Console.ReadLine();
    //if (den == string.Empty) keepGoing = false;
    //if (int.TryParse(den, out var val))
    //{
    //    var stopwatch = new Stopwatch();
    //    stopwatch.Start();
    //    var fractions = Fractions.GCFMethod(val);
    //    stopwatch.Stop();
    //    Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} ms to find {fractions} reduced fractions using GCFMethod");

    //    stopwatch.Reset();

    //    stopwatch.Start();
    //    fractions = Fractions.FindFractions(val);
    //    stopwatch.Stop();
    //    Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} ms to find {fractions} reduced fractions using FindFractions");
    //}
    //Console.WriteLine("Enter another denominator or press enter to finish");

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

    //Console.WriteLine("Enter two integers separated by a space to find the greatest common factor");
    //var integer = Console.ReadLine();
    //if(integer == string.Empty) keepGoing = false;
    //var x = integer.Split(' ')[0];
    //var y = integer.Split(' ')[1];
    //if (long.TryParse(x, out long item1) && long.TryParse(y, out long item2))
    //{
    //    var stopwatch = new Stopwatch();
    //    stopwatch.Start();
    //    var gcf = Fractions.GreatestCommonFactor(item1, item2);
    //    stopwatch.Stop();
    //    Console.WriteLine($"{gcf} found in {stopwatch.ElapsedMilliseconds}ms");
    //}
    //Console.WriteLine("Enter another pair of integers or press enter to finish");


} while (keepGoing);
