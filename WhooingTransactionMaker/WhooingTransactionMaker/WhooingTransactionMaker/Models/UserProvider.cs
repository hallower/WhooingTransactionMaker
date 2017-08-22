using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.DataModels;

namespace WhooingTransactionMaker.Models
{
    public sealed class UserProvider
    {
        private static readonly string urlReadUser = "/api/user.json";

        public UserData OwnerData { get; private set; }

        public UserProvider()
        {
        }

        public async Task SetOwnerInfo()
        {
            OwnerData = await Read();
        }

        public async Task<UserData> Read()
        {
            /*
             * {
			"code" : 200,
			"message" : "",
			"error_parameters" : {},
			"rest_of_api" : 4988,
			"results" : {
				"user_id" : 27,
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
			}
		}    */

            var result = await RESTInvoker.Invoke<UserData>(RestMethod.GET, urlReadUser, string.Empty);
            if (result == null ||
                result.Results == null)
            {
                return null;
            }

            return result.Results;
        }
    }
}
