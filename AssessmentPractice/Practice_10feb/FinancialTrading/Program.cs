using System;
using System.Collections.Generic;
using System.Linq;

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType { Stock, Bond, Option, Future }

// 1. Generic portfolio
public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> _holdings = new(); // Instrument -> Quantity
    
    // TODO: Buy instrument
    public void Buy(T instrument, int quantity, decimal price)
    {
        // Validate: quantity > 0, price > 0
        if (quantity <= 0 || price <= 0)
        {
            throw new ArgumentException();
        }

        // Add to holdings or update quantity
        if (!_holdings.ContainsKey(instrument))
        {
            _holdings[instrument] = 0;
        }

        _holdings[instrument] += quantity;
    }
    
    // TODO: Sell instrument
    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        // Validate: enough quantity
        if (!_holdings.ContainsKey(instrument) || _holdings[instrument] < quantity)
        {
            return null;
        }

        // Remove/update holdings
        _holdings[instrument] -= quantity;
        if (_holdings[instrument] == 0)
        {
            _holdings.Remove(instrument);
        }

        // Return proceeds (quantity * currentPrice)
        return quantity * currentPrice;
    }
    
    // TODO: Calculate total value
    public decimal CalculateTotalValue()
    {
        // Sum of (quantity * currentPrice) for all holdings
        return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }
    
    // TODO: Get top performing instrument
    public (T instrument, decimal returnPercentage)? GetTopPerformer(
        Dictionary<T, decimal> purchasePrices)
    {
        if (!_holdings.Any())
        {
            return null;
        }

        var results = new List<(T, decimal)>();

        foreach (var h in _holdings)
        {
            if (!purchasePrices.ContainsKey(h.Key))
            {
                continue;
            }

            var buyPrice = purchasePrices[h.Key];
            var current = h.Key.CurrentPrice;

            decimal percent = ((current - buyPrice) / buyPrice) * 100;
            results.Add((h.Key, percent));
        }

        if (!results.Any())
        {
            return null;
        }

        return results.OrderByDescending(x => x.Item2).First();
    }

    public IEnumerable<T> GetInstruments() => _holdings.Keys;
}

// 2. Specialized instruments
public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; } = "";
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
    public string CompanyName { get; set; } = "";
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; } = "";
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;
    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

// 3. Generic trading strategy
public class TradingStrategy<T> where T : IFinancialInstrument
{
    // TODO: Execute strategy on portfolio
    public void Execute(Portfolio<T> portfolio, 
        Func<T, bool> buyCondition,
        Func<T, bool> sellCondition)
    {
        // For each instrument in market data
        // Apply buy/sell conditions
        // Execute trades
        foreach (var instrument in portfolio.GetInstruments().ToList())
        {
            if (sellCondition(instrument))
            {
                portfolio.Sell(instrument, 1, instrument.CurrentPrice);
            }
            else if (buyCondition(instrument))
            {
                portfolio.Buy(instrument, 1, instrument.CurrentPrice);
            }
        }
    }
    
    // TODO: Calculate risk metrics
    public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        // Return: Volatility, Beta, Sharpe Ratio
        var prices = instruments.Select(i => i.CurrentPrice).ToList();

        if (!prices.Any())
        {
            return new Dictionary<string, decimal>();
        }

        decimal avg = prices.Average();
        decimal variance = prices.Sum(p => (p - avg) * (p - avg)) / prices.Count;
        decimal volatility = (decimal)Math.Sqrt((double)variance);

        return new Dictionary<string, decimal>
        {
            ["Volatility"] = volatility,
            ["Beta"] = avg / 100,
            ["SharpeRatio"] = avg / (volatility == 0 ? 1 : volatility)
        };
    }
}

// 4. Price history with generics
public class PriceHistory<T> where T : IFinancialInstrument
{
    private Dictionary<T, List<(DateTime, decimal)>> _history = new();
    
    // TODO: Add price point
    public void AddPrice(T instrument, DateTime timestamp, decimal price)
    {
        // Add to history
        if (!_history.ContainsKey(instrument))
        {
            _history[instrument] = new List<(DateTime, decimal)>();
        }

        _history[instrument].Add((timestamp, price));
    }
    
    // TODO: Get moving average
    public decimal? GetMovingAverage(T instrument, int days)
    {
        // Calculate simple moving average
        if (!_history.ContainsKey(instrument))
        {
            return null;
        }

        var prices = _history[instrument].OrderByDescending(x => x.Item1).Take(days).Select(x => x.Item2).ToList();

        if (!prices.Any())
        {
            return null;
        }

        return prices.Average();
    }
    
    // TODO: Detect trends
    public Trend DetectTrend(T instrument, int period)
    {
        // Return: Upward, Downward, Sideways
        if (!_history.ContainsKey(instrument))
        {
            return Trend.Sideways;
        }

        var prices = _history[instrument].OrderByDescending(x => x.Item1).Take(period).Select(x => x.Item2).ToList();

        if (prices.Count < 2)
        {
            return Trend.Sideways;
        }

        if (prices.First() > prices.Last())
        {
            return Trend.Upward;
        }
        if (prices.First() < prices.Last())
        {
            return Trend.Downward;
        }

        return Trend.Sideways;
    }
}

public enum Trend { Upward, Downward, Sideways }

// 5. TEST SCENARIO: Trading simulation
public class Program
{
    public static void Main()
    {
        // a) Create portfolio with mixed instruments
        var apple = new Stock { Symbol = "AAPL", CurrentPrice = 150, CompanyName = "Apple" };
        var bond = new Bond { Symbol = "BND1", CurrentPrice = 100, CouponRate = 5 };

        var portfolio = new Portfolio<IFinancialInstrument>();
        portfolio.Buy(apple, 5, 150);
        portfolio.Buy(bond, 3, 100);

        // b) Buy/sell logic
        Console.WriteLine("Total Value: " + portfolio.CalculateTotalValue());

        // c) Trading strategy
        var strategy = new TradingStrategy<IFinancialInstrument>();
        strategy.Execute(
            portfolio,
            i => i.CurrentPrice < 120,
            i => i.CurrentPrice > 140
        );

        // d) Price history
        var history = new PriceHistory<IFinancialInstrument>();
        history.AddPrice(apple, DateTime.Now.AddDays(-3), 140);
        history.AddPrice(apple, DateTime.Now.AddDays(-2), 145);
        history.AddPrice(apple, DateTime.Now.AddDays(-1), 150);

        // e) Demonstrations
        Console.WriteLine("Moving Avg: " + history.GetMovingAverage(apple, 3));
        Console.WriteLine("Trend: " + history.DetectTrend(apple, 3));

        var risks = strategy.CalculateRiskMetrics(portfolio.GetInstruments());
        foreach (var r in risks)
        {
            Console.WriteLine($"{r.Key}: {r.Value}");
        }
    }
}