namespace SageModeBankOOP
{
    class Bank
    {
        private int _TotalAccountsRegistered { get; set; } = 0;
        private string _name = "Bank";
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value + " Bank";
            }
        }


        private Account[] Accounts { get; set; }

        public Bank()
        {
            Accounts = new Account[100];
            _TotalAccountsRegistered = 0;
        }

        public void Register(string username, string password)
        {
            Accounts[_TotalAccountsRegistered] = new Account
            {
                Id = _TotalAccountsRegistered,
                Username = username,
                Password = password,
            };
            _TotalAccountsRegistered++;
        }

        public Account Login(string username, string password)
        {
            foreach (Account account in Accounts)
            {
                if (account != null && account.Username == username && account.Password == password)
                    return account;
            }
            return null;

        }

        public bool IsAccountExist(string username)
        {
            foreach (Account account in Accounts)
            {
                if (account != null && account.Username == username)
                    return true;
            }
            return false;
        }

        public bool Transfer(Account srcAccount, int targetID, decimal amount)
        {
            Account gotoAccount = Accounts[targetID];
            if (gotoAccount != null)
            {
                if (srcAccount.Balance >= amount)
                {
                    srcAccount.Balance -= amount;
                    gotoAccount.Balance += amount;
                    srcAccount.AddTransaction("TRO", amount, gotoAccount);
                    gotoAccount.AddTransaction("TRI", amount, srcAccount);
                    return true;
                }
            }
            return false;
        }
    }
}