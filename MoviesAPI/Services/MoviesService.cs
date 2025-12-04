using MoviesAPI.Data;
using MoviesAPI.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre,

            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public bool UpdateMovie(int id, MovieVM movieVm)
        {
            var existing = _context.Movies.Find(id);
            if (existing == null) return false;

            existing.Name = movieVm.Name;
            existing.Year = movieVm.Year;
            existing.Genre = movieVm.Genre;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteMovie(int id)
        {
            var existing = _context.Movies.Find(id);
            if (existing == null) return false;

            _context.Movies.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}
