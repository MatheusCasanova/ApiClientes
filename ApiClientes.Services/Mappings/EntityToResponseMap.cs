using ApiClientes.Infra.Data.Entities;
using ApiClientes.Services.Responses;
using AutoMapper;

namespace ApiClientes.Services.Mappings
{
    /// <summary>
    /// Mapeamento de objetos ENTITY para RESPONSE
    /// </summary>
    public class EntityToResponseMap : Profile
    {
        public EntityToResponseMap()
        {
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}
