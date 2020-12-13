using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day12
{
    public class Navigator
    {
        private char[] Directions = {'N', 'E', 'S', 'W'};
        private char[] Turns = {'L', 'R'};

        private int currentDirectionPointer;
        private Dictionary<char, int> CurrentDistances = new Dictionary<char, int> { { 'N', 0 }, { 'E', 0 }, { 'S', 0 }, { 'W', 0 } };
        private Dictionary<char, int> WaypointLocation = new Dictionary<char, int> { { 'N', 0 }, { 'E', 0 }, { 'S', 0 }, { 'W', 0 } };

        private List<Instruction> InstructionSet { get; set; }

        public Navigator(string[] input)
        {
            InstructionSet = new List<Instruction>();
            currentDirectionPointer = 1;
            WaypointLocation['E'] = 10;
            WaypointLocation['N'] = 1;
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
            // Part 1
            //CurrentDistances[instruction.Action] += instruction.Quantity;

            WaypointLocation[instruction.Action] += instruction.Quantity;
        }

        private void Turn(Instruction instruction)
        {
            // Part 1
            //currentDirectionPointer = instruction.Action == 'R'
            //    ? (currentDirectionPointer + instruction.Quantity / 90) % Directions.Length
            //    : (currentDirectionPointer + Directions.Length - instruction.Quantity / 90) % Directions.Length;

            // Move the waypoint around the ship
            var turns = instruction.Action == 'R' ? instruction.Quantity / 90 : 4 - instruction.Quantity / 90;
            for (int i = 0; i < turns; i++)
            {
                var temp = WaypointLocation['N'];
                WaypointLocation['N'] = WaypointLocation['W'];
                WaypointLocation['W'] = WaypointLocation['S'];
                WaypointLocation['S'] = WaypointLocation['E'];
                WaypointLocation['E'] = temp;
            }
        }

        private void HandleForwardReverse(Instruction instruction)
        {
            // Part 1
            //if (instruction.Action == 'F')
            //    CurrentDistances[Directions[currentDirectionPointer]] += instruction.Quantity;
            //else
            //{
            //    CurrentDistances[Directions[currentDirectionPointer]] -= instruction.Quantity;
            //}
            if (instruction.Action == 'R')
                instruction.Quantity = -instruction.Quantity;

            foreach (char direction in Directions)
            {
                CurrentDistances[direction] += instruction.Quantity * WaypointLocation[direction];
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