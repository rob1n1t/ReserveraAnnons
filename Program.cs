namespace ReserveraAnnons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student kopare = new Student(
                "Erik",
                "Eriksson",
                "erik@example.com",
                "070-4444444");

            BookSwapRegister register = SkapaStartregister(kopare);

            ReserveraAnnonsController controller =
                new ReserveraAnnonsController(register, kopare);

            bool programmetKor = true;

            while (programmetKor)
            {
                VisaMeny();

                string menyInput = Console.ReadLine() ?? "";

                if (!int.TryParse(menyInput, out int menyval))
                {
                    Console.WriteLine("Menyvalet måste vara ett heltal.");
                    continue;
                }

                switch (menyval)
                {
                    case 1:
                        List<Annons> tillgangligaAnnonser =
                            controller.ListaTillgangligaAnnonser();

                        VisaAnnonser(tillgangligaAnnonser);
                        break;

                    case 2:
                        List<Annons> annonserAttValja =
                            controller.ListaTillgangligaAnnonser();

                        if (annonserAttValja.Count == 0)
                        {
                            Console.WriteLine("Det finns inga tillgängliga annonser.");
                            break;
                        }

                        VisaAnnonser(annonserAttValja);

                        Console.Write("Ange numret på annonsen du vill reservera: ");
                        string annonsInput = Console.ReadLine() ?? "";

                        if (!int.TryParse(annonsInput, out int annonsnummer))
                        {
                            Console.WriteLine("Du måste ange ett heltal.");
                            break;
                        }

                        if (annonsnummer < 1 ||
                            annonsnummer > annonserAttValja.Count)
                        {
                            Console.WriteLine("Det numret motsvarar ingen annons.");
                            break;
                        }

                        Annons valdAnnons =
                            annonserAttValja[annonsnummer - 1];

                        try
                        {
                            Affar affar =
                                controller.ReserveraAnnons(valdAnnons);

                            VisaReservationsbekraftelse(affar);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine(
                                "Annonsen kunde inte reserveras.");
                        }

                        break;

                    case 0:
                        programmetKor = false;
                        Console.WriteLine("Programmet avslutas.");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt menyval.");
                        break;
                }
            }
        }

        private static BookSwapRegister SkapaStartregister(Student kopare)
        {
            BookSwapRegister register = new BookSwapRegister();

            Student saljare1 = new Student(
                "Anna",
                "Andersson",
                "anna@example.com",
                "070-1111111");

            Student saljare2 = new Student(
                "Bertil",
                "Berg",
                "bertil@example.com",
                "070-2222222");

            Student saljare3 = new Student(
                "Cecilia",
                "Carlsson",
                "cecilia@example.com",
                "070-3333333");

            Kurs kurs1 = new Kurs(
                "C1OB1B",
                "Objektorienterad systemutveckling 1");

            Kurs kurs2 = new Kurs(
                "C2PRG",
                "Programmering");

            Kursbok kursbok1 = new Kursbok(
                saljare1,
                kurs1,
                "Objektorienterad analys och design",
                250m,
                AnnonsSkick.BraSkick,
                DateTime.Today,
                "978-1234567890",
                "Anna Författare",
                2);

            Kursbok kursbok2 = new Kursbok(
                saljare2,
                kurs1,
                "C# från grunden",
                300m,
                AnnonsSkick.Nyskick,
                DateTime.Today,
                "978-0987654321",
                "Bertil Författare",
                1);

            Kompendium kompendium = new Kompendium(
                saljare3,
                kurs1,
                "Kurskompendium OOAD",
                100m,
                AnnonsSkick.Slitet,
                DateTime.Today,
                80,
                2026);

            DigitalResurs digitalResurs = new DigitalResurs(
                saljare1,
                kurs2,
                "Programmeringsövningar",
                50m,
                AnnonsSkick.BraSkick,
                DateTime.Today,
                "PDF",
                "Nedladdningslänk");

            // Den inloggade studentens egen annons
            Kursbok koparensAnnons = new Kursbok(
                kopare,
                kurs2,
                "Min gamla kursbok",
                150m,
                AnnonsSkick.BraSkick,
                DateTime.Today,
                "978-1111111111",
                "En annan författare",
                1);

            register.LaggTillAnnons(kursbok1);
            register.LaggTillAnnons(kursbok2);
            register.LaggTillAnnons(kompendium);
            register.LaggTillAnnons(digitalResurs);
            register.LaggTillAnnons(koparensAnnons);

            return register;
        }

        private static void VisaMeny()
        {
            Console.WriteLine();
            Console.WriteLine("BookSwap");
            Console.WriteLine("1. Lista tillgängliga annonser");
            Console.WriteLine("2. Reservera annons");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj ett alternativ: ");
        }

        private static void VisaAnnonser(List<Annons> annonser)
        {
            if (annonser.Count == 0)
            {
                Console.WriteLine("Det finns inga tillgängliga annonser.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Tillgängliga annonser:");

            for (int i = 0; i < annonser.Count; i++)
            {
                Annons annons = annonser[i];

                Console.WriteLine(
                    $"{i + 1}. {annons.Titel} | " +
                    $"Pris: {annons.Pris} kr | " +
                    $"Skick: {annons.Skick} | " +
                    $"Säljare: {annons.Saljare.Fornamn} " +
                    $"{annons.Saljare.Efternamn}");
            }
        }

        private static void VisaReservationsbekraftelse(Affar affar)
        {
            Console.WriteLine();
            Console.WriteLine("Reservation genomförd.");
            Console.WriteLine($"Annons: {affar.Annons.Titel}");
            Console.WriteLine(
                $"Köpare: {affar.Kopare.Fornamn} {affar.Kopare.Efternamn}");
            Console.WriteLine(
                $"Säljare: {affar.Annons.Saljare.Fornamn} " +
                $"{affar.Annons.Saljare.Efternamn}");
            Console.WriteLine(
                $"Reservationsdatum: {affar.Reservationsdatum}");
            Console.WriteLine($"Affärsstatus: {affar.Status}");
            Console.WriteLine($"Annonsstatus: {affar.Annons.Status}");
        }
    }
}