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
        public static List<SubscriptionDTO> GetSubscriptionList(int studentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                string studentKind = GSDE.Students.Where(x => x.Id == studentId).FirstOrDefault().StudentKind;
                List<Subscription> SubscriptionList = new List<Subscription>();
                SubscriptionList = GSDE.Subscriptions.Where(x => x.StudensKind == studentKind).ToList();
                return SubscriptionDTO.ConvertListToDTO(SubscriptionList);
            }
        }
    }
}
