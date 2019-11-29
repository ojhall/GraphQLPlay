using System.Linq;
using GraphQLPlay.Data;

namespace GraphQLPlay.HotChocolate
{
    public class MyMutation
    {
        private readonly MyDbContext _dbContext;

        public MyMutation(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CloneEf RenameClone(string cloneId, string newName)
        {
            var clone = _dbContext.Clones.First(c => c.Id.ToString() == cloneId);
            clone.Name = newName;
            _dbContext.SaveChanges();
            return clone;
        }
    }
}