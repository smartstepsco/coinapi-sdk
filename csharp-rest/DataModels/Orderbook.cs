using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
    public class Orderbook {
        public string symbol_id { get; set; }
        public string time_exchange { get; set; }
        public string time_coinapi { get; set; }
        public Ask[] asks { get; set; }
        public Bid[] bids { get; set; }
    }
}
