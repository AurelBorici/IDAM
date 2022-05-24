using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Perstistence.Dapper;
using Perstistence.Handlers.CommandHandler.Users;
using Perstistence.Mapper;
using System.Reflection;

namespace Perstistence;

public static class PersistenceConfig
{
    public static void AddPersistenceConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(AddUserCommandHandler).Assembly);

        var dbConnectionString = configuration.GetSection("ConnectionStrings:IDAMDatabase");
        services.AddSingleton<IDapperConnectionProvider>(x => new DapperConnectionProvider(dbConnectionString.Value));

        services.AddAutoMapper(Assembly.GetAssembly(typeof(Mapping)));
    }

}
