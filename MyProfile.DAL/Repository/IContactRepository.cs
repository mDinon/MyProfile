using System.Collections.Generic;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public interface IContactRepository : IRepositoryBase<Contact>
	{
		List<Contact> GetList(int ownerID);
	}
}
