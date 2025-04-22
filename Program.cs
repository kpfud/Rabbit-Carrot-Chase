using System;
using System.Collections.Generic;

class RabbitEatingCarrots
{
    static int EatCarrots(int[,] garden)
    {
        int rows = garden.GetLength(0);
        int cols = garden.GetLength(1);

        // Find the starting position of the rabbit
        int startRow, startCol;
        FindStartPosition(garden, out startRow, out startCol);

        int totalCarrotsEaten = 0;

        while (true)
        {
            // Eat carrots on the current square
            totalCarrotsEaten += garden[startRow, startCol];
            // Mark the current square as visited
            garden[startRow, startCol] = 0;

            //Find the adjacent squares' coordinates
            int[][] neighbors =
            {
                new int[] {startRow - 1, startCol},
                new int[] {startRow + 1, startCol},
                new int[] {startRow, startCol - 1},
                new int[] {startRow, startCol + 1}
            };

            // Filter out invalid neighbors
            var validNeighbors = new List<int[]>();
            foreach (var neighbor in neighbors)
            {
                int r = neighbor[0];
                int c = neighbor[1];
                if (r >= 0 && r < rows && c >= 0 && c < cols)
                {
                    validNeighbors.Add(new int[] { r, c });
                }
            }

            // If no valid neighbors, rabbit goes to sleep
            if (validNeighbors.Count == 0)
            {
                break;
            }

            // Find the neighbor with the highest carrot count
            int maxCarrots = 0;
            int[] nextSquare = null;
            foreach (var neighbor in validNeighbors)
            {
                int r = neighbor[0];
                int c = neighbor[1];
                if (garden[r, c] > maxCarrots)
                {
                    maxCarrots = garden[r, c];
                    nextSquare = neighbor;
                }
            }

            // If all neighbors have been visited, rabbit goes to sleep
            if (nextSquare == null)
            {
                break;
            }

            // Move to the square with the highest carrot count
            startRow = nextSquare[0];
            startCol = nextSquare[1];
        }

        return totalCarrotsEaten;
    }

    static void FindStartPosition(int[,] garden, out int startRow, out int startCol)
    {
        int rows = garden.GetLength(0);
        int cols = garden.GetLength(1);

        //Find the exact center if both rows and columns are odd
        if (rows % 2 == 1 && cols % 2 == 1)
        {
            startRow = rows / 2;
            startCol = cols / 2;
            return;
        }
        // Find the position with the maximum carrots closest to the center
        int centerRow = rows / 2;
        int centerCol = cols / 2;

        int[][] centerPositions=
        {
            new int[] {centerRow - 1, centerCol },
            new int[] {centerRow + 1, centerCol },
            new int[] {centerRow, centerCol - 1},
            new int[] {centerRow, centerCol + 1}
        };

        int maxCarrots = 0;
        startRow = 0;
        startCol = 0;

        foreach (var position in centerPositions)
            {
                int r = position[0];
                int c = position[1];

                if (r >= 0 && r < rows && c >= 0 && c < cols && garden[r, c] > maxCarrots)
                {
                    startRow = r;
                    startCol = c;
                maxCarrots = garden[r, c];
                }
            }
        }
    static void Main()
    {
        int[,] gardenMatrix =
        {
            { 10, 15, 9, 7, 6, 4, 3, 2, 1, 12
            },
            { 12, 2, 3, 4, 1, 6, 7, 8, 10, 0
            },
            { 0, 1, 7, 6, 2, 5, 3, 6, 0, 23
            },
            { 4, 9, 0, 5, 12, 14, 2, 4, 4, 2
            },
            { 22, 21, 6, 1, 16, 2, 5, 5, 0, 6
            },
            { 9, 8, 5, 3, 7, 6, 12, 6, 12, 3
            },
            { 10, 2, 0, 6, 8, 9, 14, 22, 13, 15
            },
            { 9, 6, 5, 4, 1, 10, 12, 10, 2, 1
            }
        };

        int result = EatCarrots(gardenMatrix);
        Console.WriteLine("Total carrots eaten by the rabbit: " + result);
    }
}