using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
    class Program {
        static void Main(string[] args) {
            new CoinApi("73034021-0EBC-493D-8A00-E0F138111F41").twitter_last_data(5);

        }
    }
}
