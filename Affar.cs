using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    public class Affar
    {
        public Student Kopare { get; private set; }
        public Annons Annons { get; private set; }
        public DateTime Reservationsdatum { get; private set; }
        public AffarsStatus Status { get; private set; }

        public Affar(Student kopare, Annons annons, DateTime datum)
        {
            Kopare = kopare;
            Annons = annons;
            Reservationsdatum = datum;
            Status = AffarsStatus.Reserverad;
        }
    }
}
