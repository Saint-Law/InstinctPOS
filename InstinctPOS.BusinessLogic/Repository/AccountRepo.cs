using InstinctPOS.BusinessLogic.Interface;
using InstinctPOS.Domain.Dtos.Account;
using InstinctPOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.BusinessLogic.Repository
{
    public class AccountRepo : IAccount
    {
        private readonly IDbConnection _connection;

        public Task<APIResponse<UserDto>> CreateRegistration(RegistrationDto request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<TokenDto>> Login(LoginDto request)
        {
            throw new NotImplementedException();
        }
    }
}
