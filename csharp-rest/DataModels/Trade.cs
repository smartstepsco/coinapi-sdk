﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
    public class Trade {
        public string symbol_id { get; set; }
        public DateTime time_exchange { get; set; }
        public DateTime time_coinapi { get; set; }
        public string uuid { get; set; }
        public decimal price { get; set; }
        public decimal size { get; set; }
        public string taker_side { get; set; }
    }

}
