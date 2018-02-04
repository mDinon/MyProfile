using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public interface IExperienceRepository : IRepositoryBase<Experience>
	{
		List<Experience> GetList(int ownerID);
		Task<List<Experience>> GetListAsync(int ownerID);
	}
}
