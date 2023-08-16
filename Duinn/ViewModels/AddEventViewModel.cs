using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Duinn.ViewModels
{
    class AddEventViewModel : BasePageViewModel
    {
        private static AddEventViewModel _instance;
        private ICommand _saveCommand;
        private ICommand _clearCommand;
        private object _lock = new object();

        public AddEventViewModel()
        {
            CalendarEvent = new Models.CalendarEvent() { StartDate = DateTime.Now, EndDate = DateTime.Now, User = Models.CalendarEvent.UserEnum.Both };
        }

        public string SelectedUser { get; set; }

        public Models.CalendarEvent CalendarEvent { get; set; }

        public List<string> UsersList 
        { 
            get
            {
                return Models.UserList.Users;
            } 
        }

        public static AddEventViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AddEventViewModel();
                }
                return _instance;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new CommandHandler(() => SaveEvent(), true));
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClearEvent(), true));
            }
        }

        private void ClearEvent()
        {
            CalendarEvent.Clear();
            NotifyPropertyChanged(nameof(CalendarEvent));
        }

        private void SaveEvent()
        {
            lock (_lock)
            {
                CalendarEvent.User = (Models.CalendarEvent.UserEnum)Enum.Parse(typeof(Models.CalendarEvent.UserEnum), SelectedUser, true);
                Models.CalendarEvents.EventsList.Add(CalendarEvent);
                EventPersistence.SaveEvents();
                ClearEvent();
            }
        }
    }
}
