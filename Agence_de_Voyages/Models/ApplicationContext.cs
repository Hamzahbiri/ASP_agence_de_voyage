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
         public DbSet<UsersModel> Users{ get; set; }
    }
}
