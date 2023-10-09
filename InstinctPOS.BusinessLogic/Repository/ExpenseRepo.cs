using AutoMapper;
using InstinctPOS.BusinessLogic.Interface;
using InstinctPOS.DataAccess.Database;
using InstinctPOS.Domain.Dtos.Expense;
using InstinctPOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.BusinessLogic.Repository
{
    public class ExpenseRepo : IExpense
    {
        private readonly IDbConnection _connection;
        private readonly ExpenseDbService service;
        private readonly IMapper _mapper;
        public ExpenseRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new ExpenseDbService(connection);
        }
        public Task<APIResponse<CreateExpenseDto>> CreateExpense(CreateExpenseDto request)
        {
            throw new NotImplementedException();
        }

        public Task<APIListResponse3<Expense>> GetExpense(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<Expense>> GetSingleExpense(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<UpdateExpenseDto>> UpdateCategory(UpdateExpenseDto request)
        {
            throw new NotImplementedException();
        }
    }
}
