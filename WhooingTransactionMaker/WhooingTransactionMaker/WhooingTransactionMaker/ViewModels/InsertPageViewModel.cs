using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WhooingTransactionMaker.Models;
using Xamarin.Forms;

namespace WhooingTransactionMaker.ViewModels
{
    public class InsertPageViewModel : INotifyPropertyChanged
    {

        public ICommand SubmitTransactionCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public InsertPageViewModel()
        {
            SubmitTransactionCommand = new Command((obj) =>
            {

            });
            
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
