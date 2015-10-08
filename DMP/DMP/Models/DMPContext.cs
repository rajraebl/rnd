using System.Data.Entity;


namespace DMP.Models
{
    public class DMPContext : DbContext
    {
        public DMPContext() : base("name=DMPContext")
        {

        }

        public DbSet<Member> MemberSet { get; set; }
        public DbSet<Message> MessageSet { get; set; }
        public DbSet<Profile> ProfileSet { get; set; }
        public DbSet<Demographics> DemographicsSet { get; set; }
        public DbSet<Favourite> FavouriteSet { get; set; }
        public DbSet<Interest> InterestSet { get; set; }
        public DbSet<InterestType> InterestTypeSet { get; set; }
        public DbSet<Photo> PhotoSet { get; set; }
    }
}