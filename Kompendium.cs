using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    public class Kompendium : Annons
    {
        public int AntalSidor { get; private set; }
        public int UtgivningsAr { get; private set; }

        public Kompendium(
            Student saljare, 
            Kurs kurs, 
            string titel, 
            decimal pris, 
            AnnonsSkick skick, 
            DateTime publiceringsdatum, 
            int antalSidor, 
            int utgivningsAr)
            : base(saljare, kurs, titel, pris, skick, publiceringsdatum)
        {
            AntalSidor = antalSidor;
            UtgivningsAr = utgivningsAr;
        }
    }
}
