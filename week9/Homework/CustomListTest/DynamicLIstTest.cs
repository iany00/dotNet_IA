using System;
using CustomLinkedList;
using Xunit;

namespace CustomListTest
{
    public class DynamicLIstTest
    {
        public class UnitTest1
        {
            [Fact]
            public void AddingStringToListShouldExists()
            {
                string testString = "This is a string";
                var dynamicList = new DynamicList<string>();
                dynamicList.Add(testString);

                var expected = true;
                var contains = dynamicList.Contains(testString);
                Assert.Equal(expected, contains);
            }

            [Fact]
            public void AddingFirstNodeShouldBecomeHead()
            {
                string testString = "This is a string";
                var dynamicList = new DynamicList<string>();
                dynamicList.Add(testString);

                var expected = testString;
                Assert.Equal(expected, dynamicList[0]);
            }

            [Fact]
            public void ContainsMethodShouldBeTrue()
            {
                string testString = "This is a string";
                var dynamicList = new DynamicList<string>();
                dynamicList.Add(testString);

                var expected = true;
                Assert.Equal(expected, dynamicList.Contains(testString));
            }

            [Fact]
            public void RemoveShouldNotContainElement()
            {
                string testString = "This is a string";
                var dynamicList = new DynamicList<string>();
                dynamicList.Add(testString);

                dynamicList.Remove(testString);

                var expected = -1;
                var result = dynamicList.IndexOf(testString);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void RemoveAtShouldNotContainElement()
            {
                string testString = "This is a string";
                var dynamicList = new DynamicList<string>();
                dynamicList.Add(testString);

                dynamicList.RemoveAt(0);

                var expected = -1;
                var result = dynamicList.IndexOf(testString);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void RemoveAtShouldContainElement()
            {
                string testString = "This is a string";
                var dynamicList = new DynamicList<string>();
                dynamicList.Add(testString);

                string testString2 = "Second String";
                dynamicList.Add(testString2);

                dynamicList.RemoveAt(1);

                var expected = 0;
                var result = dynamicList.IndexOf(testString);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void RemoveSpecificNodeShould()
            {
                string testString = "This is a string";
                var dynamicList = new DynamicList<string>();
                dynamicList.Add(testString);

                string testString2 = "Second String";
                dynamicList.Add(testString2);
            }
        }
    }
}
