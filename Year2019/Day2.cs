using System;

namespace Year2019
{
    public static class Day2
    {
        public static void Task2(string inputFile)
        {

            const int search = 19690720;
            for (var d = 1; d <= 99; d++)
            {
                for (var e = 0; e < 99; e++)
                {
                    var parser = new IntCodeWithAccess(inputFile);
                    parser.SetInput(d, e);
                    parser.ContinueProcess();
                    if (parser.Output() == search)
                    {
                        Console.WriteLine(d * 100 + e);
                    }
                }
            }
        }
    }

    internal class IntCodeWithAccess : IntCode
    {
        public IntCodeWithAccess(string inputFile) : base(inputFile)
        {}

        public new long Output()
        {
            return _program[0];
        }

        public void SetInput(int noun, int verb)
        {
            _program[1] = noun;
            _program[2] = verb;
        }

    }
}
