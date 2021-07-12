using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class WeekFunction
    {
        public static bool AddWeeksUpTo(DateTime date)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {
                    //הוספת שבועות עד לעוד שלוש חודשים מהתאריך המתקבל
                    Week week = new Week();
                    var k = GSDE.Weeks.Max(x => x.Date);
                    week = GSDE.Weeks.Where(x => x.Date == k).First();
                    while (week.Date < date.AddMonths(3))
                    {
                        Week newWeek = new Week();
                        newWeek.Date = ((DateTime)week.Date).AddDays(7);
                        GSDE.Weeks.Add(newWeek);
                        GSDE.SaveChanges();
                        week = GSDE.Weeks.OrderByDescending(o=>o.Id).FirstOrDefault();


                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }


        }

        public static WeekDTO GetWeekDetailsByWeekId(int id)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                Week Week = new Week();
                Week = GSDE.Weeks.FirstOrDefault(x => x.Id == id);
                return WeekDTO.ConvertToDTO(Week);


            }
        }

        public static bool EditWeek(WeekDTO WeekDTO)
        {
            using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
            {

                var week = context.Weeks.FirstOrDefault(x => x.Id == WeekDTO.Id);
                if (week != null)
                {
                    week.Note = WeekDTO.Note?.TrimStart().TrimEnd();
                    week.Date = Convert.ToDateTime(WeekDTO.Date);
                    week.WeeklyPortion = WeekDTO.WeeklyPortion?.TrimStart().TrimEnd();
                   
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }


        }

        public static int AddWeek(WeekDTO WeekDTO)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {



                    Week Week = new Week();
                    Week.Note = WeekDTO.Note?.TrimStart().TrimEnd();
                    Week.Date = Convert.ToDateTime(WeekDTO.Date);
                    Week.WeeklyPortion = WeekDTO.WeeklyPortion?.TrimStart().TrimEnd();
                   
                    context.Weeks.Add(Week);
                    context.SaveChanges();
                    return context.Weeks.Max(o => o.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }



        public static List<WeekDTO> getWeekList()
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Week> WeekList = new List<Week>();
                WeekList = GSDE.Weeks.ToList();
                return WeekDTO.ConvertListToDTO(WeekList);
            }
        }

    }
}



