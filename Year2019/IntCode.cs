using System.Collections;
using System.IO;
using System.Linq;

namespace Year2019
{
    internal class IntCodeWithAccess : IntCode
    {
        public IntCodeWithAccess(string inputFile) : base(inputFile)
        {}

        public long FirstCommand()
        {
            return Program[0];
        }

        public void SetInput(int noun, int verb)
        {
            Program[1] = noun;
            Program[2] = verb;
        }

    }

    public class IntCode
    {
        public int Output;
        public bool Finished;
        protected long[] Program;

        private long _input;
        private bool _inProgress;
        private int _offset;
        private int _pointer;

        public IntCode(string inputFile)
        {
            _offset = 0;
            Program = File.ReadAllText(inputFile).Split(',').Select(long.Parse).ToArray();
        }

        public void GetInput(long inputNumber)
        {
            _input = inputNumber;
            _inProgress = true;
            Process();
        }

        public void ContinueProcess()
        {
            _inProgress = true;
            Process();
        }

        private long[] ParseQuartet(int input)
        {
            var temp = new int[4];
            var quartet = Program[input].ToString();
            quartet = "0000" + quartet;
            temp[0] = int.Parse(quartet.Substring((quartet.Length - 5), 1));
            temp[1] = int.Parse(quartet.Substring((quartet.Length - 4), 1));
            temp[2] = int.Parse(quartet.Substring((quartet.Length - 3), 1));
            temp[3] = int.Parse(quartet.Substring((quartet.Length - 2), 2));

            long[] output = {0, 0, 0, 0};

            output[0] = temp[3];

            if (output[0] == 99)
            {
                return output;
            }

            if (!((IList) new int[] {3, 4, 9}).Contains((int) output[0]))
            {
                if ((input + 3) > Program.Length)
                {
                    WidenRange((input + 3));
                }

                output[1] = GetOperand(temp[2], Program[input + 1]);
                output[2] = GetOperand(temp[1], Program[input + 2]);
                output[3] = GetTargetAddress(temp[0], Program[input + 3]);
            }
            else if (((IList) new int[] {4, 9}).Contains((int) output[0]))
            {
                output[1] = GetOperand(temp[2], Program[input + 1]);
            }
            else
            {
                if ((input + 1) > Program.Length)
                {
                    WidenRange((input + 1));
                }

                output[3] = GetTargetAddress(temp[2], Program[input + 1]);
            }

            return output;
        }

        private long GetOperand(int mode, long input)
        {
            switch (mode)
            {
                case 1:
                    return input;

                case 2:
                    if ((input + _offset) > Program.Length)
                    {
                        WidenRange((int) (input + _offset));
                    }

                    return Program[input + _offset];

                default:
                    if (input >= Program.Length)
                    {
                        WidenRange((int) input);
                    }

                    return Program[input];
            }
        }

        private void WidenRange(int position)
        {
            var temp = new long[position - Program.Length + 1];
            var output = new long[position + 1];

            Program.CopyTo(output, 0);
            temp.CopyTo(output, Program.Length);
            Program = output;
        }

        private long GetTargetAddress(int mode, long input)
        {
            if (mode == 2)
            {
                if ((input + _offset) >= Program.Length)
                {
                    WidenRange((int) (input + _offset));
                }

                return (input + _offset);
            }

            if (input >= Program.Length)
            {
                WidenRange((int) input);
            }

            return (int) input;
        }

        private void GetOutput(int outputNumber)
        {
            Output = outputNumber;
            _inProgress = false;
        }

        private void Process()
        {
            for (var position = _pointer; position < Program.Length;)
            {
                while (_inProgress)
                {
                    var instruction = ParseQuartet(position);
                    if (instruction[0] == 99)
                    {
                        Finished = true;
                        _inProgress = false;
                        break;
                    }

                    switch (instruction[0])
                    {
                        case 1:
                            Program[instruction[3]] = instruction[1] + instruction[2];
                            position += 4;
                            break;

                        case 2:
                            Program[instruction[3]] = instruction[1] * instruction[2];
                            position += 4;
                            break;

                        case 3:
                            Program[instruction[3]] = _input;
                            position += 2;
                            break;

                        case 4:
                            GetOutput((int) instruction[1]);
                            position += 2;
                            _pointer = position;
                            break;

                        case 5:
                            position = (instruction[1] != 0) ? (int) instruction[2] : (position + 3);
                            break;

                        case 6:
                            position = (instruction[1] == 0) ? (int) instruction[2] : (position + 3);
                            break;

                        case 7:
                            Program[instruction[3]] = (instruction[1] < instruction[2]) ? 1 : 0;
                            position += 4;
                            break;

                        case 8:
                            Program[instruction[3]] = (instruction[1] == instruction[2]) ? 1 : 0;
                            position += 4;
                            break;

                        case 9:
                            _offset += (int) instruction[1];
                            position += 2;
                            break;
                    }
                }

                break;
            }
        }
    }
}