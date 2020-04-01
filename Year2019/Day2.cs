namespace Year2019
{
    public class Day2 : TaskDay
    {
        private const string InputFileName = InputFileDirectory + "Day2.txt";

        public override string Task1()
        {
            var robot = new IntCodeWithAccess(InputFileName);
            robot.SetInput(12, 2);
            robot.ContinueProcess();
            return robot.FirstCommand().ToString();
        }

        public override string Task2()
        {
            const int search = 19690720;
            for (var d = 1; d <= 99; d++)
            {
                for (var e = 0; e < 99; e++)
                {
                    var parser = new IntCodeWithAccess(InputFileName);
                    parser.SetInput(d, e);
                    parser.ContinueProcess();
                    if (parser.FirstCommand() == search)
                    {
                        return ((d * 100 + e).ToString());
                    }
                }
            }
            return null;
        }
    }
}
