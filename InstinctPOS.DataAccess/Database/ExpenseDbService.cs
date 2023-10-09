using Dapper;
using InstinctPOS.Domain.Models;
using InstinctPOS.Domain.Ultility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.DataAccess.Database
{
    public class ExpenseDbService
    {
        private readonly IDbConnection _connection;

        public ExpenseDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateExpense(Expense request)
        {
            try
            {
                var query = @"[InsertInto_Expense]";
                var param = new
                {
                    ExpensesName = request.ExpensesName,
                    Amount = request.Amount,
                    Description = request.Description,
                    CreatedBy = request.CreatedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<Expense> SingleExpense(int Id)
        {
            Expense expenses = new Expense();
            try
            {
                var query = @"[GetExpense]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Expense>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements")) 
                    return expenses;
            }
            return null;
        }


        public async Task<APIListResponse3<Expense>>  GetExpenses(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Expense>();
            try
            {
                var query = @"[GetAllExpenses]";
                var param = new {pageNumber = pageNumber, pageSize = pageSize};
                var result = await _connection.QueryAsync<Expense>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Expense>.ToPagedList(result, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contatins no elements"))
                {
                    response.Code = "01";
                }
            }
            return response;
        }


        public async Task<int> UpdateExpense(Expense request)
        {
            try
            {
                var query = @"[Update_Expense]";
                var param = new
                {
                    ExpensesName = request.ExpensesName,
                    Amount = request.Amount,
                    Description = request.Description,
                    ModifiedBy = request.ModifiedBy,
                    Id = request.Id
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
 
    }
}
