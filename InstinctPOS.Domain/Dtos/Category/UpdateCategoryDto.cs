using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.Domain.Dtos.Category
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; } 
        public string CategoryName { get; set; }
        public string Descripton { get; set; }
    }
}
