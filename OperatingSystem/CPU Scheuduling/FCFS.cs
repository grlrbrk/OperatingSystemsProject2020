using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    //First come, first served && First-in-First-Out
    class FCFS
    {
        public void findWaitingTime(Process[] proc, int n,
                                        int[] wt, int i_o_waittime)
        {
            int t;

            int[] service_time = new int[n];
            service_time[0] = 0;
            wt[0] = 0;
            //
            for (int i = 0; i < proc[0].i_o.Length;i++)
            {
                if (proc[0].i_o[i] <= proc[0].et)
                {
                    wt[0] = wt[0] + i_o_waittime;
                }
            }
            for (int i = 1; i < n; i++)
            {
                service_time[i] = service_time[i - 1] + proc[i - 1].et;
                wt[i] = service_time[i] - proc[i].it;                   

                if (wt[i] < 0)
                    wt[i] = 0;
            }
        }

        public void findTurnAroundTime(Process[] proc, int n,
                                int[] wt, int[] tat, int i_o_waittime)
        {
            for (int i = 0; i < n; i++)
                tat[i] = proc[i].et + wt[i];
        }

        public void findavgTime(Process[] proc, int n,int i_o_waittime)
        {
            int[] wt = new int[n]; int[] tat = new int[n];
            int total_wt = 0, total_tat = 0;

            findWaitingTime(proc, n, wt, i_o_waittime);
            findTurnAroundTime(proc, n, wt, tat,i_o_waittime);

            Console.WriteLine("FCFS:");
            Console.Write("Processes " + " Execution Time " + " Incoming Time "
                + " Waiting Time " + " Turn-Around Time "
                + " Completion Time \n");

            for (int i = 0; i < n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];
                int compl_time = tat[i] + proc[i].it;
                Console.WriteLine(i + 1 + "\t\t" + proc[i].et + "\t\t"
                    + proc[i].it + "\t\t" + wt[i] + "\t\t "
                    + tat[i] + "\t\t " + compl_time);
            }

            Console.Write("Average waiting time = "
                + (float)total_wt / (float)n);
            Console.Write("\nAverage turn around time = "
                + (float)total_tat / (float)n +"\n");
        }
    }
}
