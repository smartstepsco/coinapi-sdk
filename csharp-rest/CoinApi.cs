
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

        public T GetData<T>(string url) {
            using (HttpClientHandler handler = new HttpClientHandler()) {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpClient client = new HttpClient(handler, false)) {

                    client.DefaultRequestHeaders.Add("X-CoinAPI-Key", apikey);

                    var responseFromServer = client.GetAsync(WebUrl + url).Result.Content.ReadAsStringAsync().Result;
                    var dataFromServer = JsonConvert.DeserializeObject<T>(responseFromServer);
                    return dataFromServer;
                }
            }
        }

        public List<Exchange> Metadata_list_exchanges() {
            return GetData<List<Exchange>>("/v1/exchanges");
        }

        public List<Asset> Metadata_list_assets() {
            return GetData<List<Asset>>("/v1/assets");
        }
        public List<Symbol> Metadata_list_symbols() {
            return GetData<List<Symbol>>("/v1/symbols");
        }

        public Exchangerate Exchange_rates_get_specific_rate(string baseId, string quoteId, DateTime time) {
            var url = string.Format("/v1/exchangerate/{0}/{1}?time={2}", baseId, quoteId, time.ToString(dateFormat));
            return GetData<Exchangerate>(url);
        }
        public Exchangerate Exchange_rates_get_specific_rate(string baseId, string quoteId) {
            var url = string.Format("/v1/exchangerate/{0}/{1}", baseId, quoteId);
            return GetData<Exchangerate>(url);
        }

        public ExchangeCurrentrate Exchange_rates_get_all_current_rates(string baseId) {
            var url = string.Format("/v1/exchangerate/{0}", baseId);
            return GetData<ExchangeCurrentrate>(url);
        }

        public List<Period> Ohlcv_list_all_periods() {
            var url = "/v1/ohlcv/periods";
            return GetData<List<Period>>(url);
        }


        public List<OHLCV> Ohlcv_latest_data(string symbolId, string periodId, int limit) {
            var url = string.Format("/v1/ohlcv/{0}/latest?period_id={1}&limit={2}", symbolId, periodId, limit);
            return GetData<List<OHLCV>>(url);
        }
        public List<OHLCV> Ohlcv_latest_data(string symbolId, string periodId) {
            var url = string.Format("/v1/ohlcv/{0}/latest?period_id={1}", symbolId, periodId);
            return GetData<List<OHLCV>>(url);
        }

        public List<OHLCV> Ohlcv_historical_data(string symbolId, string periodId, DateTime start, DateTime end, int limit) {
            var url = string.Format("/v1/ohlcv/{0}/history?period_id={1}&time_start={2}&time_end={3}&limit={4}", symbolId, periodId, start.ToString("yyyy-MM-dd HH:ss:mm"), end.ToString("yyyy-MM-dd HH:ss:mm"), limit);
            return GetData<List<OHLCV>>(url);
        }
        public List<OHLCV> Ohlcv_historical_data(string symbolId, string periodId, DateTime start, DateTime end) {
            var url = string.Format("/v1/ohlcv/{0}/history?period_id={1}&time_start={2}&time_end={3}", symbolId, periodId, start.ToString(dateFormat), end.ToString(dateFormat));
            return GetData<List<OHLCV>>(url);
        }
        public List<OHLCV> Ohlcv_historical_data(string symbolId, string periodId, DateTime start, int limit) {
            var url = string.Format("/v1/ohlcv/{0}/history?period_id={1}&time_start={2}&limit={3}", symbolId, periodId, start.ToString(dateFormat), limit);
            return GetData<List<OHLCV>>(url);
        }
        public List<OHLCV> Ohlcv_historical_data(string symbolId, string periodId, DateTime start) {
            var url = string.Format("/v1/ohlcv/{0}/history?period_id={1}&time_start={2}", symbolId, periodId, start.ToString(dateFormat));
            return GetData<List<OHLCV>>(url);
        }

        public List<Trade> Trades_latest_data_all() {
            var url = "/v1/trades/latest";
            return GetData<List<Trade>>(url);
        }
        public List<Trade> Trades_latest_data_all(int limit) {
            var url = string.Format("/v1/trades/latest?limit={0}", limit);
            return GetData<List<Trade>>(url);
        }


        public List<Trade> Trades_latest_data_symbol(string symbolId) {
            var url = string.Format("/v1/trades/{0}/latest", symbolId);
            return GetData<List<Trade>>(url);
        }
        public List<Trade> Trades_latest_data_symbol(string symbolId, int limit) {
            var url = string.Format("/v1/trades/{0}/latest?limit={1}", symbolId, limit);
            return GetData<List<Trade>>(url);
        }

        public List<Trade> Trades_historical_data(string symbolId, DateTime start, DateTime end, int limit) {
            var url = string.Format("/v1/trades/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat), limit);
            return GetData<List<Trade>>(url);
        }
        public List<Trade> Trades_historical_data(string symbolId, DateTime start) {
            var url = string.Format("/v1/trades/{0}/history?time_start={1}", symbolId, start.ToString(dateFormat));
            return GetData<List<Trade>>(url);
        }
        public List<Trade> Trades_historical_data(string symbolId, DateTime start, DateTime end) {
            var url = string.Format("/v1/trades/{0}/history?time_start={1}&time_end={2}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat));
            return GetData<List<Trade>>(url);
        }
        public List<Trade> Trades_historical_data(string symbolId, DateTime start, int limit) {
            var url = string.Format("/v1/trades/{0}/history?time_start={1}&limit={2}", symbolId, start.ToString(dateFormat), limit);
            return GetData<List<Trade>>(url);
        }

        public List<Quote> Quotes_current_data_all() {
            var url = "/v1/quotes/current";
            return GetData<List<Quote>>(url);
        }

        public Quote Quotes_current_data_symbol(string symbolId) {
            var url = string.Format("/v1/quotes/{0}/current", symbolId);
            return GetData<Quote>(url);
        }

        public List<Quote> Quotes_latest_data_all() {
            var url = "/v1/quotes/latest";
            return GetData<List<Quote>>(url);
        }
        public List<Quote> Quotes_latest_data_all(int limit) {
            var url = string.Format("/v1/quotes/latest?limit={0}", limit);
            return GetData<List<Quote>>(url);
        }

        public List<Quote> Quotes_latest_data_symbol(string symbolId) {
            var url = string.Format("/v1/quotes/{0}/latest", symbolId);
            return GetData<List<Quote>>(url);
        }
        public List<Quote> Quotes_latest_data_symbol(string symbolId, int limit) {
            var url = string.Format("/v1/quotes/{0}/latest?limit={1}", symbolId, limit);
            return GetData<List<Quote>>(url);
        }

        public List<Quote> Quotes_historical_data(string symbolId, DateTime start, DateTime end, int limit) {
            var url = string.Format("/v1/quotes/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat), limit);
            return GetData<List<Quote>>(url);

        }
        public List<Quote> Quotes_historical_data(string symbolId, DateTime start) {
            var url = string.Format("/v1/quotes/{0}/history?time_start={1}", symbolId, start.ToString(dateFormat));
            return GetData<List<Quote>>(url);
        }
        public List<Quote> Quotes_historical_data(string symbolId, DateTime start, DateTime end) {
            var url = string.Format("/v1/quotes/{0}/history?time_start={1}&time_end={2}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat));
            return GetData<List<Quote>>(url);
        }
        public List<Quote> Quotes_historical_data(string symbolId, DateTime start, int limit) {
            var url = string.Format("/v1/quotes/{0}/history?time_start={1}&limit={2}", symbolId, start.ToString(dateFormat), limit);
            return GetData<List<Quote>>(url);

        }
        public List<Orderbook> Orderbooks_current_data_all() {
            var url = "/v1/orderbooks/current";
            return GetData<List<Orderbook>>(url);
        }

        public Orderbook Orderbooks_current_data_symbol(string symbolId) {
            var url = string.Format("/v1/orderbooks/{0}/current", symbolId);
            return GetData<Orderbook>(url);
        }

        public List<Orderbook> Orderbooks_last_data(string symbolId, int limit) {
            var url = string.Format("/v1/orderbooks/{0}/latest?limit={1}", symbolId, limit);
            return GetData<List<Orderbook>>(url);
        }
        public List<Orderbook> Orderbooks_last_data(string symbolId) {
            var url = string.Format("/v1/orderbooks/{0}/latest", symbolId);
            return GetData<List<Orderbook>>(url);
        }

        public List<Orderbook> Orderbooks_historical_data(string symbolId, DateTime start, DateTime end, int limit) {
            var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}&time_end={2}&limit={3}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat), limit);
            return GetData<List<Orderbook>>(url);
        }
        public List<Orderbook> Orderbooks_historical_data(string symbolId, DateTime start) {
            var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}", symbolId, start.ToString(dateFormat));
            return GetData<List<Orderbook>>(url);
        }
        public List<Orderbook> Orderbooks_historical_data(string symbolId, DateTime start, DateTime end) {
            var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}&time_end={2}", symbolId, start.ToString(dateFormat), end.ToString(dateFormat));
            return GetData<List<Orderbook>>(url);
        }
        public List<Orderbook> Orderbooks_historical_data(string symbolId, DateTime start, int limit) {
            var url = string.Format("/v1/orderbooks/{0}/history?time_start={1}&limit={2}", symbolId, start.ToString(dateFormat), limit);
            return GetData<List<Orderbook>>(url);
        }
        public List<Twitter> Twitter_last_data(int limit) {
            var url = string.Format("/v1/twitter/latest?limit={0}", limit);
            return GetData<List<Twitter>>(url);
        }
        public List<Twitter> Twitter_last_data() {
            var url = "/v1/twitter/latest";
            return GetData<List<Twitter>>(url);
        }
        public List<Twitter> Twitter_historical_data(DateTime start, DateTime end, int limit) {
            var url = string.Format("/v1/twitter/history?time_start={0}&time_end={1}&limit={2}", start.ToString(dateFormat), end.ToString(dateFormat), limit);
            return GetData<List<Twitter>>(url);
        }
        public List<Twitter> Twitter_historical_data(DateTime start) {
            var url = string.Format("/v1/twitter/history?time_start={0}", start.ToString(dateFormat));
            return GetData<List<Twitter>>(url);
        }
        public List<Twitter> Twitter_historical_data(DateTime start, DateTime end) {
            var url = string.Format("/v1/twitter/history?time_start={0}&time_end={1}", start.ToString(dateFormat), end.ToString(dateFormat));
            return GetData<List<Twitter>>(url);
        }
        public List<Twitter> Twitter_historical_data(DateTime start, int limit) {
            var url = string.Format("/v1/twitter/history?time_start={0}&limit={1}", start.ToString(dateFormat), limit);
            return GetData<List<Twitter>>(url);
        }
    }

}
