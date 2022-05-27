using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        //Command class
        //Command do not return anything
        public class Command : IRequest
        {
            //This prop is what we want to receive as a parameter from our API
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //As we are not accessing the DB we are keeping it normal and not async
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}