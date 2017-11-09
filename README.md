# CoinMarketCapAPI-Wrapper
CoinMarketCapAPI-Wrapper is a simple C# Library for Wrapping the CoinMarketCapAPI.

Dev-Website: http://par0noid.info


# Getting startet
You just have to include the CoinMarketCapAPI-Wrapper.dll from bin\ directory into your project.

After that add this namespace to your using-section:
```C#
using par0noid.CoinMarketCap;
```


# Examples
**Simple coin request**
```C#
static void Main(string[] args)
{
    CoinMarketCapAPI API = new CoinMarketCapAPI();

    Coin Coin = API.RequestCoin(CoinType.XVG); //Request VergeCoin

    Console.WriteLine(Coin.Name + ": " + Coin.Price_USD);
}
```
**Simple coin request with currency conversion**
```C#
static void Main(string[] args)
{
    CoinMarketCapAPI API = new CoinMarketCapAPI();

    Coin Coin = API.RequestCoin(CoinType.XVG, Currency.EUR); //Request VergeCoin

    Console.WriteLine(Coin.Name + ": " + Coin.ConvertedCurrency.Price);
}
```
**Request TOP10 Coins**
```C#
static void Main(string[] args)
{
    CoinMarketCapAPI API = new CoinMarketCapAPI();

    Coin[] Coins = API.RequestAll(0, 10);

    for(int i = 0; i < Coins.Length; i++)
    {
        Console.WriteLine("#" + Coins[i].Rank + " " + Coins[i].Name + ": " + Coins[i].Price_USD);
    }
}
```
**Request global Information**
```C#
static void Main(string[] args)
{
    CoinMarketCapAPI API = new CoinMarketCapAPI();

    GlobalInformation globalInfo = API.RequestGlobalInformation();

    Console.WriteLine("Total market Cap: " + globalInfo.Total_Market_Cap_USD);
}
```
