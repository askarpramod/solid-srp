using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SRP
{
    public class ReportGenerator
    {
        private const string ReportSeparatorLine = "-----------------------";

        public static string GenerateFullReport(Wallet wallet)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(ReportSeparatorLine);
            result.AppendLine($"Wallet: {wallet.Name}");
            result.AppendLine($"Date: {DateTime.Now.ToLongDateString()}");
            result.AppendLine($"Total: {wallet.Total()}");
            result.AppendLine($"Banknotes: {string.Join(",", wallet.Banknotes)}");
            result.AppendLine($"Coins: {string.Join(",", wallet.Coins)}");
            result.AppendLine(ReportSeparatorLine);
            return result.ToString();
        }

        public static string GenerateShortReport(Wallet wallet)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(ReportSeparatorLine);
            result.AppendLine($"Wallet: {wallet.Name}");
            result.AppendLine($"Date: {DateTime.Now.ToLongDateString()}");
            result.AppendLine($"Total: {wallet.Total()}");
            result.AppendLine(ReportSeparatorLine);
            return result.ToString();
        }
    }
}
