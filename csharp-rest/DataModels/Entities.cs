using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
    public class Entities {
        public Hashtag[] hashtags { get; set; }
        public User_Mentions[] user_mentions { get; set; }
        public Url[] urls { get; set; }
    }
}
