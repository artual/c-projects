using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node(T value)
        {
            this.value = value;
        }
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
        public override string ToString()
        {
            string answer = "";
            Node<T> p1 = this;
            while (p1 != null)
            {
                answer += p1.value.ToString();
                if (p1.GetNext() != null)
                {
                    answer += "\n\n";
                }
                p1 = p1.GetNext();
            }
            return answer;
        }

        public T GetValue()
        {
            return this.value;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public Node<T> GetNext()
        {
            return this.next;
        }
        public Node<T> GetNext(int num)
        {
            Node<T> p = this;
            for (int i = 0; i < num; i++)
            {
                p = p.next;
            }
            return p;
        }
        public Node<T> GetLast()
        {
            Node<T> p = this;
            while (p != null && p.GetNext() != null)
            {
                p = p.GetNext();
            }
            return p;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }

        public int GetLength()
        {
            int length = 0;
            Node<T> p1 = this;
            while (p1 != null)
            {
                length++;
                p1 = p1.GetNext();
            }
            return length;
        }
    }
}
