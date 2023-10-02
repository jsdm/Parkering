namespace ParkeringsRegistrering.Parkering
{
    public interface IParkeringsRegistreringStore
    {
        ParkeringsRegistrering Get(string registreringsNummer);
        void Save(ParkeringsRegistrering parkeringsRegistrering);
        void Remove(string registreringsNummer);
    }
    public class ParkeringsRegistreringStore : IParkeringsRegistreringStore
    {
        private static readonly Dictionary<string, ParkeringsRegistrering> Database =
            new Dictionary<string, ParkeringsRegistrering>();
        public ParkeringsRegistrering Get(string registreringsNummer) =>
            Database.ContainsKey(registreringsNummer) ? Database[registreringsNummer] : new ParkeringsRegistrering(registreringsNummer);
        public void Save(ParkeringsRegistrering parkeringsRegistrering) =>
            Database[parkeringsRegistrering.RegistreringsNummer] = parkeringsRegistrering;
        public void Remove(string registreringsNummer)
        {
            if(Database.ContainsKey(registreringsNummer))
            {
                Database.Remove(registreringsNummer);
            }
        }
    }
}
