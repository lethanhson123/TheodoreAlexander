using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace TA_Web_2020_API.Helper
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter
                {
                    name = "Ip_Address",
                    @in = "header",
                    description = "access ip address",
                    required = false,
                    type = "string"
                },
                new Parameter
                {
                    name = "API_KEY",
                    @in = "header",
                    description = "access api key",
                    required = false,
                    type = "string"
                },
                new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "access token (If you trying to login, please ignore this condition)",
                    required = false,
                    type = "string"
                }

            };
            if (operation.parameters != null)
            {
                foreach (var param in parameters) {
                    operation.parameters.Add(param);
                };
            }
            else
            {
                operation.parameters = parameters;  
            }
        }
    }
}