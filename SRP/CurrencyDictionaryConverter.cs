using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class CurrencyDictionaryConverter
    {
        public static Dictionary<Currency, int> ToDictionary(IEnumerable<Currency> money)
        {
            return (from item in money
                    group item by item
                    into batch
                    select new { A = batch.Key, B = batch.Count() })
                .ToDictionary(x => x.A, x => x.B);
        }
    }
}
