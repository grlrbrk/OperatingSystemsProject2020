using OperatingSystem.Memory_Allocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BF bf = new BF();
            FF ff = new FF();

            SJF sjf = new SJF();
            FCFS fcfs = new FCFS();
            RR rr = new RR();

            Process[] proc =
{
                new Process(1,245,25,0,new int[]{8,17}),
                new Process(2,365,10,13,new int[]{5}),
                new Process(3,155,19,18,new int[]{3,11,16})
            };
            int quantum = 3;
            int i_o = 3;
            int[] setBlockSize()
            {
                int[] blockSize = { 365, 245, 140 };
                return blockSize;
            }

            Console.WriteLine("Processes " + "\t" +
                              " Size " + "\t" +
                              " Incoming Time " + "\t" +
                              " Execution Time" + "\t" +
                              " I/O Request Time List");

            for (int i = 0; i < proc.Length; i++)
            {
                Console.WriteLine(" " + proc[i].pid + "\t\t"
                                + proc[i].size + "\t\t " + proc[i].it
                                + "\t\t" + proc[i].et
                                + "\t\t" + string.Join(",", proc[i].i_o));
            }
            bool isMenu = true;

            while (isMenu)
            {

                Console.WriteLine("***Choose an algorithm***");
                Console.WriteLine("BF (1)");
                Console.WriteLine("FF (2)");
                Console.WriteLine("FCFS (3)");
                Console.WriteLine("RR (4)");
                Console.WriteLine("SJF (5)");
                Console.WriteLine("Exit (e)");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        bf.bestFit(setBlockSize(), setBlockSize().Length, proc, proc.Length);
                        break;

                    case "2":
                        ff.firstFit(setBlockSize(), setBlockSize().Length, proc, proc.Length);
                        break;

                    case "3":
                        fcfs.findavgTime(proc, proc.Length, i_o);
                        break;

                    case "4":
                        rr.findavgTime(proc, quantum, i_o);
                        break;

                    case "5":
                        sjf.findavgTime(proc, proc.Length, i_o);
                        break;

                    case "e":
                    default:
                        isMenu = false;
                        break;
                }
            }
        }
    }
}
