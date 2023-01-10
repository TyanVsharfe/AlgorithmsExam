using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam.List
{
    public class Stack<T>
    {
        private HashNode<T> Head { get; set; }
        private HashNode<T> Tail { get; set; }

        public int Count { get; private set; }

        public void Push(T data)
        {
            var node = new HashNode<T>(data);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }

            Count++;
        }

        public T Pop()
        {
            if (Tail == null)
            {
                throw new InvalidOperationException("stack is empty");
            }

            var data = Tail.Data;
            if (Tail.Prev == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }

            Count--;
            return data;
        }

        public T Peek()
        {
            if (Tail == null)
            {
                throw new InvalidOperationException("stack is empty");
            }

            var data = Tail.Data;
            return data;
        }

        public bool Contains(T data)
        {
            if (Head == null) return false;
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
    }






    public class Queue<T>
    {
        private HashNode<T> Head { get; set; }
        private HashNode<T> Tail { get; set; }
        public int Count { get; private set; }

        public void Enqueue(T data)
        {
            var node = new HashNode<T>(data);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("queue is empty");
            }

            var data = Head.Data;
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
            }

            Count--;
            return data;
        }

        public T Peek()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("queue is empty");
            }

            var data = Head.Data;
            return data;
        }

        public bool Contains(T data)
        {
            if (Head == null) return false;
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
    }
}
