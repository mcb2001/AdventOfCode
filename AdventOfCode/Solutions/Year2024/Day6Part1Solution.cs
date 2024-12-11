using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AdventOfCode.Solutions.Year2024
{
    internal class Day6Part1Solution : Year2024Solution
    {
        public override int Day => 6;
        public override int Part => 1;

        public override async Task<object> RunAsync()
        {
            string[] mapLines = await ReadAllLinesAsync();

            //DEBUG
            /*
            mapLines =
                [
                "....#.....",
                ".........#",
                "..........",
                "..#.......",
                ".......#..",
                "..........",
                ".#..^.....",
                "........#.",
                "#.........",
                "......#...",
                ];
            */

            Point guard = new(-1, -1);

            Cell[][] board = new Cell[mapLines.Length][];

            for (int y = 0; y < mapLines.Length; ++y)
            {
                string line = mapLines[y];
                Cell[] row = new Cell[line.Length];

                for (int x = 0; x < line.Length; ++x)
                {
                    switch (line[x])
                    {
                        case '.':
                            {
                                row[x] = Cell.None;
                                break;
                            }
                        case '^':
                            {
                                guard.X = x;
                                guard.Y = y;
                                row[x] = Cell.Visited;
                                break;
                            }
                        case '#':
                            {
                                row[x] = Cell.Obstacle;
                                break;
                            }
                    }
                }

                board[y] = row;
            }

            int direction = 0;

            while (true)
            {
                board[guard.Y][guard.X] = Cell.Visited;

                Point next = guard;

                switch (direction)
                {
                    case 0:
                        {
                            --next.Y;
                            break;
                        }
                    case 1:
                        {
                            ++next.X;
                            break;
                        }
                    case 2:
                        {
                            ++next.Y;
                            break;
                        }
                    case 3:
                        {
                            --next.X;
                            break;
                        }
                }

                if (next.X == board[0].Length || next.Y == board.Length || next.X < 0 || next.Y < 0)
                {
                    break;
                }

                if (board[next.Y][next.X] == Cell.Obstacle)
                {
                    direction = (direction + 1) % 4;
                }
                else
                {
                    guard = next;
                }

            }

            int count = 0;

            foreach (Cell[] row in board)
            {
                foreach (Cell cell in row)
                {
                    count += cell == Cell.Visited ? 1 : 0;
                }
            }

            return count;
        }

        internal enum Cell
        {
            None = 0,
            Obstacle = 1,
            Visited = 2,
        }
    }
}