﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace JoelMovies.Models
{
    public class ApplicationResponse
    {
        //public ApplicationResponse()

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; } 

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        
        public string Edited { get; set; }


        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
        //}
    }
}