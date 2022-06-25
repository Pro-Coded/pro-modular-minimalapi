namespace Modular.API.Modules;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection builder);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
