using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class SubscriptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> WeeksNum { get; set; }
        public Nullable<int> DaysInWeekNum { get; set; }



        public static SubscriptionDTO Convert(Subscription subscription)
        {
            SubscriptionDTO subscriptionDTO = new SubscriptionDTO();
            subscriptionDTO.Id = subscription.Id;
            subscriptionDTO.Name = subscription.Name;
            subscriptionDTO.Price = subscription.Price;
            subscriptionDTO.WeeksNum = subscription.WeeksNum;
            subscriptionDTO.DaysInWeekNum = subscription.DaysInWeekNum;

            return subscriptionDTO;
        }

        public static List<SubscriptionDTO> Convert(List<Subscription> subscriptionList)
        {
            return subscriptionList.Select(x => Convert(x)).ToList();

        }

        public static Subscription Convert(SubscriptionDTO subscriptionDTO)
        {
            Subscription subscription = new Subscription();
            subscription.Id = subscriptionDTO.Id;
            subscription.Name = subscriptionDTO.Name;
            subscription.Price = subscriptionDTO.Price;
            subscription.WeeksNum = subscriptionDTO.WeeksNum;
            subscription.DaysInWeekNum = subscriptionDTO.DaysInWeekNum;

            return subscription;
        }

        public static List<Subscription> Convert(List<SubscriptionDTO> subscriptionDTOsList)
        {
            return subscriptionDTOsList.Select(x => Convert(x)).ToList();


        }

    }
}

