using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Applikation
{
    class Konto
    {
        static int bankkontoIncrementor = 200049;       // Vil skulle ændres til datatype long, hvis der skal bruges flere end ca 2,1 millioner kontoer
        public List<Kunde> ejere = new List<Kunde>();
        public int kontoNr { get; set; }        // Samme som bankkontoIncrementor
        public double belob { get; set; }
        public string navn { get; set; }

        
        public Konto(Kunde kunde, double belob, string navn = "Hoved konto")
        {
            AddKunde(kunde);
            this.belob = belob;
            this.navn = navn;
            this.kontoNr = bankkontoIncrementor;
            bankkontoIncrementor++;
        }

        // der bliver linket til en metode i kunde classen da listen i Kunde classen holder styr på kontoerne, 
        // og den tilføjer kunderne til listen "ejere" i konto classen
        public void AddKunde(Kunde kunde)
        {
            kunde.AddKonto(this);

        }

        public override string ToString()
        {
            return $"({kontoNr}) {navn}";
        }
    }
}
