namespace CurrencyConverter;

// Поскольку в задаче нет сигнатуры объекта "Валюта", я определил объект следующим образом.
// За основу взяты данные с сайта ЦБ РФ https://cbr.ru/currency_base/daily/
public record Currency(string Code, string Name, int Units, decimal ExchangeRate);