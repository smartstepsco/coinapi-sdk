using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
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
}
