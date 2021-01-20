using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRating.DAL;
using MovieRating.DTO;

namespace MovieRating.BAL
{
    public sealed class MovieBAL
    {

        internal MovieBAL() { }

       

        /// <summary>
        ///  Get All Active Movie
        /// </summary>
        /// <returns>List<MovieDTO></returns>
        public async Task<IEnumerable<MovieDTO>> GetAllActiveMovie()
        {
            return await DALFactory.Instance.MovieDAL.GetAllActiveMovie();
        }

        /// <summary>
        ///  Get Movie Detail By ID
        /// </summary>
        /// <returns>List<Movie></returns>
        public async Task<MovieDTO> GetMovieByID(decimal movieID)
        {
            return await DALFactory.Instance.MovieDAL.GetMovieByID(movieID);
        }
    }
}

