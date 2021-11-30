using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_demo.Module.BusinessObjects
{
    public static class DepartmentRecorder
    {
        private static List<int> records = new List<int>();

        private static object locker = new object();


        private static int addCount;
        private static int killCount;

        public static void Add(Department dept)
        {
            lock (locker)
            {
                records.Add(dept.GetHashCode());
                addCount++;
                PrintRecordsCount();
            }
        }

        public static void Kill(Department dept)
        {
            lock (locker)
            {
                int count = records.RemoveAll(x => x == dept.GetHashCode());
                if (count > 0) killCount += count;
                PrintRecordsCount();
            }
        }

        private static void PrintRecordsCount()
        {
            Console.WriteLine($"CurrentAlive={records.Count}   Add={addCount}   Kill={killCount}");
        }
    }
}
