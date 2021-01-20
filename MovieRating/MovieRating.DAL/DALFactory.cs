using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.DAL
{
    public sealed class DALFactory
    {
        private static DALFactory instance = null;

        IDBManager dbManager = new DBManager();

        private DALFactory() { }

        /// <summary>
        /// DAL Factory object
        /// </summary>
        public static DALFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new DALFactory();
                return instance;
            }
        }

        /// <summary>
        /// MovieDAL
        /// <summary>
        public MovieDAL MovieDAL
        {
            get
            {
                return new MovieDAL();
            }
        }

        /// <summary>
        /// MovieRatingDAL
        /// <summary>
        public MovieRatingDAL MovieRatingDAL
        {
            get
            {
                return new MovieRatingDAL();
            }
        }

        /// <summary>
        /// MovieRatingDAL
        /// <summary>
        public ErrorLogsDAL ErrorLogsDAL
        {
            get
            {
                return new ErrorLogsDAL();
            }
        }
    }
}

