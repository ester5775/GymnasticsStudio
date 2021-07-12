using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WeekDTO
    {
        public string WeeklyPortion { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }
        public int Id { get; set; }


        public static WeekDTO ConvertToDTO(Week week)
        {
            WeekDTO weekDTO = new WeekDTO();
            weekDTO.Id = week.Id;
            weekDTO.Date = week.Date.ToString();
            weekDTO.WeeklyPortion = week.WeeklyPortion;
            weekDTO.Note = week.Note;
           
            return weekDTO;
        }

        public static List<WeekDTO> ConvertListToDTO(List<Week> weekList)
        {
            List<WeekDTO> weekDTOsList = new List<WeekDTO>();
            for (int i = 0; i < weekList.Count(); i++)
            {
                weekDTOsList.Add(ConvertToDTO(weekList[i]));
            }
            return weekDTOsList;
        }

        public static Week ConvertFromDTO(WeekDTO weekDTO)
        {
            Week week = new Week();
            if (weekDTO.Id != default)
                week.Id = weekDTO.Id;
            week.Date = Convert.ToDateTime(weekDTO.Date);
            week.WeeklyPortion = weekDTO.WeeklyPortion;
            week.Note = weekDTO.Note;          
            return week;
        }

        public static List<Week> ConvertListFromDTO(List<WeekDTO> weekDTOsList)
        {
            List<Week> weekList = new List<Week>();
            for (int i = 0; i < weekDTOsList.Count(); i++)
            {
                weekList.Add(ConvertFromDTO(weekDTOsList[i]));
            }
            return weekList;

        }
    }
}
