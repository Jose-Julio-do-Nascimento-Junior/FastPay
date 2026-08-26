using FastPay.Core.Infra.Data.Sql.Models;
using FastPay.Transactions.Domain.Contracts.v1.Repositories;
using FastPay.Transactions.Infra.Data.Sql.DataBase.v1;
using FastPay.Transactions.Infra.Data.Sql.Repositories.v1;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Transactions.Api;

public static class Bootstrapper
{
    public static IServiceCollection AddApplicationBootstrapper(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IClientSequenceRepository, ClientSequenceRepository>();
        services.AddScoped<IAccountSequenceRepository, AccountSequenceRepository>();
        return services;
    }

    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlSettings = configuration.GetSection(SqlSettings.SessionName).Get<SqlSettings>();
        ArgumentNullException.ThrowIfNull(sqlSettings);
        services.AddSingleton(sqlSettings);

        services.AddDbContext<DataContext>(options => options.UseSqlServer(sqlSettings.ConnectionString));

        return services;
    }
}