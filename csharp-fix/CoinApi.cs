
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace csharp_fix {
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
}
