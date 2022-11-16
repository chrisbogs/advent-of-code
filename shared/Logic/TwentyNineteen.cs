using AdventOfCodeShared.Models.Image;
using AdventOfCodeShared.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Logic
{
    public class TwentyNineteen
    {
        public static double Day1Part1(string[] input)
        {
            return Helpers.CalcFuelNeeded(input);
        }
        public static double Day1Part2(string[] input)
        {
            return Helpers.CalcFuelNeededPart2(input);
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
            return Helpers.FindClosestDistanceToOrigin(wire1, wire2);
        }

        public static long Day3Part2(string[] input)
        {
            var wire1 = input[0].Split(",");
            var wire2 = input[1].Split(",");
            return Helpers.FindIntersectionWithLeastSteps(wire1, wire2);
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
                if (Helpers.MeetsCriteria(i.ToString(), criteriaMin, criteriaMax))
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
                if (Helpers.MeetsCriteriaUpdated(i.ToString(), criteriaMin, criteriaMax))
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
            return 0;//Helpers.CalcOrbits(Helpers.LoadOrbits(input));
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
            return Helpers.FindMaxSignal(amplifiers, amplifierControllerSoftware, new int[] { 0, 1, 2, 3, 4 });
        }
        public static int Day7Part2(string[] input)
        {
            return 0;
        }
        public static int Day8Part1(string[] input)
        {
            var layers = ImageLogic.SeparateIntoLayers(input[0], 25 * 6);

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
        public static string Day8Part2(string[] input)
        {
            //What message is produced after decoding your image?
            var result = ImageLogic.ConvertToImage(ImageLogic.SeparateIntoLayers(input[0], 25 * 6), 25 * 6);
            ImageLogic.PrintImage(result, 25);
            return string.Empty;
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
    }
}