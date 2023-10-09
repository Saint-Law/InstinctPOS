using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.Domain.Models
{
    public class Expense : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string ExpensesName { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
