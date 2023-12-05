using AdventOfCodeShared.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCodeShared.Models.Geometry
{
    public enum Compass
    {
        North,
        East,
        South,
        West
    }

    public class Geometry
    {
        public static int CalculateDistanceFromOrigin(Point endPoint)
        {
            return Math.Abs(endPoint.X - 0) + Math.Abs(endPoint.Y - 0);
        }

        /// <summary>
        /// Accepts a list of directions in the form of [("R", 2), ("L", 3)],
        /// where the character is one of: "R", "L".
        /// This example will end up at coordinates: (2,3)
        /// </summary>
        public static Point FollowPath(List<Tuple<DPadDirection, int>> directions)
        {
            int xAxis = 0;
            int yAxis = 0;
            var currentHeading = Compass.North;
            foreach (var (direction, distance) in directions)
            {
                if (direction == DPadDirection.RIGHT)
                {
                    currentHeading = (Compass)(((int)currentHeading + 1) % 4);
                }
                else if (direction == DPadDirection.LEFT)
                {
                    currentHeading = (Compass)(((int)currentHeading - 1 + 4) % 4);
                }

                switch (currentHeading)
                {
                    case Compass.East: xAxis += distance; break;
                    case Compass.North: yAxis += distance; break;
                    case Compass.West: xAxis -= distance; break;
                    case Compass.South: yAxis -= distance; break;
                }
            }
            return new Point(xAxis, yAxis);
        }

        /// <summary>
        /// Accepts a list of directions and returns the end coordinates.
        /// </summary>
        public static Point FollowPathByMovingOneUnitAtATime(
            Point start, 
            IEnumerable<DPadDirection> directions,
            IEnumerable<Point> validPoints)
        {
            int xAxis = start.X;
            int yAxis = start.Y;
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case DPadDirection.RIGHT:
                        if (!validPoints.Contains(new Point(xAxis + 1, yAxis))) break;
                        xAxis++;
                        break;

                    case DPadDirection.LEFT:
                        if (!validPoints.Contains(new Point(xAxis - 1, yAxis))) break;
                        xAxis--;
                        break;

                    case DPadDirection.UP:
                        if (!validPoints.Contains(new Point(xAxis, yAxis+1))) break;
                        yAxis++;
                        break;

                    case DPadDirection.DOWN:
                        if (!validPoints.Contains(new Point(xAxis, yAxis-1))) break;
                        yAxis--;
                        break;
                }
            }
            return new Point(xAxis, yAxis);
        }

        /// <summary>
        /// Given a list of directions in the format:  [("R",2), ("L", 3)]
        /// where the character is one of: R,L
        /// Returns a list of cartesian points that make up the path.
        /// </summary>
        public static Point FindFirstLoopBackInPath(List<Tuple<DPadDirection, int>> directions)
        {
            var path = new HashSet<Point>();
            int xAxis = 0;
            int yAxis = 0;
            var currentHeading = Compass.North;
            foreach (var (direction, distance) in directions)
            {
                if ((DPadDirection)direction == DPadDirection.RIGHT)
                {
                    currentHeading = (Compass)(((int)currentHeading + 1) % 4);
                }
                else if ((DPadDirection)direction == DPadDirection.LEFT)
                {
                    currentHeading = (Compass)(((int)currentHeading - 1 + 4) % 4);
                }

                switch (currentHeading)
                {
                    case Compass.East: 
                        for(int i = 0;i < distance; i++)
                        {
                            var p = new Point(xAxis, yAxis);
                            if (!path.Contains(p))
                            {
                                path.Add(p);
                            }
                            else
                            {
                                return p;
                            }
                            xAxis += 1; 
                        }
                        break;
                    case Compass.North:
                        for (int i = 0; i < distance; i++)
                        {
                            var p = new Point(xAxis, yAxis);
                            if (!path.Contains(p))
                            {
                                path.Add(p);
                            }
                            else
                            {
                                return p;
                            }
                            yAxis += 1; 
                        }
                        break; 
                    case Compass.West:
                        for (int i = 0; i < distance; i++)
                        {
                            var p = new Point(xAxis, yAxis);
                            if (!path.Contains(p))
                            {
                                path.Add(p);
                            }
                            else
                            {
                                return p;
                            }
                            xAxis -= 1;
                        }
                        break;
                    case Compass.South:
                        for (int i = 0; i < distance; i++)
                        {
                            var p = new Point(xAxis, yAxis);
                            if (!path.Contains(p))
                            {
                                path.Add(p);
                            }
                            else
                            {
                                return p;
                            }
                            yAxis -= 1;
                        }
                        break;
                }
            }
        
    
            return Point.Empty;
        }

        /// <summary>
        /// Given a list of directions in the format:  ["R98", "U47"]
        /// where the character is one of: R,L,U,D.
        /// </summary>
        public static Dictionary<Point, int> TracePathCountingSteps(string[] directions)
        {
            // Ignore the origin
            var path = new Dictionary<Point, int>();
            var previousLocationX = 0;
            var previousLocationY = 0;
            var stepCount = 0;
            foreach (var step in directions)
            {
                var direction = (DPadDirection)char.Parse(step[..1]);
                var distance = int.Parse(step[1..]);
                for (var i = 1; i <= distance; i++)
                {
                    switch (direction)
                    {
                        case DPadDirection.RIGHT:
                            previousLocationX++;
                            break;

                        case DPadDirection.LEFT:
                            previousLocationX--;
                            break;

                        case DPadDirection.UP:
                            previousLocationY++;
                            break;

                        case DPadDirection.DOWN:
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

        /// <summary>
        /// Given 2 lists of points (with step counts),
        /// return the list of all intersection points
        /// </summary>
        public static Dictionary<Point, int> FindIntersectionPoints(
            Dictionary<Point, int> wire1Path, 
            Dictionary<Point, int> wire2Path)
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

        /// <summary>
        /// Given 2 lists of points,
        /// return the list of all intersection points
        /// </summary>
        public static IEnumerable<Point> IntersectionPointsGenerator(
            HashSet<Point> path1,
            HashSet<Point> path2)
        {
            foreach (var x in path1)
            {
                if (path2.Contains(x))
                {
                    yield return x;
                }
            }
        }

    }
}
