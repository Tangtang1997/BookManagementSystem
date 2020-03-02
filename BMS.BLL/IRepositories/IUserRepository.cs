using BMS.BLL.IRepositories.Base;
using BMS.Models.Entities;

namespace BMS.BLL.IRepositories
{
    /*
     *  User表仓储接口
     * （新建的仓储接口都要继承IRepositoryBase<TEntity,TKey>接口，并把TEntity替换为当前的实体，把TKey替换为当前实体的主键）
     */
    public interface IUserRepository : IRepositoryBase<User, int>
    {

    }
}