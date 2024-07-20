using EjemploCleanArchitecture.Interfaces;
using EjemploCleanArchitecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploCleanArchitecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaludoController : Controller
    {
        private readonly ISaludo _saludos;

        public SaludoController(ISaludo saludos)
        {
            this._saludos = saludos;
        }

        [HttpGet]
        [Route("GetPersonas")]
        //public async Task<string> Saludos(string nombre)
        public async Task<List<Persona>> GetPersonas(string id)
        {
            var resp = new List<Persona>();
            try
            {
                resp = await _saludos.GetPersonas(id);
            }
            catch (Exception ex)
            {

                throw;
            }
            return resp;
        }

        [HttpPost]
        [Route("InsertPersona")]
        public async Task<Respuesta> InsertPersona([FromBody] Persona persona)
        {
            var resp = new Respuesta();
            try
            {
                resp = await _saludos.InsertPersona(persona);
            }
            catch (Exception ex)
            {

                throw;
            }
            return resp;
        }

        [HttpPut]
        [Route("UpdatePersona")]
        public async Task<Respuesta> UpdatePersona([FromBody] Persona persona, string id)
        {
            var resp = new Respuesta();
            try
            {
                resp = await _saludos.UpdatePersona(persona, id);
            }
            catch (Exception ex)
            {

                throw;
            }
            return resp;
        }
    }
}
