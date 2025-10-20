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

        public void Add(T item)
        {
            var node = new DoubleNode<T>(item);
            if (IsEmpty)
            {
                _First = node;
                _Last = node;
            }
            else
            {
                node.Left= _Last;
                _Last!.Right = node;
                _Last = node;
            }
            Count++;
        }
    }


}

    