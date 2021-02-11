using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Common.AutoMapper
{
    public static class MappingExtensions
    {
        public static async Task<List<TDest>> ProjectToListAsync<TDest>(this IQueryable queryable, IMapper mapper, CancellationToken cancellationToken)
        {
            return await queryable
                .ProjectTo<TDest>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
