﻿using System.ComponentModel.DataAnnotations;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }


        public byte GenreId { get; set; }

        public GenreDTO Genre { get; set; }

        [Range(1, 100)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
