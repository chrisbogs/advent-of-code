using System.Collections.Generic;

namespace AdventOfCodeShared.Models
{
    public class Direction
    {
        public const string FORWARD = "forward";
        public const string DOWN = "down";
        public const string UP = "up";
    }

    public class Command
    {
        public string Direction;
        public int Amount;
        public Command(string direction, int amount)
        {
            this.Direction = direction;
            this.Amount = amount;
        }
    }

    public class Submarine
    {
        // 0, 0 is the surface of the water (entry point)
        // first value is horizontal position
        // second value is depth
        private MyPoint CurrentPosition = new(0, 0);
        private int Aim = 0;

        public int CurrentPositionHash => this.CurrentPosition.X * this.CurrentPosition.Y;

        public List<Command> ParseCommands(string[] input)
        {
            List<Command> commands = new(); ;
            foreach (var x in input)
            {
                var s = x.Split(' ');
                var direction = Direction.FORWARD;
                switch (s[0])
                {
                    // case Direction.FORWARD:
                    //     direction = Direction.FORWARD;
                    //     break;
                    case Direction.DOWN:
                        direction = Direction.DOWN;
                        break;
                    case Direction.UP:
                        direction = Direction.UP;
                        break;
                }

                var amount = int.Parse(s[1]);
                commands.Add(new Command(
                    direction, amount
                ));
            }
            return commands;
        }

        public void Move(List<Command> commands)
        {
            foreach (var x in commands)
            {
                if (x.Direction == Direction.FORWARD)
                {
                    this.CurrentPosition.X += x.Amount;
                    this.CurrentPosition.Y += this.Aim * x.Amount;
                }
                else if (x.Direction == Direction.UP)
                {
                    this.Aim -= x.Amount;
                }
                else if (x.Direction == Direction.DOWN)
                {
                    this.Aim += x.Amount;
                }
            }
        }

        public void MovePart1(List<Command> commands)
        {
            foreach (var x in commands)
            {
                if (x.Direction == Direction.FORWARD)
                {
                    this.CurrentPosition.X += x.Amount;
                }
                else if (x.Direction == Direction.UP)
                {
                    this.CurrentPosition.Y -= x.Amount;
                }
                else if (x.Direction == Direction.DOWN)
                {
                    this.CurrentPosition.Y += x.Amount;
                }
            }
        }

    }
}
