using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cracking.ChapterOne
{
    /// <summary>
    /// Implement an algorithm to determine if a string has all unique characters. What if you
    // can not use additional data structures?
    /// </summary>
    public static class Exercises
    {
        /// <summary>
        /// Implement an algorithm to determine if a string has all unique characters. What if you
        //  can not use additional data structures?
        /// </summary>
        public static bool UniqueCharactersUsingHashset(string data)
        {
            var hash = new HashSet<char>();
            foreach (var character in data)
            {
                if (hash.Contains(character))
                    return false;
                else
                    hash.Add(character);
            }
            return true;
        }

        public static bool UniqueCharactersNoExtraSpace(string data)
        {
            for (int i = 0; i < data.Length; i++)
                for (int j = i + 1; j < data.Length; j++)
                    if (data[i] == data[j])
                        return false;

            return true;
        }
        /// <summary>
        /// Write code to reverse a C-Style String. (C-String means that “abcd” is represented as
        // five characters, including the null character.)
        /// </summary>
        public static void ReverseCString(ref char?[] cStyleString)
        {
            if (cStyleString.Length == 0 || cStyleString[cStyleString.Length - 1] != null) throw new Exception("Not an C-String");
            int median = (cStyleString.Length - 1) / 2;
            for (int i = 0; i < median; i++)
            {
                char? t = cStyleString[i];

                cStyleString[i] = cStyleString[cStyleString.Length - 2 - i];
                cStyleString[cStyleString.Length - 2 - i] = t;
            }
        }

        /// <summary>
        /// Write a method to decide if two strings are anagrams or not.
        /// </summary>
        public static bool IsAnamgrams(string original, string testing)
        {
            Dictionary<char, int> histogram = new Dictionary<char, int>();
            if (original.Length != testing.Length)
                return false;
            for (int i = 0; i < original.Length; i++)
                if (histogram.ContainsKey(original[i]))
                    histogram[original[i]]++;
                else
                    histogram[original[i]] = 1;

            for (int i = 0; i < testing.Length; i++)
                if (!histogram.ContainsKey(testing[i]))
                    return false;
                else
                {
                    histogram[testing[i]]--;
                    if (histogram[testing[i]] < 0) return false;
                }
            return true;
        }

        public static string ReplaceSpaces(string data)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                if (data[i] == ' ')
                    sb.Append("%20");
                else sb.Append(data[i]);
            return sb.ToString();
        }

        /// <summary>
        /// a b c d    1,1 -> 1,4   1,2 -> 2,4   1,3 -> 3,4
        /// e f g h    2,1 -> 1,3   2,2 -> 2,3   2,3 -> 2,4  
        /// k l m n  
        /// o p r s
        /// 
        /// o k e a
        /// p l f b
        /// r m g c
        /// s n h d
        /// Given an image represented by an NxN matrix, where each pixel in the image is 4
        /// bytes, write a method to rotate the image by 90 degrees.Can you do this in place?
        /// </summary>
        /// <param name="original"></param>
        public static void Rotate(ref int[][] matrix, int n)
        {
            for (int layer = 0; layer < n / 2; ++layer)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; ++i)
                {
                    int offset = i - first;
                    int top = matrix[first][i]; // save top
                                                // left -> top
                    matrix[first][i] = matrix[last - offset][first];
                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset];
                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];
                    // top -> right
                    matrix[i][last] = top; // right <- saved top
                }
            }
        }

        /// <summary>
        /// Design an algorithm and write code to remove the duplicate characters in a string
        ///without using any additional buffer.NOTE: One or two additional variables are fine.
        /// An extra copy of the array is not.
        /// </summary>
        public static string RemoveDuplicates(string data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                int count = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (data[i] == data[j])
                    {
                        count++;
                        if (count == 2)
                            break;
                    }

                }
                if (count == 0)
                    sb.Append(data[i]);
            }
            return sb.ToString();
        }
    }
}
