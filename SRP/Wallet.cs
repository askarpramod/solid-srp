using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP
{
    public class Wallet
    {
        private const string ReportSeparatorLine = "-----------------------";

        private List<Currency> _currency = new();

        public string Name { get; }

        public IEnumerable<Currency> Money => _currency;
        public IEnumerable<Currency> Coins => _currency.Where(m => (int)m <= 200);
        public IEnumerable<Currency> Banknotes => _currency.Where(m => (int)m > 200);

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
            if (money == null || !money.Any())
            {
                return;
            }

            if (!_currency.Any())
            {
                throw new OutOfMoneyException(money);
            }

            _currency = TakeMoney(ToDictionary(money), ToDictionary(_currency));
        }

        private List<Currency> TakeMoney(Dictionary<Currency, int> money, Dictionary<Currency, int> credit)
        {
            var missedMoney = new List<Currency>();

            foreach (KeyValuePair<Currency, int> item in money)
            {
                if (credit.ContainsKey(item.Key) && credit[item.Key] >= item.Value)
                {
                    credit[item.Key] -= item.Value;
                }
                else
                {
                    missedMoney.Add(item.Key);
                }
            }

            if (missedMoney.Count > 0)
            {
                throw new OutOfMoneyException(missedMoney);
            }

            return ToList(credit).ToList();
        }

        public bool HasMoney(IEnumerable<Currency> money)
        {
            if (money == null || !money.Any())
            {
                return true;
            }

            var credit = ToDictionary(_currency);

            return !ToDictionary(money).Any(entry => !credit.ContainsKey(entry.Key) || credit[entry.Key] < entry.Value);
        }

        public double Total()
        {
            double sum = 0;
            _currency.ForEach(m => sum += ((double)m) / 100);
            return sum;
        }

        public string GetFullReport()
        {
            return GetReport(true);
        }

        public string GetShortReport()
        {
            return GetReport(false);
        }

        private string GetReport(bool fullReport)
        {
            var result = new StringBuilder();
            result.AppendLine(ReportSeparatorLine);
            result.AppendLine($"Wallet: {Name}");
            result.AppendLine($"Date: {DateTime.Now.ToLongDateString()}");
            result.AppendLine($"Total: {Total()}");
            if (fullReport)
            {
                result.AppendLine($"Banknotes: {string.Join(",", Banknotes)}");
                result.AppendLine($"Coins: {string.Join(",", Coins)}");
            }

            result.AppendLine(ReportSeparatorLine);
            return result.ToString();
        }

        private Dictionary<Currency, int> ToDictionary(IEnumerable<Currency> money)
        {
            return (from item in money
                    group item by item
                    into batch
                    select new { A = batch.Key, B = batch.Count() })
                .ToDictionary(x => x.A, x => x.B);
        }

        private static IEnumerable<Currency> ToList(Dictionary<Currency, int> money)
        {
            var result = new List<Currency>();
            foreach (KeyValuePair<Currency, int> item in money.Where(i => i.Value > 0))
            {
                result.AddRange(Enumerable.Repeat(item.Key, item.Value));
            }
            return result;
        }
    }
}
