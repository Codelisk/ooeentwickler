using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwickleruno.services.Provider.AccountProvider;

public interface IAccountProvider
{
    AccountDto? Account { get; }

    Task<bool> SetAccountAsync();
    void SetAccountFromRegister(AccountDto account);
}
