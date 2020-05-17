using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    //Best Fit Memory Allocation
    public class BF
    {
        public void bestFit(int[] blockSize, int m,
                  Process[] proc, int n)
        {
            int[] processSize = new int[proc.Length];

            for (int i = 0; i < proc.Length; i++)
            {
                processSize[i] = proc[i].size;
            }

            // Stores block id of the block  
            // allocated to a process 
            int[] allocation = new int[n];

            // Initially no block is assigned to 
            // any process 
            for (int i = 0; i < allocation.Length; i++)
                allocation[i] = -1;

            // pick each process and find suitable 
            // blocks according to its size ad 
            // assign to it 
            for (int i = 0; i < n; i++)
            {

                // Find the best fit block for 
                // current process 
                int bestIdx = -1;
                for (int j = 0; j < m; j++)
                {
                    if (blockSize[j] >= processSize[i])
                    {
                        if (bestIdx == -1)
                            bestIdx = j;
                        else if (blockSize[bestIdx]
                                       > blockSize[j])
                            bestIdx = j;
                    }
                }

                // If we could find a block for 
                // current process 
                if (bestIdx != -1)
                {

                    // allocate block j to p[i]  
                    // process 
                    allocation[i] = bestIdx;

                    // Reduce available memory in 
                    // this block. 
                    blockSize[bestIdx] -= processSize[i];
                }
            }

            Console.WriteLine("\nProcess No.\tProcess"
                                + " Size\tBlock no.");

            Console.Write(" " + "OS" + "\t\t"
                            + 350 + "\t\t"
                            + 1 + "\n");

            for (int i = 0; i < n; i++)
            {
                Console.Write(" " + (i + 1) + "\t\t"
                            + processSize[i] + "\t\t");

                if (allocation[i] != -1)
                    Console.Write(allocation[i] + 1 + 1);
                else
                    Console.Write("Not Allocated");

                Console.WriteLine();
            }
        }
    }
}
