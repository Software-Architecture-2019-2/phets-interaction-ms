using System.Collections.Generic;

public class OInteraction
{

    public int Id { get; set; }
    public int IdMain { get; set; }
    public int IdSecondary { get; set; }
    public bool Match1 { get; set; }
    public bool? Match2 { get; set; }

    public static List<OInteraction> BuildFromInteractionsList(int refId, List<Interaction> interactions){

        if(interactions == null) return new List<OInteraction>();

        List<OInteraction> OInteractions = new List<OInteraction>();
        foreach(var interaction in interactions){
            OInteraction toAdd = new OInteraction();
            toAdd.Id = interaction.Id;

            if(interaction.IdSecondary == refId){
                if(!interaction.Match2.HasValue) continue;

                toAdd.IdMain = interaction.IdSecondary;
                toAdd.IdSecondary = interaction.IdMain;
                toAdd.Match1 = interaction.Match2.Value;
                toAdd.Match2 = interaction.Match2;
            }
            else{
                toAdd.IdMain = interaction.IdMain;
                toAdd.IdSecondary = interaction.IdSecondary;
                toAdd.Match1 = interaction.Match1;
                toAdd.Match2 = interaction.Match2;
            }
            OInteractions.Add(toAdd);
        }
        return OInteractions;
    }
}