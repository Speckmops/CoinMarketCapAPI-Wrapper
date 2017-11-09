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
    /// ConvertedCurrency includes the converted currency values
    /// </summary>
    public struct ConvertedCurrency
    {
        private Currency _Currency;
        private double _Price;
        private double _Volume_24h;
        private double _Market_Cap;

        public Currency Currency
        {
            get
            {
                return _Currency;
            }
        }

        public double Price
        {
            get
            {
                return _Price;
            }
        }

        public double Volume_24h
        {
            get
            {
                return _Volume_24h;
            }
        }

        public double Market_Cap
        {
            get
            {
                return _Market_Cap;
            }
        }

        public ConvertedCurrency(Currency ConvertCurrency, double Price, double Volume_24h, double Market_Cap)
        {
            _Currency = ConvertCurrency;
            _Price = Price;
            _Volume_24h = Volume_24h;
            _Market_Cap = Market_Cap;
        }
    }
}
