using AutoMapper;
using server.Domain.Entities;
using server.Application.Common.Dtos;
using server.Application.Transactions.Queries.GetAllTransactions;

namespace server.Application.Transactions;

public class TransactionMappingProfile : Profile
{
    public TransactionMappingProfile()
    {
        CreateMap<Transaction, TransactionDto>();

        CreateMap<Transaction, TransactionEntityDto>();

        CreateMap<Transaction, GetAllTransactionsDto>();
    }
}
