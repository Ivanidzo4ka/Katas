using System.Collections.Generic;

namespace Cracking.ChapterTwo
{
    public class Node
    {
        public Node Next { get; set; }
        public int Item { get; set; }

        public static Node CreateFromArray(int[] array)
        {
            var head = new Node();
            var last = head;
            foreach (var elem in array)
            {
                var current = new Node() { Item = elem };
                last.Next = current;
                last = current;
            }
            return head.Next;
        }

        public static IEnumerable<int> GetContent(Node head)
        {
            while (head != null)
            {
                yield return head.Item;
                head = head.Next;
            }
        }
    }
}
