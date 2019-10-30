using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace interaction_ms.Maps{

    public class InteractionMap{

        public InteractionMap(EntityTypeBuilder<Interaction> entityBuilder){
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("interactions");

            entityBuilder.Property(x => x.Id).HasColumnName("id_match");
            entityBuilder.Property(x => x.IdMain).HasColumnName("id_main");
            entityBuilder.Property(x => x.IdSecondary).HasColumnName("id_secondary");
            entityBuilder.Property(x => x.Match1).HasColumnName("match_1");
            entityBuilder.Property(x => x.Match2).HasColumnName("match_2");

            entityBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}