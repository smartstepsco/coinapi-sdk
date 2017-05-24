using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
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
}
