using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            return services;
        }
    }
}
