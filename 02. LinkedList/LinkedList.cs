using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T item;

        // 아래 세개 무슨 의미인지 파악하기!!
        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return item; } set { item = value; } }
    }
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T value)
        {
            // 1. 새로 노드 만들기
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            
            // 2. 연결구조 변경(새로운 노드의 다음 노드를 head로, head의 이전 노드를 새로운 노드로)
            if(head != null)    // 2-1. head노드가 있을 때
            {
                newNode.next = head;
                head.prev = newNode;
            // 3. head를 새로 만든 노드로 변경
                head = newNode;
            }
            else              // 2-2. head노드가 없을 때
            {
                head = newNode;
                tail = newNode;
            }

            // 4. 갯수 늘리기
            count++;
            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (tail != null)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else
            {
                tail = newNode;
                head = newNode;
            }
            count++;
            return newNode;
        }

        public void Remove(LinkedListNode<T> node)
        {   
            // 예외1 : node가 연결리스트에 포함된 노드가 아닌 경우
            if (node.list != this)
                throw new InvalidOperationException();
            // 예외2 : 노드가 null인 경우
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            // 0. 지웠을 때 head나 tail이 변경되는 경우
            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;

            // 1. 연결구조 바꾸기(이전 노드가 내 다음 노드를 next로, 다음 노드가 내 이전 노드를 prev로)
            if(node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;
            // 2. 노드 지우기(갯수 줄이기)
            count--;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> findNode = Find(value);
            if(findNode != null)
            {
                Remove(findNode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> target = head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            while (target != null)
            {
                if (comparer.Equals(value, target.Value))
                {
                    return target;
                }
                else
                {
                    target = target.next;
                }
                
            }
            return null;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            // 예외1 : node가 연결리스트에 포함된 노드가 아닌 경우
            if (node.list != this)
                throw new InvalidOperationException();
            // 예외2 : 노드가 null인 경우
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            // 1. 새로운 노드 만들기
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            // 2. 연결구조 바꾸기
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev = newNode;
            if(node.prev != null)       // 이전 노드가 없다는 것은 노드가 헤드라는 것
            {
                node.prev.next = newNode;
            }
            else
            {
                head = newNode;
            }
            // 3. 갯수 증가
            count++;
            return newNode;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            // 예외1 : node가 연결리스트에 포함된 노드가 아닌 경우
            if (node.list != this)
                throw new InvalidOperationException();
            // 예외2 : 노드가 null인 경우
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            // 1. 새로운 노드 만들기
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            // 2. 연결구조 바꾸기
            newNode.prev = node;
            newNode.next = node.next;
            node.next = newNode;
            if (node.next != null)       // 다음 노드가 없다는 것은 노드가 테일라는 것
            {
                node.next.prev = newNode;
            }
            else
            {
                tail = newNode;
            }
            // 3. 갯수 증가
            count++;
            return newNode;
        }

        // 링크드리스트 기술면접 조사
    }
}
