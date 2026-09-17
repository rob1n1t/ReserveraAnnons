using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    public class BookSwapRegister
    {
        private List<Annons> Annonser { get; }
        private List<Affar> Affarer { get; }

        // Konstruktor
        public BookSwapRegister()
        {
            Annonser = new List<Annons>();
            Affarer = new List<Affar>();
        }

        // Annons är klassen, nyAnnons är variabelnamnet på objektet
        // Används innan användningsfallet påbörjas för att lägga till testdata
        public void LaggTillAnnons(Annons nyAnnons)
        {
            Annonser.Add(nyAnnons);
        }

        // Metod ska ge tillbaka en lista med Annons-objekt.
        public List<Annons> HamtaTillgangligaAnnonser(Student kopare)
        {
            List<Annons> tillgangliga = new List<Annons>();

            foreach (Annons aktuellAnnons in Annonser)
            {
                bool arTillSalu = aktuellAnnons.Status == AnnonsStatus.TillSalu; //
                bool kanReserveras = aktuellAnnons.KanReserverasAv(kopare);  // se så köpare och säljare ej är samma person 

                if (arTillSalu && kanReserveras)
                {
                    tillgangliga.Add(aktuellAnnons);
                }
            }

            return tillgangliga;
        }

        public void LaggTillAffar(Affar affar)
        {
            Affarer.Add(affar);
        }

    }
}
