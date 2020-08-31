using System;
using System.Text;
using Xunit;

namespace Cracking.ChapterOne.Tests
{
    public class ExerciseTests
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("a", true)]
        [InlineData("ab", true)]
        [InlineData("aa", false)]
        [InlineData("bb", false)]
        [InlineData("aba", false)]
        public void UniqueCharacters(string data, bool expected)
        {
            Assert.Equal(expected, Exercises.UniqueCharactersNoExtraSpace(data));
            Assert.Equal(expected, Exercises.UniqueCharactersUsingHashset(data));
        }
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("ab", "ba")]
        [InlineData("abc", "cba")]
        [InlineData("abcd", "dcba")]
        public void TraverseCString(string data, string expected)
        {
            var cStyleString = new char?[data.Length + 1];
            cStyleString[data.Length] = null;
            for (int i = 0; i < data.Length; i++)
                cStyleString[i] = data[i];
            Exercises.ReverseCString(ref cStyleString);

            Assert.Null(cStyleString[cStyleString.Length - 1]);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < cStyleString.Length - 1; i++)
                stringBuilder.Append(cStyleString[i]);
            Assert.Equal(expected, stringBuilder.ToString());
        }

        [Theory]
        [InlineData("aaa", "a")]
        [InlineData("abbaa", "ab")]
        [InlineData("abc", "abc")]
        [InlineData("", "")]
        [InlineData("abbccc", "abc")]
        public void RemoveDuplicates(string data, string expected)
        {
            Assert.Equal(expected, Exercises.RemoveDuplicates(data));
        }

        [Theory]
        [InlineData("anagram", "managra", true)]
        [InlineData("abc", "cba", true)]
        [InlineData("a aa", " aaa", true)]
        [InlineData("aba", "aaa", false)]
        [InlineData("", "", true)]
        [InlineData("a", "b", false)]

        public void Anagram(string original, string testing, bool result)
        {
            Assert.Equal(result, Exercises.IsAnamgrams(original, testing));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("a ", "a%20")]
        [InlineData(" a", "%20a")]
        [InlineData("a  a", "a%20%20a")]
        public void ReplaceSpaces(string data, string expected)
        {
            Assert.Equal(expected, Exercises.ReplaceSpaces(data));
        }

        [Fact]
        public void RotateMatrix()
        {
            int[][] original = new int[4][] {
               new int[4] { 1, 2, 3, 4 },
               new int[4] { 5, 6, 7, 8 },
                new int[4]{ 9, 10, 11, 12 },
                new int[4]{ 13, 14, 15, 16 }
            };
            int[][] expected = new int[4][] {
                new int[4]{ 13, 9, 5, 1 },
                new int[4]{ 14, 10, 6, 2 },
                new int[4]{ 15, 11, 7, 3 },
                new int[4]{ 16, 12, 8, 4 } };
            Exercises.Rotate(ref original, 4);
            Assert.Equal(expected, original);
        }
    }
}
