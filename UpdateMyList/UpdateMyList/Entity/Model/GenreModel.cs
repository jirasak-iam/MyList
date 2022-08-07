using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class GenreModel : BaseModel
    {
        public int genreId { get; set; }
        public string genreCode { get; set; }
        public string genreDesc { get; set; }
        public string genreDisplay { get { return string.IsNullOrEmpty(genreCode) ? genreDesc :  $"{genreCode} - {genreDesc}"; } }
    }
}
