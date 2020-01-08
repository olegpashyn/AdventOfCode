using System;

namespace Year2019
{
    public class TaskDay
    {
        public const int TasksAvailable = 2;

        public virtual string Task1(string inputFileFolder)
        {
            return "Task 1 transformed to task 2";
        }

        public virtual string Task2(string inputFileFolder)
        {
            return "Not yet implemented";
        }
    }
}