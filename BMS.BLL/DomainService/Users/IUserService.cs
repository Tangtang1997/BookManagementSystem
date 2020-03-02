using System.Collections.Generic;
using System.Threading.Tasks;
using BMS.Models.ViewModels.CRUD;

namespace BMS.BLL.DomainService.Users
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllAsync();

        Task<UserViewModel> GetByIdAsync(int id);

        Task<bool> AddAsync(UserViewModel userViewModel);

        Task<bool> UpdateAsync(UserViewModel userViewModel);

        Task<bool> DeleteByIdAsync(int id);
    }
}
