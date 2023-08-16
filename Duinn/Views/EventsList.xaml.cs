using Duinn.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Duinn.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsList : ContentPage
    {
        bool alertAnswer = false;

        public EventsList()
        {
            InitializeComponent();
            this.BindingContext = EventsListViewModel.Instance;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            RefreshEvents();
        }

        private static void RefreshEvents()
        {
            _ = EventPersistence.LoadEventsAsync();
            EventsListViewModel.Instance.NotifyPropertyChanged(nameof(EventsListViewModel.Instance.UpcomingEvents));
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            alertAnswer = await DisplayAlert("Question", "Delete this event?", "Yes", "No");
            if (alertAnswer)
            {
                if(e.Item is Models.CalendarEvent ce)
                {
                    if (!EventsListViewModel.Instance.RemoveEvent(ce.ID))
                    {
                        await DisplayAlert("Alert", "Failed to delete event", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Event deleted", "Ok");
                    }

                    RefreshEvents();
                }
            }
        }
    }
}