using InstinctPOS.Domain.Dtos.Account;
using InstinctPOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.BusinessLogic.Interface
{
    public interface IAccount
    {
        Task<APIResponse<TokenDto>> Login(LoginDto request);
        Task<APIResponse<UserDto>> CreateRegistration(RegistrationDto request);
    }
}
