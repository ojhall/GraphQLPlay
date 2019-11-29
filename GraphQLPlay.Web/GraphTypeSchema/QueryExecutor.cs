using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLPlay.Data;

namespace GraphQLPlay.GraphTypeSchema
{
    public class GraphQlQueryExecutor
    {
        private readonly Schema _schema;

        public GraphQlQueryExecutor(MyDbContext dbContext)
        {
            _schema = new Schema {Query = new TopLevelQuery(dbContext)};
        }

        public Task<string> Execute(string query)
        {
            return _schema.ExecuteAsync(_ => { _.Query = query; });
        }
    }
}