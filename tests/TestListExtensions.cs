using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Models;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestListExtensions
    {
        [Fact]
        public void FullyContains_ReturnsTrueWhenSet1FullyContainsSet2()
        {
            // Arrange
            List<long> set1 = new List<long> { 1, 10 };
            List<long> set2 = new List<long> { 3, 8 };

            // Act
            bool result = set1.FullyContains(set2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void FullyContains_ReturnsFalseWhenSet1DoesNotFullyContainSet2()
        {
            // Arrange
            List<long> set1 = new List<long> { 1, 5 };
            List<long> set2 = new List<long> { 7, 10 };

            // Act
            bool result = set1.FullyContains(set2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void FullyContains_ReturnsFalseWhenSet1IsEmpty()
        {
            // Arrange
            List<long> set1 = new List<long>();
            List<long> set2 = new List<long> { 3, 8 };

            // Act
            bool result = set1.FullyContains(set2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasIntersection_ReturnsTrueWhenSetsHaveIntersection()
        {
            // Arrange
            List<long> set1 = new List<long> { 1, 5 };
            List<long> set2 = new List<long> { 3, 8 };

            // Act
            bool result = set1.HasIntersection(set2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasIntersection_ReturnsFalseWhenSetsDoNotHaveIntersection()
        {
            // Arrange
            List<long> set1 = new List<long> { 1, 3 };
            List<long> set2 = new List<long> { 4, 8 };

            // Act
            bool result = set1.HasIntersection(set2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasIntersection_ReturnsFalseWhenSet1IsEmpty()
        {
            // Arrange
            List<long> set1 = new List<long>();
            List<long> set2 = new List<long> { 3, 8 };

            // Act
            bool result = set1.HasIntersection(set2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ReturnSmallestNonEmpty_ReturnsSmallestList()
        {
            // Arrange
            List<GridNode<int>> list1 = new List<GridNode<int>> { new GridNode<int>(1), new GridNode<int>(2) };
            List<GridNode<int>> list2 = new List<GridNode<int>> { new GridNode<int>(3) };

            // Act
            List<GridNode<int>> result = list1.ReturnSmallestNonEmpty(list2);

            // Assert
            Assert.Same(list2, result);
        }

        [Fact]
        public void ReturnSmallestNonEmpty_ReturnsList2WhenList1IsEmpty()
        {
            // Arrange
            List<GridNode<int>> list1 = new List<GridNode<int>>();
            List<GridNode<int>> list2 = new List<GridNode<int>> { new GridNode<int>(1) };

            // Act
            List<GridNode<int>> result = list1.ReturnSmallestNonEmpty(list2);

            // Assert
            Assert.Same(list2, result);
        }

        [Fact]
        public void ReturnSmallestNonEmpty_ReturnsList1WhenList2IsEmpty()
        {
            // Arrange
            List<GridNode<int>> list1 = new List<GridNode<int>> { new GridNode<int>(1) };
            List<GridNode<int>> list2 = new List<GridNode<int>>();

            // Act
            List<GridNode<int>> result = list1.ReturnSmallestNonEmpty(list2);

            // Assert
            Assert.Same(list1, result);
        }

        [Fact]
        public void ReturnSmallestNonEmpty_ReturnsList1WhenBothListsAreEqual()
        {
            // Arrange
            List<GridNode<int>> list1 = new List<GridNode<int>> { new GridNode<int>(1) };
            List<GridNode<int>> list2 = new List<GridNode<int>> { new GridNode<int>(2) };

            // Act
            List<GridNode<int>> result = list1.ReturnSmallestNonEmpty(list2);

            // Assert
            Assert.Same(list1, result);
        }
    }

}
