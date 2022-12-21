using Application;

namespace Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllCommandHandlers(this IServiceCollection services,
            ServiceLifetime withLifetime = ServiceLifetime.Transient)
        {
            return services.Scan(scan => scan
                .FromApplicationDependencies()
                .AddClasses(classes =>
                    classes.AssignableTo(typeof(ICommandHandler<>))
                        .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition)).AsSelfWithInterfaces()
                .WithLifetime(withLifetime));
        }

        public static IServiceCollection AddAllQueryHandlers(this IServiceCollection service,
            ServiceLifetime withLifetime = ServiceLifetime.Transient)
        {
            return service.Scan(scan => scan
                .FromApplicationDependencies()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>))
                    .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition)).AsSelfWithInterfaces()
                .WithLifetime(withLifetime));
        }
    }
}
