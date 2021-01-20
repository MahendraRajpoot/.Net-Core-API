using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRating.BAL;
using MovieRating.DTO;
using Microsoft.Extensions.Logging;

namespace MovieRating.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        [HttpGet, Route(template: "GetAllMovie")]
        public async Task<IEnumerable<MovieDTO>> GetAllMovie()
        {
            try
            {
                return await BALFactory.Instance.MovieBAL.GetAllActiveMovie();
            }
            catch (Exception ex)
            {
                BALFactory.Instance.ErrorLogsBAL.InsertErrorLogs(ex);
            }
            return new List<MovieDTO>();
        }

        [HttpGet, Route(template: "GetMovieByID/{movieID}")]
        public async Task<MovieDTO> GetMovieByID(string movieID)
        {
            try
            {
                decimal.TryParse(movieID, out decimal decMovieID);
                return await BALFactory.Instance.MovieBAL.GetMovieByID(decMovieID);
            }
            catch (Exception ex)
            {
                BALFactory.Instance.ErrorLogsBAL.InsertErrorLogs(ex);
            }
            return new MovieDTO();
        }
    }
}
