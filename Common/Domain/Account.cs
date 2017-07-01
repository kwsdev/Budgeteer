using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public abstract class Account
    {
        protected Account(AccountId id, AccountNumber number)
        {
            Id = id;
            Number = number;
        }

        public AccountId Id { get; }

        public AccountNumber Number { get; }
    }
}
