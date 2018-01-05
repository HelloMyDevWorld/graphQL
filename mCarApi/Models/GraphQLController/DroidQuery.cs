using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mCarApi.Models
{
    public class DroidQuery : ObjectGraphType
    {
        public DroidQuery()
        {
            Field<DroidType>(
              "hero",
              resolve: context => new Droid { Id = 1, Name = "R2-D2" }
            );
        }
    }
}
