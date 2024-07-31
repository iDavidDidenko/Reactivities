using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities
{
    // Handle Query
    public class MyList
    {
        // the Query class implements IRequest<List<Activity>>, meaning it is a request that expects a List<Activity> as a response.
        //The Query class implements IRequest<List<Activity>>. This means it is a request to retrieve a list of activities. It does not have any properties or methods; it simply represents the request.
        public class Query : IRequest<List<Activity>> {}
        //pass Query class, Return List of activities.

        // IRequestHandler<Query, List<Activity>>. This means it is responsible for handling Query requests and returning a List<Activity> as the response.
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            // CancellationToken us to actually cancel the request if it's no longer needed.
            public async Task<List<Activity>> Handle(Query request, CancellationToken token)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}