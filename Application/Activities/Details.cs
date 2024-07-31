using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        // Query feach data only.
        // activity is the table represents a class.
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        // handler class.
        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.FindAsync(request.Id);
            }

        }


    }
}