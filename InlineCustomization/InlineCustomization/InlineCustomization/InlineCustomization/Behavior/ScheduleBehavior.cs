using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using System.Linq;

namespace InlineCustomization
{
    public class ScheduleBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            schedule = bindable.FindByName<SfSchedule>("schedule");

            schedule.OnMonthInlineLoadedEvent += Schedule_OnMonthInlineLoadedEvent;
        }

        private void Schedule_OnMonthInlineLoadedEvent(object sender, MonthInlineLoadedEventArgs e)
        {
            var appointments = e.appointments.Cast<ScheduleAppointment>().ToList();
            MonthInlineViewStyle monthInlineViewStyle = new MonthInlineViewStyle();
            if (appointments != null && appointments.Count > 0)
            {
                monthInlineViewStyle.BackgroundColor = Color.Blue;
                monthInlineViewStyle.TextColor = Color.Green;
                monthInlineViewStyle.FontSize = 20;
                monthInlineViewStyle.FontAttributes = FontAttributes.None;
                monthInlineViewStyle.FontFamily = "Times New Roman";
                monthInlineViewStyle.TimeTextColor = Color.Red;
                monthInlineViewStyle.TimeTextSize = 15;
                monthInlineViewStyle.TimeTextFormat = "hh a";
            }
            else
            {
                // Style the No Events label
                monthInlineViewStyle.BackgroundColor = Color.Red;
                monthInlineViewStyle.FontAttributes = FontAttributes.Italic;
                monthInlineViewStyle.FontFamily = "Times New Roman";
                monthInlineViewStyle.TimeTextColor = Color.White;
                monthInlineViewStyle.TimeTextSize = 20;
            }

            e.monthInlineViewStyle = monthInlineViewStyle;
        }
    }
}
