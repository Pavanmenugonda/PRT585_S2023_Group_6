using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1CommonInfrastructure.Models
{
    public class MovieModel
    {
        public int MovieId { get; set; } // int
        public string MovieName { get; set; } // nvarchar(400)
        public string? Genre { get; set; } // nvarchar(30)
        public DateTime? ReleaseDate { get; set; }
        public string? Description { set; get; } // nvarvarchar(400)
        public bool IsDeleted { get; set; } // bit
    }
}
