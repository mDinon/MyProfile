using System.Collections.Generic;
using System.Threading.Tasks;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public interface IOwnerRepository : IRepositoryBase<Owner>
	{
		List<Owner> GetList();
		Task<List<Owner>> GetListAsync();
	}
}
