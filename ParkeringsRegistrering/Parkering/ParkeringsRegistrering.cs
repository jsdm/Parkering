namespace ParkeringsRegistrering.Parkering
{
    using System.Collections.Generic;
    using System.Linq;

    public class ParkeringsRegistrering
    {
        public string RegistreringsNummer { get; set; }
        public DateTime ParkeringStart { get; set; }
        public DateTime? ParkeringEnd { get; set; }
        public int LotArea { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }

        public ParkeringsRegistrering(string registreringsNummer)
        {
            RegistreringsNummer = registreringsNummer;
        }
    }
}
