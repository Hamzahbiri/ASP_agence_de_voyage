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
		
		public  DbSet<Destination> Destinations { get; set; }   
        public DbSet<Venue> Venues { get; set; }
        public  DbSet<Reservation> Reservations { get; set; }
        

    }
}

