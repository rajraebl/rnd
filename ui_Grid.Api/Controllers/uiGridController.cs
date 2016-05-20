using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ui_Grid.DAL;


namespace ui_Grid.Api.Controllers
{
    [RoutePrefix("myAPIPrefix")]
    public class uiGridController : ApiController
    {
        //db_ui_GridEntities db = new db_ui_gridEntities();
        db_ui_gridEntities db = new db_ui_gridEntities();

        [Route("GetStudents")]
        public IEnumerable<Student> Get()
        {
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