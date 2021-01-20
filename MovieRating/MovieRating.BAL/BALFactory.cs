using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.BAL
{
    public sealed class BALFactory
    {
        private static BALFactory instance = null;

        private BALFactory() { }

        /// <summary>
        /// BAL Factory object
        /// </summary>
        public static BALFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new BALFactory();
                return instance;
            }
        }

        /// <summary>
        /// MovieBAL
        /// <summary>
        public MovieBAL MovieBAL
        {
            get
            {
                return new MovieBAL();
            }
        }

        /// <summary>
        /// MovieRatingBAL
        /// <summary>
        public MovieRatingBAL MovieRatingBAL
        {
            get
            {
                return new MovieRatingBAL();
            }
        }

        /// <summary>
        /// ErrorLogsBAL
        /// <summary>
        public ErrorLogsBAL ErrorLogsBAL
        {
            get
            {
                return new ErrorLogsBAL();
            }
        }
    }
}

