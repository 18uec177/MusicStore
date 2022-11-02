using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public class ArtistRepository : IArtistRepository
    {
       
       
            private readonly MusicStoreContext _context = null;
            public ArtistRepository(MusicStoreContext context)
            {
                _context = context;
            }


            public async Task<List<Artist>> GetArtists()
            {
                return await _context.Artist.Select(g => new Artist()
                {
                    ArtistId = g.ArtistId,
                    Name = g.Name,

                }).ToListAsync();
            }
        }
    }


