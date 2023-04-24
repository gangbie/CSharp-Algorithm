using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{                              //실제 데이터, 우선순위
    internal class PriorityQueue<TElement>   //TPriority 대신 무조건 int 써도 ㄱㅊ
    {
        private struct Node
        {
            public TElement element;
            public int priority;
        }

        private List<Node> nodes;

        public PriorityQueue()
        {
            this.nodes = new List<Node>();
        }

        public int Count { get { return nodes.Count; } }

        public void Enqueue(TElement element, int priority)
        {
            Node newNode = new Node() { element = element, priority = priority };
            // 1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);
            int newNodeIndex = nodes.Count - 1;
            // 2. 새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            while(newNodeIndex > 0)
            {
                // 2-1. 부모노드 확인
                int parentIndex = GetParentIndex(newNodeIndex);
                Node parentNode = nodes[parentIndex];

                // 2-2. 자식노드가 부모노드보다 우선순위 높으면 교체
                if(newNode.priority < parentNode.priority)
                {
                    nodes[newNodeIndex] = parentNode;
                    nodes[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public TElement Dequeue()
        {
            Node rootNode = nodes[0];

            // 1. 0번 빼고서 마지막놈 최상단으로 올림(복사)
            Node lastNode = nodes[nodes.Count - 1];
            nodes[0] = lastNode;
            // 1-1. 올렸으면 가장 마지막놈 지움
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            // 2. 자식노드들과 비교하여 더 작은 자식과 교체
            while(index < nodes.Count)
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int righttChildIndex = GetRightChildIndex(index);

                // 2-1. 자식이 둘 다 있는 경우
                if (righttChildIndex < nodes.Count)
                {
                    // 자식들 먼저 비교 lessChildIndex
                    int lessChildIndex = nodes[leftChildIndex].priority < nodes[righttChildIndex].priority
                        ? leftChildIndex : righttChildIndex;
                    // less랑 현재랑 비교
                    if (nodes[lessChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[lessChildIndex];
                        nodes[lessChildIndex] = lastNode;
                        index = lessChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                // 2-2. 자식이 하나만 있는 경우 == 왼쪽 자식만 있는 경우
                else if (leftChildIndex < nodes.Count)
                {
                    if (nodes[leftChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[leftChildIndex];
                        nodes[leftChildIndex] = lastNode;
                        index = leftChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                // 2-3. 자식이 없는 경우
                else
                {
                    break;
                }
            }

            return rootNode.element;
        }

        public TElement Peak()
        {
            return nodes[0].element;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }
        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
        public int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }
    }
}
