using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP
{
    public class Wallet
    {
        private List<Currency> _currency = new();

        public string Name { get; }

        public IEnumerable<Currency> Money => _currency;
        public IEnumerable<Currency> Coins => CurrencyConverter.GetCoins(_currency);
        public IEnumerable<Currency> Banknotes => CurrencyConverter.GetBanknotes(_currency);


        public Wallet(string name)
        {
            Name = name;
        }

        public void PutMoney(IEnumerable<Currency> money)
        {
            _currency?.AddRange(money);
        }

        public void TakeMoney(IEnumerable<Currency> money)
        {
            _currency = TransactionManager.ExecuteTransaction(
                CurrencyDictionaryConverter.ToDictionary(money),
                CurrencyDictionaryConverter. ToDictionary(_currency));
        }

        public bool HasMoney(IEnumerable<Currency> money)
        {
            return TransactionValidator.ValidateTransaction(_currency, money);
        }

        public double Total()
        {
            return CurrencyCalculator.CalculateTotal(_currency);
        }

        public string GetFullReport()
        {
            return ReportGenerator.GenerateFullReport(this);
        }

        public string GetShortReport()
        {
            return ReportGenerator.GenerateShortReport(this);
        }
    }
}
