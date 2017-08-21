using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.Helpers;
using Xamarin.Forms;

namespace WhooingTransactionMaker.Models
{

    public enum AuthStatus
    {
        NoAuth,
        Authenticating,
        AuthSuccess,
        AuthFailed,
    }

    public sealed class Auth
    {
        private static readonly Lazy<Auth> lazy = new Lazy<Auth>(() => new Auth());

        private Int64 sequence;
        private string appID = "226";
        private string alkjdflkasdf = "cfd493a5175df115e33a50d4fedaeae0809532b1";
        private string tmpToken;
        private string accessToken;
        private string accessTokenS;

        private string urlReqeustToken = "/app_auth/request_token";
        private string urlGetAccessToken = "/app_auth/access_token";

        public AuthStatus Status { get; private set; }

        public static Auth Instance { get { return lazy.Value; } }

        private Auth()
        {
            Status = AuthStatus.NoAuth;
        }

        public async Task<string> GetToken()
        {
            Status = AuthStatus.Authenticating;

            var uri = Whooing.BaseUrl + urlReqeustToken + "?app_id=" + appID + "&app_secret=" + alkjdflkasdf;
            var result = await RESTInvoker.Invoke(RestMethod.GET, uri, string.Empty);

            if (result["token"] == null)
            {
                SubsystemUtils.Instance.Err("GetToken is failed!!!");
                Status = AuthStatus.AuthFailed;
            }

            tmpToken = result["token"]?.ToString();
            return tmpToken;
        }

        public async Task<string> GetAccessToken(string pin)
        {
            Status = AuthStatus.Authenticating;

            var uri = Whooing.BaseUrl + urlGetAccessToken + "?app_id=" + appID + "&app_secret=" + alkjdflkasdf + "&token=" + tmpToken + "&pin=" + pin;
            var result = await RESTInvoker.Invoke(RestMethod.GET, uri, string.Empty);

            if (result["token"] == null)
            {
                Status = AuthStatus.AuthFailed;
                SubsystemUtils.Instance.Err("GetAccessToken is failed!!!");
            }
            else
            {
                Status = AuthStatus.AuthSuccess;
                //SubsystemUtils.Instance.Err("GetAccessToken is succeed!!!");
                tmpToken = null;
            }

            accessToken = result["token"]?.ToString();
            accessTokenS = result["token_secret"]?.ToString();
            return result["user_id"].ToString();
        }

        public string getXAPIKey()
        {
            if (Status != AuthStatus.AuthSuccess)
            {
                SubsystemUtils.Instance.Err("Login is required to make XAPI key!!!");
                return string.Empty;
            }

            string key = "app_id=";

            key += appID;
            key += ",token=";
            key += accessToken;

            key += ",nounce=";
            key += (sequence++);
            key += ",timestamp=";
            key += DateTime.Today.Millisecond;

            key += ",signiture=";
            key += SubsystemUtils.Instance.GetSHA1Hash(alkjdflkasdf + '|' + accessTokenS);

            //Log.d(LOG_TAG, "XAPIKey = " + key.toString();
            return key;
        }
    }
}

