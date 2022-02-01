using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Incubadora.Repository.Infraestructure.Contract
{
    public interface IBaseRepository<T>
    {
        T SingleOrDefault(Expression<Func<T, bool>> whereCondition);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition);

        T Insert(T entity);

        void Update(T entity);

        void UpdateAll(IList<T> entities);

        void Delete(Expression<Func<T, bool>> whereCondition);

        bool Exists(Expression<Func<T, bool>> whereCondition);

        T SingleOrDefaultInclude(Expression<Func<T, bool>> where, string entitie);
        T SingleOrDefaultIncludes(Expression<Func<T, bool>> where, string entitie1, string entitie2);
        /// <summary>
        /// Este metodo se encarga de  consultar todas las entidades de una entidad incluyendo un catalogo relacionado en particualr
        /// </summary>
        /// <param name="where">la condicion a cumplir</param>
        /// <param name="entity">el catalogo relacionado</param>
        /// <returns>la coleccion de entidades como resultado</returns>
        IEnumerable<T> GetIncludeAll(Expression<Func<T, bool>> where, string entity);
        /// <summary>
        /// Este metodo se encarga de consultar todos los elementos de una entidad incluyendo sus relaciones especificas
        /// </summary>
        /// <param name="where">condicion a cumplir</param>
        /// <param name="entity">el catalogo relacionado</param>
        /// <param name="entity2">el catalogo relacionado</param>
        /// <param name="entity3">el catalogo relacionado</param>
       /// <returns>la coleccion de entidades como resultado</returns>
        IEnumerable<T> GetIncludeForAll(Expression<Func<T, bool>> where, string entity, string entity2, string entity3);
    }
}
