using Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        public Task<List<MovieModel>> GetAllAsync();

        public Task<MovieModel> GetByIdAsync(int id);
    }
}