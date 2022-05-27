using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        //This mediator class queries for a single activity
        public class Query : IRequest<Activity>
        {
            //Prop to handle
            public Guid Id { get; set; }
        }

        //Handler class
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