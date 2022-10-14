using AdventOfCodeShared.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCodeShared.Services
{
    public class TwentySeventeen
    {
        public static double Day1Part1(string[] input)
        {
            return CalcFuelNeeded(input);
        }
        public static double Day1Part2(string[] input)
        {
            return CalcFuelNeededPart2(input);
        }

        public static long Day2Part1(string[] input)
        {
            var computer = new Computer(input[0]);
            //To do this, before running the program, replace position 1 with the value 12 and replace position 2 with the value 2.
            computer.SetInputs(12, 2);
            computer.RunIntCodeProgram();
            return computer.Output;
        }
        public static int Day2Part2(string[] input)
        {
            // Find the input noun and verb that cause the program to produce the output 19690720.
            // What is 100 * noun + verb ? (For example, if noun = 12 and verb = 2, the answer would be 1202.)
            var initialMemory = input[0];
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    var computer = new Computer(initialMemory);
                    computer.SetInputs(noun, verb);
                    computer.RunIntCodeProgram();
                    if (computer.Output == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            return -1;
        }
        public static long Day3Part1(string[] input)
        {
            var wire1 = input[0].Split(",");
            var wire2 = input[1].Split(",");
            return FindClosestDistanceToOrigin(wire1, wire2);
        }

        public static long Day3Part2(string[] input)
        {
            var wire1 = input[0].Split(",");
            var wire2 = input[1].Split(",");
            return FindIntersectionWithLeastSteps(wire1, wire2);
        }

        public static int Day4Part1(string[] input)
        {
            var inputs = input[0].Split("-");
            int criteriaMin = 0;
            int criteriaMax = 0;
            if (!string.IsNullOrEmpty(inputs[0]) && !string.IsNullOrEmpty(inputs[0]))
            {
                criteriaMin = int.Parse(inputs[0]);
                criteriaMax = int.Parse(inputs[1]);
            }
            var result = 0;
            //How many different passwords within the range given in your puzzle input meet these criteria?
            for (var i = criteriaMin; i <= criteriaMax; i++)
            {
                if (MeetsCriteria(i.ToString(), criteriaMin, criteriaMax))
                {
                    result++;
                }
            }
            return result;
        }

        public static int Day4Part2(string[] input)
        {
            var inputs = input[0].Split("-");
            int criteriaMin = 0;
            int criteriaMax = 0;
            if (!string.IsNullOrEmpty(inputs[0]) && !string.IsNullOrEmpty(inputs[0]))
            {
                criteriaMin = int.Parse(inputs[0]);
                criteriaMax = int.Parse(inputs[1]);
            }
            var result = 0;
            for (var i = criteriaMin; i <= criteriaMax; i++)
            {
                if (MeetsCriteriaUpdated(i.ToString(), criteriaMin, criteriaMax))
                {
                    result++;
                }
            }
            return result;
        }

        public static List<long> Day5Part1(string[] input)
        {
            var computer = new Computer(input[0]);
            //The TEST diagnostic program will start by requesting from the user the ID of the system to test by running an input instruction
            //- provide it 1, the ID for the ship's air conditioner unit.
            computer.RunIntCodeProgram(new Stack<long>(new List<long>() { 1 }));
            //It will then perform a series of diagnostic tests confirming that various parts of the Intcode computer, like parameter modes, function correctly.
            //For each test, it will run an output instruction indicating how far the result of the test was from the expected value, where 0 means the test was successful.
            //Non-zero outputs mean that a function is not working correctly; check the instructions that were run before the output instruction to see which one failed.
            //Finally, the program will output a diagnostic code and immediately halt.
            //This final output isn't an error; an output followed immediately by a halt means the program finished.
            //If all outputs were zero except the diagnostic code, the diagnostic program ran successfully.
            //After providing 1 to the only input instruction and passing all the tests, what diagnostic code does the program produce?
            return computer.DiagnosticOutput;
        }
        public static List<long> Day5Part2(string[] input)
        {
            //This time, when the TEST diagnostic program runs its input instruction to get the ID of the system to test,
            var computer = new Computer(input[0]);
            //provide it 5, the ID for the ship's thermal radiator controller.
            //This diagnostic test suite only outputs one number, the diagnostic code.
            computer.RunIntCodeProgram(new Stack<long>(new List<long>() { 5 }));
            //What is the diagnostic code for system ID 5?
            return computer.DiagnosticOutput;
        }

        public static int Day6Part1(string[] input)
        {
            //What is the total number of direct and indirect orbits in your map data?
            return CalcOrbits(LoadOrbits(input));
        }
        public static int Day6Part2(string[] input)
        {
            return 0;
        }
        public static long Day7Part1(string[] input)
        {
            var amplifierControllerSoftware = input[0];
            var amplifiers = new Computer[5];
            //What is the highest signal that can be sent to the thrusters?
            return FindMaxSignal(amplifiers, amplifierControllerSoftware, new int[] { 0, 1, 2, 3, 4 });
        }
        public static int Day7Part2(string[] input)
        {
            return 0;
        }
        public static int Day8Part1(string[] input)
        {
            var layers = SeparateIntoLayers(input[0], 25 * 6);

            //To make sure the image wasn't corrupted during transmission,
            //the Elves would like you to find the layer that contains the fewest 0 digits.
            var minDigits = layers?.Select(x => new
            {
                data = x,
                zeroCount = x.Count(x => x == '0')
            })
            ?.OrderBy(x => x.zeroCount)?.FirstOrDefault();

            //On that layer, what is the number of 1 digits multiplied by the number of 2 digits?
            var oneDigits = minDigits?.data?.Count(x => x == '1') ?? 0;
            var twoDigits = minDigits?.data?.Count(x => x == '2') ?? 0;
            return oneDigits * twoDigits;
        }
        public static void Day8Part2(string[] input)
        {
            //What message is produced after decoding your image?
            var result = ConvertToImage(SeparateIntoLayers(input[0], 25 * 6), 25 * 6);
            PrintImage(result, 25);
        }

        public static long Day9Part1(string[] input)
        {
            //The BOOST program will ask for a single input; run it in test mode by providing it the value 1.
            //It will perform a series of checks on each opcode, output any opcodes(and the associated parameter modes) that seem to be functioning incorrectly,
            //and finally output a BOOST keycode.
            //Once your Intcode computer is fully functional, the BOOST program should report no malfunctioning opcodes when run in test mode;
            //it should only output a single value, the BOOST keycode.
            var computer = new Computer(input[0]);
            computer.RunIntCodeProgram(new Stack<long>(new List<long>() { 1 }));

            //What BOOST keycode does it produce?
            return computer.DiagnosticOutput.Last();
        }
        public static long Day9Part2(string[] input)
        {
            // ---Part Two-- -
            //You now have a complete Intcode computer.
            //Finally, you can lock on to the Ceres distress signal!
            //You just need to boost your sensors using the BOOST program.
            //The program runs in sensor boost mode by providing the input instruction the value 2.
            var computer = new Computer(input[0]);
            computer.RunIntCodeProgram(new Stack<long>(new List<long>() { 2 }));
            //Once run, it will boost the sensors automatically, but it might take a few seconds to complete the operation on slower hardware.
            //In sensor boost mode, the program will output a single value: the coordinates of the distress signal.
            //Run the BOOST program in sensor boost mode.
            //What are the coordinates of the distress signal?
            return computer.DiagnosticOutput.Last();
        }

        public static int Day10Part1(string[] input)
        {
            return 0;
        }
        public static int Day10Part2(string[] input)
        {
            return 0;
        }

        public static int Day11Part1(string[] input)
        {
            return 0;
        }
        public static int Day11Part2(string[] input)
        {
            return 0;
        }

        public static int Day12Part1(string[] input)
        {
            return 0;
        }
        public static int Day12Part2(string[] input)
        {
            return 0;
        }

        public static int Day13Part1(string[] input)
        {
            return 0;
        }
        public static int Day13Part2(string[] input)
        {
            return 0;
        }

        public static int Day14Part1(string[] input)
        {
            return 0;
        }
        public static int Day14Part2(string[] input)
        {
            return 0;
        }

        public static int Day15Part1(string[] input)
        {
            return 0;
        }
        public static int Day15Part2(string[] input)
        {
            return 0;
        }

        public static int Day16Part1(string[] input)
        {
            return 0;
        }
        public static int Day16Part2(string[] input)
        {
            return 0;
        }

        public static int Day17Part1(string[] input)
        {
            return 0;
        }
        public static int Day17Part2(string[] input)
        {
            return 0;
        }

        public static int Day18Part1(string[] input)
        {
            return 0;
        }
        public static int Day18Part2(string[] input)
        {
            return 0;
        }

        public static int Day19Part1(string[] input)
        {
            return 0;
        }
        public static int Day19Part2(string[] input)
        {
            return 0;
        }

        public static int Day20Part1(string[] input)
        {
            return 0;
        }
        public static int Day20Part2(string[] input)
        {
            return 0;
        }

        public static int Day21Part1(string[] input)
        {
            return 0;
        }
        public static int Day21Part2(string[] input)
        {
            return 0;
        }

        public static int Day22Part1(string[] input)
        {
            return 0;
        }
        public static int Day22Part2(string[] input)
        {
            return 0;
        }

        public static int Day23Part1(string[] input)
        {
            return 0;
        }
        public static int Day23Part2(string[] input)
        {
            return 0;
        }

        public static int Day24Part1(string[] input)
        {
            return 0;
        }
        public static int Day24Part2(string[] input)
        {
            return 0;
        }

        public static int Day25Part1(string[] input)
        {
            return 0;
        }
        public static int Day25Part2(string[] input)
        {
            return 0;
        }

        private static double CalcFuelNeeded(string[] moduleMasses)
        {
            var fuelNeeded = 0.0;
            foreach (var moduleMass in moduleMasses)
            {
                fuelNeeded += CalcFuelNeeded(double.Parse(moduleMass));
            }
            return fuelNeeded;
        }

        public static double CalcFuelNeeded(double moduleMass)
        {
            return Math.Floor(moduleMass / 3.0) - 2;
        }

        public static double CalcFuelNeededPart2(string[] moduleMasses)
        {
            var fuelNeeded = 0.0;

            foreach (var moduleMass in moduleMasses)
            {
                fuelNeeded += CalcFuelNeededPart2(double.Parse(moduleMass));
            }

            return fuelNeeded;
        }

        public static double CalcFuelNeededPart2(double moduleMass)
        {
            var fuelNeededForMass = CalcFuelNeeded(moduleMass);

            // calc fuel needed for mass of fuel
            var existingMass = fuelNeededForMass;
            while (existingMass > 0)
            {
                var moreFuelNeeded = CalcFuelNeeded(existingMass);
                if (moreFuelNeeded > 0)
                {
                    fuelNeededForMass += moreFuelNeeded;
                }
                existingMass = moreFuelNeeded;
            }
            return fuelNeededForMass;
        }
        public static int FindClosestDistanceToOrigin(string[] wire1, string[] wire2)
        {
            var wire1Path = TracePathCountingSteps(wire1);
            var wire2Path = TracePathCountingSteps(wire2);
            var crossings = FindIntersectionPoints(wire1Path, wire2Path);
            var closestPoint = crossings.Select(p => new
            {
                p.Key.X,
                p.Key.Y,
                Distance = Math.Abs(p.Key.X) + Math.Abs(p.Key.Y)
            })
                .OrderBy(x => x.Distance)
                .FirstOrDefault();

            //What is the Manhattan distance from the central port to the closest intersection?
            return closestPoint?.Distance ?? 0;
        }
        private static Dictionary<Point, int> FindIntersectionPoints(Dictionary<Point, int> wire1Path, Dictionary<Point, int> wire2Path)
        {
            var result = new Dictionary<Point, int>();
            foreach (var x in wire1Path)
            {
                if (wire2Path.ContainsKey(x.Key))
                {
                    result.Add(x.Key, x.Value + wire2Path[x.Key]);
                }
            }
            return result;
        }
        private static Dictionary<Point, int> TracePathCountingSteps(string[] wireDirections)
        {
            // Ignore the origin
            var path = new Dictionary<Point, int>();
            var previousLocationX = 0;
            var previousLocationY = 0;
            var stepCount = 0;
            foreach (var step in wireDirections)
            {
                var direction = step.Substring(0, 1);
                var distance = int.Parse(step.Substring(1));
                for (var i = 1; i <= distance; i++)
                {
                    switch (direction)
                    {
                        case "R":
                            previousLocationX++;
                            break;

                        case "L":
                            previousLocationX--;
                            break;

                        case "U":
                            previousLocationY++;
                            break;

                        case "D":
                            previousLocationY--;
                            break;
                    }

                    stepCount++;
                    var p = new Point(previousLocationX, previousLocationY);
                    if (!path.ContainsKey(p))
                    {
                        path.Add(p, stepCount);
                    }
                }
            }
            return path;
        }
        public static int FindIntersectionWithLeastSteps(string[] wire1, string[] wire2)
        {
            var wire1Path = TracePathCountingSteps(wire1);
            var wire2Path = TracePathCountingSteps(wire2);

            var crossings = FindIntersectionPoints(wire1Path, wire2Path);

            var closestPoint = crossings.Min(x => x.Value);
            return closestPoint;
        }
        public static bool MeetsCriteria(string password, int criteriaMin, int criteriaMax)
        {
            var number = int.Parse(password);

            //It is a six-digit number.
            if (number < 100000 || number > 999999)
            {
                return false;
            }
            //The value is within the range given in your puzzle input.
            if (number > criteriaMax || number < criteriaMin)
            {
                return false;
            }

            var result = false;
            for (var i = 0; i < password.Length; i++)
            {
                //Two adjacent digits are the same (like 22 in 122345).
                result |= i > 0 && password[i] == password[i - 1] || i + 1 < password.Length && password[i] == password[i + 1];
                //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
                if (i > 0 && password[i] < password[i - 1])
                {
                    return false;
                }
            }
            return result;
        }

        public static bool MeetsCriteriaUpdated(string password, int criteriaMin, int criteriaMax)
        {
            var number = int.Parse(password);

            //It is a six-digit number.
            if (number < 100000 || number > 999999)
            {
                return false;
            }
            //The value is within the range given in your puzzle input.
            if (number > criteriaMax || number < criteriaMin)
            {
                return false;
            }

            char? prev = null;
            var seqCount = 1;
            var pairFound = false;
            for (var i = 0; i < password.Length; i++)
            {
                //Two adjacent digits are the same (like 22 in 122345).
                //the two adjacent matching digits are not part of a larger group of matching digits.
                if (prev.HasValue && password[i] == prev.Value)
                {
                    seqCount++;
                    if ((i == password.Length - 1 || password[i] != password[i + 1]) && seqCount == 1)
                    {
                        pairFound = true;
                    }
                }
                else
                {
                    seqCount = 0;
                }

                //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
                if (i > 0 && password[i] < password[i - 1])
                {
                    return false;
                }
                prev = password[i];
            }
            return pairFound;
        }

        public static Dictionary<string, ObjectNode> LoadOrbits(string[] allOrbits)
        {
            var allObjects = new Dictionary<string, ObjectNode>();
            //In the map data, this orbital relationship is written AAA)BBB, which means "BBB is in orbit around AAA".
            var orbitInstructions = allOrbits;
            foreach (var oi in orbitInstructions.Where(x => x.Count() > 0))
            {
                var objects = oi.Split(')');
                var name = objects[1];
                var orbittingObjectName = objects[0];

                ObjectNode on;
                if (allObjects.ContainsKey(name))
                {
                    on = allObjects[name];
                }
                else
                {
                    on = new ObjectNode() { Name = name };
                    on.Orbitting = new LinkedList<ObjectNode>();
                    allObjects.Add(name, on);
                }

                ObjectNode orbitting;
                if (allObjects.ContainsKey(orbittingObjectName))
                {
                    orbitting = allObjects[orbittingObjectName];
                }
                else
                {
                    orbitting = new ObjectNode() { Name = orbittingObjectName };
                    orbitting.Orbitting = new LinkedList<ObjectNode>();
                    allObjects.Add(orbittingObjectName, orbitting);
                }
                on.Orbitting.AddLast(orbitting);
            }
            return allObjects;
        }
        public static int CalcOrbits(Dictionary<string, ObjectNode> allObjects)
        {
            //Whenever A orbits B and B orbits C, then A indirectly orbits C.
            //This chain can be any number of objects long: if A orbits B, B orbits C, and C orbits D, then A indirectly orbits D.
            return DepthFirstTraverse(allObjects);
        }
        public struct ObjectNode
        {
            public string Name;
            public LinkedList<ObjectNode> Orbitting;
        }
        private static int DepthFirstTraverse(Dictionary<string, ObjectNode> allObjects)
        {
            return 0;
        }

        public static long FindMaxSignal(Computer[] amplifiers, string amplifierControllerSoftware, int[] phaseSettingSequence)
        {
            //Try every combination of phase settings on the amplifiers.
            var maxSignal = long.MinValue;

            var permutations = new List<int[]>();
            Helpers.FindPermutations(phaseSettingSequence, permutations);
            foreach (var permute in permutations)
            {
                long lastOutputSignal = 0;
                maxSignal = RunProgramThroughAmplifiers(amplifiers, permute, maxSignal, ref lastOutputSignal, amplifierControllerSoftware);
            }
            return maxSignal;
        }

        public static long RunProgramThroughAmplifiers(Computer[] amplifiers, int[] amplifierInput, long maxSignal, ref long lastOutputSignal, string amplifierControllerSoftware)
        {
            for (var i = 0; i < amplifiers.Length; i++)
            {
                amplifiers[i] = new Computer(amplifierControllerSoftware);
                amplifiers[i].RunIntCodeProgram(new Stack<long>(new List<long>() { lastOutputSignal, amplifierInput[i] }));
                lastOutputSignal = amplifiers[i].DiagnosticOutput[0];
                maxSignal = Math.Max(maxSignal, lastOutputSignal);
            }
            return maxSignal;
        }

        private static void PrintImage(List<char> result, int width)
        {
            for (var i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] == '0' ? ' ' : '*');
                if (i != 0 && i % width == 0)
                {
                    Console.Write(Environment.NewLine);
                }
            }
        }

        //Break up the string into chunks of widthxheight chunks
        public static List<string> SeparateIntoLayers(string message, int layerSize)
        {
            var layers = new List<string>();
            for (var i = 0; i < message.Length; i += layerSize)
            {
                layers.Add(message.Substring(i, layerSize));
            }
            return layers;
        }

        private enum PixelColour
        {
            Black = 0,
            White = 1,
            Transparent = 2
        }

        public static List<char> ConvertToImage(List<string> layers, int layerSize)
        {
            //The image is rendered by stacking the layers and aligning the pixels with the same positions in each layer.
            //The digits indicate the color of the corresponding pixel: 0 is black, 1 is white, and 2 is transparent.
            //The layers are rendered with the first layer in front and the last layer in back.
            //So, if a given position has a transparent pixel in the first and second layers,
            //a black pixel in the third layer,
            //and a white pixel in the fourth layer,
            //the final image would have a black pixel at that position.
            var finalMessage = layers[0].ToList();

            var otherLayers = layers.Skip(1);

            for (var i = 0; i < layerSize; i++)
            {
                foreach (var layer in otherLayers)
                {
                    if ((PixelColour)int.Parse(finalMessage[i].ToString()) != PixelColour.Transparent)
                    {
                        break;
                    }
                    // If we can see through to the next layer, continue
                    if ((PixelColour)int.Parse(layer[i].ToString()) != PixelColour.Transparent)
                    {
                        finalMessage[i] = layer[i];
                    }
                }
            }

            return finalMessage.Where(x => x != 2).ToList();
        }

    }
}