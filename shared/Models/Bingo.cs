using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    class Bingo
    {
        private List<List<BingoTile>> Board;
        private readonly int size = 5;
        public bool Done = false; // card has already won
        public Bingo(List<int> cardValues)
        {
            this.Board = new List<List<BingoTile>>();
            for (var i = 0; i < this.size; i++)
            {
                var row = new List<BingoTile>();
                for (var j = 0; j < this.size; j++)
                {
                    var nextValue = cardValues[0];
                    cardValues = cardValues.Skip(1)?.ToList();
                    row.Add(new BingoTile(false, nextValue));
                }
                this.Board.Add(row);
            }
        }

        public List<List<BingoTile>> Board1 => Board;

        public override string ToString()
        {
            var output = "\n";
            for (var i = 0; i < this.size; i++)
            {
                for (var j = 0; j < this.size; j++)
                {
                    output += this.Board[i][j].ToString() + "\t";
                }
                output += "\n";
            }
            return output;
        }

        public int GetFinalScore(int finalNumber)
        {
            // sum of all un-marked numbers in this Board
            var sum = 0;
            foreach (var x in this.Board)
            {
                sum += x.Where(x => !x.Marked)
                .Aggregate(0, (partialSum, n) => partialSum + n.Value);
            }
            // * the final number
            return sum * finalNumber;
        }

        // Returns true if a line exists in the card either horizontally or vertically
        // in the 2D array.
        // TODO: Come back and improve this algorithm.
        public bool hasWon()
        {
            // check row by row
            for (var i = 0; i < this.size; i++)
            {
                if (this.Board[i].All(x => x.Marked))
                {
                    this.Done = true;
                    return true;
                }
            }

            // check row by column
            for (var c = 0; c < this.size; c++)
            {
                var allMarked = true;
                for (var r = 0; r < this.size; r++)
                {
                    if (!this.Board[r][c].Marked)
                    {
                        allMarked = false;
                        break;

                    }
                }
                if (allMarked)
                {
                    this.Done = true;
                    return true;
                }
            }

            return false;
        }

        // Given a Bingo number, mark the tile on our card if it exists.
        // Return a boolean signifying if we have won or not.
        public bool NumberCalled(int n)
        {
            for (var i = 0; i < this.size; i++)
            {
                for (var j = 0; j < this.size; j++)
                {
                    if (this.Board[i][j].Value == n)
                    {
                        this.Board[i][j].Marked = true;
                    }
                }
            }
            return this.hasWon();
        }

        public struct ReturnType
        {
            public int[] NumbersCalled;
            public List<Bingo> BingoCards;
        }

        public static ReturnType ParseInput(string[] input)
        {
            var numbersCalled = input[0].Split(',').Select(x => int.Parse(x)).ToArray();
            var bingoCards = input.Skip(2).ToList();
            int[] bingoCard = Array.Empty<int>();
            List<List<int>> cards = new();

            foreach (var line in bingoCards)
            {
                if (line == "\n" || line == "")
                {
                    // next card
                    cards.Add(bingoCard.ToList());
                    bingoCard = Array.Empty<int>();
                }

                if (line != null && line.Trim() != "")
                {
                    var parsedLine = line
                        .Split(' ')
                        .Where(x => x != null && x != "")
                        .Select(x => int.Parse(x));

                    if (parsedLine != null)
                    {
                        bingoCard = bingoCard.Concat(parsedLine).ToArray();
                    }
                }
            }
            var bingos = new List<Bingo>();
            foreach (var card in cards)
            {
                bingos.Add(new Bingo(card));
            }

            return new ReturnType() { NumbersCalled = numbersCalled, BingoCards = bingos };
        }

        public static string RunBingo(int[] numbersCalled, List<Bingo> bingos, bool firstWinnerOnly)
        {
            var numberOfCards = bingos.Count;
            foreach (var n in numbersCalled)
            {
                foreach (var b in bingos)
                {
                    if (b.Done)
                    {
                        continue;
                    }

                    var won = b.NumberCalled(n);
                    if (won)
                    {
                        numberOfCards--;
                        var winningScore = b.GetFinalScore(n).ToString();
                        if (firstWinnerOnly || numberOfCards == 0)
                        {
                            return winningScore;
                        }
                    }
                }
            }
            return "No winners";
        }
    }

    class BingoTile
    {
        public bool Marked = false;
        public int Value = 0;
        public BingoTile(bool marked, int value)
        {
            this.Marked = marked; this.Value = value;
        }
        public override string ToString() => $"{(this.Marked ? 'x' : 'o')}{this.Value}";
    }

    
}