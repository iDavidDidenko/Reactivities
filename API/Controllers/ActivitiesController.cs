using Domain;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers
{
    public class ActivitiesController : BaseApiController // Inheritance
    {
        private readonly DataContext _context;

        // the idea is, when http request comes in,
        // our program know where this requiest needs to go.
        // it's send it to "ActivitiesController" 
        // and create a new "instance" of "DataContext.
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        // creating 2 end-points.
        [HttpGet] // api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        // define a Root-parameter.
        [HttpGet("{id}")] // api/activities/X (X is the ID parameter)
        public async Task<ActionResult<Activity>> GetActivity(Guid id) // id need to match the name id
        {
            return await _context.Activities.FindAsync(id);
        }

    }
}