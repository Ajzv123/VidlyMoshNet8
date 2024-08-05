using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customers> Customers { get; set; }
    }
}
