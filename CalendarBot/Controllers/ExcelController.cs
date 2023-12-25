using CalendarBot.Context;
using CalendarBot.Logic;
using CalendarBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalendarBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExcelController : Controller
    {
        readonly CalendarContext Context;
        public ExcelController(CalendarContext cont)
        {
            Context = cont;
        }

        [HttpPut]
        public ActionResult CreateImplementationTable()
        {
            var implementations = Context.Implementations.ToList();
            ExcelInfo info = new ExcelInfo("D:\\PayLoads", DateTime.Now.Date);//TODO set the actual path for your app
            ExcelLogic.CreateImplementationTable(implementations, info.Path);
            Context.ExcelInfos.Add(info); 
            Context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult CreatePlanTable()
        {
            var plans = CalendarBot.Excel.ExcelParser.GetStudyPlans("D:\\PayLoads\\Нагрузка Ермоченко (1 ставка).xlsx", "Нагрузка Ермоченко (1 ставка).xlsx");
            foreach (var plan in plans)
            {
                Context.Plans.Add(plan);
                Context.SaveChanges();
            }

            return Ok();
        }
    }
}
