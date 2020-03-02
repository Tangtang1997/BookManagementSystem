using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using BMS.BLL.IRepositories.Base;
using BMS.DAL.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMS.DAL.Repositories.Base
{
    /// <summary>
    /// 仓储基类
    /// 所有仓储都要继承此类，并在构造函数中传递DbContext
    /// </summary>
    /// <typeparam name="TEntity">泛型实体</typeparam> 
    /// <typeparam name="TKey">主键</typeparam>
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// 有参构造函数，供派生类调用
        /// </summary>
        /// <param name="dbContext"></param>
        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        /// <summary>
        /// 单例模式获取DbContext
        /// </summary>
        /// <returns></returns>
        public DbContext GetContext()
        {
            var dbContextName = typeof(DbContext).Name;

            if (CallContext.GetData(dbContextName) is DbContext dbContext)
                return dbContext;

            dbContext = new ApplicationDbContextFactory().CreateDbContext(null);
            CallContext.SetData(dbContextName, dbContext);

            return dbContext;
        }

        /// <summary>
        /// 将对实体的操作保存到数据库,返回受影响的行数
        /// </summary>
        /// <returns></returns>
        private int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
        /// <summary>
        /// （异步版本）将对实体的操作保存到数据库,返回受影响的行数
        /// </summary>
        /// <returns></returns>
        private async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        #region 查询

        /// <summary>
        /// 根据条件查询数量，返回int值
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? DbSet.Count()
                : DbSet.Count(predicate);
        }
        /// <summary>
        /// （异步版本）根据条件查询数量，返回int值
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? await DbSet.CountAsync()
                : await DbSet.CountAsync(predicate);
        }

        /// <summary>
        /// 根据主键查询单个对象，返回单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity FindById(TKey id)
        {
            return DbSet.Find(id);
        }
        /// <summary>
        /// （异步版本）根据主键查询单个对象，返回单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindByIdAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        /// 根据条件查询一条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }
        /// <summary>
        ///（异步版本） 根据条件查询一条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 获取一个集合，返回一个list
        /// </summary>
        /// <returns></returns>
        public List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? DbSet.ToList()
                : DbSet.Where(predicate).ToList();
        }
        /// <summary>
        ///（异步版本） 获取一个集合，返回一个list
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? await DbSet.ToListAsync()
                : await DbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> LoadQueryable(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? DbSet.AsQueryable()
                : DbSet.Where(predicate);
        }
        public async Task<IQueryable<TEntity>> LoadQueryableAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? await Task.FromResult(DbSet.AsQueryable())
                : await Task.FromResult(DbSet.Where(predicate));
        }

        #endregion

        #region 添加

        /// <summary>
        /// 插入一条数据,返回受影响的行数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(TEntity entity)
        {
            DbSet.Add(entity);
            return SaveChanges();
        }
        /// <summary>
        /// （异步版本）插入一条数据,返回受影响的行数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return await SaveChangesAsync();
        }

        /// <summary>
        /// 插入一个集合,返回受影响的行数
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int InsertCollection(IEnumerable<TEntity> entities)
        {
            var count = 0;

            entities.ToList().ForEach(x => count += Insert(x));

            return count;
        }
        /// <summary>
        /// （异步版本）插入一个集合,返回受影响的行数
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<int> InsertCollectionAsync(IEnumerable<TEntity> entities)
        {
            var count = 0;

            entities.ToList().ForEach(async x => count += await InsertAsync(x));

            return await Task.FromResult(count);
        }

        #endregion

        #region 更新

        /// <summary>
        /// 更新一条数据,返回受影响的行数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(TEntity entity)
        {
            DbSet.Update(entity);
            return SaveChanges();
        }
        public async Task<int> UpdateAsync(TEntity entity)
        {
            return await Task.FromResult(Update(entity));
        }

        /// <summary>
        /// 更新一个集合,返回受影响的行数
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int UpdateCollection(IEnumerable<TEntity> entities)
        {
            var count = 0;

            entities.ToList().ForEach(x =>
            {
                count += Update(x);
            });

            return count;
        }
        public async Task<int> UpdateCollectionAsync(IEnumerable<TEntity> entities)
        {
            var count = 0;

            entities.ToList().ForEach(async x =>
            {
                count += await UpdateAsync(x);
            });

            return await Task.FromResult(count);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除一条数据,返回受影响的行数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            return SaveChanges();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            return await Task.FromResult(Delete(entity));
        }

        /// <summary>
        /// 删除一个集合,返回受影响的行数
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int DeleteCollection(IEnumerable<TEntity> entities)
        {
            var count = 0;

            entities.ToList().ForEach(x =>
            {
                count += Delete(x);
            });

            return count;
        }
        public async Task<int> DeleteCollectionAsync(IEnumerable<TEntity> entities)
        {
            return await Task.FromResult(DeleteCollection(entities));
        }

        #endregion

        #region 执行sql语句

        /// <summary>
        /// 执行添加、更新、删除的sql语句
        /// </summary>
        /// <param name="executeSql">sql语句</param>
        /// <param name="parameters">SqlParameter参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteSqlCommand(string executeSql, params object[] parameters)
        {
            return DbContext.Database.ExecuteSqlRaw(executeSql, parameters);
        }
        public Task<int> ExecuteSqlCommandAsync(string executeSql, params object[] parameters)
        {
            return Task.FromResult(ExecuteSqlCommand(executeSql, parameters));
        }

        /// <summary>
        /// 执行查询sql语句 注意:始终对原始 SQL 查询使用参数化!
        /// </summary>
        /// <param name="querySql">sql语句</param>
        /// <param name="parameters">SqlParameter参数数组</param>
        /// <returns>IQueryable</returns>
        public IQueryable<TEntity> FromSqlRaw(string querySql, params object[] parameters)
        {
            return DbSet.FromSqlRaw(querySql, parameters);
        }
        public async Task<IQueryable<TEntity>> FromSqlRawAsync(string querySql, params object[] parameters)
        {
            return await Task.FromResult(FromSqlRaw(querySql, parameters));
        }

        /// <summary>
        /// 执行带有内插字符串的sql查询语句
        /// 使用示例：
        /// <code>var id=1;</code>
        /// <code>_repository.FromSqlRaw( $"SELECT * FROM Table WHERE Id= {id} ");</code>
        /// </summary>
        /// <param name="formattableString">带有内插字符串的sql语句</param>
        /// <returns>IQueryable</returns>
        public IQueryable<TEntity> FromSqlInterpolated(FormattableString formattableString)
        {
            return DbSet.FromSqlInterpolated(formattableString);
        }
        public async Task<IQueryable<TEntity>> FromSqlInterpolatedAsync(FormattableString formattableString)
        {
            return await Task.FromResult(FromSqlInterpolated(formattableString));
        }

        #endregion 

    }
}