using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DTO;
using System.Web.Http.Cors;
using Bll;
using System.Web;
using System.IO;

namespace GymnasticsStudioServer.Controllers
{    
    [RoutePrefix("api/File")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class FileController : ApiController
    {

        FileService FilesService = new FileService();
        [HttpPost]
        [Route("UploadFile")]
        public IHttpActionResult Upload()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                try
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath($"~/App_Data/uploads")))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath($"~/App_Data/uploads"));
                        }
                        var filePath = HttpContext.Current.Server.MapPath($"~/App_Data/uploads/{postedFile.FileName}");
                        postedFile.SaveAs(filePath);
                        return Ok(FilesService.UploadFile(filePath, postedFile.FileName));
                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }

            return Ok(false);
        }

    }
}