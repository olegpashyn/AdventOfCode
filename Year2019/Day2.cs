using System;

namespace Year2019
{
    public class Day2 : TaskDay
    {
        private const string inputFileName = InputFileDirectory + "Day2.txt";

        public override string Task1()
        {
            var robot = new IntCodeWithAccess(inputFileName);
            robot.SetInput(12, 2);
            robot.ContinueProcess();
            return robot.Output().ToString();
        }

        public override string Task2()
        {
            const int search = 19690720;
            for (var d = 1; d <= 99; d++)
            {
                for (var e = 0; e < 99; e++)
                {
                    var parser = new IntCodeWithAccess(inputFileName);
                    parser.SetInput(d, e);
                    parser.ContinueProcess();
                    if (parser.Output() == search)
                    {
                        return ((d * 100 + e).ToString());
                    }
                }
            }
            return null;
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
