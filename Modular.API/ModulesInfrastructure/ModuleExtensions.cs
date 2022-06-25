﻿namespace Modular.API.Modules;

public static class ModuleExtensions
{
    // this could also be added into the DI container
    private static readonly List<IModule> registeredModules = new();

    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        IEnumerable<IModule>? modules = DiscoverModules();
        foreach (IModule? module in modules)
        {
            _ = module.RegisterModule(services);
            registeredModules.Add(module);
        }

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (IModule? module in registeredModules)
        {
            _ = module.MapEndpoints(app);
        }

        return app;
    }

    private static IEnumerable<IModule> DiscoverModules() => typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
}