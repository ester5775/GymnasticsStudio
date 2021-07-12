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

namespace GymnasticsStudioServer.Controllers
{
    //[Route("api/[controller]/{action}")]
    
    [RoutePrefix("api/Lesson")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FilesController : ApiController
    {
        [HttpPost]
        [Route("Lesson/UploadFile")]
        FilesService FilesService = new FilesService();
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
