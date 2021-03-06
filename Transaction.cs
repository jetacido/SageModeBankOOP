using System;

namespace SageModeBankOOP
{
    class Transaction
    {
        public string Type { get; set; }
        public DateTime Date { get; set; } = System.DateTime.Now;
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public Account Receiver { get; set; }
        public int Id { get; set; }
    }
}