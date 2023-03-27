using System;
using System.IO;
using System.Text;
using Challenge7;

namespace Challenge7
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();
            #region Создаем файл, с дефолтными записями если его не существует
            if (!File.Exists("tabel.txt")) {
                string text = "1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва\n" +
                    "2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск\n";
                repo.InsertData(text);
            }
            #endregion
            #region Создание нового работника
            Console.WriteLine("Создание нового сотрудника\n");
            Worker Vasya = new Worker();
            Vasya.FIO = "Васильев Василий Васильевич";
            Vasya.Added = DateTime.Now;
            Vasya.Age = 22;
            Vasya.Height = 183;
            Vasya.BirthDate = Convert.ToDateTime("03.10.1970");
            Vasya.BirthPlace = "город Newerwinter";
            repo.AddWorker(Vasya);
            #endregion
            #region Получаем список всех сотрудников, и выводим их на экран
            Console.WriteLine("Получаем список всех сотрудников, и выводим их на экран\n");
            Worker[] workers = repo.GetAllWorkers();
            repo.PrintWorkers(workers);
            //foreach (var worker in workers) {
            //    Console.WriteLine(worker.Id + " " + worker.FIO);
            //}
            #endregion
            #region Удаляем работника по его id
            Console.WriteLine("Удаляем сотрудника с ID = 2\n");
            repo.DeleteWorker(2);
            #endregion
            #region Получаем работника по Id и выводим его на экран
            Console.WriteLine("Выводим информацию о сотруднике с ID = 1\n");
            Worker WorkerbyID = repo.GetWorkerById(1);
            repo.PrintWorkers(WorkerbyID);
            #endregion
            #region Фильтруем работников в диапазоне дат по дате добавления
            Console.WriteLine("Выводим сотрудников с датой добавления между 01.01.2020 и 01.09.2022\n");
            Worker[] Filtered = repo.GetWorkersBetweenTwoDates(Convert.ToDateTime("01.01.2020"), Convert.ToDateTime("01.09.2022"));
            repo.PrintWorkers(Filtered);
            //foreach (var worker in Filtered) {
            //    Console.WriteLine(worker.Id + " " + worker.FIO);
            //}
            #endregion
            #region Сортируем работников по FIO или по Id
            Console.WriteLine("Сортируем сотрудников по FIO\n");
            repo.SortWorkersByField("FIO");
            Console.WriteLine("Сортируем сотрудников по Id\n");
            repo.SortWorkersByField("Id");
            #endregion
        }
    }
}
