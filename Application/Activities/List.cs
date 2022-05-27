using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    //Class to list the activities
    public class List
    {
        //Mediator class to list the activities
        //It extends an interface IRequest which is from mediator
        //It takes List and activity as a param
        public class Query : IRequest<List<Activity>>
        {

        }

        //Handler class from mediator
        //Takes Query as param and returns list of activities
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            //Data context as a dependency to constructor
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}