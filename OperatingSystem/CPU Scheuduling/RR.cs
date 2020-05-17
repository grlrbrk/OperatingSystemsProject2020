using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class RR
    {
        public void findavgTime(Process[] proc, int n, int i_o_waittime)
        {
            int res = 0;
            int resc = 0;

            String seq = "";

            int[] res_bt = new int[proc.Length];
            int[] res_art = new int[proc.Length];

            for (int i = 0; i < res_bt.Length; i++)
            {
                res_bt[i] = proc[i].et;
                res_art[i] = proc[i].it;
            }

            int t = 0;

            int[] w = new int[proc.Length];

            int[] comp = new int[proc.Length];

            while (true)
            {
                Boolean flag = true;
                for (int i = 0; i < proc.Length; i++)
                {
                    for (int x = 0; x < proc[i].i_o.Length; x++)
                    {
                        if (t == proc[i].i_o[x])
                        {
                            t = t + i_o_waittime;
                            continue;
                        }
                    }
                    if (res_art[i] <= t)
                    {
                        if (res_art[i] <= n)
                        {
                            if (res_bt[i] > 0)
                            {
                                flag = false;
                                if (res_bt[i] > n)
                                {
                                    t = t + n;
                                    res_bt[i] = res_bt[i] - n;
                                    res_art[i] = res_art[i] + n;
                                    seq += "->" + "p" + proc[i].pid;
                                }
                                else
                                {
                                    t = t + res_bt[i];

                                    comp[i] = t - proc[i].it;

                                    w[i] = t - proc[i].et - proc[i].it;
                                    res_bt[i] = 0;

                                    seq += "->" + "p" + proc[i].pid;
                                }
                            }
                        }
                        else if (res_art[i] > n)
                        {

                            for (int j = 0; j < proc.Length; j++)
                            {

                                if (res_art[j] < res_art[i])
                                {
                                    if (res_bt[j] > 0)
                                    {
                                        flag = false;
                                        if (res_bt[j] > n)
                                        {
                                            t = t + n;
                                            res_bt[j] = res_bt[j] - n;
                                            res_art[j] = res_art[j] + n;
                                            seq += "->" + "p" + proc[j].pid;
                                        }
                                        else
                                        {
                                            t = t + res_bt[j];
                                            comp[j] = t - proc[j].it;
                                            w[j] = t - proc[j].et - proc[j].it;
                                            res_bt[j] = 0;
                                            seq += "->" + "p" + proc[j].pid;
                                        }
                                    }
                                }
                            }

                            if (res_bt[i] > 0)
                            {
                                flag = false;

                                if (res_bt[i] > n)
                                {
                                    t = t + n;
                                    res_bt[i] = res_bt[i] - n;
                                    res_art[i] = res_art[i] + n;
                                    seq += "->" + "p" + proc[i].pid;
                                }
                                else
                                {
                                    t = t + res_bt[i];
                                    comp[i] = t - proc[i].it;
                                    w[i] = t - proc[i].et - proc[i].it;
                                    res_bt[i] = 0;
                                    seq += "->" + "p" + proc[i].pid;
                                }
                            }
                        }
                    }

                    else if (res_art[i] > t)
                    {
                        t++;
                        i--;
                    }
                }

                if (flag)
                {
                    break;
                }
            }
            Console.WriteLine("Round Robin:");
            Console.WriteLine(" Processes " 
                + " Compilation Time "
                + " Waiting Time ");
            for (int i = 0; i < proc.Length; i++)
            {
                Console.WriteLine(" " + proc[i].pid + "\t\t" +
                                     comp[i] + "\t\t" + w[i]);

                res = res + w[i];
                resc = resc + comp[i];
            }

            Console.WriteLine("Average waiting time is " +
                                   (float)res / proc.Length);
            Console.WriteLine("Average compilation time is " +
                                      (float)resc / proc.Length);
            Console.WriteLine("Sequence is like that " + seq);
        }
    }
}
