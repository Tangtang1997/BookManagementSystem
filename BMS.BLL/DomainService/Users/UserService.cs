using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
            : base(userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            //直接使用父类的方法
            var users = await FindAllAsync(x => x.LoginName != "admin");
            return _mapper.Map<List<UserViewModel>>(users);

            //或者使用仓储查询
            //var userList=await _userRepository.FindListAsync(x => x.LoginName != "admin"); 
            //return MapToViewModelList(userList);
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<UserViewModel>(await FindByIdAsync(id));
        }

        public async Task<bool> AddAsync(UserViewModel userViewModel)
        {
            return await AddEntityAsync(MapToUser(userViewModel));
        }

        public async Task<bool> UpdateAsync(UserViewModel userViewModel)
        {
            return await UpdateEntityAsync(MapToUser(userViewModel));
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var user = await FindByIdAsync(id);

            return await DeleteEntityAsync(user);
        }

        private User MapToUser(UserViewModel userViewModel)
        {
            return _mapper.Map<User>(userViewModel);
        }
    }
}
