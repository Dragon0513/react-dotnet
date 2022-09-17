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

namespace Application.Followers
{
    public class List
    {
        public class Query : IRequest<Result<List<Profiles.Profile>>>
        {
            public string Predicate { get; set; }
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Profiles.Profile>>>
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
            public async Task<Result<List<Profiles.Profile>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var profiles = new List<Profiles.Profile>();

                switch(request.Predicate)
                {
                    case "followers":
                        profiles = await context.UserFollowings.Where(x => x.Target.UserName == request.Username)
                            .Select(u => u.Observer)
                            .ProjectTo<Profiles.Profile>(mapper.ConfigurationProvider, new { currentUsername = userAccessor.GetUsername()})
                            .ToListAsync();
                        break;

                    case "following":
                        profiles = await context.UserFollowings.Where(x => x.Observer.UserName == request.Username)
                            .Select(u => u.Target)
                            .ProjectTo<Profiles.Profile>(mapper.ConfigurationProvider, new { currentUsername = userAccessor.GetUsername() })
                            .ToListAsync();
                        break;
                }

                return Result<List<Profiles.Profile>>.Success(profiles);
            }
        }
    }
}
