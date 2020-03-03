using BMS.BLL.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BMS.BLL.DomainService.Base
{
    public abstract class BaseService<TEntity, TKey> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity, TKey> CurrentRepository;

        /// <summary>
        /// 派生类在构造函数中传递仓储实例
        /// </summary>
        /// <param name="repository"></param>
        protected BaseService(IRepositoryBase<TEntity, TKey> repository) => CurrentRepository = repository;

        #region 添加

        protected bool AddEntity(TEntity entity) => CurrentRepository.Insert(entity) == 1;
        protected async Task<bool> AddEntityAsync(TEntity entity) => await CurrentRepository.InsertAsync(entity) == 1;

        protected bool AddList(List<TEntity> entities) =>
            CurrentRepository.InsertCollection(entities) == entities.Count;

        protected async Task<bool> AddListAsync(List<TEntity> entities) =>
            await CurrentRepository.InsertCollectionAsync(entities) == entities.Count;

        #endregion

        #region 删除

        /// <summary>
        /// 根据Id删除一条数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected bool DeleteEntity(TKey key)
        {
            var model = CurrentRepository.FindById(key);

            return CurrentRepository.Delete(model) == 1;
        }

        protected async Task<bool> DeleteEntityAsync(TKey key)
        {
            var model = await CurrentRepository.FindByIdAsync(key);

            return await CurrentRepository.DeleteAsync(model) == 1;
        }

        protected bool DeleteEntity(TEntity entity) => CurrentRepository.Delete(entity) == 1;
        protected async Task<bool> DeleteEntityAsync(TEntity entity) => await CurrentRepository.DeleteAsync(entity) == 1;

        protected bool DeleteEntity(List<TEntity> entities) => CurrentRepository.DeleteCollection(entities) == entities.Count;

        protected async Task<bool> DeleteEntityAsync(List<TEntity> entities) =>
            await CurrentRepository.DeleteCollectionAsync(entities) == entities.Count;

        #endregion

        #region 更新

        protected bool UpdateEntity(TEntity entity) => CurrentRepository.Update(entity) == 1;
        protected async Task<bool> UpdateEntityAsync(TEntity entity) => await CurrentRepository.UpdateAsync(entity) == 1;

        protected bool UpdateEntity(List<TEntity> entities) => CurrentRepository.UpdateCollection(entities) == entities.Count;

        protected async Task<bool> UpdateEntityAsync(List<TEntity> entities) =>
            await CurrentRepository.UpdateCollectionAsync(entities) == entities.Count;

        #endregion

        #region 查询

        protected int Count(Expression<Func<TEntity, bool>> expression = null) => CurrentRepository.Count(expression);

        protected async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null) =>
            await CurrentRepository.CountAsync(expression);

        protected List<TEntity> FindAll(Expression<Func<TEntity, bool>> expression = null) =>
            CurrentRepository.FindList(expression);

        protected async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression = null) =>
            await CurrentRepository.FindListAsync(expression);

        protected TEntity FindById(TKey key) => CurrentRepository.FindById(key);
        protected async Task<TEntity> FindByIdAsync(TKey key) => await CurrentRepository.FindByIdAsync(key);

        protected TEntity Find(Expression<Func<TEntity, bool>> expression = null) =>
            CurrentRepository.FindEntity(expression);

        protected async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression = null) =>
            await CurrentRepository.FindEntityAsync(expression);

        protected IQueryable<TEntity> Load(Expression<Func<TEntity, bool>> expression = null) =>
            CurrentRepository.LoadQueryable(expression);

        protected async Task<IQueryable<TEntity>> LoadAsync(Expression<Func<TEntity, bool>> expression = null) =>
            await CurrentRepository.LoadQueryableAsync(expression);

        #endregion

    }
}
