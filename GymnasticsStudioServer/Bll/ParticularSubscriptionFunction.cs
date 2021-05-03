using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class ParticularSubscriptionFunction
    {
        public static bool AddParticularSubscription(ParticularSubScriptionDTO particularSubScriptionDTO)
        {

            try
            {
                using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
                {

                    GSDE.ParticularSubscriptions.Add(ParticularSubScriptionDTO.Convert(particularSubScriptionDTO));
                    GSDE.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}

