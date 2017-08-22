using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WhooingTransactionMaker.Helpers;
using WhooingTransactionMaker.Models;
using Xamarin.Forms;

namespace WhooingTransactionMaker.ViewModels
{
    public class InsertPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SubmitTransactionCommand { get; }

        public ICollection<String> LeftCategories { get; private set; } = new List<String>();

        public ICollection<String> RightCategories { get; private set; } = new List<String>();

        public InsertPageViewModel()
        {
            SubmitTransactionCommand = new Command((obj) =>
            {
                SubsystemUtils.Instance.Dbg("Submit");
            });

            Whooing.Instance.WhooingStatusChanged += (s, e) =>
            {
                if(Whooing.Instance.WhooingStatus == WhooingServiceStatus.ServiceReady)
                {
                    UpdateWhooingInformation();
                }
            };

            if (Whooing.Instance.WhooingStatus == WhooingServiceStatus.ServiceReady)
            {
                // update accounts
                // items
                UpdateWhooingInformation();
            }
        }

        private void UpdateWhooingInformation()
        {
            UpdateCategories();
        }

        private void UpdateCategories()
        {
            LeftCategories = new List<String>();
            RightCategories = new List<String>();

            foreach (var account in Whooing.Instance.AllAccounts.Assets)
            {
                LeftCategories.Add(account.Title);
                RightCategories.Add(account.Title);
            }

            foreach (var account in Whooing.Instance.AllAccounts.Liabilities)
            {
                LeftCategories.Add(account.Title);
                RightCategories.Add(account.Title);
            }

            foreach (var account in Whooing.Instance.AllAccounts.Capitals)
            {
                LeftCategories.Add(account.Title);
                RightCategories.Add(account.Title);
            }

            foreach (var account in Whooing.Instance.AllAccounts.Expenses)
            {
                LeftCategories.Add(account.Title);
            }
            foreach (var account in Whooing.Instance.AllAccounts.Incomes)
            {
                RightCategories.Add(account.Title);
            }

            OnPropertyChanged("LeftCategories");
            OnPropertyChanged("RightCategories");
        }


        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
