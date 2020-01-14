using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config;

        public MoviesController()
        {
            _context = new MyDbContext();
            _config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = _config.CreateMapper();
        }

        public IHttpActionResult GetMovies()
        {
            IEnumerable<MovieDto> movies = _context.Movies
                .ToList()
                .Select(_mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies
                .Select(_mapper.Map<Movie, MovieDto>)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return Content(HttpStatusCode.NotFound, $"Movie with Id {id} not found");

            return Ok(movie);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Movie movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return Content(HttpStatusCode.NotFound, $"Movie with Id {id} not found");

            movieDto.Id = movieInDb.Id;
            _mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return Content(HttpStatusCode.NotFound, $"Movie with Id {id} not found");

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}