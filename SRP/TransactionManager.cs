using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class TransactionManager
    {
        public static List<Currency> ExecuteTransaction(Dictionary<Currency, int> money, Dictionary<Currency, int> credit)
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

            return CurrencyListConverter.ToList(credit).ToList();
        }

        
    }
}
