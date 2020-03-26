using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace footgolf
{
    class Program
    {
        static List<footgolf> footg;
        struct footgolf
        {
            public string nev;
            public string kategoria;
            public string egyesulet;
            public List<int> pontok;
        }
        static void Main(string[] args)
        {
            Beolvas();
            F03();
            F04();

            Console.ReadKey();
        }

        private static void F04()
        {
            int no = footg.FindAll(a => a.kategoria.Contains("Noi")).Count;
            double noiarany = (Convert.ToDouble(no) / footg.Count) * 100;
            Console.WriteLine("4. feladat: A női versenyzők aránya: ", + noiarany);
        }

        private static void F03()
        {
            Console.WriteLine("3. feladat: Versenyzők száma: " + footg.Count());
        }

        private static void Beolvas()
        {
            footg = new List<footgolf>();
            StreamReader sr = new StreamReader(@"fob2016.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');
                footgolf ft = new footgolf();
                ft.nev = line[0];
                ft.kategoria = line[1];
                ft.egyesulet = line[2];
                ft.pontok = new List<int>();
                for (int i = 3; i < line.Length; i++)
                {
                    ft.pontok.Add(Convert.ToInt32(line[i]));
                }
                footg.Add(ft);
            }
            sr.Close();
        }
    }
}