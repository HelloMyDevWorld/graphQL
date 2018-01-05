using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mCarApi.Models;
using GraphQL.Types;
using GraphQL;

namespace mCarApi.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        /**
         * http://localhost:4370/graphql
         * Content-Type: application/json
         * {"Query": "query { hero {  id name  } }"}
        **/

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = new DroidQuery() };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
