using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AdventOfCode.Solutions.Year2024
{
    [Skippable]
    internal class Day6Part2Solution : Year2024Solution
    {
        public override int Day => 6;
        public override int Part => 2;

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

            int count = 0;

            Enumerable.Range(0, board.Length)
                .AsParallel()
                .WithDegreeOfParallelism(12)
                .ForAll(y =>
                {
                    for (int x = 0; x < board[y].Length; ++x)
                    {
                        Cell[][] clone = Clone(board);

                        if (clone[y][x] == Cell.None)
                        {
                            clone[y][x] = Cell.Obstacle;

                            if (HasLoops(guard, clone))
                            {
                                ++count;
                            }
                        }
                    }
                });

            return count;
        }

        private static Cell[][] Clone(Cell[][] board)
        {
            List<Cell[]> newBoard = [];

            foreach (Cell[] row in board)
            {
                Cell[] newRow = new Cell[row.Length];

                for (int x = 0; x < row.Length; ++x)
                {
                    newRow[x] = row[x];
                }

                newBoard.Add(newRow);
            }

            return [.. newBoard];
        }

        private static bool HasLoops(Point guard, Cell[][] board)
        {
            HashSet<(int X, int Y, int Direction)> loopDetection = [];

            int direction = 0;

            while (true)
            {
                (int X, int Y, int Direction) positionInTime = (guard.X, guard.Y, direction);

                if (loopDetection.Contains(positionInTime))
                {
                    return true;
                }

                loopDetection.Add(positionInTime);

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

            return false;
        }

        internal enum Cell
        {
            None = 0,
            Obstacle = 1,
            Visited = 2,
        }
    }
}