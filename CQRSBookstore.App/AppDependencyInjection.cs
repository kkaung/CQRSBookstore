using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CQRSBookstore.App.Data;
using CQRSBookstore.App.Common.Interface.Repositories;
using CQRSBookstore.App.Repositories;
using CQRSBookstore.App.Common.Auth;
using CQRSBookstore.App.Common.Interface.Account;

namespace CQRSBookstore.App;

public static class AppDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(AppDependencyInjection).Assembly);
        services.AddDbContext<DataContext>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReservationsRepository, ReservationsRepository>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
