
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
    class CoinApi {
        private string apikey;
        private static string WebUrl = "https://rest.coinapi.io";// "https://rest-test.coinapi.io";
        public CoinApi(string apikey) {
            this.apikey = apikey;
        }

        public List<Exchange> exchanges() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);


                   
                    var responseFromServer = client.GetAsync(WebUrl + "/v1/exchanges").Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Exchange>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }


        public List<Symbol> symbols() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);



                    var responseFromServer = client.GetAsync(WebUrl + "/v1/symbols").Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Symbol>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }


        public List<Exchangerate> exchangerates(string baseId,string quoteId,DateTime time) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url =string.Format( "/v1/exchangerate/{0}/{1}?time={2}",baseId,quoteId,time.ToString("yyyy-MM-dd HH:ss:mm"));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Exchangerate>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<ExchangeCurrentrate> exchangerates(string baseId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/exchangerate/{asset_id_base}", baseId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<ExchangeCurrentrate>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Period> periods() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);



                    var responseFromServer = client.GetAsync(WebUrl + "/v1/ohlcv/periods").Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Period>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }


        public List<OHLCV> ohlcv_latest_data(string symbolId, string periodId, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/ohlcv/{0}/latest?period_id={1}&limit={2}", symbolId, periodId, limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<OHLCV>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<OHLCV> ohlcv_historical_data(string symbolId, string periodId, DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/ohlcv/{0}/history?period_id={1}&time_start={2}&time_end={3}&limit={4}", symbolId, periodId, start.ToString("yyyy-MM-dd HH:ss:mm"), end.ToString("yyyy-MM-dd HH:ss:mm"), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<OHLCV>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }


        public List<Trade> trades( int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/trades/latest?limit={0}", limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }


        public List<Trade> trades(string symbolId, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/trades/{0}/latest?limit={1}", symbolId, limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Trade> trades(string symbolId, DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/trades/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString("yyyy-MM-dd HH:ss:mm"), end.ToString("yyyy-MM-dd HH:ss:mm"), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Quote> quotes() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = "/v1/quotes/current";


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Quote> quotes(string symbolId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/current", symbolId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }


        public List<Quote> quotes_last_data(int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/latest?limit={0}", limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Quote> quotes_last_data(string symbolId, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/latest?limit={1}", symbolId, limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Quote> quotes_historical_data(string symbolId, DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString("yyyy-MM-dd HH:ss:mm"), end.ToString("yyyy-MM-dd HH:ss:mm"), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Orderbook> orderbooks() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = "/v1/orderbooks/current";


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Orderbook> orderbooks(string symbolId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/current", symbolId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Orderbook> orderbooks_last_data(string symbolId,int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/latest?limit={1}", symbolId, limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Orderbook> orderbooks_historical_data(string symbolId, DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString("yyyy-MM-dd HH:ss:mm"), end.ToString("yyyy-MM-dd HH:ss:mm"), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Twitter> twitter_last_data(int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/twitter/latest?limit={0}", limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Twitter>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Twitter> twitter_historical_data( DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/twitter/history?time_start={0}&time_end={1}&limit={2}", start.ToString("yyyy-MM-dd HH:ss:mm"), end.ToString("yyyy-MM-dd HH:ss:mm"), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Twitter>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
    }

    #region Classes
    public class Twitter {
        public long? in_reply_to_status_id { get; set; }
        public string text { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public bool truncated { get; set; }
        public bool retweeted { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public string source { get; set; }
        public string created_at { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public object geo { get; set; }
        public int retweet_count { get; set; }
        public object contributors { get; set; }
        public string id_str { get; set; }
        public Entities entities { get; set; }
        public object place { get; set; }
        public object coordinates { get; set; }
        public User user { get; set; }
        public int? in_reply_to_user_id { get; set; }
        public long id { get; set; }
        public bool favorited { get; set; }
        public bool possibly_sensitive { get; set; }
    }

    public class Entities {
        public Hashtag[] hashtags { get; set; }
        public User_Mentions[] user_mentions { get; set; }
        public Url[] urls { get; set; }
    }

    public class Hashtag {
        public string text { get; set; }
        public int[] indices { get; set; }
    }

    public class User_Mentions {
        public int[] indices { get; set; }
        public string name { get; set; }
        public string id_str { get; set; }
        public int id { get; set; }
        public string screen_name { get; set; }
    }

    public class Url {
        public int[] indices { get; set; }
        public string display_url { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
    }

    public class User {
        public object following { get; set; }
        public object notifications { get; set; }
        public bool profile_background_tile { get; set; }
        public bool contributors_enabled { get; set; }
        public bool verified { get; set; }
        public int friends_count { get; set; }
        public bool is_translator { get; set; }
        public string profile_background_image_url_https { get; set; }
        public string profile_link_color { get; set; }
        public int listed_count { get; set; }
        public string profile_sidebar_border_color { get; set; }
        public string profile_image_url { get; set; }
        public string description { get; set; }
        public int favourites_count { get; set; }
        public string created_at { get; set; }
        public bool default_profile { get; set; }
        public bool profile_use_background_image { get; set; }
        public bool show_all_inline_media { get; set; }
        public bool geo_enabled { get; set; }
        public string time_zone { get; set; }
        public string profile_background_color { get; set; }
        public bool default_profile_image { get; set; }
        public string profile_background_image_url { get; set; }
        public int followers_count { get; set; }
        public bool _protected { get; set; }
        public string url { get; set; }
        public string profile_image_url_https { get; set; }
        public string id_str { get; set; }
        public string lang { get; set; }
        public string name { get; set; }
        public int statuses_count { get; set; }
        public string profile_text_color { get; set; }
        public int id { get; set; }
        public object follow_request_sent { get; set; }
        public int utc_offset { get; set; }
        public string profile_sidebar_fill_color { get; set; }
        public string location { get; set; }
        public string screen_name { get; set; }
    }



    public class Orderbook {
        public string symbol_id { get; set; }
        public string time_exchange { get; set; }
        public string time_coinapi { get; set; }
        public Ask[] asks { get; set; }
        public Bid[] bids { get; set; }
    }

    public class Ask {
        public decimal price { get; set; }
        public int size { get; set; }
    }

    public class Bid {
        public decimal price { get; set; }
        public int size { get; set; }
    }





    public class Quote {
        public string symbol_id { get; set; }
        public string time_exchange { get; set; }
        public string time_coinapi { get; set; }
        public decimal ask_price { get; set; }
        public int ask_size { get; set; }
        public int bid_price { get; set; }
        public int bid_size { get; set; }
        public Trade last_trade { get; set; }
    }





    public class Trade {
        public string symbol_id { get; set; }
        public DateTime time_exchange { get; set; }
        public DateTime time_coinapi { get; set; }
        public string uuid { get; set; }
        public decimal price { get; set; }
        public decimal size { get; set; }
        public string taker_side { get; set; }
    }

    public class OHLCV {
        public DateTime time_period_start { get; set; }
        public DateTime time_period_end { get; set; }
        public DateTime time_open { get; set; }
        public DateTime time_close { get; set; }
        public decimal price_open { get; set; }
        public decimal price_high { get; set; }
        public decimal price_low { get; set; }
        public decimal price_close { get; set; }
        public decimal volume_traded { get; set; }
        public int trades_count { get; set; }
    }


    public class Period {
        public string period_id { get; set; }
        public int length_seconds { get; set; }
        public int length_months { get; set; }
        public int unit_count { get; set; }
        public string unit_name { get; set; }
        public string display_name { get; set; }
    }


    public class ExchangeCurrentrate {
        public string asset_id_base { get; set; }
        public Rate[] rates { get; set; }
    }

    public class Rate {
        public DateTime time { get; set; }
        public string asset_id_quote { get; set; }
        public decimal rate { get; set; }
    }


    public class Exchangerate {
        public DateTime time { get; set; }
        public string asset_id_base { get; set; }
        public string asset_id_quote { get; set; }
        public decimal rate { get; set; }
    }


    public class Symbol {
        public string symbol_id { get; set; }
        public string exchange_id { get; set; }
        public string symbol_type { get; set; }
        public bool option_type_is_call { get; set; }
        public decimal option_strike_price { get; set; }
        public decimal option_contract_unit { get; set; }
        public string option_exercise_style { get; set; }
        public DateTime option_expiration_time { get; set; }
        public string asset_id_base { get; set; }
        public string asset_id_quote { get; set; }
    }

    public class Exchange {
        public string exchange_id { get; set; }
        public string website { get; set; }
        public string name { get; set; }
    }
    #endregion
}
