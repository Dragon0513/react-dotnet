using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Result<Profile>>
        {
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Profile>>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext _context, IMapper _mapper, IUserAccessor _userAccessor)
            {
                context = _context;
                mapper = _mapper;
                userAccessor = _userAccessor;
            }
            public async Task<Result<Profile>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await context.Users
                    .ProjectTo<Profile>(mapper.ConfigurationProvider, new { currentUsername = userAccessor.GetUsername() })
                    .SingleOrDefaultAsync(x => x.Username == request.Username);


                return Result<Profile>.Success(user);
            }
        }
    }
}
