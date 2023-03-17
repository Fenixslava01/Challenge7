using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge7
{
    class Repository
    {
        public Worker[] GetAllWorkers() { 
            List <Worker> WorkersList = new List <Worker>();
            foreach (string line in System.IO.File.ReadLines("tabel.txt"))
            {
                string[] lines = line.Split("#");
                Worker tempWorker = new Worker();
                tempWorker.Id = Convert.ToInt16(lines[0]);
                tempWorker.Added = Convert.ToDateTime(lines[1]);
                tempWorker.FIO = lines[2];
                tempWorker.Age = Convert.ToInt16(lines[3]);
                tempWorker.Height = Convert.ToInt16(lines[4]);
                tempWorker.BirthDate = Convert.ToDateTime(lines[5]);
                tempWorker.BirthPlace = lines[6];
                WorkersList.Add(tempWorker);
            }
            Worker[] Workers = WorkersList.ToArray();
            return Workers;
        }
        private int GetIidsFromFile()
        {
            int count = 0;
            foreach (string line in System.IO.File.ReadLines("tabel.txt"))
            {
                Console.WriteLine(line);
                count++;
            }
            return count;
        }

    }
}
