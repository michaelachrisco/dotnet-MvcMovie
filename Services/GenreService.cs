using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Services
{
    public class GenreService
    {
        public const string Classic = "Classic";
        public const string SciFi = "SciFi";

        private List<SelectListItem> genreList;

        public GenreService()
        {
            genreList = new List<SelectListItem>();

            // simulate loading data from datasource
            genreList.Add(new SelectListItem { Text = Classic, Value = Classic });
            genreList.Add(new SelectListItem { Text = SciFi, Value = SciFi });
        }

        public SelectList GetGenres()
        {
            return new SelectList(genreList, "Value", "Text", Classic);
        }
    }
}
