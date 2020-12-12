using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day12
{
    public class Navigator
    {
        private char[] Directions = {'N', 'E', 'S', 'W'};
        private char[] Turns = {'L', 'R'};

        private int currentLocationPointer;
        private Dictionary<char,int> CurrentDistances = new Dictionary<char, int> {{'N', 0}, {'E', 0}, {'S', 0}, {'W', 0}};

        private List<Instruction> InstructionSet { get; set; }

        public Navigator(string[] input)
        {
            InstructionSet = new List<Instruction>();
            currentLocationPointer = 1;
            foreach (var line in input)
            {
                InstructionSet.Add(new Instruction(line));
            }
        }

        public void ProcessInstructions()
        {
            foreach (var instruction in InstructionSet)
            {
                if (Directions.Contains(instruction.Action))
                    AddDirection(instruction);
                else if (Turns.Contains(instruction.Action))
                    Turn(instruction);
                else
                    HandleForwardReverse(instruction);
            }
        }

        public int Distance
        {
            get
            {
                var ns = Math.Abs(CurrentDistances['N'] - CurrentDistances['S']);
                var ew = Math.Abs(CurrentDistances['E'] - CurrentDistances['W']);
                return ns + ew;
            }
        }

        private void AddDirection(Instruction instruction)
        {
            CurrentDistances[instruction.Action] += instruction.Quantity;
        }

        private void Turn(Instruction instruction)
        {
            currentLocationPointer = instruction.Action == 'R'
                ? (currentLocationPointer + instruction.Quantity / 90) % Directions.Length
                : (currentLocationPointer + Directions.Length - instruction.Quantity / 90) % Directions.Length;
        }

        private void HandleForwardReverse(Instruction instruction)
        {
            if (instruction.Action == 'F')
                CurrentDistances[Directions[currentLocationPointer]] += instruction.Quantity;
            else
            {
                CurrentDistances[Directions[currentLocationPointer]] -= instruction.Quantity;
            }
        }
    }

    public class Instruction
    {
        public char Action { get; set; }
        public int Quantity { get; set; }

        public Instruction(string input)
        {
            Action = input[0];
            Quantity = Convert.ToInt32(input.Substring(1));
        }
    }
}