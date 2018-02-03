using Microsoft.EntityFrameworkCore;
using MyProfile.Model.Entities;

namespace MyProfile.DAL
{
	public class MyProfileDbContext : DbContext
	{
		public DbSet<Owner> Owner { get; set; }
		public DbSet<Address> Address { get; set; }
		public DbSet<Experience> Experience { get; set; }
		public DbSet<Contact> Contact { get; set; }
		public DbSet<ExperienceType> ExperienceType { get; set; }
		public DbSet<ContactType> ContactType { get; set; }

		public MyProfileDbContext() : base()
		{
		}

		public MyProfileDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}
