using EjemploCleanArchitecture.Interfaces;
using EjemploCleanArchitecture.Models;

namespace EjemploCleanArchitecture.Services
{
    public class SaludoService : ISaludo //Herencia
    {
        //public async Task<string> Saludos(string nombre)    

        public async Task<List<Persona>> GetPersonas(string id)
        {
            var resp = new List<Persona>();
            try
            {
                //resp = $"Hola {nombre}, como va tu dia";
                var qry = LLenarPersonasEnt();
                if (id.Equals("0"))
                {
                    resp = qry;
                }
                else
                {
                    resp = qry.Where(q => q.id.Equals(id)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return resp;
        }
        public async Task<Respuesta> InsertPersona(Persona persona)
        {
            var resp = new Respuesta();
            try
            {
                var qry = LLenarPersonasEnt();
                persona.id = (int.Parse(qry.Select(x => x.id).OrderDescending().FirstOrDefault()) + 1).ToString();

                qry.Add(persona);

                resp.cod = "000";
                resp.data = persona;
                resp.message = "Se ingreso exitosamente!!";
            }
            catch (Exception)
            {

                throw;
            }
            return resp;
        }
        public async Task<Respuesta> UpdatePersona(Persona persona, string id)
        {
            var resp = new Respuesta();
            try
            {
                var qry = LLenarPersonasEnt();
                var per = qry.FirstOrDefault(q => q.id.Equals(id));

                if (per == null)
                {
                    resp.cod = "201";
                    resp.data = null;
                    resp.message = "No se encontro la persona!!";
                }
                else {

                    per.nombre = persona.nombre;
                    per.apellido = persona.apellido;
                    per.edad = persona.edad;
                    per.telefono = persona.telefono;
                    per.direccion = persona.direccion;
                    per.emai = persona.emai;

                    resp.cod = "000";
                    resp.data = qry;
                    resp.message = "Se ingreso exitosamente!!";

                }
                                
            }
            catch (Exception)
            {

                throw;
            }
            return resp;
        }
        public List<Persona> LLenarPersonasEnt()
        {
            var resp = new Persona();
            var lst = new List<Persona>();

            try
            {
                lst = new List<Persona> {
                    new Persona{
                        id = "1",
                        nombre="Derek",
                        apellido="Mejia",
                        edad="34",
                        telefono="0924953458",
                        direccion="Norte",
                        emai="degumeji@gmail.com"
                    },
                    new Persona{
                        id = "2",
                        nombre="Derek2",
                        apellido="Mejia2",
                        edad="34",
                        telefono="0924953458",
                        direccion="Norte",
                        emai="degumeji@gmail.com"
                    },
                    new Persona{
                        id = "3",
                        nombre="Derek3",
                        apellido="Mejia3",
                        edad="34",
                        telefono="0924953458",
                        direccion="Norte",
                        emai="degumeji@gmail.com"
                    }
                };
            }
            catch (Exception ex)
            {

                throw;
            }
            return lst;
        }
    }
}
