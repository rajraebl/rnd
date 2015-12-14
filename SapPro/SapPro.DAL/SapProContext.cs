using System.Data.Entity;
using SapPro.Entity;

namespace SapPro.DAL
{
    public class SapProContext : DbContext
    {
        public DbSet<Product> tblProduct { get; set; }
    }
}
