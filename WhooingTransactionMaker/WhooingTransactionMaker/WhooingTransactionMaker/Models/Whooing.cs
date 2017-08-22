using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.DataModels;
using WhooingTransactionMaker.Helpers;

namespace WhooingTransactionMaker.Models
{
    public enum WhooingServiceStatus
    {
        LoggedOut,
        LogInProgress,
        LogIned,
        ServiceReady,
    }

    public class Whooing
    {
        #region Whooing Class Instance Definition

        private static readonly Lazy<Whooing> lazy
            = new Lazy<Whooing>(() => new Whooing());

        public static Whooing Instance { get => lazy.Value; }

        #endregion


        #region Properties

        public static string BaseUrl
        {
            get => "https://whooing.com";
        }

        public string UserID { get; private set; }

        public string DefaultSectionID { get; private set; }

        public Accounts AllAccounts
        {
            get => AccountProviderInstance.AllAccounts;
        }

        private WhooingServiceStatus whooingStatus;
        public WhooingServiceStatus WhooingStatus
        {
            get => whooingStatus;
            private set
            {
                if (whooingStatus != value)
                {
                    whooingStatus = value;
                    WhooingStatusChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        #endregion


        #region EventHandlers

        public EventHandler WhooingStatusChanged;

        #endregion


        #region Whooing Sub Model Instance Definitions

        private static readonly Lazy<AuthProvider> authProvider = new Lazy<AuthProvider>(() => new AuthProvider());
        public static AuthProvider AuthProviderInstance { get => authProvider.Value; }


        private static readonly Lazy<UserProvider> userProvider = new Lazy<UserProvider>(() => new UserProvider());
        public static UserProvider UserProviderInstance { get => userProvider.Value; }


        private static readonly Lazy<SectionProvider> sectionProvider = new Lazy<SectionProvider>(() => new SectionProvider());
        public static SectionProvider SectionProviderInstance { get => sectionProvider.Value; }


        private static readonly Lazy<AccountProvider> accountProvider = new Lazy<AccountProvider>(() => new AccountProvider());
        public static AccountProvider AccountProviderInstance { get => accountProvider.Value; }

        #endregion


        public bool IsLoginRequired
        {
            get
            {
                if (WhooingStatus == WhooingServiceStatus.LoggedOut)
                {
                    return true;
                }
                return false;
            }
        }

        public string XAPIKey
        {
            get
            {
                return AuthProviderInstance.getXAPIKey();
            }
        }



        private Whooing()
        {
            WhooingStatus = WhooingServiceStatus.LoggedOut;
        }


        public async Task<string> GetLoginUrl()
        {
            WhooingStatus = WhooingServiceStatus.LogInProgress;

            string token = await AuthProviderInstance.GetToken();
            if (token.Length < 0)
            {
                SubsystemUtils.Instance.Err("GetLoginUrl is failed!!!");
                return null;
            }

            return "https://whooing.com/app_auth/authorize?token=" + token;
        }

        public async Task<bool> DoLoginProcess(string pinNumber)
        {
            UserID = await AuthProviderInstance.GetAccessToken(pinNumber);
            if (AuthProviderInstance.Status != AuthStatus.AuthSuccess)
            {
                WhooingStatus = WhooingServiceStatus.LoggedOut;
                SubsystemUtils.Instance.Err("Login is Failed!!!");
                return false;
            }

            WhooingStatus = WhooingServiceStatus.LogIned;
#pragma warning disable CS4014
            GetOwnerInfo(UserID);
#pragma warning restore CS4014

            return true;
        }

        public async Task GetOwnerInfo(string userID)
        {
            // TODO : remove await!!!!
            await UserProviderInstance.SetOwnerInfo();
            DefaultSectionID = await SectionProviderInstance.SetDefaultSection();
            await SectionProviderInstance.ReadSections();
            await AccountProviderInstance.ReadAll(DefaultSectionID);

            WhooingStatus = WhooingServiceStatus.ServiceReady;
        }
    }
}
