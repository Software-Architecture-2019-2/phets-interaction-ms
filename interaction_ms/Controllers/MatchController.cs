using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace interaction_ms.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase {
        
        public ApiDbContext context;

        public MatchController(ApiDbContext context){
            this.context = context;
        }
        
        // GET api/values
        [HttpGet]
        public object Get() {
            // return context.Blogs.Where(b => b.Title.Contains("Title")).Select((c) => new 
            //     {
            //         Id = c.Id,
            //         Title = c.Title,
            //         Description = c.Description
            //     }
            // ).ToList();
            return context.Matches.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<List<Match>> Get(int id) {
            return context.Matches.Where(b => b.IdAnimalMain == id).ToList();
        }

        // POST api/values
        [HttpPost]
        [Route("Interaction")]
        public ActionResult Post(int id_main, int id_secondary, bool state) {

            try{
                Match match = new Match {
                    Id = 0,
                    IdAnimalMain = id_main,
                    IdAnimalSecondary = id_secondary,
                    State = state
                };
                context.Matches.Add(match);
                context.SaveChanges();
                return Ok(match);
            }
            catch{
                return BadRequest();
            }
        }
    }
}
