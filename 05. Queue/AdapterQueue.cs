using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /******************************************************
	 * 어댑터 패턴 (Adapter)
	 * 
	 * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
	 ******************************************************/
    // Queue는 어댑터 패턴으로 하기 비적합
    // 링크드리스트는 노드기반이기 때문에 가비지컬렉터에 부담이 됨

    public class AdapterQueue<T>
    {
        private LinkedList<T> container;

        public AdapterQueue()
        {
            container = new LinkedList<T>();
        }

        public void Push(T item)
        {
            container.AddLast(item);
        }

        public T Pop()
        {
            T value = container.First<T>();
            container.RemoveFirst();
            return value;
        }
    }
}
