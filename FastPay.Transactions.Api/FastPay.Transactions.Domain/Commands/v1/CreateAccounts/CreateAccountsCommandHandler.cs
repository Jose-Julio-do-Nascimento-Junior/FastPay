using AutoMapper;
using FastPay.Core.Domain.Handlers;
using FastPay.Core.Domain.Models;
using FastPay.Transactions.Domain.Contracts.v1.Repositories;
using FastPay.Transactions.Domain.Dtos.v1;
using FastPay.Transactions.Domain.Entities.v1;
using FastPay.Transactions.Domain.Resources.v1;
using Microsoft.Extensions.Logging;

namespace FastPay.Transactions.Domain.Commands.v1.CreateAccounts;

public sealed class CreateAccountsCommandHandler : CommandHandler<CreateAccountsCommand>
{
    private const string HandlerName = nameof(CreateAccountsCommandHandler);

    private readonly ILogger<CreateAccountsCommandHandler> _logger;
    private readonly IAccountRepository _accountRepository;
    private readonly IClientSequenceRepository _clientSequenceRepository;
    private readonly IAccountSequenceRepository _accountSequenceRepository;
    private readonly IMapper _mapper;

    public CreateAccountsCommandHandler(
        ILogger<CreateAccountsCommandHandler> logger,
        IAccountRepository accountRepository,
        IClientSequenceRepository clientSequenceRepository,
        IAccountSequenceRepository accountSequenceRepository,
        IMapper mapper)
    {
        _logger = logger;
        _accountRepository = accountRepository;
        _clientSequenceRepository = clientSequenceRepository;
        _accountSequenceRepository = accountSequenceRepository;
        _mapper = mapper;
    }

    public override async Task<Response> Handle(CreateAccountsCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogTemplate.StartHandler, HandlerName);

        var account = _mapper.Map<Account>(command);

        await GenerateSequencesAsync(account, cancellationToken);

        var persistedAccount = await _accountRepository.CreateAccountAsync(account, cancellationToken);

        var response = _mapper.Map<AccountResponseDto>(persistedAccount);

        _logger.LogInformation(LogTemplate.EndHandler, HandlerName, persistedAccount.ClientId);

        return new Response() { Content = response };
    }

    private async Task GenerateSequencesAsync(Account account, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(account.ClientId))
        {
            account.ClientId = await _clientSequenceRepository.GenerateClientIdAsync(cancellationToken);
        }

        account.AccountId = await _accountSequenceRepository.GenerateAccountIdAsync(account.ClientId!, cancellationToken);

        account.SetIdentity(account.ClientId!, account.AccountId!);
    }
}