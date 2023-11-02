using AdventOfCodeShared.Extensions;
using System;
using Xunit;

namespace Tests
{
    public class TestArrayExtensions
    {
        [Fact]
        public void RemoveAt_RemovesElementAtIndex()
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5 };
            int index = 2;

            // Act
            int[] result = arr.RemoveAt(index);

            // Assert
            Assert.Equal(new int[] { 1, 2, 4, 5 }, result);
        }

        [Fact]
        public void Add_Params_AddsMultipleElements()
        {
            // Arrange
            int[] arr = { 1, 2, 3 };
            int[] items = { 4, 5, 6 };

            // Act
            int[] result = arr.Add(items);

            // Assert
            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6 }, result);
        }

        [Fact]
        public void Add_Item_AddsSingleElement()
        {
            // Arrange
            int[] arr = { 1, 2, 3 };
            int item = 4;

            // Act
            int[] result = arr.Add(item);

            // Assert
            Assert.Equal(new int[] { 1, 2, 3, 4 }, result);
        }

        [Fact]
        public void Add_NullArray_AddsSingleElement()
        {
            // Arrange
            int[] arr = null;
            int item = 4;

            // Act
            int[] result = arr.Add(item);

            // Assert
            Assert.Equal(new int[] { 4 }, result);
        }

        [Fact]
        public void Add_NullArrayWithParams_AddsMultipleElements()
        {
            // Arrange
            int[] arr = null;
            int[] items = { 1, 2, 3 };

            // Act
            int[] result = arr.Add(items);

            // Assert
            Assert.Equal(new int[] { 1, 2, 3 }, result);
        }
    }
}