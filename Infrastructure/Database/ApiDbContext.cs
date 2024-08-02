using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Database
{
    public class ApiDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApiDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Season> Seasons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQL"))
                .UseSnakeCaseNamingConvention();
        }
    }
}