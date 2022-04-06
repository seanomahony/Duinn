using System.Collections.Generic;
using Xamarin.Forms;
using XamForms.Controls;

namespace Duinn
{
    public static class CalendarPatterns
    {
        public static BackgroundPattern AmyPattern(string text)
        {
            return new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.7f, Color = Color.White},
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.3f, Color = Color.Yellow,Text = text, TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle},
                }
            };
        }

        public static BackgroundPattern SeanPattern(string text)
        {
            return new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>        
                {            
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.7f, Color = Color.White},
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.3f, Color = Color.LightBlue,Text = text, TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle},
                }
            };
        }

        public static BackgroundPattern BothPattern(string text)
        {
            return new BackgroundPattern(1)
            {
                Pattern = new List<Pattern>
                {
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.7f, Color = Color.White},
                    new Pattern{ WidthPercent = 1f, HightPercent = 0.3f, Color = Color.LightGreen,Text = text, TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle},
                }
            };
        }
    }
}
