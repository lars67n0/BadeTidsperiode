using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FærdighedsPrøve_2._00
{
    public class Kreds
    {

        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int AntalDeltager { get; set; }

        public Kreds(int id, string navn, string adresse, int antaldeltager)
        {
            this.Id = id;
            this.Navn = navn;
            this.Adresse = adresse;
            this.AntalDeltager = antaldeltager;
        }

        public Kreds()
        {
        }

        public override string ToString()
        {
            return " Kreds ID = " + this.Id + ". Kreds Navn :" + this.Navn + " Deres Adresse : " + this.Adresse + " Antal Deltagere : " + this.AntalDeltager;
        }
    }
}
