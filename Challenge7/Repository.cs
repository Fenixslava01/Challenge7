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
        public Worker[] GetAllWorkers()
        {
            List<Worker> WorkersList = new List<Worker>();
            foreach (string line in System.IO.File.ReadLines("tabel.txt"))
            {
                string[] lines = line.Split("#");
                if (lines[0] != "")
                {
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
            }
            Worker[] Workers = WorkersList.ToArray();
            return Workers;
        }
        public Worker GetWorkerById(int id)
        {
            Worker[] workers = GetAllWorkers();
            foreach (var worker in workers)
            {
                if (worker.Id == id)
                {
                    return worker;
                }
            }
            return new Worker();
        }
        public void DeleteWorker(int id)
        {
            string WorkerNew = "";
            Worker[] workers = GetAllWorkers();
            foreach (Worker worker in workers)
            {
                if (worker.Id != id)
                {
                    WorkerNew += worker.Id + "#" + worker.Added + "#" + worker.FIO + "#" + worker.Age + "#" + worker.Height + "#" + worker.BirthDate + "#" + worker.BirthPlace;
                }
                WorkerNew += "\n";
            }
            FileStream fs = System.IO.File.Create("tabel.txt");
            fs.Close();
            using (FileStream fstream = new FileStream("tabel.txt", FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(WorkerNew);
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
        public void InsertData(string text)
        {
            using (FileStream fstream = new FileStream("tabel.txt", FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
        public void AddWorker(Worker worker)
        {
            int newId = GetIidsFromFile();
            worker.Id = ++newId;
            string WorkerNew = "";
            WorkerNew += worker.Id + "#" + worker.Added + "#" + worker.FIO + "#" + worker.Age + "#" + worker.Height + "#" + worker.BirthDate + "#" + worker.BirthPlace;
            InsertData(WorkerNew);
        }
        private int GetIidsFromFile()
        {
            Worker[] AllWorkers = GetAllWorkers();
            int maxId = 0;
            foreach (Worker unit in AllWorkers) {
                if (unit.Id > maxId) {
                    maxId = unit.Id;
                }
            }
            return maxId;
        }
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] AllWorkers = GetAllWorkers();
            List<Worker> WorkersList = new List<Worker>();
            foreach (Worker worker in AllWorkers)
            {
                if (worker.Added > dateFrom & worker.Added < dateTo)
                {
                    WorkersList.Add(worker);
                }
            }
            Worker[] Workers = WorkersList.ToArray();
            return Workers;
        }
        public void SortWorkersByField(string field)
        {
            Worker[] AllWorkers = GetAllWorkers();
            if (field == "FIO") {
                Console.WriteLine("Сортировка по ФИО: \n");
                foreach (var item in AllWorkers.OrderBy(w => w.FIO)) {
                    Console.WriteLine(item.Id + " " + item.FIO);
                }
            } else if (field == "Id") {
                Console.WriteLine("Сортировка по ID: \n");
                foreach (var item in AllWorkers.OrderBy(w => Convert.ToInt32(w.Id))) { 
                    Console.WriteLine(item.Id + " " + item.FIO);
                }
            }
        }
    }
}
