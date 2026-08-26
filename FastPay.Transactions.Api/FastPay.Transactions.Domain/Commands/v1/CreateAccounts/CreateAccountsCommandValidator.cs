using FastPay.Transactions.Domain.Resources.v1;
using FluentValidation;

namespace FastPay.Transactions.Domain.Commands.v1.CreateAccounts;

public sealed class CreateAccountsCommandValidator : AbstractValidator<CreateAccountsCommand>
{
    public CreateAccountsCommandValidator()
    {
        RuleFor(command => command.ClientId)
           .Matches(Constants.ValidClientIdFormat)
           .When(command => !string.IsNullOrWhiteSpace(command.ClientId))
           .WithMessage(Message.ClientIdFormatInvalid);
    }
}