using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Queue<T>
    {
        private const int DafaultCapacity = 4;
        private T[] array;
        private int head;
        private int tail;

        public Queue()
        {
            array = new T[DafaultCapacity+1];
            head = 0;
            tail = 0;
        }

        public int Count
        {
            get
            {
                if (head <= tail)
                    return tail - head;
                else
                    return tail - head + array.Length;
            }
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Grow();
            }
            array[tail] = item;
            MoveNext(ref tail);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            T result = array[head];
            MoveNext(ref head);
            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            return array[head];
        }

        private void MoveNext(ref int index)
        {
            // 인덱스가 배열크기 -1이면 0으로 아니면 인덱스 +1로
            index = (index == array.Length - 1) ? 0 : index + 1;
        }

        private bool IsEmpty()
        {
            return head == tail;
        }
        private bool IsFull()
        {
            if(head > tail)
            {
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }
        }

        private void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];
            if(head < tail)
            {
                Array.Copy(array, newArray, Count);
            }
            else
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
                head = 0;
                tail = Count;
            }
            array = newArray;
        }
    }

}
