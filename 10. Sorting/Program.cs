﻿namespace _10._Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<int> selectionList = new List<int>();
            List<int> insertionList = new List<int>();
            List<int> bubbleList = new List<int>();
            List<int> heapList = new List<int>();
            List<int> mergeList = new List<int>();
            List<int> quickList = new List<int>();

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < 20; i++)
            {
                int rand = random.Next() % 100;
                Console.Write(string.Format("{0} ", rand));

                selectionList.Add(rand);
                insertionList.Add(rand);
                bubbleList.Add(rand);
                heapList.Add(rand);
                mergeList.Add(rand);
                quickList.Add(rand);
            }
            Console.WriteLine();

            Console.WriteLine("선택 정렬 결과 : ");
            Sorting.SelectionSort(selectionList);
            foreach (int i in selectionList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("삽입 정렬 결과 : ");
            Sorting.InsertionSort(insertionList);
            foreach (int i in insertionList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("버블 정렬 결과 : ");
            Sorting.BubbleSort(bubbleList);
            foreach (int i in bubbleList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("힙 정렬 결과 : ");
            Sorting.HeapSort(heapList);
            foreach (int i in heapList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("합병 정렬 결과 : ");
            Sorting.MergeSort(mergeList, 0, mergeList.Count - 1);
            foreach (int i in mergeList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("퀵 정렬 결과 : ");
            Sorting.QuickSort(quickList, 0, quickList.Count - 1);
            foreach (int i in quickList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();
        }
    }
}