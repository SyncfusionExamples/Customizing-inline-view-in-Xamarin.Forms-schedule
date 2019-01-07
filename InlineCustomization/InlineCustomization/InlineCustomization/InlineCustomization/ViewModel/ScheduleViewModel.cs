using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace InlineCustomization
{
    public class ScheduleViewModel
    {
        public ScheduleAppointmentCollection Appointments { get; set; }

        public ScheduleViewModel()
        {
            Appointments = new ScheduleAppointmentCollection();
            Appointments.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now.Date.AddHours(10),
                EndTime = DateTime.Now.Date.AddHours(12),
                Subject = "Meeting",
                Color = Color.Red
            });
        }
    }
}
