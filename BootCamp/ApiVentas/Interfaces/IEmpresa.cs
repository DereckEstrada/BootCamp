using ApiVentas.Models;

namespace ApiVentas.Interfaces
{
    public interface IEmpresa
    {
        Task<Respuesta> GetEmpresa(int empresaID, string? empresaNombre, string? ruc, int? ciudadID);
        Task<Respuesta> PostEmpresa(Empresa empresa);
        Task<Respuesta> PutEmpresa(Empresa empresa);
        Task<Respuesta> DeleteEmpresa(Empresa empresa);
    }
}