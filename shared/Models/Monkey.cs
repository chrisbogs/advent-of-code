using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCodeShared.Logic.Helpers;

namespace AdventOfCodeShared.Models
{
    public class Monkey
    {
        public long Id { get; set; }
        public List<double> WorryLevelForItems { get; set; }
        public MathOperator Operation { get; set; }
        public string OperationParameter { get; set; } // could be a number or "old"
        public int Test { get; set; }
        public long TrueResult { get; set; }
        public long FalseResult { get; set; }
        public long NumberOfInspections { get; set; }

        internal void TakeTurn(ref List<Monkey> monkeys, bool divideWorryLevel = true)
        {
            List<int> indicesToDelete = new();

            // Monkey goes through it's list of items and inspects each one of them, 
            for (int i = 0; i < WorryLevelForItems.Count; i++)
            {
                var OperationParameterValue = OperationParameter.ToLower().Equals("old") 
                    ? WorryLevelForItems[i] 
                    : long.Parse(OperationParameter);

                switch (Operation)
                {
                    case MathOperator.Add:
                        WorryLevelForItems[i] += OperationParameterValue;
                        break;
                    case MathOperator.Subtract:
                        WorryLevelForItems[i] -= OperationParameterValue;
                        break;
                    case MathOperator.Multiply:
                        WorryLevelForItems[i] *= OperationParameterValue;
                        break;
                    case MathOperator.Divide:
                        WorryLevelForItems[i] /= OperationParameterValue;
                        break;
                }

                if (divideWorryLevel)
                {
                    //After each monkey inspects an item but before it tests your worry level,
                    //your relief that the monkey's inspection didn't damage the item causes
                    //your worry level to be divided by three and rounded down to the nearest integer.
                    WorryLevelForItems[i] = (long)Math.Floor(WorryLevelForItems[i] / 3.0);
                }
                else
                {
                    //var lcm = monkeys.SelectMany(x => x.WorryLevelForItems).Aggregate((x, y) => x * y);
                    WorryLevelForItems[i] = (long)Math.Log(WorryLevelForItems[i]);
                }


                // then decides which monkey to throw it to depending on the test
                if (WorryLevelForItems[i] % Test == 0)
                {
                    var throwTo = monkeys.FirstOrDefault(x => x.Id == TrueResult);
                    throwTo?.GiveItem(WorryLevelForItems[i]);
                }
                else
                {
                    var throwTo = monkeys.FirstOrDefault(x => x.Id == FalseResult);
                    throwTo?.GiveItem(WorryLevelForItems[i]);
                }
                indicesToDelete.Add(i);

                NumberOfInspections++;
            }

            // delete the higher indices first so that the lower are still valid.
            indicesToDelete.Reverse();
            foreach (var item in indicesToDelete)
            {
                WorryLevelForItems.RemoveAt(item);
            }
        }

        private void GiveItem(double item)
        {
            this.WorryLevelForItems.Add(item);
        }

        /// <summary>
        /// Accepts string in the form:
        ///Monkey 0:
        ///  Starting items: 79, 98
        ///  Operation: new = old* 19
        ///  Test: divisible by 23
        ///    If true: throw to monkey 2
        ///    If false: throw to monkey 3

        ///Monkey 1:
        ///  Starting items: 54, 65, 75, 74
        ///  Operation: new = old + 6
        ///  Test: divisible by 19
        ///    If true: throw to monkey 2
        ///    If false: throw to monkey 0
        /// </summary>
        public static List<Monkey> ParseMonkeyInTheMiddle(string[] input)
        {
            var result = new List<Monkey>();
            var currentMonkey = new Monkey();
            foreach (var line in input)
            {
                var trimmed = line.Trim();
                if (trimmed.Length == 0)
                {
                    result.Add(currentMonkey);
                    currentMonkey = new Monkey();
                }
                else
                {
                    if (trimmed.StartsWith("Monkey"))
                    {
                        currentMonkey.Id = long.Parse(trimmed.Split("Monkey")[1].Trim().Replace(":", ""));
                    }
                    else if (trimmed.StartsWith("Starting items:"))
                    {
                        currentMonkey.WorryLevelForItems = trimmed.Split("Starting items:")[1].Split(",")
                            .Select(double.Parse).ToList();
                    }
                    else if (trimmed.StartsWith("Operation: new = old"))
                    {
                        var split = trimmed.Split("Operation: new = old ");
                        var operatorSplit = split[1].Split(" ");
                        currentMonkey.Operation = (MathOperator)operatorSplit[0][0];
                        currentMonkey.OperationParameter = operatorSplit[1];
                    }
                    else if (trimmed.StartsWith("Test: divisible by "))
                    {
                        currentMonkey.Test = int.Parse(trimmed.Split("Test: divisible by ")[1]);
                    }
                    else if (trimmed.StartsWith("If true: throw to monkey "))
                    {
                        currentMonkey.TrueResult = int.Parse(trimmed.Split("If true: throw to monkey ")[1]);
                    }
                    else if (trimmed.StartsWith("If false: throw to monkey "))
                    {
                        currentMonkey.FalseResult = int.Parse(trimmed.Split("If false: throw to monkey ")[1]);
                    }
                }
            }
            result.Add(currentMonkey);

            return result;
        }
    }
}
