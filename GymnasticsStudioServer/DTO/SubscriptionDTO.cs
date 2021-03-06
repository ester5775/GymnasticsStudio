
﻿using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> WeeksNum { get; set; }
        public Nullable<int> DaysInWeekNum { get; set; }
        public string LessonKind { get; set; }
        public string StudensKind { get; set; }
        public static SubscriptionDTO ConvertToDTO(Subscription subscription)
        {
            SubscriptionDTO subscriptionDTO = new SubscriptionDTO();
            if(subscription.Id!=default)
            subscriptionDTO.Id = subscription.Id;
            subscriptionDTO.Name = subscription.Name;
            subscriptionDTO.Price = subscription.Price;
            subscriptionDTO.WeeksNum = subscription.WeeksNum;
            subscriptionDTO.DaysInWeekNum = subscription.DaysInWeekNum;
            subscriptionDTO.LessonKind = subscription.LessonKind;
            subscriptionDTO.StudensKind = subscription.StudensKind;

            return subscriptionDTO;
        }

        public static List<SubscriptionDTO> ConvertListToDTO(List<Subscription> subscriptionList)
        {
            List<SubscriptionDTO> studentDTOsList = new List<SubscriptionDTO>();
            for (int i = 0; i < subscriptionList.Count(); i++)
            {
                studentDTOsList.Add(ConvertToDTO(subscriptionList[i]));
            }
            return studentDTOsList;
        }

        public static Subscription ConvertFromDTO(SubscriptionDTO subscriptionDTO)
        {
            Subscription subscription = new Subscription();
            if(subscriptionDTO.Id!=default)
                 subscription.Id = subscriptionDTO.Id;
            subscription.Name = subscriptionDTO.Name;
            subscription.Price = subscriptionDTO.Price;
            subscription.WeeksNum = subscriptionDTO.WeeksNum;
            subscription.DaysInWeekNum = subscriptionDTO.DaysInWeekNum;
            subscription.LessonKind = subscriptionDTO.LessonKind;
            subscription.StudensKind = subscriptionDTO.StudensKind;
            return subscription;
        }

        public static List<Subscription> ConvertListFromDTO(List<SubscriptionDTO> subscriptionDTOsList)
        {
            List<Subscription> subscriptionList = new List<Subscription>();
            for (int i = 0; i < subscriptionDTOsList.Count(); i++)
            {
                subscriptionList.Add(ConvertFromDTO(subscriptionDTOsList[i]));
            }
            return subscriptionList;

        }

    }
}
