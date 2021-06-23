using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingLibrary
{
    public static class ErrorCodes
    {
        // Transaction
        public static string NEGATIVE_AMOUNT = "Amount is negative";
        public static string ZERO_AMOUNT = "Amount is zero";

        // Binance
        public static string UNKNOWN_TYPE = "Unknown transaction type '{0}'";
        public static string BLANK_MARKET = "Market is blank";
        public static string UNKNOWN_MARKET = "Unknown market '{0}'";
    }
}
