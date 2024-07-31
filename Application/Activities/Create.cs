using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        // Query return data, Command do not.
        public class Command : IRequest //when use -> '<>' we return the type
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            // the 'request' should hold an activity object.
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();
            }
        }
    }
}