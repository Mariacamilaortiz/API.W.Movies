using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;
using API.W.Movies.Repository.IRepository;
using API.W.Movies.Services.IServices;
using AutoMapper;

namespace API.W.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _repo.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _repo.GetMovieAsync(id);
            if (movie == null)
                throw new InvalidOperationException($"No se encontró la película con ID '{id}'");

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto dto)
        {
            var exists = await _repo.MovieExistsByNameAsync(dto.Name);

            if (exists)
                throw new InvalidOperationException($"Ya existe una película con el nombre '{dto.Name}'");

            var movie = _mapper.Map<Movie>(dto);

            var created = await _repo.CreateMovieAsync(movie);

            if (!created)
                throw new Exception("Error al crear la película");

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            var movie = await _repo.GetMovieAsync(id);

            if (movie == null)
                throw new InvalidOperationException($"No se encontró la película con ID '{id}'");

            var nameExists = await _repo.MovieExistsByNameAsync(dto.Name);

            if (nameExists && movie.Name != dto.Name)
                throw new InvalidOperationException($"Ya existe una película con el nombre '{dto.Name}'");

            _mapper.Map(dto, movie);

            var updated = await _repo.UpdateMovieAsync(movie);

            if (!updated)
                throw new Exception("Error al actualizar la película");

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _repo.GetMovieAsync(id);

            if (movie == null)
                throw new InvalidOperationException($"No se encontró la película con ID '{id}'");

            return await _repo.DeleteMovieAsync(id);
        }

        public Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MovieExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
