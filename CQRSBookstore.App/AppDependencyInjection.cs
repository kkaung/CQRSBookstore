using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSBookstore.App;

public class AppDependencyInjection
{
    public static IServiceCollection AddApplication(IServiceCollection services) {

        services.AddMediatR(typeof(AppDependencyInjection).Assembly);
        return services;
    }
}