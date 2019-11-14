using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Swagger.Net;
namespace swaggernet_apikey
{
    public class TokenFilter : Attribute, IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var ls = apiDescription.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>()
                .Union(apiDescription.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AuthorizeAttribute>())
                ;
            if (ls.Any())
            {
                if (operation.parameters == null)
                {
                    operation.parameters = new List<Parameter>();
                }
                //operation.parameters.Add(new Parameter
                //{
                //    name = "WoTrusToken",
                //    @in = "header",
                //    type = "string",
                //    required = true // set to false if this is optional
                //});
                operation.responses.Add("401", new Response { description = "Unauthorized" });
                //var oAuthScheme = new ApiKeyScheme
                //{
                //    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                //};
                //if (operation.security == null)
                //{
                //    operation.security = new List< IDictionary<string, IEnumerable<string>>>();
                //}
                //Dictionary<string, IEnumerable<string>> dt = new Dictionary<string, IEnumerable<string>>();
                //dt.Add("apikey", new List<string> { "123" });
                //operation.security.Add(dt);
            }
        }
    }
}