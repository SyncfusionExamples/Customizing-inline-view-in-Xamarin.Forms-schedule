using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;

namespace InlineCustomization
{
	public partial class MainPage : ContentPage
	{
        ScheduleAppointmentCollection appColl = new ScheduleAppointmentCollection();
		public MainPage()
		{
			InitializeComponent();
            appColl.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now.Date.AddHours(10),
                EndTime = DateTime.Now.Date.AddHours(12),
                Subject = "Meeting",
                Color = Color.Red
            });
            

            schedule.OnMonthInlineLoadedEvent += Schedule_OnMonthInlineLoadedEvent;
            schedule.DataSource = appColl;

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
