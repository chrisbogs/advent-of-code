

using System;
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
        private long MiddleOfSpriteValue = 1;
        // This saves the states from the following cycles:
        private int[] cyclesToSave = new int[] { 20, 60, 100, 140, 180, 220 };
        private readonly Dictionary<int, long> StatesOfSignalStrength = new();
        
        public long CombinedSignalStrengths => StatesOfSignalStrength.Sum(x => x.Value);

        // CRT
        // draws a single pixel during each cycle
        private const int SPRITE_WIDTH = 3;
        private const int SCREEN_WIDTH = 40;
        private const int SCREEN_HEIGHT = 6;
        private const char LIT = '#';
        private const char DARK = ' ';
        private char[] Screen;

        public CommunicationSystemComputer()
        {
            this.Screen = new char[SCREEN_HEIGHT * SCREEN_WIDTH];
        }

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

        internal void Run(List<Instruction> instructions, bool draw = false)
        {
            foreach (var instruction in instructions)
            {
                var oldSpriteValue = MiddleOfSpriteValue;
                var oldCycle = CurrentCycle;

                if (draw)
                {
                    DrawPixel(oldSpriteValue, CurrentCycle);
                }

                switch (instruction.operation)
                {
                    case NOOP:
                        CurrentCycle++;
                        break;
                    case ADDX:
                        if (draw)
                        {
                            DrawPixel(oldSpriteValue, CurrentCycle+1);
                        }
                        CurrentCycle += 2;
                        MiddleOfSpriteValue += instruction.parameter;
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
                        StatesOfSignalStrength.Add(cyleToSave, cyleToSave * oldSpriteValue);
                    }
                }
            }
        }

        private void DrawPixel(long oldRegisterValue, int currentIndexOnScreen)
        {
            var pixelToDraw = DARK;
            var horizontalPosition_NoVertical = currentIndexOnScreen % SCREEN_WIDTH;
            if (oldRegisterValue - 1 <= horizontalPosition_NoVertical && horizontalPosition_NoVertical <= oldRegisterValue + 1)
            {
                pixelToDraw = LIT;
            }
            this.Screen[currentIndexOnScreen % (SCREEN_WIDTH * SCREEN_HEIGHT)] = pixelToDraw;
        }

        public void PrintScreen() 
        {
            //Array.Fill<char>(Screen, '_');
            for (int i = 0; i < SCREEN_WIDTH * SCREEN_HEIGHT; i++)
            {
                Console.Write(this.Screen[i].ToString());
                if (i>1 && i % (SCREEN_WIDTH) == SCREEN_WIDTH-1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
