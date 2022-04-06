using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duinn.ViewModels
{
    class EventsListViewModel : BasePageViewModel
    {
        private static EventsListViewModel _instance;
        private object _lock = new object();

        public List<Models.CalendarEvent> UpcomingEvents
        {
            get
            {
                List<Models.CalendarEvent> events = new List<Models.CalendarEvent>();
                foreach (var evnt in Models.CalendarEvents.EventsList.Where(e => e.StartDate.Date >= DateTime.Today.Date).Take(10).OrderBy(e => e.StartDate.Date))
                {
                    events.Add(evnt);
                }
                return events;
            }
        }

        public EventsListViewModel()
        {

        }

        public static EventsListViewModel Instance 
        { 
            get 
            {
                if(_instance == null)
                {
                    _instance = new EventsListViewModel();
                }
                return _instance;
            } 
        }

        public bool RemoveEvent(Models.CalendarEvent calendarEvent)
        {
            if (!Models.CalendarEvents.EventsList.Remove(calendarEvent))
            {
                return false;
            }
            UpdateEventsList();
            return true;
        }

        private void UpdateEventsList()
        {
            lock (_lock)
            {
                EventPersistence.SaveEvents();
                NotifyPropertyChanged(nameof(UpcomingEvents));
            }
        }
    }
}
