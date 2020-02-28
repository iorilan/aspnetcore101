using System;
using System.Collections.Generic;

namespace StackSample
{
    ////push and pop is basic function of a stack
    class Program
    {
        static void Main()
        {
            var alphabet = new Stack<char>();
            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');

            Console.Write("First iteration: (foreach) ");
            foreach (char item in alphabet)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.Write("Second iteration: (while-pop)");
            while (alphabet.Count > 0)
            {
                Console.Write(alphabet.Pop());
            }
            Console.WriteLine();
        }
    }
}
