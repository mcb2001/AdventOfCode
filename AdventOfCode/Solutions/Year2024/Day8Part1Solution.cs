using System.Drawing;

namespace AdventOfCode.Solutions.Year2024
{
    internal class Day8Part1Solution : Year2024Solution
    {
        public override int Day => 8;
        public override int Part => 1;

        public override async Task<object> RunAsync()
        {
            string[] lines = await ReadAllLinesAsync();

            //DEBUG
            /*
            lines =
                [
                    "............",
                    "........0...",
                    ".....0......",
                    ".......0....",
                    "....0.......",
                    "......A.....",
                    "............",
                    "............",
                    "........A...",
                    ".........A..",
                    "............",
                    "............",
                ];
            */

            char[,] state = new char[lines.Length, lines[0].Length];

            Dictionary<char, List<Point>> coordinateMap = [];

            for (int y = 0; y < lines.Length; ++y)
            {
                string line = lines[y];

                for (int x = 0; x < line.Length; ++x)
                {
                    char c = line[x];

                    state[y, x] = c;

                    if (c == '.')
                    {
                        continue;
                    }

                    if (coordinateMap.TryGetValue(c, out List<Point>? points))
                    {
                        points.Add(new(x, y));
                    }
                    else
                    {
                        coordinateMap.Add(c, [new(x, y)]);
                    }
                }
            }

            int count = 0;

            foreach (List<Point> pointSet in coordinateMap.Values)
            {
                for (int a = 0; a < pointSet.Count - 1; ++a)
                {
                    for (int b = a + 1; b < pointSet.Count; ++b)
                    {
                        Point p0 = pointSet[a];
                        Point p1 = pointSet[b];

                        if (p0.X < p1.X && p0.Y < p1.Y)
                        {
                            //Direction: NW-SE

                            int diffX = p1.X - p0.X;
                            int diffY = p1.Y - p0.Y;

                            Point up = new(p0.X - diffX, p0.Y - diffY);

                            if (up.X >= 0 && up.Y >= 0)
                            {
                                if (state[up.Y, up.X] != '#')
                                {
                                    ++count;
                                }

                                if (state[up.Y, up.X] == '.')
                                {
                                    state[up.Y, up.X] = '#';
                                }
                            }

                            Point down = new(p1.X + diffX, p1.Y + diffY);

                            if (down.X < lines[0].Length && down.Y < lines.Length)
                            {
                                if (state[down.Y, down.X] != '#')
                                {
                                    ++count;
                                }

                                if (state[down.Y, down.X] == '.')
                                {
                                    state[down.Y, down.X] = '#';
                                }
                            }
                        }
                        else
                        {
                            //Direction: NE-SW

                            int diffX = p0.X - p1.X;
                            int diffY = p1.Y - p0.Y;

                            Point up = new(p0.X + diffX, p0.Y - diffY);

                            if (up.X < lines[0].Length && up.Y >= 0)
                            {
                                if (state[up.Y, up.X] != '#')
                                {
                                    ++count;
                                }

                                if (state[up.Y, up.X] == '.')
                                {
                                    state[up.Y, up.X] = '#';
                                }
                            }

                            Point down = new(p1.X - diffX, p1.Y + diffY);

                            if (down.X >= 0 && down.Y < lines.Length)
                            {
                                if (state[down.Y, down.X] != '#')
                                {
                                    ++count;
                                }

                                if (state[down.Y, down.X] == '.')
                                {
                                    state[down.Y, down.X] = '#';
                                }
                            }
                        }
                    }
                }

            }

            return count;
        }
    }
}