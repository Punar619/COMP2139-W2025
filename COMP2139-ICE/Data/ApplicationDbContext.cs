using Microsoft.EntityFrameworkCore;

namespace COMP2139_ICE.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}