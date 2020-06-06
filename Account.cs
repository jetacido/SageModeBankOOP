namespace SageModeBankOOP
{
    class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal[] Balances { get; set; }
        public decimal amount { get; set; }
        public Transaction[] Transactions { get; set; }
        public Bank bank { get; set; }
        public Account()
        {
            Transactions = new Transaction[1000];
            Balances = new decimal[100];
        }

        public void Withdraw(decimal amount)
        {

        }

        public decimal Deposit(decimal[] Balances)
        {
            Balances[bank._CurrentAccountIndex] += amount;
            return amount;
        }

        public void Transfer(Account receiverAcc)
        {

        }
    }
}
