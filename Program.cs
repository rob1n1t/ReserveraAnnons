namespace ReserveraAnnons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student kopare = new Student("Adam","Andersson","adam00@gmail.com","070-1234567");
            BookSwapRegister register = SkapaStartregister(kopare);
            ReserveraAnnonsController controller = new ReserveraAnnonsController(register, kopare);

            bool running = true;

            List<Annons> tillgangligaAnnonser = new List<Annons>();

            while (running)
            {
                VisaMeny();

                string menyInput = Console.ReadLine() ?? "";

                if (!int.TryParse(menyInput, out int menyval))
                {
                    Console.WriteLine("Ditt val måste vara ett heltal.");
                    continue;
                }

                switch (menyval)
                {
                    case 1:
                        Console.WriteLine("Du valde: Lista tillgängliga annonser.");
                        tillgangligaAnnonser = controller.ListaTillgangligaAnnonser();
                        VisaAnnonser(tillgangligaAnnonser);
                        break;

                    case 2:
                        Console.WriteLine("Du valde: Reservera annons.");
                        Console.Write("Ange numret på annonsen du vill reservera: ");
                        string annonsInput = Console.ReadLine() ?? "";

                        if (!int.TryParse(annonsInput, out int annonsnummer))
                        {
                            Console.WriteLine("Du måste ange ett heltal.");
                            break;
                        }

                        if (annonsnummer < 1 || annonsnummer > tillgangligaAnnonser.Count)
                        {
                            Console.WriteLine("Det numret motsvarar ingen annons.");
                            break;
                        }

                        Annons valdAnnons = tillgangligaAnnonser[annonsnummer - 1];
                        Affar affar = controller.ReserveraAnnons(valdAnnons);
                        VisaReservationsbekraftelse(affar);
                        break;

                    case 0:
                        running = false;
                        Console.WriteLine("Du valde att avsluta programmet.");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
            }
        }

        private static BookSwapRegister SkapaStartregister(Student kopare)
        {
            BookSwapRegister register = new BookSwapRegister();

            Student saljare1 = new Student("Anna","Andersson","annaa99@gmail.com","070-1122334");

            Student saljare2 = new Student("Bertil","Berg","berraberg@gmail.com","070-2222222");

            Student saljare3 = new Student("Cecilia","Carlsson","ceca123@gmail.com","070-3333333");

            Kurs kurs1 = new Kurs("C1OB1B","Objektorienterad systemutveckling 1");

            Kurs kurs2 = new Kurs("NGC011","Grundläggande programmering med C#");

            Kursbok kursbok1 = new Kursbok(
                saljare1,
                kurs1,
                "Object-oriented analysis and design with applications",
                545m,
                AnnonsSkick.BraSkick,
                DateTime.Today,
                "9780201895513",
                "Grady Booch",
                3);

            Kursbok kursbok2 = new Kursbok(
                saljare2,
                kurs1,
                "Pro C# 10 with .NET 6",
                586m,
                AnnonsSkick.Nyskick,
                DateTime.Today,
                "9781484278680",
                "Andrew Troelsen",
                11);

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
                "Skarp programmering med C#",
                609m,
                AnnonsSkick.BraSkick,
                DateTime.Today,
                "9789144052601",
                "Jan Skansholm",
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
            Console.WriteLine();
            Console.WriteLine("Tillgängliga annonser:");

            for (int i = 0; i < annonser.Count; i++)
            {
                Annons annons = annonser[i];

                Console.WriteLine($"{i + 1}. {annons.Titel} | " +
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
            Console.WriteLine($"Köpare: {affar.Kopare.Fornamn} {affar.Kopare.Efternamn}");
            Console.WriteLine($"Säljare: {affar.Annons.Saljare.Fornamn} " + $"{affar.Annons.Saljare.Efternamn}");
            Console.WriteLine($"Reservationsdatum: {affar.Reservationsdatum}");
            Console.WriteLine($"Affärsstatus: {affar.Status}");
            Console.WriteLine($"Annonsstatus: {affar.Annons.Status}");
        }
    }
}