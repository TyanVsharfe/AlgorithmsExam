using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam.List
{
    public class HashNode<T>
    {
        public HashNode<T> Next { get; set; }
        public HashNode<T> Prev { get; set; }
        public T Data { get; private set; }

        public HashNode(T data)
        {
            this.Data = data;
        }
    }
}
