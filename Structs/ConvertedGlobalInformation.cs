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

namespace par0noid.CoinMarketCap
{
    /// <summary>
    /// ConvertedGlobalInformation includes the converted globalinformation values
    /// </summary>
    public struct ConvertedGlobalInformation
    {
        private Currency _Currency;
        private double _Total_Market_Cap;
        private double _Total_24h_Volume;

        public Currency Currency
        {
            get
            {
                return _Currency;
            }
        }

        public double Total_Market_Cap
        {
            get
            {
                return _Total_Market_Cap;
            }
        }

        public double Total_24h_Volume
        {
            get
            {
                return _Total_24h_Volume;
            }
        }

        public ConvertedGlobalInformation(Currency Currency, double Total_Market_Cap, double Total_24h_Volume)
        {
            _Currency = Currency;
            _Total_Market_Cap = Total_Market_Cap;
            _Total_24h_Volume = Total_24h_Volume;
        }
    }
}
