using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class FileService
    {
        public int UploadFile(string filePath, string fileName)
        {
            using (Gymnastics_Studio_DataEntities GSDE = new Gymnastics_Studio_DataEntities())
            {
                var file = GSDE.UploadsFiles.Add(new UploadsFile()
                {
                    Name = fileName,
                    Path = filePath
                });
                GSDE.SaveChanges();
                return file.Id;
            }
        }

    }
}
