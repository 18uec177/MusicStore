using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MusicStoreContext _context = null;
        public GenreRepository(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<List<GenreModel>> GetAllGenre()
        {
            return await _context.Genre.Select(g => new GenreModel()
            {
                GenreId = g.GenreId,

                Name = g.Name,

                Description = g.Description

            }).ToListAsync();
        }
    }
}
