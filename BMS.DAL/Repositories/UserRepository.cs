using BMS.BLL.IRepositories;
using BMS.DAL.EntityFrameworkCore;
using BMS.DAL.Repositories.Base;
using BMS.Models.Entities;

namespace BMS.DAL.Repositories
{
    /// <summary>
    /// User仓储，继承仓储基类，将从依赖注入容器中获取的DbContext传给父类的构造函数，供父类实例化
    ///          实现IUserRepository接口，
    /// </summary>
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }

        /*
         * AutoFacBootstrap类中已经配置好依赖关系了
         * UserRepository的实例在容器中由IUserRepository接口存储，
         * 当需要使用UserRepository的实例时只要从依赖注入容器中获取IUserRepository接口即可
         */
    }
}