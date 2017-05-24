using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
    public class Quote {
        public string symbol_id { get; set; }
        public string time_exchange { get; set; }
        public string time_coinapi { get; set; }
        public decimal ask_price { get; set; }
        public decimal ask_size { get; set; }
        public decimal bid_price { get; set; }
        public decimal bid_size { get; set; }
        public Trade last_trade { get; set; }
    }
}
