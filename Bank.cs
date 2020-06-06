namespace SageModeBankOOP
{
    class Bank
    {
        public int _TotalAccountsRegistered { get; set; }
        public int _CurrentAccountIndex { get; set; }
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


        public Account[] Accounts { get; set; }

        public Bank()
        {
            Accounts = new Account[100];
            _TotalAccountsRegistered = 0;
            _CurrentAccountIndex = -1;
        }

        public void Register(string username, string password)
        {
            Accounts[_TotalAccountsRegistered] = new Account
            {
                Id = _TotalAccountsRegistered,
                Username = username,
                Password = password,
                Balances = new decimal[100]
            };
            _TotalAccountsRegistered++;
            _CurrentAccountIndex = -1;
            
        }

        public bool Login(string username, string password)
        {
            return false;
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

        public void Transfer()
        {

        }

        public bool IsLoggedin(string username, string password)
        {

            foreach (Account account in Accounts)
            {
                if (account != null && account.Username == username && account.Password == password)
                {
                    int x = 0;
                    x++;
                    _CurrentAccountIndex = account.Id;
                    return true;
                }

            }

            return false;
        }
    }
}
