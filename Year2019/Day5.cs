using System;

namespace Year2019
{
    public class Day5 : TaskDay
    {
        public override string Task1()
        {
            return Diagnostic(1);
        }        
        
        public override string Task2()
        {
            return Diagnostic(5);
        }

        private static string Diagnostic(int input)
        {
            var computer = new IntCode(InputFileDirectory + "Day5.txt");
            computer.GetInput(input);
            while (!computer.Finished)
            {
                Console.WriteLine(computer.Output);
                computer.ContinueProcess();
            }
            return string.Empty;
        }
    }
}
