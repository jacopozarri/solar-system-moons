using Microsoft.EntityFrameworkCore;


    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<DefaultNamespace.Planet> Planet { get; set; } = default!;

        public DbSet<DefaultNamespace.Moon>? Moon { get; set; }
    }
