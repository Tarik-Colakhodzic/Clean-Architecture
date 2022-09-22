using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<Movie> Movies { get; set; }

        Task<int> SaveChangesAsync();
    }
}