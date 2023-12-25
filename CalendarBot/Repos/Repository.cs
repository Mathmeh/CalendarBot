using CalendarBot.Context;

namespace CalendarBot.Repos
{
    public class Repository
    {
        private readonly CalendarContext context;
        public Repository(CalendarContext cont)
        {
            this.context = cont;
        }

    }
}
