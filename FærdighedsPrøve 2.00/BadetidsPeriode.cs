using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FærdighedsPrøve_2._00
{
    public class BadetidsPeriode
    {
        public string Type { get; set; }
        public DayOfWeek Ugedag { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }

        public BadetidsPeriode(string type, DayOfWeek ugedag, DateTime start, DateTime slut)
        {
            this.Type = type;
            this.Ugedag = ugedag;
            this.StartTidspunkt = start;
            this.SlutTidspunkt = slut;
        }

        public override string ToString()
        {
            return
                $"Bade Aktivitet : {Type}, Hvilken Ugedag Afholdes Det? Om {Ugedag}. Fra {StartTidspunkt} Til {SlutTidspunkt}";

        }

        public static Dictionary<int, Kreds> KredsDictionary
        {
            get { return KredsDictionary; }
        }

        private static Dictionary<int, Kreds> kredsDictionary = new Dictionary<int, Kreds>()
        {
            {1, new Kreds(1, "Gruppe1", "Sted1", 5)},
            {2, new Kreds(2, "Gruppe2", "Sted2", 6)},
            {3, new Kreds(3, "Gruppe3", "Sted3", 7)},
        };

        public static void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Alle Aktiviteter");
            foreach (var kreds in kredsDictionary)
            {
                Console.WriteLine();
                Console.WriteLine(kreds);
                Console.WriteLine("______________________________");
            }
        }

        public static void Create(Kreds kreds)
        {
            kredsDictionary.Add(kreds.Id, kreds);
        }

        public static void Update(int index, Kreds kreds)
        {
            kredsDictionary[index] = kreds;
        }

        public static void Delete(int num)
        {
            kredsDictionary.Remove(num);
        }

    }




}
