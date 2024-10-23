using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class CurrencyConverter
    {
        const int MaxCoin= 200;

        public static IEnumerable<Currency> GetCoins(IEnumerable<Currency> currency)
        {
            return currency.Where(m => (int)m <= MaxCoin);
        }

        public static IEnumerable<Currency> GetBanknotes(IEnumerable<Currency> currency)
        {
            return currency.Where(m => (int)m > MaxCoin);
        }
    }
}
