using InstinctPOS.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace InstinctPOS.DataAccess
{
    public interface IApplicationDbContext
    {
       DbSet<Expense> Expenses { get; set; }
       DbSet<Category> Categories { get; set; }

       Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
