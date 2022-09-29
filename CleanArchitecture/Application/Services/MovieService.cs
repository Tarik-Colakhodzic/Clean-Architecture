using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Mapper;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IApplicationDBContext _context;

        public MovieService(IApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<MovieModel>> GetAllAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            return ObjectMapper.Mapper.Map<List<MovieModel>>(movies);
        }

        public async Task<MovieModel> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return ObjectMapper.Mapper.Map<MovieModel>(movie);
        }
    }
}