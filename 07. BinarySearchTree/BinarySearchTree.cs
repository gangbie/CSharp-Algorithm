using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;
        public class Node
        {
            public T item;
            public Node parent;
            public Node left;
            public Node right;
            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }
            public bool HasNoChild { get { return left == null && right == null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
        }

        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);

            if(root == null)
            {
                root = newNode;
                return;
            }
            Node current = root;
            while(current != null)
            {
                // 비교해서 더 작은 경우 왼쪽으로
                if (item.CompareTo(current.item) < 0)
                {
                    // 비교노드가 왼쪽 자식이 있는 경우
                    if(current.left != null)
                    {
                        // 왼쪽 자식과 또 비교하기 위해 current를 왼쪽 자식으로 설정
                        current = current.left;
                    }
                    // 비교노드가 왼쪽 자식이 없는경우
                    else
                    {
                        // 그자리가 지금 추가가 될 자리
                        current.left = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                // 더 큰경우 오른쪽으로
                else if(item.CompareTo(current.item) > 0)
                {
                    // 비교노드가 오른쪽 자식이 있는 경우
                    if(current.right != null)
                    {
                        // 오른쪽 자식과 또 비교하기 위해 current를 오른쪽자식으로 설정
                        current = current.right;
                    }
                    // 비교노드가 오른쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리가 지금 추가가 될 자리
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                // 똑같은 경우
                else
                {
                    return;
                }
            }
        }

        public bool TryGetValue(T item, out T outValue)
        {
            if(root == null)
            {
                outValue = default(T);
                return false;
            }

            Node findNode = FindNode(item);
            if (findNode == null)
            {
                outValue = default(T);
                return false;
            }
            else
            {
                outValue = findNode.item;
                return true;
            }
        }

        public Node FindNode(T item)
        {
            if (root == null)
            {
                return null;
            }

            Node current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)
                {
                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    current = current.right;
                }
                else
                {
                    return current;
                }
            }
            return null;
        }

        public bool Remove(T item)
        {
            Node findNode = FindNode(item);

            if(findNode == null)
            {
                return false;
            }
            else
            {
                EraseNode(findNode);
                return true;
            }
        }

        private void EraseNode(Node node)
        {
            // 1. 자식노드가 없는 노드일 경우
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)
                {
                    node.parent.left = null;
                }else if (node.IsRightChild)
                {
                    node.parent.right = null;
                }
                else
                {
                    root = null;
                }
            }
            // 2. 자식노드가 1개인 노드일 경우
            else if(node.HasLeftChild || node.HasRightChild)
            {
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.left : node.right;
                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else // if(node.IsRootNode)
                {
                    root = child;
                    child.parent = null;
                }
            }
            // 3. 자식노드가 2개인 노드일 경우
            // 왼쪽 자식 중 가장 큰 값과 데이터 교환한 후, 그 노드를 지워주는 방식으로 대체
            // 왼쪽으로 한 칸 간 뒤 계속 오른쪽으로만 가면 됨
            else // if(node.HasBothChild)
            {
                Node replaceNode = node.left;
                while(replaceNode.right != null)
                {
                    replaceNode = replaceNode.right;
                }
                node.item = replaceNode.item;
                EraseNode(replaceNode);

                // 오른쪽꺼 제일 작은 값으로 해도 됨
                /*
                Node replaceNode = node.right;
                while (replaceNode.left != null)
                {
                    replaceNode = replaceNode.left;
                }
                node.item = replaceNode.item;
                EraseNode(replaceNode);
                */
            }
        }
        
    }
}
