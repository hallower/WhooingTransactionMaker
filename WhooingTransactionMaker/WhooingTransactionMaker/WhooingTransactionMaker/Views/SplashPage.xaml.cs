using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.Helpers;
using WhooingTransactionMaker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhooingTransactionMaker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            LoginToWhooing();
        }

        public async void LoginToWhooing()
        {
            LoginView.Source = await Whooing.Instance.GetLoginUrl();
            LoginView.IsVisible = true;
        }

        private void WebViewNavigating(object sender, WebNavigatingEventArgs e)
        {
            LoadingStatus.Text = e.Url;

            if (e.Url.Contains("pin="))
            {
                LoginView.IsVisible = false;

                int startPos = e.Url.IndexOf("pin=") + 4;
                int endPos = e.Url.IndexOf("&", startPos);
                string pinNumber;

                if (endPos == -1)
                {
                    pinNumber = e.Url.Substring(startPos);
                }
                else
                {
                    pinNumber = e.Url.Substring(startPos, endPos - startPos);
                }

#pragma warning disable CS4014
                PostLoginProcess(pinNumber);
#pragma warning restore CS4014
            }
            else if (e.Url.Contains("logout"))
            {
                // TODO : exit
            }

        }

        private async Task PostLoginProcess(string pinNumber)
        {
            if (await Whooing.Instance.DoLoginProcess(pinNumber) == false)
            {
                SubsystemUtils.Instance.Toast("Login is failed due to invalid account information, Please login again.");
                SubsystemUtils.Instance.TerminateApp();
                return;
            }

            Application.Current.MainPage = new TabbedPage
            {
                Children =
                    {
                        new InsertPage()
                        {
                            Title = "Insert",
                            Icon = Device.OnPlatform("tab_feed.png",null,null)
                        },
                        new EntryListPage()
                        {
                            Title = "List",
                            Icon = Device.OnPlatform("tab_feed.png",null,null)
                        },
                        new NavigationPage(new ItemsPage())
                        {
                            Title = "Browse",
                            Icon = Device.OnPlatform("tab_feed.png",null,null)
                        }
                    }
            };
        }
    }
}