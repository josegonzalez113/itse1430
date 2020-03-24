﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    /// <summary> Represents a movie.</summary>
    public class Movie : IValidatableObject
    {/// <summary> Gets or set the title.</summary>

        public Genre Genre { get; set; }
        public string Title
        {
            get 
            {
                // Long long way
                /*if(_title == null)
                return "";
                return _title;*/

                //Long way
                //return(_title != null) ? _title: "");

                //Correct way
                return _title ?? "";
            }
            set { _title = value?.Trim(); }
        }
        private string _title;

        /// <summary> Gets or sets the run length in minutes.</summary>
        /*public int RunLength
        {
            get { return _runLength; }
            set { _runLength = value; }
        }
        private int _runLength;*/

        public int RunLength { get; set; }

        /// <summary> Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }
        private string _description;

        /// <summary> Gets or sets release year.</summary>
        /// <summary> Default 1900.</summary>
        /*public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }
        private int _releaseYear;*/

        public int ReleaseYear { get; set; } = 1900;

        /// <summary> Determines if this is a classic.</summary>
       /* public bool IsClassic
        {
            get { return _isClassic; }
            set { _isClassic = value; }
        }
        private bool _isClassic;*/

        public bool IsClassic { get; set; }

        public bool isBlackAndWhite
        {
            get { return ReleaseYear <= 1930; }
        }

        /*public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        private int _id;*/

        public int Id { get; set; }

        public override string ToString ()
        {
            return Title;
        }
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //Title is required
            //if (txtTitle.Text?.Trim() == "")
            if (String.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult("Title is required", new[] { nameof(Title)});
                //error = "Title is required";
            };

            // Run Length has to be >=0
            if (RunLength < 0)
            {
                yield return new ValidationResult("Run Length has to be >= to zero", new[] { nameof(RunLength) });
                //error = "Run Length has to be >= to zero";
            };

            //Release Year >= 1900
            if (ReleaseYear < 1900)
            {
                yield return new ValidationResult("Release year has to be >= 1900", new[] { nameof(ReleaseYear) });
                //error = "Release year has to be >= 1900";
            };

            //error = null;
            //return true;
        }
    }
}
