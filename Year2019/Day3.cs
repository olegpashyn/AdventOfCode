namespace Year2019
{
    public class Day3 : TaskDay
    {
        public override string Task2()
        {
            const int search = 19690720;
            for (var d = 1; d <= 99; d++)
            {
                for (var e = 0; e < 99; e++)
                {
                    var parser = new IntCodeWithAccess(InputFileDirectory + "Day1.txt");
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
}