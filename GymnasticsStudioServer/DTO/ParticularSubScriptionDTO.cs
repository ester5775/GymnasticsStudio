using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ParticularSubScriptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
        public string LessonKind { get; set; }
        public Nullable<double> Price { get; set; }

        public static ParticularSubScriptionDTO Convert(ParticularSubscription particularSubscription)
        {
            ParticularSubScriptionDTO particularSubScriptionDTO = new ParticularSubScriptionDTO();
            particularSubScriptionDTO.Id = particularSubscription.Id;
            particularSubScriptionDTO.Name = particularSubscription.Name;
            particularSubScriptionDTO.StudentId = particularSubscription.StudentId;
            particularSubScriptionDTO.StartDate = particularSubscription.StartDate.ToString();
            particularSubScriptionDTO.FinishDate = particularSubscription.FinishDate.ToString();
            particularSubScriptionDTO.LessonKind = particularSubscription.LessonKind;
            particularSubScriptionDTO.Price = particularSubscription.Price;
            return particularSubScriptionDTO;
        }

        public static List<ParticularSubScriptionDTO> Convert(List<ParticularSubscription> particularSubscriptionList)
        {
            return particularSubscriptionList.Select(x => Convert(x)).ToList();
        }

        public static ParticularSubscription Convert(ParticularSubScriptionDTO particularSubScriptionDTO)
        {
            ParticularSubscription particularSubscription = new ParticularSubscription();
            if (particularSubScriptionDTO.Id != default)
                particularSubscription.Id = particularSubScriptionDTO.Id;
            particularSubscription.Name = particularSubScriptionDTO.Name;
            particularSubscription.StudentId = particularSubScriptionDTO.StudentId;
            if(particularSubScriptionDTO.StartDate!=default)
            particularSubscription.StartDate = System.Convert.ToDateTime(particularSubScriptionDTO.StartDate);
            if (particularSubScriptionDTO.FinishDate != default)
                particularSubscription.FinishDate = System.Convert.ToDateTime(particularSubScriptionDTO.FinishDate);
            particularSubscription.LessonKind = particularSubScriptionDTO.LessonKind;
            particularSubscription.Price = particularSubScriptionDTO.Price;
            return particularSubscription;
        }

        public static List<ParticularSubscription> Convert(List<ParticularSubScriptionDTO> particularSubScriptionDTOList)
        {
            return particularSubScriptionDTOList.Select(x => Convert(x)).ToList();


        }

    }
}

   