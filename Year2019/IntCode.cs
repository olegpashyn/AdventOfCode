using System.Collections;
using System.IO;
using System.Linq;

namespace Year2019
{
    public class IntCode
    {
        public int Output;
        public bool Finished;

        private long _input;
        private bool _inProg;
        private long[] _program;
        private int _offset;
        private int _pointer;

        public IntCode(string inputFile)
        {
            _offset = 0;
            _program = Enumerable.ToArray(Enumerable.Select(File.ReadAllText(inputFile).Split(','), long.Parse));
        }

        public void getInput(long inputNumber)
        {
            _input = inputNumber;
            _inProg = true;
            Process();
        }

        public void continueProcess()
        {
            _inProg = true;
            Process();
        }

        private long[] ParseQuartet(int input)
        {
            var temp = new int[4];
            var quartet = this._program[input].ToString();
            quartet = "0000" + quartet;
            temp[0] = int.Parse(quartet.Substring((quartet.Length - 5), 1));
            temp[1] = int.Parse(quartet.Substring((quartet.Length - 4), 1));
            temp[2] = int.Parse(quartet.Substring((quartet.Length - 3), 1));
            temp[3] = int.Parse(quartet.Substring((quartet.Length - 2), 2));

            long[] output = { 0, 0, 0, 0 };

            output[0] = temp[3];

            if (output[0] == 99)
            {
                return output;
            }

            if (!((IList)new int[] { 3, 4, 9 }).Contains((int)output[0]))
            {
                if ((input + 3) > _program.Length)
                {
                    WidenRange((input + 3));
                }
                output[1] = GetOperand(temp[2], _program[input + 1]);
                output[2] = GetOperand(temp[1], _program[input + 2]);
                output[3] = GetTargetAddress(temp[0], _program[input + 3]);
            }
            else if (((IList)new int[] { 4, 9 }).Contains((int)output[0]))
            {
                output[1] = GetOperand(temp[2], _program[input + 1]);
            }
            else
            {
                if ((input + 1) > _program.Length)
                {
                    WidenRange((input + 1));
                }
                output[3] = GetTargetAddress(temp[2], _program[input + 1]);
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
                    if ((input + _offset) > _program.Length)
                    {
                        WidenRange((int)(input + _offset));
                    }
                    return _program[input + _offset];

                default:
                    if (input >= _program.Length)
                    {
                        WidenRange((int)input);
                    }
                    return _program[input];
            }
        }

        private void WidenRange(int position)
        {
            var temp = new long[position - _program.Length + 1];
            var output = new long[position + 1];

            _program.CopyTo(output, 0);
            temp.CopyTo(output, _program.Length);
            _program = output;
        }

        private long GetTargetAddress(int mode, long input)
        {
            if (mode == 2)
            {
                if ((input + _offset) >= _program.Length)
                {
                    WidenRange((int)(input + _offset));
                }
                return (input + _offset);
            }

            if (input >= _program.Length)
            {
                WidenRange((int)input);
            }
            return (int)input;
        }

        private void getOutput(int outputNumber)
        {
            Output = outputNumber;
            _inProg = false;
        }

        private void Process()
        {
            for (var position = _pointer; position < _program.Length;)
            {
                while (_inProg)
                {
                    var instruction = ParseQuartet(position);
                    if (instruction[0] == 99)
                    {
                        Finished = true;
                        _inProg = false;
                        break;
                    }

                    switch (instruction[0])
                    {
                        case 1:
                            _program[instruction[3]] = instruction[1] + instruction[2];
                            position += 4;
                            break;

                        case 2:
                            _program[instruction[3]] = instruction[1] * instruction[2];
                            position += 4;
                            break;

                        case 3:
                            _program[instruction[3]] = _input;
                            position += 2;
                            break;

                        case 4:
                            getOutput((int)instruction[1]);
                            position += 2;
                            _pointer = position;
                            break;

                        case 5:
                            position = (instruction[1] != 0) ? (int)instruction[2] : (position + 3);
                            break;

                        case 6:
                            position = (instruction[1] == 0) ? (int)instruction[2] : (position + 3);
                            break;

                        case 7:
                            _program[instruction[3]] = (instruction[1] < instruction[2]) ? 1 : 0;
                            position += 4;
                            break;

                        case 8:
                            _program[instruction[3]] = (instruction[1] == instruction[2]) ? 1 : 0;
                            position += 4;
                            break;

                        case 9:
                            _offset += (int)instruction[1];
                            position += 2;
                            break;
                    }
                }
                break;
            }
        }
    }
}