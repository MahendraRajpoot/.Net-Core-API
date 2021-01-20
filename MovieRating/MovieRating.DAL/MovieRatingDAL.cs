using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MovieRating.DTO;

namespace MovieRating.DAL
{
    public sealed class MovieRatingDAL
    {

        IDBManager dbManager = new DBManager();

        internal MovieRatingDAL() { }

        /// <summary>
        ///  Insert MovieRating
        /// </summary>
        /// <param name="objMovieRating">MovieRating</param>
        /// <returns>MovieRating</returns>
        public async Task InsertMovieRating(MovieRatingDTO objMovieRatingDTO)
        {
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(4);

                if (objMovieRatingDTO.MovieID > 0)
                    dbManager.AddParameters(0, "@Movie_ID", objMovieRatingDTO.MovieID);
                else
                    dbManager.AddParameters(0, "@Movie_ID", null);

                if (objMovieRatingDTO.Rating > 0)
                    dbManager.AddParameters(1, "@Rating", objMovieRatingDTO.Rating);
                else
                    dbManager.AddParameters(1, "@Rating", null);

                dbManager.AddParameters(2, "@Comment", !string.IsNullOrWhiteSpace(objMovieRatingDTO.Comment) ? objMovieRatingDTO.Comment.Trim() : null);

                if (objMovieRatingDTO.CreatedBy > 0)
                    dbManager.AddParameters(3, "@Created_By", objMovieRatingDTO.CreatedBy);
                else
                    dbManager.AddParameters(3, "@Created_By", null);

                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertMovieRating");
               // Task.Run(() => dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertMovieRating"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.Dispose();
            }
        }



    }
}

