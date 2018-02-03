using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public class AddressRepository : RepositoryBase<Address>, IAddressRepository
	{
		public AddressRepository(MyProfileDbContext context) : base(context)
		{
		}

		public List<Address> GetList(int ownerID)
		{
			return this.DbContext.Address
				.Include(a => a.Owner)
				.Where(a => a.Owner_ID == ownerID)
				.OrderByDescending(a => a.ID)
				.ToList();
		}

		public Task<List<Address>> GetListAsync(int ownerID)
		{
			return this.DbContext.Address
				.Include(a => a.Owner)
				.Where(a => a.Owner_ID == ownerID)
				.OrderByDescending(a => a.ID)
				.ToListAsync();
		}

		public override Address Find(int id)
		{
			return this.DbContext.Address
				.Include(a => a.Owner)
				.Where(a => a.ID == id)
				.FirstOrDefault();
		}

		public override Task<Address> FindAsync(int id)
		{
			return this.DbContext.Address
				.Include(a => a.Owner)
				.Where(a => a.ID == id)
				.FirstOrDefaultAsync();
		}
	}
}
