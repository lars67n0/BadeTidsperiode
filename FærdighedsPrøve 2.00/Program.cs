using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FærdighedsPrøve_2._00
{
    class Program
    {
        static void Main(string[] args)
        {
            Kreds k1 = new Kreds(1, "Name1", "Adress1", 4);
            Kreds k2 = new Kreds(2, "Name2", "Adress2", 5);
            Kreds k3 = new Kreds (3, "Name3", "Adress3", 6);

            Console.WriteLine();
            Console.Write("Gruppens Navn : ");
            Console.WriteLine($" {k1.Navn}");
            Console.WriteLine($"{k1.ToString()}");
            Console.WriteLine("____________________________________________________________");

            Console.WriteLine();
            Console.Write("Gruppens Navn : ");
            Console.WriteLine($" {k2.Navn}");
            Console.WriteLine($"{k2.ToString()}");
            Console.WriteLine("____________________________________________________________");

            BadetidsPeriode b1 = new BadetidsPeriode("MorgenDukkert", DayOfWeek.Monday, new DateTime().AddHours(6), new DateTime().AddHours(9));
            BadetidsPeriode b2 = new BadetidsPeriode("AftenDukkert", DayOfWeek.Thursday, new DateTime().AddHours(12), new DateTime().AddHours(15));
            BadetidsPeriode b3 = new BadetidsPeriode("Sykron", DayOfWeek.Saturday, new DateTime().AddHours(8), new DateTime().AddHours(10));

            Console.WriteLine();
            
            Console.WriteLine($" {b1.Type}");
            Console.WriteLine();
            Console.WriteLine($"{b2.ToString()}");
            Console.WriteLine("____________________________________________________________");




            BadetidsPeriode.Print();
            Console.WriteLine();
            Console.WriteLine("_____________________________________________________________________");





            static int MainInt(List<string> Data)
            {
                Console.WriteLine("Some Title");
                foreach (var Choice in Data)
                {
                    Console.WriteLine(Choice);
                }

                Console.WriteLine("Please Enter Ur Option#: ");
                string input = Console.ReadKey().KeyChar.ToString();

                try
                {
                    int result = Int32.Parse(input);
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable To Parse ''{input}''");
                }
                return -1;
            }

            bool proceed = true;
            List<string> inp = new List<string>()
            {
                "press 1. To Create",
                "Press 2. To Update",
                "press 3. To Delete",
                "Press 4. To Print",
                "Press 5. To Quit"
            };

            while (proceed)
            {
                int UserChoice = MainInt(inp);
                Console.WriteLine();

                switch (UserChoice)
                {
                    case 1:
                        Console.WriteLine("Skriv Navnet Du ønsker: ");
                        string navn = Console.ReadLine();
                        Console.WriteLine("Skriv Adressen : ");
                        string adresse = Console.ReadLine();

                        Console.WriteLine("Skriv Antal Deltagere : ");
                        Console.WriteLine();
                        int antaldeltager = Convert.ToInt32(Console.ReadLine());


                        Console.WriteLine("Skriv ID På Kredsen : ");
                        int id = 0;
                        string input = Console.ReadLine();
                        try
                        {
                            id = int.Parse(input);
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine($"({input}) Skal Være Et Tal");
                        }

                        if (BadetidsPeriode.KredsDictionary.ContainsKey(id) == false)
                        {
                            Kreds newKreds = new Kreds(id, navn, adresse, antaldeltager);
                            BadetidsPeriode.Create(newKreds);
                        }
                        

                        break;
                    case 2:
                        int index;
                        Console.WriteLine("SKriv ID På Kreds : ");
                        index = Convert.ToInt32(Console.ReadLine());
                        Kreds kreds = new Kreds();
                        Console.WriteLine("Skriv Navnet På Kreds : ");
                        kreds.Navn = Console.ReadLine();
                        Console.WriteLine("Skriv Adressen På Kreds : ");
                        kreds.Adresse = Console.ReadLine();
                        
                        Console.WriteLine("Antal Deltagere : ");
                        kreds.AntalDeltager = Convert.ToInt32(Console.ReadLine());
                        

                        BadetidsPeriode.Update(index, kreds);


                        break;
                    case 3:
                        Console.WriteLine("SKriv ID På Den Kreds Du Ønsker At Slette : ");
                        int Idinput = 0;
                        try
                        {
                            Idinput = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"'{Idinput}' Prøv Igen Skal Være Et Tal : ");
                        }

                        if (BadetidsPeriode.KredsDictionary.ContainsKey(Idinput - 1))
                        {
                            BadetidsPeriode.Delete(Idinput);
                        }

                        break;
                    case 4:
                        BadetidsPeriode.Print();
                        Console.WriteLine();
                        break;
                    case 5:
                        proceed = false;
                        Console.WriteLine();

                        break;
                    default:
                        continue;
                        
                }
            }


        }
    }
}
