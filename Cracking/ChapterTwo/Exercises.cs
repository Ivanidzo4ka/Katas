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
        /// <summary>
        /// Implement an algorithm to find the nth to last element of a singly linked list.
        /// </summary>
        public static Node GetNthElementFromEnd(Node head, int n)
        {
            if (n < 1 || head == null)
                return null;
            var orignal = head;
            var current = head;
            for (int i = 0; i < n - 1; i++)
            {
                if (current == null)
                    return null;
                current = current.Next;
            }
            while (current.Next != null)
            {
                current = current.Next;
                orignal = orignal.Next;
            }
            return orignal;
        }

        /// <summary>
        /// Implement an algorithm to delete a node in the middle of a single linked list, given
        /// only access to that node.
        /// </summary>
        public static void DeleteNode(Node node)
        {
            if (node == null || node.Next == null)
                return;
            node.Item = node.Next.Item;
            node.Next = node.Next.Next;
        }

        /// <summary>
        /// You have two numbers represented by a linked list, where each node contains a sin-
        /// gle digit.The digits are stored in reverse order, such that the 1’s digit is at the head of
        /// the list. Write a function that adds the two numbers and returns the sum as a linked
        /// list.
        /// </summary>
        public static Node Summarize(Node headOne, Node headTwo)
        {
            var head = new Node();
            var last = head;
            int carryOver = 0;
            while (headOne != null && headTwo != null)
            {
                var current = new Node() { Item = (headOne.Item + headTwo.Item + carryOver) % 10 };
                last.Next = current;
                last = last.Next;
                carryOver = (headOne.Item + headTwo.Item + carryOver) / 10;
                headOne = headOne.Next;
                headTwo = headTwo.Next;
            }
            while (headOne != null)
            {
                var current = new Node() { Item = (headOne.Item + carryOver) % 10 };
                last.Next = current;
                last = last.Next;
                carryOver = (headOne.Item + carryOver) / 10;
                headOne = headOne.Next;
            }
            while (headTwo != null)
            {
                var current = new Node() { Item = (headTwo.Item + carryOver) % 10 };
                last.Next = current;
                last = last.Next;
                carryOver = (headTwo.Item + carryOver) / 10;
                headTwo = headTwo.Next;
            }
            if (carryOver != 0)
            {
                var current = new Node() { Item = carryOver };
                last.Next = current;
                last = last.Next;
            }
            return head.Next;
        }
    }
}
