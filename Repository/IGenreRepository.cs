using MusicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public interface IGenreRepository
    {
        Task<List<GenreModel>> GetAllGenre();
    }
}