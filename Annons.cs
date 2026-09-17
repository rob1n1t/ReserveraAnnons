using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    // man kan inte skapa ett objekt av klassen Annons när den är abstrakt
    public abstract class Annons
    {
        public Student Saljare { get; private set; }
        public Kurs Kurs { get; private set; }
        public string Titel { get; private set; }
        public decimal Pris { get; private set; }
        public AnnonsSkick Skick { get; private set; }
        public DateTime Publiceringsdatum { get; private set; }
        public AnnonsStatus Status { get; private set; }

        protected Annons(
            Student saljare, 
            Kurs kurs, 
            string titel, 
            decimal pris, 
            AnnonsSkick skick, 
            DateTime publiceringsdatum)
        {
            Saljare = saljare;
            Kurs = kurs;
            Titel = titel;
            Pris = pris;
            Skick = skick;
            Publiceringsdatum = publiceringsdatum;
            Status = AnnonsStatus.TillSalu;
        }

        public bool KanReserverasAv(Student kopare)
        {
            return Status == AnnonsStatus.TillSalu && kopare != Saljare;
        }

        public void MarkeraSomReserverad()
        {
            Status = AnnonsStatus.Reserverad;
        }
    }
}
