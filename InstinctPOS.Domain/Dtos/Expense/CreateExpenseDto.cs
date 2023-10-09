using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.Domain.Dtos.Expense
{
    public class CreateExpenseDto
    {
        public string ExpensesName { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; } 
    }
}
