using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;

        public MovieService(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MovieModel>> GetAllAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            return _mapper.Map<List<MovieModel>>(movies);
        }

        public async Task<MovieModel> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return _mapper.Map<MovieModel>(movie);
        }
    }
}