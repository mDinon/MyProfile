using System.Collections.Generic;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public interface IExperienceRepository : IRepositoryBase<Experience>
	{
		List<Experience> GetList(int ownerID);
	}
}
