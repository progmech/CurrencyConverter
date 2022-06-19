namespace CurrencyConverter;

public class ArgsChecker : IArgsChecker
{
    public bool CheckConversionArgs(string args, out string currencyFirst, out string currencySecond, out decimal amountSecond)
    {
        try
        {
            string[] values = args.Split(' ');            
            currencyFirst = values[0];
            currencySecond = values[1];
            amountSecond = int.Parse(values[2]);
            return true;
        }
        catch
        {
            currencyFirst = "";
            currencySecond = "";
            amountSecond = 0;
            return false;            
        }
    }

    public bool CheckOperationArgs(string args, out string currencyFirst, out decimal amountFirst, out string currencySecond,
        out decimal amountSecond)
    {
        try
        {
            string[] values = args.Split(' ');            
            currencyFirst = values[0];
            amountFirst = int.Parse(values[1]);
            currencySecond = values[2];
            amountSecond = int.Parse(values[3]);
            return true;
        }
        catch
        {
            currencyFirst = "";
            amountFirst = 0;
            currencySecond = "";
            amountSecond = 0;
            return false;            
        }
    }
}

public interface IArgsChecker
{
    public bool CheckConversionArgs(string args, out string currencyFirst, out string currencySecond,
        out decimal amountSecond);

    public bool CheckOperationArgs(string args, out string currencyFirst, out decimal amountFirst,
        out string currencySecond, out decimal amountSecond);
}