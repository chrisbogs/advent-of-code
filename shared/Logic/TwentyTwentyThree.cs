﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCodeShared.Extensions;
using static AdventOfCodeShared.Logic.Helpers;

namespace AdventOfCodeShared.Logic
{
    public class TwentyTwentyThree
    {
        public static long Day1Part1(string[] input)
        {
            /* As they're making the final adjustments, they discover that their calibration document (your puzzle input) has been amended by a very young Elf
             who was apparently just excited to show off her art skills. 
             Consequently, the Elves are having trouble reading the values on the document.
            // The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. 
            On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.
            // For example:
            // 1abc2
            // pqr3stu8vwx
            // a1b2c3d4e5f
            // treb7uchet
            // In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.
            // Consider your entire calibration document. What is the sum of all of the calibration values?
            */
            var result = 0;
            foreach (var line in input)
            {
                var firstDigit = line.FindFirstDigit();
                var secondDigit = line.FindLastDigit();
                if (!string.IsNullOrEmpty(firstDigit)
                    && !string.IsNullOrEmpty(secondDigit)
                    && int.TryParse(firstDigit + secondDigit, out var concatenated))
                {
                    result += concatenated;
                }
            }
            return result; //54561
        }
        public static long Day1Part2(string[] input)
        {
            var result = 0;
            foreach (var line in input)
            {
                var firstDigit = line.FindFirstRepresentationOfDigit();
                var secondDigit = line.FindLastRepresentationOfDigit();
                if (!string.IsNullOrEmpty(firstDigit)
                    && !string.IsNullOrEmpty(secondDigit)
                    && int.TryParse(firstDigit + secondDigit, out var concatenated))
                {
                    result += concatenated;
                }
            }
            return result;
        }

        public static long Day2Part1(string[] input)
        {
            //             You're launched high into the atmosphere!
            //             The apex of your trajectory just barely reaches the surface of a large island floating in the sky.
            //             You gently land in a fluffy pile of leaves.
            //             It's quite cold, but you don't see much snow.
            //             An Elf runs over to greet you.
            // The Elf explains that you've arrived at Snow Island and apologizes for the lack of snow.
            // He'll be happy to explain the situation, but it's a bit of a walk, so you have some time.
            // They don't get many visitors up here; would you like to play a game in the meantime?
            // As you walk, the Elf shows you a small bag and some cubes which are either red, green, or blue.
            // Each time you play this game, he will hide a secret number of cubes of each color in the bag, and your goal is to figure out information about the number of cubes.
            // To get information, once a bag has been loaded with cubes, the Elf will reach into the bag, grab a handful of random cubes, show them to you,
            // and then put them back in the bag.
            // He'll do this a few times per game.
            // You play several games and record the information from each game (your puzzle input).
            // Each game is listed with its ID number (like the 11 in Game 11: ...)
            // followed by a semicolon-separated list of subsets of cubes that were revealed from the bag (like 3 red, 5 green, 4 blue).
            // For example, the record of a few games might look like this:
            // Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            // Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            // Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            // Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            // Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            // In game 1, three sets of cubes are revealed from the bag (and then put back again).
            // The first set is 3 blue cubes and 4 red cubes; the second set is 1 red cube, 2 green cubes, and 6 blue cubes; the third set is only 2 green cubes.

            // The Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes?

            // In the example above, games 1, 2, and 5 would have been possible if the bag had been loaded with that configuration.
            // However, game 3 would have been impossible because at one point the Elf showed you 20 red cubes at once;
            // similarly, game 4 would also have been impossible because the Elf showed you 15 blue cubes at once.
            // If you add up the IDs of the games that would have been possible, you get 8.
            // Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes.
            // What is the sum of the IDs of those games?
            var allPieces = new Dictionary<string, int>()
            {
                {"red", 12 },
                {"green", 13 },
                {"blue", 14 },
            };
            
            var result = 0;
            foreach (var game in input)
            {
                //Game 1: 2 blue, 3 red; 3 green, 3 blue, 6 red; 4 blue, 6 red; 2 green, 2 blue, 9 red; 2 red, 4 blue
                var afterGame = game.Split("Game ");
                if (afterGame.Length < 1) continue;

                var afterGameId = afterGame[1].Split(":");
                if (afterGameId.Length < 1) continue;

                int.TryParse(afterGameId[0].Trim(), out int gameId);
                // parse games and build a dictionary of pieces

                var pieces = new Dictionary<string, int>();
                foreach (var sets in afterGameId[1].Trim().Split(";"))
                {
                    foreach (var x in sets.Trim().Split(","))
                    {
                        var parts = x.Trim().Split(" ");
                        int.TryParse(parts[0].Trim(), out int count);
                        var colour = parts[1].Trim().ToLower();

                        if (pieces.ContainsKey(colour))
                        {
                            pieces[colour] = Math.Max(pieces[colour], count);
                        }
                        else
                        {
                            pieces.Add(colour, count);
                        }
                    }
                }

                var isSubSet = IsSubSet(pieces, allPieces);
                if (isSubSet)
                {
                    result += gameId;
                }
            }

            return result;//3059
        }
        public static long Day2Part2(string[] input)
        {
            //            The Elf says they've stopped producing snow because they aren't getting any water!He isn't sure why the water stopped; however, he can show you how to get to the water source to check it out for yourself. It's just up ahead!

            //As you continue your walk, the Elf poses a second question: in each game you played, what is the fewest number of cubes of each color that could have been in the bag to make the game possible?

            //Again consider the example games from earlier:

            //Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            //Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            //Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            //Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            //Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            //In game 1, the game could have been played with as few as 4 red, 2 green, and 6 blue cubes. If any color had even one fewer cube, the game would have been impossible.
            //Game 2 could have been played with a minimum of 1 red, 3 green, and 4 blue cubes.
            //Game 3 must have been played with at least 20 red, 13 green, and 6 blue cubes.
            //Game 4 required at least 14 red, 3 green, and 15 blue cubes.
            //Game 5 needed no fewer than 6 red, 3 green, and 2 blue cubes in the bag.
            //The power of a set of cubes is equal to the numbers of red, green, and blue cubes multiplied together. The power of the minimum set of cubes in game 1 is 48.In games 2 - 5 it was 12, 1560, 630, and 36, respectively.Adding up these five powers produces the sum 2286.

            //For each game, find the minimum set of cubes that must have been present.What is the sum of the power of these sets?

            var result = 0;
            foreach (var game in input)
            {
                //Game 1: 2 blue, 3 red; 3 green, 3 blue, 6 red; 4 blue, 6 red; 2 green, 2 blue, 9 red; 2 red, 4 blue
                var afterGame = game.Split("Game ");
                if (afterGame.Length < 1) continue;

                var afterGameId = afterGame[1].Split(":");
                if (afterGameId.Length < 1) continue;

                int.TryParse(afterGameId[0].Trim(), out int gameId);
                // parse games and build a dictionary of pieces

                var pieces = new Dictionary<string, int>();
                foreach (var sets in afterGameId[1].Trim().Split(";"))
                {
                    foreach (var x in sets.Trim().Split(","))
                    {
                        var parts = x.Trim().Split(" ");
                        int.TryParse(parts[0].Trim(), out int count);
                        var colour = parts[1].Trim().ToLower();

                        if (pieces.ContainsKey(colour))
                        {
                            pieces[colour] = Math.Max(pieces[colour], count);
                        }
                        else
                        {
                            pieces.Add(colour, count);
                        }
                    }
                }
                if (pieces.Any())
                {
                    var powers = 1;
                    foreach (int i in pieces.Values)
                    {
                        powers *= i;
                    }
                    result += powers;
                }
            }

            return result;//65371
        }

        public static long Day3Part1(string[] input)
        {
            // You and the Elf eventually reach a gondola lift station; he says the gondola lift will take you up to the water source, but this is as far as he can bring you. You go inside.
            // It doesn't take long to find the gondolas, but there seems to be a problem: they're not moving.
            // "Aaah!"
            // You turn around to see a slightly-greasy Elf with a wrench and a look of surprise. "Sorry, I wasn't expecting anyone!
            // The gondola lift isn't working right now; it'll still be a while before I can fix it." You offer to help.
            // The engineer explains that an engine part seems to be missing from the engine, but nobody can figure out which one.
            // If you can add up all the part numbers in the engine schematic, it should be easy to work out which part is missing.
            // The engine schematic (your puzzle input) consists of a visual representation of the engine.
            // There are lots of numbers and symbols you don't really understand, but apparently any number adjacent to a symbol,
            // even diagonally, is a "part number" and should be included in your sum.
            // (Periods (.) do not count as a symbol.)
            // Here is an example engine schematic:
            // 467..114..
            // ...*......
            // ..35..633.
            // ......#...
            // 617*......
            // .....+.58.
            // ..592.....
            // ......755.
            // ...$.*....
            // .664.598..
            // In this schematic, two numbers are not part numbers because they are not adjacent to a symbol: 114 (top right) and 58 (middle right).
            // Every other number is adjacent to a symbol and so is a part number; their sum is 4361.
            // Of course, the actual engine schematic is much larger.
            // What is the sum of all of the part numbers in the engine schematic?
            var sum = 0;
            var visited = new bool[input.Length][];
            for (int c = 0; c < input.Length; c++)
            {
                visited[c] = new bool[input[c].Length];
            }

            for (int x = 0; x < input.Length; x++)
            {
                for(int y = 0; y < input[x].Length ; y++)
                {
                    var current = input[x][y];
                    // is the character a symbol (not a . and not a digit)
                    if (!char.IsDigit(current) && current != '.')
                    {
                        // find any digits adjacent to that index in the following 8 spots
                        // 1 2 3
                        // 4 * 5
                        // 6 7 8
                        if (x > 0 && y > 0 && char.IsDigit(input[x - 1][y - 1])) { sum += FindRestOfNumberInRow(input, x - 1, y - 1, visited); }
                        if (x > 0 && char.IsDigit(input[x - 1][y])) { sum += FindRestOfNumberInRow(input, x - 1, y, visited); }
                        if (x > 0 && y < input[x].Length && char.IsDigit(input[x - 1][y + 1])) { sum += FindRestOfNumberInRow(input, x - 1, y + 1, visited); }
                        if (y > 0 && char.IsDigit(input[x][y - 1])) { sum += FindRestOfNumberInRow(input, x, y - 1, visited); }
                        if (y < input[x].Length && char.IsDigit(input[x][y + 1])) { sum += FindRestOfNumberInRow(input, x, y + 1, visited); }
                        if (x < input.Length && y > 0 && char.IsDigit(input[x + 1][y - 1])) { sum += FindRestOfNumberInRow(input, x + 1, y - 1, visited); }
                        if (x < input.Length && char.IsDigit(input[x + 1][y])) { sum += FindRestOfNumberInRow(input, x + 1, y, visited); }
                        if (x < input.Length && y < input[x+1].Length && char.IsDigit(input[x + 1][y + 1])) { sum += FindRestOfNumberInRow(input, x + 1, y + 1, visited); }
                    }
                }
            }

            return sum;//514969
        }
        public static long Day3Part2(string[] input)
        {
            // The engineer finds the missing part and installs it in the engine!
            // As the engine springs to life, you jump in the closest gondola, finally ready to ascend to the water source.
            //You don't seem to be going very fast, though. Maybe something is still wrong?
            //Fortunately, the gondola has a phone labeled "help", so you pick it up and the engineer answers.
            //Before you can explain the situation, she suggests that you look out the window.
            //There stands the engineer, holding a phone in one hand and waving with the other.
            //You're going so slowly that you haven't even left the station. You exit the gondola.
            //The missing part wasn't the only issue - one of the gears in the engine is wrong.
            //A gear is any * symbol that is adjacent to exactly two part numbers.
            //Its gear ratio is the result of multiplying those two numbers together.
            //This time, you need to find the gear ratio of every gear and add them all up so that the engineer can figure
            //out which gear needs to be replaced.
            //Consider the same engine schematic again:
            //467..114.....*........35..633.
            //          ......#...
            //617 * ...........+.58.
            //            ..592.....
            //......755.
            //...$.*.....664.598..
            //In this schematic, there are two gears.
            //The first is in the top left; it has part numbers 467 and 35, so its gear ratio is 16345.
            //The second gear is in the lower right; its gear ratio is 451490.
            //(The * adjacent to 617 is not a gear because it is only adjacent to one part number.)
            //Adding up all of the gear ratios produces 467835.
            //What is the sum of all of the gear ratios in your engine schematic ?
            var sum = 0;
            var visited = new bool[input.Length][];
            for (int c = 0; c < input.Length; c++)
            {
                visited[c] = new bool[input[c].Length];
            }

            var numbers = new Dictionary<Point, List<int>>();
            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < input[x].Length; y++)
                {
                    var current = input[x][y];
                    // is the character a symbol (not a . and not a digit)
                    if (!char.IsDigit(current) && current != '.' && current == '*')
                    {
                        // find any digits adjacent to that index in the following 8 spots
                        // 1 2 3
                        // 4 * 5
                        // 6 7 8
                        if (x > 0 && y > 0 && char.IsDigit(input[x - 1][y - 1]))
                        {
                            var number = FindRestOfNumberInRow(input, x - 1, y - 1, visited);
                            if (number > 0)
                            {
                                numbers.AddAggregate(new Point(x, y), number);
                            }
                        }
                        if (x > 0 && char.IsDigit(input[x - 1][y]))
                        {
                            var number = FindRestOfNumberInRow(input, x - 1, y, visited);
                            if (number > 0)
                            {
                                numbers.AddAggregate(new Point(x, y), number);
                            }
                        }
                        if (x > 0 && y < input[x].Length && char.IsDigit(input[x - 1][y + 1]))
                        {
                            var number = FindRestOfNumberInRow(input, x - 1, y + 1, visited);
                            if (number > 0)
                            {
                                numbers.AddAggregate(new Point(x, y), number);
                            }
                        }
                        if (y > 0 && char.IsDigit(input[x][y - 1]))
                        {
                            var number = FindRestOfNumberInRow(input, x, y - 1, visited);
                            if (number > 0)
                            {
                                numbers.AddAggregate(new Point(x, y), number);
                            }
                        }
                        if (y < input[x].Length && char.IsDigit(input[x][y + 1]))
                        {
                            var number = FindRestOfNumberInRow(input, x, y + 1, visited);
                            if (number > 0)
                            {
                                numbers.AddAggregate(new Point(x, y), number);
                            }
                        }
                        if (x < input.Length && y > 0 && char.IsDigit(input[x + 1][y - 1]))
                        {
                            var number = FindRestOfNumberInRow(input, x + 1, y - 1, visited);
                            if (number > 0)
                            {
                                numbers.AddAggregate(new Point(x, y), number);
                            }
                        }
                        if (x < input.Length && char.IsDigit(input[x + 1][y]))
                        {
                            var number = FindRestOfNumberInRow(input, x + 1, y, visited);
                            if (number > 0)
                            {
                                numbers.AddAggregate(new Point(x, y), number);
                            }
                        }
                        if (x < input.Length && y < input[x + 1].Length && char.IsDigit(input[x + 1][y + 1]))
                        {
                            var number = FindRestOfNumberInRow(input, x + 1, y + 1, visited);
                            if (number > 0)
                            {
                                numbers.AddAggregate(new Point(x, y), number);
                            }
                        }
                    }
                }
            }
            foreach (var number in numbers)
            {
                if (number.Value.Count == 2)
                {
                    sum += number.Value[0] * number.Value[1];
                }
            }

            return sum;//78915902
        }

        public static long Day4Part1(string[] input)
        {
            // The gondola takes you up. Strangely, though, the ground doesn't seem to be coming with you; you're not climbing a mountain.
            // As the circle of Snow Island recedes below you, an entire new landmass suddenly appears above you!
            // The gondola carries you to the surface of the new island and lurches into the station.
            // As you exit the gondola, the first thing you notice is that the air here is much warmer than it was on Snow Island.
            // It's also quite humid. Is this where the water source is?
            // The next thing you notice is an Elf sitting on the floor across the station in what seems to be a pile of colorful square cards.
            // "Oh! Hello!" The Elf excitedly runs over to you. "How may I be of service?" You ask about water sources.
            // "I'm not sure; I just operate the gondola lift. That does sound like something we'd have, though - this is Island Island, after all!
            // I bet the gardener would know. He's on a different island, though - er, the small kind surrounded by water, not the floating kind.
            // We really need to come up with a better naming scheme. Tell you what: if you can help me with something quick,
            // I'll let you borrow my boat and you can go visit the gardener. I got all these scratchcards as a gift, but I can't figure out what I've won."
            // The Elf leads you over to the pile of colorful cards.
            // There, you discover dozens of scratchcards, all with their opaque covering already scratched off.
            // Picking one up, it looks like each card has two lists of numbers separated by a vertical bar (|): a list of winning numbers
            // and then a list of numbers you have. You organize the information into a table (your puzzle input).
            // As far as the Elf has been able to figure out, you have to figure out which of the numbers you have appear in the list of winning numbers.
            // The first match makes the card worth one point and each match after the first doubles the point value of that card.
            // For example:
            // Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            // Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            // Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            // Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            // Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            // Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            // In the above example, card 1 has five winning numbers (41, 48, 83, 86, and 17) and eight numbers you have (83, 86, 6, 31, 17, 9, 48, and 53).
            // Of the numbers you have, four of them (48, 83, 17, and 86) are winning numbers!
            // That means card 1 is worth 8 points (1 for the first match, then doubled three times for each of the three matches after the first).
            // Card 2 has two winning numbers (32 and 61), so it is worth 2 points.
            // Card 3 has two winning numbers (1 and 21), so it is worth 2 points.
            // Card 4 has one winning number (84), so it is worth 1 point.
            // Card 5 has no winning numbers, so it is worth no points.
            // Card 6 has no winning numbers, so it is worth no points.
            // So, in this example, the Elf's pile of scratchcards is worth 13 points.
            // Take a seat in the large pile of colorful cards. How many points are they worth in total?
            int score = 0;
            //Parse all cards
            foreach(var line in input)
            {
                // ignore the "Card x:
                var applicableText = line.Split(":")[1];
                int cardScore = 0;
                var parts = applicableText.Split("|");
                var winningNums = parts[0].ParseIntsOnLine();
                var myNums = parts[1].ParseIntsOnLine();

                foreach (var winner in winningNums)
                {
                    if (myNums.Contains(winner))
                    {
                        cardScore = cardScore == 0 ? 1 : cardScore * 2;
                    }
                }
                score += cardScore;
            }
            return score;//26914
        }
        public static long Day4Part2(string[] input)
        {
            //Just as you're about to report your findings to the Elf, one of you realizes that the rules have actually been printed on the back of every card this whole time.
            //There's no such thing as "points". Instead, scratchcards only cause you to win more scratchcards equal to the number of winning numbers you have.
            //Specifically, you win copies of the scratchcards below the winning card equal to the number of matches.
            //So, if card 10 were to have 5 matching numbers, you would win one copy each of cards 11, 12, 13, 14, and 15.
            //Copies of scratchcards are scored like normal scratchcards and have the same card number as the card they copied.
            //So, if you win a copy of card 10 and it has 5 matching numbers, it would then win a copy of the same cards that the original card 10 won: cards 11, 12, 13, 14, and 15.
            //This process repeats until none of the copies cause you to win any more cards. (Cards will never make you copy a card past the end of the table.)
            //This time, the above example goes differently:
            //Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            //Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            //Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            //Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            //Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            //Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            //Card 1 has four matching numbers, so you win one copy each of the next four cards: cards 2, 3, 4, and 5.
            //Your original card 2 has two matching numbers, so you win one copy each of cards 3 and 4.
            //Your copy of card 2 also wins one copy each of cards 3 and 4.
            //Your four instances of card 3(one original and three copies) have two matching numbers, so you win four copies each of cards 4 and 5.
            //Your eight instances of card 4(one original and seven copies) have one matching number, so you win eight copies of card 5.
            //Your fourteen instances of card 5(one original and thirteen copies) have no matching numbers and win no more cards.
            //Your one instance of card 6(one original) has no matching numbers and wins no more cards.
            //Once all of the originals and copies have been processed, you end up with 1 instance of card 1, 2 instances of card 2, 4 instances of card 3, 8 instances of card 4, 14 instances of card 5, and 1 instance of card 6.
            //In total, this example pile of scratchcards causes you to ultimately have 30 scratchcards!
            //Process all of the original and copied scratchcards until no more scratchcards are won.
            //Including the original set of scratchcards, how many total scratchcards do you end up with ?

            Dictionary<int, int> cardCounts = new(); // how many of each card we have
            Dictionary<int, (int, int)> cardScores = new(); // score and matching nums per card
            Dictionary<int, List<int>> cardWinningNums = new();
            Dictionary<int, List<int>> cardMyNums = new();

            foreach (var line in input)
            {
                // ignore the "Card x:
                var partsA = line.Split(":");
                var card_num = partsA[0].Split("Card ");

                int cardNumber = int.Parse(card_num[1]);
                var partsB = partsA[1].Split("|");
                var winningNums = partsB[0].ParseIntsOnLine();
                var myNums = partsB[1].ParseIntsOnLine();
                cardCounts[cardNumber] = 1;
                cardWinningNums[cardNumber] = winningNums;
                cardMyNums[cardNumber] = myNums;
                cardScores[cardNumber] = CalculateLotteryCardScore(winningNums, myNums);
            }

            ProcessLotteryCard(cardCounts.Keys.ToHashSet(), cardCounts, cardScores, cardWinningNums, cardMyNums);

            return cardCounts.Sum(x => x.Value);//13080971
        }

        private static void ProcessLotteryCard(
            HashSet<int> newCardIds,
            Dictionary<int, int> cardCounts, 
            Dictionary<int, (int, int)> cardScores, 
            Dictionary<int, List<int>> cardWinningNums, 
            Dictionary<int, List<int>> cardMyNums)
        {
            foreach (var key in newCardIds)
            {
                // base case is score is 0, matching nums are 0
                (var _, var matchingNums) = cardScores[key];

                for (int i = 1; i <= matchingNums; i++)
                {
                    if (i + 1 <= cardScores.Keys.Count)
                    {
                        cardCounts[key + i]++;
                        ProcessLotteryCard(new HashSet<int>() { key + i }, cardCounts, cardScores, cardWinningNums, cardMyNums);
                    }
                }
            }
        }

        /// <summary>
        /// Returns card score, and number of matching numbers.
        /// </summary>
        private static (int, int) CalculateLotteryCardScore(List<int> winningNums, List<int> myNums)
        {
            (int cardScore, int matchingNums ) = (0, 0);
            foreach (var winner in winningNums)
            {
                if (myNums.Contains(winner))
                {
                    cardScore = cardScore == 0 ? 1 : cardScore * 2;
                    matchingNums++;
                }
            }

            return (cardScore, matchingNums);
        }

        public static long Day5Part1(string[] input)
        {
            //             You take the boat and find the gardener right where you were told he would be: managing a giant "garden" that looks more to you like a farm.

            // "A water source? Island Island is the water source!" You point out that Snow Island isn't receiving any water.

            // "Oh, we had to stop the water because we ran out of sand to filter it with! Can't make snow with dirty water. Don't worry, I'm sure we'll get more sand soon; we only turned off the water a few days... weeks... oh no." His face sinks into a look of horrified realization.

            // "I've been so busy making sure everyone here has food that I completely forgot to check why we stopped getting more sand! There's a ferry leaving soon that is headed over in that direction - it's much faster than your boat. Could you please go check it out?"

            // You barely have time to agree to this request when he brings up another. "While you wait for the ferry, maybe you can help us with our food production problem. The latest Island Island Almanac just arrived and we're having trouble making sense of it."

            // The almanac (your puzzle input) lists all of the seeds that need to be planted. It also lists what type of soil to use with each kind of seed, what type of fertilizer to use with each kind of soil, what type of water to use with each kind of fertilizer, and so on. Every type of seed, soil, fertilizer and so on is identified with a number, but numbers are reused by each category - that is, soil 123 and fertilizer 123 aren't necessarily related to each other.

            // For example:

            // seeds: 79 14 55 13

            // seed-to-soil map:
            // 50 98 2
            // 52 50 48

            // soil-to-fertilizer map:
            // 0 15 37
            // 37 52 2
            // 39 0 15

            // fertilizer-to-water map:
            // 49 53 8
            // 0 11 42
            // 42 0 7
            // 57 7 4

            // water-to-light map:
            // 88 18 7
            // 18 25 70

            // light-to-temperature map:
            // 45 77 23
            // 81 45 19
            // 68 64 13

            // temperature-to-humidity map:
            // 0 69 1
            // 1 0 69

            // humidity-to-location map:
            // 60 56 37
            // 56 93 4
            // The almanac starts by listing which seeds need to be planted: seeds 79, 14, 55, and 13.

            // The rest of the almanac contains a list of maps which describe how to convert numbers from a source category into numbers in a destination category. That is, the section that starts with seed-to-soil map: describes how to convert a seed number (the source) to a soil number (the destination). This lets the gardener and his team know which soil to use with which seeds, which water to use with which fertilizer, and so on.

            // Rather than list every source number and its corresponding destination number one by one, the maps describe entire ranges of numbers that can be converted. Each line within a map contains three numbers: the destination range start, the source range start, and the range length.

            // Consider again the example seed-to-soil map:

            // 50 98 2
            // 52 50 48
            // The first line has a destination range start of 50, a source range start of 98, and a range length of 2. This line means that the source range starts at 98 and contains two values: 98 and 99. The destination range is the same length, but it starts at 50, so its two values are 50 and 51. With this information, you know that seed number 98 corresponds to soil number 50 and that seed number 99 corresponds to soil number 51.

            // The second line means that the source range starts at 50 and contains 48 values: 50, 51, ..., 96, 97. This corresponds to a destination range starting at 52 and also containing 48 values: 52, 53, ..., 98, 99. So, seed number 53 corresponds to soil number 55.

            // Any source numbers that aren't mapped correspond to the same destination number. So, seed number 10 corresponds to soil number 10.

            // So, the entire list of seed numbers and their corresponding soil numbers looks like this:

            // seed  soil
            // 0     0
            // 1     1
            // ...   ...
            // 48    48
            // 49    49
            // 50    52
            // 51    53
            // ...   ...
            // 96    98
            // 97    99
            // 98    50
            // 99    51
            // With this map, you can look up the soil number required for each initial seed number:

            // Seed number 79 corresponds to soil number 81.
            // Seed number 14 corresponds to soil number 14.
            // Seed number 55 corresponds to soil number 57.
            // Seed number 13 corresponds to soil number 13.
            // The gardener and his team want to get started as soon as possible, so they'd like to know the closest location that needs a seed. Using these maps, find the lowest location number that corresponds to any of the initial seeds. To do this, you'll need to convert each seed number through other categories until you can find its corresponding location number. In this example, the corresponding types are:

            // Seed 79, soil 81, fertilizer 81, water 81, light 74, temperature 78, humidity 78, location 82.
            // Seed 14, soil 14, fertilizer 53, water 49, light 42, temperature 42, humidity 43, location 43.
            // Seed 55, soil 57, fertilizer 57, water 53, light 46, temperature 82, humidity 82, location 86.
            // Seed 13, soil 13, fertilizer 52, water 41, light 34, temperature 34, humidity 35, location 35.
            // So, the lowest location number in this example is 35.

            // What is the lowest location number that corresponds to any of the initial seed numbers?
            return 0;
        }
        public static long Day5Part2(string[] input)
        {
            return 0;
        }

        public static long Day6Part1(string[] input)
        {
//            ---Day 6: Wait For It-- -
//The ferry quickly brings you across Island Island.After asking around, you discover that there is indeed normally a large pile of sand somewhere near here, but you don't see anything besides lots of water and the small island where the ferry has docked.

//As you try to figure out what to do next, you notice a poster on a wall near the ferry dock. "Boat races! Open to the public! Grand prize is an all-expenses-paid trip to Desert Island!" That must be where the sand comes from!Best of all, the boat races are starting in just a few minutes.

//You manage to sign up as a competitor in the boat races just in time.The organizer explains that it's not really a traditional race - instead, you will get a fixed amount of time during which your boat has to travel as far as it can, and you win if your boat goes the farthest.

//As part of signing up, you get a sheet of paper(your puzzle input) that lists the time allowed for each race and also the best distance ever recorded in that race.To guarantee you win the grand prize, you need to make sure you go farther in each race than the current record holder.

//The organizer brings you over to the area where the boat races are held.The boats are much smaller than you expected - they're actually toy boats, each with a big button on top. Holding down the button charges the boat, and releasing the button allows the boat to move. Boats move faster if their button was held longer, but time spent holding the button counts against the total race time. You can only hold the button at the start of the race, and boats don't move until the button is released.

//For example:

//Time:      7  15   30
//Distance:  9  40  200
//This document describes three races:

//The first race lasts 7 milliseconds.The record distance in this race is 9 millimeters.
//The second race lasts 15 milliseconds.The record distance in this race is 40 millimeters.
//The third race lasts 30 milliseconds.The record distance in this race is 200 millimeters.
//Your toy boat has a starting speed of zero millimeters per millisecond.For each whole millisecond you spend at the beginning of the race holding down the button, the boat's speed increases by one millimeter per millisecond.

//So, because the first race lasts 7 milliseconds, you only have a few options:

//Don't hold the button at all (that is, hold it for 0 milliseconds) at the start of the race. The boat won't move; it will have traveled 0 millimeters by the end of the race.
//Hold the button for 1 millisecond at the start of the race.Then, the boat will travel at a speed of 1 millimeter per millisecond for 6 milliseconds, reaching a total distance traveled of 6 millimeters.
//Hold the button for 2 milliseconds, giving the boat a speed of 2 millimeters per millisecond.It will then get 5 milliseconds to move, reaching a total distance of 10 millimeters.
//Hold the button for 3 milliseconds.After its remaining 4 milliseconds of travel time, the boat will have gone 12 millimeters.
//Hold the button for 4 milliseconds.After its remaining 3 milliseconds of travel time, the boat will have gone 12 millimeters.
//Hold the button for 5 milliseconds, causing the boat to travel a total of 10 millimeters.
//Hold the button for 6 milliseconds, causing the boat to travel a total of 6 millimeters.
//Hold the button for 7 milliseconds.That's the entire duration of the race. You never let go of the button. The boat can't move until you let go of the button.Please make sure you let go of the button so the boat gets to move. 0 millimeters.
//Since the current record for this race is 9 millimeters, there are actually 4 different ways you could win: you could hold the button for 2, 3, 4, or 5 milliseconds at the start of the race.

//In the second race, you could hold the button for at least 4 milliseconds and at most 11 milliseconds and beat the record, a total of 8 different ways to win.

//In the third race, you could hold the button for at least 11 milliseconds and no more than 19 milliseconds and still beat the record, a total of 9 ways you could win.

//To see how much margin of error you have, determine the number of ways you can beat the record in each race; in this example, if you multiply these values together, you get 288(4 * 8 * 9).

//Determine the number of ways you could beat the record in each race. What do you get if you multiply these numbers together?
            return 0;
        }
        public static long Day6Part2(string[] input)
        {
            return 0;
        }

        public static long Day7Part1(string[] input)
        {
//            ---Day 7: Camel Cards ---
//Your all - expenses - paid trip turns out to be a one-way, five - minute ride in an airship. (At least it's a cool airship!) It drops you off at the edge of a vast desert and descends back to Island Island.

//"Did you bring the parts?"

//You turn around to see an Elf completely covered in white clothing, wearing goggles, and riding a large camel.

//"Did you bring the parts?" she asks again, louder this time.You aren't sure what parts she's looking for; you're here to figure out why the sand stopped.

//"The parts! For the sand, yes! Come with me; I will show you." She beckons you onto the camel.

//After riding a bit across the sands of Desert Island, you can see what look like very large rocks covering half of the horizon.The Elf explains that the rocks are all along the part of Desert Island that is directly above Island Island, making it hard to even get there.Normally, they use big machines to move the rocks and filter the sand, but the machines have broken down because Desert Island recently stopped receiving the parts they need to fix the machines.
//            You've already assumed it'll be your job to figure out why the parts stopped when she asks if you can help. You agree automatically.

//Because the journey will take a few days, she offers to teach you the game of Camel Cards.Camel Cards is sort of similar to poker except it's designed to be easier to play while riding a camel.

//In Camel Cards, you get a list of hands, and your goal is to order them based on the strength of each hand. A hand consists of five cards labeled one of A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, or 2.The relative strength of each card follows this order, where A is the highest and 2 is the lowest.

//Every hand is exactly one type.From strongest to weakest, they are:
//            Five of a kind, where all five cards have the same label: AAAAA
//            Four of a kind, where four cards have the same label and one card has a different label: AA8AA
//            Full house, where three cards have the same label, and the remaining two cards share a different label: 23332
//Three of a kind, where three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
//            Two pair, where two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
//One pair, where two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
//            High card, where all cards' labels are distinct: 23456
//Hands are primarily ordered based on type; for example, every full house is stronger than any three of a kind.

//If two hands have the same type, a second ordering rule takes effect.Start by comparing the first card in each hand.If these cards are different, the hand with the stronger first card is considered stronger. If the first card in each hand have the same label, however, then move on to considering the second card in each hand.If they differ, the hand with the higher second card wins; otherwise, continue with the third card in each hand, then the fourth, then the fifth.

//So, 33332 and 2AAAA are both four of a kind hands, but 33332 is stronger because its first card is stronger.Similarly, 77888 and 77788 are both a full house, but 77888 is stronger because its third card is stronger(and both hands have the same first and second card).

//To play Camel Cards, you are given a list of hands and their corresponding bid(your puzzle input). For example:

//32T3K 765
//T55J5 684
//KK677 28
//KTJJT 220
//QQQJA 483
//This example shows five hands; each hand is followed by its bid amount.Each hand wins an amount equal to its bid multiplied by its rank, where the weakest hand gets rank 1, the second-weakest hand gets rank 2, and so on up to the strongest hand. Because there are five hands in this example, the strongest hand will have rank 5 and its bid will be multiplied by 5.
//            So, the first step is to put the hands in order of strength:
//            32T3K is the only one pair and the other hands are all a stronger type, so it gets rank 1.
//            KK677 and KTJJT are both two pair. Their first cards both have the same label, but the second card of KK677 is stronger(K vs T), so KTJJT gets rank 2 and KK677 gets rank 3.
//            T55J5 and QQQJA are both three of a kind. QQQJA has a stronger first card, so it gets rank 5 and T55J5 gets rank 4.
//            Now, you can determine the total winnings of this set of hands by adding up the result of multiplying each hand's bid with its rank (765 * 1 + 220 * 2 + 28 * 3 + 684 * 4 + 483 * 5). So the total winnings in this example are 6440.

//Find the rank of every hand in your set. What are the total winnings ?
            return 0;
        }
        public static long Day7Part2(string[] input)
        {
            return 0;
        }
        public static long Day8Part1(string[] input)
        {
//            ---Day 8: Haunted Wasteland ---
//You're still riding a camel across Desert Island when you spot a sandstorm quickly approaching. When you turn to warn the Elf, she disappears before your eyes! To be fair, she had just finished warning you about ghosts a few minutes ago.

//One of the camel's pouches is labeled "maps" - sure enough, it's full of documents(your puzzle input) about how to navigate the desert. At least, you're pretty sure that's what they are; one of the documents contains a list of left / right instructions, and the rest of the documents seem to describe some kind of network of labeled nodes.

//It seems like you're meant to use the left/right instructions to navigate the network. Perhaps if you have the camel follow the same instructions, you can escape the haunted wasteland!

//After examining the maps for a bit, two nodes stick out: AAA and ZZZ.You feel like AAA is where you are now, and you have to follow the left / right instructions until you reach ZZZ.

//This format defines each node of the network individually.For example:

//RL

//AAA = (BBB, CCC)
//BBB = (DDD, EEE)
//CCC = (ZZZ, GGG)
//DDD = (DDD, DDD)
//EEE = (EEE, EEE)
//GGG = (GGG, GGG)
//ZZZ = (ZZZ, ZZZ)
//Starting with AAA, you need to look up the next element based on the next left / right instruction in your input.In this example, start with AAA and go right(R) by choosing the right element of AAA, CCC.Then, L means to choose the left element of CCC, ZZZ.By following the left / right instructions, you reach ZZZ in 2 steps.

//Of course, you might not find ZZZ right away.If you run out of left / right instructions, repeat the whole sequence of instructions as necessary: RL really means RLRLRLRLRLRLRLRL... and so on.For example, here is a situation that takes 6 steps to reach ZZZ:

//LLR

//AAA = (BBB, BBB)
//BBB = (AAA, ZZZ)
//ZZZ = (ZZZ, ZZZ)
//Starting at AAA, follow the left / right instructions.How many steps are required to reach ZZZ ?
            return 0;
        }
        public static long Day8Part2(string[] input)
        {
            return 0;
        }
        public static long Day9Part1(string[] input)
        {
//            ---Day 9: Mirage Maintenance ---
//You ride the camel through the sandstorm and stop where the ghost's maps told you to stop. The sandstorm subsequently subsides, somehow seeing you standing at an oasis!

//The camel goes to get some water and you stretch your neck. As you look up, you discover what must be yet another giant floating island, this one made of metal!That must be where the parts to fix the sand machines come from.

//There's even a hang glider partially buried in the sand here; once the sun rises and heats up the sand, you might be able to use the glider and the hot air to get all the way up to the metal island!

//While you wait for the sun to rise, you admire the oasis hidden here in the middle of Desert Island.It must have a delicate ecosystem; you might as well take some ecological readings while you wait.Maybe you can report any environmental instabilities you find to someone so the oasis can be around for the next sandstorm - worn traveler.

//You pull out your handy Oasis And Sand Instability Sensor and analyze your surroundings.The OASIS produces a report of many values and how they are changing over time(your puzzle input).Each line in the report contains the history of a single value.For example:

//0 3 6 9 12 15
//1 3 6 10 15 21
//10 13 16 21 30 45
//To best protect the oasis, your environmental report should include a prediction of the next value in each history.To do this, start by making a new sequence from the difference at each step of your history.If that sequence is not all zeroes, repeat this process, using the sequence you just generated as the input sequence. Once all of the values in your latest sequence are zeroes, you can extrapolate what the next value of the original history should be.

//In the above dataset, the first history is 0 3 6 9 12 15.Because the values increase by 3 each step, the first sequence of differences that you generate will be 3 3 3 3 3.Note that this sequence has one fewer value than the input sequence because at each step it considers two numbers from the input. Since these values aren't all zero, repeat the process: the values differ by 0 at each step, so the next sequence is 0 0 0 0. This means you have enough information to extrapolate the history! Visually, these sequences can be arranged like this:

//0   3   6   9  12  15
//  3   3   3   3   3
//    0   0   0   0
//To extrapolate, start by adding a new zero to the end of your list of zeroes; because the zeroes represent differences between the two values above them, this also means there is now a placeholder in every sequence above it:

//0   3   6   9  12  15   B
//  3   3   3   3   3   A
//    0   0   0   0   0
//You can then start filling in placeholders from the bottom up.A needs to be the result of increasing 3(the value to its left) by 0(the value below it); this means A must be 3:

//0   3   6   9  12  15   B
//  3   3   3   3   3   3
//    0   0   0   0   0
//Finally, you can fill in B, which needs to be the result of increasing 15(the value to its left) by 3(the value below it), or 18:

//0   3   6   9  12  15  18
//  3   3   3   3   3   3
//    0   0   0   0   0
//So, the next value of the first history is 18.

//Finding all-zero differences for the second history requires an additional sequence:

//1   3   6  10  15  21
//  2   3   4   5   6
//    1   1   1   1
//      0   0   0
//Then, following the same process as before, work out the next value in each sequence from the bottom up:

//1   3   6  10  15  21  28
//  2   3   4   5   6   7
//    1   1   1   1   1
//      0   0   0   0
//So, the next value of the second history is 28.

//The third history requires even more sequences, but its next value can be found the same way:

//10  13  16  21  30  45  68
//   3   3   5   9  15  23
//     0   2   4   6   8
//       2   2   2   2
//         0   0   0
//So, the next value of the third history is 68.

//If you find the next value for each history in this example and add them together, you get 114.

//Analyze your OASIS report and extrapolate the next value for each history. What is the sum of these extrapolated values ?
            return 0;
        }
        public static long Day9Part2(string[] input)
        {
            return 0;
        }
        public static long Day10Part1(string[] input)
        {
//            ---Day 10: Pipe Maze ---
//You use the hang glider to ride the hot air from Desert Island all the way up to the floating metal island.This island is surprisingly cold and there definitely aren't any thermals to glide on, so you leave your hang glider behind.

//You wander around for a while, but you don't find any people or animals. However, you do occasionally find signposts labeled "Hot Springs" pointing in a seemingly consistent direction; maybe you can find someone at the hot springs and ask them where the desert-machine parts are made.

//The landscape here is alien; even the flowers and trees are made of metal.As you stop to admire some metal grass, you notice something metallic scurry away in your peripheral vision and jump into a big pipe! It didn't look like any animal you've ever seen; if you want a better look, you'll need to get ahead of it.

//Scanning the area, you discover that the entire field you're standing on is densely packed with pipes; it was hard to tell at first because they're the same metallic silver color as the "ground".You make a quick sketch of all of the surface pipes you can see(your puzzle input).

//The pipes are arranged in a two-dimensional grid of tiles:

//| is a vertical pipe connecting north and south.
//- is a horizontal pipe connecting east and west.
//L is a 90 - degree bend connecting north and east.
//J is a 90 - degree bend connecting north and west.
//7 is a 90 - degree bend connecting south and west.
//F is a 90 - degree bend connecting south and east.
//. is ground; there is no pipe in this tile.
//S is the starting position of the animal; there is a pipe on this tile, but your sketch doesn't show what shape the pipe has.
//Based on the acoustics of the animal's scurrying, you're confident the pipe that contains the animal is one large, continuous loop.

//For example, here is a square loop of pipe:

//            .....
//.F - 7.
//.|.|.
//.L - J.
//.....
//If the animal had entered this loop in the northwest corner, the sketch would instead look like this:

//.....
//.S - 7.
//.|.|.
//.L - J.
//.....
//In the above diagram, the S tile is still a 90 - degree F bend: you can tell because of how the adjacent pipes connect to it.

//Unfortunately, there are also many pipes that aren't connected to the loop! This sketch shows the same loop as above:

//- L | F7
//7S - 7 |
//L | 7 ||
//-L - J |
//L | -JF
//In the above diagram, you can still figure out which pipes form the main loop: they're the ones connected to S, pipes those pipes connect to, pipes those pipes connect to, and so on. Every pipe in the main loop connects to its two neighbors (including S, which will have exactly two pipes connecting to it, and which is assumed to connect back to those two pipes).

//Here is a sketch that contains a slightly more complex main loop:

//..F7.
//.FJ |.
//SJ.L7
//| F--J
//LJ...
//Here's the same example sketch with the extra, non-main-loop pipe tiles also shown:

//7 - F7 -
//.FJ | 7
//SJLL7
//| F--J
//LJ.LJ
//If you want to get out ahead of the animal, you should find the tile in the loop that is farthest from the starting position.Because the animal is in the pipe, it doesn't make sense to measure this by direct distance. Instead, you need to find the tile that would take the longest number of steps along the loop to reach from the starting point - regardless of which way around the loop the animal went.

//In the first example with the square loop:

//.....
//.S - 7.
//.|.|.
//.L - J.
//.....
//You can count the distance each tile in the loop is from the starting point like this:

//.....
//.012.
//.1.3.
//.234.
//.....
//In this example, the farthest point from the start is 4 steps away.

//Here's the more complex loop again:..F7.
//.FJ |.
//SJ.L7
//| F--J
//LJ...
//Here are the distances for each tile on that loop:

//..45.
//.236.
//01.78
//14567
//23...
//Find the single giant loop starting at S.How many steps along the loop does it take to get from the starting position to the point farthest from the starting position ?
            return 0;
        }
        public static long Day10Part2(string[] input)
        {
            return 0;
        }
        public static int Day11Part1(string[] input)
        {
//            ---Day 11: Cosmic Expansion ---
//You continue following signs for "Hot Springs" and eventually come across an observatory.The Elf within turns out to be a researcher studying cosmic expansion using the giant telescope here.

//He doesn't know anything about the missing machine parts; he's only visiting for this research project.However, he confirms that the hot springs are the next - closest area likely to have people; he'll even take you straight there once he's done with today's observation analysis.

//Maybe you can help him with the analysis to speed things up ?

//The researcher has collected a bunch of data and compiled the data into a single giant image(your puzzle input).The image includes empty space(.) and galaxies(#). For example:

//...#......
//.......#..
//#.........
//................#...
//.#........
//.........#
//.................#..
//#...#.....
//The researcher is trying to figure out the sum of the lengths of the shortest path between every pair of galaxies.However, there's a catch: the universe expanded in the time it took the light from those galaxies to reach the observatory.

//Due to something involving gravitational effects, only some space expands.In fact, the result is that any rows or columns that contain no galaxies should all actually be twice as big.

//In the above example, three columns and two rows contain no galaxies:

//   v  v  v...#......
// .......#..
// #.........
//> .......... <
// ......#...
// .#........
// .........#
//> .......... <
// .......#..
// #...#.....
//   ^^^These rows and columns need to be twice as big; the result of cosmic expansion therefore looks like this:

//....#........
//.........#...
//#............
//.............
//.............
//........#....
//.#...........
//............#
//.............
//.............
//.........#...
//#....#.......
//Equipped with this expanded universe, the shortest path between every pair of galaxies can be found. It can help to assign every galaxy a unique number:

//....1.................2...
//3.........................
//.............
//........4.....5...........
//............6.............
//.............
//.........7...
//8....9.......
//In these 9 galaxies, there are 36 pairs.Only count each pair once; order within the pair doesn't matter. For each pair, find any shortest path between the two galaxies using only steps that move up, down, left, or right exactly one . or # at a time. (The shortest path between two galaxies is allowed to pass through another galaxy.)

//For example, here is one of the shortest paths between galaxies 5 and 9:

//....1.................2...
//3.........................
//.............
//........4.....5...........
//.##.........6
//..##.........
//...##........
//....##...7...
//8....9.......
//This path has length 9 because it takes a minimum of nine steps to get from galaxy 5 to galaxy 9(the eight locations marked # plus the step onto galaxy 9 itself). Here are some other example shortest path lengths:

//Between galaxy 1 and galaxy 7: 15
//Between galaxy 3 and galaxy 6: 17
//Between galaxy 8 and galaxy 9: 5
//In this example, after expanding the universe, the sum of the shortest path between all 36 pairs of galaxies is 374.

//Expand the universe, then find the length of the shortest path between every pair of galaxies.What is the sum of these lengths ?
            return 0;
        }
        public static int Day11Part2(string[] input)
        {
            return 0;
        }
        public static int Day12Part1(string[] input)
        {
//            ---Day 12: Hot Springs ---
//You finally reach the hot springs!You can see steam rising from secluded areas attached to the primary, ornate building.

//As you turn to enter, the researcher stops you. "Wait - I thought you were looking for the hot springs, weren't you?" You indicate that this definitely looks like hot springs to you.

//"Oh, sorry, common mistake! This is actually the onsen! The hot springs are next door."

//You look in the direction the researcher is pointing and suddenly notice the massive metal helixes towering overhead. "This way!"

//It only takes you a few more steps to reach the main gate of the massive fenced - off area containing the springs. You go through the gate and into a small administrative building.

//"Hello! What brings you to the hot springs today? Sorry they're not very hot right now; we're having a lava shortage at the moment." You ask about the missing machine parts for Desert Island.

//"Oh, all of Gear Island is currently offline! Nothing is being manufactured at the moment, not until we get more lava to heat our forges. And our springs. The springs aren't very springy unless they're hot!"

//"Say, could you go up and see why the lava stopped flowing? The springs are too cold for normal operation, but we should be able to find one springy enough to launch you up there!"

//There's just one problem - many of the springs have fallen into disrepair, so they're not actually sure which springs would even be safe to use! Worse yet, their condition records of which springs are damaged(your puzzle input) are also damaged! You'll need to help them repair the damaged records.

//In the giant field just outside, the springs are arranged into rows.For each row, the condition records show every spring and whether it is operational(.) or damaged(#). This is the part of the condition records that is itself damaged; for some springs, it is simply unknown (?) whether the spring is operational or damaged.

//However, the engineer that produced the condition records also duplicated some of this information in a different format! After the list of springs for a given row, the size of each contiguous group of damaged springs is listed in the order those groups appear in the row.This list always accounts for every damaged spring, and each number is the entire size of its contiguous group(that is, groups are always separated by at least one operational spring: #### would always be 4, never 2,2).

//So, condition records with no unknown spring conditions might look like this:

//#.#.### 1,1,3
//.#...#....###. 1,1,3
//.#.###.#.###### 1,3,1,6
//####.#...#... 4,1,1
//#....######..#####. 1,6,5
//.###.##....# 3,2,1
//However, the condition records are partially damaged; some of the springs' conditions are actually unknown (?). For example:

//???.### 1,1,3
//.?? .. ?? ...?##. 1,1,3
//?#?#?#?#?#?#?#? 1,3,1,6
//????.#...#... 4,1,1
//????.######..#####. 1,6,5
//?###???????? 3,2,1
//Equipped with this information, it is your job to figure out how many different arrangements of operational and broken springs fit the given criteria in each row.

//In the first line(???.### 1,1,3), there is exactly one way separate groups of one, one, and three broken springs (in that order) can appear in that row: the first three unknown springs must be broken, then operational, then broken (#.#), making the whole row #.#.###.

//The second line is more interesting: .?? .. ?? ...?##. 1,1,3 could be a total of four different arrangements. The last ? must always be broken (to satisfy the final contiguous group of three broken springs), and each ?? must hide exactly one of the two broken springs. (Neither ?? could be both broken springs or they would form a single contiguous group of two; if that were true, the numbers afterward would have been 2,3 instead.) Since each ?? can either be #. or .#, there are four possible arrangements of springs.

//The last line is actually consistent with ten different arrangements!Because the first number is 3, the first and second ? must both be. (if either were #, the first number would have to be 4 or higher). However, the remaining run of unknown spring conditions have many different ways they could hold groups of two and one broken springs:

//?###???????? 3,2,1
//.###.##.#...
//.###.##..#..
//.###.##...#.
//.###.##....#
//.###..##.#..
//.###..##..#.
//.###..##...#
//.###...##.#.
//.###...##..#
//.###....##.#
//In this example, the number of possible arrangements for each row is:

//???.### 1,1,3 - 1 arrangement
//.?? .. ?? ...?##. 1,1,3 - 4 arrangements
//?#?#?#?#?#?#?#? 1,3,1,6 - 1 arrangement
//????.#...#... 4,1,1 - 1 arrangement
//????.######..#####. 1,6,5 - 4 arrangements
//?###???????? 3,2,1 - 10 arrangements
//Adding all of the possible arrangement counts together produces a total of 21 arrangements.

//For each row, count all of the different arrangements of operational and broken springs that meet the given criteria.What is the sum of those counts ?
            return 0;
        }
        public static int Day12Part2(string[] input)
        {
            return 0;
        }
        public static int Day13Part1(string[] input)
        {
//            ---Day 13: Point of Incidence-- -
//With your help, the hot springs team locates an appropriate spring which launches you neatly and precisely up to the edge of Lava Island.

//There's just one problem: you don't see any lava.

//You do see a lot of ash and igneous rock; there are even what look like gray mountains scattered around. After a while, you make your way to a nearby cluster of mountains only to discover that the valley between them is completely full of large mirrors.Most of the mirrors seem to be aligned in a consistent way; perhaps you should head in that direction?

//As you move through the valley of mirrors, you find that several of them have fallen from the large metal frames keeping them in place.The mirrors are extremely flat and shiny, and many of the fallen mirrors have lodged into the ash at strange angles. Because the terrain is all one color, it's hard to tell where it's safe to walk or where you're about to run into a mirror.

//You note down the patterns of ash(.) and rocks(#) that you see as you walk (your puzzle input); perhaps by carefully analyzing these patterns, you can figure out where the mirrors are!

//For example:

//#.##..##.
//..#.##.#.
//##......#
//##......#
//..#.##.#.
//..##..##.
//#.#.##.#.

//#...##..#
//#....#..#
//..##..###
//#####.##.
//#####.##.
//..##..###
//#....#..#
//To find the reflection in each pattern, you need to find a perfect reflection across either a horizontal line between two rows or across a vertical line between two columns.

//In the first pattern, the reflection is across a vertical line between two columns; arrows on each of the two columns point at the line between the columns:

//123456789
//    ><
//#.##..##.
//..#.##.#.
//##......#
//##......#
//..#.##.#.
//..##..##.
//#.#.##.#.
//    ><
//123456789
//In this pattern, the line of reflection is the vertical line between columns 5 and 6.Because the vertical line is not perfectly in the middle of the pattern, part of the pattern(column 1) has nowhere to reflect onto and can be ignored; every other column has a reflected column within the pattern and must match exactly: column 2 matches column 9, column 3 matches 8, 4 matches 7, and 5 matches 6.

//The second pattern reflects across a horizontal line instead:

//            1 #...##..# 1
//2 #....#..# 2
//3..##..### 3
//4v#####.##.v4
//5 ^#####.##.^5
//6..##..### 6
//7 #....#..# 7
//This pattern reflects across the horizontal line between rows 4 and 5.Row 1 would reflect with a hypothetical row 8, but since that's not in the pattern, row 1 doesn't need to match anything.The remaining rows match: row 2 matches row 7, row 3 matches row 6, and row 4 matches row 5.

//To summarize your pattern notes, add up the number of columns to the left of each vertical line of reflection; to that, also add 100 multiplied by the number of rows above each horizontal line of reflection. In the above example, the first pattern's vertical line has 5 columns to its left and the second pattern's horizontal line has 4 rows above it, a total of 405.

//Find the line of reflection in each of the patterns in your notes. What number do you get after summarizing all of your notes ?
            return 0;
        }
        public static int Day13Part2(string[] input)
        {
            return 0;
        }
        public static int Day14Part1(string[] input)
        {
//            ---Day 14: Parabolic Reflector Dish-- -
//You reach the place where all of the mirrors were pointing: a massive parabolic reflector dish attached to the side of another large mountain.

//The dish is made up of many small mirrors, but while the mirrors themselves are roughly in the shape of a parabolic reflector dish, each individual mirror seems to be pointing in slightly the wrong direction. If the dish is meant to focus light, all it's doing right now is sending it in a vague direction.

//This system must be what provides the energy for the lava!If you focus the reflector dish, maybe you can go where it's pointing and use the light to fix the lava production.

//Upon closer inspection, the individual mirrors each appear to be connected via an elaborate system of ropes and pulleys to a large metal platform below the dish.The platform is covered in large rocks of various shapes.Depending on their position, the weight of the rocks deforms the platform, and the shape of the platform controls which ropes move and ultimately the focus of the dish.

//In short: if you move the rocks, you can focus the dish.The platform even has a control panel on the side that lets you tilt it in one of four directions!The rounded rocks(O) will roll when the platform is tilted, while the cube - shaped rocks(#) will stay in place. You note the positions of all of the empty spaces (.) and rocks (your puzzle input). For example:

//O....#....
//O.OO#....#
//.....##...
//OO.#O....O
//.O.....O#.
//O.#..O.#.#
//..O..#O..O
//.......O..
//#....###..
//#OO..#....
//Start by tilting the lever so all of the rocks will slide north as far as they will go:

//OOOO.#.O..
//OO..#....#
//OO..O##..O
//O..#.OO...
//........#.
//..#....#.#
//..O..#.O.O
//..O.......
//#....###..
//#....#....
//You notice that the support beams along the north side of the platform are damaged; to ensure the platform doesn't collapse, you should calculate the total load on the north support beams.

//The amount of load caused by a single rounded rock(O) is equal to the number of rows from the rock to the south edge of the platform, including the row the rock is on. (Cube - shaped rocks(#) don't contribute to load.) So, the amount of load caused by each rock in each row is as follows:

//OOOO.#.O.. 10
//OO..#....#  9
//OO..O##..O  8
//O..#.OO...  7
//.. .. .. ..#.  6
//..#....#.#  5
//.. O..#.O.O  4
//..O.......  3
//#....###..  2
//#....#....  1
//The total load is the sum of the load caused by all of the rounded rocks. In this example, the total load is 136.

//Tilt the platform so that the rounded rocks all roll north.Afterward, what is the total load on the north support beams?
            return 0;
        }
        public static int Day14Part2(string[] input)
        {
            return 0;
        }

        public static int Day15Part1(string[] input)
        {
//            ---Day 15: Lens Library ---
//The newly - focused parabolic reflector dish is sending all of the collected light to a point on the side of yet another mountain -the largest mountain on Lava Island.As you approach the mountain, you find that the light is being collected by the wall of a large facility embedded in the mountainside.

//You find a door under a large sign that says "Lava Production Facility" and next to a smaller sign that says "Danger - Personal Protective Equipment required beyond this point".

//As you step inside, you are immediately greeted by a somewhat panicked reindeer wearing goggles and a loose - fitting hard hat. The reindeer leads you to a shelf of goggles and hard hats(you quickly find some that fit) and then further into the facility. At one point, you pass a button with a faint snout mark and the label "PUSH FOR HELP".No wonder you were loaded into that trebuchet so quickly!

//You pass through a final set of doors surrounded with even more warning signs and into what must be the room that collects all of the light from outside.As you admire the large assortment of lenses available to further focus the light, the reindeer brings you a book titled "Initialization Manual".

//"Hello!", the book cheerfully begins, apparently unaware of the concerned reindeer reading over your shoulder. "This procedure will let you bring the Lava Production Facility online - all without burning or melting anything unintended!"

//"Before you begin, please be prepared to use the Holiday ASCII String Helper algorithm (appendix 1A)." You turn to appendix 1A.The reindeer leans closer with interest.

//The HASH algorithm is a way to turn any string of characters into a single number in the range 0 to 255.To run the HASH algorithm on a string, start with a current value of 0.Then, for each character in the string starting from the beginning:

//Determine the ASCII code for the current character of the string.
//Increase the current value by the ASCII code you just determined.
//Set the current value to itself multiplied by 17.
//Set the current value to the remainder of dividing itself by 256.
//After following these steps for each character in the string in order, the current value is the output of the HASH algorithm.

//So, to find the result of running the HASH algorithm on the string HASH:

//The current value starts at 0.
//The first character is H; its ASCII code is 72.
//The current value increases to 72.
//The current value is multiplied by 17 to become 1224.
//The current value becomes 200(the remainder of 1224 divided by 256).
//The next character is A; its ASCII code is 65.
//The current value increases to 265.
//The current value is multiplied by 17 to become 4505.
//The current value becomes 153(the remainder of 4505 divided by 256).
//The next character is S; its ASCII code is 83.
//The current value increases to 236.
//The current value is multiplied by 17 to become 4012.
//The current value becomes 172(the remainder of 4012 divided by 256).
//The next character is H; its ASCII code is 72.
//The current value increases to 244.
//The current value is multiplied by 17 to become 4148.
//The current value becomes 52(the remainder of 4148 divided by 256).
//So, the result of running the HASH algorithm on the string HASH is 52.

//The initialization sequence(your puzzle input) is a comma - separated list of steps to start the Lava Production Facility.Ignore newline characters when parsing the initialization sequence. To verify that your HASH algorithm is working, the book offers the sum of the result of running the HASH algorithm on each step in the initialization sequence.

//For example:

//rn = 1,cm -,qp = 3,cm = 2,qp -,pc = 4,ot = 9,ab = 5,pc -,pc = 6,ot = 7
//This initialization sequence specifies 11 individual steps; the result of running the HASH algorithm on each of the steps is as follows:

//rn = 1 becomes 30.
//cm - becomes 253.
//qp = 3 becomes 97.
//cm = 2 becomes 47.
//qp - becomes 14.
//pc = 4 becomes 180.
//ot = 9 becomes 9.
//ab = 5 becomes 197.
//pc - becomes 48.
//pc = 6 becomes 214.
//ot = 7 becomes 231.
//In this example, the sum of these results is 1320.Unfortunately, the reindeer has stolen the page containing the expected verification number and is currently running around the facility with it excitedly.

//Run the HASH algorithm on each step in the initialization sequence.What is the sum of the results ? (The initialization sequence is one long line; be careful when copy-pasting it.)
            return 0;
        }
        public static int Day15Part2(string[] input)
        {
            return 0;
        }

        public static int Day16Part1(string[] input)
        {
            // --- Day 16: The Floor Will Be Lava ---
// With the beam of light completely focused somewhere, the reindeer leads you deeper still into the Lava Production Facility. At some point, you realize that the steel facility walls have been replaced with cave, and the doorways are just cave, and the floor is cave, and you're pretty sure this is actually just a giant cave.

// Finally, as you approach what must be the heart of the mountain, you see a bright light in a cavern up ahead. There, you discover that the beam of light you so carefully focused is emerging from the cavern wall closest to the facility and pouring all of its energy into a contraption on the opposite side.

// Upon closer inspection, the contraption appears to be a flat, two-dimensional square grid containing empty space (.), mirrors (/ and \), and splitters (| and -).

// The contraption is aligned so that most of the beam bounces around the grid, but each tile on the grid converts some of the beam's light into heat to melt the rock in the cavern.

// You note the layout of the contraption (your puzzle input). For example:

// .|...\....
// |.-.\.....
// .....|-...
// ........|.
// ..........
// .........\
// ..../.\\..
// .-.-/..|..
// .|....-|.\
// ..//.|....
// The beam enters in the top-left corner from the left and heading to the right. Then, its behavior depends on what it encounters as it moves:

// If the beam encounters empty space (.), it continues in the same direction.
// If the beam encounters a mirror (/ or \), the beam is reflected 90 degrees depending on the angle of the mirror. For instance, a rightward-moving beam that encounters a / mirror would continue upward in the mirror's column, while a rightward-moving beam that encounters a \ mirror would continue downward from the mirror's column.
// If the beam encounters the pointy end of a splitter (| or -), the beam passes through the splitter as if the splitter were empty space. For instance, a rightward-moving beam that encounters a - splitter would continue in the same direction.
// If the beam encounters the flat side of a splitter (| or -), the beam is split into two beams going in each of the two directions the splitter's pointy ends are pointing. For instance, a rightward-moving beam that encounters a | splitter would split into two beams: one that continues upward from the splitter's column and one that continues downward from the splitter's column.
// Beams do not interact with other beams; a tile can have many beams passing through it at the same time. A tile is energized if that tile has at least one beam pass through it, reflect in it, or split in it.

// In the above example, here is how the beam of light bounces around the contraption:

// >|<<<\....
// |v-.\^....
// .v...|->>>
// .v...v^.|.
// .v...v^...
// .v...v^..\
// .v../2\\..
// <->-/vv|..
// .|<<<2-|.\
// .v//.|.v..
// Beams are only shown on empty tiles; arrows indicate the direction of the beams. If a tile contains beams moving in multiple directions, the number of distinct directions is shown instead. Here is the same diagram but instead only showing whether a tile is energized (#) or not (.):

// ######....
// .#...#....
// .#...#####
// .#...##...
// .#...##...
// .#...##...
// .#..####..
// ########..
// .#######..
// .#...#.#..
// Ultimately, in this example, 46 tiles become energized.

// The light isn't energizing enough tiles to produce lava; to debug the contraption, you need to start by analyzing the current situation. With the beam starting in the top-left heading right, how many tiles end up being energized?
            return 0;
        }
        public static int Day16Part2(string[] input)
        {
            return 0;
        }

        public static int Day17Part1(string[] input)
        {
// --- Day 17: Clumsy Crucible ---
// The lava starts flowing rapidly once the Lava Production Facility is operational. As you leave, the reindeer offers you a parachute, allowing you to quickly reach Gear Island.

// As you descend, your bird's-eye view of Gear Island reveals why you had trouble finding anyone on your way up: half of Gear Island is empty, but the half below you is a giant factory city!

// You land near the gradually-filling pool of lava at the base of your new lavafall. Lavaducts will eventually carry the lava throughout the city, but to make use of it immediately, Elves are loading it into large crucibles on wheels.

// The crucibles are top-heavy and pushed by hand. Unfortunately, the crucibles become very difficult to steer at high speeds, and so it can be hard to go in a straight line for very long.

// To get Desert Island the machine parts it needs as soon as possible, you'll need to find the best way to get the crucible from the lava pool to the machine parts factory. To do this, you need to minimize heat loss while choosing a route that doesn't require the crucible to go in a straight line for too long.

// Fortunately, the Elves here have a map (your puzzle input) that uses traffic patterns, ambient temperature, and hundreds of other parameters to calculate exactly how much heat loss can be expected for a crucible entering any particular city block.

// For example:

// 2413432311323
// 3215453535623
// 3255245654254
// 3446585845452
// 4546657867536
// 1438598798454
// 4457876987766
// 3637877979653
// 4654967986887
// 4564679986453
// 1224686865563
// 2546548887735
// 4322674655533
// Each city block is marked by a single digit that represents the amount of heat loss if the crucible enters that block. The starting point, the lava pool, is the top-left city block; the destination, the machine parts factory, is the bottom-right city block. (Because you already start in the top-left block, you don't incur that block's heat loss unless you leave that block and then return to it.)

// Because it is difficult to keep the top-heavy crucible going in a straight line for very long, it can move at most three blocks in a single direction before it must turn 90 degrees left or right. The crucible also can't reverse direction; after entering each city block, it may only turn left, continue straight, or turn right.

// One way to minimize heat loss is this path:

// 2>>34^>>>1323
// 32v>>>35v5623
// 32552456v>>54
// 3446585845v52
// 4546657867v>6
// 14385987984v4
// 44578769877v6
// 36378779796v>
// 465496798688v
// 456467998645v
// 12246868655<v
// 25465488877v5
// 43226746555v>
// This path never moves more than three consecutive blocks in the same direction and incurs a heat loss of only 102.

// Directing the crucible from the lava pool to the machine parts factory, but not moving more than three consecutive blocks in the same direction, what is the least heat loss it can incur?
            return 0;
        }
        public static int Day17Part2(string[] input)
        {
            return 0;
        }

        public static int Day18Part1(string[] input)
        {
// --- Day 18: Lavaduct Lagoon ---
// Thanks to your efforts, the machine parts factory is one of the first factories up and running since the lavafall came back. However, to catch up with the large backlog of parts requests, the factory will also need a large supply of lava for a while; the Elves have already started creating a large lagoon nearby for this purpose.

// However, they aren't sure the lagoon will be big enough; they've asked you to take a look at the dig plan (your puzzle input). For example:

// R 6 (#70c710)
// D 5 (#0dc571)
// L 2 (#5713f0)
// D 2 (#d2c081)
// R 2 (#59c680)
// D 2 (#411b91)
// L 5 (#8ceee2)
// U 2 (#caa173)
// L 1 (#1b58a2)
// U 2 (#caa171)
// R 2 (#7807d2)
// U 3 (#a77fa3)
// L 2 (#015232)
// U 2 (#7a21e3)
// The digger starts in a 1 meter cube hole in the ground. They then dig the specified number of meters up (U), down (D), left (L), or right (R), clearing full 1 meter cubes as they go. The directions are given as seen from above, so if "up" were north, then "right" would be east, and so on. Each trench is also listed with the color that the edge of the trench should be painted as an RGB hexadecimal color code.

// When viewed from above, the above example dig plan would result in the following loop of trench (#) having been dug out from otherwise ground-level terrain (.):

// #######
// #.....#
// ###...#
// ..#...#
// ..#...#
// ###.###
// #...#..
// ##..###
// .#....#
// .######
// At this point, the trench could contain 38 cubic meters of lava. However, this is just the edge of the lagoon; the next step is to dig out the interior so that it is one meter deep as well:

// #######
// #######
// #######
// ..#####
// ..#####
// #######
// #####..
// #######
// .######
// .######
// Now, the lagoon can contain a much more respectable 62 cubic meters of lava. While the interior is dug out, the edges are also painted according to the color codes in the dig plan.

// The Elves are concerned the lagoon won't be large enough; if they follow their dig plan, how many cubic meters of lava could it hold?
            return 0;
        }
        public static int Day18Part2(string[] input)
        {
            return 0;
        }

        public static int Day19Part1(string[] input)
        {
//             The Elves of Gear Island are thankful for your help and send you on your way. They even have a hang glider that someone stole from Desert Island; since you're already going that direction, it would help them a lot if you would use it to get down there and return it to them.

// As you reach the bottom of the relentless avalanche of machine parts, you discover that they're already forming a formidable heap. Don't worry, though - a group of Elves is already here organizing the parts, and they have a system.

// To start, each part is rated in each of four categories:

// x: Extremely cool looking
// m: Musical (it makes a noise when you hit it)
// a: Aerodynamic
// s: Shiny
// Then, each part is sent through a series of workflows that will ultimately accept or reject the part. Each workflow has a name and contains a list of rules; each rule specifies a condition and where to send the part if the condition is true. The first rule that matches the part being considered is applied immediately, and the part moves on to the destination described by the rule. (The last rule in each workflow has no condition and always applies if reached.)

// Consider the workflow ex{x>10:one,m<20:two,a>30:R,A}. This workflow is named ex and contains four rules. If workflow ex were considering a specific part, it would perform the following steps in order:

// Rule "x>10:one": If the part's x is more than 10, send the part to the workflow named one.
// Rule "m<20:two": Otherwise, if the part's m is less than 20, send the part to the workflow named two.
// Rule "a>30:R": Otherwise, if the part's a is more than 30, the part is immediately rejected (R).
// Rule "A": Otherwise, because no other rules matched the part, the part is immediately accepted (A).
// If a part is sent to another workflow, it immediately switches to the start of that workflow instead and never returns. If a part is accepted (sent to A) or rejected (sent to R), the part immediately stops any further processing.

// The system works, but it's not keeping up with the torrent of weird metal shapes. The Elves ask if you can help sort a few parts and give you the list of workflows and some part ratings (your puzzle input). For example:

// px{a<2006:qkq,m>2090:A,rfg}
// pv{a>1716:R,A}
// lnx{m>1548:A,A}
// rfg{s<537:gd,x>2440:R,A}
// qs{s>3448:A,lnx}
// qkq{x<1416:A,crn}
// crn{x>2662:A,R}
// in{s<1351:px,qqz}
// qqz{s>2770:qs,m<1801:hdj,R}
// gd{a>3333:R,R}
// hdj{m>838:A,pv}

// {x=787,m=2655,a=1222,s=2876}
// {x=1679,m=44,a=2067,s=496}
// {x=2036,m=264,a=79,s=2244}
// {x=2461,m=1339,a=466,s=291}
// {x=2127,m=1623,a=2188,s=1013}
// The workflows are listed first, followed by a blank line, then the ratings of the parts the Elves would like you to sort. All parts begin in the workflow named in. In this example, the five listed parts go through the following workflows:

// {x=787,m=2655,a=1222,s=2876}: in -> qqz -> qs -> lnx -> A
// {x=1679,m=44,a=2067,s=496}: in -> px -> rfg -> gd -> R
// {x=2036,m=264,a=79,s=2244}: in -> qqz -> hdj -> pv -> A
// {x=2461,m=1339,a=466,s=291}: in -> px -> qkq -> crn -> R
// {x=2127,m=1623,a=2188,s=1013}: in -> px -> rfg -> A
// Ultimately, three parts are accepted. Adding up the x, m, a, and s rating for each of the accepted parts gives 7540 for the part with x=787, 4623 for the part with x=2036, and 6951 for the part with x=2127. Adding all of the ratings for all of the accepted parts gives the sum total of 19114.

// Sort through all of the parts you've been given; what do you get if you add together all of the rating numbers for all of the parts that ultimately get accepted?
            return 0;
        }
        public static int Day19Part2(string[] input)
        {
            return 0;
        }

        public static int Day20Part1(string[] input)
        {
//             With your help, the Elves manage to find the right parts and fix all of the machines. Now, they just need to send the command to boot up the machines and get the sand flowing again.

// The machines are far apart and wired together with long cables. The cables don't connect to the machines directly, but rather to communication modules attached to the machines that perform various initialization tasks and also act as communication relays.

// Modules communicate using pulses. Each pulse is either a high pulse or a low pulse. When a module sends a pulse, it sends that type of pulse to each module in its list of destination modules.

// There are several different types of modules:

// Flip-flop modules (prefix %) are either on or off; they are initially off. If a flip-flop module receives a high pulse, it is ignored and nothing happens. However, if a flip-flop module receives a low pulse, it flips between on and off. If it was off, it turns on and sends a high pulse. If it was on, it turns off and sends a low pulse.

// Conjunction modules (prefix &) remember the type of the most recent pulse received from each of their connected input modules; they initially default to remembering a low pulse for each input. When a pulse is received, the conjunction module first updates its memory for that input. Then, if it remembers high pulses for all inputs, it sends a low pulse; otherwise, it sends a high pulse.

// There is a single broadcast module (named broadcaster). When it receives a pulse, it sends the same pulse to all of its destination modules.

// Here at Desert Machine Headquarters, there is a module with a single button on it called, aptly, the button module. When you push the button, a single low pulse is sent directly to the broadcaster module.

// After pushing the button, you must wait until all pulses have been delivered and fully handled before pushing it again. Never push the button if modules are still processing pulses.

// Pulses are always processed in the order they are sent. So, if a pulse is sent to modules a, b, and c, and then module a processes its pulse and sends more pulses, the pulses sent to modules b and c would have to be handled first.

// The module configuration (your puzzle input) lists each module. The name of the module is preceded by a symbol identifying its type, if any. The name is then followed by an arrow and a list of its destination modules. For example:

// broadcaster -> a, b, c
// %a -> b
// %b -> c
// %c -> inv
// &inv -> a
// In this module configuration, the broadcaster has three destination modules named a, b, and c. Each of these modules is a flip-flop module (as indicated by the % prefix). a outputs to b which outputs to c which outputs to another module named inv. inv is a conjunction module (as indicated by the & prefix) which, because it has only one input, acts like an inverter (it sends the opposite of the pulse type it receives); it outputs to a.

// By pushing the button once, the following pulses are sent:

// button -low-> broadcaster
// broadcaster -low-> a
// broadcaster -low-> b
// broadcaster -low-> c
// a -high-> b
// b -high-> c
// c -high-> inv
// inv -low-> a
// a -low-> b
// b -low-> c
// c -low-> inv
// inv -high-> a
// After this sequence, the flip-flop modules all end up off, so pushing the button again repeats the same sequence.

// Here's a more interesting example:

// broadcaster -> a
// %a -> inv, con
// &inv -> b
// %b -> con
// &con -> output
// This module configuration includes the broadcaster, two flip-flops (named a and b), a single-input conjunction module (inv), a multi-input conjunction module (con), and an untyped module named output (for testing purposes). The multi-input conjunction module con watches the two flip-flop modules and, if they're both on, sends a low pulse to the output module.

// Here's what happens if you push the button once:

// button -low-> broadcaster
// broadcaster -low-> a
// a -high-> inv
// a -high-> con
// inv -low-> b
// con -high-> output
// b -high-> con
// con -low-> output
// Both flip-flops turn on and a low pulse is sent to output! However, now that both flip-flops are on and con remembers a high pulse from each of its two inputs, pushing the button a second time does something different:

// button -low-> broadcaster
// broadcaster -low-> a
// a -low-> inv
// a -low-> con
// inv -high-> b
// con -high-> output
// Flip-flop a turns off! Now, con remembers a low pulse from module a, and so it sends only a high pulse to output.

// Push the button a third time:

// button -low-> broadcaster
// broadcaster -low-> a
// a -high-> inv
// a -high-> con
// inv -low-> b
// con -low-> output
// b -low-> con
// con -high-> output
// This time, flip-flop a turns on, then flip-flop b turns off. However, before b can turn off, the pulse sent to con is handled first, so it briefly remembers all high pulses for its inputs and sends a low pulse to output. After that, flip-flop b turns off, which causes con to update its state and send a high pulse to output.

// Finally, with a on and b off, push the button a fourth time:

// button -low-> broadcaster
// broadcaster -low-> a
// a -low-> inv
// a -low-> con
// inv -high-> b
// con -high-> output
// This completes the cycle: a turns off, causing con to remember only low pulses and restoring all modules to their original states.

// To get the cables warmed up, the Elves have pushed the button 1000 times. How many pulses got sent as a result (including the pulses sent by the button itself)?

// In the first example, the same thing happens every time the button is pushed: 8 low pulses and 4 high pulses are sent. So, after pushing the button 1000 times, 8000 low pulses and 4000 high pulses are sent. Multiplying these together gives 32000000.

// In the second example, after pushing the button 1000 times, 4250 low pulses and 2750 high pulses are sent. Multiplying these together gives 11687500.

// Consult your module configuration; determine the number of low pulses and high pulses that would be sent after pushing the button 1000 times, waiting for all pulses to be fully handled after each push of the button. What do you get if you multiply the total number of low pulses sent by the total number of high pulses sent?
            return 0;
        }
        public static int Day20Part2(string[] input)
        {
            return 0;
        }

        public static int Day21Part1(string[] input)
        {
//             You manage to catch the airship right as it's dropping someone else off on their all-expenses-paid trip to Desert Island! It even helpfully drops you off near the gardener and his massive farm.

// "You got the sand flowing again! Great work! Now we just need to wait until we have enough sand to filter the water for Snow Island and we'll have snow again in no time."

// While you wait, one of the Elves that works with the gardener heard how good you are at solving problems and would like your help. He needs to get his steps in for the day, and so he'd like to know which garden plots he can reach with exactly his remaining 64 steps.

// He gives you an up-to-date map (your puzzle input) of his starting position (S), garden plots (.), and rocks (#). For example:

// ...........
// .....###.#.
// .###.##..#.
// ..#.#...#..
// ....#.#....
// .##..S####.
// .##..#...#.
// .......##..
// .##.#.####.
// .##..##.##.
// ...........
// The Elf starts at the starting position (S) which also counts as a garden plot. Then, he can take one step north, south, east, or west, but only onto tiles that are garden plots. This would allow him to reach any of the tiles marked O:

// ...........
// .....###.#.
// .###.##..#.
// ..#.#...#..
// ....#O#....
// .##.OS####.
// .##..#...#.
// .......##..
// .##.#.####.
// .##..##.##.
// ...........
// Then, he takes a second step. Since at this point he could be at either tile marked O, his second step would allow him to reach any garden plot that is one step north, south, east, or west of any tile that he could have reached after the first step:

// ...........
// .....###.#.
// .###.##..#.
// ..#.#O..#..
// ....#.#....
// .##O.O####.
// .##.O#...#.
// .......##..
// .##.#.####.
// .##..##.##.
// ...........
// After two steps, he could be at any of the tiles marked O above, including the starting position (either by going north-then-south or by going west-then-east).

// A single third step leads to even more possibilities:

// ...........
// .....###.#.
// .###.##..#.
// ..#.#.O.#..
// ...O#O#....
// .##.OS####.
// .##O.#...#.
// ....O..##..
// .##.#.####.
// .##..##.##.
// ...........
// He will continue like this until his steps for the day have been exhausted. After a total of 6 steps, he could reach any of the garden plots marked O:

// ...........
// .....###.#.
// .###.##.O#.
// .O#O#O.O#..
// O.O.#.#.O..
// .##O.O####.
// .##.O#O..#.
// .O.O.O.##..
// .##.#.####.
// .##O.##.##.
// ...........
// In this example, if the Elf's goal was to get exactly 6 more steps today, he could use them to reach any of 16 garden plots.

// However, the Elf actually needs to get 64 steps today, and the map he's handed you is much larger than the example map.

// Starting from the garden plot marked S on your map, how many garden plots could the Elf reach in exactly 64 steps?
            return 0;
        }
        public static int Day21Part2(string[] input)
        {
            return 0;
        }

        public static int Day22Part1(string[] input)
        {
//             Enough sand has fallen; it can finally filter water for Snow Island.

// Well, almost.

// The sand has been falling as large compacted bricks of sand, piling up to form an impressive stack here near the edge of Island Island. In order to make use of the sand to filter water, some of the bricks will need to be broken apart - nay, disintegrated - back into freely flowing sand.

// The stack is tall enough that you'll have to be careful about choosing which bricks to disintegrate; if you disintegrate the wrong brick, large portions of the stack could topple, which sounds pretty dangerous.

// The Elves responsible for water filtering operations took a snapshot of the bricks while they were still falling (your puzzle input) which should let you work out which bricks are safe to disintegrate. For example:

// 1,0,1~1,2,1
// 0,0,2~2,0,2
// 0,2,3~2,2,3
// 0,0,4~0,2,4
// 2,0,5~2,2,5
// 0,1,6~2,1,6
// 1,1,8~1,1,9
// Each line of text in the snapshot represents the position of a single brick at the time the snapshot was taken. The position is given as two x,y,z coordinates - one for each end of the brick - separated by a tilde (~). Each brick is made up of a single straight line of cubes, and the Elves were even careful to choose a time for the snapshot that had all of the free-falling bricks at integer positions above the ground, so the whole snapshot is aligned to a three-dimensional cube grid.

// A line like 2,2,2~2,2,2 means that both ends of the brick are at the same coordinate - in other words, that the brick is a single cube.

// Lines like 0,0,10~1,0,10 or 0,0,10~0,1,10 both represent bricks that are two cubes in volume, both oriented horizontally. The first brick extends in the x direction, while the second brick extends in the y direction.

// A line like 0,0,1~0,0,10 represents a ten-cube brick which is oriented vertically. One end of the brick is the cube located at 0,0,1, while the other end of the brick is located directly above it at 0,0,10.

// The ground is at z=0 and is perfectly flat; the lowest z value a brick can have is therefore 1. So, 5,5,1~5,6,1 and 0,2,1~0,2,5 are both resting on the ground, but 3,3,2~3,3,3 was above the ground at the time of the snapshot.

// Because the snapshot was taken while the bricks were still falling, some bricks will still be in the air; you'll need to start by figuring out where they will end up. Bricks are magically stabilized, so they never rotate, even in weird situations like where a long horizontal brick is only supported on one end. Two bricks cannot occupy the same position, so a falling brick will come to rest upon the first other brick it encounters.

// Here is the same example again, this time with each brick given a letter so it can be marked in diagrams:

// 1,0,1~1,2,1   <- A
// 0,0,2~2,0,2   <- B
// 0,2,3~2,2,3   <- C
// 0,0,4~0,2,4   <- D
// 2,0,5~2,2,5   <- E
// 0,1,6~2,1,6   <- F
// 1,1,8~1,1,9   <- G
// At the time of the snapshot, from the side so the x axis goes left to right, these bricks are arranged like this:

//  x
// 012
// .G. 9
// .G. 8
// ... 7
// FFF 6
// ..E 5 z
// D.. 4
// CCC 3
// BBB 2
// .A. 1
// --- 0
// Rotating the perspective 90 degrees so the y axis now goes left to right, the same bricks are arranged like this:

//  y
// 012
// .G. 9
// .G. 8
// ... 7
// .F. 6
// EEE 5 z
// DDD 4
// ..C 3
// B.. 2
// AAA 1
// --- 0
// Once all of the bricks fall downward as far as they can go, the stack looks like this, where ? means bricks are hidden behind other bricks at that location:

//  x
// 012
// .G. 6
// .G. 5
// FFF 4
// D.E 3 z
// ??? 2
// .A. 1
// --- 0
// Again from the side:

//  y
// 012
// .G. 6
// .G. 5
// .F. 4
// ??? 3 z
// B.C 2
// AAA 1
// --- 0
// Now that all of the bricks have settled, it becomes easier to tell which bricks are supporting which other bricks:

// Brick A is the only brick supporting bricks B and C.
// Brick B is one of two bricks supporting brick D and brick E.
// Brick C is the other brick supporting brick D and brick E.
// Brick D supports brick F.
// Brick E also supports brick F.
// Brick F supports brick G.
// Brick G isn't supporting any bricks.
// Your first task is to figure out which bricks are safe to disintegrate. A brick can be safely disintegrated if, after removing it, no other bricks would fall further directly downward. Don't actually disintegrate any bricks - just determine what would happen if, for each brick, only that brick were disintegrated. Bricks can be disintegrated even if they're completely surrounded by other bricks; you can squeeze between bricks if you need to.

// In this example, the bricks can be disintegrated as follows:

// Brick A cannot be disintegrated safely; if it were disintegrated, bricks B and C would both fall.
// Brick B can be disintegrated; the bricks above it (D and E) would still be supported by brick C.
// Brick C can be disintegrated; the bricks above it (D and E) would still be supported by brick B.
// Brick D can be disintegrated; the brick above it (F) would still be supported by brick E.
// Brick E can be disintegrated; the brick above it (F) would still be supported by brick D.
// Brick F cannot be disintegrated; the brick above it (G) would fall.
// Brick G can be disintegrated; it does not support any other bricks.
// So, in this example, 5 bricks can be safely disintegrated.

// Figure how the blocks will settle based on the snapshot. Once they've settled, consider disintegrating a single brick; how many bricks could be safely chosen as the one to get disintegrated?
            return 0;
        }
        public static int Day22Part2(string[] input)
        {
            return 0;
        }

        public static int Day23Part1(string[] input)
        {
//             The Elves resume water filtering operations! Clean water starts flowing over the edge of Island Island.

// They offer to help you go over the edge of Island Island, too! Just hold on tight to one end of this impossibly long rope and they'll lower you down a safe distance from the massive waterfall you just created.

// As you finally reach Snow Island, you see that the water isn't really reaching the ground: it's being absorbed by the air itself. It looks like you'll finally have a little downtime while the moisture builds up to snow-producing levels. Snow Island is pretty scenic, even without any snow; why not take a walk?

// There's a map of nearby hiking trails (your puzzle input) that indicates paths (.), forest (#), and steep slopes (^, >, v, and <).

// For example:

// #.#####################
// #.......#########...###
// #######.#########.#.###
// ###.....#.>.>.###.#.###
// ###v#####.#v#.###.#.###
// ###.>...#.#.#.....#...#
// ###v###.#.#.#########.#
// ###...#.#.#.......#...#
// #####.#.#.#######.#.###
// #.....#.#.#.......#...#
// #.#####.#.#.#########v#
// #.#...#...#...###...>.#
// #.#.#v#######v###.###v#
// #...#.>.#...>.>.#.###.#
// #####v#.#.###v#.#.###.#
// #.....#...#...#.#.#...#
// #.#########.###.#.#.###
// #...###...#...#...#.###
// ###.###.#.###v#####v###
// #...#...#.#.>.>.#.>.###
// #.###.###.#.###.#.#v###
// #.....###...###...#...#
// #####################.#
// You're currently on the single path tile in the top row; your goal is to reach the single path tile in the bottom row. Because of all the mist from the waterfall, the slopes are probably quite icy; if you step onto a slope tile, your next step must be downhill (in the direction the arrow is pointing). To make sure you have the most scenic hike possible, never step onto the same tile twice. What is the longest hike you can take?

// In the example above, the longest hike you can take is marked with O, and your starting position is marked S:

// #S#####################
// #OOOOOOO#########...###
// #######O#########.#.###
// ###OOOOO#OOO>.###.#.###
// ###O#####O#O#.###.#.###
// ###OOOOO#O#O#.....#...#
// ###v###O#O#O#########.#
// ###...#O#O#OOOOOOO#...#
// #####.#O#O#######O#.###
// #.....#O#O#OOOOOOO#...#
// #.#####O#O#O#########v#
// #.#...#OOO#OOO###OOOOO#
// #.#.#v#######O###O###O#
// #...#.>.#...>OOO#O###O#
// #####v#.#.###v#O#O###O#
// #.....#...#...#O#O#OOO#
// #.#########.###O#O#O###
// #...###...#...#OOO#O###
// ###.###.#.###v#####O###
// #...#...#.#.>.>.#.>O###
// #.###.###.#.###.#.#O###
// #.....###...###...#OOO#
// #####################O#
// This hike contains 94 steps. (The other possible hikes you could have taken were 90, 86, 82, 82, and 74 steps long.)

// Find the longest hike you can take through the hiking trails listed on your map. How many steps long is the longest hike?
            return 0;
        }
        public static int Day23Part2(string[] input)
        {
            return 0;
        }

        public static int Day24Part1(string[] input)
        {
//             It seems like something is going wrong with the snow-making process. Instead of forming snow, the water that's been absorbed into the air seems to be forming hail!

// Maybe there's something you can do to break up the hailstones?

// Due to strong, probably-magical winds, the hailstones are all flying through the air in perfectly linear trajectories. You make a note of each hailstone's position and velocity (your puzzle input). For example:

// 19, 13, 30 @ -2,  1, -2
// 18, 19, 22 @ -1, -1, -2
// 20, 25, 34 @ -2, -2, -4
// 12, 31, 28 @ -1, -2, -1
// 20, 19, 15 @  1, -5, -3
// Each line of text corresponds to the position and velocity of a single hailstone. The positions indicate where the hailstones are right now (at time 0). The velocities are constant and indicate exactly how far each hailstone will move in one nanosecond.

// Each line of text uses the format px py pz @ vx vy vz. For instance, the hailstone specified by 20, 19, 15 @ 1, -5, -3 has initial X position 20, Y position 19, Z position 15, X velocity 1, Y velocity -5, and Z velocity -3. After one nanosecond, the hailstone would be at 21, 14, 12.

// Perhaps you won't have to do anything. How likely are the hailstones to collide with each other and smash into tiny ice crystals?

// To estimate this, consider only the X and Y axes; ignore the Z axis. Looking forward in time, how many of the hailstones' paths will intersect within a test area? (The hailstones themselves don't have to collide, just test for intersections between the paths they will trace.)

// In this example, look for intersections that happen with an X and Y position each at least 7 and at most 27; in your actual data, you'll need to check a much larger test area. Comparing all pairs of hailstones' future paths produces the following results:

// Hailstone A: 19, 13, 30 @ -2, 1, -2
// Hailstone B: 18, 19, 22 @ -1, -1, -2
// Hailstones' paths will cross inside the test area (at x=14.333, y=15.333).

// Hailstone A: 19, 13, 30 @ -2, 1, -2
// Hailstone B: 20, 25, 34 @ -2, -2, -4
// Hailstones' paths will cross inside the test area (at x=11.667, y=16.667).

// Hailstone A: 19, 13, 30 @ -2, 1, -2
// Hailstone B: 12, 31, 28 @ -1, -2, -1
// Hailstones' paths will cross outside the test area (at x=6.2, y=19.4).

// Hailstone A: 19, 13, 30 @ -2, 1, -2
// Hailstone B: 20, 19, 15 @ 1, -5, -3
// Hailstones' paths crossed in the past for hailstone A.

// Hailstone A: 18, 19, 22 @ -1, -1, -2
// Hailstone B: 20, 25, 34 @ -2, -2, -4
// Hailstones' paths are parallel; they never intersect.

// Hailstone A: 18, 19, 22 @ -1, -1, -2
// Hailstone B: 12, 31, 28 @ -1, -2, -1
// Hailstones' paths will cross outside the test area (at x=-6, y=-5).

// Hailstone A: 18, 19, 22 @ -1, -1, -2
// Hailstone B: 20, 19, 15 @ 1, -5, -3
// Hailstones' paths crossed in the past for both hailstones.

// Hailstone A: 20, 25, 34 @ -2, -2, -4
// Hailstone B: 12, 31, 28 @ -1, -2, -1
// Hailstones' paths will cross outside the test area (at x=-2, y=3).

// Hailstone A: 20, 25, 34 @ -2, -2, -4
// Hailstone B: 20, 19, 15 @ 1, -5, -3
// Hailstones' paths crossed in the past for hailstone B.

// Hailstone A: 12, 31, 28 @ -1, -2, -1
// Hailstone B: 20, 19, 15 @ 1, -5, -3
// Hailstones' paths crossed in the past for both hailstones.
// So, in this example, 2 hailstones' future paths cross inside the boundaries of the test area.

// However, you'll need to search a much larger test area if you want to see if any hailstones might collide. Look for intersections that happen with an X and Y position each at least 200000000000000 and at most 400000000000000. Disregard the Z axis entirely.

// Considering only the X and Y axes, check all pairs of hailstones' future paths for intersections. How many of these intersections occur within the test area?
            return 0;
        }
        public static int Day24Part2(string[] input)
        {
            return 0;
        }

        public static int Day25Part1(string[] input)
        {
//             Still somehow without snow, you go to the last place you haven't checked: the center of Snow Island, directly below the waterfall.

// Here, someone has clearly been trying to fix the problem. Scattered everywhere are hundreds of weather machines, almanacs, communication modules, hoof prints, machine parts, mirrors, lenses, and so on.

// Somehow, everything has been wired together into a massive snow-producing apparatus, but nothing seems to be running. You check a tiny screen on one of the communication modules: Error 2023. It doesn't say what Error 2023 means, but it does have the phone number for a support line printed on it.

// "Hi, you've reached Weather Machines And So On, Inc. How can I help you?" You explain the situation.

// "Error 2023, you say? Why, that's a power overload error, of course! It means you have too many components plugged in. Try unplugging some components and--" You explain that there are hundreds of components here and you're in a bit of a hurry.

// "Well, let's see how bad it is; do you see a big red reset button somewhere? It should be on its own module. If you push it, it probably won't fix anything, but it'll report how overloaded things are." After a minute or two, you find the reset button; it's so big that it takes two hands just to get enough leverage to push it. Its screen then displays:

// SYSTEM OVERLOAD!

// Connected components would require
// power equal to at least 100 stars!
// "Wait, how many components did you say are plugged in? With that much equipment, you could produce snow for an entire--" You disconnect the call.

// You have nowhere near that many stars - you need to find a way to disconnect at least half of the equipment here, but it's already Christmas! You only have time to disconnect three wires.

// Fortunately, someone left a wiring diagram (your puzzle input) that shows how the components are connected. For example:

// jqt: rhn xhk nvd
// rsh: frs pzl lsr
// xhk: hfx
// cmg: qnr nvd lhk bvb
// rhn: xhk bvb hfx
// bvb: xhk hfx
// pzl: lsr hfx nvd
// qnr: nvd
// ntq: jqt hfx bvb xhk
// nvd: lhk
// lsr: lhk
// rzs: qnr cmg lsr rsh
// frs: qnr lhk lsr
// Each line shows the name of a component, a colon, and then a list of other components to which that component is connected. Connections aren't directional; abc: xyz and xyz: abc both represent the same configuration. Each connection between two components is represented only once, so some components might only ever appear on the left or right side of a colon.

// In this example, if you disconnect the wire between hfx/pzl, the wire between bvb/cmg, and the wire between nvd/jqt, you will divide the components into two separate, disconnected groups:

// 9 components: cmg, frs, lhk, lsr, nvd, pzl, qnr, rsh, and rzs.
// 6 components: bvb, hfx, jqt, ntq, rhn, and xhk.
// Multiplying the sizes of these groups together produces 54.

// Find the three wires you need to disconnect in order to divide the components into two separate groups. What do you get if you multiply the sizes of these two groups together?
            return 0;
        }
        public static int Day25Part2(string[] input)
        {
            return 0;
        }
    }
}
