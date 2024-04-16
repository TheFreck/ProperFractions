using Machine.Specifications;

namespace ProperFractions.Specs
{
    public class When_Finding_All_Proper_Fractions_For_Given_Denominator
    {
        Establish context = () =>
        {
            input =  new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            expect = new long[][] { new long[] { 0 },new long[] { 1 },new long[] { 1, 2 },new long[] { 1, 3 },new long[] { 1, 2, 3, 4 },new long[] { 1, 5 },new long[] { 1, 2, 3, 4, 5, 6 },new long[] { 1, 3, 5, 7 },new long[] { 1, 2, 4, 5, 7, 8 } };
            answer = new long[input.Length][];
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answer[i] = Fractions.FindFractions(input[i]);
            }
        };

        It Should_Return_The_Number_Of_Proper_Fractions_For_A_Given_Denominator = () =>
        {
            for (var i = 0; i < answer.Length; i++)
            {
                for(var j=0; j< answer[i].Length; j++)
                {
                    if (answer[i][j] != expect[i][j])
                    {
                        var ans = answer[i][j];
                        var exp = expect[i][j];
                    }
                    answer[i][j].ShouldEqual(expect[i][j]);
                }
            }
        };

        private static long[] input;
        private static long[][] expect;
        private static long[][] answer;
    }
}