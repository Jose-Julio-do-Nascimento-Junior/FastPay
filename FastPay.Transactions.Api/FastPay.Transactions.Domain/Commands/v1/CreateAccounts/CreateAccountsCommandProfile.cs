using AutoMapper;
using FastPay.Transactions.Domain.Dtos.v1;
using FastPay.Transactions.Domain.Entities.v1;
using FastPay.Transactions.Domain.Resources.v1;

namespace FastPay.Transactions.Domain.Commands.v1.CreateAccounts;

public sealed class CreateAccountsCommandProfile : Profile
{
    public CreateAccountsCommandProfile()
    {
        CreateMap<CreateAccountsCommand, Account>()
             .ForMember(dest => dest.ClientId, opt => opt.MapFrom(
                 src => string.IsNullOrWhiteSpace(src.ClientId)
                 ? default : src.ClientId.All(char.IsDigit)
                 ? string.Format(Constants.ClientIdFormat,
                     int.Parse(src.ClientId)) : src.ClientId));

        //$"CLI-{int.Parse(src.ClientId):D3}"
        CreateMap<Account, AccountResponseDto>();
    }
}