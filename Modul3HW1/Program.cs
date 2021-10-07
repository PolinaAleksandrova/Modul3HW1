using System;
using System.Collections;
using Modul3HW1.Collection;

namespace Modul3HW1
{
    public class Program
    {
        private static IComparer _comparer;
        public Program(IComparer comparer)
        {
            _comparer = comparer;
        }

        public static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Remove(2);
            list.RemoveAt(4);
            list.Sort(_comparer);
        }
    }
}
