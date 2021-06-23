using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TradingLibrary.Binance
{
    public class SpotOrderTransaction
    {
        private DateTime timestamp;
        private string market;
        private string type;
        private double price;
        private double amount;
        private double total;
        private double fee;
        private string feeCoin;

        private string fund;

        public SpotOrderTransaction()
        {
            timestamp = DateTime.MinValue;
            market = "";
            type = "";
            price = 0;
            amount = 0;
            total = 0;
            fee = 0;
            feeCoin = "";
            fund = "";
        }

        public SpotOrderTransaction(DateTime timestamp, string market, string type, double price, double amount, double total, double fee, string feeCoin, string fund = "")
        {
            ValidateMarket(market);
            ValidateType(type);

            this.timestamp = timestamp;
            this.market = market;
            this.type = type;
            this.price = price;
            this.amount = amount;
            this.total = total;
            this.fee = fee;
            this.feeCoin = feeCoin;
            this.fund = fund;
        }

        public General.Transaction ToGeneralTransaction()
        {
            string[] symbols = MarketDecomposer.Decompose(market);

            DateTime tTimestamp = timestamp;
            string fromSymbol = type == "BUY" ? symbols[1] : symbols[0];
            double fromAmount = type == "BUY" ? total : amount;
            string toSymbol = type == "BUY" ? symbols[0] : symbols[1];
            double toAmount = type == "BUY" ? amount : total;
            string feeSymbol = feeCoin;
            double feeAmount = fee;

            return new General.Transaction(tTimestamp, fromSymbol, fromAmount, toSymbol, toAmount, feeSymbol, feeAmount);
        }

        private void ValidateMarket(string market)
        {
            if (market == "") throw new Exception(ErrorCodes.BLANK_MARKET);
            MarketDecomposer.Decompose(market);
        }

        private void ValidateType(string type)
        {
            if (type != "BUY" &&
                type != "SELL")
            {
                throw new Exception(string.Format(ErrorCodes.UNKNOWN_TYPE, type));
            }
        }
    }
}
