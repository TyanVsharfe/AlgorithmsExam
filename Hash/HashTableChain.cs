using AlgorithmsExam.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    public class HashTableChain
    {
        private readonly int maxTableSize;
        private readonly int maxSize;
        private Dictionary<int, List<HashNode>> nodes = null;
        private HashFunc hashFunc;

        public IReadOnlyCollection<KeyValuePair<int, List<HashNode>>> Nodes => nodes?.ToList()?.AsReadOnly();
        public int MaxLengthChain => nodes.Where(x => x.Value != null).Max(x => x.Value.Count);
        public int MinLengthChain => nodes.Where(x => x.Value != null).Min(x => x.Value.Count);
        public int Count { get; private set; }
        public double FillFactor => (double)(Count / maxTableSize);

        public HashTableChain(int maxTableSize = 1000, int maxSize = 100000)
        {
            this.maxTableSize = maxTableSize;
            nodes = new Dictionary<int, List<HashNode>>(maxTableSize);
            this.maxSize = maxSize;
            Count = 0;
            hashFunc = new HashFunc(maxTableSize);
        }

        public void Insert(int key, string value)
        {
            if (Count > maxSize)
            {
                Console.WriteLine($"Максимальная длинна таблицы составляет {maxTableSize} символов.");
                return;
            }
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Введенное вами значение является null или пусто.");
                return;
            }

            var item = new HashNode(key, value);
            var hash = hashFunc.GetHashByMult(item.Key);
            List<HashNode> hashTableItem = null;

            if (nodes.ContainsKey(hash))
            {
                hashTableItem = nodes[hash];
                var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);
                nodes[hash].Add(item);
            }
            else
            {
                hashTableItem = new List<HashNode> { item };
                nodes.Add(hash, hashTableItem);
            }
            Count++;
        }

        public void Delete(int key)
        {
            var hash = hashFunc.GetHashByMult(key);
            if (!nodes.ContainsKey(hash))
            {
                Console.WriteLine($"Введенный вами ключ \"{key}\" не существует.");
                return;
            }

            var hashTableItem = nodes[hash];
            var item = hashTableItem.SingleOrDefault(i => i.Key == key);

            if (item != null)
            {
                Console.WriteLine($"Элемент \"{item}\" удален.");
                hashTableItem.Remove(item);
            }
            else
            {
                Console.WriteLine($"Под ключем \"{key}\" элемент не сужествует.");
            }
            Count--;
        }

        public string Search(int key)
        {
            var hash = hashFunc.GetHashByMult(key);
            if (!nodes.ContainsKey(hash))
            {
                return $"Введенный вами ключ \"{key}\" не существует.";
            }

            var hashTableItem = nodes[hash];

            if (hashTableItem != null)
            {
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);
                if (item != null)
                {
                    return key + " - " + item.Value;
                }
            }
            return $"Под ключем \"{key}\" элемент не сужествует.";
        }

        public void ShowHashTable(int limit = 10)
        {
            var newNodes = nodes.Take(limit);
            foreach (var item in newNodes)
            {
                Console.WriteLine(item.Key);
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
