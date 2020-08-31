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
    }
}
