using CalendarBot.Models;
using Microsoft.EntityFrameworkCore;

namespace CalendarBot.Context
{
    public class CalendarContext : DbContext
    {
        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options)
        {
           
        }

        public DbSet<StudyPlan> Plans { get; set; }
        public DbSet<Implementation> Implementations { get; set; }
        public DbSet<ExcelInfo> ExcelInfos { get; set; }

    }
}
