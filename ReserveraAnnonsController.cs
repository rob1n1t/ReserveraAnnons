using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    public class ReserveraAnnonsController
    {
        private BookSwapRegister Register { get; }
        private Student InloggadStudent { get; }

        public ReserveraAnnonsController(BookSwapRegister register, Student inloggadStudent)
        {
            Register = register;
            InloggadStudent = inloggadStudent;
        }

        public List<Annons> ListaTillgangligaAnnonser()
        {
            return Register.HamtaTillgangligaAnnonser(InloggadStudent);
        }

        public Affar ReserveraAnnons(Annons validAnnons)
        {
            Affar nyAffar = new Affar(InloggadStudent, validAnnons, DateTime.Now);

            validAnnons.MarkeraSomReserverad();
            Register.LaggTillAffar(nyAffar);

            return nyAffar;
        }
    }
}
