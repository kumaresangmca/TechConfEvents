using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using TechConf.Common.Constant;
using TechConf.Models.DTO;
using TechConf.Services.Contracts;

namespace TechConf.Web.Filters
{
    public class ApiKeyAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private IOrganizationService<OrganizationDTO>? service;
        private IOptions<APIKeyOptions>? apiKeyOptions;

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            apiKeyOptions = context.HttpContext.RequestServices.GetService(typeof(IOptions<APIKeyOptions>)) as IOptions<APIKeyOptions>;
            string? key = context.HttpContext.Request.Headers[apiKeyOptions.Value.Name];
            if (string.IsNullOrWhiteSpace(key) || !await IsApiValid(key, context))
            {
                context.Result = new UnauthorizedResult();
            }
        }
        public async Task<bool> IsApiValid(string key, AuthorizationFilterContext context)
        {
            service = context.HttpContext.RequestServices.GetService(typeof(IOrganizationService<OrganizationDTO>)) as IOrganizationService<OrganizationDTO>;
            if (service == null)
            {
                return false;
            }
            var orgainization = await service.GetByApiKeyAsync(key);
            if (orgainization == null)
            {
                return false;
            }
            context.HttpContext.Request.Headers.Add("OrganizationId", orgainization.Id.ToString());
            return true;
        }
    }
}
