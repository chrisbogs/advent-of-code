

using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    public struct Instruction 
    {
        public string operation;
        public long parameter;
    }
    
    internal class CommunicationSystemComputer
    {
        private const string NOOP = "noop"; // takes 1 cycle
        private const string ADDX = "addx"; // takes 2 cycles
        private int CurrentCycle = 0;
        private long RegisterValue = 1;
        // This saves the states from the following cycles:
        private int[] cyclesToSave = new int[] { 20, 60, 100, 140, 180, 220 };
        private readonly Dictionary<int, long> StatesOfSignalStrength = new();
        
        public long CombinedSignalStrengths => StatesOfSignalStrength.Sum(x => x.Value);

        public static List<Instruction> ParseInstructions(string[] input)
        {
            var result = new List<Instruction>();
            foreach (var line in input) {
                var split = line.Trim().Split(' ');
                result.Add(new Instruction()
                {
                    operation = split[0],
                    parameter = split.Length > 1 ? long.Parse(split[1]) : 0
                });
            }
            return result;
        }

        internal void Run(List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                var oldRegisterValue = RegisterValue;
                var oldCycle = CurrentCycle;
                switch (instruction.operation)
                {
                    case NOOP:
                        CurrentCycle++;
                        break;
                    case ADDX:
                        CurrentCycle += 2;
                        RegisterValue += instruction.parameter;
                        break;
                }

                // Save state if needed
                if (cyclesToSave.Any(x => oldCycle <= x && x <= CurrentCycle))
                {
                    // the operation took multiple cycles,
                    // so we need to use the state before the operation was completed.
                    var cyleToSave = cyclesToSave.First(x => oldCycle <= x && x <= CurrentCycle);
                    if (!StatesOfSignalStrength.ContainsKey(cyleToSave))
                    {
                        StatesOfSignalStrength.Add(cyleToSave, cyleToSave * oldRegisterValue);
                    }
                }
            }
        }
    }
}
