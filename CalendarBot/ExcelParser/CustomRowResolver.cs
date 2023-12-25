using CalendarBot.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;

namespace CalendarBot
{
    public static class CustomRowResolver
    {
        public static StudyPlan RowToStudyPlan(DataRow row)
        {
            var plan = new StudyPlan();

            try
            {
                if (row.Field<string>("Ф.И.О.") != "")
                {
                    plan.TeacherName = row.Field<string>("Ф.И.О.");
                }


                if (row.Field<string>("Дисциплина (вид работ)") != "")
                {
                    plan.AcademicDiscipline = row.Field<string>("Дисциплина (вид работ)");
                }


                if (row.Field<string>("ставка") != "")
                {
                    int.TryParse(row.Field<string>("ставка"), out int ante);
                    plan.Ante = ante;
                }


                if (row.Field<string>("Факультет") != "")
                {
                    plan.Faculty = row.Field<string>("Факультет");
                }


                if (row.Field<string>("Специальность") != "")
                {
                    plan.Speciality = row.Field<string>("Специальность");
                }


                if (row.Field<string>("Курс") != "")
                {
                    int.TryParse(row.Field<string>("Курс"), out int grade);
                    plan.Grade = grade;
                }


                if (row.Field<string>("Семестр") != "")
                {
                    int.TryParse(row.Field<string>("Семестр"), out int sem);
                    plan.Semester = sem;
                }


                if (row.Field<string>("Форма обучения") != "")
                {
                    plan.EducationForm = row.Field<string>("Форма обучения");
                }


                if (row.Field<string>("студентов") != "")
                {
                    int.TryParse(row.Field<string>("студентов"), out int students);
                    plan.StudentAmount = students;
                }


                if (row.Field<string>("групп") != "")
                {
                    int.TryParse(row.Field<string>("групп"), out int groups);
                    plan.Groups = groups;
                }


                if (row.Field<string>("подгрупп") != "")
                {
                    int.TryParse(row.Field<string>("подгрупп"), out int subgroups);
                    plan.Subgroups = subgroups;
                }


                if (row.Field<string>("Лекции\n(в т. ч. online)") != "")
                {
                    int.TryParse(row.Field<string>("Лекции\n(в т. ч. online)"), out int lectures);
                    plan.Lectures = lectures;
                }


                if (row.Field<string>("Лекции\n(offline)") != "")
                {
                    int.TryParse(row.Field<string>("Лекции\n(offline)"), out int ofLectures);
                    plan.OfflineLectures = ofLectures;
                }


                if (row.Field<string>("Практ., сем. занятия\n(в т. ч. online)") != "")
                {
                    int.TryParse(row.Field<string>("Практ., сем. занятия\n(в т. ч. online)"), out int practice);
                    plan.SemLessons = practice;
                }


                if (row.Field<string>("Практ., сем. занятия\n(offline)") != "")
                {
                    int.TryParse(row.Field<string>("Практ., сем. занятия\n(offline)"), out int practice);
                    plan.SemLessonsOffline = practice;
                }


                if (row.Field<string>("Лаборатор. занятия\n(в т. ч. online)") != "")
                {
                    int.TryParse(row.Field<string>("Лаборатор. занятия\n(в т. ч. online)"), out int labs);
                    plan.LabLesson = labs;
                }


                if (row.Field<string>("Лаборатор. занятия\n(offline)") != "")
                {
                    int.TryParse(row.Field<string>("Лаборатор. занятия\n(offline)"), out int labsOffline);
                    plan.LabLessonOffline = labsOffline;
                }


                if (row.Field<string>("Количество\nконтрольных работ") != "")
                {
                    int.TryParse(row.Field<string>("Количество\nконтрольных работ"), out int tests);
                    plan.NumberOfTests = tests;
                }


                if (row.Field<string>("Контроль УСР") != "")
                {
                    int.TryParse(row.Field<string>("Контроль УСР"), out int usr);
                    plan.USRControl = usr;
                }


                if (row.Field<string>("Контрольные работы") != "")
                {
                    int.TryParse(row.Field<string>("Контрольные работы"), out int ex);
                    plan.ControlWorks = ex;
                }


                if (row.Field<string>("Экзамены") != "")
                {
                    double.TryParse(row.Field<string>("Экзамены"), out double ex);
                    plan.Exams = Math.Round(ex, 2);
                }


                if (row.Field<string>("Зачеты") != "")
                {
                    double.TryParse(row.Field<string>("Зачеты"), out double sc);
                    plan.Score = Math.Round(sc, 2);
                }


                if (row.Field<string>("Учебная практика") != "")
                {
                    double.TryParse(row.Field<string>("Учебная практика"), out double ep);
                    plan.EducationalPractice = Math.Round(ep, 2);
                }


                if (row.Field<string>("Производственная практика") != "")
                {
                    double.TryParse(row.Field<string>("Производственная практика"), out double ep);
                    plan.Internship = Math.Round(ep, 2);
                }


                if (row.Field<string>("Курсовое  проектирование") != "")
                {
                    double.TryParse(row.Field<string>("Курсовое  проектирование"), out double cp);
                    plan.CourseProject = Math.Round(cp, 2);
                }


                if (row.Field<string>("Дипломное  проектирование") != "")
                {
                    double.TryParse(row.Field<string>("Дипломное  проектирование"), out double dp);
                    plan.GraduationProject = Math.Round(dp, 2);
                }


                if (row.Field<string>("Занятия с магистрантами") != "")
                {
                    double.TryParse(row.Field<string>("Занятия с магистрантами"), out double ul);
                    plan.UnderGraduatesLessons = Math.Round(ul, 2);
                }


                if (row.Field<string>("Руководство кафедрой") != "")
                {
                    double.TryParse(row.Field<string>("Руководство кафедрой"), out double dm);
                    plan.DepartmentManagement = Math.Round(dm, 2);
                }


                if (row.Field<string>("ГЭК") != "")
                {
                    double.TryParse(row.Field<string>("ГЭК"), out double gex);
                    plan.GEX = Math.Round(gex, 2);
                }


                if (row.Field<string>("Всего учебных часов") != "")
                {
                    double.TryParse(row.Field<string>("Всего учебных часов"), out double total);
                    plan.TotalHours = Math.Round(total, 2);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return plan;
        }
    }
}









