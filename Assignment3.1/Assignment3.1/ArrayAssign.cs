using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3._1
{
    internal class ArrayAssign
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter No of Batches in YCP");
            int noOfBatches= Convert.ToInt32(Console.ReadLine());

            int[][] arr = new int[noOfBatches];

            

            for (int i = 0; i < noOfBatches; i++)
            {
                Console.Write("Enter no of Students");
                int noOfStudents = Convert.ToInt32(Console.ReadLine());
                arr[i] = new int[noOfStudents];
                    for (int j = 0; j < noOfStudents; j++)
                {
                    Console.WriteLine("Enter Marks of Students");
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }    
            }
            
            for (int i = 0; i < noOfBatches; i++)
            {
                for (int j = 0; j < noOfStudents; j++)
                {
                    Console.WriteLine(arr[i][j]); 
                }
            }
        }

    }
}
