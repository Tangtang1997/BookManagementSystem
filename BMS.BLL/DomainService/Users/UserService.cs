using BMS.BLL.DomainService.Base;
using BMS.BLL.IRepositories;
using BMS.Models.Entities;
using BMS.Models.ViewModels.CRUD;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMS.BLL.DomainService.Users
{
    public class UserService : BaseService<User, int>, IUserService
    {

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            //直接使用父类的方法
            var users = await FindAllAsync(x => x.LoginName != "admin");
            return MapToViewModelList(users);

            //或者使用仓储查询
            //var userList=await _userRepository.FindListAsync(x => x.LoginName != "admin"); 
            //return MapToViewModelList(userList);
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            return MapToViewModel(await FindByIdAsync(id));
        }

        public async Task<bool> AddAsync(UserViewModel userViewModel)
        {
            return await AddAsync(MapToUser(userViewModel));
        }

        public async Task<bool> UpdateAsync(UserViewModel userViewModel)
        {
            return await UpdateAsync(MapToUser(userViewModel));
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var user = await FindByIdAsync(id);

            return await DeleteAsync(user);
        }

        /// <summary>
        /// 将<see cref="User"/> 对象转换成<see cref="UserViewModel"></see>对象
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private static UserViewModel MapToViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LoginName = user.LoginName,
                PassWord = user.PassWord,
                Address = user.Address,
                Age = user.Age,
                IdNumber = user.IdNumber,
                Gender = user.Gender
            };
        }

        /// <summary>
        /// 将<see cref="UserViewModel"/> 对象转换成<see cref="User"></see>对象
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        private static User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Address = userViewModel.Address,
                Age = userViewModel.Age,
                LoginName = userViewModel.LoginName,
                PassWord = userViewModel.PassWord,
                IdNumber = userViewModel.IdNumber,
                Gender = userViewModel.Gender
            };
        }

        /// <summary>
        /// 将<see cref="IEnumerable&lt;User&gt;"/> 集合转换为<see cref="List&lt;UserViewModel&gt;"/>集合
        /// </summary>
        /// <returns></returns>
        private static List<UserViewModel> MapToViewModelList(IEnumerable<User> users)
        {
            return users.Select(item => new UserViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                Age = item.Age,
                LoginName = item.LoginName,
                PassWord = item.PassWord,
                IdNumber = item.IdNumber,
                Gender = item.Gender
            })
                .ToList();
        }
    }
}
