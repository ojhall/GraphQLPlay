using System.Threading.Tasks;
using GraphQLPlay.GraphTypeSchema;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLPlay.Controllers
{
    [Route("api/query")]
    public class QueryController : ControllerBase
    {
        private readonly GraphQlQueryExecutor _queryExecutor;

        public QueryController(GraphQlQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<object> Query([FromBody] string query)
        {
            return await _queryExecutor.Execute(query);
        }
    }
}