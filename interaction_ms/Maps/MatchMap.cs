using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace interaction_ms.Maps{

    public class MatchMap{

        public MatchMap(EntityTypeBuilder<Match> entityBuilder){
            entityBuilder.HasKey(x => new {x.Id});
            entityBuilder.ToTable("interactions");

            entityBuilder.Property(x => x.Id).HasColumnName("id_match");
            entityBuilder.Property(x => x.IdAnimalMain).HasColumnName("id_animal_main");
            entityBuilder.Property(x => x.IdAnimalSecondary).HasColumnName("id_animal_secondary");
            entityBuilder.Property(x => x.State).HasColumnName("match_state");
        }
    }
}