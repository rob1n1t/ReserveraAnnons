using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveraAnnons
{
    public class Kurs
    {
        public string Kurskod { get; private set;  }
        public string Namn { get; private set; }

        public Kurs(string kurskod, string namn)
        {
            Kurskod = kurskod;
            Namn = namn;
        }
    }
}
