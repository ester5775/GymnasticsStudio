using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class FileService
    {
        public int UploadFile(string filePath, string fileName, string StudentId)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                var newFile = new UploadsFile();

                newFile.Name = fileName;
                newFile.Path = filePath;
                if (StudentId != null) newFile.StudentId = Convert.ToInt32(StudentId);
                var file = GSDE.UploadsFiles.Add(newFile);
                GSDE.SaveChanges();
                return file.Id;
            }
        }
        public List<UploadsFileDTO> GetFilesPerStudent(int id)
        {
            using (Gymnastics_Studio_DataEntities GSD = new Gymnastics_Studio_DataEntities())
            {
                return UploadsFileDTO.Convert(GSD.UploadsFiles.Where(x => x.StudentId == id).ToList());
            }
        }
    }
}
