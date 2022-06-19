// See https://aka.ms/new-console-template for more information

using CurrencyConverter;
using static System.Console;

int command;
var currencyCatalog = new List<Currency>
{
    new("AUD", "Австралийский доллар", 1, 39.7651M),
    new("AZN", "Азербайджанский манат", 1, 33.3589M),
    new("AMD", "Армянских драмов", 100, 13.3341M),
    new("BYN", "Белорусский рубль", 1, 22.1152M),
    new("BGN", "Болгарский лев", 1, 30.1553M),
    new("BRL", "Бразильский реал", 1, 11.0944M),
    new("HUF", "Венгерских форинтов", 100, 14.9591M),
    new("USD", "Доллар США", 1, 56.7101M)    
};

var converter = new Converter(currencyCatalog, new ArgsChecker());

do
{
    PrintMenu();
    if (!int.TryParse(ReadLine(), out command))
    {
        continue;
    }

    switch (command)
    {
        case 1:
            PrintConversionFormat();
            WriteLine(converter.Convert(ReadLine()));
            break;
        case 2:
            PrintOperationFormat("addition");
            WriteLine(converter.Add(ReadLine()));
            break;    
        case 3:
            PrintOperationFormat("subtraction");
            WriteLine(converter.Subtract(ReadLine()));            
            break;
        case 4:
            break;
    }
} while (command != 4);

void PrintMenu()
{
    WriteLine("1. Convert");
    WriteLine("2. Addition");
    WriteLine("3. Subtraction");
    WriteLine("4. Exit");
    WriteLine("Enter the number of command:");    
}

void PrintOperationFormat(string operation)
{
    WriteLine($"Enter required data for {operation} as follows:");
    WriteLine("CurrencyCode1 Amount1 CurrencyCode2 Amount2");
    WriteLine("e.g. AZN 10 HUF 100");
    WriteLine("The result will be converted to the first currency");
}

void PrintConversionFormat()
{
    WriteLine("Enter required data as follows:");
    WriteLine("CurrencyCode1 CurrencyCode2 Amount2");
    WriteLine("e.g. AZN HUF 100");
    WriteLine("The result will be converted to the first currency");
}