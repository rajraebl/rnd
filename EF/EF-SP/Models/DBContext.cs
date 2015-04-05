using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace EF_SP.Models
{
    public class AdContext : DbContext
    {
        public AdContext(): base("name=AdContext")
        { }

        public AdContext(string ConnStr): base(ConnStr)
        { }

        public DbSet<Email> AdSet { get; set; }

        public int SoftDeleteUserAccount(global::System.String email)
        {
            SqlParameter emailParameter;

            var p = new SqlParameter
            {
                ParameterName = "@Email",
                DbType = System.Data.DbType.String,
                Size = 150,
                Direction = System.Data.ParameterDirection.Input,
                Value = email
            };

            var l = new SqlParameter[1];
            if (email != null)
            {
                emailParameter = new SqlParameter("@Email", email);
            }
            else
            {
                emailParameter = new SqlParameter("Email", typeof(global::System.String));
            }
            l[0] = emailParameter;
            //l.Add(emailParameter);
            //return this.Database.ExecuteSqlCommand("[Identity].[SoftDeleteUserAccount] @Email='" + emailParameter +"'", emailParameter);
            //this.Database.Connection.CreateCommand()
            
            //var result = context.Database.SqlQuery<ResultForCampaign>("GetResultsForCampaign @ClientId", clientIdParameter)
             //   .ToList();

            //SqlParameter idParameter = new SqlParameter("@productId", productId);


            //var data = this.Database.SqlQuery<int>("[Identity].[SoftDeleteUserAccountx] ").First();
            var data = this.Database.SqlQuery<int>("exec [Identity].[SoftDeleteUserAccountx] @Email", p).First();


            return data;
            //return this.Database.ExecuteSqlCommand(" [Identity].[SoftDeleteUserAccount] ", p);
            //return base.ExecuteFunction("SoftDeleteUserAccount", emailParameter);

            //var context = ((IObjectContextAdapter)this).ObjectContext;
            //return context.ExecuteFunction("SoftDeleteUserAccount", emailParameter);

        }

        public int SoftDeleteUserAccountx(global::System.String email)
        {
            SqlParameter emailParameter;

            var p = new SqlParameter
            {
                ParameterName = "@Email",
                DbType = System.Data.DbType.String,
                Size = 150,
                Direction = System.Data.ParameterDirection.Input,
                Value = email
            };


            var data = 0;
            using (var db = new AdContext())
            {
                data = db.ExecuteReader("[Identity].[SoftDeleteUserAccountx] @Email", p);
            }


            return data;
        }
    }

    public static class SP
    {
        public static int ExecuteReader(this AdContext db, string sp, SqlParameter param)
        {
            using (db)
            {
                var data = db.Database.SqlQuery<int>(sp, param).First();
                return data;
            }
        }
    }

    
}