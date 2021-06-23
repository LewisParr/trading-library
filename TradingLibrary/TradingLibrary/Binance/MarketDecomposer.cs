using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingLibrary.Binance
{
    public static class MarketDecomposer
    {
        public static string[] Decompose(string market)
        {
            switch (market)
            {
                case "BNBGBP": return new string[] { "BNB", "GBP" };
                case "BTCGBP": return new string[] { "BTC", "GBP" };
                case "CHZGBP": return new string[] { "CHZ", "GBP" };
                case "DOTGBP": return new string[] { "DOT", "GBP" };
                case "ENJGBP": return new string[] { "ENJ", "GBP" };
                case "ETHGBP": return new string[] { "ETH", "GBP" };
                case "GBPUSDT": return new string[] { "GBP", "USDT" };
                case "LINKGBP": return new string[] { "LINK", "GBP" };
                case "LTCGBP": return new string[] { "LTC", "GBP" };
                case "VETGBP": return new string[] { "VET", "GBP" };
                case "VITEUSDT": return new string[] { "VITE", "USDT" };
                case "XRPGBP": return new string[] { "XRP", "GBP" };
                default: throw new Exception(string.Format(ErrorCodes.UNKNOWN_MARKET, market));
            }
        }
    }
}
