using Domain;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Activities;



namespace API.Controllers
{
    public class ActivitiesController : BaseApiController // Inheritance
    {
        // the idea is, when http request comes in,
        // our program know where this requiest needs to go.
        // it's send it to "ActivitiesController" 
        // creating 2 end-points.
        [HttpGet] // api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new MyList.Query());
        }

        // define a Root-parameter.
        [HttpGet("{id}")] // api/activities/X (X is the ID parameter)
        public async Task<ActionResult<Activity>> GetActivity(Guid id) // id need to match the name id
        {
            return Ok();
        }

    }
}