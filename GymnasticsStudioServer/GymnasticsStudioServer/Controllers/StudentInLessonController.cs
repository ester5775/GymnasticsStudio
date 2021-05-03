﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DTO;
using System.Web.Http.Cors;
using Bll;

namespace GymnasticsStudioServer.Controllers
{
    //[Route("api/[controller]/{action}")]

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/StudentInLesson")]  
    public class StudentInLessonController : ApiController
    {
        // PostStudentInLessons: api/StudentInLesson
        [HttpPost]
        [Route("PostStudentInLessons/{studentId}/{date}")]
        public IHttpActionResult PostStudentInLessons( int studentId, string date, [FromBody] LessonDTO lessonDTO)
        {
            return Ok(StudentInLessonFunction.PostStudentInLessons(lessonDTO, studentId, date));
        }

    }
}
