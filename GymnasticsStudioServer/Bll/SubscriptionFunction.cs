using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class SubscriptionFunction
    {
        public static List<SubscriptionDTO> getSubscriptionListByStudent(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                string studentKind = GSDE.Students.Where(x => x.Id == studentId).FirstOrDefault().StudentKind;
                List<Subscription> SubscriptionList = new List<Subscription>();
                SubscriptionList = GSDE.Subscriptions.Where(x => x.StudensKind == studentKind).ToList();
                return SubscriptionDTO.ConvertListToDTO(SubscriptionList);
            }
        }
        public static SubscriptionDTO GetSubscriptionDetailsBySubscriptionId(int id)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                Subscription Subscription = new Subscription();
                Subscription = GSDE.Subscriptions.FirstOrDefault(x => x.Id == id);
                return SubscriptionDTO.ConvertToDTO(Subscription);


            }
        }

        public static bool EditSubscription(SubscriptionDTO SubscriptionDTO)
        {
            using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
            {

                var s = context.Subscriptions.FirstOrDefault(x => x.Id == SubscriptionDTO.Id);
                if (s != null)
                {
                    s.Name = SubscriptionDTO.Name?.TrimStart().TrimEnd();
                    s.Price = SubscriptionDTO.Price;
                    s.WeeksNum = SubscriptionDTO.WeeksNum;
                    s.DaysInWeekNum = SubscriptionDTO.DaysInWeekNum;
                    s.LessonKind = SubscriptionDTO.LessonKind?.TrimStart().TrimEnd();
                    s.StudensKind = SubscriptionDTO.StudensKind?.TrimStart().TrimEnd();
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }


        }

        public static int AddSubscription(SubscriptionDTO SubscriptionDTO)
        {
            try
            {
                using (Gymnastics_Studio_DataEntities context = new Gymnastics_Studio_DataEntities())
                {



                    Subscription Subscription = new Subscription();
                    Subscription.Name = SubscriptionDTO.Name?.TrimStart().TrimEnd();
                    Subscription.Price = SubscriptionDTO.Price;
                    Subscription.WeeksNum = SubscriptionDTO.WeeksNum;
                    Subscription.DaysInWeekNum = SubscriptionDTO.DaysInWeekNum;
                    Subscription.StudensKind = SubscriptionDTO.StudensKind?.TrimStart().TrimEnd();
                    Subscription.LessonKind = SubscriptionDTO.LessonKind?.TrimStart().TrimEnd();
                    context.Subscriptions.Add(Subscription);
                    context.SaveChanges();
                    return context.Subscriptions.Max(o => o.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }



        public static List<SubscriptionDTO> getSubscriptionList()
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                List<Subscription> SubscriptionList = new List<Subscription>();
                SubscriptionList = GSDE.Subscriptions.ToList();
                return SubscriptionDTO.ConvertListToDTO(SubscriptionList);
            }
        }

    }
}

