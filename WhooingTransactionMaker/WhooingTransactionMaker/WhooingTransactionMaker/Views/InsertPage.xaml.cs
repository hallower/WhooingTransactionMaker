using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WhooingTransactionMaker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhooingTransactionMaker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {

        private DateTime InsertDate = DateTime.Today;

        public static readonly BindableProperty SubmitTransactionProperty =
            BindableProperty.Create("SubmitTransaction", typeof(ICommand), typeof(InsertPage), null);

        public ICommand SubmitTransaction
        {
            get { return (ICommand)GetValue(SubmitTransactionProperty); }
            set { SetValue(SubmitTransactionProperty, value); }
        }

        public InsertPage()
        {
            InitializeComponent();

            // Set today
            ItemDate.Text = InsertDate.ToString("m");
        }

        private void SubmitClicked(object sender, EventArgs e)
        {
            if(LeftCategory.SelectedItem == null ||
                RightCategory.SelectedItem == null)
            {
                // TODO : Make a toast
                return;
            }

            if(ItemDesc.Text.Length < 1)
            {
                // TODO : Make a toast
                return;
            }
            Double price;
            if(Double.TryParse(ItemPrice.Text, out price) == false)
            {
                // TODO : Make a toast
                return;
            }

            SubmitTransaction?.Execute(new Transaction
            {
                Time = InsertDate,
                Price = price,
                Desc = ItemDesc.Text,
                Left = LeftCategory.SelectedItem.ToString(),
                Right = RightCategory.SelectedItem.ToString(),
            });
        }
    }
}