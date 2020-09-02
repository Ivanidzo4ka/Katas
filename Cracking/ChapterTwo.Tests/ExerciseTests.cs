using System;
using Xunit;
using Xunit.Abstractions;

namespace Cracking.ChapterTwo.Tests
{
    public class ExerciseTests
    {


        [Fact]
        public void ValidateConstruction()
        {
            var content = new int[] { 1, 2, 3, 4, 5 };
            var head = Node.CreateFromArray(content);
            Assert.Equal(content, Node.GetContent(head));
        }

        [Fact]
        public void RemoveDuplicates()
        {
            var head = Node.CreateFromArray(new int[] { 1, 1, 1, 2, 2 });
            Exercises.RemoveDuplicates(head);
            Assert.Equal(new int[] { 1, 2 }, Node.GetContent(head));

            head = Node.CreateFromArray(new int[] { 1, 2, 3, 4 });
            Exercises.RemoveDuplicates(head);
            Assert.Equal(new int[] { 1, 2, 3, 4 }, Node.GetContent(head));


            head = Node.CreateFromArray(new int[] { 1, 1, 1, 2, 2 });
            Exercises.RemoveDuplicatesNoExtraMemory(head);
            Assert.Equal(new int[] { 1, 2 }, Node.GetContent(head));

            head = Node.CreateFromArray(new int[] { 1, 2, 3, 4 });
            Exercises.RemoveDuplicatesNoExtraMemory(head);
            Assert.Equal(new int[] { 1, 2, 3, 4 }, Node.GetContent(head));
        }

        [Fact]
        public void GetNthElementFromEnd()
        {
            var head = Node.CreateFromArray(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            var result = Exercises.GetNthElementFromEnd(head, 3);

            Assert.Equal(5, result.Item);
            result = Exercises.GetNthElementFromEnd(head, 2);
            Assert.Equal(6, result.Item);
            result = Exercises.GetNthElementFromEnd(head, 1);
            Assert.Equal(7, result.Item);
            result = Exercises.GetNthElementFromEnd(head, 10);
            Assert.Null(result);
        }

        [Fact]
        public void DeleteNode()
        {
            var head = Node.CreateFromArray(new int[] { 1, 2, 3, 4 });
            var node = head.Next.Next;
            Exercises.DeleteNode(node);
            Assert.Equal(new int[] { 1, 2, 4 }, Node.GetContent(head));
        }

        [Fact]
        public void Summarize()
        {
            var headOne = Node.CreateFromArray(new int[] { 3, 2, 1 });
            var headTwo = Node.CreateFromArray(new int[] { 3, 2, 1 });
            var sum = Exercises.Summarize(headOne, headTwo);
            Assert.Equal(new int[] { 6, 4, 2 }, Node.GetContent(sum));
            headOne = Node.CreateFromArray(new int[] { 9, 9, 9 });
            headTwo = Node.CreateFromArray(new int[] { 9, 9, 9 });
            sum = Exercises.Summarize(headOne, headTwo);
            Assert.Equal(new int[] { 8, 9, 9, 1 }, Node.GetContent(sum));

            headOne = Node.CreateFromArray(new int[] { 1 });
            headTwo = Node.CreateFromArray(new int[] { 9, 9, 9 });
            sum = Exercises.Summarize(headOne, headTwo);
            Assert.Equal(new int[] { 0, 0, 0, 1 }, Node.GetContent(sum));

            headOne = Node.CreateFromArray(new int[] { 9, 9, 9 });
            headTwo = Node.CreateFromArray(new int[] { 9 });
            sum = Exercises.Summarize(headOne, headTwo);
            Assert.Equal(new int[] { 8, 0, 0, 1 }, Node.GetContent(sum));
        }
    }
}
