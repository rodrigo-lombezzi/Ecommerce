using AutoMapper;
using Ecommerce.Objetcs.DTOs.Entities;
using Ecommerce.Objetcs.Models;

namespace E_commerce.Objects.Builders.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PedidoDTO, Pedido>().ReverseMap();
    }
}

