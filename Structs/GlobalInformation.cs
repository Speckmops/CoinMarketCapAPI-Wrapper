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
    /// GlobalInformation includes all global informations
    /// </summary>
    public struct GlobalInformation
    {
        private double _Total_Market_Cap_USD;
        private double _Total_24h_Volume_USD;
        private double _Bitcoin_Percentage_of_Market_Cap;
        private int _Active_Currencies;
        private int _Active_Assets;
        private int _Active_Markets;
        private ConvertedGlobalInformation _ConvertedGlobalInformation;
        private DateTime _Last_Updated;

        public double Total_Market_Cap_USD
        {
            get
            {
                return _Total_Market_Cap_USD;
            }
        }

        public double Total_24h_Volume_USD
        {
            get
            {
                return _Total_24h_Volume_USD;
            }
        }

        public double Bitcoin_Percentage_of_Market_Cap
        {
            get
            {
                return _Bitcoin_Percentage_of_Market_Cap;
            }
        }

        public int Active_Currencies
        {
            get
            {
                return _Active_Currencies;
            }
        }

        public int Active_Assets
        {
            get
            {
                return _Active_Assets;
            }
        }

        public int Active_Markets
        {
            get
            {
                return _Active_Markets;
            }
        }

        public ConvertedGlobalInformation ConvertedGlobalInformation
        {
            get
            {
                return _ConvertedGlobalInformation;
            }
        }

        public DateTime Last_Updated
        {
            get
            {
                return _Last_Updated;
            }
        }

        public GlobalInformation(string _JSON_RAW) : this()
        {
            Regex r = new Regex(@"""(?<key>[^""]+)"": (?<value>[^\n|^,]+)");

            MatchCollection mc = r.Matches(_JSON_RAW.Replace("\r", ""));
            Currency Currency = Currency.NONE;
            double Total_Market_Cap = 0;
            double Total_24h_Volume = 0;

            foreach (Match m in mc)
            {
                try
                {
                    switch (m.Groups["key"].ToString())
                    {
                        case "total_market_cap_usd":
                            _Total_Market_Cap_USD = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "total_24h_volume_usd":
                            _Total_24h_Volume_USD = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "bitcoin_percentage_of_market_cap":
                            _Bitcoin_Percentage_of_Market_Cap = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            break;
                        case "active_currencies":
                            _Active_Currencies = int.Parse(m.Groups["value"].ToString());
                            break;
                        case "active_assets":
                            _Active_Assets = int.Parse(m.Groups["value"].ToString());
                            break;
                        case "active_markets":
                            _Active_Markets = int.Parse(m.Groups["value"].ToString());
                            break;

                        case "last_updated":
                            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                            _Last_Updated = dt.AddSeconds(int.Parse(m.Groups["value"].ToString())).ToLocalTime();
                            break;
                        default:
                            if (m.Groups["key"].ToString().StartsWith("total_market_cap_"))
                            {
                                Currency = (Currency)Enum.Parse(typeof(Currency), m.Groups["key"].ToString().Replace("total_market_cap_", "").ToUpper());
                                Total_Market_Cap = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            }
                            if (m.Groups["key"].ToString().StartsWith("total_24h_volume_"))
                            {
                                Total_24h_Volume = double.Parse(m.Groups["value"].ToString(), CultureInfo.InvariantCulture);
                            }
                            break;
                    }
                }
                catch
                {
                    throw new ParsingFailedException();
                }

            }
            _ConvertedGlobalInformation = new ConvertedGlobalInformation(Currency, Total_Market_Cap, Total_24h_Volume);
        }
    }
}
