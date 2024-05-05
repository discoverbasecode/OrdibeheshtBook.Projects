using Framework.Core.Common.Application.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Core.Common.Application
{
    public class CommonBootstrapper
    {
        public static void Init(IServiceCollection service)
        {
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        }
    }
}