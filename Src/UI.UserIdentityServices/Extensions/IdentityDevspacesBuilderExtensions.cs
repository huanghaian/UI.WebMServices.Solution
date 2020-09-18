using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.UserIdentityServices.Extensions
{
    static class IdentityDevspacesBuilderExtensions
    {
        public static IIdentityServerBuilder AddDevspacesIfNeeded(this IIdentityServerBuilder builder, bool useDevspaces)
        {
            if (useDevspaces)
            {
                //builder.AddRedirectUriValidator<DevspacesRedirectUriValidator>();
            }
            return builder;
        }
    }
}
