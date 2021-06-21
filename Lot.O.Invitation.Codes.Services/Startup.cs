/*
 * Third Party Code that is not to be changed.
 */
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lot.O.Invitation.Codes.Services
{
    public static class Startup
    {
        public static void SetupLotOInvitationCodes(this IServiceCollection services, string apiKey)
        {
            services.AddSingleton<IRuntimeInfo, RuntimeInfo>();
            services.AddTransient<IEntropyService, EntropyService>((provider) => new EntropyService(provider.GetRequiredService<IRuntimeInfo>(), apiKey));
        }
    }
}
