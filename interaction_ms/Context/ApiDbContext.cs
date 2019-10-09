using Microsoft.EntityFrameworkCore;
using interaction_ms.Maps;

public class ApiDbContext: DbContext{

    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options){}

    public DbSet<Match> Matches { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        new MatchMap(modelBuilder.Entity<Match>());
    }
}