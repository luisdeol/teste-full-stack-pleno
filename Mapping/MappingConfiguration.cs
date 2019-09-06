using AutoMapper;
using TesteFullStackPleno.Core.Entities;
using TesteFullStackPleno.Models;

namespace TesteFullStackPleno.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<ComportamentoRequest, Comportamento>();
        }
    }
}
