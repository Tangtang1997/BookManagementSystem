using System.Collections.Generic;
using BMS.Models.Entities;

namespace BMS.BLL.DomainService.Account.Dto
{
    public class LoginOutput
    {
        public LoginOutput()
        {
            User=new User();
        }

        public int? Id { get; set; } 
        public User User { get; set; }
        public List<string> AuthKey { get; set; }
        public bool IsSucceed { get; set; } 
    }
}