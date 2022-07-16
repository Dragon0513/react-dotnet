using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Create
    {
        public class Command: IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler: IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Activities.Add(request.Activity);
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
