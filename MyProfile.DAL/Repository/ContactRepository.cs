using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public class ContactRepository : RepositoryBase<Contact>, IContactRepository
	{
		public ContactRepository(MyProfileDbContext context) : base(context)
		{
		}

		public List<Contact> GetList(int ownerID)
		{
			return DbContext.Contact
				.Include(c => c.Owner)
				.Include(c => c.ContactType)
				.Where(c => c.Owner_ID == ownerID)
				.OrderByDescending(c => c.ID)
				.ToList();
		}

		public Task<List<Contact>> GetListAsync(int ownerID)
		{
			return DbContext.Contact
				.Include(c => c.Owner)
				.Include(c => c.ContactType)
				.Where(c => c.Owner_ID == ownerID)
				.OrderByDescending(c => c.ID)
				.ToListAsync();
		}

		public override Contact Find(int id)
		{
			return DbContext.Contact
				.Include(c => c.Owner)
				.Include(c => c.ContactType)
				.Where(c => c.ID == id)
				.FirstOrDefault();
		}

		public override Task<Contact> FindAsync(int id)
		{
			return DbContext.Contact
				.Include(c => c.Owner)
				.Include(c => c.ContactType)
				.Where(c => c.ID == id)
				.FirstOrDefaultAsync();
		}
	}
}
