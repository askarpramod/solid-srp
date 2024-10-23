using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class CurrencyCalculator
    {
        public static double CalculateTotal(List<Currency> currency)
        {
            double sum = 0;
            currency.ForEach(m => sum += ((double)m) / 100);
            return sum;
        }
    }
}
