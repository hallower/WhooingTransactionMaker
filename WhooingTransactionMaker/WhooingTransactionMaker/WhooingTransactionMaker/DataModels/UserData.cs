using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.Helpers;

namespace WhooingTransactionMaker.DataModels
{
    public class UserData
    {
        /*
         * "user_id" : 27,
				"username" : "Helloman",
				"last_ip" : "192.168.0.1",
				"last_login_timestamp" : 1322448931,
				"created_timestamp" : 1321448931,
				"modified_timestamp" : 1321448931,
				"language" : "ko",
				"level" : "1",
				"expire" : 1321448931,
				"timezone" : "Asia/Seoul",
				"currency" : "KRW",
				"country" : "KR",
				"image_url" : "https://s3-ap-northeast-1.amazonaws.com/whooingprofile/p27.jpg",
				"mileage" : 230
         */

        [JsonProperty("user_id")]
        public string ID { get; set; }

        [JsonProperty("username")]
        public string Name { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("mileage")]
        public double Mileage { get; set; }
    }
}
