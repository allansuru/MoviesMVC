﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public Genre Genre { get; set; }

       
        public byte GenreId { get; set; }
       
        public DateTime DateAdded { get; set; }
       
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

    }
}