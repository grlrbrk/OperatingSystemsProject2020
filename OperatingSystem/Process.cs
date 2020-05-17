using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class Process
    {
        public int pid; // Process ID 
        public int size; // Size(KB)
        public int it; // Incoming Time
        public int et; // Execution Time
        public int[] i_o; //I-O Times


        public Process(int pid,int size, int et, int it,int[] i_o)
        {
            this.pid = pid;
            this.size = size;
            this.et = et;
            this.it = it;
            this.i_o = i_o;
        }

    }
}
