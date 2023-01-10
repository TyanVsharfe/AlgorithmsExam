using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    public class HashFunc
    {
        private int maxTableSize;

        public HashFunc(int size)
        {
            maxTableSize = size;
        }

        public int GetHashByDiv(int key)
        {
            return Math.Abs(key.GetHashCode() % maxTableSize);
        }

        public int GetHashByMult(int key)
        {
            double goldenRatio = 0.618033;
            return (int)Math.Abs(maxTableSize * (key.GetHashCode() * goldenRatio % 1));
        }

    }
}
