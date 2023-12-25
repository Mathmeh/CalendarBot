using Google.Apis.Calendar.v3.Data;
using System.ComponentModel.DataAnnotations;

namespace CalendarBot.Models
{
    public class Implementation
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Group { get; set; }
        public string Discipline { get; set; }
        public string Theme { get; set; }
        public string LessonType { get; set; }
        public double Hours { get; set; }
        public double Ante { get; set; }
        public string? Note { get; set; }

        public Implementation()
        {
            Group = "";
            Discipline = "";
            Theme = "";
            LessonType = "";
            Note = "";
        }

        public Implementation(Event ev)
        {
            try
            {
                string descString = ev.Description;
                string title = ev.Summary;
                StartTime = DateTime.Parse(ev.Start.DateTimeRaw.ToString()).ToUniversalTime();
                EndTime = DateTime.Parse(ev.End.DateTimeRaw.ToString()).ToUniversalTime();
                Date = DateOnly.FromDateTime(StartTime);

                if (title!=null&&title.Contains(" "))
                {
                    var substrs = title.Split(" ");
                    Group = substrs[1];
                    Discipline = substrs[0];
                }

                if (descString!=null&&descString.Contains("\n")) { 
                var substrs = descString.Split("\n");
                    foreach (var sub in substrs)
                    {
                        int spaceIndex = sub.IndexOf(':');
                        string header = sub.Substring(0, spaceIndex); // Get the substring before the symbol


                        switch (header)
                        {
                            case "Тема":
                                Theme = sub.Substring(spaceIndex + 2);
                                break;
                            case "Часы":
                                Double.TryParse(sub.Substring(spaceIndex + 2), out double d);
                                Hours = d;
                                break;
                            case "Тип занятия":
                                LessonType = sub.Substring(spaceIndex + 2);
                                break;
                            case "Ставка":
                                Double.TryParse(sub.Substring(spaceIndex + 2), out double ante);
                                Ante = ante;
                                break;
                            case "Примечания":
                                Note = sub.Substring(spaceIndex + 2);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public bool isValid()
        {
            if (Hours==0) return false;
            if (Ante==0) return false;
            if (LessonType==null||LessonType.Trim()=="") return false;
            if (Group == null || Group.Trim() == "") return false;
            if (Discipline == null || Discipline.Trim() == "") return false;
            if (Theme == null || Theme.Trim() == "") return false;

            return true;
        }
    }
}
