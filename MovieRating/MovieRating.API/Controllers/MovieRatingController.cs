using Microsoft.AspNetCore.Mvc;
using MovieRating.BAL;
using MovieRating.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieRatingController : ControllerBase
    {
        [HttpPost, Route(template: "InsertRating")]
        public async Task InsertRating(MovieRatingDTO objMovieRatingDTO)
        {
            try
            {
                await BALFactory.Instance.MovieRatingBAL.InsertMovieRating(objMovieRatingDTO);
            }
            catch (Exception ex)
            {
                //Log error and return appropriate message
                BALFactory.Instance.ErrorLogsBAL.InsertErrorLogs(ex);
            }            
        }
    }
}
