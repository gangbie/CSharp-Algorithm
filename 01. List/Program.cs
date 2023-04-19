using System.Collections.Generic;

namespace _01._List
{
    internal class Program
    {
        /******************************************************
		 * 배열 (Array)   !!메모리를 어떻게 사용하는지 숙지(메모리 구조 확인)!!
		 * 
		 * 연속적인 메모리상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
		 * 초기화때 정한 크기가 소멸까지 유지됨
		 * 배열의 요소는 인덱스를 사용하여 직접적으로 엑세스 가능
		 ******************************************************/

        // <배열의 사용>
        void Array()
        {
            int[] intArray = new int[100];

            // 인덱스를 통한 접근
            intArray[0] = 10;
            int value = intArray[0];
        }

        // <배열의 시간복잡도>
        // 접근		탐색
        // O(1)		O(N)

        // int 배열 20번째 자료 접근 : O(1) 20번째 자료의 주소 = 배열의 주소 + int 자료형의 크기(4byte) * 19
        // 데이터가 n개 있을 때 탐색 : O(n)
        // public int FindIndex(int[] intArray, int data)
        // {
        //     for(int i = 0; i < intArray.Length; i++)
        //     {
        //         if (intArray[i] == data)
        //             return i;
        //     }
        //     return -1;
        // }


        /******************************************************
		 * List(선형리스트)(동적배열) (Dynamic Array)
		 * 
		 * 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
		 * 배열요소의 갯수를 특정할 수 없는 경우 사용
		 ******************************************************/

        // <List의 사용>
        void List1()
        {
            List<string> list = new List<string>();

            // 배열 요소 삽입
            list.Add("0번 데이터");
            list.Add("1번 데이터");
            list.Add("2번 데이터");

            // 배열 요소 삭제
            list.Remove("1번 데이터");

            // 배열 요소 접근
            list[0] = "데이터0";
            string value = list[0];

            // 배열 요소 탐색
            string? findValue = list.Find(x => x.Contains('2'));
            int findIndex = list.FindIndex(x => x.Contains('0'));
        }

        // <List의 시간복잡도>
        // 접근   	탐색		삽입		삭제
        // O(1)		O(n)	    O(n)    	O(n)

        static void Main(string[] args)
        {
            /*
            List<string> list = new List<string>();

            list.Add("1번 데이터");
            list.Add("2번 데이터");
            list.Add("3번 데이터");
            list.Add("4번 데이터");
            list.Add("5번 데이터");

            string value;
            value = list[0];
            value = list[1];
            value = list[2];
            value = list[3];
            value = list[4];

            list[0] = "5번 데이터";
            list[1] = "4번 데이터";
            list[2] = "3번 데이터";
            list[3] = "2번 데이터";
            list[4] = "1번 데이터";

            list.Remove("3번 데이터");
            list.Remove("2번 데이터");

            string? findValue = list.Find(x => x.Contains('4'));
            int findIndex = list.FindIndex(x => x.Contains('1'));
            */

            DataStructure.List<int> list = new DataStructure.List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Remove(2);
            list.RemoveAt(0);

            list[0] = 10;
            int intNum = list[0];

            for(int i=0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }


        }

    }
}