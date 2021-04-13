using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlogProject.Shared
{
    public class EIGENAAR
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Geef de naam op van de eigenaar.")]
        public string omschrijving { get; set; }
        [Required(ErrorMessage = "Geef een regio op.")]
        public string regio { get; set; }
    }
}
