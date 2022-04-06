using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Duinn.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEvent : ContentPage
    {
        public AddEvent()
        {
            InitializeComponent();
            this.BindingContext = ViewModels.AddEventViewModel.Instance;
        }

        private void StartDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            EndDate.Date = StartDate.Date;
        }
    }
}