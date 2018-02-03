using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public class ExperienceRepository : RepositoryBase<Experience>, IExperienceRepository
	{
		public ExperienceRepository(MyProfileDbContext context) : base(context)
		{
		}

		public List<Experience> GetList(int ownerID)
		{
			return DbContext.Experience
				.Include(e => e.Owner)
				.Include(e => e.ExperienceType)
				.Where(e => e.Owner_ID == ownerID)
				.OrderByDescending(e => e.ID)
				.ToList();
		}

		public override Experience Find(int id)
		{
			return DbContext.Experience
				.Include(e => e.Owner)
				.Include(e => e.ExperienceType)
				.Where(e => e.ID == id)
				.FirstOrDefault();
		}
	}
}
