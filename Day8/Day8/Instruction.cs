using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    public class Instruction
    {
        public int Position { get; set; }
        public string Operation { get; set; }
        public int Argument { get; set; }
        public bool Executed { get; set; }

        public Instruction(string input)
        {
            Operation = input.Substring(0, 3);
            Argument = Convert.ToInt32(input.Split(' ')[1]);
        }
    }
}
