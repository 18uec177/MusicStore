using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public class AlbumRepository : IAlbumRepository
    {

        private readonly MusicStoreContext _context = null;

        public AlbumRepository(MusicStoreContext context)
        {
            _context = context;
         

        }
        //public async Task<int> AddNewAlbum(Album model)
        //{
        //    var newAlbum = new Album()
        //    {

        //        Title = model.Title,
        //       Price = model.Price,
        //       Artist = model.Artist,
        //       Genre = model.Genre,

        //    };




        //    await _context.Album.AddAsync(newAlbum);
        //    await _context.SaveChangesAsync();

        //    return newAlbum.AlbumId;
        //}

        //public Task<int> AddNewAlbum(AlbumModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<AlbumModel>> GetAlbumByGenre(string genre)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<AlbumModel>> GetAlbumsById(int Id)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<List<AlbumModel>> GetAlbums()
        //{
        //    return await _context.Album.Select(album => new AlbumModel()
        //    {

        //        Title = album.Title,
        //        Price = album.Price
        //    }).ToListAsync();

        //}

      
            public IEnumerable<Album> Albums => _context.Album.Include(a => a.Artist)
                    .Include(a => a.Genre);
            public async Task<int> AddNewAlbum(Album model)
            {
                var newAlbum = new Album()
                {
                    AlbumId = model.AlbumId,
                    Title = model.Title,
                    Price = model.Price,
                    AlbumArtUrl = model.AlbumArtUrl,
                    GenreId = model.GenreId,
                    ArtistId = model.ArtistId

                };

                await _context.Album.AddAsync(newAlbum);
                await _context.SaveChangesAsync();

                return newAlbum.AlbumId;
            }
            public async Task<List<AlbumModel>> GetAlbums()
            {
                return await _context.Album.Select(album => new AlbumModel()
                {
                    AlbumId = album.AlbumId,
                    Title = album.Title,
                    Price = album.Price,
                    AlbumArtUrl = album.AlbumArtUrl,
                    //Genre = album.Genre.Name,
                    //Artist = album.Artist.Name
                }).ToListAsync();

            }

            public async Task<List<AlbumModel>> GetAlbumsById(int id)
            {
                return await _context.Album.Where(x => x.Genre.GenreId == id).Select(g => new AlbumModel()
                {
                    AlbumId = g.AlbumId,
                    Title = g.Title,
                    Price = g.Price,
                    AlbumArtUrl = g.AlbumArtUrl,
                    Genre = g.Genre.Name,
                    Artist = g.Artist.Name

                }).ToListAsync();

            }

            public async Task<AlbumModel> GetAlbumsDetails(int id)
            {
                return await _context.Album.Where(x => x.AlbumId == id).Select(g => new AlbumModel()
                {
                    AlbumId = g.AlbumId,
                    Title = g.Title,
                    Price = g.Price,
                    AlbumArtUrl = g.AlbumArtUrl,
                    Genre = g.Genre.Name,
                    Artist = g.Artist.Name

                }).FirstOrDefaultAsync();
            }



    }
}


