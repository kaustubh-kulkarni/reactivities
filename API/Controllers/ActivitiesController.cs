using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
    //Derive from base api controller 
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        //Dependency injection of data context from persistance
        public ActivitiesController(DataContext context)
        {
            _context = context;  
        }

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] //api/activities/guid
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id); 
        }

    }
}