using System;
using System.Collections.Generic;
using System.Text;

namespace Duinn.Models
{
    class CalendarEvents
    {
        private static List<CalendarEvent> _eventsList;

        public static List<CalendarEvent> EventsList
        {
            get
            {
                if (_eventsList == null)
                {
                    _eventsList = new List<CalendarEvent>();
                }
                return _eventsList;
            }
            set
            {
                _eventsList = value;
            }
        }
    }
}
