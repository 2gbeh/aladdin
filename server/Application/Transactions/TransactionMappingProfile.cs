using AutoMapper;
using server.Domain.Entities;
using server.Application.Common.Dtos;

namespace server.Application.Transactions;

public class TransactionMappingProfile : Profile
{
    public TransactionMappingProfile()
    {
        CreateMap<Transaction, TransactionDto>();

        CreateMap<Transaction, TransactionEntityDto>();
    }
}
