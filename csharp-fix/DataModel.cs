using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_fix {
    class DataModel {



    }


    

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

    public class Entities {
        public Hashtag[] hashtags { get; set; }
        public User_Mentions[] user_mentions { get; set; }
        public Url[] urls { get; set; }
    }

    public class Hashtag {
        public string text { get; set; }
        public int[] indices { get; set; }
    }

    public class User_Mentions {
        public int[] indices { get; set; }
        public string name { get; set; }
        public string id_str { get; set; }
        public int id { get; set; }
        public string screen_name { get; set; }
    }

    public class Url {
        public int[] indices { get; set; }
        public string display_url { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
    }

    public class User {
        public object following { get; set; }
        public object notifications { get; set; }
        public bool profile_background_tile { get; set; }
        public bool contributors_enabled { get; set; }
        public bool verified { get; set; }
        public int friends_count { get; set; }
        public bool is_translator { get; set; }
        public string profile_background_image_url_https { get; set; }
        public string profile_link_color { get; set; }
        public int listed_count { get; set; }
        public string profile_sidebar_border_color { get; set; }
        public string profile_image_url { get; set; }
        public string description { get; set; }
        public int favourites_count { get; set; }
        public string created_at { get; set; }
        public bool default_profile { get; set; }
        public bool profile_use_background_image { get; set; }
        public bool show_all_inline_media { get; set; }
        public bool geo_enabled { get; set; }
        public string time_zone { get; set; }
        public string profile_background_color { get; set; }
        public bool default_profile_image { get; set; }
        public string profile_background_image_url { get; set; }
        public int followers_count { get; set; }
        public bool _protected { get; set; }
        public string url { get; set; }
        public string profile_image_url_https { get; set; }
        public string id_str { get; set; }
        public string lang { get; set; }
        public string name { get; set; }
        public int statuses_count { get; set; }
        public string profile_text_color { get; set; }
        public int id { get; set; }
        public object follow_request_sent { get; set; }
        public int utc_offset { get; set; }
        public string profile_sidebar_fill_color { get; set; }
        public string location { get; set; }
        public string screen_name { get; set; }
    }



    public class Orderbook {
        public string symbol_id { get; set; }
        public string time_exchange { get; set; }
        public string time_coinapi { get; set; }
        public Ask[] asks { get; set; }
        public Bid[] bids { get; set; }
    }

    public class Ask {
        public float price { get; set; }
        public int size { get; set; }
    }

    public class Bid {
        public float price { get; set; }
        public int size { get; set; }
    }





    public class Quote {
        public string symbol_id { get; set; }
        public string time_exchange { get; set; }
        public string time_coinapi { get; set; }
        public float ask_price { get; set; }
        public int ask_size { get; set; }
        public int bid_price { get; set; }
        public int bid_size { get; set; }
        public Trade last_trade { get; set; }
    }





    public class Trade {
        public string symbol_id { get; set; }
        public DateTime time_exchange { get; set; }
        public DateTime time_coinapi { get; set; }
        public string uuid { get; set; }
        public float price { get; set; }
        public float size { get; set; }
        public string taker_side { get; set; }
    }

    public class OHLCV {
        public DateTime time_period_start { get; set; }
        public DateTime time_period_end { get; set; }
        public DateTime time_open { get; set; }
        public DateTime time_close { get; set; }
        public float price_open { get; set; }
        public float price_high { get; set; }
        public float price_low { get; set; }
        public float price_close { get; set; }
        public float volume_traded { get; set; }
        public int trades_count { get; set; }
    }


    public class Period {
        public string period_id { get; set; }
        public int length_seconds { get; set; }
        public int length_months { get; set; }
        public int unit_count { get; set; }
        public string unit_name { get; set; }
        public string display_name { get; set; }
    }


    public class ExchangeCurrentrate {
        public string asset_id_base { get; set; }
        public Rate[] rates { get; set; }
    }

    public class Rate {
        public DateTime time { get; set; }
        public string asset_id_quote { get; set; }
        public float rate { get; set; }
    }


    public class Exchangerate {
        public DateTime time { get; set; }
        public string asset_id_base { get; set; }
        public string asset_id_quote { get; set; }
        public float rate { get; set; }
    }


    public class Symbol {
        public string symbol_id { get; set; }
        public string exchange_id { get; set; }
        public string symbol_type { get; set; }
        public bool option_type_is_call { get; set; }
        public float option_strike_price { get; set; }
        public float option_contract_unit { get; set; }
        public string option_exercise_style { get; set; }
        public DateTime option_expiration_time { get; set; }
        public string asset_id_base { get; set; }
        public string asset_id_quote { get; set; }
    }

    public class Exchange {
        public string exchange_id { get; set; }
        public string website { get; set; }
        public string name { get; set; }
    }
}
