using System.Threading.Tasks;
using BMS.BLL.DomainService.Account.Dto;
using BMS.BLL.DomainService.Base;
using BMS.BLL.IRepositories.Base;
using BMS.Models.Entities;

namespace BMS.BLL.DomainService.Account
{
    public class AccountService : BaseService<User, int>, IAccountService
    {
        public AccountService(IRepositoryBase<User, int> repository)
            : base(repository)
        {
        }
         
        public async Task<LoginOutput> IsLoginAsync(LoginInput loginInput)
        {
            var user = await FindAsync(x => x.LoginName == loginInput.LoginName && x.PassWord == loginInput.PassWord);

            if (user != null)
            {
                return new LoginOutput
                {
                    Id = user.Id,
                    User = user,
                    IsSucceed = true
                };
            }

            return new LoginOutput();
        }
    }
}