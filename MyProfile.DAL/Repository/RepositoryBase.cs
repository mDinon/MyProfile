using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProfile.Model.Entities;

namespace MyProfile.DAL.Repository
{
	public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
	{
		protected MyProfileDbContext DbContext { get; }

		protected RepositoryBase(MyProfileDbContext context)
		{
			DbContext = context;
		}

		public virtual TEntity Find(int id)
		{
			return DbContext.Set<TEntity>()
				.FirstOrDefault(x => x.ID == id && x.Active);
		}

		public virtual Task<TEntity> FindAsync(int id)
		{
			return DbContext.Set<TEntity>()
				.FirstOrDefaultAsync(x => x.ID == id && x.Active);
		}

		public void Save()
		{
			try
			{
				DbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				//TODO: handle and log exception
			}
		}

		public TEntity Add(TEntity model)
		{
			model.DateCreated = DateTime.Now;
			model.Active = true;

			DbContext.Set<TEntity>().Add(model);

			Save();
			return model;
		}

		public void Update(TEntity model)
		{
			model.DateModified = DateTime.Now;

			DbContext.Entry(model).State = EntityState.Modified;

			Save();
		}

		public virtual void Delete(TEntity model)
		{
			model.Active = false;
			model.DateModified = DateTime.Now;

			DbContext.Entry(model).State = EntityState.Modified;

			Save();
		}
	}
}
