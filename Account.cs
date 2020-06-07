using System;
namespace SageModeBankOOP
{
    class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        private int _TransCount { get; set; } = 0;
        public Transaction[] Transactions { get; set; }


        public Account()
        {
            Transactions = new Transaction[1000];
            Balance = 0;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            AddTransaction("WTH", amount, this);

        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            AddTransaction("DPT", amount, this);
        }

        public void Transfer(Account receiverAcc)
        {

        }

        public void AddTransaction(string transaction, decimal amount, Account target = null)
        {
            Transactions[_TransCount] = new Transaction
            {
                Id = _TransCount,
                Type = transaction,
                Amount = amount,
                Target = target,
                Balance = Balance,
            };
            _TransCount++;
        }
        public Transaction[] GetTransactions()
        {
            Transaction[] result = new Transaction[_TransCount];

            for (int x = 0; x < _TransCount; x++)
            {
                result[x] = Transactions[x];
            }
            return result;
        }
    }
}