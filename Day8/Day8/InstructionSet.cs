using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Day8
{
    public class InstructionSet
    {
        public int Accumulator { get; set; }
        public List<Instruction> Instructions { get; set; }

        public InstructionSet(string[] input)
        {
            Instructions = new List<Instruction>();
            int i = 0;
            foreach (var line in input)
            {
                var instruction = new Instruction(line) { Position = i};
                Instructions.Add(instruction);
                i++;
            }
        }

        public void Reset()
        {
            Instructions.ForEach(x => x.Executed = false);
            Accumulator = 0;
        }

        public bool Execute()
        {
            var instruction = Instructions.First();
            while (instruction != null && !instruction.Executed)
            {
                instruction = ProcessInstruction(instruction, Instructions);
            }

            return instruction == null;
        }

        private Instruction ProcessInstruction(Instruction instruction, List<Instruction> instructions)
        {
            instruction.Executed = true;
            if (instruction.Operation == "nop")
            {
                return instructions.First(x => x.Position == instruction.Position + 1);
            }

            if (instruction.Operation == "acc")
            {
                Accumulator += instruction.Argument;
                return instructions.First(x => x.Position == instruction.Position + 1);
            }

            if (instruction.Operation == "jmp")
            {
                return instructions.FirstOrDefault(x => x.Position == instruction.Position + instruction.Argument);
            }

            throw new Exception();
        }
    }
}