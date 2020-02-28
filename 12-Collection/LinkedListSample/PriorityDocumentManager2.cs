using System;
using System.Collections.Generic;

namespace LinkedListSample
{
    ////dictionary version of linkedList
    public class PriorityDocumentManager2
    {
        private SortedDictionary<int, IList<Document>> _dict = new SortedDictionary<int, IList<Document>>(new DescendingComparer<int>());
        
        public void AddDocument(Document d){
            if(_dict.ContainsKey(d.Priority)){
                _dict[d.Priority].Add(d);
            }else{
                _dict.Add(d.Priority, new List<Document>(){d});
            }
        }

        public void DisplayAllNodes()
        {
            foreach(var k in _dict.Keys){
                foreach(var d in _dict[k]){
                    Console.WriteLine($"Priority {k}, title:{d.Title}");
                }
            }
        }
    }

    class DescendingComparer<T> : IComparer<T> where T : IComparable<T> {
        public int Compare(T x, T y) {
            return y.CompareTo(x);
        }
    }

}