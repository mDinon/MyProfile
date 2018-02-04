using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
	{
		public OwnerRepository(MyProfileDbContext context) : base(context)
		{
		}

		public List<Owner> GetList()
		{
			return DbContext.Owner
				.Where(o => o.Active)
				.OrderByDescending(o => o.ID)
				.ToList();
		}

		public Task<List<Owner>> GetListAsync()
		{
			return DbContext.Owner
				.Where(o => o.Active)
				.OrderByDescending(o => o.ID)
				.ToListAsync();
		}

		public override Owner Find(int id)
		{
			return DbContext.Owner
				.FirstOrDefault(o => o.ID == id && o.Active);
		}
	}
}
