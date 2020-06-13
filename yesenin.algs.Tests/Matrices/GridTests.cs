using System.Collections.Generic;
using System.Linq;
using Xunit;
using yesenin.algs.Matrices;

namespace yesenin.algs.Tests.Matrices
{
    public class GridTests
    {
        [Fact]
        public void FindBiggestSquare_22_on_33_Test()
        {
            var grid = Grid.ProduceEmptyRectangle(3, 3);
            grid = Grid.PlaceSquare(0, 0, 2, grid);
            var result = Grid.FindBiggestSquare(grid);
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void FindBiggestSquareTest()
        {
            var grid = new List<string>
            {
                "1 1 0 1 0",
                "1 1 1 1 1",
                "0 0 1 1 1",
                "0 0 1 1 1",
                "1 1 0 0 0",
            };

            var result = Grid.FindBiggestSquare(grid);
            Assert.Equal(3, result);
        }
        
        [Fact]
        public void FindBiggestSquareTest_2()
        {
            var grid = new List<string>
            {
                "1 1 0 1 0",
                "1 1 1 1 1",
                "0 0 1 1 1",
                "0 0 0 1 1",
                "1 1 0 0 0",
            };

            var result = Grid.FindBiggestSquare(grid);
            Assert.Equal(2, result);
        }

        [Fact]
        public void MeasureSquare_22_on_55_00_Test()
        {
            var lines = new List<string>
            {
                "1 1 0 0 0",
                "1 1 0 0 0",
                "0 0 0 0 0",
                "0 0 0 0 0",
                "0 0 0 0 0",
            };
            var grid = Grid.ConvertToGrid(lines);
            var result = Grid.MeasureSquare(0, 0, grid);
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void MeasureSquare_33_on_55_Test()
        {
            var lines = new List<string>
            {
                "1 1 1 0 0",
                "1 1 1 0 0",
                "1 1 1 0 0",
                "0 0 0 0 0",
                "0 0 0 0 0",
            };
            var grid = Grid.ConvertToGrid(lines);
            var result = Grid.MeasureSquare(0, 0, grid);
            Assert.Equal(3, result);
        }
        
        [Fact]
        public void MeasureSquare_22_on_55_11_Test()
        {
            var grid = Grid.ProduceEmptyRectangle(5, 5);
            grid = Grid.PlaceSquare(1, 1, 2, grid);
            var result = Grid.MeasureSquare(1, 1, grid);
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void MeasureSquare_44_on_55_Test()
        {
            var grid = Grid.ProduceEmptyRectangle(5, 5);
            grid = Grid.PlaceSquare(1, 1, 4, grid);
            var result = Grid.MeasureSquare(1, 1, grid);
            Assert.Equal(4, result);
        }
        
        [Fact]
        public void MeasureSquare_NegativeTest()
        {
            var lines = new List<string>
            {
                "1 1 1 0 0",
                "1 0 1 0 0",
                "1 1 1 0 0",
                "0 0 0 0 0",
                "0 0 0 0 0",
            };
            var grid = Grid.ConvertToGrid(lines);
            var result = Grid.MeasureSquare(0, 0, grid);
            Assert.Equal(3, result);
        }

        [Fact]
        public void ProduceEmptyRectangleTest()
        {
            var grid = Grid.ProduceEmptyRectangle(3, 3);
            var expectedLines = new List<string>
            {
                "0 0 0",
                "0 0 0",
                "0 0 0",
            };
            var expectedGrid = Grid.ConvertToGrid(expectedLines);

            Assert.Equal(expectedGrid.Count, grid.Count);
            Assert.Equal(expectedGrid.First().Length, grid.First().Length);

            for (var i = 0; i < grid.Count; i++)
            {
                Assert.Equal(expectedGrid[i], grid[i]);
            }
        }

        [Fact]
        public void PlaceSquare_22_on_33_00_Test()
        {
            var grid = Grid.ProduceEmptyRectangle(3, 3);
            grid = Grid.PlaceSquare(0, 0, 2, grid);
            var expectedLines = new List<string>
            {
                "1 1 0",
                "1 1 0",
                "0 0 0",
            };
            var expectedGrid = Grid.ConvertToGrid(expectedLines);
            
            Assert.Equal(expectedGrid.Count, grid.Count);
            Assert.Equal(expectedGrid.First().Length, grid.First().Length);

            for (var i = 0; i < grid.Count; i++)
            {
                Assert.Equal(expectedGrid[i], grid[i]);
            }
        }
        
        [Fact]
        public void PlaceSquare_33_on_22_11_Test()
        {
            var grid = Grid.ProduceEmptyRectangle(3, 3);
            grid = Grid.PlaceSquare(1, 1, 2, grid);
            var expectedLines = new List<string>
            {
                "0 0 0",
                "0 1 1",
                "0 1 1",
            };
            var expectedGrid = Grid.ConvertToGrid(expectedLines);
            
            Assert.Equal(expectedGrid.Count, grid.Count);
            Assert.Equal(expectedGrid.First().Length, grid.First().Length);

            for (var i = 0; i < grid.Count; i++)
            {
                Assert.Equal(expectedGrid[i], grid[i]);
            }
        }
    }
}