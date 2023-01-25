using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CQRSBookstore.App.Data;

namespace CQRSBookstore.App;

public class AppDependencyInjection
{
    public static IServiceCollection AddApplication(IServiceCollection services) {
        services.AddMediatR(typeof(AppDependencyInjection).Assembly);
        services.AddDbContext<DataContext>();
        return services;
    }
}