namespace CreditSuisseItDevRisk;

static class TradeDashboard
{
    public static bool Exit { get; private set; }
    public static TradeService _tradeService = new();

    public static void Run()
    {
        while (!Exit)
        {
            try
            {
                Console.WriteLine("Welcome to CreditSuisse IT DEV RISK!!!!");

                var referenceDate = InputUtil.GetInputAsDateTime("Insert the Reference Date:");
                var tradesNumber = InputUtil.GetInputAsInteger("Insert the number of trades:");
                var trades = CreateTrades(tradesNumber).ToList();

                var results = _tradeService.GetResults(trades, referenceDate);

                PrintResult(results);
                Exit = UserWantExit();
            }
            catch (Exception exception)
            {
                Console.WriteLine("\nAn error has occurred: {0}\n", exception.Message);
            }
        }
    }

    private static bool UserWantExit()
    {
        string input = InputUtil.GetInputAsString("\nDo you want to exit? (y/n)");
        return input.Equals("y", StringComparison.OrdinalIgnoreCase);
    }

    private static IEnumerable<ITrade> CreateTrades(int tradesNumber)
    {
        for (int i = 0; i < tradesNumber; i++)
        {
            var tradeData = InputUtil.GetInputAsString("Insert your trade:");
            yield return _tradeService.CreateTrade(tradeData);
        }
    }

    private static void PrintResult(List<TradeResult> results)
    {
        Console.WriteLine("\nThe output");
        foreach (var result in results)
        {
            Console.WriteLine(result.Category.ToString().ToUpper());
        }

        Console.WriteLine("\nTrade/Category");
        foreach (var result in results)
        {
            var trade = result.Trade;
            Console.WriteLine(
                "[value: {0}; clientSector: {1}; nextPaymentDate {2}; category: {3}]",
                trade.Value,
                trade.ClientSector,
                trade.NextPaymentDate,
                result.Category
            );
        }
    }
}
