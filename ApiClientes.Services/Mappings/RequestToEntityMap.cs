using ApiClientes.Infra.Data.Entities;
using ApiClientes.Services.Requests;
using AutoMapper;

namespace ApiClientes.Services.Mappings
{
    /// <summary>
    /// Mapeamento de objetos REQUEST para ENTITY 
    /// </summary>
    public class RequestToEntityMap : Profile
    {
       public RequestToEntityMap()
        {
            CreateMap<ClientePostRequest, Cliente>();
            CreateMap<ClientePutRequest, Cliente>();
        }
    }
}
