using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace interaction_ms.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : ControllerBase {
        
        public ApiDbContext context;

        public InteractionController(ApiDbContext context){
            this.context = context;
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
        }

        // GET api/interaction/Match?id1=1&id2=2
        [HttpGet]
        [Route("Match")]
        public ActionResult<Match> Get(int id1, int id2) {

            Match match = new Match();
            try{
                
                if(context.Interactions.Any(x => (x.IdMain == id2 && x.IdSecondary == id1 && x.Match1 && x.Match2 != null && x.Match2 == true))){
                    match.State = true;
                    return match;
                }
                else if(context.Interactions.Any(x => (x.IdMain == id1 && x.IdSecondary == id2 && x.Match1 && x.Match2 != null && x.Match2 == true))){
                    match.State = true;
                    return match;
                }
            }
            catch{
                return BadRequest();
            }
            match.State = false;
            return match;
        }

        // POST api/interaction/Create?id1=1&id2=1&state=true
        [HttpPost]
        [Route("Create")]
        public ActionResult<Interaction> Post(int id1, int id2, bool state) {

            try{
                //If the other dog has interacted with me
                if(context.Interactions.Any(x => (x.IdMain == id2 && x.IdSecondary == id1))){
                    Interaction interaction = context.Interactions.FirstOrDefault(x => (x.IdMain == id2 && x.IdSecondary == id1));
                    interaction.Match2 = state;
                    interaction = context.Interactions.FirstOrDefault(x => x.IdMain == id2 && x.IdSecondary == id1);
                    context.SaveChanges();
                    return interaction;
                }
                else{// Im the first interaction
                    Interaction interaction = new Interaction {
                        Id = 0,
                        IdMain = id1,
                        IdSecondary = id2,
                        Match1 = state,
                        Match2 = null
                    };
                    context.Interactions.Add(interaction);
                    context.SaveChanges();
                    return interaction;
                }
            }
            catch{
                return BadRequest();
            }
        }

        // PUT api/interaction/Unlike?id1=1&id2=1
        [HttpPut]
        [Route("Unlike")]
        public ActionResult<Interaction> Put(int id1, int id2) {

            try{
                //If the other dog has interacted with me
                if(context.Interactions.Any(x => (x.IdMain == id2 && x.IdSecondary == id1))){
                    Interaction interaction = context.Interactions.FirstOrDefault(x => (x.IdMain == id2 && x.IdSecondary == id1));
                    interaction.Match2 = false;
                    context.SaveChanges();
                    return interaction;
                }
                else{// Im the first interaction
                    Interaction interaction = context.Interactions.FirstOrDefault(x => (x.IdMain == id1 && x.IdSecondary == id2));
                    interaction.Match1 = false;
                    context.SaveChanges();
                    return interaction;
                }
            }
            catch{
                return BadRequest();
            }
        }
    }
}
