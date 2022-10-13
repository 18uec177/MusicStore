using MusicStore.Data;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public interface IAlbumRepository
    {

        Task<List<AlbumModel>> GetAlbums();
        Task<List<AlbumModel>> GetAlbumsById(int id);
        Task<AlbumModel> GetAlbumsDetails(int id);

        Task<int> AddNewAlbum(Album albumModel);
        IEnumerable<Album> Albums { get; }



        //Task<int> AddNewAlbum(AlbumModel model);
        //Task<List<AlbumModel>> GetAlbumByGenre(string genre);

        //Task<List<AlbumModel>> GetAlbums();
        //Task<List<AlbumModel>> GetAlbumsById(int id);
        //string GetAppName();
        // Task<AlbumModel> GetAlbumbyid(int id);
        //List<AlbumModel> SearchBooks(string title, string authorName);
    }
}
