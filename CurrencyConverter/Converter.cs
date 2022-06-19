namespace CurrencyConverter;

public class Converter : ICurrencyConverter
{
    private readonly List<Currency> _currencyCatalog;
    private readonly IArgsChecker _argsChecker;

    public Converter(List<Currency> catalog, IArgsChecker argsChecker)
    {
        _currencyCatalog = catalog;
        _argsChecker = argsChecker;
    }
    public decimal Subtract(string args)
    {
        var result = Decimal.MinValue;
        if (_argsChecker.CheckOperationArgs(args, out string firstCode, out decimal firstAmount,
                out string secondCode, out decimal secondAmount))
        {
            Currency? firstCurrency = _currencyCatalog.FirstOrDefault(c => c.Code == firstCode);
            Currency? secondCurrency = _currencyCatalog.FirstOrDefault(c => c.Code == secondCode);
            if (firstCurrency != null && secondCurrency != null)
            {
                decimal firstRubleResult = firstAmount / firstCurrency.Units * firstCurrency.ExchangeRate;
                decimal secondRubleResult = secondAmount / secondCurrency.Units * secondCurrency.ExchangeRate;                
                result = (firstRubleResult - secondRubleResult) / (firstCurrency.Units * firstCurrency.ExchangeRate);
            }

        }        
        return result;
    }
    
    public decimal Add(string args)
    {
        var result = Decimal.MinValue;
        if (_argsChecker.CheckOperationArgs(args, out string firstCode, out decimal firstAmount, 
                out string secondCode, out decimal secondAmount))
        {
            Currency? firstCurrency = _currencyCatalog.FirstOrDefault(c => c.Code == firstCode);
            Currency? secondCurrency = _currencyCatalog.FirstOrDefault(c => c.Code == secondCode);
            if (firstCurrency != null && secondCurrency != null)
            {
                decimal firstRubleResult = firstAmount / firstCurrency.Units * firstCurrency.ExchangeRate;
                decimal secondRubleResult = secondAmount / secondCurrency.Units * secondCurrency.ExchangeRate;                
                result = (firstRubleResult + secondRubleResult) / (firstCurrency.Units * firstCurrency.ExchangeRate);
            }

        }        
        return result;
    }
    
    public decimal Convert(string args)
    {
        var result = Decimal.MinValue;
        if (_argsChecker.CheckConversionArgs(args, out string firstCode, out string secondCode, out decimal amount))
        {
            Currency? firstCurrency = _currencyCatalog.FirstOrDefault(c => c.Code == firstCode);
            Currency? secondCurrency = _currencyCatalog.FirstOrDefault(c => c.Code == secondCode);
            if (firstCurrency != null && secondCurrency != null)
            {
                result = amount / secondCurrency.Units * secondCurrency.ExchangeRate / (firstCurrency.Units * firstCurrency.ExchangeRate);
            }

        }        
        return result;
    }    
}

public interface ICurrencyConverter
{
    public decimal Convert(string args);    
    public decimal Add(string args);
    public decimal Subtract(string args);
}
