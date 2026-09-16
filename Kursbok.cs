using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    public class Kursbok : Annons
    {
        public string ISBN { get; private set; }
        public string Forfattare { get; private set; }
        public int Upplaga { get; private set; }

        public Kursbok(
            Student saljare, 
            Kurs kurs, 
            string titel, 
            decimal pris, 
            AnnonsSkick skick, 
            DateTime publiceringsdatum, 
            string isbn, 
            string forfattare, 
            int upplaga)
            : base(saljare, kurs, titel, pris, skick, publiceringsdatum)
        {
            ISBN = isbn;
            Forfattare = forfattare;
            Upplaga = upplaga;
        }
    }
}
