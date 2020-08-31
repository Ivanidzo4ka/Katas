using System;
using System.Collections.Generic;

namespace Cracking.ChapterTwo
{
    public class Exercises
    {
        public static void RemoveDuplicates(Node head)
        {
            var hash = new HashSet<int>();
            Node previous = null;
            while (head != null)
            {
                if (hash.Contains(head.Item))
                {
                    previous.Next = head.Next;
                }
                else
                {
                    hash.Add(head.Item);
                    previous = head;
                }
                head = head.Next;
            }
        }

        public static bool MeetBefore(Node head, Node element)
        {
            while (head != element)
            {
                if (head.Item == element.Item)
                    return true;
                head = head.Next;
            }
            return false;
        }

        public static void RemoveDuplicatesNoExtraMemory(Node head)
        {
            var originalHead = head;
            Node previous = null;
            while (head != null)
            {

                if (MeetBefore(originalHead, head))
                {
                    previous.Next = head.Next;
                }
                else
                {
                    previous = head;
                }
                head = head.Next;
            }
        }
    }
}
