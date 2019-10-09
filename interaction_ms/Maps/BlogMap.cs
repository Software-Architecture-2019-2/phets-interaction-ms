using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace interaction_ms.Maps{

    public class BlogMap{

        public BlogMap(EntityTypeBuilder<Blog> entityBuilder){
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("blog");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.Title).HasColumnName("title");
            entityBuilder.Property(x => x.Description).HasColumnName("description");
        }
    }
}