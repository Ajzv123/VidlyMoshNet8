﻿using System.ComponentModel.DataAnnotations;

namespace VidlyMoshNet8.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public Genre Genre { get; set; }

        
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        
        
        [Display(Name = "Number in Stock")]
        [Range(1, 100)]
        public byte NumberInStock { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        
    }
}
