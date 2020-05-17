using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Memory_Allocation
{
    public class FF
    {
        public void firstFit(int[] blockSize, int m,
                  Process[] proc, int n)
        {
            int[] processSize = new int[proc.Length];

            for (int i = 0; i < proc.Length; i++)
            {
                processSize[i] = proc[i].size;
            }

            int[] allocation = new int[n];

            for (int i = 0; i < allocation.Length; i++)
                allocation[i] = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (blockSize[j] >= processSize[i])
                    {
                        allocation[i] = j;

                        blockSize[j] -= processSize[i];

                        break;
                    }
                }
            }

            Console.WriteLine("\nProcess No.\tProcess Size\tBlock no.");
            Console.Write(" " + "OS" + "\t\t"
                + 350 + "\t\t"
                + 1 + "\n");

            for (int i = 0; i < n; i++)
            {
                Console.Write(" " + (i + 1) + "\t\t" +
                              processSize[i] + "\t\t");
                if (allocation[i] != -1)
                    Console.Write(allocation[i] + 1 + 1);
                else
                    Console.Write("Not Allocated");
                Console.WriteLine();
            }
        }
    }
}
