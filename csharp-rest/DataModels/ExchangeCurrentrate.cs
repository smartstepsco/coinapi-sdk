using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
    public class ExchangeCurrentrate {
        public string asset_id_base { get; set; }
        public Rate[] rates { get; set; }
    }
}
