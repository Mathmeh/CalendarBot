using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CalendarBot.Models
{
    public class ExcelInfo
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public DateTime DateOfCreation { get; set; }

        public ExcelInfo(string path, DateTime time)
        {

            DateOfCreation = time.ToUniversalTime();
            var myUniqueFileNameId = string.Format(@"{0}.txt", Guid.NewGuid());
            FileName = time.Date.ToShortDateString() + "__план выполнения__" + myUniqueFileNameId + ".xlsx";
            Path = path + "\\" + FileName;
        }

        public ExcelInfo()
        {
            FileName = "default";
            Path = "default";
            DateOfCreation = DateTime.Now;
        }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExcelInfo>()
                .HasKey(b => b.Id);

        }
    }
}
