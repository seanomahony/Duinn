using System;
using System.Collections.Generic;
using System.Text;

namespace Duinn.Models
{
    class CalendarEvent
    {
        public CalendarEvent()
        {
            ID = Guid.NewGuid().ToString();
        }

        public string ID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public UserEnum User { get; set; }

        public void Clear()
        {
            Title = "";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Description = "";
            User = UserEnum.Both;
        }

        public enum UserEnum
        {
            Amy,
            Sean,
            Both
        }
    }
}
