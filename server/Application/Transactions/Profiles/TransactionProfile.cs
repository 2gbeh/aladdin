using AutoMapper;
using System.Linq;
using server.Domain.Entities.Transaction;
using server.Shared.Dtos;

namespace server.Application.Transactions.Profiles;

public sealed class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("Type", opt => opt.MapFrom(src => src.Type))
            .ForCtorParam("ContactId", opt => opt.MapFrom(src => src.ContactId))
            .ForCtorParam("ContactName", opt => opt.MapFrom(src => src.Contact != null ? src.Contact.Name : null))
            .ForCtorParam("ContactDisplayName", opt => opt.MapFrom(src => src.Contact != null ? src.Contact.DisplayName : null))
            .ForCtorParam("Amount", opt => opt.MapFrom(src => src.Amount.Amount))
            .ForCtorParam("Currency", opt => opt.MapFrom(src => src.Amount.Currency))
            .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
            .ForCtorParam("TransactionCategoryName", opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
            .ForCtorParam("Tags", opt => opt.MapFrom(src => src.Tags))
            .ForCtorParam("Status", opt => opt.MapFrom(src => src.Status))
            .ForCtorParam("PaymentDate", opt => opt.MapFrom(src => src.PaymentDate))
            .ForCtorParam("CreatedAt", opt => opt.MapFrom(src => src.CreatedAt))
            .ForCtorParam("UpdatedAt", opt => opt.MapFrom(src => src.UpdatedAt));
    }
}
