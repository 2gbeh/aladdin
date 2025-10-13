using AutoMapper;
using server.Domain.Common;
using server.Domain.Entities;
using server.Shared.Dtos;

namespace server.Application.Transactions.Mappings;

public class TransactionMappingProfile : Profile
{
    public TransactionMappingProfile()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.Value));
        
        CreateMap<LookupEntity, LookupEntityDto>();
    }
}
