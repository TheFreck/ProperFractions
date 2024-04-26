using Machine.Specifications;

namespace ProperFractions.Specs
{
    public class When_Finding_All_Proper_Fractions_For_An_Even_Denominator
    {
        Establish context = () =>
        {
            input =  new long[] { 2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48,50 };
            expect = new long[] { 1,2,2,4, 4, 4, 6, 8, 6, 8,10, 8,12,12, 8,16,16,12,18,16,12,20,22,16,20 };
            answer = new long[input.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answer[i] = Fractions.ProperFractions(input[i]);
            }
        };

        It Should_Return_The_Number_Of_Proper_Fractions_For_A_Given_Denominator = () =>
        {
            for (var i = 0; i < answer.Length; i++)
            {
                if (answer[i] != expect[i])
                {
                    var inp = input[i];
                    var ans = answer[i];
                    var exp = expect[i];
                }
                answer[i].ShouldEqual(expect[i]);
            }
        };

        private static long[] input;
        private static long[] expect;
        private static long[] answer;
    }

    public class When_Finding_All_Proper_Fractions_For_An_Odd_Denominator
    {
        Establish context = () =>
        {
            input  = new long[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, /*9999999, 9678930201*/ };
            expect = new long[] { 0, 2, 4, 6, 6, 10, 12,  8, 16, 18, 12, 22, 20, 18, 28, 30, 20, 24, 36, 24, 40, 42, 24, 46, 42, 32, /*6637344, 6113006496*/ };
            answers1 = new long[input.Length];
            answers2 = new long[input.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answers1[i] = Fractions.FindFractions(input[i]);
                answers2[i] = Fractions.GCFMethod(input[i]);
            }
        };

        It Should_Return_The_Number_Of_Proper_Fractions_For_A_Given_Denominator = () =>
        {
            for (var i = 0; i < answers1.Length; i++)
            {
                if (answers1[i] != expect[i] || answers2[i] != expect[i])
                {
                    var inp = input[i];
                    var ans1 = answers1[i];
                    var ans2 = answers2[i];
                    var exp = expect[i];
                }
                answers1[i].ShouldEqual(expect[i]);
                answers2[i].ShouldEqual(expect[i]);
            }
        };

        private static long[] input;
        private static long[] expect;
        private static long[] answers1;
        private static long[] answers2;
    }

    public class When_Finding_Factors_Of_An_Integer
    {
        Establish context = () =>
        {
            input = new long[] { 1, 2, 3, 4, 6, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 24, 25, 26, 27, 28, 29, 30 };
            expect = new List<List<long>>
            { 
                new List<long> {},
                new List<long> {},
                new List<long> {},
                new List<long> {2},
                new List<long> {2,3},
                new List<long> {2,4},
                new List<long> {3},
                new List<long> {2,5},
                new List<long> {},
                new List<long> {2,3,4,6},
                new List<long> {},
                new List<long> {2,7},
                new List<long> {3,5},
                new List<long> {2,4,8},
                new List<long> {},
                new List<long> {2,3,6,9},
                new List<long> {2,4,5,10},
                new List<long> {3,7},
                new List<long> {2,11},
                new List<long> {2,3,4,6,8,12},
                new List<long> {5},
                new List<long> {2,13},
                new List<long> {3,9},
                new List<long> {2,4,7,14},
                new List<long> {},
                new List<long> {2,3,5,6,10,15}
            };
            answer = new List<List<long>>();
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answer.Add(Fractions.FindFactors(input[i]));
            }
        };

        It Should_Return_An_Array_Of_Factors = () =>
        {
            for (var i = 0; i < answer.Count; i++)
            {
                for(var j=0; j < answer[i].Count; j++)
                {
                    if (answer[i][j] != expect[i][j])
                    {
                        var inp = input[i];
                        var ans = answer[i][j];
                        var exp = expect[i][j];
                    }
                    answer[i][j].ShouldEqual(expect[i][j]);

                }
            }
        };

        private static long[] input;
        private static List<List<long>> expect;
        private static List<List<long>> answer;
    }

    public class When_Finding_The_Greatest_Common_Factor_Of_Two_Integers
    {
        Establish context = () =>
        {
            inputs = new List<(long, long)>
            {
                (25,10),(12,9),(14,21),(2,3),(232,46)
            };
            expects = new List<bool>
            {
                true,true,true,false,true
            };
            answer = new List<bool>();
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Count; i++)
            {
                answer.Add(Fractions.GreatestCommonFactor(inputs[i].Item1, inputs[i].Item2));
            }
        };

        It Should_Return_The_Greatest_Common_Factor = () =>
        {
            for (var i = 0; i < answer.Count; i++)
            {
                if (answer[i] != expects[i])
                {
                    var inp = inputs[i];
                    var ans = answer[i];
                    var exp = expects[i];
                }
                answer[i].ShouldEqual(expects[i]);
            }
        };

        private static List<(long, long)> inputs;
        private static List<bool> expects;
        private static List<bool> answer;
    }
}