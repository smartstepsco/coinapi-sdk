using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_rest {
    public class Twitter {
        public long? in_reply_to_status_id { get; set; }
        public string text { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public bool truncated { get; set; }
        public bool retweeted { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public string source { get; set; }
        public string created_at { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public object geo { get; set; }
        public int retweet_count { get; set; }
        public object contributors { get; set; }
        public string id_str { get; set; }
        public Entities entities { get; set; }
        public object place { get; set; }
        public object coordinates { get; set; }
        public User user { get; set; }
        public int? in_reply_to_user_id { get; set; }
        public long id { get; set; }
        public bool favorited { get; set; }
        public bool possibly_sensitive { get; set; }
    }
}
