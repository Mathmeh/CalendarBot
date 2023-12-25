using CalendarBot.Context;
using CalendarBot.Oauth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalendarBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        readonly UserCredential Credentials;
        CalendarService Service;
        readonly CalendarContext Context;

        public CalendarController(CalendarContext cont)
        {
            Context = cont;
            
            Credentials = OauthClass.GetAcces();
            Service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Credentials,
                ApplicationName = "Calendar API Sample",
            });
        }

        
        [HttpPost]
        public ActionResult SetEvent()
        {
            Event ev = CalendarLogic.CreateEvent();
            Service.Events.Insert(ev, "primary").Execute();
            return Ok();
        }


        [HttpGet]
        public ActionResult GetValidCurrentWeekEvents()
        {
            var tuple = CalendarLogic.GetCurrentWeek();
            Events events = CalendarLogic.GetWeekEvents(tuple.Item1, tuple.Item2, Service);

            var impl = CalendarLogic.CreateImplementationList(events);

            return Ok();
        }
       

        /// <summary>
        /// Simple Deletion events from calendar from specified period
        /// </summary>
        /// <param name="startOfWeek"></param>
        /// <param name="endOfWeek"></param>
        /// <returns></returns>
       [HttpDelete]
       public ActionResult DeleteEventsFromWeek(DateTime startOfWeek, DateTime endOfWeek)
        {
            CalendarLogic.DeleteEventsFromPeriod(startOfWeek, endOfWeek, Service);
            return Ok();
        }

        /// <summary>
        /// Deletion with saving events from calendar from specified period
        /// </summary>
        /// <param name="startOfPeriod"></param>
        /// <param name="endOfPeriod"></param>
        /// <param name="ifDelete"></param>
        /// flag indicating the need for deletion
        /// <returns></returns>
        [HttpDelete]
        [Route("save")]
        public ActionResult DeleteAndSaveEventsFromPeriod(DateTime startOfPeriod, DateTime endOfPeriod, bool ifDelete)
        {
            var events =  CalendarLogic.GetWeekEvents(startOfPeriod, endOfPeriod, Service);
            var impls = CalendarLogic.CreateImplementationList(events);
            foreach (var impl in impls)
            {
                try
                {
                    Context.Implementations.Add(impl);
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            if (ifDelete == true)
            {
                CalendarLogic.DeleteEventsFromPeriod(startOfPeriod, endOfPeriod, Service);
            }
            return Ok();
        }
    }
}
