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
    public sealed class MovieDAL
    {

        IDBManager dbManager = new DBManager();

        internal MovieDAL() { }



        /// <summary>
        ///  Get All Active Movie
        /// </summary>
        /// <returns>List<Movie></returns>
        public async Task<IEnumerable<MovieDTO>> GetAllActiveMovie()
        {
            List<MovieDTO> lstMovieDTO = new List<MovieDTO>();
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.ExecuteReader(CommandType.StoredProcedure, "usp_GetAllActiveMovie");
                while (dbManager.DataReader.Read())
                {
                    MovieDTO objMovieDTO = new MovieDTO();
                    objMovieDTO.MovieID = DbHelper.CheckDbDecimal(dbManager.DataReader["Movie_ID"]);
                    objMovieDTO.MovieName = DbHelper.CheckDbNullString(dbManager.DataReader["Movie_Name"]);
                    objMovieDTO.Description = DbHelper.CheckDbNullString(dbManager.DataReader["Description"]);
                    objMovieDTO.ReleaseDate = DbHelper.CheckDBNullDate(dbManager.DataReader["Release_Date"]);
                    objMovieDTO.Status = DbHelper.CheckDbNullInt(dbManager.DataReader["Status"]);
                    objMovieDTO.CreatedBy = DbHelper.CheckDbNullDecimal(dbManager.DataReader["Created_By"]);
                    objMovieDTO.AverageRating = DbHelper.CheckDbInt(dbManager.DataReader["Average_Rating"]);
                    lstMovieDTO.Add(objMovieDTO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.CloseReader();
                dbManager.Dispose();
            }
            return await Task.FromResult(lstMovieDTO);
        }

        /// <summary>
        ///  Get Movie Detail By ID
        /// </summary>
        /// <returns>List<Movie></returns>
        public async Task<MovieDTO> GetMovieByID(decimal movieID)
        {
            MovieDTO objMovieDTO = null;
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(1);
                if (movieID > 0)
                    dbManager.AddParameters(0, "@Movie_ID", movieID);
                else
                    dbManager.AddParameters(0, "@Movie_ID", null);

                dbManager.ExecuteReader(CommandType.StoredProcedure, "usp_GetMovieByID");
                while (dbManager.DataReader.Read())
                {
                    objMovieDTO = new MovieDTO();
                    objMovieDTO.MovieID = DbHelper.CheckDbDecimal(dbManager.DataReader["Movie_ID"]);
                    objMovieDTO.MovieName = DbHelper.CheckDbNullString(dbManager.DataReader["Movie_Name"]);
                    objMovieDTO.Description = DbHelper.CheckDbNullString(dbManager.DataReader["Description"]);
                    objMovieDTO.ReleaseDate = DbHelper.CheckDBNullDate(dbManager.DataReader["Release_Date"]);
                    objMovieDTO.Status = DbHelper.CheckDbNullInt(dbManager.DataReader["Status"]);
                    objMovieDTO.CreatedBy = DbHelper.CheckDbNullDecimal(dbManager.DataReader["Created_By"]);
                    objMovieDTO.AverageRating = DbHelper.CheckDbInt(dbManager.DataReader["Average_Rating"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.CloseReader();
                dbManager.Dispose();
            }
            return await Task.FromResult(objMovieDTO);
        }

    }
}

