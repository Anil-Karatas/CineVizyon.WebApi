using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVizyon.Business.Dtos
{
    public class AddMovieDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Director { get; set; }
        // Dto'yu açtıktan sonra Servicese gidip tanımlıyoruz.
        public decimal UnitPrice { get; set; }
        public bool IsDiscounted { get; set; }
    }
}
