using CalendarBot.Models;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace CalendarBot
{
    public static class CalendarLogic
    {
        public static Event CreateEvent()
        {
            Event myEvent = new Event
            {
                Summary = "Appointment",
                Location = "Somewhere",
                Start = new EventDateTime()
                {
                    DateTimeDateTimeOffset = new DateTime(2023, 11, 5, 10, 0, 0),
                    TimeZone = "America/Los_Angeles"
                },
                End = new EventDateTime()
                {
                    DateTimeDateTimeOffset = new DateTime(   2023, 11, 5, 15, 30, 0),
                    TimeZone = "America/Los_Angeles"
                },
                Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" },
            };
            return myEvent;
        }

        public static Events GetWeekEvents(DateTime startOfWeek, DateTime endOfWeek, CalendarService service)
        {
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = startOfWeek;
            request.TimeMax = endOfWeek;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();
            return events;
        }

        public static Tuple<DateTime, DateTime> GetCurrentWeek()
        {
            // Get the first and last day of the current week
            DateTime now = DateTime.Now;
            DateTime startOfWeek = now.AddDays(-(int)now.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            Tuple<DateTime, DateTime> tuple = new(startOfWeek, endOfWeek);
            return tuple;
        }

        public static void DeleteEventsFromPeriod(DateTime startOfWeek, DateTime endOfWeek, CalendarService service)
        {
            Events events = GetWeekEvents(startOfWeek, endOfWeek, service);
            foreach (var ev in events.Items)
            {
                var id = ev.Id;
                var calendarId = "primary";
                // Delete the note
                service.Events.Delete(calendarId, id).Execute();
            }
        }
        public static List<Implementation> CreateImplementationList(Events evs)
        {
            List<Implementation> list = new List<Implementation>();
            foreach (var ev in evs.Items)
            {
                var impl = new Implementation(ev);
                if (impl.isValid())
                {
                    list.Add(impl);
                }
            }
            return list;
        }
    }
}
