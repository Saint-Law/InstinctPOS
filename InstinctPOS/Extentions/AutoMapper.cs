using AutoMapper;
using InstinctPOS.Domain.Dtos.Account;
using InstinctPOS.Domain.Dtos.Expense;
using InstinctPOS.Domain.Models;

namespace InstinctPOS.Extentions
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Expense, CreateExpenseDto>();
            CreateMap<CreateExpenseDto, Expense>();
            CreateMap<Expense, UpdateExpenseDto>();
            CreateMap<UpdateExpenseDto, Expense>();

            CreateMap<User, UserDto>();
            CreateMap<User, RegistrationDto>();

        }
    }
}
