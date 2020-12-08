using System;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Input.txt");
            var instructionSet = new InstructionSet(lines);
            Console.WriteLine($"{instructionSet.Instructions.Count} instructions.");
            instructionSet.Execute();
            Console.WriteLine($"Accumulator: {instructionSet.Accumulator}");

            foreach (var instruction in instructionSet.Instructions)
            {
                instructionSet.Reset();
                instruction.Operation = instruction.Operation == "nop" ? "jmp" : instruction.Operation == "jmp" ? "nop": instruction.Operation;
                if (instructionSet.Execute())
                {
                    Console.WriteLine($"Changed position {instruction.Position} and completed. Accumulator is {instructionSet.Accumulator}");
                    break;
                }
                // revert
                instruction.Operation = instruction.Operation == "nop" ? "jmp" : instruction.Operation == "jmp" ? "nop" : instruction.Operation;
            }
            Console.Read();
        }
    }
}
