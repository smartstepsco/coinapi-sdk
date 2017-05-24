
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
        private string dateFormat = "yyyy-MM-ddTHH:mm:ss.fff";
        private static string WebUrl = "https://rest.coinapi.io";// "https://rest-test.coinapi.io";
        public CoinApi(string apikey) {
            this.apikey = apikey;
        }

        public List<Exchange> Metadata_list_exchanges() {
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

        public List<Asset> Metadata_list_assets() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);



                    var responseFromServer = client.GetAsync(WebUrl + "/v1/assets").Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Asset>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Symbol> Metadata_list_symbols() {
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
        
        public Exchangerate Exchange_rates_get_specific_rate(string baseId,string quoteId,DateTime time) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url =string.Format( "/v1/exchangerate/{0}/{1}?time={2}",baseId,quoteId,time.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<Exchangerate>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public Exchangerate Exchange_rates_get_specific_rate(string baseId, string quoteId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/exchangerate/{0}/{1}", baseId, quoteId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<Exchangerate>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public ExchangeCurrentrate Exchange_rates_get_all_current_rates(string baseId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/exchangerate/{0}", baseId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<ExchangeCurrentrate>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Period> Ohlcv_list_all_periods() {
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


        public List<OHLCV> Ohlcv_latest_data(string symbolId, string periodId, int limit) {
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
        public List<OHLCV> Ohlcv_latest_data(string symbolId, string periodId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/ohlcv/{0}/latest?period_id={1}", symbolId, periodId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<OHLCV>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<OHLCV> Ohlcv_historical_data(string symbolId, string periodId, DateTime start, DateTime end, int limit) {
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
        public List<OHLCV> Ohlcv_historical_data(string symbolId, string periodId, DateTime start, DateTime end) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/ohlcv/{0}/history?period_id={1}&time_start={2}&time_end={3}", symbolId, periodId, start.ToString(dateFormat), end.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<OHLCV>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<OHLCV> Ohlcv_historical_data(string symbolId, string periodId, DateTime start,  int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/ohlcv/{0}/history?period_id={1}&time_start={2}&limit={3}", symbolId, periodId, start.ToString(dateFormat), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<OHLCV>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<OHLCV> Ohlcv_historical_data(string symbolId, string periodId, DateTime start) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/ohlcv/{0}/history?period_id={1}&time_start={2}", symbolId, periodId, start.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<OHLCV>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Trade> Trades_latest_data_all() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = "/v1/trades/latest";


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Trade> Trades_latest_data_all( int limit) {
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


        public List<Trade> Trades_latest_data_symbol(string symbolId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/trades/{0}/latest", symbolId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Trade> Trades_latest_data_symbol(string symbolId, int limit) {
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

        public List<Trade> Trades_historical_data(string symbolId, DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/trades/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Trade> Trades_historical_data(string symbolId, DateTime start) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/trades/{0}/history?time_start={1}", symbolId, start.ToString(dateFormat) );


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Trade> Trades_historical_data(string symbolId, DateTime start, DateTime end) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/trades/{0}/history?time_start={1}&time_end={2}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Trade> Trades_historical_data(string symbolId, DateTime start,  int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/trades/{0}/history?time_start={1}&limit={2}", symbolId, start.ToString(dateFormat), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Trade>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Quote> Quotes_current_data_all() {
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

        public Quote Quotes_current_data_symbol(string symbolId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/current", symbolId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<Quote>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Quote> Quotes_latest_data_all() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = "/v1/quotes/latest";


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Quote> Quotes_latest_data_all(int limit) {
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

        public List<Quote> Quotes_latest_data_symbol(string symbolId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/latest", symbolId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Quote> Quotes_latest_data_symbol(string symbolId, int limit) {
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

        public List<Quote> Quotes_historical_data(string symbolId, DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Quote> Quotes_historical_data(string symbolId, DateTime start) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/history?time_start={1}", symbolId, start.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Quote> Quotes_historical_data(string symbolId, DateTime start, DateTime end) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/history?time_start={1}&time_end={2}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Quote> Quotes_historical_data(string symbolId, DateTime start, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/quotes/{0}/history?time_start={1}&limit={2}", symbolId, start.ToString(dateFormat), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Quote>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }



        public List<Orderbook> Orderbooks_current_data_all() {
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

        public Orderbook Orderbooks_current_data_symbol(string symbolId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/current", symbolId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<Orderbook>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Orderbook> Orderbooks_last_data(string symbolId,int limit) {
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
        public List<Orderbook> Orderbooks_last_data(string symbolId) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/latest", symbolId);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Orderbook> Orderbooks_historical_data(string symbolId, DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Orderbook> Orderbooks_historical_data(string symbolId, DateTime start) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}", symbolId, start.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Orderbook> Orderbooks_historical_data(string symbolId, DateTime start, DateTime end) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}&time_end={2}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Orderbook> Orderbooks_historical_data(string symbolId, DateTime start,  int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}&limit={2}", symbolId, start.ToString(dateFormat), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Orderbook>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Twitter> Twitter_last_data(int limit) {
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
        public List<Twitter> Twitter_last_data() {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = "/v1/twitter/latest";


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Twitter>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Twitter> Twitter_historical_data( DateTime start, DateTime end, int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/twitter/history?time_start={0}&time_end={1}&limit={2}", start.ToString(dateFormat), end.ToString(dateFormat), limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Twitter>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Twitter> Twitter_historical_data(DateTime start) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/twitter/history?time_start={0}", start.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Twitter>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Twitter> Twitter_historical_data(DateTime start, DateTime end) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/twitter/history?time_start={0}&time_end={1}", start.ToString(dateFormat), end.ToString(dateFormat));


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Twitter>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
        public List<Twitter> Twitter_historical_data(DateTime start,int limit) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {


                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);
                    var url = string.Format("/v1/twitter/history?time_start={0}&limit={1}", start.ToString(dateFormat),limit);


                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<List<Twitter>>(responseFromServer);
                    return dataFromServer;
                }
            }
        }
    }

}
