namespace CreditSuisseItDevRisk;

class TradeService
{
    public List<TradeResult> GetResults(List<ITrade> trades, DateTime referenceDate)
    {
        var results = new List<TradeResult>();
        foreach (var trade in trades)
        {
            var result = CreateResult(trade, referenceDate);
            results.Add(result);
        }

        return results;
    }

    public ITrade CreateTrade(string tradeData)
    {
        var datas = tradeData.Split(' ');
        if (datas.Length != 3)
        {
            throw new ArgumentException(
                $"Invalid trade. Expected 3 parameters and received: {datas.Length}"
            );
        }

        var value = InputUtil.ParseDouble(datas[0]);
        var clientSector = InputUtil.ParseString(datas[1]);
        var nextPaymentDate = InputUtil.ParseDatetime(datas[2]);

        return new Trade(value, clientSector, nextPaymentDate);
    }

    private static TradeResult CreateResult(ITrade trade, DateTime referenceDate)
    {
        if (IsTradeExpired(trade.NextPaymentDate, referenceDate))
        {
            return new(trade, Category.Expired);
        }

        if (IsTradeRisk(trade.Value))
        {
            var category = GetTypeRisk(trade.ClientSector);
            return new(trade, category);
        }

        return new(trade, Category.DefaultRisk);
    }

    private static bool IsTradeExpired(DateTime nextPaymentDate, DateTime referenceDate)
    {
        const int daysToExpire = 30;
        return nextPaymentDate.AddDays(daysToExpire) < referenceDate;
    }

    private static bool IsTradeRisk(double tradeValue)
    {
        const int tradeRiskValue = 1_000_000;
        return tradeValue > tradeRiskValue;
    }

    private static Category GetTypeRisk(string sector)
    {
        const string highRiskSector = "Private";
        const string mediumRiskSector = "Public";

        return sector switch
        {
            highRiskSector => Category.HighRisk,
            mediumRiskSector => Category.MediumRisk,
            _ => Category.DefaultRisk,
        };
    }
}
