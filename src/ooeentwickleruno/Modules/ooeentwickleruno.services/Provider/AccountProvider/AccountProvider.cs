using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.apiclient;

namespace ooeentwickleruno.services.Provider.AccountProvider;

internal class AccountProvider : IAccountProvider
{
    private readonly IAccountRepository _accountRepository;

    public AccountDto? Account { get; private set; }

    public AccountProvider(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void SetAccountFromRegister(AccountDto account)
    {
        Account = account;
    }

    public async Task<bool> SetAccountAsync()
    {
        try
        {
            var accounts = await _accountRepository.GetAll();
            Account = accounts.FirstOrDefault();
            return Account is not null;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
