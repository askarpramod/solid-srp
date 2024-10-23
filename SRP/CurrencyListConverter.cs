using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class CurrencyListConverter
    {
        public static IEnumerable<Currency> ToList(Dictionary<Currency, int> money)
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
