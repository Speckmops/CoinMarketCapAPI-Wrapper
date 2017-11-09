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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace par0noid.CoinMarketCap
{
    public class CoinMarketCapAPI
    {
        //URL to CoinMarketCapAPI
        private const string API_URL = "https://api.coinmarketcap.com/v1/";
        //CoinNames, used by enum CoinType
        private string[] _CoinNames = new string[] { "bitcoin", "ethereum", "bitcoin-cash", "ripple", "litecoin", "dash", "neo", "nem", "monero", "iota", "ethereum-classic", "qtum", "omisego", "cardano", "lisk", "zcash", "bitconnect", "stellar", "eos", "tether", "waves", "hshare", "stratis", "ark", "komodo", "populous", "steem", "bytecoin-bcn", "ardor", "electroneum", "maidsafecoin", "gas", "vertcoin", "augur", "tenx", "binance-coin", "decred", "bitshares", "salt", "pivx", "bitcoindark", "golem-network-tokens", "monacoin", "basic-attention-token", "veritaseum", "factom", "walton", "tron", "kyber-network", "dogecoin", "metaverse", "digixdao", "siacoin", "blocknet", "gamecredits", "syscoin", "bytom", "byteball", "status", "0x", "aeternity", "verge", "civic", "singulardtv", "gxshares", "metal", "lykke", "digibyte", "iconomi", "bancor", "gnosis-gno", "particl", "attention-token-of-media", "chainlink", "bitquence", "vechain", "pura", "funfair", "ripio-credit-network", "nxt", "kucoin", "b3coin", "power-ledger", "adx-net", "monaco", "zencash", "cryptonex", "nav-coin", "neblio", "nexus", "streamr-datacoin", "zcoin", "faircoin", "storj", "ubiq", "mcap", "groestlcoin", "loopring", "edgeless", "iocoin", "zeusshield", "rlc", "kin", "bitdeal", "aragon", "dentacoin", "mobilego", "nolimitcoin", "taas", "airswap", "peercoin", "viacoin", "wings", "request-network", "modum", "open-trading-network", "quantum-resistant-ledger", "sonm", "melon", "counterparty", "rise", "gulden", "decentraland", "enigma-project", "moeda-loyalty-points", "amber", "cofound-it", "viberate", "achain", "everex", "substratum", "reddcoin", "cloakcoin", "leocoin", "firstblood", "tokencard", "emercoin", "pillar", "district0x", "potcoin", "tierion", "trust", "elastic", "centra", "bitbay", "red-pulse", "aeon", "skycoin", "triggers", "icos", "decent", "xplay", "stox", "coindash", "xaurum", "atbcoin", "diamond", "crown", "namecoin", "paypie", "smartcash", "eidoo", "feathercoin", "etheroll", "sibcoin", "safe-exchange-coin", "ion", "paragon", "okcash", "peerplays-ppy", "credence-coin", "monetha", "rubycoin", "the-champcoin", "blackcoin", "domraider", "pepe-cash", "chronobank", "library-credit", "vericoin", "cindicator", "gridcoin", "salus", "santiment", "toacoin", "alis", "e-coin", "mothership", "bitdice", "poet", "dubaicoin-dbix", "agoras-tokens", "digitalnote", "rialto", "numeraire", "expanse", "energycoin", "humaniq", "golos", "einsteinium", "raiblocks", "solarcoin", "blackmoon-crypto", "waves-community-token", "agrello-delta", "primas", "monetaryunit", "clams", "omni", "credo", "revain", "aventus", "target-coin", "guppy", "florincoin", "nexium", "synereo", "maecenas", "soarcoin", "vcash", "asch", "whitecoin", "transfercoin", "shift", "adtoken", "lunyr", "polybius", "patientory", "radium", "spectrecoin", "investfeed", "mysterium", "burst", "databits", "oax", "bitcore", "change", "nebulas-token", "centurion", "lomocoin", "unobtanium", "swarm-city", "bitsend", "encryptotel", "sphere", "bitqy", "novacoin", "kickico", "nvo", "prizm", "obits", "neoscoin", "casinocoin", "hive", "wagerr", "bitcloud", "gambit", "nimiq", "dao-casino", "lampix", "pinkcoin", "quantum", "earthcoin", "voxels", "xtrabytes", "ixledger", "e-dinar-coin", "rivetz", "compcoin", "bitcrystals", "korecoin", "blocktix", "pluton", "curecoin", "coss", "dovu", "incent", "bitcny", "oraclechain", "greencoin", "ecobit", "airtoken", "masternodecoin", "obsidian", "musicoin", "stealthcoin", "bankcoin", "goldcoin", "blockmason", "dynamic", "bitbean", "project-decorum", "sequence", "xcurrency", "htmlcoin", "exclusivecoin", "qwark", "vslice", "vibe", "rupee", "heat-ledger", "foldingcoin", "hedge", "pascal-coin", "confido", "cvcoin", "zrcoin", "auroracoin", "creditbit", "bitcoin-plus", "posw-coin", "dimecoin", "mybit-token", "equitrader", "circuits-of-value", "global-currency-reserve", "europecoin", "tao", "voisecom", "trueflip", "synergy", "applebyte", "dent", "pesetacoin", "nushares", "mooncoin", "aeron", "internet-of-people", "bitswift", "belacoin", "blockcat", "propy", "apx", "myriad", "neutron", "veriumreserve", "yocoin", "thegcccoin", "hush", "blitzcash", "syndicate", "riecoin", "audiocoin", "hempcoin", "terracoin", "bitusd", "trustplus", "suncontract", "zeitcoin", "geocoin", "flik", "steem-dollars", "go-coin", "bitmark", "mintcoin", "memetic", "dnotes", "2give", "zclassic", "social", "primecoin", "breakout-stake", "vivo", "evergreencoin", "bridgecoin", "bluecoin", "latoken", "real", "spreadcoin", "bitland", "opus", "breakout", "janus", "sexcoin", "xp", "royal-kingdom-coin", "bitcoinz", "primalbase", "hubii-network", "neverdie", "creativecoin", "tracto", "deeponion", "vtorrent", "dopecoin", "parkbyte", "autonio", "indorse-token", "clearpoll", "bismuth", "putincoin", "embers", "remicoin", "condensate", "mercury", "karbowanec", "crave", "starta", "hellogold", "cannabiscoin", "visio", "chaincoin", "huntercoin", "kolion", "oceanlab", "quark", "startcoin", "atc-coin", "legends-room", "tokes", "e-gulden", "onix", "magi", "arcticcoin", "zoin", "elixir", "cryptoping", "chips", "ebtcnew", "fincoin", "martexcoin", "mao-zedong", "unity-ingot", "xios", "cryptogenic-bullion", "zennies", "fimkrypto", "luckchain", "trackr", "ixcoin", "pirl", "adshares", "internxt", "espers", "dotcoin", "eboostcoin", "altcoin-alt", "ico-openledger", "nexxus", "adzcoin", "giga-watt-token", "newyorkcoin", "gimli", "helleniccoin", "cryptocarbon", "linda", "fundyourselfnow", "life", "draftcoin", "miners-reward-token", "skincoin", "influxcoin", "bytecent", "nautiluscoin", "trezarcoin", "bitzeny", "monacocoin", "renos", "bitradio", "bowhead", "growers-international", "minereum", "nubits", "fastcoin", "megacoin", "briacoin", "rustbits", "worldcoin", "supercoin", "bata", "happycoin", "sovereign-hero", "linx", "fucktoken", "hicoin", "unify", "ufo-coin", "zetacoin", "smileycoin", "roulettetoken", "dinastycoin", "teslacoin", "kekcoin", "whalecoin", "capricoin", "netko", "insanecoin-insn", "litedoge", "sumokoin", "moin", "unbreakablecoin", "signatum", "cryptonite", "unitus", "ethereum-gold", "maxcoin", "808coin", "solaris", "fantomcoin", "ethbet", "digitalprice", "blakestar", "torcoin-tor", "digital-developers-fund", "postoken", "fujinto", "ethereum-blue", "procurrency", "sprouts", "shield-coin", "tychocoin", "zero", "billionaire-token", "altcommunity-coin", "authorship", "fuelcoin", "42-coin", "dashcoin", "canada-ecoin", "luxcoin", "gcoin", "footy-cash", "mazacoin", "dalecoin", "exchangen", "piplcoin", "britcoin", "futurexe", "denarius-dnr", "embercoin", "eot-token", "vsync-vsx", "pakcoin", "colossuscoinxt", "senderon", "jetcoin", "women", "cryptoforecast", "bitbtc", "mincoin", "icoin", "ethereum-dark", "trumpcoin", "ellaism", "bolenum", "veltor", "scorecoin", "postcoin", "i0coin", "cryptojacks", "platinumbar", "ebtc", "litebar", "atomic-coin", "wayguide", "elcoin-el", "tekcoin", "hodlcoin", "biblepay", "ecocoin", "kilocoin", "bit20", "cannation", "iethereum", "ethereumcash", "mojocoin", "campuscoin", "bitsilver", "emoneypower", "digitalcoin", "zurcoin", "prcoin", "rupaya", "coinonatx", "mineum", "bitcoin-red", "global-tour-coin", "virta-unique-coin", "bumbacoin", "cybcsec", "spacecoin", "master-swiscoin", "ammo-rewards", "bitcoinfast", "slimcoin", "asiadigicoin", "digital-rupees", "boostcoin", "coimatic-2", "roofs", "kurrent", "biteur", "ethgas", "interzone", "money", "gold-pressed-latinum", "litecoin-plus", "playercoin", "300-token", "cashcoin", "cryptoworldx-token", "vault-coin", "allsafe", "photon", "songcoin", "wild-beast-block", "impact", "milocoin", "solarflarecoin", "vaperscoin", "neurodao", "iconic", "kronecoin", "anarchistsprime", "litecred", "slevin", "luna-coin", "wexcoin", "morningstar-payments", "litecoin-ultra", "bigboobscoin", "project-x", "levoplus", "harmonycoin-hmc", "1337coin", "digital-money-bits", "falcoin", "supernet-unity", "fedoracoin", "bcap", "jinn", "arcade-token", "yashcoin", "stakecoin-stcn", "prospectors-gold", "cagecoin", "asiacoin", "vpncoin", "adelphoi", "atmos", "ethbits", "colossuscoin-v2", "pandacoin-pnd", "mergecoin", "darcrus", "real-estate-tokens", "hyperstake", "woodcoin", "inpay", "infinitecoin", "bitpark-coin", "ethereum-movie-venture", "ultracoin", "incakoin", "shadowcash", "wavesgo", "iticoin", "metalcoin", "hitcoin", "ultimate-secure-cash", "link-platform", "shorty", "russiacoin", "cryptcoin", "cream", "monster-byte", "netcoin", "kobocoin", "zccoin", "btsr", "hobonickels", "machinecoin", "starcredits", "inflationcoin", "ether-for-the-rest-of-the-world", "carboncoin", "bitbar", "blockpay", "bitstar", "noblecoin", "orbitcoin", "eternity", "anoncoin", "version", "ambercoin", "leviarcoin", "smartcoin", "btctalkcoin", "fujicoin", "deutsche-emark", "gaia", "trollcoin", "stress", "triangles", "daxxcoin", "valorbit", "ohm-wallet", "aurumcoin", "swagbucks", "shadow-token", "piggycoin", "globalcoin", "titcoin", "phoenixcoin", "kayicoin", "8bit", "kibicoin", "opal", "universe", "lanacoin", "tagcoin", "paycoin2", "etheriya", "purevidz", "bitcoin-scrypt", "nyancoin", "goodomy", "guncoin", "freicoin", "bunnycoin", "elementrem", "funcoin", "fluttercoin", "flycoin", "sacoin", "sproutsextreme", "sterlingcoin", "coin", "joulecoin", "casino", "prototanium", "the-cypherfunks", "honey", "electra", "devcoin", "lottocoin", "goldreserve", "digicube", "tittiecoin", "bolivarcoin", "cannacoin", "kushcoin", "petrodollar", "rubies", "qubitcoin", "unicoin", "ratecoin", "bigup", "virtualcoin", "newbium", "piecoin", "tigercoin", "joincoin", "ripto-bux", "francs", "revolvercoin", "truckcoin", "satoshimadness", "paycon", "idice", "bitgem", "evil-coin", "crypto", "darsek", "dollarcoin", "grantcoin", "yacoin", "jin-coin", "px", "theresa-may-coin", "evotion", "berncash", "blakecoin", "unrealcoin", "globalboost-y", "acoin", "antibitcoin", "bitcurrency", "bitgold", "chesscoin", "smoke", "wyvern", "goldblocks", "bittokens", "emerald", "swing", "goldpieces", "bottlecaps", "franko", "hempcoin-hmp", "gapcoin", "octocoin", "corgicoin", "bitz", "wmcoin", "dreamcoin", "ltbcoin", "coin2-1", "cachecoin", "leacoin", "droxne", "mtmgaming", "x-coin", "bitasean", "quazarcoin", "philosopher-stones", "o2olondoncoin", "catcoin", "aricoin", "usde", "islacoin", "argentum", "chronos", "c-bit", "sling", "parallelcoin", "independent-money-system", "firecoin", "aquariuscoin", "pascal-lite", "chancoin", "halcyon", "flaxscript", "sixeleven", "compucoin", "securecoin", "gameunits", "virtacoinplus", "sativacoin", "rimbit", "universal-currency", "macron", "vector", "beavercoin", "prime-xi", "bitquark", "icobid", "kittehcoin", "marscoin", "gpu-coin", "cypher", "tilecoin", "healthywormcoin", "das", "dibcoin", "quatloo", "tajcoin", "jewels", "sooncoin", "tattoocoin", "braincoin", "metal-music-coin", "secretcoin", "eurocoin", "marijuanacoin", "ponzicoin", "arbit", "billarycoin", "reecoin", "redcoin", "mustangcoin", "tristar-coin", "coinonat", "creatio", "uro", "nevacoin", "zayedcoin", "ronpaulcoin", "tickets", "allion", "zetamicron", "blackstar", "comet", "bitcoin-21", "bitcoin-planet", "cryptoescudo", "spots", "neuro", "mindcoin", "jio-token", "guccionecoin", "artex-coin", "popularcoin", "bipcoin", "coexistcoin", "agrolifecoin", "useless-ethereum-token", "warp", "bitcoal", "soilcoin", "hexx", "crevacoin", "globaltoken", "flavorcoin", "genstake", "pulse", "cabbage", "jobscoin", "plncoin", "steps", "eryllium", "printerium", "cthulhu-offerings", "dappster", "bowscoin", "hacker-gold", "beatcoin", "crtcoin", "benjirolls", "blazecoin", "pesobit", "orlycoin", "impulsecoin", "dt-token", "osmiumcoin", "ibank", "bios-crypto", "gamebet-coin", "zonecoin", "shilling", "tagrcoin", "kingn-coin", "ego", "ride-my-car", "letitride", "debitcoin", "fuzzballs", "gbcgoldcoin", "doubloon", "bbqcoin", "posex", "vip-tokens", "dpay", "high-voltage", "dix-asset", "dollar-online", "antilitecoin", "bnrtxcoin", "destiny", "socialcoin-socc", "chncoin", "veros", "xonecoin", "biobar", "speedcash", "rsgpcoin", "magnum", "p7coin", "sydpak", "argus", "qibuck-asset", "tradecoin-v2", "selfiecoin", "elysium", "javascript-token", "revenu", "geertcoin", "save-and-gain", "virtacoin", "nodecoin", "rawcoin2", "burstocean", "ccminer", "concoin", "wallet-builders-coin", "bitvolt", "enigma", "litebitcoin", "powercoin", "frazcoin", "lex4all", "californium", "pizzacoin", "geysercoin", "mantracoin", "swaptoken", "sojourn", "mikethemug", "digital-credits", "abncoin", "environ", "ulatech", "ebittree-coin", "future-digital-currency", "caliphcoin", "applecoin-apw", "bt1-cst", "bitcoin-gold", "nuls", "bt2-cst", "regalcoin", "yoyow", "swisscoin", "octanox", "infinity-economics", "segwit2x", "fargocoin", "firstcoin", "raiden-network-token", "techshares", "ormeus-coin", "enjin-coin", "high-gain", "tezos", "clubcoin", "lltoken", "exchange-union", "cobinhood", "gulfcoin", "innova", "grid", "storjcoin-x", "ug-token", "bitsoar", "sphre-air", "unikoin-gold", "icon", "etherparty", "everus", "aion", "natcoin", "msd", "golos-gold", "akuya-coin", "phore", "qvolta", "bitbase", "pure", "bitcoin-unlimited", "bastonet", "delphy", "bitcoin-silver", "smart-investment-fund-token", "suretly", "deuscoin", "boscoin", "international-diamond", "rasputin-online-coin", "minexcoin", "macro1", "russian-mining-coin", "atlant", "primulon", "litecoin-gold", "sigmacoin", "cartaxi-token", "corion", "rchain", "goldunioncoin", "ibtc", "starcash-network", "desire", "buzzcoin", "xenon", "eccoin", "peoplecoin", "force", "ethereum-lite", "t-coin", "etherx", "aureus", "zephyr", "farad", "alpacoin", "dutch-coin", "ergo", "granitecoin", "crystal-clear", "egold", "flypme", "chronologic", "cyder", "yellow-token", "vulcano", "sand-coin", "eltcoin", "first-bitcoin-capital", "mercury-protocol", "flash", "dfscoin", "eusd", "rupaya-old", "coupecoin", "alphabitcoinfund", "internet-of-things", "president-trump", "teslacoilcoin", "president-johnson", "minex", "wild-crypto", "stex", "blockchain-index", "ebit", "paccoin", "iquant", "cash-poker-pro", "ganjacoin", "swapcoin", "ox-fina", "regacoin", "lazaruscoin", "sync", "wa-space", "wearesatoshi", "encryptotel-eth", "landcoin", "zilbercoin", "cubits", "musiconomi", "bitcoincashscrypt", "10mtoken", "exrnchain", "etherdoge", "universalroyalcoin", "facecoin", "happy-creator-coin", "brat", "huncoin", "atmcoin", "rcoin", "terranova", "antimatter", "stronghands", "runners", "btcmoon", "adcoin", "network-token", "peacecoin", "wink", "amsterdamcoin", "9coin", "eltc", "wowecoin", "namocoin", "zengold", "ereal", "pirate-blocks", "marxcoin", "amis", "pabyosi-coin-special", "topcoin", "betacoin", "irishcoin", "turbocoin", "rublebit", "motocoin", "lepen", "wi-coin", "india-coin", "fapcoin", "bixc", "hodl-bucks", "avoncoin", "futcoin", "sakuracoin", "wowcoin", "voyacoin", "peepcoin", "shacoin", "quotient", "halloween-coin", "bitfid", "ur", "the-vegan-initiative", "x2", "edrcoin", "gaycoin", "uncoin", "bestchain", "intelligent-trading-tech", "sharkcoin", "bitok", "linkedcoin", "birds", "protean", "axiom", "blazercoin", "asiccoin", "tellurion", "fireflycoin", "bitcedi", "batcoin", "clinton", "safecoin", "frankywillcoin", "animecoin", "zsecoin", "snakeeyes", "goldmaxcoin", "quebecoin", "advanced-internet-blocks", "mavro", "digital-bullion-gold", "utacoin", "bubble", "avatarcoin", "vegascoin", "tyrocoin", "topaz", "sportscoin", "fazzcoin", "shellcoin", "cybercoin", "fonziecoin", "pinkdog", "mobilecash", "donationcoin", "moneycoin", "rabbitcoin", "royalties", "skeincoin", "yescoin", "dashs", "bitcentavo", "invisiblecoin", "xtd-coin", "xaucoin", "moneta2", "rhfcoin", "todaycoin", "pokecoin", "royalcoin", "darklisk", "flappycoin", "mmxvi", "cashme", "lathaan", "ugain", "xde-ii", "first-bitcoin", "aseancoin", "cbd-crystals", "paypeer", "golfcoin", "magnetcoin", "kashhcoin", "microcoin", "elacoin", "karmacoin", "qora", "hyper", "gameleaguecoin", "bongger", "trickycoin", "eggcoin", "dubstep", "cycling-coin", "deltacredits", "opescoin", "bitalphacoin", "psilocybin", "operand", "thecreed", "ocow", "soulcoin", "richcoin", "prismchain", "aces", "omicron", "mind-gene", "teamup", "global-business-revolution", "netbit", "axfunds", "safe-trade-coin", "neptune-classic", "teracoin", "tattoocoin-limited", "picoin", "aidos-kuneen", "cheapcoin", "excelcoin", "kexcoin", "dynamiccoin", "miyucoin", "infchain", "coimatic-3" };
        //Optional Proxy
        private WebProxy _Proxy = new WebProxy();
        //RequestTypes
        private enum RequestType
        {
            Coin,
            Global
        }

        #region Public Functions

        /// <summary>
        /// RequestCoin can request the statistics of a specific coin
        /// </summary>
        /// <param name="CoinType">The type of the coin</param>
        /// <param name="Currency">Optional currency conversion</param>
        /// <returns>Coin-Object</returns>
        public Coin RequestCoin(CoinType CoinType, Currency Currency = Currency.NONE)
        {
            Coin[] Result = StartCoinRequest(0, 100, Currency, _CoinNames[(int)CoinType]);

            if(Result.Length == 1)
            {
                return Result[0];
            }
            else
            {
                throw new ParsingFailedException();
            }
        }

        /// <summary>
        /// RequestAll can request the statistics of all coins. It is possible to set a limit. Results are sort by their ranking.
        /// </summary>
        /// <param name="Start">Optional Startvalue (Default 0). Choosing a too high value will result in an exception.</param>
        /// <param name="Limit">Optional Limit (Default 100). 0 = no limit</param>
        /// <param name="Currency">Optional currency conversion</param>
        /// <returns>Coin-Object-Array</returns>
        public Coin[] RequestAll(int Start = 0, int Limit = 100, Currency Currency = Currency.NONE)
        {
            return StartCoinRequest(Start, Limit, Currency);
        }


        public GlobalInformation RequestGlobalInformation(Currency Currency = Currency.NONE)
        {
            return (GlobalInformation)RequestAPI(Currency != Currency.NONE ? "?convert=" + Currency.ToString() : "", RequestType.Global);
        }

        /// <summary>
        /// Set a proxy for communitcation throughs a tunnel
        /// </summary>
        /// <param name="Proxy">WebProvy object</param>
        public void UseProxy(WebProxy Proxy)
        {
            _Proxy = Proxy;
        }

        #endregion

        #region API-Functions
        private Coin[] StartCoinRequest(int Start = 0, int Limit = 100, Currency Currency = Currency.NONE, string Coin = null)
        {
            List<string> URLParameters = new List<string>();

            if (Start > 0)
            {
                URLParameters.Add("start=" + Start);
            }

            if (Limit != 100 && Limit >= 0)
            {
                URLParameters.Add("limit=" + Limit);
            }

            if (Currency != Currency.NONE)
            {
                URLParameters.Add("convert=" + Currency.ToString());
            }

            return (Coin[])RequestAPI((Coin != null ? Coin + "/" : "") + (URLParameters.Count > 0 ? "?" : "") + String.Join("&", URLParameters.ToArray()), RequestType.Coin);
        }

        private object RequestAPI(string Parameters, RequestType RequestType = RequestType.Coin)
        {
            WebClient Client = new WebClient();
            Client.Proxy = _Proxy;
            string raw = null;

            try
            {
                raw = Encoding.UTF8.GetString(Client.DownloadData(API_URL + (RequestType == RequestType.Coin ? "ticker/" : "global/") + Parameters));
            }
            catch
            {
                throw new InvalidRequestException("Server returned invalid request", API_URL + Parameters);
            }

            if(RequestType == RequestType.Coin)
            {
                return ParseAPICoinResult(raw);
            }
            else
            {
                return new GlobalInformation(raw);
            }
        }

        private Coin[] ParseAPICoinResult(string Result)
        {
            List<Coin> Currencies = new List<Coin>();

            Regex r = new Regex(@"{(?<currency>[^}]+)}");

            MatchCollection mc = r.Matches(Result);

            foreach(Match m in mc)
            {
                if(!m.Groups["currency"].ToString().Contains("id not found"))
                {
                    Currencies.Add(new Coin(m.Groups["currency"].ToString()));
                }
            }

            return Currencies.ToArray();
        }

        #endregion
    }
}
