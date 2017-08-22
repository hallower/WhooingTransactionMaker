using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WhooingTransactionMaker.DataModels;
using WhooingTransactionMaker.Helpers;
using WhooingTransactionMaker.Models;
using Xamarin.Forms;

namespace WhooingTransactionMaker.ViewModels
{
    public class EntryListPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

       
        public ICollection<String> Entries { get; private set; } = new List<String>()
        {
            "entry1",
            "entry2",
            "entry3",
            "entry4",
            "entry5",
            "entry6",
            "entry7",
            "entry8",
            "entry9",
            "entry10",
            "entry11",
            "entry12",
            "entry13",
            "entry14",
            "entry15",
            "entry16",
            "entry17",
            "entry18",
            "entry19",
            "entry20",
        };
        
        public EntryListPageViewModel()
        {
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
            UpdateEntries();
        }

        private async void UpdateEntries()
        {
            Entries entries = await EntryProvider.Read(Whooing.Instance.DefaultSectionID);

            Entries = new List<string>();
            foreach(var entry in entries.EntryList)
            {
                Entries.Add($"{entry.Item} / {entry.Money} / {entry.LeftAccount} - {entry.RightAccount}");
            }
            OnPropertyChanged("Entries");
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
