using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ui_Grid.DAL;
using log4net;

namespace ui_Grid.Api.Controllers
{
    [RoutePrefix("myAPIPrefix")]
    public class uiGridController : ApiController
    {
        private static ILog logger = LogManager.GetLogger(typeof(uiGridController));

        //db_ui_GridEntities db = new db_ui_gridEntities();
        db_ui_gridEntities db = new db_ui_gridEntities();

        [Route("GetStudents")]
        public IEnumerable<Student> Get()
        {
            //http://www.codeproject.com/Articles/140911/log-net-Tutorial
            logger.Debug("This is my log4net POC");
            logger.Error("Get method called");
            return db.Students;
        }

        [Route("GetStudentsDesc")]
        public IEnumerable<Student> getStudentDesc()
        {
            return db.Students.OrderByDescending(x => x.FirstName);
        }

        [Route("GetStudentsAsc")]
        public IEnumerable<Student> getStudentAsc()
        {
            return db.Students.OrderBy(x => x.FirstName);
        }

    }
}