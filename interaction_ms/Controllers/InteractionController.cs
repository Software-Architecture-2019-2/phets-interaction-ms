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

        // POST api/interaction/Create?id_main=1&id_secondary=1&match_1=true
        [HttpPost]
        [Route("Create")]
        public ActionResult Post(int id_main, int id_secondary, bool match_1) {

            try{
                //If the other dog has interacted with me
                if(context.Interactions.Any(x => (x.IdMain == id_secondary && x.IdSecondary == id_main))){
                    Interaction interaction = context.Interactions.FirstOrDefault(x => (x.IdMain == id_secondary && x.IdSecondary == id_main));
                    interaction.Match2 = match_1;
                    context.SaveChanges();
                    return Ok(interaction);
                }
                else{// Im the first interaction
                    Interaction interaction = new Interaction {
                        Id = 0,
                        IdMain = id_main,
                        IdSecondary = id_secondary,
                        Match1 = match_1,
                        Match2 = null
                    };
                    context.Interactions.Add(interaction);
                    context.SaveChanges();
                    return Ok(interaction);
                }
            }
            catch{
                return BadRequest();
            }
        }

        // PUT api/interaction/Unlike?id_main=1&id_secondary=1
        [HttpPut]
        [Route("Unlike")]
        public ActionResult Put(int id_main, int id_secondary) {

            try{
                //If the other dog has interacted with me
                if(context.Interactions.Any(x => (x.IdMain == id_secondary && x.IdSecondary == id_main))){
                    Interaction interaction = context.Interactions.FirstOrDefault(x => (x.IdMain == id_secondary && x.IdSecondary == id_main));
                    interaction.Match2 = false;
                    context.SaveChanges();
                    return Ok(interaction);
                }
                else{// Im the first interaction
                    Interaction interaction = context.Interactions.FirstOrDefault(x => (x.IdMain == id_main && x.IdSecondary == id_secondary));
                    interaction.Match1 = false;
                    context.SaveChanges();
                    return Ok(interaction);
                }
            }
            catch{
                return BadRequest();
            }
        }

        // GET api/interaction/Match?id_main=1&id_secondary=1
        [HttpGet]
        [Route("Match")]
        public ActionResult<Match> Get(int id1, int id2) {

            Match match = new Match();
            if(context.Interactions.Any(x => (x.IdMain == id2 && x.IdSecondary == id1 && x.Match1 && x.Match2 != null && x.Match2 == true))){
                match.State = true;
                return match;
            }
            else if(context.Interactions.Any(x => (x.IdMain == id1 && x.IdSecondary == id2 && x.Match1 && x.Match2 != null && x.Match2 == true))){
                match.State = true;
                return match;
            }
            return BadRequest();
        }
    }
}
