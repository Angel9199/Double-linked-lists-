using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_Linkedlist.Logic
{
    public class DoubleList<T>
    {
        private DoubleNode<T>? _First;

        private DoubleNode<T>? _Last;

        public DoubleList()
        {

            _First = null;
            _Last = null;
            Count = 0;
        }

        public int Count { get; set; }

        public bool IsEmpty => Count == 0;

        public override string ToString()
        {
            var output = string.Empty;
            var pointer = _First;
            while (pointer != null)
            {
                output += $"{pointer.Data}\n";
                pointer = pointer.Right;
            }
            return output;
        }

        public void AddSorted(T item)
        {
            var node = new DoubleNode<T>(item);
            if (_First == null)
            {
                _First = _Last = node;
            }
            else
            {
                var current = _First;

                while (current != null && Comparer<T>.Default.Compare(item, current.Data) > 0)
                {
                    current = current.Right;
                }

                if (current == _First)
                {
                    node.Right = _First;
                    _First.Left = node;
                    _First = node;
                }
                else if (current == null)
                {
                    _Last.Right = node;
                    node.Left = _Last;
                    _Last = node;
                }
                else
                {
                    node.Left = current.Left;
                    node.Right = current;
                    current.Left!.Right = node;
                    current.Left = node;
                }
            }

            Count++;
        }

        public string ToInvertedList()
        {
            var output = string.Empty;
            var pointer = _Last;
            while (pointer != null)
            {
                output += $"{pointer.Data}\n";
                pointer = pointer.Left;
            }
            return output;
        }

        public void SortDescending()
        {
            var items = new List<T>();
            var pointer = _First;

                while (pointer != null)
            {
                items.Add(pointer.Data);
                pointer = pointer.Right;
            }

            Clear();

            foreach (var item in items.OrderByDescending(x => x))
            {
                AddSorted(item);
            }

     
            
        }

        public List<T> GetModes()
        {
            var frequency = new Dictionary<T, int>();
            var pointer = _First;
            while (pointer != null)
            {
                if (frequency.ContainsKey(pointer.Data))
                    frequency[pointer.Data]++;
                else
                    frequency[pointer.Data] = 1;

                pointer = pointer.Right;
            }

            var max = frequency.Values.Max();
            return frequency.Where(x => x.Value == max).Select(x => x.Key).ToList();
        }

        public string GetFrequencyGraph()
        {
            var frequency = new Dictionary<T, int>();
            var pointer = _First;
            while (pointer != null)
            {
                if (frequency.ContainsKey(pointer.Data))
                    frequency[pointer.Data]++;
                else
                    frequency[pointer.Data] = 1;

                pointer = pointer.Right;
            }

            var output = string.Empty;
            foreach (var kvp in frequency.OrderBy(x => x.Key))
            {
                output += $"{kvp.Key} {new string('*', kvp.Value)}\n";
            }
            return output;
        }

        public bool Exists(T item)
        {
            var pointer = _First;
            while (pointer != null)
            {
                if (EqualityComparer<T>.Default.Equals(pointer.Data, item))
                    return true;
                pointer = pointer.Right;
            }
            return false;
        }

        public bool RemoveOne(T item)
        {
            var pointer = _First;
            while (pointer != null)
            {
                if (EqualityComparer<T>.Default.Equals(pointer.Data, item))
                {
                    if (pointer.Left != null)
                        pointer.Left.Right = pointer.Right;
                    else
                        _First = pointer.Right;

                    if (pointer.Right != null)
                        pointer.Right.Left = pointer.Left;
                    else
                        _Last = pointer.Left;

                    Count--;
                    return true;
                }
                pointer = pointer.Right;
            }
            return false;
        }
        public int RemoveAll(T item)
        {
            int removed = 0;
            while (RemoveOne(item))
            {
                removed++;
            }
            return removed;
        }
        public void Clear()
        {
            _First = null;
            _Last = null;
            Count = 0;
        }

    }



}

    