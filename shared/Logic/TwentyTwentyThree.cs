using AdventOfCodeShared.Extensions;

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
            // Note: could do it in one loop
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
            return result; //49820 > 50,000
        }
        public static long Day1Part2(string[] input)
        {
            return 0;
            // o the atmosphere! The apex of your trajectory just barely reaches the surface of a large island floating in the sky. You gently land in a fluffy pile of leaves. It's quite cold, but you don't see much snow. An Elf runs over to greet you.
// The Elf explains that you've arrived at Snow Island and apologizes for the lack of snow. He'll be happy to explain the situation, but it's a bit of a walk, so you have some time. They don't get many visitors up here; would you like to play a game in the meantime?
// As you walk, the Elf shows you a small bag and some cubes which are either red, green, or blue. Each time you play this game, he will hide a secret number of cubes of each color in the bag, and your goal is to figure out information about the number of cubes.
// To get information, once a bag has been loaded with cubes, the Elf will reach into the bag, grab a handful of random cubes, show them to you, and then put them back in the bag. He'll do this a few times per game.
// You play several games and record the information from each game (your puzzle input). Each game is listed with its ID number (like the 11 in Game 11: ...) followed by a semicolon-separated list of subsets of cubes that were revealed from the bag (like 3 red, 5 green, 4 blue).
// For example, the record of a few games might look like this:
// Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
// Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
// Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
// Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
// Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
// In game 1, three sets of cubes are revealed from the bag (and then put back again). The first set is 3 blue cubes and 4 red cubes; the second set is 1 red cube, 2 green cubes, and 6 blue cubes; the third set is only 2 green cubes.

// The Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes?

// In the example above, games 1, 2, and 5 would have been possible if the bag had been loaded with that configuration. However, game 3 would have been impossible because at one point the Elf showed you 20 red cubes at once; similarly, game 4 would also have been impossible because the Elf showed you 15 blue cubes at once. If you add up the IDs of the games that would have been possible, you get 8.

// Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games?
        }

        public static long Day2Part1(string[] input)
        {
//             You're launched high int
            return 0;
        }
        public static long Day2Part2(string[] input)
        {
            return 0;
        }

        public static long Day3Part1(string[] input)
        {
//             You and the Elf eventually reach a gondola lift station; he says the gondola lift will take you up to the water source, but this is as far as he can bring you. You go inside.

// It doesn't take long to find the gondolas, but there seems to be a problem: they're not moving.

// "Aaah!"

// You turn around to see a slightly-greasy Elf with a wrench and a look of surprise. "Sorry, I wasn't expecting anyone! The gondola lift isn't working right now; it'll still be a while before I can fix it." You offer to help.

// The engineer explains that an engine part seems to be missing from the engine, but nobody can figure out which one. If you can add up all the part numbers in the engine schematic, it should be easy to work out which part is missing.

// The engine schematic (your puzzle input) consists of a visual representation of the engine. There are lots of numbers and symbols you don't really understand, but apparently any number adjacent to a symbol, even diagonally, is a "part number" and should be included in your sum. (Periods (.) do not count as a symbol.)

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
// In this schematic, two numbers are not part numbers because they are not adjacent to a symbol: 114 (top right) and 58 (middle right). Every other number is adjacent to a symbol and so is a part number; their sum is 4361.

// Of course, the actual engine schematic is much larger. What is the sum of all of the part numbers in the engine schematic?
            return 0;
        }
        public static long Day3Part2(string[] input)
        {
            return 0;
        }

        public static long Day4Part1(string[] input)
        {
//             The gondola takes you up. Strangely, though, the ground doesn't seem to be coming with you; you're not climbing a mountain. As the circle of Snow Island recedes below you, an entire new landmass suddenly appears above you! The gondola carries you to the surface of the new island and lurches into the station.

// As you exit the gondola, the first thing you notice is that the air here is much warmer than it was on Snow Island. It's also quite humid. Is this where the water source is?

// The next thing you notice is an Elf sitting on the floor across the station in what seems to be a pile of colorful square cards.

// "Oh! Hello!" The Elf excitedly runs over to you. "How may I be of service?" You ask about water sources.

// "I'm not sure; I just operate the gondola lift. That does sound like something we'd have, though - this is Island Island, after all! I bet the gardener would know. He's on a different island, though - er, the small kind surrounded by water, not the floating kind. We really need to come up with a better naming scheme. Tell you what: if you can help me with something quick, I'll let you borrow my boat and you can go visit the gardener. I got all these scratchcards as a gift, but I can't figure out what I've won."

// The Elf leads you over to the pile of colorful cards. There, you discover dozens of scratchcards, all with their opaque covering already scratched off. Picking one up, it looks like each card has two lists of numbers separated by a vertical bar (|): a list of winning numbers and then a list of numbers you have. You organize the information into a table (your puzzle input).

// As far as the Elf has been able to figure out, you have to figure out which of the numbers you have appear in the list of winning numbers. The first match makes the card worth one point and each match after the first doubles the point value of that card.

// For example:

// Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
// Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
// Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
// Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
// Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
// Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
// In the above example, card 1 has five winning numbers (41, 48, 83, 86, and 17) and eight numbers you have (83, 86, 6, 31, 17, 9, 48, and 53). Of the numbers you have, four of them (48, 83, 17, and 86) are winning numbers! That means card 1 is worth 8 points (1 for the first match, then doubled three times for each of the three matches after the first).

// Card 2 has two winning numbers (32 and 61), so it is worth 2 points.
// Card 3 has two winning numbers (1 and 21), so it is worth 2 points.
// Card 4 has one winning number (84), so it is worth 1 point.
// Card 5 has no winning numbers, so it is worth no points.
// Card 6 has no winning numbers, so it is worth no points.
// So, in this example, the Elf's pile of scratchcards is worth 13 points.

// Take a seat in the large pile of colorful cards. How many points are they worth in total?
            return 0;
        }
        public static long Day4Part2(string[] input)
        {
            return 0;
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
