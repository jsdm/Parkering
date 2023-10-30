using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkeringsRegistrering.Event;

namespace ParkeringsRegistrering.Parkering
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkeringsRegistreringController : ControllerBase
    {
        private readonly IParkeringsRegistreringStore parkeringsRegistreringStore;
        private readonly IEventstore eventStore;
        public ParkeringsRegistreringController(
            IParkeringsRegistreringStore parkeringsRegistreringStore,
            IEventstore eventStore
            )
        {
            this.parkeringsRegistreringStore = parkeringsRegistreringStore;
            this.eventStore = eventStore;
        }

        [HttpGet("{registreringsNummer}")]
        public ParkeringsRegistrering Get(string registreringsNummer)
            => parkeringsRegistreringStore.Get(registreringsNummer);

        [HttpPost("registrerParkering")]
        public ParkeringsRegistrering Post(
            string registreringsNummer,
            int lot,
            string? email,
            int? phonenumber
            )
        {
            ParkeringsRegistrering opretParkering = new(registreringsNummer)
            {
                LotArea = lot,
                ParkeringStart = DateTime.Now,
                Email = email,
                Phone = phonenumber
            };
            parkeringsRegistreringStore.Save(opretParkering);
            eventStore.Raise("NewParkingStarted", opretParkering);
            return opretParkering;
        }

        [HttpDelete("{registreringsNummer}")]
        public void SletParkering(string registreringsNummer)
        {
            parkeringsRegistreringStore.Remove(registreringsNummer);
        }
    }
}
