using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRating.DAL;
using MovieRating.DTO;

namespace MovieRating.BAL
{
    public sealed class MovieRatingBAL
    {

         internal  MovieRatingBAL() { }

        /// <summary>
        ///  Insert MovieRating
        /// </summary>
        /// <param name="objMovieRatingDTO">MovieRating</param>
        /// <returns>MovieRating</returns>
        public async Task InsertMovieRating(MovieRatingDTO objMovieRatingDTO)
        {
           await DALFactory.Instance.MovieRatingDAL.InsertMovieRating(objMovieRatingDTO);
        }

       

      
    }
}

