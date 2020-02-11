using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    /// <summary> Represents a movie.</summary>
    public class Movie
    {/// <summary> Run length in minutes.</summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _title;

        /// <summary> Run length in minutes.</summary>
        public int runLength;
        /// <summary> Run length in minutes.</summary>
        public string description;
        /// <summary> Run length in minutes.</summary>
        public int releaseYear = 1900;
        /// <summary> Run length in minutes.</summary>
        public bool isClassic;

    }
}
