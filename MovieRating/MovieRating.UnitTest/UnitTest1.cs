using MovieRating.API.Controllers;
using MovieRating.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MovieRating.UnitTest
{
    public class UnitTest1
    {
        MovieController objMovieController;
        [Fact]
        public async Task ValidateReturnTypes()
        {
            objMovieController = new MovieController();
            var okResult = await objMovieController.GetAllMovie();
            Assert.IsType<List<MovieDTO>>(okResult);
        }

        [Fact]
        public async Task ValidateDataCount()
        {
            objMovieController = new MovieController();
            var okResult = await objMovieController.GetAllMovie();
            var viewResult = Assert.IsType<List<MovieDTO>>(okResult);
            Assert.Equal(10, viewResult.Count);
        }
    }
}
