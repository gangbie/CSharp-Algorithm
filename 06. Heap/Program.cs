namespace _06._Heap
{
    internal class Program
    {

        /******************************************************
		 * 힙 (Heap)
		 * 
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 ******************************************************/
        static void PriorityQueue()
        {
            // 기본 int 우선순위(오름차순) 적용
            PriorityQueue<string, int> ascendingpq = new PriorityQueue<string, int>();

            ascendingpq.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            ascendingpq.Enqueue("데이터2", 3);
            ascendingpq.Enqueue("데이터3", 5);
            ascendingpq.Enqueue("데이터4", 2);
            ascendingpq.Enqueue("데이터5", 4);

            while (ascendingpq.Count > 0) Console.WriteLine(ascendingpq.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력


            // 수정 int 우선순위 적용(내림차순)
            PriorityQueue<string, int> decendingpq = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));

            decendingpq.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            decendingpq.Enqueue("데이터2", 3);
            decendingpq.Enqueue("데이터3", 5);
            decendingpq.Enqueue("데이터4", 2);
            decendingpq.Enqueue("데이터5", 4);

            while (decendingpq.Count > 0) Console.WriteLine(decendingpq.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력
        }

        // 시간복잡도
        // 탐색(가장 우선순위 높은)     추가         삭제
        // O(1)                    O(logN)      O(logN)

        static void Main(string[] args)
        {
            // 기본 int 우선순위(오름차순) 적용
            DataStructure.PriorityQueue<string> pq1 = new DataStructure.PriorityQueue<string>();
            
            pq1.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            pq1.Enqueue("데이터2", 3);
            pq1.Enqueue("데이터3", 5);
            pq1.Enqueue("데이터4", 2);
            pq1.Enqueue("데이터5", 4);
            
            while (pq1.Count > 0) Console.WriteLine(pq1.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력
            
            
            // 수정 int 우선순위 적용
            //DataStructure.PriorityQueue<string> pq2 = new DataStructure.PriorityQueue<string>(Comparer<int>.Create((a, b) => b - a));
            //
            //pq2.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            //pq2.Enqueue("데이터2", 3);
            //pq2.Enqueue("데이터3", 5);
            //pq2.Enqueue("데이터4", 2);
            //pq2.Enqueue("데이터5", 4);
            //
            //while (pq2.Count > 0) Console.WriteLine(pq2.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력
        }
    }
}