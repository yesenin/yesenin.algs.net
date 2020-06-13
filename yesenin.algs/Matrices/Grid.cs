using System;
using System.Collections.Generic;
using System.Linq;

namespace yesenin.algs.Matrices
{
    /// <summary>
    /// Methods for grids
    /// </summary>
    public static class Grid
    {
        /// <summary>
        /// Returns size of the biggest square formed by "1"s on the given grid.
        /// </summary>
        /// <param name="lines">Grid rows</param>
        /// <returns>Size of the biggest square</returns>
        public static int FindBiggestSquare(List<string> lines)
        {
            var grid = ConvertToGrid(lines);
            return FindBiggestSquare(grid);
        }
        
        public static int FindBiggestSquare(List<int[]> grid)
        {
            var maxSquare = 0;
            for (var i = 0; i < grid.Count; i++)
            {
                for (var j = 0; j < grid.First().Length; j++)
                {
                    if (grid[i][j] != 1)
                    {
                        continue;
                    }
                    var m = MeasureSquare(i, j, grid);
                    if (m > 0 && m > maxSquare)
                    {
                        maxSquare = m;
                    }
                }
            }
            return maxSquare;
        }
        
        public static List<int[]> ConvertToGrid(List<string> lines)
        {
            var grid = new List<int[]>();
            foreach (var line in lines)
            {
                grid.Add(line.Split(' ').Select(int.Parse).ToArray());
            }
            return grid;
        }

        public static int MeasureSquare(int i, int j, List<int[]> grid)
        {
            var width = 1;
            var r_j = j + width;
            while (r_j < grid.First().Length && grid[i][r_j] == 1)
            {
                width += 1;
                r_j = j + width;
            }
            
            var height = 1;
            var b_i = i + height;
            while (b_i < grid.Count && grid[b_i][j] == 1 )
            {
                height += 1;
                b_i = i + height;
            }

            try
            {
                if (width != height || !CheckFillSquare(i, j, width, grid))
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
            
            return width;
        }

        public static bool CheckFillSquare(int i, int j, int a, List<int[]> grid)
        {
            for (var c = i; a < i + a - 1; a++)
            {
                for (var b = j; b < j + a - 1; b++)
                {
                    if (grid[c][b] != 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static List<int[]> ProduceEmptyRectangle(int width, int height)
        {
            var result = new List<int[]>();
            
            for (var i = 0; i < height; i++)
            {
                result.Add(new int[width]);
                for (var j = 0; j < width; j++)
                {
                    result[i][j] = 0;
                }
            }

            return result;
        }

        public static List<int[]> PlaceSquare(int x, int y, int a, List<int[]> grid)
        {
            if (y + a > grid.Count || x + a > grid.First().Length)
            {
                return grid;
            }

            for (var i = x; i < x + a; i++)
            {
                for (var j = y; j < y + a; j++)
                {
                    grid[i][j] = 1;
                }
            }

            return grid;
        }
    }
}