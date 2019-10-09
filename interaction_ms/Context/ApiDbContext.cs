using Microsoft.EntityFrameworkCore;
using interaction_ms.Maps;

public class ApiDbContext: DbContext{

    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options){}

    public DbSet<Blog> Blogs { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        new BlogMap(modelBuilder.Entity<Blog>());
    }
}