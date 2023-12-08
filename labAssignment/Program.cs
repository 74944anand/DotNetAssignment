using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Size of array");
            int count = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[count];
            Console.WriteLine("Enter Values");
            for (int i = 0; i < count; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Array: ");
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

            
            List<int>list = new List<int>();
            for (int i = 0;i < count; i++)
            {
                list.Add(arr[i]);
            }
            Console.WriteLine("List: ");
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            int[] listarray = new int[count];
                list.CopyTo(listarray);

            Console.WriteLine("List to Array: ");
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

        }
    }
}
