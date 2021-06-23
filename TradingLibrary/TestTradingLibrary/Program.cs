using System;
using TradingLibrary;

namespace TestTradingLibrary
{
    class Program
    {
        static int nPass;
        static int nFail;

        static void Main(string[] args)
        {
            nPass = 0;
            nFail = 0;

            Console.WriteLine("Running tests..\n");

            Test_General_Transaction();
            Test_Binance_MarketDecomposer();

            Console.WriteLine("\nTests completed");
            Console.WriteLine("\tPassing: " + nPass);
            Console.WriteLine("\tFailing: " + nFail);
            Console.Read();
        }

        static void Test_General_Transaction()
        {
            Console.WriteLine("\nTesting General.Transaction..");
            try
            {
                var transaction = new TradingLibrary.General.Transaction();
                Console.WriteLine("Constructed empty Transaction successfully");
                nPass++;
            }
            catch
            {
                Console.WriteLine("Failed constructing empty Transaction");
                nFail++;
            }

            try
            {
                var transaction = new TradingLibrary.General.Transaction(DateTime.Now, "GBP", 21.3, "BTC", 0.00034);
                Console.WriteLine("Constructed from/to Transaction successfully");
                nPass++;
            }
            catch
            {
                Console.WriteLine("Failed constructing from/to Transaction");
                nFail++;
            }

            try
            {
                var transaction = new TradingLibrary.General.Transaction(DateTime.Now, "GBP", 43.5, "BTC", 0.00453, "BNB", 0.000023);
                Console.WriteLine("Constructed from/to/fee Transaction successfully");
                nPass++;
            }
            catch
            {
                Console.WriteLine("Failed constructing from/to/fee Transaction");
                nFail++;
            }
        }

        static void Test_Binance_MarketDecomposer()
        {
            Console.WriteLine("\nTesting Binance.MarketDecomposer..");
            try
            {
                string[] symbols = TradingLibrary.Binance.MarketDecomposer.Decompose("BTCGBP");
                if (symbols[0] != "BTC") throw new Exception();
                if (symbols[1] != "GBP") throw new Exception();
                Console.WriteLine("Decomposed 'BTCGBP' successfully");
                nPass++;
            }
            catch
            {
                Console.WriteLine("Failed to decompose 'BTCGBP'");
                nFail++;
            }

            try
            {
                string[] symbols = TradingLibrary.Binance.MarketDecomposer.Decompose("GBPUSDT");
                if (symbols[0] != "GBP") throw new Exception();
                if (symbols[1] != "USDT") throw new Exception();
                Console.WriteLine("Decomposed 'GBPUSDT' successfully");
                nPass++;
            }
            catch
            {
                Console.WriteLine("Failed to decompose 'GBPUSDT'");
                nFail++;
            }

            try
            {
                string[] symbols = TradingLibrary.Binance.MarketDecomposer.Decompose("VITEUSDT");
                if (symbols[0] != "VITE") throw new Exception();
                if (symbols[1] != "USDT") throw new Exception();
                Console.WriteLine("Decomposed 'VITEUSDT' successfully");
                nPass++;
            }
            catch
            {
                Console.WriteLine("Failed to decompose 'VITEUSDT'");
                nFail++;
            }

            try
            {
                string[] symbols = TradingLibrary.Binance.MarketDecomposer.Decompose("XXXYYY");
                Console.WriteLine("Failed to identify unknown market");
                nFail++;
            }
            catch
            {
                Console.WriteLine("Successfully identified unknown market");
                nPass++;
            }
        }
    }
}
