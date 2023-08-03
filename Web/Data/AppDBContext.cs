using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Web.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){}
        
    public DbSet<User> Users { get; set; }

}