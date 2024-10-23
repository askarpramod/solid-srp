using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class TransactionValidator
    {
        public static bool ValidateTransaction(List<Currency> currency, IEnumerable<Currency> money)
        {
            if (money == null || !money.Any())
            {
                return true;
            }

            var credit = CurrencyDictionaryConverter.ToDictionary(currency);

            return !CurrencyDictionaryConverter.ToDictionary(money).Any(entry => !credit.ContainsKey(entry.Key) || credit[entry.Key] < entry.Value);
        }
    }
}
