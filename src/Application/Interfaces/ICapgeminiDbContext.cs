using System.Threading;
using System.Threading.Tasks;
using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface ICapgeminiDbContext
    {
        DbSet<Importation> Importations { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}