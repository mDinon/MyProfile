using System;
using System.Threading.Tasks;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public interface IRepositoryBase<TEntity> where TEntity : EntityBase
	{
		TEntity Find(int id);
		Task<TEntity> FindAsync(int id);
		TEntity Add(TEntity model);
		void Update(TEntity model);
		void Delete(TEntity model);
		void Save();
	}
}
