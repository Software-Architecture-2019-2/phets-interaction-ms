using Microsoft.EntityFrameworkCore;
using interaction_ms.Maps;

public class ApiDbContext: DbContext{

    public DbContextOptions<ApiDbContext> options;
    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options){
        this.options = options; 
    }

    public DbSet<Interaction> Interactions { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        new InteractionMap(modelBuilder.Entity<Interaction>());
    }
}