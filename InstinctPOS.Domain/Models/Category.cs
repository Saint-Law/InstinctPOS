using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstinctPOS.Domain.Models
{
    public class Category : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Descripton { get; set; }
    }
}
