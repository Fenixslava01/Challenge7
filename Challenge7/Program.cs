using System;
using System.IO;
using System.Text;
using Challenge7;

namespace Challenge7
{
    class Program
    {
        static void InsertData(string text)
        {
            using (FileStream fstream = new FileStream("tabel.txt", FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
        static void Main(string[] args)
        {
            if (!File.Exists("tabel.txt"))
            {
                string text = "1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва\n" +
                    "2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск\n";
                InsertData(text);
            }
            Repository repo = new Repository();
            Worker[] workers = repo.GetAllWorkers();
            foreach (var item in workers)
            {
                Console.WriteLine(item.Id + " " + item.FIO);
            }
        }
    }
}
