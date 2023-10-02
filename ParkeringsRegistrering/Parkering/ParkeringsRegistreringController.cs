using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkeringsRegistrering.Parkering
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkeringsRegistreringController : ControllerBase
    {
        private readonly IParkeringsRegistreringStore parkeringsRegistreringStore;
        public ParkeringsRegistreringController(IParkeringsRegistreringStore parkeringsRegistreringStore)
        {
            this.parkeringsRegistreringStore = parkeringsRegistreringStore;
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
            return opretParkering;
        }

        [HttpDelete("{registreringsNummer}")]
        public void SletParkering(string registreringsNummer)
        {
            parkeringsRegistreringStore.Remove(registreringsNummer);
        }
    }
}
