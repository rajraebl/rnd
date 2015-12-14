using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RU1.Models;

namespace RU1.Controllers
{
    public class QueryController : Controller
    {
        RU1Context context = new RU1Context();
        public ActionResult updateCredit(int? i)
        {
            if (i != null)
            {
                if(i<5)
                ExecuteSqlCommand(i);
                if (i == 5 || i == -5)
                    ExecuteStoreCommand(i);
                else if(i==6 || i==-6)
                {
                    ExecuteSp(i);

                }
            }
            return View();
        }

        /*http://blogs.msdn.com/b/diego/archive/2012/01/10/how-to-execute-stored-procedures-sqlquery-in-the-dbcontext-api.aspx
         Database.SqlQuery<T>() expects some kind of result set (e.g. SELECT). Under the hood, it uses DbCommand.ExecuteReader(), and when T is scalar, it expects the result set to have exactly one field -- but if the result set has more than one field, or if there are no fields, it throws the exception that you encountered.
The return value can be retrieved by passing a DbParameter to Database.SqlQuery<T>() and setting Direction = ParameterDirection.ReturnValue
            alter proc sp_UpdateCredit
            @cnt int
            as
            update course set credits = credits+@cnt
            select @@ROWCOUNT -- this line is required for ExecuteSp method
         
         */

        private void ExecuteSp(int? i)
        {
            ViewBag.Amount = i;

            var p = new SqlParameter
            {
                ParameterName = "@cnt",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                Value = i
            };

            ViewBag.RowsAffected = context.Database.SqlQuery<int>("exec [sp_UpdateCredit] @cnt", p).First();
        }
        private void ExecuteSqlCommand(int? i)
        {
            ViewBag.Amount = i;
            ViewBag.RowsAffected = context.Database.ExecuteSqlCommand("update course set credits = credits+{0}", i);
        }

        private void ExecuteStoreCommand(int? i)
        {
            ViewBag.Amount = i;
            var objectContext = (context as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext;
            var p = new SqlParameter
            {
                ParameterName = "@cnt",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                Value = i
            };

            ViewBag.RowsAffected = objectContext.ExecuteStoreCommand("exec [sp_UpdateCredit] @cnt", p);
        }

    }
}
