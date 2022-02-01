
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Incubadora.Repository.Infraestructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        internal DbSet<T> dbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            var dbResult = dbSet.Where(where.Compile()).FirstOrDefault();
            return dbResult;
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where.Compile()).AsEnumerable();
        }

        public virtual T Insert(T entity)
        {

            dynamic obj = dbSet.Add(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj;

        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            this._unitOfWork.Db.SaveChanges();
        }
        public virtual void UpdateAll(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            }
            this._unitOfWork.Db.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> entities = this.GetAll(where);
            foreach (T entity in entities)
            {
                if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            this._unitOfWork.Db.SaveChanges();
        }



        public T SingleOrDefaultOrderBy(Expression<Func<T, bool>> whereCondition, Expression<Func<T, int>> orderBy, string direction)
        {
            if (direction == "ASC")
            {
                return dbSet.Where(whereCondition).OrderBy(orderBy).FirstOrDefault();

            }
            else
            {
                return dbSet.Where(whereCondition).OrderByDescending(orderBy).FirstOrDefault();
            }
        }

        public bool Exists(Expression<Func<T, bool>> whereCondition)
        {
            return dbSet.Any(whereCondition);
        }

        public int Count(Expression<Func<T, bool>> whereCondition)
        {
            return dbSet.Where(whereCondition).Count();
        }

        public IEnumerable<T> GetPagedRecords(Expression<Func<T, bool>> whereCondition, Expression<Func<T, string>> orderBy, int pageNo, int pageSize)
        {
            return (dbSet.Where(whereCondition).OrderBy(orderBy).Skip((pageNo - 1) * pageSize).Take(pageSize)).AsEnumerable();
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters);
        }

        public IEnumerable<T> GetAllWithPageRecords(Expression<Func<T, string>> orderBy, int pageNo, int pageSize)
        {
            return (dbSet.OrderBy(orderBy).Skip((pageNo - 1) * pageSize).Take(pageSize)).AsEnumerable();
        }

        public T SingleOrDefaultInclude(Expression<Func<T, bool>> where,string entity)
        {
            var dbResult = dbSet.Include(entity).Where(where.Compile()).FirstOrDefault();
            return dbResult;
        }
        public T SingleOrDefaultIncludes(Expression<Func<T, bool>> where,string entity1, string entity2)
        {
            var dbResult = dbSet.Include(entity1).Include(entity2).Where(where.Compile()).FirstOrDefault();
            return dbResult;
        }
        /// <summary>
        /// Este metodo se encarga d econsultar una instancia de entidad , incluyendo sus elementos relacionados
        /// </summary>
        /// <param name="where">condicion de busqueda</param>
        /// <param name="entity1">entidad relacionada</param>
        /// <param name="entity2">entidad relacionada</param>
        /// <param name="entity3">entidad relacionada</param>
        /// <param name="entity4">entidad relacionada</param>
        /// <returns></returns>
        public T SingleOrDefaultForIncludes(Expression<Func<T, bool>> where, string entity1, string entity2,string entity3, string entity4)
        {
            var dbResult = dbSet.Include(entity1).Include(entity2).Include(entity3).Include(entity4).Where(where.Compile()).FirstOrDefault();
            return dbResult;
        }

        /// <summary>
        /// Este metodo se encarga de  consultar todas las entidades de una entidad incluyendo un catalogo relacionado en particualr
        /// </summary>
        /// <param name="where">la condicion a cumplir</param>
        /// <param name="entity">el catalogo relacionado</param>
        /// <returns>la coleccion de entidades como resultado</returns>
        public IEnumerable<T> GetIncludeAll(Expression<Func<T, bool>> where,string entity)
        {
            return dbSet.Include(entity).Where(where.Compile()).AsEnumerable();
        }
        /// <summary>
        /// Este metodo se encarga de consultar todos los elementos de una entidad incluyendo sus relaciones especificas
        /// </summary>
        /// <param name="where">condicion a cumplir</param>
        /// <param name="entity">el catalogo relacionado</param>
        /// <param name="entity2">el catalogo relacionado</param>
        /// <param name="entity3">el catalogo relacionado</param>
        /// <returns>la coleccion de entidades como resultado</returns>
        public IEnumerable<T> GetIncludeForAll(Expression<Func<T, bool>> where, string entity, string entity2, string entity3)
        {
            return dbSet.Include(entity).Include(entity2).Include(entity3).Where(where.Compile()).AsEnumerable();
        }
    }
}
