using IdentityForge.Application.Messaging;
using IdentityForge.Application.Messaging.Behaviors;

namespace IdentityForge.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssembliesOf(typeof(DependencyInjection))
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        //services.Decorate(typeof(IQueryHandler<,>), typeof(ValidationBehavior.QueryHandler<,>));
        services.Decorate(typeof(ICommandHandler<,>), typeof(ValidationBehavior.CommandHandler<,>));
        //services.Decorate(typeof(ICommandHandler<>), typeof(ValidationBehavior.CommandBaseHandler<>));

        //services.Decorate(typeof(IQueryHandler<,>), typeof(LoggingBehavior.QueryHandler<,>));
        services.Decorate(typeof(ICommandHandler<,>), typeof(LoggingBehavior.CommandHandler<,>));
        //services.Decorate(typeof(ICommandHandler<>), typeof(LoggingBehavior.CommandBaseHandler<>));

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        return services;
    }
}
