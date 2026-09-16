using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    public class BokswapRegister
    {
        private List<Annons> Annonser { get; }
        private List<Affar> Affarer { get; }

        // Konstruktor
        public BokswapRegister()
        {
            Annonser = new List<Annonser>();
            Affarer = new List<Affarer>();
        }

        // Annons är klassen, nyAnnons är variabelnamnet på objektet
        public void LaggTillAnnons(Annons nyAnnons)
        {
            Annonser.add(annons);
        }

        // Metod ska ge tillbaka en lista med Annons-objekt.
        public List<Annons> HamtaTillgangligaAnnonser(Student kopare)
        {
            List<Annons> tillgangliga = new List<Annons>();

            foreach (Annons aktuellAnnons in Annonser)
            {
                bool arTillSalu = aktuellAnnons.Status == AnnonsStatus.TillSalu;
                bool kanReserveras = aktuellAnnons.KanReserverasAv(kopare);

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
