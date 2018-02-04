using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public interface IAddressRepository : IRepositoryBase<Address>
	{
		List<Address> GetList(int ownerID);
		Task<List<Address>> GetListAsync(int ownerID);
	}
}
