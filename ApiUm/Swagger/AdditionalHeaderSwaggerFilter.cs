using ApiUm.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiUm.Swagger;

public class AdditionalHeaderSwaggerFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var hasFilter = context.ApiDescription.ActionDescriptor.FilterDescriptors
                                  .Select(filter => filter.Filter)
                                  .OfType<ServiceFilterAttribute>()
                                  .Any(filter => filter.ServiceType == typeof(AuthenticationFilter));

        if (!hasFilter)
            return;

        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Authorization",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }

}
