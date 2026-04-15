using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")] // localhost:5001/api/members
    [ApiController]
    //injection de dépendance appDbContext 
    public class MembersController(AppDbContext context) : ControllerBase
    {   //SYNCHRONE  VERSION
        // [HttpGet]
        // public ActionResult<IReadOnlyList<AppUser>> GetMembers()//Le but est uniquement de la lecture on utilise IReadOnlyList pour gagner en perf
        // {
        //     var members = context.Users.ToList();
        //     return members;
        // }

        // [HttpGet("{id}")]
        // public ActionResult<AppUser> GetMember(string id) // localhost:5001/api/members/monId
        // {
        //     var member = context.Users.Find(id);
        //     if(member == null) return NotFound();
        //     return member;
        // }
        //END SYNCHRONE VERSION

        //ASYNC  
         [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>> > GetMembers()//Le but est uniquement de la lecture on utilise IReadOnlyList pour gagner en perf
        {
            var members = await context.Users.ToListAsync();
            return members;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMember(string id) // localhost:5001/api/members/monId
        {
            var member = await context.Users.FindAsync(id);
            if(member == null) return NotFound();
            return member;
        }

    }
}
