using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    //Shortest Job First
    public class SJF
    {
        public void findWaitingTime(Process[] proc, int n,
                                        int[] wt,int i_o_waittime)
        {
            int[] rt = new int[n];

            for (int i = 0; i < n; i++)
                rt[i] = proc[i].et;

            int complete = 0, t = 0, minm = int.MaxValue;
            int shortest = 0, finish_time;
            bool check = false;

            while (complete != n)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((proc[j].it <= t) &&
                    (rt[j] < minm) && rt[j] > 0)
                    {
                        minm = rt[j];
                        shortest = j;
                        check = true;
                    }
                    for (int x = 0; x < proc[j].i_o.Length; x++)
                    {
                        if (t == proc[j].i_o[x])
                        {
                            t = t + i_o_waittime;
                            continue;         
                        }
                    }
                }

                if (check == false)
                {
                    t++;
                    continue;
                }

                rt[shortest]--;

                minm = rt[shortest];
                if (minm == 0)
                    minm = int.MaxValue;


                if (rt[shortest] == 0)
                {

                    complete++;
                    check = false;

                    finish_time = t + 1;

                    wt[shortest] = finish_time -
                                proc[shortest].et -
                                proc[shortest].it;

                    if (wt[shortest] < 0)
                        wt[shortest] = 0;
                }
                t++;
            }
        }

        public void findTurnAroundTime(Process[] proc, int n,
                                int[] wt, int[] tat)
        {

            for (int i = 0; i < n; i++)
                tat[i] = proc[i].et + wt[i];
        }


        public void findavgTime(Process[] proc, int n, int i_o_waittime)
        {
            int[] wt = new int[n]; int[] tat = new int[n];
            int total_wt = 0, total_tat = 0;


            findWaitingTime(proc, n, wt,i_o_waittime);


            findTurnAroundTime(proc, n, wt, tat);

            Console.WriteLine("SJF:");
            Console.WriteLine("Processes " +
                            " Burst time " +
                            " Waiting time " +
                            " Turn around time");

            for (int i = 0; i < n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];
                Console.WriteLine(" " + proc[i].pid + "\t\t"
                                + proc[i].et + "\t\t " + wt[i]
                                + "\t\t" + tat[i]);
            }

            Console.WriteLine("Average waiting time = " +
                            (float)total_wt / (float)n);
            Console.WriteLine("Average turn around time = " +
                            (float)total_tat / (float)n);
        }
    }
}
