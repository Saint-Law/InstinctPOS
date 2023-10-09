using InstinctPOS.Domain.Dtos.Category;
using InstinctPOS.Domain.Dtos.Expense;
using InstinctPOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.BusinessLogic.Interface
{
    public interface IExpense
    {
        Task<APIListResponse3<Expense>> GetExpense(int pageNumber, int pageSize);
        Task<APIResponse<Expense>> GetSingleExpense(int Id);
        Task<APIResponse<CreateExpenseDto>> CreateExpense(CreateExpenseDto request);
        Task<APIResponse<UpdateExpenseDto>> UpdateExpense(UpdateExpenseDto request);
    }
}
