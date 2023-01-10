using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class HashNode
    {
        public int Key { get; private set; }
        public string Value { get; private set; }

        public HashNode(int key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Key = key;
            Value = value;
        }
    }
}
