using System.Collections.Generic;
using System.Threading.Tasks;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public interface IContactRepository : IRepositoryBase<Contact>
	{
		List<Contact> GetList(int ownerID);
		Task<List<Contact>> GetListAsync(int ownerID);
	}
}
