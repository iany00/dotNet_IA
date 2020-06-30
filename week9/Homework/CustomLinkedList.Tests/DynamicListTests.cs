using System;
using System.Diagnostics.SymbolStore;
using NUnit.Framework;

namespace CustomLinkedList.Tests
{
    public class DynamicListTests
    {
        private DynamicList<int> sut;

        [SetUp]
        public void Setup()
        {
            this.sut = new DynamicList<int>();
        }

        [Test]
        public void CannotCallElementWithNegativeIndex()
        {
            var incorrectIndex = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var test = this.sut[incorrectIndex];
            }, "Provided index is less than zero");
        }

        [Test]
        public void CannotCallElementWithIndexAboveTheRange()
        {
            var incorrectIndex = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var test = this.sut[incorrectIndex];
            }, "Provided index is grated than the range of the collection");
        }

        [Test]
        public void AddShouldIncreaseCollectionCount()
        {
            this.sut.Add(1);

            Assert.AreEqual(1, this.sut.Count, "Adding an elemet dosen't affect the collection's count ");
        }

        [Test]
        [TestCase(1,0)]
        [TestCase(5,3)]
        [TestCase(10,8)]
        [TestCase(15,14)]
        public void AddShouldSaveTheElementInTheCollection(int numberOfAdditions, int indexToCheck)
        {
            this.AddElements(numberOfAdditions);

            Assert.AreEqual(indexToCheck, this.sut[indexToCheck], "Element is not the same as the one added");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(-6)]
        [TestCase(6)]
        public void RemoveAtIndexOutsideTheBoundariesIsImpossible(int indexToRemove)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.sut.Remove(indexToRemove));
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(10, 5)]
        [TestCase(10, 0)]
        public void RemoveAtShouldRemoveTheElementAtTheGivenIndex(int numberOfAdditions, int indexToRemove)
        {
            this.AddElements(numberOfAdditions);

            this.sut.RemoveAt(indexToRemove);

            Assert.AreEqual(indexToRemove +1 , sut[indexToRemove]);
        }

        [Test]
        [TestCase(3,3)]
        [TestCase(3,1)]
        public void RemoveUnexistentElementShouldReturnNegativeInteger(int numberOFAdditions, int elemetToRemove)
        {
            this.AddElements(numberOFAdditions);

            var isLessThanZero = this.sut.Remove(elemetToRemove) < 0;

            Assert.IsTrue(isLessThanZero, "Attemptuing to remove an unexistent element ");
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(5, 4)]
        [TestCase(10, 7)]
        public void ContainsShouldReturnTrueIfElementExists(int numberOfAdditions, int keyElement)
        {
            this.AddElements(numberOfAdditions);

            Assert.IsTrue(this.sut.Contains(keyElement), "Contains returns false for existing element");
        }

        private void AddElements(int numberOfAdditions)
        {
            for (int i = 0; i < numberOfAdditions; i++)
            {
                this.sut.Add(i);
            }
        }
    }
}