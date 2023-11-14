using Agence_de_Voyages.Models;
using Microsoft.EntityFrameworkCore;

namespace Agence_de_Voyages.Models
{
    public class ApplicationContext :DbContext 
    {
        public ApplicationContext(DbContextOptions options )
            :base(options)
            
        {

        }
         public DbSet<User> Users{ get; set; }
        public DbSet<Tour> Tours { get; set; }
        }
}

