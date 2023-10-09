using InstinctPOS.BusinessLogic.Interface;
using InstinctPOS.Domain.Dtos.Category;
using InstinctPOS.Domain.Dtos.Expense;
using InstinctPOS.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace InstinctPOS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpense _repo;

        public ExpenseController(IExpense repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<object> GetExpense(int pageNumber, int pageSize)
        {
            var res = await _repo.GetExpense(pageNumber, pageSize);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }

        [HttpGet]
        public async Task<object> GetSingleExpense(int Id)
        {
            var res = await _repo.GetSingleExpense(Id);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateExpense([FromBody] CreateExpenseDto request)
        {
            var res = await _repo.CreateExpense(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("06"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateExpense([FromBody] UpdateExpenseDto request)
        {
            var res = await _repo.UpdateExpense(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }
    }
}
