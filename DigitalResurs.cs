using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    public class DigitalResurs : Annons
    {
        public string Filformat { get; private set; }
        public string Leveranssatt { get; private set; }

        public DigitalResurs(Student saljare, Kurs kurs, string titel, decimal pris, AnnonsSkick skick, DateTime publiceringsdatum, string filformat, string leveranssatt)
            : base(saljare, kurs, titel, pris, skick, publiceringsdatum)
        {
            Filformat = filformat;
            Leveranssatt = leveranssatt;
        }
    }
}
