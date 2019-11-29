using System.Collections.Generic;
using GraphQLPlay.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLPlay.HotChocolate
{
    public class MyQuery
    {
        private readonly MyDbContext _dbContext;

        public MyQuery(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CloneEf> Clones()
        {
            return _dbContext.Clones.Include(c => c.ParentImage);
        }

        public IEnumerable<ImageEf> Images()
        {
            return _dbContext.Images;
        }
    }
}