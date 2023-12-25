using System.ComponentModel.DataAnnotations;

namespace CalendarBot.Models
{
    public class StudyPlan
    {
        [Key]
        public int Id { get; set; }
        public string TeacherName { get; set; }

        public int Ante { get; set; }
        public string AcademicDiscipline { get; set; }
        public string Faculty { get; set; }
        public string Speciality { get; set; }
        public int Grade { get; set; }
        public int Semester { get; set; }
        public string EducationForm { get; set; }
        public int StudentAmount { get; set; }
        public int Groups { get; set; }
        public int Subgroups { get; set; }
        public int Lectures  { get; set; }
        public int OfflineLectures { get; set; }
        public int SemLessons { get; set; }
        public int SemLessonsOffline { get; set; }
        public int LabLesson { get; set; }
        public int LabLessonOffline { get; set; }
        public int NumberOfTests    { get; set; }
        public int USRControl { get; set; }
        public int ControlWorks { get; set; }
        
        public double Exams { get; set; }
        public double Score { get; set; }
        public double EducationalPractice { get; set; }
        public double Internship { get; set; }
        public double CourseProject { get; set; }
        public double GraduationProject { get; set; }
        public double UnderGraduatesLessons { get; set; }
        public double DepartmentManagement { get; set; }
        public double GEX { get; set; }
        public double TotalHours { get; set; }


        public StudyPlan()
        {
            TeacherName = "";
            AcademicDiscipline = "";
            Faculty = "";
            Speciality = "";
            EducationForm = "";
        }
    }
}
