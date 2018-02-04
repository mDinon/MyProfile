using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
				.Where(e => e.Owner_ID == ownerID && e.Active)
				.OrderByDescending(e => e.ID)
				.ToList();
		}

		public Task<List<Experience>> GetListAsync(int ownerID)
		{
			return DbContext.Experience
				.Include(e => e.Owner)
				.Include(e => e.ExperienceType)
				.Where(e => e.Owner_ID == ownerID && e.Active)
				.OrderByDescending(e => e.ID)
				.ToListAsync();
		}

		public override Experience Find(int id)
		{
			return DbContext.Experience
				.Include(e => e.Owner)
				.Include(e => e.ExperienceType)
				.FirstOrDefault(e => e.ID == id && e.Active);
		}

		public override Task<Experience> FindAsync(int id)
		{
			return DbContext.Experience
				.Include(e => e.Owner)
				.Include(e => e.ExperienceType)
				.FirstOrDefaultAsync(e => e.ID == id && e.Active);
		}
	}
}
