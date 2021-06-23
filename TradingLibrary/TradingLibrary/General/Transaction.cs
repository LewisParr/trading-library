using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingLibrary.General
{
    public class Transaction
    {
        private DateTime timestamp;
        private string fromSymbol;
        private double fromAmount;
        private string toSymbol;
        private double toAmount;
        private string feeSymbol;
        private double feeAmount;

        public Transaction()
        {
            timestamp = DateTime.MinValue;
            fromSymbol = "";
            fromAmount = 0;
            toSymbol = "";
            toAmount = 0;
            feeSymbol = "";
            feeAmount = 0;
        }

        public Transaction(DateTime timestamp, string fromSymbol, double fromAmount, string toSymbol, double toAmount)
        {
            ValidateAmount(fromAmount);
            ValidateAmount(toAmount);

            this.timestamp = timestamp;
            this.fromSymbol = fromSymbol;
            this.fromAmount = fromAmount;
            this.toSymbol = toSymbol;
            this.toAmount = toAmount;
            feeSymbol = "";
            feeAmount = 0;
        }

        public Transaction(DateTime timestamp, string fromSymbol, double fromAmount, string toSymbol, double toAmount, string feeSymbol, double feeAmount)
        {
            ValidateAmount(fromAmount);
            ValidateAmount(toAmount);
            ValidateAmount(feeAmount);

            this.timestamp = timestamp;
            this.fromSymbol = fromSymbol;
            this.fromAmount = fromAmount;
            this.toSymbol = toSymbol;
            this.toAmount = toAmount;
            this.feeSymbol = feeSymbol;
            this.feeAmount = feeAmount;
        }

        private void ValidateAmount(double amount)
        {
            if (amount < 0) throw new Exception(ErrorCodes.NEGATIVE_AMOUNT);
            if (amount == 0) throw new Exception(ErrorCodes.ZERO_AMOUNT);
        }
    }
}
