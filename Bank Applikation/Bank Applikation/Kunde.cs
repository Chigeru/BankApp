using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Applikation
{
    class Kunde
    {
        public String name { get; set; }
        String address { get; set; }
        static int startKundeNr = 1000;
        public int kundeNr = startKundeNr;
        public List<Konto> kontoliste;

        public Kunde(string name, string address)
        {
            this.name = name;
            this.address = address;
            this.kundeNr = startKundeNr;
            startKundeNr++;
            kontoliste = new List<Konto>();
        }

        // Tilføjer kontoen til listen over kontoer og derefter tilføjer kunden til kontoen
        public void AddKonto(Konto konto)
        {
            kontoliste.Add(konto);
            konto.ejere.Add(this);
        }

        // bliver ikke brugt, men vil kunne blive brugt i fremtidig udvikling
        public String RemoveKonto(Konto konto)
        {
            if (kontoliste.Count == 1 && konto.belob == 0)
            {
                konto.ejere.Remove(this);
                kontoliste.Remove(konto);
                return $"Kontoen blev fjernet fra {this.name}";
            }
            else if (kontoliste.Count == 1 && konto.belob != 0)
            {
                return $"Kontoen er ikke tom og blev derfor ikke fjernet fra {this.name}";
            }
            else
            {
                return $"kontoen blev fjernet fra {this.name}";
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
