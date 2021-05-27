using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Applikation
{
    class Konto
    {
        static int bankkontoIncrementor = 2049;
        public List<Kunde> ejere = new List<Kunde>();
        int kontoNr { get; set; }
        public double belob { get; set; }
        public string navn { get; set; }


        public Konto(Kunde kunde, double belob, string navn)
        {
            AddKunde(kunde);
            this.belob = belob;
            this.navn = navn;
            this.kontoNr = bankkontoIncrementor;
            bankkontoIncrementor++;
        }

        public void AddKunde(Kunde kunde)
        {
            kunde.AddKonto(this);

        }

        public int getKontoNr()
        {
            return kontoNr;
        }

        public override string ToString()
        {
            return $"({kontoNr}) {navn}";
        }
    }
}
