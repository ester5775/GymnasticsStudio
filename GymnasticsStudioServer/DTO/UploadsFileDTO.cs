using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UploadsFileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Nullable<int> StudentId { get; set; }

        public static List<UploadsFileDTO> Convert(List<UploadsFile> lists)
        {
            return lists.Select(x => Convert(x)).ToList();
        }
        public static UploadsFileDTO Convert(UploadsFile file)
        {
            return new UploadsFileDTO()
            {
                Id = file.Id,
                Name = file.Name,
                Path = file.Path,
                StudentId=file.StudentId
            };
        }
    }
}
