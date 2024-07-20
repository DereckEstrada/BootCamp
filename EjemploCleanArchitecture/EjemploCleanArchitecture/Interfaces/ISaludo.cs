using EjemploCleanArchitecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploCleanArchitecture.Interfaces
{
    public interface ISaludo
    {
        Task<List<Persona>> GetPersonas(string id);
        Task<Respuesta> InsertPersona(Persona persona);
        Task<Respuesta> UpdatePersona(Persona persona, string id);

    }
}
