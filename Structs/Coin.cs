/*
                           __                           __     
                         /'__`\                  __    /\ \    
 _____      __     _ __ /\ \/\ \    ___     ___ /\_\   \_\ \   
/\ '__`\  /'__`\  /\`'__\ \ \ \ \ /' _ `\  / __`\/\ \  /'_` \  
\ \ \L\ \/\ \L\.\_\ \ \/ \ \ \_\ \/\ \/\ \/\ \L\ \ \ \/\ \L\ \ 
 \ \ ,__/\ \__/.\_\\ \_\  \ \____/\ \_\ \_\ \____/\ \_\ \___,_\
  \ \ \/  \/__/\/_/ \/_/   \/___/  \/_/\/_/\/___/  \/_/\/__,_ /
   \ \_\                                                       
    \/_/                                      addicted to code


Copyright (C) 2017  Stefan 'par0noid' Zehnpfennig

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.

 */
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace par0noid.CoinMarketCap
{
    /// <summary>
    /// Coin class includes all statistic information about a coin
    /// </summary>
    public struct Coin
    {
        private string _ID;
        private string _Name;
        private string _Symbol;
        private int _Rank;
        private double _Price_USD;
        private double _Price_BTC;
        private double _24h_Volume_USD;
        private double _Market_Cap_USD;
        private double _Available_Supply;
        private double _Total_Supply;
        private double _Max_Supply;
        private double _Percent_Change_1h;
        private double _Percent_Change_24h;
        private double _Percent_Change_7d;
        private ConvertedCurrency _ConvertedCurrency;
        private DateTime _Last_Updated;

        public string ID
        {
            get
            {
                return _ID;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public string Symbol
        {
            get
            {
                return _Symbol;
            }
        }

        public int Rank
        {
            get
            {
                return _Rank;
            }
        }

        public double Price_USD
        {
            get
            {
                return _Price_USD;
            }
        }

        public double Price_BTC
        {
            get
            {
                return _Price_BTC;
            }
        }

        public double Volume_USD_24h
        {
            get
            {
                return _24h_Volume_USD;
            }

        }

        public double Market_Cap_USD
        {
            get
            {
                return _Market_Cap_USD;
            }
        }

        public double Available_Supply
        {
            get
            {
                return _Available_Supply;
            }
        }

        public double Total_Supply
        {
            get
            {
                return _Total_Supply;
            }
        }

        public double Max_Supply
        {
            get
            {
                return _Max_Supply;
            }
        }

        public double Percent_Change_1h
        {
            get
            {
                return _Percent_Change_1h;
            }
        }

        public double Percent_Change_24h
        {
            get
            {
                return _Percent_Change_24h;
            }
        }

        public double Percent_Change_7d
        {
            get
            {
                return _Percent_Change_7d;
            }
        }

        public ConvertedCurrency ConvertedCurrency
        {
            get
            {
                return _ConvertedCurrency;
            }
        }

        public DateTime Last_Updated
        {
            get
            {
                return _Last_Updated;
            }
        }

        public Coin(string _JSON_RAW) : this()
        {
            Regex r = new Regex(@"""(?<key>[^""]+)"": ""(?<value>[^""]+)""");

            MatchCollection mc = r.Matches(_JSON_RAW);
            Currency Currency = Currency.NONE;
            double Price = 0;
            double Volume_24h = 0;
            double Market_Cap = 0;

            foreach (Match m in mc)
            {
                try
                {
                    switch (m.Groups["key"].ToString())
                    {
                        case "id":
                            _ID = m.Groups["value"].ToString();
                            break;
                        case "name":
                            _Name = m.Groups["value"].ToString();
                            break;
                        case "symbol":
                            _Symbol = m.Groups["value"].ToString();
                            break;
                        case "rank":
                            _Rank = int.Parse(m.Groups["value"].ToString());
                            break;
                        case "price_usd":
                            _Price_USD = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "price_btc":
                            _Price_BTC = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "24h_volume_usd":
                            _24h_Volume_USD = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "market_cap_usd":
                            _Market_Cap_USD = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "available_supply":
                            _Available_Supply = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "total_supply":
                            _Total_Supply = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "max_supply":
                            _Max_Supply = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "percent_change_1h":
                            _Percent_Change_1h = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "percent_change_24h":
                            _Percent_Change_24h = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "percent_change_7d":
                            _Percent_Change_7d = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "last_updated":
                            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                            _Last_Updated = dt.AddSeconds(int.Parse(m.Groups["value"].ToString())).ToLocalTime();
                            break;
                        default:
                            if (m.Groups["key"].ToString().StartsWith("price_"))
                            {
                                Currency = (Currency)Enum.Parse(typeof(Currency), m.Groups["key"].ToString().Replace("price_", "").ToUpper());
                                Price = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            }
                            if (m.Groups["key"].ToString().StartsWith("24h_volume_"))
                            {
                                Volume_24h = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            }
                            if (m.Groups["key"].ToString().StartsWith("market_cap_"))
                            {
                                Market_Cap = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            }
                            break;
                    }
                }
                catch
                {
                    throw new ParsingFailedException();
                }
                
            }
            _ConvertedCurrency = new ConvertedCurrency(Currency, Price, Volume_24h, Market_Cap);
        }
    }
}
