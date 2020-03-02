using System.Threading.Tasks;
using BMS.BLL.DomainService.Account.Dto;

namespace BMS.BLL.DomainService.Account
{
    public interface IAccountService
    {
        Task<LoginOutput> IsLoginAsync(LoginInput loginInput);
    }
}