using AutoMapper;
using InstinctPOS.BusinessLogic.Interface;
using InstinctPOS.DataAccess.Database;
using InstinctPOS.Domain.Dtos.Expense;
using InstinctPOS.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
        public async Task<APIResponse<CreateExpenseDto>> CreateExpense(CreateExpenseDto request)
        {
            var response = new APIResponse<CreateExpenseDto>();
            var model = _mapper.Map<Expense>(request);
            var result = await service.CreateExpense(model);

            if(result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else if(result == -1)
            {
                response.Code = "01";
                response.Description = "Record Already Exist";
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occuried, Please try again later";
            }
            return response;
        }

        public async Task<APIListResponse3<Expense>> GetExpense(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Expense>();
            var result = await service.GetExpenses(pageNumber, pageSize);
            if(result != null)
            {
                if(result.Data.Count() > 0)
                {
                    var metadata = new
                    {
                        result.Data.TotalCount,
                        result.Data.PageSize,
                        result.Data.CurrentPage,
                        result.Data.TotalPages,
                        result.Data.HasNext,
                        result.Data.HasPrevious
                    };
                    response.PageInfo = JsonConvert.SerializeObject(metadata);
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result.Data;
                }
                else
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occured, Please try again later";
            }
            return response;
        }

        public async Task<APIResponse<Expense>> GetSingleExpense(int Id)
        {
            var response = new APIResponse<Expense>();
            var result = await service.SingleExpense(Id);
            
            if(result != null)
            {
               if(result.Id == 0)
                {
                    response.Code = "01";
                    response.Description = "No Record found";
                }
                else
                {
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result;
                }
            }
            else
            {
                response.Code = "01";
                response.Description = "No Record found";
            }
            return response;
        }



        public async Task<APIResponse<UpdateExpenseDto>> UpdateExpense(UpdateExpenseDto request)
        {
            var response = new APIResponse<UpdateExpenseDto>();
            var model = _mapper.Map<Expense>(request);
            var result = await service.UpdateExpense(model);

            if(result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occured, Please try again later";
            }
            return response;
        }
    }
}
