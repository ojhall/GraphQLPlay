using EntityGraphQL;
using EntityGraphQL.Schema;
using GraphQLPlay.Data;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLPlay.Controllers
{
    [Route("api/query")]
    public class QueryController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        private readonly MappedSchemaProvider<MyDbContext> _schemaProvider;

        public QueryController(MyDbContext myDbContext, MappedSchemaProvider<MyDbContext> schemaProvider)
        {
            _myDbContext = myDbContext;
            _schemaProvider = schemaProvider;
        }

        [HttpPost]
        public object Post([FromBody] QueryRequest query)
        {
            var results = _myDbContext.QueryObject(query, _schemaProvider);
            return results;
        }
    }
}