using Domain;
using Microsoft.AspNetCore.Mvc;
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
            return await Mediator.Send(new Details.Query {Id = id});
        }

        [HttpPost] // IActionResult to return http response
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            await Mediator.Send(new Create.Command {Activity = activity});
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            await Mediator.Send(new Edit.Command {Activity = activity});

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command {Id = id});
            return Ok();
        }



    }
}