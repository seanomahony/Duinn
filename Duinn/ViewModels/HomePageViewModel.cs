using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamForms.Controls;

namespace Duinn.ViewModels
{
    class HomePageViewModel : BasePageViewModel
    {
        private static HomePageViewModel _instance;

        public HomePageViewModel() : base()
        {
            Initialize();
        }

        public static HomePageViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HomePageViewModel();
                }

                return _instance;
            }
        }

        private DateTime? _date;
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                NotifyPropertyChanged(nameof(Date));
            }
        }

        private ObservableCollection<SpecialDate> calendarEvents;
        public ObservableCollection<SpecialDate> CalendarEvents
        {
            get { return calendarEvents; }
            set { calendarEvents = value; NotifyPropertyChanged(nameof(CalendarEvents)); }
        }

        private void Initialize()
        {
            CalendarEvents = new ObservableCollection<SpecialDate>();
            LoadEvents();
        }

        public void LoadEvents()
        {

            var dates = new List<SpecialDate>();
            CalendarEvents.Clear();
            CalendarEvents = new ObservableCollection<SpecialDate>(dates);
            foreach (var calEvent in Models.CalendarEvents.EventsList)
            {
                SpecialDate specialDate = new SpecialDate(calEvent.StartDate);
                BackgroundPattern backgroundPattern;
                switch (calEvent.User)
                {
                    case Models.CalendarEvent.UserEnum.Amy:
                        backgroundPattern = CalendarPatterns.AmyPattern(calEvent.Title);
                        break;
                    case Models.CalendarEvent.UserEnum.Both:
                        backgroundPattern = CalendarPatterns.BothPattern(calEvent.Title);
                        break;
                    case Models.CalendarEvent.UserEnum.Sean:
                        backgroundPattern = CalendarPatterns.SeanPattern(calEvent.Title);
                        break;
                    default:
                        backgroundPattern = null;
                        break;
                }
                specialDate.BackgroundPattern = backgroundPattern;
                CalendarEvents.Add(specialDate);
            }

            NotifyPropertyChanged(nameof(CalendarEvents));
        }

        private void InitializeDummyData()
        {
            var dates = new List<SpecialDate>();

            var grayColor = Color.FromHex("#CCE5E5E5");
            CalendarEvents.Clear();
            CalendarEvents = new ObservableCollection<SpecialDate>(dates) {
        new SpecialDate(DateTime.Now.AddDays(3))
        {
            Selectable = true,
            BackgroundPattern = new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.7f, Color = Color.White},
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.3f, Color = Color.Yellow,Text = "Vacation", TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle},
                }
            }
        },
        new SpecialDate(DateTime.Now.AddDays(5))
        {
            Selectable = true,
            BackgroundPattern = new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.7f, Color = Color.White},
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.3f, Color = Color.LightGreen, Text = "Absence", TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle},
                }
            }
        },
        new SpecialDate(DateTime.Now.AddDays(4))
        {
            Selectable = true,
            BackgroundPattern = new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.7f, Color = grayColor},
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.15f, Color = Color.Yellow, Text = "Vacation", TextColor=Color.DarkBlue, TextSize=9, TextAlign=TextAlign.Middle},
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.15f, Color = Color.LightGreen, Text = "Absence", TextColor=Color.DarkBlue, TextSize=9, TextAlign=TextAlign.Middle},
                }
            }
        },
        new SpecialDate(DateTime.Now.AddDays(6))
        {
            Selectable = true,
            BackgroundPattern = new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.7f, Color = grayColor},
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.3f, Color = Color.LightGreen, Text = "Absence", TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle},
                }
            }
        },
        new SpecialDate(DateTime.Now)
        {
            Selectable = true,
            TextColor = Color.Red,
            FontAttributes = FontAttributes.Bold
        },
        new SpecialDate(DateTime.Now.AddDays(1))
        {
            Selectable = true,
            BackgroundPattern = new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 1f, Color = grayColor},
                }
            },
        },
        new SpecialDate(DateTime.Now.AddDays(2))
        {
            Selectable = true,
            BackgroundPattern = new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 1f, Color = grayColor},
                }
            }
        },
        new SpecialDate(DateTime.Now.AddDays(8))
        {
            Selectable = true,
            BackgroundPattern = new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 1f, Color = grayColor},
                }
            }
        },
        new SpecialDate(DateTime.Now.AddDays(9))
        {
            Selectable = true,
            BackgroundPattern = new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 1f, Color = grayColor},
                }
            }
        },

    };
        }
    }
}
