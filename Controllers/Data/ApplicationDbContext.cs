using Microsoft.EntityFrameworkCore;

namespace ShopApp.Controllers.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
    }
}
